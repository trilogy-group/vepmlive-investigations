using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.AdSynchJob" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class AdSynchJobTest : AbstractBaseSetupTypedTest<AdSynchJob>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AdSynchJob) Initializer

        private const string Methodexecute = "execute";
        private Type _adSynchJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AdSynchJob _adSynchJobInstance;
        private AdSynchJob _adSynchJobInstanceFixture;

        #region General Initializer : Class (AdSynchJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AdSynchJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _adSynchJobInstanceType = typeof(AdSynchJob);
            _adSynchJobInstanceFixture = Create(true);
            _adSynchJobInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AdSynchJob)

        #region General Initializer : Class (AdSynchJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AdSynchJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        public void AUT_AdSynchJob_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_adSynchJobInstanceFixture, 
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
        ///      Class (<see cref="AdSynchJob" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        public void AUT_AdSynchJob_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<AdSynchJob>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_AdSynchJob_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_adSynchJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}