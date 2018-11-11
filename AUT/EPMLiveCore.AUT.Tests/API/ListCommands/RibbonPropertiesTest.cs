using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.RibbonProperties" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RibbonPropertiesTest : AbstractBaseSetupTypedTest<RibbonProperties>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RibbonProperties) Initializer

        private const string FieldbBuildTeam = "bBuildTeam";
        private const string FieldbDisableProject = "bDisableProject";
        private const string FieldbDisablePlan = "bDisablePlan";
        private const string FieldaEPKButtons = "aEPKButtons";
        private const string FieldaEPKActivex = "aEPKActivex";
        private Type _ribbonPropertiesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RibbonProperties _ribbonPropertiesInstance;
        private RibbonProperties _ribbonPropertiesInstanceFixture;

        #region General Initializer : Class (RibbonProperties) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RibbonProperties" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ribbonPropertiesInstanceType = typeof(RibbonProperties);
            _ribbonPropertiesInstanceFixture = Create(true);
            _ribbonPropertiesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RibbonProperties)

        #region General Initializer : Class (RibbonProperties) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RibbonProperties" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldbBuildTeam)]
        [TestCase(FieldbDisableProject)]
        [TestCase(FieldbDisablePlan)]
        [TestCase(FieldaEPKButtons)]
        [TestCase(FieldaEPKActivex)]
        public void AUT_RibbonProperties_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ribbonPropertiesInstanceFixture, 
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
        ///     Class (<see cref="RibbonProperties" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RibbonProperties_Is_Instance_Present_Test()
        {
            // Assert
            _ribbonPropertiesInstanceType.ShouldNotBeNull();
            _ribbonPropertiesInstance.ShouldNotBeNull();
            _ribbonPropertiesInstanceFixture.ShouldNotBeNull();
            _ribbonPropertiesInstance.ShouldBeAssignableTo<RibbonProperties>();
            _ribbonPropertiesInstanceFixture.ShouldBeAssignableTo<RibbonProperties>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RibbonProperties) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RibbonProperties_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RibbonProperties instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ribbonPropertiesInstanceType.ShouldNotBeNull();
            _ribbonPropertiesInstance.ShouldNotBeNull();
            _ribbonPropertiesInstanceFixture.ShouldNotBeNull();
            _ribbonPropertiesInstance.ShouldBeAssignableTo<RibbonProperties>();
            _ribbonPropertiesInstanceFixture.ShouldBeAssignableTo<RibbonProperties>();
        }

        #endregion

        #endregion

        #endregion
    }
}