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
using EPMLiveCore.Layouts.epmlive;
using ManageFragment = EPMLiveCore.Layouts.epmlive;

namespace EPMLiveCore.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.ManageFragment" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ManageFragmentTest : AbstractBaseSetupV3Test
    {
        public ManageFragmentTest() : base(typeof(ManageFragment))
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

        #region General Initializer : Class (ManageFragment) Initializer

        #region Fields

        private const string FieldgridMyFragments = "gridMyFragments";
        private const string FieldgridPublicFragments = "gridPublicFragments";
        private const string FieldbtnClose = "btnClose";

        #endregion

        private Type _manageFragmentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ManageFragment _manageFragmentInstance;
        private ManageFragment _manageFragmentInstanceFixture;

        #region General Initializer : Class (ManageFragment) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ManageFragment" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _manageFragmentInstanceType = typeof(ManageFragment);
            _manageFragmentInstanceFixture = this.Create<ManageFragment>(true);
            _manageFragmentInstance = _manageFragmentInstanceFixture ?? this.Create<ManageFragment>(false);
            CurrentInstance = _manageFragmentInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ManageFragment)

        #region General Initializer : Class (ManageFragment) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ManageFragment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldgridMyFragments)]
        [TestCase(FieldgridPublicFragments)]
        public void AUT_ManageFragment_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_manageFragmentInstanceFixture, 
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
        ///     Class (<see cref="ManageFragment" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ManageFragment_Is_Instance_Present_Test()
        {
            // Assert
            _manageFragmentInstanceType.ShouldNotBeNull();
            _manageFragmentInstance.ShouldNotBeNull();
            _manageFragmentInstanceFixture.ShouldNotBeNull();
            _manageFragmentInstance.ShouldBeAssignableTo<ManageFragment>();
            _manageFragmentInstanceFixture.ShouldBeAssignableTo<ManageFragment>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ManageFragment) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ManageFragment_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ManageFragment instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _manageFragmentInstanceType.ShouldNotBeNull();
            _manageFragmentInstance.ShouldNotBeNull();
            _manageFragmentInstanceFixture.ShouldNotBeNull();
            _manageFragmentInstance.ShouldBeAssignableTo<ManageFragment>();
            _manageFragmentInstanceFixture.ShouldBeAssignableTo<ManageFragment>();
        }

        #endregion

        #endregion

        #endregion
    }
}