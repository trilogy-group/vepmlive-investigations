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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.RPEN_Resource" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RPENResourceTest : AbstractBaseSetupTypedTest<RPEN_Resource>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RPEN_Resource) Initializer

        private const string Fieldid = "id";
        private const string Fieldextid = "extid";
        private const string FieldNTacct = "NTacct";
        private const string FieldName = "Name";
        private const string FieldeMail = "eMail";
        private Type _rPENResourceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RPEN_Resource _rPENResourceInstance;
        private RPEN_Resource _rPENResourceInstanceFixture;

        #region General Initializer : Class (RPEN_Resource) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RPEN_Resource" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rPENResourceInstanceType = typeof(RPEN_Resource);
            _rPENResourceInstanceFixture = Create(true);
            _rPENResourceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RPEN_Resource)

        #region General Initializer : Class (RPEN_Resource) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RPEN_Resource" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldid)]
        [TestCase(Fieldextid)]
        [TestCase(FieldNTacct)]
        [TestCase(FieldName)]
        [TestCase(FieldeMail)]
        public void AUT_RPENResource_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_rPENResourceInstanceFixture, 
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
        ///     Class (<see cref="RPEN_Resource" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RPENResource_Is_Instance_Present_Test()
        {
            // Assert
            _rPENResourceInstanceType.ShouldNotBeNull();
            _rPENResourceInstance.ShouldNotBeNull();
            _rPENResourceInstanceFixture.ShouldNotBeNull();
            _rPENResourceInstance.ShouldBeAssignableTo<RPEN_Resource>();
            _rPENResourceInstanceFixture.ShouldBeAssignableTo<RPEN_Resource>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RPEN_Resource) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RPEN_Resource_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RPEN_Resource instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _rPENResourceInstanceType.ShouldNotBeNull();
            _rPENResourceInstance.ShouldNotBeNull();
            _rPENResourceInstanceFixture.ShouldNotBeNull();
            _rPENResourceInstance.ShouldBeAssignableTo<RPEN_Resource>();
            _rPENResourceInstanceFixture.ShouldBeAssignableTo<RPEN_Resource>();
        }

        #endregion

        #endregion

        #endregion
    }
}