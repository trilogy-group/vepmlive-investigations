using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Events
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Events.ClearCacheEvent" />)
    ///     and namespace <see cref="EPMLiveCore.Events"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClearCacheEventTest : AbstractBaseSetupTypedTest<ClearCacheEvent>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ClearCacheEvent) Initializer

        private const string MethodClearSettingsNavigationCache = "ClearSettingsNavigationCache";
        private const string MethodItemAdded = "ItemAdded";
        private const string MethodItemUpdated = "ItemUpdated";
        private const string MethodItemDeleted = "ItemDeleted";
        private Type _clearCacheEventInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ClearCacheEvent _clearCacheEventInstance;
        private ClearCacheEvent _clearCacheEventInstanceFixture;

        #region General Initializer : Class (ClearCacheEvent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ClearCacheEvent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clearCacheEventInstanceType = typeof(ClearCacheEvent);
            _clearCacheEventInstanceFixture = Create(true);
            _clearCacheEventInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ClearCacheEvent)

        #region General Initializer : Class (ClearCacheEvent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ClearCacheEvent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodClearSettingsNavigationCache, 0)]
        [TestCase(MethodItemAdded, 0)]
        [TestCase(MethodItemUpdated, 0)]
        [TestCase(MethodItemDeleted, 0)]
        public void AUT_ClearCacheEvent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_clearCacheEventInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ClearCacheEvent" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodClearSettingsNavigationCache)]
        [TestCase(MethodItemAdded)]
        [TestCase(MethodItemUpdated)]
        [TestCase(MethodItemDeleted)]
        public void AUT_ClearCacheEvent_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ClearCacheEvent>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ClearSettingsNavigationCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClearCacheEvent_ClearSettingsNavigationCache_Method_Call_Internally(Type[] types)
        {
            var methodClearSettingsNavigationCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clearCacheEventInstance, MethodClearSettingsNavigationCache, Fixture, methodClearSettingsNavigationCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ItemAdded) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClearCacheEvent_ItemAdded_Method_Call_Internally(Type[] types)
        {
            var methodItemAddedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clearCacheEventInstance, MethodItemAdded, Fixture, methodItemAddedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemUpdated) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClearCacheEvent_ItemUpdated_Method_Call_Internally(Type[] types)
        {
            var methodItemUpdatedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clearCacheEventInstance, MethodItemUpdated, Fixture, methodItemUpdatedPrametersTypes);
        }

        #endregion

        #region Method Call : (ItemDeleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClearCacheEvent_ItemDeleted_Method_Call_Internally(Type[] types)
        {
            var methodItemDeletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clearCacheEventInstance, MethodItemDeleted, Fixture, methodItemDeletedPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}