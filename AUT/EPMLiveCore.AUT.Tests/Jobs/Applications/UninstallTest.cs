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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Applications.Uninstall" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Applications"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UninstallTest : AbstractBaseSetupTypedTest<Uninstall>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Uninstall) Initializer

        private const string Methodexecute = "execute";
        private const string MethodSetPercent = "SetPercent";
        private Type _uninstallInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Uninstall _uninstallInstance;
        private Uninstall _uninstallInstanceFixture;

        #region General Initializer : Class (Uninstall) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Uninstall" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _uninstallInstanceType = typeof(Uninstall);
            _uninstallInstanceFixture = Create(true);
            _uninstallInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Uninstall)

        #region General Initializer : Class (Uninstall) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Uninstall" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodSetPercent, 0)]
        public void AUT_Uninstall_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_uninstallInstanceFixture, 
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
        ///      Class (<see cref="Uninstall" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        [TestCase(MethodSetPercent)]
        public void AUT_Uninstall_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Uninstall>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Uninstall_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uninstallInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (SetPercent) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Uninstall_SetPercent_Method_Call_Internally(Type[] types)
        {
            var methodSetPercentPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_uninstallInstance, MethodSetPercent, Fixture, methodSetPercentPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}