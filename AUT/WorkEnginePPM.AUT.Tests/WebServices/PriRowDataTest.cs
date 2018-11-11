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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ClientPrioritizationDataCache.PriRowData" />)
    ///     and namespace <see cref="ClientPrioritizationDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PriRowDataTest : AbstractBaseSetupTypedTest<PriRowData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PriRowData) Initializer

        private const string Fieldrowdata = "rowdata";
        private Type _priRowDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PriRowData _priRowDataInstance;
        private PriRowData _priRowDataInstanceFixture;

        #region General Initializer : Class (PriRowData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PriRowData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _priRowDataInstanceType = typeof(PriRowData);
            _priRowDataInstanceFixture = Create(true);
            _priRowDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PriRowData)

        #region General Initializer : Class (PriRowData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PriRowData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldrowdata)]
        public void AUT_PriRowData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_priRowDataInstanceFixture, 
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
        ///     Class (<see cref="PriRowData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PriRowData_Is_Instance_Present_Test()
        {
            // Assert
            _priRowDataInstanceType.ShouldNotBeNull();
            _priRowDataInstance.ShouldNotBeNull();
            _priRowDataInstanceFixture.ShouldNotBeNull();
            _priRowDataInstance.ShouldBeAssignableTo<PriRowData>();
            _priRowDataInstanceFixture.ShouldBeAssignableTo<PriRowData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PriRowData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PriRowData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PriRowData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _priRowDataInstanceType.ShouldNotBeNull();
            _priRowDataInstance.ShouldNotBeNull();
            _priRowDataInstanceFixture.ShouldNotBeNull();
            _priRowDataInstance.ShouldBeAssignableTo<PriRowData>();
            _priRowDataInstanceFixture.ShouldBeAssignableTo<PriRowData>();
        }

        #endregion

        #endregion

        #endregion
    }
}