using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WorkflowAction" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowActionTest : AbstractBaseSetupTypedTest<WorkflowAction>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkflowAction) Initializer

        private Type _workflowActionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkflowAction _workflowActionInstance;
        private WorkflowAction _workflowActionInstanceFixture;

        #region General Initializer : Class (WorkflowAction) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowAction" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowActionInstanceType = typeof(WorkflowAction);
            _workflowActionInstanceFixture = Create(true);
            _workflowActionInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="WorkflowAction" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkflowAction_Is_Instance_Present_Test()
        {
            // Assert
            _workflowActionInstanceType.ShouldNotBeNull();
            _workflowActionInstance.ShouldNotBeNull();
            _workflowActionInstanceFixture.ShouldNotBeNull();
            _workflowActionInstance.ShouldBeAssignableTo<WorkflowAction>();
            _workflowActionInstanceFixture.ShouldBeAssignableTo<WorkflowAction>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowAction) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowAction_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowAction instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowActionInstanceType.ShouldNotBeNull();
            _workflowActionInstance.ShouldNotBeNull();
            _workflowActionInstanceFixture.ShouldNotBeNull();
            _workflowActionInstance.ShouldBeAssignableTo<WorkflowAction>();
            _workflowActionInstanceFixture.ShouldBeAssignableTo<WorkflowAction>();
        }

        #endregion

        #endregion

        #endregion
    }
}