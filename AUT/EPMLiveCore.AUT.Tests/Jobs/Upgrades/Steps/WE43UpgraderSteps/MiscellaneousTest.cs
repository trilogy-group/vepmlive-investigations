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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.Miscellaneous" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MiscellaneousTest : AbstractBaseSetupTypedTest<Miscellaneous>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Miscellaneous) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodConfigurePlanner = "ConfigurePlanner";
        private const string MethodResetFeatures = "ResetFeatures";
        private const string MethodSetProperty = "SetProperty";
        private const string MethodPerform = "Perform";
        private Type _miscellaneousInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Miscellaneous _miscellaneousInstance;
        private Miscellaneous _miscellaneousInstanceFixture;

        #region General Initializer : Class (Miscellaneous) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Miscellaneous" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _miscellaneousInstanceType = typeof(Miscellaneous);
            _miscellaneousInstanceFixture = Create(true);
            _miscellaneousInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Miscellaneous)

        #region General Initializer : Class (Miscellaneous) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Miscellaneous" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodConfigurePlanner, 0)]
        [TestCase(MethodResetFeatures, 0)]
        [TestCase(MethodSetProperty, 0)]
        [TestCase(MethodPerform, 0)]
        public void AUT_Miscellaneous_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_miscellaneousInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Miscellaneous) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Miscellaneous" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_Miscellaneous_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_miscellaneousInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Miscellaneous" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodConfigurePlanner)]
        [TestCase(MethodResetFeatures)]
        [TestCase(MethodSetProperty)]
        [TestCase(MethodPerform)]
        public void AUT_Miscellaneous_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Miscellaneous>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ConfigurePlanner) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Miscellaneous_ConfigurePlanner_Method_Call_Internally(Type[] types)
        {
            var methodConfigurePlannerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_miscellaneousInstance, MethodConfigurePlanner, Fixture, methodConfigurePlannerPrametersTypes);
        }

        #endregion

        #region Method Call : (ResetFeatures) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Miscellaneous_ResetFeatures_Method_Call_Internally(Type[] types)
        {
            var methodResetFeaturesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_miscellaneousInstance, MethodResetFeatures, Fixture, methodResetFeaturesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetProperty) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Miscellaneous_SetProperty_Method_Call_Internally(Type[] types)
        {
            var methodSetPropertyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_miscellaneousInstance, MethodSetProperty, Fixture, methodSetPropertyPrametersTypes);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Miscellaneous_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_miscellaneousInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}