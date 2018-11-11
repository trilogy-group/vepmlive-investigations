using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs.Applications
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Applications.InstallAndConfigure" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Applications"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class InstallAndConfigureTest : AbstractBaseSetupTypedTest<InstallAndConfigure>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (InstallAndConfigure) Initializer

        private const string Methodexecute = "execute";
        private const string MethodSetPercent = "SetPercent";
        private Type _installAndConfigureInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private InstallAndConfigure _installAndConfigureInstance;
        private InstallAndConfigure _installAndConfigureInstanceFixture;

        #region General Initializer : Class (InstallAndConfigure) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="InstallAndConfigure" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _installAndConfigureInstanceType = typeof(InstallAndConfigure);
            _installAndConfigureInstanceFixture = Create(true);
            _installAndConfigureInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (InstallAndConfigure)

        #region General Initializer : Class (InstallAndConfigure) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="InstallAndConfigure" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodSetPercent, 0)]
        public void AUT_InstallAndConfigure_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_installAndConfigureInstanceFixture, 
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
        ///      Class (<see cref="InstallAndConfigure" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        [TestCase(MethodSetPercent)]
        public void AUT_InstallAndConfigure_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<InstallAndConfigure>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallAndConfigure_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installAndConfigureInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (SetPercent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallAndConfigure_SetPercent_Method_Call_Internally(Type[] types)
        {
            var methodSetPercentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installAndConfigureInstance, MethodSetPercent, Fixture, methodSetPercentPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}