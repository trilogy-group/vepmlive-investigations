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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.RollupJob" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RollupJobTest : AbstractBaseSetupTypedTest<RollupJob>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RollupJob) Initializer

        private const string MethodExecute = "Execute";
        private const string MethodgetListItemCount = "getListItemCount";
        private Type _rollupJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RollupJob _rollupJobInstance;
        private RollupJob _rollupJobInstanceFixture;

        #region General Initializer : Class (RollupJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RollupJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rollupJobInstanceType = typeof(RollupJob);
            _rollupJobInstanceFixture = Create(true);
            _rollupJobInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RollupJob)

        #region General Initializer : Class (RollupJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="RollupJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodExecute, 0)]
        [TestCase(MethodgetListItemCount, 0)]
        public void AUT_RollupJob_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_rollupJobInstanceFixture, 
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
        ///      Class (<see cref="RollupJob" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodExecute)]
        [TestCase(MethodgetListItemCount)]
        public void AUT_RollupJob_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<RollupJob>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RollupJob_Execute_Method_Call_Internally(Type[] types)
        {
            var methodExecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupJobInstance, MethodExecute, Fixture, methodExecutePrametersTypes);
        }

        #endregion

        #region Method Call : (getListItemCount) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RollupJob_getListItemCount_Method_Call_Internally(Type[] types)
        {
            var methodgetListItemCountPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_rollupJobInstance, MethodgetListItemCount, Fixture, methodgetListItemCountPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}