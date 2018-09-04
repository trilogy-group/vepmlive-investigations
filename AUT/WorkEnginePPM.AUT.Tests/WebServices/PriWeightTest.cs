using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace ClientPrioritizationDataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ClientPrioritizationDataCache.PriWeight" />)
    ///     and namespace <see cref="ClientPrioritizationDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PriWeightTest : AbstractBaseSetupTypedTest<PriWeight>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PriWeight) Initializer

        private const string Fieldrowfid = "rowfid";
        private const string Fieldratio = "ratio";
        private Type _priWeightInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PriWeight _priWeightInstance;
        private PriWeight _priWeightInstanceFixture;

        #region General Initializer : Class (PriWeight) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PriWeight" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _priWeightInstanceType = typeof(PriWeight);
            _priWeightInstanceFixture = Create(true);
            _priWeightInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PriWeight)

        #region General Initializer : Class (PriWeight) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PriWeight" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldrowfid)]
        [TestCase(Fieldratio)]
        public void AUT_PriWeight_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_priWeightInstanceFixture, 
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
        ///     Class (<see cref="PriWeight" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PriWeight_Is_Instance_Present_Test()
        {
            // Assert
            _priWeightInstanceType.ShouldNotBeNull();
            _priWeightInstance.ShouldNotBeNull();
            _priWeightInstanceFixture.ShouldNotBeNull();
            _priWeightInstance.ShouldBeAssignableTo<PriWeight>();
            _priWeightInstanceFixture.ShouldBeAssignableTo<PriWeight>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PriWeight) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PriWeight_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PriWeight instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _priWeightInstanceType.ShouldNotBeNull();
            _priWeightInstance.ShouldNotBeNull();
            _priWeightInstanceFixture.ShouldNotBeNull();
            _priWeightInstance.ShouldBeAssignableTo<PriWeight>();
            _priWeightInstanceFixture.ShouldBeAssignableTo<PriWeight>();
        }

        #endregion

        #endregion

        #endregion
    }
}