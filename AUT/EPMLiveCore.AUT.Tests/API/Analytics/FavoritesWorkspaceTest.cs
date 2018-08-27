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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.FavoritesWorkspace" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class FavoritesWorkspaceTest : AbstractBaseSetupTest
    {
        public FavoritesWorkspaceTest() : base(typeof(FavoritesWorkspace))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FavoritesWorkspace) Initializer

        private const string MethodIsFavWorkspace = "IsFavWorkspace";
        private const string MethodAddFavWorkspace = "AddFavWorkspace";
        private const string MethodRemoveFavWorkspace = "RemoveFavWorkspace";
        private const string MethodClearCache = "ClearCache";
        private Type _favoritesWorkspaceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (FavoritesWorkspace) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FavoritesWorkspace" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _favoritesWorkspaceInstanceType = typeof(FavoritesWorkspace);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FavoritesWorkspace)

        #region General Initializer : Class (FavoritesWorkspace) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="FavoritesWorkspace" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodIsFavWorkspace, 0)]
        [TestCase(MethodAddFavWorkspace, 0)]
        [TestCase(MethodRemoveFavWorkspace, 0)]
        [TestCase(MethodClearCache, 0)]
        public void AUT_FavoritesWorkspace_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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
        ///     Class (<see cref="FavoritesWorkspace" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_FavoritesWorkspace_Is_Static_Type_Present_Test()
        {
            // Assert
            _favoritesWorkspaceInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="FavoritesWorkspace" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodIsFavWorkspace)]
        [TestCase(MethodAddFavWorkspace)]
        [TestCase(MethodRemoveFavWorkspace)]
        [TestCase(MethodClearCache)]
        public void AUT_FavoritesWorkspace_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _favoritesWorkspaceInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (IsFavWorkspace) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FavoritesWorkspace_IsFavWorkspace_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsFavWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodIsFavWorkspace, Fixture, methodIsFavWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (IsFavWorkspace) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_IsFavWorkspace_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => FavoritesWorkspace.IsFavWorkspace(xml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IsFavWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_IsFavWorkspace_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodIsFavWorkspacePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsFavWorkspace = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsFavWorkspace, methodIsFavWorkspacePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodIsFavWorkspace, Fixture, methodIsFavWorkspacePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesWorkspaceInstanceType, MethodIsFavWorkspace, parametersOfIsFavWorkspace, methodIsFavWorkspacePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIsFavWorkspace);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfIsFavWorkspace.ShouldNotBeNull();
            parametersOfIsFavWorkspace.Length.ShouldBe(1);
            methodIsFavWorkspacePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (IsFavWorkspace) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_IsFavWorkspace_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodIsFavWorkspacePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsFavWorkspace = { xml };

            // Assert
            parametersOfIsFavWorkspace.ShouldNotBeNull();
            parametersOfIsFavWorkspace.Length.ShouldBe(1);
            methodIsFavWorkspacePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesWorkspaceInstanceType, MethodIsFavWorkspace, parametersOfIsFavWorkspace, methodIsFavWorkspacePrametersTypes));
        }

        #endregion

        #region Method Call : (IsFavWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_IsFavWorkspace_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIsFavWorkspacePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodIsFavWorkspace, Fixture, methodIsFavWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodIsFavWorkspacePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsFavWorkspace) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_IsFavWorkspace_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsFavWorkspacePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodIsFavWorkspace, Fixture, methodIsFavWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsFavWorkspacePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsFavWorkspace) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_IsFavWorkspace_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsFavWorkspace, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsFavWorkspace) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_IsFavWorkspace_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsFavWorkspace, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFavWorkspace) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FavoritesWorkspace_AddFavWorkspace_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddFavWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodAddFavWorkspace, Fixture, methodAddFavWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (AddFavWorkspace) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_AddFavWorkspace_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => FavoritesWorkspace.AddFavWorkspace(xml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddFavWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_AddFavWorkspace_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodAddFavWorkspacePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddFavWorkspace = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddFavWorkspace, methodAddFavWorkspacePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodAddFavWorkspace, Fixture, methodAddFavWorkspacePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesWorkspaceInstanceType, MethodAddFavWorkspace, parametersOfAddFavWorkspace, methodAddFavWorkspacePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAddFavWorkspace);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddFavWorkspace.ShouldNotBeNull();
            parametersOfAddFavWorkspace.Length.ShouldBe(1);
            methodAddFavWorkspacePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFavWorkspace) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_AddFavWorkspace_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodAddFavWorkspacePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddFavWorkspace = { xml };

            // Assert
            parametersOfAddFavWorkspace.ShouldNotBeNull();
            parametersOfAddFavWorkspace.Length.ShouldBe(1);
            methodAddFavWorkspacePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesWorkspaceInstanceType, MethodAddFavWorkspace, parametersOfAddFavWorkspace, methodAddFavWorkspacePrametersTypes));
        }

        #endregion

        #region Method Call : (AddFavWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_AddFavWorkspace_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddFavWorkspacePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodAddFavWorkspace, Fixture, methodAddFavWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddFavWorkspacePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddFavWorkspace) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_AddFavWorkspace_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFavWorkspacePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodAddFavWorkspace, Fixture, methodAddFavWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddFavWorkspacePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFavWorkspace) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_AddFavWorkspace_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFavWorkspace, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddFavWorkspace) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_AddFavWorkspace_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFavWorkspace, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveFavWorkspace) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FavoritesWorkspace_RemoveFavWorkspace_Static_Method_Call_Internally(Type[] types)
        {
            var methodRemoveFavWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodRemoveFavWorkspace, Fixture, methodRemoveFavWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveFavWorkspace) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_RemoveFavWorkspace_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => FavoritesWorkspace.RemoveFavWorkspace(xml);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RemoveFavWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_RemoveFavWorkspace_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodRemoveFavWorkspacePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveFavWorkspace = { xml };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemoveFavWorkspace, methodRemoveFavWorkspacePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodRemoveFavWorkspace, Fixture, methodRemoveFavWorkspacePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesWorkspaceInstanceType, MethodRemoveFavWorkspace, parametersOfRemoveFavWorkspace, methodRemoveFavWorkspacePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfRemoveFavWorkspace);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfRemoveFavWorkspace.ShouldNotBeNull();
            parametersOfRemoveFavWorkspace.Length.ShouldBe(1);
            methodRemoveFavWorkspacePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RemoveFavWorkspace) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_RemoveFavWorkspace_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xml = CreateType<string>();
            var methodRemoveFavWorkspacePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRemoveFavWorkspace = { xml };

            // Assert
            parametersOfRemoveFavWorkspace.ShouldNotBeNull();
            parametersOfRemoveFavWorkspace.Length.ShouldBe(1);
            methodRemoveFavWorkspacePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _favoritesWorkspaceInstanceType, MethodRemoveFavWorkspace, parametersOfRemoveFavWorkspace, methodRemoveFavWorkspacePrametersTypes));
        }

        #endregion

        #region Method Call : (RemoveFavWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_RemoveFavWorkspace_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodRemoveFavWorkspacePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodRemoveFavWorkspace, Fixture, methodRemoveFavWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodRemoveFavWorkspacePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (RemoveFavWorkspace) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_RemoveFavWorkspace_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveFavWorkspacePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodRemoveFavWorkspace, Fixture, methodRemoveFavWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveFavWorkspacePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveFavWorkspace) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_RemoveFavWorkspace_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveFavWorkspace, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RemoveFavWorkspace) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_RemoveFavWorkspace_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveFavWorkspace, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_FavoritesWorkspace_ClearCache_Static_Method_Call_Internally(Type[] types)
        {
            var methodClearCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_ClearCache_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
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
        public void AUT_FavoritesWorkspace_ClearCache_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<AnalyticsData>();
            var methodClearCachePrametersTypes = new Type[] { typeof(AnalyticsData) };
            object[] parametersOfClearCache = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _favoritesWorkspaceInstanceType, MethodClearCache, parametersOfClearCache, methodClearCachePrametersTypes);

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
        public void AUT_FavoritesWorkspace_ClearCache_Static_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_FavoritesWorkspace_ClearCache_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodClearCachePrametersTypes = new Type[] { typeof(AnalyticsData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _favoritesWorkspaceInstanceType, MethodClearCache, Fixture, methodClearCachePrametersTypes);

            // Assert
            methodClearCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_FavoritesWorkspace_ClearCache_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
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

        #endregion

        #endregion
    }
}