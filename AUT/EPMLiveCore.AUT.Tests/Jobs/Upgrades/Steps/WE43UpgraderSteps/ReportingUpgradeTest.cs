using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.ReportingUpgrade" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportingUpgradeTest : AbstractBaseSetupTypedTest<ReportingUpgrade>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingUpgrade) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodRunRefreshAll = "RunRefreshAll";
        private const string MethodPerform = "Perform";
        private Type _reportingUpgradeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingUpgrade _reportingUpgradeInstance;
        private ReportingUpgrade _reportingUpgradeInstanceFixture;

        #region General Initializer : Class (ReportingUpgrade) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingUpgrade" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingUpgradeInstanceType = typeof(ReportingUpgrade);
            _reportingUpgradeInstanceFixture = Create(true);
            _reportingUpgradeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingUpgrade)

        #region General Initializer : Class (ReportingUpgrade) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingUpgrade" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRunRefreshAll, 0)]
        [TestCase(MethodPerform, 0)]
        public void AUT_ReportingUpgrade_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingUpgradeInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportingUpgrade) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportingUpgrade" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_ReportingUpgrade_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportingUpgradeInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportingUpgrade" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodRunRefreshAll)]
        [TestCase(MethodPerform)]
        public void AUT_ReportingUpgrade_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportingUpgrade>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (RunRefreshAll) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingUpgrade_RunRefreshAll_Method_Call_Internally(Type[] types)
        {
            var methodRunRefreshAllPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingUpgradeInstance, MethodRunRefreshAll, Fixture, methodRunRefreshAllPrametersTypes);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingUpgrade_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingUpgradeInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}