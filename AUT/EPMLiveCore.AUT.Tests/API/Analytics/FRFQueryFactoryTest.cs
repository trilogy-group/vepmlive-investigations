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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.FRFQueryFactory" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FRFQueryFactoryTest : AbstractBaseSetupTest
    {
        public FRFQueryFactoryTest() : base(typeof(FRFQueryFactory))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FRFQueryFactory) Initializer

        private const string MethodGetQuery = "GetQuery";
        private const string MethodGetFavoriteQueries = "GetFavoriteQueries";
        private const string MethodGetFavoriteWorkspaceQueries = "GetFavoriteWorkspaceQueries";
        private const string MethodGetFrequentQueries = "GetFrequentQueries";
        private const string MethodGetRecentQueries = "GetRecentQueries";
        private const string MethodGetCreateFavoriteQuery = "GetCreateFavoriteQuery";
        private const string MethodGetRemoveFavoriteQuery = "GetRemoveFavoriteQuery";
        private const string MethodGetReadFavoriteQuery = "GetReadFavoriteQuery";
        private const string MethodGetCreateFavWorkSpaceQuery = "GetCreateFavWorkSpaceQuery";
        private const string MethodGetRemoveFavWorkSpaceQuery = "GetRemoveFavWorkSpaceQuery";
        private const string MethodGetReadFavWorkSpaceQuery = "GetReadFavWorkSpaceQuery";
        private const string MethodGetCreateFrequentQuery = "GetCreateFrequentQuery";
        private const string MethodGetRemoveFrequentQuery = "GetRemoveFrequentQuery";
        private const string MethodGetReadFrequentQuery = "GetReadFrequentQuery";
        private const string MethodGetUpdateFrequentQuery = "GetUpdateFrequentQuery";
        private const string MethodGetCreateRecentItemQuery = "GetCreateRecentItemQuery";
        private const string FieldqueryCheckFavStatus_Item = "queryCheckFavStatus_Item";
        private const string FieldqueryCheckFavStatus_NonItem = "queryCheckFavStatus_NonItem";
        private const string FieldqueryCreateFav_Item = "queryCreateFav_Item";
        private const string FieldqueryCreateFav_NonItem = "queryCreateFav_NonItem";
        private const string FieldqueryRemoveFav_Item = "queryRemoveFav_Item";
        private const string FieldqueryRemoveFav_NonItem = "queryRemoveFav_NonItem";
        private const string FieldqueryReadFavWSStatus_Item = "queryReadFavWSStatus_Item";
        private const string FieldqueryReadFavWSStatus_NonItem = "queryReadFavWSStatus_NonItem";
        private const string FieldqueryCreateFavWS_Item = "queryCreateFavWS_Item";
        private const string FieldqueryCreateFavWS_NonItem = "queryCreateFavWS_NonItem";
        private const string FieldqueryRemoveFavWS_Item = "queryRemoveFavWS_Item";
        private const string FieldqueryRemoveFavWS_NonItem = "queryRemoveFavWS_NonItem";
        private const string FieldqueryCheckFrequentStatus_Item = "queryCheckFrequentStatus_Item";
        private const string FieldqueryCheckFrequentStatus_NonItem = "queryCheckFrequentStatus_NonItem";
        private const string FieldqueryCreateFrequent = "queryCreateFrequent";
        private const string FieldqueryRemoveFrequent_Item = "queryRemoveFrequent_Item";
        private const string FieldqueryRemoveFrequent_NonItem = "queryRemoveFrequent_NonItem";
        private const string FieldqueryCreateRecentItem = "queryCreateRecentItem";
        private Type _fRFQueryFactoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (FRFQueryFactory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FRFQueryFactory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _fRFQueryFactoryInstanceType = typeof(FRFQueryFactory);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FRFQueryFactory)

        #region General Initializer : Class (FRFQueryFactory) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="FRFQueryFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetQuery, 0)]
        [TestCase(MethodGetFavoriteQueries, 0)]
        [TestCase(MethodGetFavoriteWorkspaceQueries, 0)]
        [TestCase(MethodGetFrequentQueries, 0)]
        [TestCase(MethodGetRecentQueries, 0)]
        [TestCase(MethodGetCreateFavoriteQuery, 0)]
        [TestCase(MethodGetRemoveFavoriteQuery, 0)]
        [TestCase(MethodGetReadFavoriteQuery, 0)]
        [TestCase(MethodGetCreateFavWorkSpaceQuery, 0)]
        [TestCase(MethodGetRemoveFavWorkSpaceQuery, 0)]
        [TestCase(MethodGetReadFavWorkSpaceQuery, 0)]
        [TestCase(MethodGetCreateFrequentQuery, 0)]
        [TestCase(MethodGetRemoveFrequentQuery, 0)]
        [TestCase(MethodGetReadFrequentQuery, 0)]
        [TestCase(MethodGetUpdateFrequentQuery, 0)]
        [TestCase(MethodGetCreateRecentItemQuery, 0)]
        public void AUT_FRFQueryFactory_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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
        ///     Class (<see cref="FRFQueryFactory" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_FRFQueryFactory_Is_Static_Type_Present_Test()
        {
            // Assert
            _fRFQueryFactoryInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="FRFQueryFactory" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetQuery)]
        [TestCase(MethodGetFavoriteQueries)]
        [TestCase(MethodGetFavoriteWorkspaceQueries)]
        [TestCase(MethodGetFrequentQueries)]
        [TestCase(MethodGetRecentQueries)]
        [TestCase(MethodGetCreateFavoriteQuery)]
        [TestCase(MethodGetRemoveFavoriteQuery)]
        [TestCase(MethodGetReadFavoriteQuery)]
        [TestCase(MethodGetCreateFavWorkSpaceQuery)]
        [TestCase(MethodGetRemoveFavWorkSpaceQuery)]
        [TestCase(MethodGetReadFavWorkSpaceQuery)]
        [TestCase(MethodGetCreateFrequentQuery)]
        [TestCase(MethodGetRemoveFrequentQuery)]
        [TestCase(MethodGetReadFrequentQuery)]
        [TestCase(MethodGetUpdateFrequentQuery)]
        [TestCase(MethodGetCreateRecentItemQuery)]
        public void AUT_FRFQueryFactory_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _fRFQueryFactoryInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetQuery, Fixture, methodGetQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetQuery_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            Action executeAction = null;

            // Act
            executeAction = () => FRFQueryFactory.GetQuery(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetQuery, methodGetQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetQuery, Fixture, methodGetQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetQuery, parametersOfGetQuery, methodGetQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetQuery.ShouldNotBeNull();
            parametersOfGetQuery.Length.ShouldBe(1);
            methodGetQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetQuery = { data };

            // Assert
            parametersOfGetQuery.ShouldNotBeNull();
            parametersOfGetQuery.Length.ShouldBe(1);
            methodGetQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetQuery, parametersOfGetQuery, methodGetQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetQuery, Fixture, methodGetQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetQuery, Fixture, methodGetQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavoriteQueries) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetFavoriteQueries_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFavoriteQueriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteQueries, Fixture, methodGetFavoriteQueriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFavoriteQueries) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteQueries_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFavoriteQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFavoriteQueries = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFavoriteQueries, methodGetFavoriteQueriesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteQueries, Fixture, methodGetFavoriteQueriesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteQueries, parametersOfGetFavoriteQueries, methodGetFavoriteQueriesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFavoriteQueries);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFavoriteQueries.ShouldNotBeNull();
            parametersOfGetFavoriteQueries.Length.ShouldBe(1);
            methodGetFavoriteQueriesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFavoriteQueries) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteQueries_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFavoriteQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFavoriteQueries = { data };

            // Assert
            parametersOfGetFavoriteQueries.ShouldNotBeNull();
            parametersOfGetFavoriteQueries.Length.ShouldBe(1);
            methodGetFavoriteQueriesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteQueries, parametersOfGetFavoriteQueries, methodGetFavoriteQueriesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFavoriteQueries) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteQueries_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFavoriteQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteQueries, Fixture, methodGetFavoriteQueriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFavoriteQueriesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFavoriteQueries) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteQueries_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFavoriteQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteQueries, Fixture, methodGetFavoriteQueriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFavoriteQueriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavoriteQueries) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteQueries_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFavoriteQueries, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFavoriteQueries) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteQueries_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFavoriteQueries, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaceQueries) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetFavoriteWorkspaceQueries_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFavoriteWorkspaceQueriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteWorkspaceQueries, Fixture, methodGetFavoriteWorkspaceQueriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaceQueries) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteWorkspaceQueries_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFavoriteWorkspaceQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFavoriteWorkspaceQueries = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFavoriteWorkspaceQueries, methodGetFavoriteWorkspaceQueriesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteWorkspaceQueries, Fixture, methodGetFavoriteWorkspaceQueriesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteWorkspaceQueries, parametersOfGetFavoriteWorkspaceQueries, methodGetFavoriteWorkspaceQueriesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFavoriteWorkspaceQueries);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFavoriteWorkspaceQueries.ShouldNotBeNull();
            parametersOfGetFavoriteWorkspaceQueries.Length.ShouldBe(1);
            methodGetFavoriteWorkspaceQueriesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaceQueries) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteWorkspaceQueries_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFavoriteWorkspaceQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFavoriteWorkspaceQueries = { data };

            // Assert
            parametersOfGetFavoriteWorkspaceQueries.ShouldNotBeNull();
            parametersOfGetFavoriteWorkspaceQueries.Length.ShouldBe(1);
            methodGetFavoriteWorkspaceQueriesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteWorkspaceQueries, parametersOfGetFavoriteWorkspaceQueries, methodGetFavoriteWorkspaceQueriesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaceQueries) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteWorkspaceQueries_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFavoriteWorkspaceQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteWorkspaceQueries, Fixture, methodGetFavoriteWorkspaceQueriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFavoriteWorkspaceQueriesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaceQueries) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteWorkspaceQueries_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFavoriteWorkspaceQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFavoriteWorkspaceQueries, Fixture, methodGetFavoriteWorkspaceQueriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFavoriteWorkspaceQueriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaceQueries) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteWorkspaceQueries_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFavoriteWorkspaceQueries, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFavoriteWorkspaceQueries) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFavoriteWorkspaceQueries_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFavoriteWorkspaceQueries, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFrequentQueries) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetFrequentQueries_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFrequentQueriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFrequentQueries, Fixture, methodGetFrequentQueriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFrequentQueries) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFrequentQueries_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFrequentQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFrequentQueries = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFrequentQueries, methodGetFrequentQueriesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFrequentQueries, Fixture, methodGetFrequentQueriesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetFrequentQueries, parametersOfGetFrequentQueries, methodGetFrequentQueriesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFrequentQueries);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFrequentQueries.ShouldNotBeNull();
            parametersOfGetFrequentQueries.Length.ShouldBe(1);
            methodGetFrequentQueriesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFrequentQueries) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFrequentQueries_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetFrequentQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetFrequentQueries = { data };

            // Assert
            parametersOfGetFrequentQueries.ShouldNotBeNull();
            parametersOfGetFrequentQueries.Length.ShouldBe(1);
            methodGetFrequentQueriesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetFrequentQueries, parametersOfGetFrequentQueries, methodGetFrequentQueriesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetFrequentQueries) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFrequentQueries_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFrequentQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFrequentQueries, Fixture, methodGetFrequentQueriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFrequentQueriesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFrequentQueries) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFrequentQueries_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFrequentQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetFrequentQueries, Fixture, methodGetFrequentQueriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFrequentQueriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFrequentQueries) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFrequentQueries_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFrequentQueries, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFrequentQueries) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetFrequentQueries_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFrequentQueries, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRecentQueries) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetRecentQueries_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRecentQueriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRecentQueries, Fixture, methodGetRecentQueriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRecentQueries) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRecentQueries_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRecentQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRecentQueries = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRecentQueries, methodGetRecentQueriesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRecentQueries, Fixture, methodGetRecentQueriesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetRecentQueries, parametersOfGetRecentQueries, methodGetRecentQueriesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRecentQueries);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRecentQueries.ShouldNotBeNull();
            parametersOfGetRecentQueries.Length.ShouldBe(1);
            methodGetRecentQueriesPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRecentQueries) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRecentQueries_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRecentQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRecentQueries = { data };

            // Assert
            parametersOfGetRecentQueries.ShouldNotBeNull();
            parametersOfGetRecentQueries.Length.ShouldBe(1);
            methodGetRecentQueriesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetRecentQueries, parametersOfGetRecentQueries, methodGetRecentQueriesPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRecentQueries) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRecentQueries_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRecentQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRecentQueries, Fixture, methodGetRecentQueriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRecentQueriesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRecentQueries) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRecentQueries_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRecentQueriesPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRecentQueries, Fixture, methodGetRecentQueriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRecentQueriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRecentQueries) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRecentQueries_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRecentQueries, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRecentQueries) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRecentQueries_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRecentQueries, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetCreateFavoriteQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCreateFavoriteQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavoriteQuery, Fixture, methodGetCreateFavoriteQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavoriteQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFavoriteQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCreateFavoriteQuery, methodGetCreateFavoriteQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavoriteQuery, Fixture, methodGetCreateFavoriteQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavoriteQuery, parametersOfGetCreateFavoriteQuery, methodGetCreateFavoriteQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetCreateFavoriteQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCreateFavoriteQuery.ShouldNotBeNull();
            parametersOfGetCreateFavoriteQuery.Length.ShouldBe(1);
            methodGetCreateFavoriteQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavoriteQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFavoriteQuery = { data };

            // Assert
            parametersOfGetCreateFavoriteQuery.ShouldNotBeNull();
            parametersOfGetCreateFavoriteQuery.Length.ShouldBe(1);
            methodGetCreateFavoriteQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavoriteQuery, parametersOfGetCreateFavoriteQuery, methodGetCreateFavoriteQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavoriteQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCreateFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavoriteQuery, Fixture, methodGetCreateFavoriteQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCreateFavoriteQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavoriteQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCreateFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavoriteQuery, Fixture, methodGetCreateFavoriteQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreateFavoriteQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavoriteQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreateFavoriteQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreateFavoriteQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavoriteQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCreateFavoriteQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetRemoveFavoriteQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRemoveFavoriteQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavoriteQuery, Fixture, methodGetRemoveFavoriteQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavoriteQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRemoveFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRemoveFavoriteQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRemoveFavoriteQuery, methodGetRemoveFavoriteQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavoriteQuery, Fixture, methodGetRemoveFavoriteQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavoriteQuery, parametersOfGetRemoveFavoriteQuery, methodGetRemoveFavoriteQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRemoveFavoriteQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRemoveFavoriteQuery.ShouldNotBeNull();
            parametersOfGetRemoveFavoriteQuery.Length.ShouldBe(1);
            methodGetRemoveFavoriteQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavoriteQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRemoveFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRemoveFavoriteQuery = { data };

            // Assert
            parametersOfGetRemoveFavoriteQuery.ShouldNotBeNull();
            parametersOfGetRemoveFavoriteQuery.Length.ShouldBe(1);
            methodGetRemoveFavoriteQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavoriteQuery, parametersOfGetRemoveFavoriteQuery, methodGetRemoveFavoriteQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavoriteQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRemoveFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavoriteQuery, Fixture, methodGetRemoveFavoriteQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRemoveFavoriteQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavoriteQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRemoveFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavoriteQuery, Fixture, methodGetRemoveFavoriteQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRemoveFavoriteQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavoriteQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRemoveFavoriteQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRemoveFavoriteQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavoriteQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRemoveFavoriteQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReadFavoriteQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetReadFavoriteQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReadFavoriteQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFavoriteQuery, Fixture, methodGetReadFavoriteQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReadFavoriteQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavoriteQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetReadFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetReadFavoriteQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetReadFavoriteQuery, methodGetReadFavoriteQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFavoriteQuery, Fixture, methodGetReadFavoriteQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetReadFavoriteQuery, parametersOfGetReadFavoriteQuery, methodGetReadFavoriteQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetReadFavoriteQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReadFavoriteQuery.ShouldNotBeNull();
            parametersOfGetReadFavoriteQuery.Length.ShouldBe(1);
            methodGetReadFavoriteQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetReadFavoriteQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavoriteQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetReadFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetReadFavoriteQuery = { data };

            // Assert
            parametersOfGetReadFavoriteQuery.ShouldNotBeNull();
            parametersOfGetReadFavoriteQuery.Length.ShouldBe(1);
            methodGetReadFavoriteQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetReadFavoriteQuery, parametersOfGetReadFavoriteQuery, methodGetReadFavoriteQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetReadFavoriteQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavoriteQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReadFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFavoriteQuery, Fixture, methodGetReadFavoriteQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReadFavoriteQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetReadFavoriteQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavoriteQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReadFavoriteQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFavoriteQuery, Fixture, methodGetReadFavoriteQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReadFavoriteQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReadFavoriteQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavoriteQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReadFavoriteQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReadFavoriteQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavoriteQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReadFavoriteQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFavWorkSpaceQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetCreateFavWorkSpaceQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCreateFavWorkSpaceQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavWorkSpaceQuery, Fixture, methodGetCreateFavWorkSpaceQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreateFavWorkSpaceQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavWorkSpaceQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFavWorkSpaceQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCreateFavWorkSpaceQuery, methodGetCreateFavWorkSpaceQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavWorkSpaceQuery, Fixture, methodGetCreateFavWorkSpaceQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavWorkSpaceQuery, parametersOfGetCreateFavWorkSpaceQuery, methodGetCreateFavWorkSpaceQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetCreateFavWorkSpaceQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCreateFavWorkSpaceQuery.ShouldNotBeNull();
            parametersOfGetCreateFavWorkSpaceQuery.Length.ShouldBe(1);
            methodGetCreateFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCreateFavWorkSpaceQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavWorkSpaceQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFavWorkSpaceQuery = { data };

            // Assert
            parametersOfGetCreateFavWorkSpaceQuery.ShouldNotBeNull();
            parametersOfGetCreateFavWorkSpaceQuery.Length.ShouldBe(1);
            methodGetCreateFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavWorkSpaceQuery, parametersOfGetCreateFavWorkSpaceQuery, methodGetCreateFavWorkSpaceQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCreateFavWorkSpaceQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavWorkSpaceQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCreateFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavWorkSpaceQuery, Fixture, methodGetCreateFavWorkSpaceQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCreateFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCreateFavWorkSpaceQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavWorkSpaceQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCreateFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFavWorkSpaceQuery, Fixture, methodGetCreateFavWorkSpaceQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreateFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFavWorkSpaceQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavWorkSpaceQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreateFavWorkSpaceQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCreateFavWorkSpaceQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFavWorkSpaceQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCreateFavWorkSpaceQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkSpaceQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetRemoveFavWorkSpaceQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRemoveFavWorkSpaceQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavWorkSpaceQuery, Fixture, methodGetRemoveFavWorkSpaceQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkSpaceQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavWorkSpaceQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRemoveFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRemoveFavWorkSpaceQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRemoveFavWorkSpaceQuery, methodGetRemoveFavWorkSpaceQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavWorkSpaceQuery, Fixture, methodGetRemoveFavWorkSpaceQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavWorkSpaceQuery, parametersOfGetRemoveFavWorkSpaceQuery, methodGetRemoveFavWorkSpaceQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRemoveFavWorkSpaceQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRemoveFavWorkSpaceQuery.ShouldNotBeNull();
            parametersOfGetRemoveFavWorkSpaceQuery.Length.ShouldBe(1);
            methodGetRemoveFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkSpaceQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavWorkSpaceQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRemoveFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRemoveFavWorkSpaceQuery = { data };

            // Assert
            parametersOfGetRemoveFavWorkSpaceQuery.ShouldNotBeNull();
            parametersOfGetRemoveFavWorkSpaceQuery.Length.ShouldBe(1);
            methodGetRemoveFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavWorkSpaceQuery, parametersOfGetRemoveFavWorkSpaceQuery, methodGetRemoveFavWorkSpaceQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkSpaceQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavWorkSpaceQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRemoveFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavWorkSpaceQuery, Fixture, methodGetRemoveFavWorkSpaceQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRemoveFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkSpaceQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavWorkSpaceQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRemoveFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFavWorkSpaceQuery, Fixture, methodGetRemoveFavWorkSpaceQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRemoveFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkSpaceQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavWorkSpaceQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRemoveFavWorkSpaceQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRemoveFavWorkSpaceQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFavWorkSpaceQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRemoveFavWorkSpaceQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReadFavWorkSpaceQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetReadFavWorkSpaceQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReadFavWorkSpaceQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFavWorkSpaceQuery, Fixture, methodGetReadFavWorkSpaceQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReadFavWorkSpaceQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavWorkSpaceQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetReadFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetReadFavWorkSpaceQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetReadFavWorkSpaceQuery, methodGetReadFavWorkSpaceQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFavWorkSpaceQuery, Fixture, methodGetReadFavWorkSpaceQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetReadFavWorkSpaceQuery, parametersOfGetReadFavWorkSpaceQuery, methodGetReadFavWorkSpaceQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetReadFavWorkSpaceQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReadFavWorkSpaceQuery.ShouldNotBeNull();
            parametersOfGetReadFavWorkSpaceQuery.Length.ShouldBe(1);
            methodGetReadFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetReadFavWorkSpaceQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavWorkSpaceQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetReadFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetReadFavWorkSpaceQuery = { data };

            // Assert
            parametersOfGetReadFavWorkSpaceQuery.ShouldNotBeNull();
            parametersOfGetReadFavWorkSpaceQuery.Length.ShouldBe(1);
            methodGetReadFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetReadFavWorkSpaceQuery, parametersOfGetReadFavWorkSpaceQuery, methodGetReadFavWorkSpaceQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetReadFavWorkSpaceQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavWorkSpaceQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReadFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFavWorkSpaceQuery, Fixture, methodGetReadFavWorkSpaceQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReadFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetReadFavWorkSpaceQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavWorkSpaceQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReadFavWorkSpaceQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFavWorkSpaceQuery, Fixture, methodGetReadFavWorkSpaceQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReadFavWorkSpaceQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReadFavWorkSpaceQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavWorkSpaceQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReadFavWorkSpaceQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReadFavWorkSpaceQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFavWorkSpaceQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReadFavWorkSpaceQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFrequentQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetCreateFrequentQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCreateFrequentQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFrequentQuery, Fixture, methodGetCreateFrequentQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreateFrequentQuery) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFrequentQuery_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFrequentQuery = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCreateFrequentQuery, methodGetCreateFrequentQueryPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCreateFrequentQuery.ShouldNotBeNull();
            parametersOfGetCreateFrequentQuery.Length.ShouldBe(1);
            methodGetCreateFrequentQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(null, parametersOfGetCreateFrequentQuery));
        }

        #endregion

        #region Method Call : (GetCreateFrequentQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFrequentQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateFrequentQuery = { data };

            // Assert
            parametersOfGetCreateFrequentQuery.ShouldNotBeNull();
            parametersOfGetCreateFrequentQuery.Length.ShouldBe(1);
            methodGetCreateFrequentQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetCreateFrequentQuery, parametersOfGetCreateFrequentQuery, methodGetCreateFrequentQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCreateFrequentQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFrequentQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCreateFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFrequentQuery, Fixture, methodGetCreateFrequentQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCreateFrequentQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCreateFrequentQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFrequentQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCreateFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateFrequentQuery, Fixture, methodGetCreateFrequentQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreateFrequentQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateFrequentQuery) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFrequentQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreateFrequentQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCreateFrequentQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateFrequentQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCreateFrequentQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRemoveFrequentQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetRemoveFrequentQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRemoveFrequentQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFrequentQuery, Fixture, methodGetRemoveFrequentQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRemoveFrequentQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFrequentQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRemoveFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRemoveFrequentQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRemoveFrequentQuery, methodGetRemoveFrequentQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFrequentQuery, Fixture, methodGetRemoveFrequentQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFrequentQuery, parametersOfGetRemoveFrequentQuery, methodGetRemoveFrequentQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRemoveFrequentQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRemoveFrequentQuery.ShouldNotBeNull();
            parametersOfGetRemoveFrequentQuery.Length.ShouldBe(1);
            methodGetRemoveFrequentQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRemoveFrequentQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFrequentQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetRemoveFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetRemoveFrequentQuery = { data };

            // Assert
            parametersOfGetRemoveFrequentQuery.ShouldNotBeNull();
            parametersOfGetRemoveFrequentQuery.Length.ShouldBe(1);
            methodGetRemoveFrequentQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFrequentQuery, parametersOfGetRemoveFrequentQuery, methodGetRemoveFrequentQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetRemoveFrequentQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFrequentQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRemoveFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFrequentQuery, Fixture, methodGetRemoveFrequentQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRemoveFrequentQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRemoveFrequentQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFrequentQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRemoveFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetRemoveFrequentQuery, Fixture, methodGetRemoveFrequentQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRemoveFrequentQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRemoveFrequentQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFrequentQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRemoveFrequentQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRemoveFrequentQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetRemoveFrequentQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRemoveFrequentQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReadFrequentQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetReadFrequentQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReadFrequentQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFrequentQuery, Fixture, methodGetReadFrequentQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReadFrequentQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFrequentQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetReadFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetReadFrequentQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetReadFrequentQuery, methodGetReadFrequentQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFrequentQuery, Fixture, methodGetReadFrequentQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetReadFrequentQuery, parametersOfGetReadFrequentQuery, methodGetReadFrequentQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetReadFrequentQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReadFrequentQuery.ShouldNotBeNull();
            parametersOfGetReadFrequentQuery.Length.ShouldBe(1);
            methodGetReadFrequentQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetReadFrequentQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFrequentQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetReadFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetReadFrequentQuery = { data };

            // Assert
            parametersOfGetReadFrequentQuery.ShouldNotBeNull();
            parametersOfGetReadFrequentQuery.Length.ShouldBe(1);
            methodGetReadFrequentQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetReadFrequentQuery, parametersOfGetReadFrequentQuery, methodGetReadFrequentQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetReadFrequentQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFrequentQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReadFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFrequentQuery, Fixture, methodGetReadFrequentQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReadFrequentQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetReadFrequentQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFrequentQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReadFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetReadFrequentQuery, Fixture, methodGetReadFrequentQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReadFrequentQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReadFrequentQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFrequentQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReadFrequentQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReadFrequentQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetReadFrequentQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReadFrequentQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetUpdateFrequentQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetUpdateFrequentQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetUpdateFrequentQuery, Fixture, methodGetUpdateFrequentQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetUpdateFrequentQuery_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetUpdateFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetUpdateFrequentQuery = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUpdateFrequentQuery, methodGetUpdateFrequentQueryPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetUpdateFrequentQuery, Fixture, methodGetUpdateFrequentQueryPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetUpdateFrequentQuery, parametersOfGetUpdateFrequentQuery, methodGetUpdateFrequentQueryPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetUpdateFrequentQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUpdateFrequentQuery.ShouldNotBeNull();
            parametersOfGetUpdateFrequentQuery.Length.ShouldBe(1);
            methodGetUpdateFrequentQueryPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetUpdateFrequentQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetUpdateFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetUpdateFrequentQuery = { data };

            // Assert
            parametersOfGetUpdateFrequentQuery.ShouldNotBeNull();
            parametersOfGetUpdateFrequentQuery.Length.ShouldBe(1);
            methodGetUpdateFrequentQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetUpdateFrequentQuery, parametersOfGetUpdateFrequentQuery, methodGetUpdateFrequentQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetUpdateFrequentQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUpdateFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetUpdateFrequentQuery, Fixture, methodGetUpdateFrequentQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUpdateFrequentQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetUpdateFrequentQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUpdateFrequentQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetUpdateFrequentQuery, Fixture, methodGetUpdateFrequentQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUpdateFrequentQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetUpdateFrequentQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUpdateFrequentQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUpdateFrequentQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetUpdateFrequentQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUpdateFrequentQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FRFQueryFactory_GetCreateRecentItemQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCreateRecentItemQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateRecentItemQuery, Fixture, methodGetCreateRecentItemQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQuery) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateRecentItemQuery_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateRecentItemQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateRecentItemQuery = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCreateRecentItemQuery, methodGetCreateRecentItemQueryPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCreateRecentItemQuery.ShouldNotBeNull();
            parametersOfGetCreateRecentItemQuery.Length.ShouldBe(1);
            methodGetCreateRecentItemQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(null, parametersOfGetCreateRecentItemQuery));
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateRecentItemQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodGetCreateRecentItemQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfGetCreateRecentItemQuery = { data };

            // Assert
            parametersOfGetCreateRecentItemQuery.ShouldNotBeNull();
            parametersOfGetCreateRecentItemQuery.Length.ShouldBe(1);
            methodGetCreateRecentItemQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _fRFQueryFactoryInstanceType, MethodGetCreateRecentItemQuery, parametersOfGetCreateRecentItemQuery, methodGetCreateRecentItemQueryPrametersTypes));
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateRecentItemQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCreateRecentItemQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateRecentItemQuery, Fixture, methodGetCreateRecentItemQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCreateRecentItemQueryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateRecentItemQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCreateRecentItemQueryPrametersTypes = new Type[] { typeof(AnalyticsData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _fRFQueryFactoryInstanceType, MethodGetCreateRecentItemQuery, Fixture, methodGetCreateRecentItemQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCreateRecentItemQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQuery) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateRecentItemQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCreateRecentItemQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCreateRecentItemQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FRFQueryFactory_GetCreateRecentItemQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCreateRecentItemQuery, 0);
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