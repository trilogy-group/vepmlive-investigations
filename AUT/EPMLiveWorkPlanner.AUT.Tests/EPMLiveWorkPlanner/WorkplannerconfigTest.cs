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
using EPMLiveWorkPlanner;
using workplannerconfig = EPMLiveWorkPlanner;

namespace EPMLiveWorkPlanner
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.workplannerconfig" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkplannerconfigTest : AbstractBaseSetupV3Test
    {
        public WorkplannerconfigTest() : base(typeof(workplannerconfig))
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

        #region General Initializer : Class (workplannerconfig) Initializer

        #region Fields

        private const string FieldpnlFeature = "pnlFeature";
        private const string FieldlnkButton = "lnkButton";
        private const string FieldhdnId = "hdnId";
        private const string FieldbtnAdd = "btnAdd";
        private const string FieldButton1 = "Button1";
        private const string FieldPlaceHolder1 = "PlaceHolder1";
        private const string FieldButton2 = "Button2";

        #endregion

        private Type _workplannerconfigInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private workplannerconfig _workplannerconfigInstance;
        private workplannerconfig _workplannerconfigInstanceFixture;

        #region General Initializer : Class (workplannerconfig) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="workplannerconfig" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workplannerconfigInstanceType = typeof(workplannerconfig);
            _workplannerconfigInstanceFixture = this.Create<workplannerconfig>(true);
            _workplannerconfigInstance = _workplannerconfigInstanceFixture ?? this.Create<workplannerconfig>(false);
            CurrentInstance = _workplannerconfigInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (workplannerconfig)

        #region General Initializer : Class (workplannerconfig) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="workplannerconfig" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldpnlFeature)]
        [TestCase(FieldlnkButton)]
        [TestCase(FieldhdnId)]
        [TestCase(FieldbtnAdd)]
        [TestCase(FieldButton1)]
        [TestCase(FieldPlaceHolder1)]
        [TestCase(FieldButton2)]
        public void AUT_Workplannerconfig_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workplannerconfigInstanceFixture, 
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
        ///     Class (<see cref="workplannerconfig" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Workplannerconfig_Is_Instance_Present_Test()
        {
            // Assert
            _workplannerconfigInstanceType.ShouldNotBeNull();
            _workplannerconfigInstance.ShouldNotBeNull();
            _workplannerconfigInstanceFixture.ShouldNotBeNull();
            _workplannerconfigInstance.ShouldBeAssignableTo<workplannerconfig>();
            _workplannerconfigInstanceFixture.ShouldBeAssignableTo<workplannerconfig>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (workplannerconfig) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_workplannerconfig_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            workplannerconfig instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workplannerconfigInstanceType.ShouldNotBeNull();
            _workplannerconfigInstance.ShouldNotBeNull();
            _workplannerconfigInstanceFixture.ShouldNotBeNull();
            _workplannerconfigInstance.ShouldBeAssignableTo<workplannerconfig>();
            _workplannerconfigInstanceFixture.ShouldBeAssignableTo<workplannerconfig>();
        }

        #endregion

        #endregion

        #endregion
    }
}