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
using WorkPlannerWizard = EPMLiveWorkPlanner.Layouts.epmlive;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.Layouts.epmlive.WorkPlannerWizard" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner.Layouts.epmlive"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkPlannerWizardTest : AbstractBaseSetupV3Test
    {
        public WorkPlannerWizardTest() : base(typeof(WorkPlannerWizard))
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

        #region General Initializer : Class (WorkPlannerWizard) Initializer

        #region Fields

        private const string FieldpnlUpload = "pnlUpload";
        private const string FieldlblUploadError = "lblUploadError";
        private const string FieldFileUpload = "FileUpload";
        private const string FieldbtnUpload = "btnUpload";
        private const string FieldButton1 = "Button1";
        private const string FieldpnlUploadDone = "pnlUploadDone";
        private const string FieldpnlParentChild = "pnlParentChild";
        private const string FieldddlChildParent = "ddlChildParent";
        private const string FieldpnlPlanner = "pnlPlanner";
        private const string FieldpnlItem = "pnlItem";
        private const string FieldpnlTemplate = "pnlTemplate";
        private const string FieldpnlDone = "pnlDone";

        #endregion

        private Type _workPlannerWizardInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private WorkPlannerWizard _workPlannerWizardInstance;
        private WorkPlannerWizard _workPlannerWizardInstanceFixture;

        #region General Initializer : Class (WorkPlannerWizard) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkPlannerWizard" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workPlannerWizardInstanceType = typeof(WorkPlannerWizard);
            _workPlannerWizardInstanceFixture = this.Create<WorkPlannerWizard>(true);
            _workPlannerWizardInstance = _workPlannerWizardInstanceFixture ?? this.Create<WorkPlannerWizard>(false);
            CurrentInstance = _workPlannerWizardInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkPlannerWizard)

        #region General Initializer : Class (WorkPlannerWizard) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkPlannerWizard" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldpnlUpload)]
        [TestCase(FieldlblUploadError)]
        [TestCase(FieldFileUpload)]
        [TestCase(FieldbtnUpload)]
        [TestCase(FieldButton1)]
        [TestCase(FieldpnlUploadDone)]
        [TestCase(FieldpnlParentChild)]
        [TestCase(FieldddlChildParent)]
        [TestCase(FieldpnlPlanner)]
        [TestCase(FieldpnlItem)]
        [TestCase(FieldpnlTemplate)]
        [TestCase(FieldpnlDone)]
        public void AUT_WorkPlannerWizard_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workPlannerWizardInstanceFixture, 
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
        ///     Class (<see cref="WorkPlannerWizard" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkPlannerWizard_Is_Instance_Present_Test()
        {
            // Assert
            _workPlannerWizardInstanceType.ShouldNotBeNull();
            _workPlannerWizardInstance.ShouldNotBeNull();
            _workPlannerWizardInstanceFixture.ShouldNotBeNull();
            _workPlannerWizardInstance.ShouldBeAssignableTo<WorkPlannerWizard>();
            _workPlannerWizardInstanceFixture.ShouldBeAssignableTo<WorkPlannerWizard>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkPlannerWizard) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkPlannerWizard_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkPlannerWizard instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workPlannerWizardInstanceType.ShouldNotBeNull();
            _workPlannerWizardInstance.ShouldNotBeNull();
            _workPlannerWizardInstanceFixture.ShouldNotBeNull();
            _workPlannerWizardInstance.ShouldBeAssignableTo<WorkPlannerWizard>();
            _workPlannerWizardInstanceFixture.ShouldBeAssignableTo<WorkPlannerWizard>();
        }

        #endregion

        #endregion

        #endregion
    }
}