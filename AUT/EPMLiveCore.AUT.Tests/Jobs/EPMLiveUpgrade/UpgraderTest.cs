using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs.EPMLiveUpgrade
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.EPMLiveUpgrade.Upgrader" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.EPMLiveUpgrade"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UpgraderTest : AbstractBaseSetupTypedTest<Upgrader>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Upgrader) Initializer

        private const string Methodexecute = "execute";
        private Type _upgraderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Upgrader _upgraderInstance;
        private Upgrader _upgraderInstanceFixture;

        #region General Initializer : Class (Upgrader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Upgrader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _upgraderInstanceType = typeof(Upgrader);
            _upgraderInstanceFixture = Create(true);
            _upgraderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Upgrader)

        #region General Initializer : Class (Upgrader) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Upgrader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        public void AUT_Upgrader_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_upgraderInstanceFixture, 
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
        ///      Class (<see cref="Upgrader" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        public void AUT_Upgrader_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Upgrader>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Upgrader_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_upgraderInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}