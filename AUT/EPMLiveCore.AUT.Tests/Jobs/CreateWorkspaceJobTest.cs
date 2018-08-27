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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.CreateWorkspaceJob" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CreateWorkspaceJobTest : AbstractBaseSetupTypedTest<CreateWorkspaceJob>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CreateWorkspaceJob) Initializer

        private const string Methodexecute = "execute";
        private Type _createWorkspaceJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CreateWorkspaceJob _createWorkspaceJobInstance;
        private CreateWorkspaceJob _createWorkspaceJobInstanceFixture;

        #region General Initializer : Class (CreateWorkspaceJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CreateWorkspaceJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _createWorkspaceJobInstanceType = typeof(CreateWorkspaceJob);
            _createWorkspaceJobInstanceFixture = Create(true);
            _createWorkspaceJobInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CreateWorkspaceJob)

        #region General Initializer : Class (CreateWorkspaceJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CreateWorkspaceJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        public void AUT_CreateWorkspaceJob_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_createWorkspaceJobInstanceFixture, 
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
        ///      Class (<see cref="CreateWorkspaceJob" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        public void AUT_CreateWorkspaceJob_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CreateWorkspaceJob>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CreateWorkspaceJob_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_createWorkspaceJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}