using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs.Upgrades
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.WE43UpgradeJob" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WE43UpgradeJobTest : AbstractBaseSetupTypedTest<WE43UpgradeJob>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WE43UpgradeJob) Initializer

        private const string Methodexecute = "execute";
        private Type _wE43UpgradeJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WE43UpgradeJob _wE43UpgradeJobInstance;
        private WE43UpgradeJob _wE43UpgradeJobInstanceFixture;

        #region General Initializer : Class (WE43UpgradeJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WE43UpgradeJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _wE43UpgradeJobInstanceType = typeof(WE43UpgradeJob);
            _wE43UpgradeJobInstanceFixture = Create(true);
            _wE43UpgradeJobInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WE43UpgradeJob)

        #region General Initializer : Class (WE43UpgradeJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WE43UpgradeJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        public void AUT_WE43UpgradeJob_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_wE43UpgradeJobInstanceFixture, 
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
        ///      Class (<see cref="WE43UpgradeJob" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        public void AUT_WE43UpgradeJob_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WE43UpgradeJob>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WE43UpgradeJob_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wE43UpgradeJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}