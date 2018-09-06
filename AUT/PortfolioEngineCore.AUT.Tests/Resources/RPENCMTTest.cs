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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.RPEN_CMT" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RPENCMTTest : AbstractBaseSetupTypedTest<RPEN_CMT>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RPEN_CMT) Initializer

        private const string FieldUID = "UID";
        private const string FieldRes = "Res";
        private const string Fieldpendingres = "pendingres";
        private const string Fieldenteredbyres = "enteredbyres";
        private const string FieldcmtGuid = "cmtGuid";
        private const string Fielddept = "dept";
        private const string Fielddept_cls = "dept_cls";
        private const string Fieldnotes = "notes";
        private Type _rPENCMTInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RPEN_CMT _rPENCMTInstance;
        private RPEN_CMT _rPENCMTInstanceFixture;

        #region General Initializer : Class (RPEN_CMT) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RPEN_CMT" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rPENCMTInstanceType = typeof(RPEN_CMT);
            _rPENCMTInstanceFixture = Create(true);
            _rPENCMTInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RPEN_CMT)

        #region General Initializer : Class (RPEN_CMT) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RPEN_CMT" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldUID)]
        [TestCase(FieldRes)]
        [TestCase(Fieldpendingres)]
        [TestCase(Fieldenteredbyres)]
        [TestCase(FieldcmtGuid)]
        [TestCase(Fielddept)]
        [TestCase(Fielddept_cls)]
        [TestCase(Fieldnotes)]
        public void AUT_RPENCMT_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_rPENCMTInstanceFixture, 
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
        ///     Class (<see cref="RPEN_CMT" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RPENCMT_Is_Instance_Present_Test()
        {
            // Assert
            _rPENCMTInstanceType.ShouldNotBeNull();
            _rPENCMTInstance.ShouldNotBeNull();
            _rPENCMTInstanceFixture.ShouldNotBeNull();
            _rPENCMTInstance.ShouldBeAssignableTo<RPEN_CMT>();
            _rPENCMTInstanceFixture.ShouldBeAssignableTo<RPEN_CMT>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RPEN_CMT) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RPEN_CMT_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RPEN_CMT instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _rPENCMTInstanceType.ShouldNotBeNull();
            _rPENCMTInstance.ShouldNotBeNull();
            _rPENCMTInstanceFixture.ShouldNotBeNull();
            _rPENCMTInstance.ShouldBeAssignableTo<RPEN_CMT>();
            _rPENCMTInstanceFixture.ShouldBeAssignableTo<RPEN_CMT>();
        }

        #endregion

        #endregion

        #endregion
    }
}