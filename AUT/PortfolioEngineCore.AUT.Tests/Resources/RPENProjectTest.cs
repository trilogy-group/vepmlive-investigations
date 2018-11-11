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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.RPEN_Project" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RPENProjectTest : AbstractBaseSetupTypedTest<RPEN_Project>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RPEN_Project) Initializer

        private const string FieldPID = "PID";
        private const string Fieldextid = "extid";
        private const string FieldName = "Name";
        private const string FieldPMid = "PMid";
        private const string FieldPMdlg = "PMdlg";
        private const string Fieldnotes = "notes";
        private Type _rPENProjectInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RPEN_Project _rPENProjectInstance;
        private RPEN_Project _rPENProjectInstanceFixture;

        #region General Initializer : Class (RPEN_Project) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RPEN_Project" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rPENProjectInstanceType = typeof(RPEN_Project);
            _rPENProjectInstanceFixture = Create(true);
            _rPENProjectInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RPEN_Project)

        #region General Initializer : Class (RPEN_Project) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RPEN_Project" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldPID)]
        [TestCase(Fieldextid)]
        [TestCase(FieldName)]
        [TestCase(FieldPMid)]
        [TestCase(FieldPMdlg)]
        [TestCase(Fieldnotes)]
        public void AUT_RPENProject_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_rPENProjectInstanceFixture, 
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
        ///     Class (<see cref="RPEN_Project" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RPENProject_Is_Instance_Present_Test()
        {
            // Assert
            _rPENProjectInstanceType.ShouldNotBeNull();
            _rPENProjectInstance.ShouldNotBeNull();
            _rPENProjectInstanceFixture.ShouldNotBeNull();
            _rPENProjectInstance.ShouldBeAssignableTo<RPEN_Project>();
            _rPENProjectInstanceFixture.ShouldBeAssignableTo<RPEN_Project>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RPEN_Project) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RPEN_Project_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RPEN_Project instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _rPENProjectInstanceType.ShouldNotBeNull();
            _rPENProjectInstance.ShouldNotBeNull();
            _rPENProjectInstanceFixture.ShouldNotBeNull();
            _rPENProjectInstance.ShouldBeAssignableTo<RPEN_Project>();
            _rPENProjectInstanceFixture.ShouldBeAssignableTo<RPEN_Project>();
        }

        #endregion

        #endregion

        #endregion
    }
}