using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace ModelDataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.ModelBarsChanged" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ModelBarsChangedTest : AbstractBaseSetupTypedTest<ModelBarsChanged>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ModelBarsChanged) Initializer

        private const string FieldredrawCompleteGrid = "redrawCompleteGrid";
        private const string FieldbarsAffected = "barsAffected";
        private const string FieldRowID = "RowID";
        private const string FieldStarts = "Starts";
        private const string FieldFinishs = "Finishs";
        private Type _modelBarsChangedInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ModelBarsChanged _modelBarsChangedInstance;
        private ModelBarsChanged _modelBarsChangedInstanceFixture;

        #region General Initializer : Class (ModelBarsChanged) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ModelBarsChanged" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _modelBarsChangedInstanceType = typeof(ModelBarsChanged);
            _modelBarsChangedInstanceFixture = Create(true);
            _modelBarsChangedInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ModelBarsChanged)

        #region General Initializer : Class (ModelBarsChanged) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ModelBarsChanged" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldredrawCompleteGrid)]
        [TestCase(FieldbarsAffected)]
        [TestCase(FieldRowID)]
        [TestCase(FieldStarts)]
        [TestCase(FieldFinishs)]
        public void AUT_ModelBarsChanged_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_modelBarsChangedInstanceFixture, 
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
        ///     Class (<see cref="ModelBarsChanged" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ModelBarsChanged_Is_Instance_Present_Test()
        {
            // Assert
            _modelBarsChangedInstanceType.ShouldNotBeNull();
            _modelBarsChangedInstance.ShouldNotBeNull();
            _modelBarsChangedInstanceFixture.ShouldNotBeNull();
            _modelBarsChangedInstance.ShouldBeAssignableTo<ModelBarsChanged>();
            _modelBarsChangedInstanceFixture.ShouldBeAssignableTo<ModelBarsChanged>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ModelBarsChanged) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ModelBarsChanged_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ModelBarsChanged instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _modelBarsChangedInstanceType.ShouldNotBeNull();
            _modelBarsChangedInstance.ShouldNotBeNull();
            _modelBarsChangedInstanceFixture.ShouldNotBeNull();
            _modelBarsChangedInstance.ShouldBeAssignableTo<ModelBarsChanged>();
            _modelBarsChangedInstanceFixture.ShouldBeAssignableTo<ModelBarsChanged>();
        }

        #endregion

        #endregion

        #endregion
    }
}