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
using PlannerAdmin = EPMLiveWorkPlanner.Layouts.epmlive;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWorkPlanner.Layouts.epmlive.PlannerAdmin" />)
    ///     and namespace <see cref="EPMLiveWorkPlanner.Layouts.epmlive"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PlannerAdminTest : AbstractBaseSetupV3Test
    {
        public PlannerAdminTest() : base(typeof(PlannerAdmin))
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

        #region General Initializer : Class (PlannerAdmin) Initializer

        #region Fields

        private const string FieldpnlAdmin = "pnlAdmin";
        private const string FieldhlAdmin = "hlAdmin";
        private const string FieldpnlMain = "pnlMain";
        private const string FieldgvPlans = "gvPlans";

        #endregion

        private Type _plannerAdminInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private PlannerAdmin _plannerAdminInstance;
        private PlannerAdmin _plannerAdminInstanceFixture;

        #region General Initializer : Class (PlannerAdmin) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PlannerAdmin" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _plannerAdminInstanceType = typeof(PlannerAdmin);
            _plannerAdminInstanceFixture = this.Create<PlannerAdmin>(true);
            _plannerAdminInstance = _plannerAdminInstanceFixture ?? this.Create<PlannerAdmin>(false);
            CurrentInstance = _plannerAdminInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PlannerAdmin)

        #region General Initializer : Class (PlannerAdmin) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PlannerAdmin" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldpnlAdmin)]
        [TestCase(FieldhlAdmin)]
        [TestCase(FieldpnlMain)]
        [TestCase(FieldgvPlans)]
        public void AUT_PlannerAdmin_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_plannerAdminInstanceFixture, 
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
        ///     Class (<see cref="PlannerAdmin" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PlannerAdmin_Is_Instance_Present_Test()
        {
            // Assert
            _plannerAdminInstanceType.ShouldNotBeNull();
            _plannerAdminInstance.ShouldNotBeNull();
            _plannerAdminInstanceFixture.ShouldNotBeNull();
            _plannerAdminInstance.ShouldBeAssignableTo<PlannerAdmin>();
            _plannerAdminInstanceFixture.ShouldBeAssignableTo<PlannerAdmin>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PlannerAdmin) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PlannerAdmin_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PlannerAdmin instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _plannerAdminInstanceType.ShouldNotBeNull();
            _plannerAdminInstance.ShouldNotBeNull();
            _plannerAdminInstanceFixture.ShouldNotBeNull();
            _plannerAdminInstance.ShouldBeAssignableTo<PlannerAdmin>();
            _plannerAdminInstanceFixture.ShouldBeAssignableTo<PlannerAdmin>();
        }

        #endregion

        #endregion

        #endregion
    }
}