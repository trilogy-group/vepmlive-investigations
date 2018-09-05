using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.ComponentWeight" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ComponentWeightTest : AbstractBaseSetupTypedTest<ComponentWeight>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ComponentWeight) Initializer

        private const string FieldScenarioId = "ScenarioId";
        private const string FieldComponentId = "ComponentId";
        private const string FieldWeight = "Weight";
        private Type _componentWeightInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ComponentWeight _componentWeightInstance;
        private ComponentWeight _componentWeightInstanceFixture;

        #region General Initializer : Class (ComponentWeight) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ComponentWeight" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _componentWeightInstanceType = typeof(ComponentWeight);
            _componentWeightInstanceFixture = Create(true);
            _componentWeightInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ComponentWeight)

        #region General Initializer : Class (ComponentWeight) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ComponentWeight" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldScenarioId)]
        [TestCase(FieldComponentId)]
        [TestCase(FieldWeight)]
        public void AUT_ComponentWeight_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_componentWeightInstanceFixture, 
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
        ///     Class (<see cref="ComponentWeight" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ComponentWeight_Is_Instance_Present_Test()
        {
            // Assert
            _componentWeightInstanceType.ShouldNotBeNull();
            _componentWeightInstance.ShouldNotBeNull();
            _componentWeightInstanceFixture.ShouldNotBeNull();
            _componentWeightInstance.ShouldBeAssignableTo<ComponentWeight>();
            _componentWeightInstanceFixture.ShouldBeAssignableTo<ComponentWeight>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ComponentWeight) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ComponentWeight_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ComponentWeight instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _componentWeightInstanceType.ShouldNotBeNull();
            _componentWeightInstance.ShouldNotBeNull();
            _componentWeightInstanceFixture.ShouldNotBeNull();
            _componentWeightInstance.ShouldBeAssignableTo<ComponentWeight>();
            _componentWeightInstanceFixture.ShouldBeAssignableTo<ComponentWeight>();
        }

        #endregion

        #endregion

        #endregion
    }
}