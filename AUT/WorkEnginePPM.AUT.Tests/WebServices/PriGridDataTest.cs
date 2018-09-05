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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ClientPrioritizationDataCache.PriGridData" />)
    ///     and namespace <see cref="ClientPrioritizationDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PriGridDataTest : AbstractBaseSetupTypedTest<PriGridData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PriGridData) Initializer

        private const string FieldNumCols = "NumCols";
        private const string Fieldgriddata = "griddata";
        private Type _priGridDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PriGridData _priGridDataInstance;
        private PriGridData _priGridDataInstanceFixture;

        #region General Initializer : Class (PriGridData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PriGridData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _priGridDataInstanceType = typeof(PriGridData);
            _priGridDataInstanceFixture = Create(true);
            _priGridDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PriGridData)

        #region General Initializer : Class (PriGridData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PriGridData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldNumCols)]
        [TestCase(Fieldgriddata)]
        public void AUT_PriGridData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_priGridDataInstanceFixture, 
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
        ///     Class (<see cref="PriGridData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PriGridData_Is_Instance_Present_Test()
        {
            // Assert
            _priGridDataInstanceType.ShouldNotBeNull();
            _priGridDataInstance.ShouldNotBeNull();
            _priGridDataInstanceFixture.ShouldNotBeNull();
            _priGridDataInstance.ShouldBeAssignableTo<PriGridData>();
            _priGridDataInstanceFixture.ShouldBeAssignableTo<PriGridData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PriGridData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PriGridData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PriGridData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _priGridDataInstanceType.ShouldNotBeNull();
            _priGridDataInstance.ShouldNotBeNull();
            _priGridDataInstanceFixture.ShouldNotBeNull();
            _priGridDataInstance.ShouldBeAssignableTo<PriGridData>();
            _priGridDataInstanceFixture.ShouldBeAssignableTo<PriGridData>();
        }

        #endregion

        #endregion

        #endregion
    }
}