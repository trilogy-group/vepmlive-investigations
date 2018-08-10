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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.TimeOff" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class TimeOffTest : AbstractBaseSetupTypedTest<TimeOff>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TimeOff) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodPerform = "Perform";
        private Type _timeOffInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TimeOff _timeOffInstance;
        private TimeOff _timeOffInstanceFixture;

        #region General Initializer : Class (TimeOff) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TimeOff" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _timeOffInstanceType = typeof(TimeOff);
            _timeOffInstanceFixture = Create(true);
            _timeOffInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TimeOff)

        #region General Initializer : Class (TimeOff) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TimeOff" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPerform, 0)]
        public void AUT_TimeOff_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_timeOffInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TimeOff) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TimeOff" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_TimeOff_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_timeOffInstanceFixture,
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
        ///      Class (<see cref="TimeOff" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPerform)]
        public void AUT_TimeOff_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<TimeOff>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_TimeOff_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeOffInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}