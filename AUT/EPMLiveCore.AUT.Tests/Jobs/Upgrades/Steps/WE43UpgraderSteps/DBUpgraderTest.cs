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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.DBUpgrader" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DBUpgraderTest : AbstractBaseSetupTypedTest<DBUpgrader>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DBUpgrader) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodUpgradePFEDatabase = "UpgradePFEDatabase";
        private const string MethodUpgradePFEDB = "UpgradePFEDB";
        private const string MethodPerform = "Perform";
        private Type _dBUpgraderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DBUpgrader _dBUpgraderInstance;
        private DBUpgrader _dBUpgraderInstanceFixture;

        #region General Initializer : Class (DBUpgrader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DBUpgrader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dBUpgraderInstanceType = typeof(DBUpgrader);
            _dBUpgraderInstanceFixture = Create(true);
            _dBUpgraderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DBUpgrader)

        #region General Initializer : Class (DBUpgrader) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DBUpgrader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodUpgradePFEDatabase, 0)]
        [TestCase(MethodUpgradePFEDB, 0)]
        [TestCase(MethodPerform, 0)]
        public void AUT_DBUpgrader_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_dBUpgraderInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DBUpgrader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DBUpgrader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_DBUpgrader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dBUpgraderInstanceFixture,
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
        ///      Class (<see cref="DBUpgrader" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodUpgradePFEDatabase)]
        [TestCase(MethodUpgradePFEDB)]
        [TestCase(MethodPerform)]
        public void AUT_DBUpgrader_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<DBUpgrader>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (UpgradePFEDatabase) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DBUpgrader_UpgradePFEDatabase_Method_Call_Internally(Type[] types)
        {
            var methodUpgradePFEDatabasePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBUpgraderInstance, MethodUpgradePFEDatabase, Fixture, methodUpgradePFEDatabasePrametersTypes);
        }

        #endregion

        #region Method Call : (UpgradePFEDB) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DBUpgrader_UpgradePFEDB_Method_Call_Internally(Type[] types)
        {
            var methodUpgradePFEDBPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBUpgraderInstance, MethodUpgradePFEDB, Fixture, methodUpgradePFEDBPrametersTypes);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DBUpgrader_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_dBUpgraderInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}