using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveWorkPlanner.Layouts.epmlive;
using WorkPlanLinkTask = EPMLiveWorkPlanner.Layouts.epmlive;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.Layouts.epmlive.WorkPlanLinkTask" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner.Layouts.epmlive"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkPlanLinkTaskTest : AbstractBaseSetupV3Test
    {
        public WorkPlanLinkTaskTest() : base(typeof(WorkPlanLinkTask))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (WorkPlanLinkTask) Initializer

        private Type _workPlanLinkTaskInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private WorkPlanLinkTask _workPlanLinkTaskInstance;
        private WorkPlanLinkTask _workPlanLinkTaskInstanceFixture;

        #region General Initializer : Class (WorkPlanLinkTask) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkPlanLinkTask" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workPlanLinkTaskInstanceType = typeof(WorkPlanLinkTask);
            _workPlanLinkTaskInstanceFixture = this.Create<WorkPlanLinkTask>(true);
            _workPlanLinkTaskInstance = _workPlanLinkTaskInstanceFixture ?? this.Create<WorkPlanLinkTask>(false);
            CurrentInstance = _workPlanLinkTaskInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="WorkPlanLinkTask" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkPlanLinkTask_Is_Instance_Present_Test()
        {
            // Assert
            _workPlanLinkTaskInstanceType.ShouldNotBeNull();
            _workPlanLinkTaskInstance.ShouldNotBeNull();
            _workPlanLinkTaskInstanceFixture.ShouldNotBeNull();
            _workPlanLinkTaskInstance.ShouldBeAssignableTo<WorkPlanLinkTask>();
            _workPlanLinkTaskInstanceFixture.ShouldBeAssignableTo<WorkPlanLinkTask>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkPlanLinkTask) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkPlanLinkTask_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkPlanLinkTask instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workPlanLinkTaskInstanceType.ShouldNotBeNull();
            _workPlanLinkTaskInstance.ShouldNotBeNull();
            _workPlanLinkTaskInstanceFixture.ShouldNotBeNull();
            _workPlanLinkTaskInstance.ShouldBeAssignableTo<WorkPlanLinkTask>();
            _workPlanLinkTaskInstanceFixture.ShouldBeAssignableTo<WorkPlanLinkTask>();
        }

        #endregion

        #endregion

        #endregion
    }
}