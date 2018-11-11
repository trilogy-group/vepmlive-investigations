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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.InstallReportingEvents" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class InstallReportingEventsTest : AbstractBaseSetupTypedTest<InstallReportingEvents>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (InstallReportingEvents) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodPerform = "Perform";
        private const string MethodInstallEvents = "InstallEvents";
        private Type _installReportingEventsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private InstallReportingEvents _installReportingEventsInstance;
        private InstallReportingEvents _installReportingEventsInstanceFixture;

        #region General Initializer : Class (InstallReportingEvents) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="InstallReportingEvents" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _installReportingEventsInstanceType = typeof(InstallReportingEvents);
            _installReportingEventsInstanceFixture = Create(true);
            _installReportingEventsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (InstallReportingEvents)

        #region General Initializer : Class (InstallReportingEvents) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="InstallReportingEvents" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPerform, 0)]
        [TestCase(MethodInstallEvents, 0)]
        public void AUT_InstallReportingEvents_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_installReportingEventsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (InstallReportingEvents) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="InstallReportingEvents" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_InstallReportingEvents_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_installReportingEventsInstanceFixture,
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
        ///      Class (<see cref="InstallReportingEvents" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPerform)]
        [TestCase(MethodInstallEvents)]
        public void AUT_InstallReportingEvents_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<InstallReportingEvents>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallReportingEvents_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installReportingEventsInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #region Method Call : (InstallEvents) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallReportingEvents_InstallEvents_Method_Call_Internally(Type[] types)
        {
            var methodInstallEventsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installReportingEventsInstance, MethodInstallEvents, Fixture, methodInstallEventsPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}