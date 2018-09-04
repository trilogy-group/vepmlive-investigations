using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace CostDataValues
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsTargetColours" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsTargetColoursTest : AbstractBaseSetupTypedTest<clsTargetColours>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsTargetColours) Initializer

        private const string FieldID = "ID";
        private const string Fieldlow_val = "low_val";
        private const string FieldDesc = "Desc";
        private Type _clsTargetColoursInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsTargetColours _clsTargetColoursInstance;
        private clsTargetColours _clsTargetColoursInstanceFixture;

        #region General Initializer : Class (clsTargetColours) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsTargetColours" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsTargetColoursInstanceType = typeof(clsTargetColours);
            _clsTargetColoursInstanceFixture = Create(true);
            _clsTargetColoursInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsTargetColours)

        #region General Initializer : Class (clsTargetColours) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsTargetColours" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldID)]
        [TestCase(Fieldlow_val)]
        [TestCase(FieldDesc)]
        public void AUT_ClsTargetColours_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsTargetColoursInstanceFixture, 
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
        ///     Class (<see cref="clsTargetColours" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsTargetColours_Is_Instance_Present_Test()
        {
            // Assert
            _clsTargetColoursInstanceType.ShouldNotBeNull();
            _clsTargetColoursInstance.ShouldNotBeNull();
            _clsTargetColoursInstanceFixture.ShouldNotBeNull();
            _clsTargetColoursInstance.ShouldBeAssignableTo<clsTargetColours>();
            _clsTargetColoursInstanceFixture.ShouldBeAssignableTo<clsTargetColours>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsTargetColours) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsTargetColours_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsTargetColours instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsTargetColoursInstanceType.ShouldNotBeNull();
            _clsTargetColoursInstance.ShouldNotBeNull();
            _clsTargetColoursInstanceFixture.ShouldNotBeNull();
            _clsTargetColoursInstance.ShouldBeAssignableTo<clsTargetColours>();
            _clsTargetColoursInstanceFixture.ShouldBeAssignableTo<clsTargetColours>();
        }

        #endregion

        #endregion

        #endregion
    }
}