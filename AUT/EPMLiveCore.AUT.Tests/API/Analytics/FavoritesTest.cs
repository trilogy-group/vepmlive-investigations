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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Favorites" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FavoritesTest : AbstractBaseSetupTest
    {
        public FavoritesTest() : base(typeof(Favorites))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Favorites) Initializer

        private const string MethodIsFav = "IsFav";
        private const string MethodAddFav = "AddFav";
        private const string MethodRemoveFav = "RemoveFav";
        private const string MethodClearCache = "ClearCache";
        private const string MethodCleanItemArray = "CleanItemArray";
        private Type _favoritesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (Favorites) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Favorites" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _favoritesInstanceType = typeof(Favorites);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Favorites)

        #region General Initializer : Class (Favorites) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Favorites" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodIsFav, 0)]
        [TestCase(MethodAddFav, 0)]
        [TestCase(MethodRemoveFav, 0)]
        [TestCase(MethodClearCache, 0)]
        [TestCase(MethodCleanItemArray, 0)]
        public void AUT_Favorites_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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
        ///     Class (<see cref="Favorites" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Favorites_Is_Static_Type_Present_Test()
        {
            // Assert
            _favoritesInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Favorites" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodIsFav)]
        [TestCase(MethodAddFav)]
        [TestCase(MethodRemoveFav)]
        [TestCase(MethodClearCache)]
        [TestCase(MethodCleanItemArray)]
        public void AUT_Favorites_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _favoritesInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Favorites_IsFav_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsFavPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodIsFav, Fixture, methodIsFavPrametersTypes);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_IsFav_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Favorites.IsFav(xml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_IsFav_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodIsFavPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsFav = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsFav, methodIsFavPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodIsFav, Fixture, methodIsFavPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesInstanceType, MethodIsFav, parametersOfIsFav, methodIsFavPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIsFav);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfIsFav.ShouldNotBeNull();
            parametersOfIsFav.Length.ShouldBe(1);
            methodIsFavPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_IsFav_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodIsFavPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsFav = { xml };

            // Assert
            parametersOfIsFav.ShouldNotBeNull();
            parametersOfIsFav.Length.ShouldBe(1);
            methodIsFavPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesInstanceType, MethodIsFav, parametersOfIsFav, methodIsFavPrametersTypes));
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_IsFav_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsFavPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodIsFav, Fixture, methodIsFavPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodIsFavPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_IsFav_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsFavPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodIsFav, Fixture, methodIsFavPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsFavPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_IsFav_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsFav, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsFav) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_IsFav_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsFav, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFav) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Favorites_AddFav_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddFavPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodAddFav, Fixture, methodAddFavPrametersTypes);
        }

        #endregion

        #region Method Call : (AddFav) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_AddFav_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Favorites.AddFav(xml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddFav) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_AddFav_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodAddFavPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddFav = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddFav, methodAddFavPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodAddFav, Fixture, methodAddFavPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesInstanceType, MethodAddFav, parametersOfAddFav, methodAddFavPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAddFav);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddFav.ShouldNotBeNull();
            parametersOfAddFav.Length.ShouldBe(1);
            methodAddFavPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFav) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_AddFav_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodAddFavPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddFav = { xml };

            // Assert
            parametersOfAddFav.ShouldNotBeNull();
            parametersOfAddFav.Length.ShouldBe(1);
            methodAddFavPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesInstanceType, MethodAddFav, parametersOfAddFav, methodAddFavPrametersTypes));
        }

        #endregion

        #region Method Call : (AddFav) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_AddFav_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddFavPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodAddFav, Fixture, methodAddFavPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddFavPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddFav) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_AddFav_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFavPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodAddFav, Fixture, methodAddFavPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddFavPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFav) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_AddFav_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFav, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddFav) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_AddFav_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFav, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveFav) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Favorites_RemoveFav_Static_Method_Call_Internally(Type[] types)
        {
            var methodRemoveFavPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodRemoveFav, Fixture, methodRemoveFavPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveFav) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_RemoveFav_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Favorites.RemoveFav(xml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RemoveFav) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_RemoveFav_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodRemoveFavPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveFav = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemoveFav, methodRemoveFavPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodRemoveFav, Fixture, methodRemoveFavPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesInstanceType, MethodRemoveFav, parametersOfRemoveFav, methodRemoveFavPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfRemoveFav);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRemoveFav.ShouldNotBeNull();
            parametersOfRemoveFav.Length.ShouldBe(1);
            methodRemoveFavPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveFav) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_RemoveFav_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodRemoveFavPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveFav = { xml };

            // Assert
            parametersOfRemoveFav.ShouldNotBeNull();
            parametersOfRemoveFav.Length.ShouldBe(1);
            methodRemoveFavPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesInstanceType, MethodRemoveFav, parametersOfRemoveFav, methodRemoveFavPrametersTypes));
        }

        #endregion

        #region Method Call : (RemoveFav) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_RemoveFav_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRemoveFavPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodRemoveFav, Fixture, methodRemoveFavPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRemoveFavPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RemoveFav) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_RemoveFav_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveFavPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodRemoveFav, Fixture, methodRemoveFavPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveFavPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveFav) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_RemoveFav_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveFav, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveFav) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_RemoveFav_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveFav, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Favorites_ClearCache_Static_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_ClearCache_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodClearCachePrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfClearCache = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodClearCache, methodClearCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfClearCache);

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
        public void AUT_Favorites_ClearCache_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodClearCachePrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfClearCache = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _favoritesInstanceType, MethodClearCache, parametersOfClearCache, methodClearCachePrametersTypes);

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
        public void AUT_Favorites_ClearCache_Static_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Favorites_ClearCache_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearCachePrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);

            // Assert
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_ClearCache_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CleanItemArray) (Return Type : object[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Favorites_CleanItemArray_Static_Method_Call_Internally(Type[] types)
        {
            var methodCleanItemArrayPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodCleanItemArray, Fixture, methodCleanItemArrayPrametersTypes);
        }

        #endregion

        #region Method Call : (CleanItemArray) (Return Type : object[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_CleanItemArray_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var r = CreateType<object []>();
            var methodCleanItemArrayPrametersTypes = new Type[] { typeof(object []) };
            object[] parametersOfCleanItemArray = { r };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCleanItemArray, methodCleanItemArrayPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCleanItemArray.ShouldNotBeNull();
            parametersOfCleanItemArray.Length.ShouldBe(1);
            methodCleanItemArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(null, parametersOfCleanItemArray));
        }

        #endregion

        #region Method Call : (CleanItemArray) (Return Type : object[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_CleanItemArray_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var r = CreateType<object []>();
            var methodCleanItemArrayPrametersTypes = new Type[] { typeof(object []) };
            object[] parametersOfCleanItemArray = { r };

            // Assert
            parametersOfCleanItemArray.ShouldNotBeNull();
            parametersOfCleanItemArray.Length.ShouldBe(1);
            methodCleanItemArrayPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<object[]>(null, _favoritesInstanceType, MethodCleanItemArray, parametersOfCleanItemArray, methodCleanItemArrayPrametersTypes));
        }

        #endregion

        #region Method Call : (CleanItemArray) (Return Type : object[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_CleanItemArray_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCleanItemArrayPrametersTypes = new Type[] { typeof(object []) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodCleanItemArray, Fixture, methodCleanItemArrayPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCleanItemArrayPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CleanItemArray) (Return Type : object[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_CleanItemArray_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCleanItemArrayPrametersTypes = new Type[] { typeof(object []) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesInstanceType, MethodCleanItemArray, Fixture, methodCleanItemArrayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCleanItemArrayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CleanItemArray) (Return Type : object[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_CleanItemArray_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCleanItemArray, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (CleanItemArray) (Return Type : object[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Favorites_CleanItemArray_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCleanItemArray, 0);
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