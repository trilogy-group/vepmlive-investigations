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
using WorkPlanner = EPMLiveWorkPlanner.Layouts.epmlive;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.Layouts.epmlive.WorkPlanner" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner.Layouts.epmlive"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkPlannerTest : AbstractBaseSetupV3Test
    {
        public WorkPlannerTest() : base(typeof(WorkPlanner))
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

        #region General Initializer : Class (WorkPlanner) Initializer

        #region Fields

        private const string FieldpnlAct = "pnlAct";
        private const string FieldlblAct = "lblAct";
        private const string FieldpnlMSProject = "pnlMSProject";
        private const string FieldpnlOldPlanner = "pnlOldPlanner";
        private const string FieldpnlProject = "pnlProject";
        private const string FieldpnlProjectSchedule = "pnlProjectSchedule";
        private const string FieldpnlPerms = "pnlPerms";
        private const string FieldlblPerms = "lblPerms";
        private const string FieldpnlParentChild = "pnlParentChild";
        private const string FieldsectionItem2 = "sectionItem2";
        private const string FieldddlChildParent = "ddlChildParent";
        private const string FieldpnlPopup = "pnlPopup";
        private const string FieldpnlMain = "pnlMain";

        #endregion

        private Type _workPlannerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private WorkPlanner _workPlannerInstance;
        private WorkPlanner _workPlannerInstanceFixture;

        #region General Initializer : Class (WorkPlanner) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkPlanner" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workPlannerInstanceType = typeof(WorkPlanner);
            _workPlannerInstanceFixture = this.Create<WorkPlanner>(true);
            _workPlannerInstance = _workPlannerInstanceFixture ?? this.Create<WorkPlanner>(false);
            CurrentInstance = _workPlannerInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkPlanner)

        #region General Initializer : Class (WorkPlanner) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkPlanner" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldpnlAct)]
        [TestCase(FieldlblAct)]
        [TestCase(FieldpnlMSProject)]
        [TestCase(FieldpnlOldPlanner)]
        [TestCase(FieldpnlProject)]
        [TestCase(FieldpnlProjectSchedule)]
        [TestCase(FieldpnlPerms)]
        [TestCase(FieldlblPerms)]
        [TestCase(FieldpnlParentChild)]
        [TestCase(FieldsectionItem2)]
        [TestCase(FieldddlChildParent)]
        [TestCase(FieldpnlPopup)]
        [TestCase(FieldpnlMain)]
        public void AUT_WorkPlanner_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workPlannerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="WorkPlanner" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkPlanner_Is_Instance_Present_Test()
        {
            // Assert
            _workPlannerInstanceType.ShouldNotBeNull();
            _workPlannerInstance.ShouldNotBeNull();
            _workPlannerInstanceFixture.ShouldNotBeNull();
            _workPlannerInstance.ShouldBeAssignableTo<WorkPlanner>();
            _workPlannerInstanceFixture.ShouldBeAssignableTo<WorkPlanner>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkPlanner) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkPlanner_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkPlanner instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workPlannerInstanceType.ShouldNotBeNull();
            _workPlannerInstance.ShouldNotBeNull();
            _workPlannerInstanceFixture.ShouldNotBeNull();
            _workPlannerInstance.ShouldBeAssignableTo<WorkPlanner>();
            _workPlannerInstanceFixture.ShouldBeAssignableTo<WorkPlanner>();
        }

        #endregion

        #endregion

        #endregion
    }
}