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

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.AnalyzerDataCache" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AnalyzerDataCacheTest : AbstractBaseSetupTypedTest<AnalyzerDataCache>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AnalyzerDataCache) Initializer

        private const string MethodSaveStashEntry = "SaveStashEntry";
        private const string MethodGetStashEntry = "GetStashEntry";
        private const string Field_sqlConnection = "_sqlConnection";
        private Type _analyzerDataCacheInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AnalyzerDataCache _analyzerDataCacheInstance;
        private AnalyzerDataCache _analyzerDataCacheInstanceFixture;

        #region General Initializer : Class (AnalyzerDataCache) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AnalyzerDataCache" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _analyzerDataCacheInstanceType = typeof(AnalyzerDataCache);
            _analyzerDataCacheInstanceFixture = Create(true);
            _analyzerDataCacheInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AnalyzerDataCache)

        #region General Initializer : Class (AnalyzerDataCache) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AnalyzerDataCache" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodSaveStashEntry, 0)]
        [TestCase(MethodGetStashEntry, 0)]
        public void AUT_AnalyzerDataCache_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_analyzerDataCacheInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AnalyzerDataCache) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AnalyzerDataCache" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_sqlConnection)]
        public void AUT_AnalyzerDataCache_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_analyzerDataCacheInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AnalyzerDataCache) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="AnalyzerDataCache" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_AnalyzerDataCache_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<AnalyzerDataCache>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (AnalyzerDataCache) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="AnalyzerDataCache" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AnalyzerDataCache_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<AnalyzerDataCache>(Fixture);
        }

        #endregion

        #region General Constructor : Class (AnalyzerDataCache) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AnalyzerDataCache" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AnalyzerDataCache_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfAnalyzerDataCache = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodAnalyzerDataCachePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_analyzerDataCacheInstanceType, methodAnalyzerDataCachePrametersTypes, parametersOfAnalyzerDataCache);
        }

        #endregion

        #region General Constructor : Class (AnalyzerDataCache) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AnalyzerDataCache" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AnalyzerDataCache_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodAnalyzerDataCachePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_analyzerDataCacheInstanceType, Fixture, methodAnalyzerDataCachePrametersTypes);
        }

        #endregion

        #region General Constructor : Class (AnalyzerDataCache) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AnalyzerDataCache" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AnalyzerDataCache_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            object[] parametersOfAnalyzerDataCache = { sBaseInfo };
            var methodAnalyzerDataCachePrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_analyzerDataCacheInstanceType, methodAnalyzerDataCachePrametersTypes, parametersOfAnalyzerDataCache);
        }

        #endregion

        #region General Constructor : Class (AnalyzerDataCache) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="AnalyzerDataCache" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_AnalyzerDataCache_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodAnalyzerDataCachePrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_analyzerDataCacheInstanceType, Fixture, methodAnalyzerDataCachePrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="AnalyzerDataCache" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodSaveStashEntry)]
        [TestCase(MethodGetStashEntry)]
        public void AUT_AnalyzerDataCache_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AnalyzerDataCache>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (SaveStashEntry) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AnalyzerDataCache_SaveStashEntry_Method_Call_Internally(Type[] types)
        {
            var methodSaveStashEntryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_analyzerDataCacheInstance, MethodSaveStashEntry, Fixture, methodSaveStashEntryPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveStashEntry) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_SaveStashEntry_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sKey = CreateType<string>();
            var sData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _analyzerDataCacheInstance.SaveStashEntry(sKey, sData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveStashEntry) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_SaveStashEntry_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sKey = CreateType<string>();
            var sData = CreateType<string>();
            var methodSaveStashEntryPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSaveStashEntry = { sKey, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveStashEntry, methodSaveStashEntryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AnalyzerDataCache, bool>(_analyzerDataCacheInstanceFixture, out exception1, parametersOfSaveStashEntry);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AnalyzerDataCache, bool>(_analyzerDataCacheInstance, MethodSaveStashEntry, parametersOfSaveStashEntry, methodSaveStashEntryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveStashEntry.ShouldNotBeNull();
            parametersOfSaveStashEntry.Length.ShouldBe(2);
            methodSaveStashEntryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveStashEntry) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_SaveStashEntry_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sKey = CreateType<string>();
            var sData = CreateType<string>();
            var methodSaveStashEntryPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSaveStashEntry = { sKey, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveStashEntry, methodSaveStashEntryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AnalyzerDataCache, bool>(_analyzerDataCacheInstanceFixture, out exception1, parametersOfSaveStashEntry);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AnalyzerDataCache, bool>(_analyzerDataCacheInstance, MethodSaveStashEntry, parametersOfSaveStashEntry, methodSaveStashEntryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveStashEntry.ShouldNotBeNull();
            parametersOfSaveStashEntry.Length.ShouldBe(2);
            methodSaveStashEntryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (SaveStashEntry) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_SaveStashEntry_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sKey = CreateType<string>();
            var sData = CreateType<string>();
            var methodSaveStashEntryPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfSaveStashEntry = { sKey, sData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AnalyzerDataCache, bool>(_analyzerDataCacheInstance, MethodSaveStashEntry, parametersOfSaveStashEntry, methodSaveStashEntryPrametersTypes);

            // Assert
            parametersOfSaveStashEntry.ShouldNotBeNull();
            parametersOfSaveStashEntry.Length.ShouldBe(2);
            methodSaveStashEntryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveStashEntry) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_SaveStashEntry_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveStashEntryPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_analyzerDataCacheInstance, MethodSaveStashEntry, Fixture, methodSaveStashEntryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveStashEntryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveStashEntry) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_SaveStashEntry_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveStashEntry, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_analyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveStashEntry) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_SaveStashEntry_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveStashEntry, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStashEntry) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AnalyzerDataCache_GetStashEntry_Method_Call_Internally(Type[] types)
        {
            var methodGetStashEntryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_analyzerDataCacheInstance, MethodGetStashEntry, Fixture, methodGetStashEntryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetStashEntry) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_GetStashEntry_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sKey = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _analyzerDataCacheInstance.GetStashEntry(sKey);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetStashEntry) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_GetStashEntry_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sKey = CreateType<string>();
            var methodGetStashEntryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetStashEntry = { sKey };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetStashEntry, methodGetStashEntryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<AnalyzerDataCache, string>(_analyzerDataCacheInstanceFixture, out exception1, parametersOfGetStashEntry);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<AnalyzerDataCache, string>(_analyzerDataCacheInstance, MethodGetStashEntry, parametersOfGetStashEntry, methodGetStashEntryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetStashEntry.ShouldNotBeNull();
            parametersOfGetStashEntry.Length.ShouldBe(1);
            methodGetStashEntryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetStashEntry) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_GetStashEntry_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sKey = CreateType<string>();
            var methodGetStashEntryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetStashEntry = { sKey };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<AnalyzerDataCache, string>(_analyzerDataCacheInstance, MethodGetStashEntry, parametersOfGetStashEntry, methodGetStashEntryPrametersTypes);

            // Assert
            parametersOfGetStashEntry.ShouldNotBeNull();
            parametersOfGetStashEntry.Length.ShouldBe(1);
            methodGetStashEntryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetStashEntry) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_GetStashEntry_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetStashEntryPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_analyzerDataCacheInstance, MethodGetStashEntry, Fixture, methodGetStashEntryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetStashEntryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetStashEntry) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_GetStashEntry_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetStashEntryPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_analyzerDataCacheInstance, MethodGetStashEntry, Fixture, methodGetStashEntryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetStashEntryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetStashEntry) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_GetStashEntry_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetStashEntry, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_analyzerDataCacheInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetStashEntry) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AnalyzerDataCache_GetStashEntry_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetStashEntry, 0);
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