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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.RPEN_Depts" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RPENDeptsTest : AbstractBaseSetupTypedTest<RPEN_Depts>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RPEN_Depts) Initializer

        private const string Fielddept_code = "dept_code";
        private const string Fielddept_mgrs = "dept_mgrs";
        private Type _rPENDeptsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RPEN_Depts _rPENDeptsInstance;
        private RPEN_Depts _rPENDeptsInstanceFixture;

        #region General Initializer : Class (RPEN_Depts) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RPEN_Depts" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rPENDeptsInstanceType = typeof(RPEN_Depts);
            _rPENDeptsInstanceFixture = Create(true);
            _rPENDeptsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RPEN_Depts)

        #region General Initializer : Class (RPEN_Depts) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RPEN_Depts" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fielddept_code)]
        [TestCase(Fielddept_mgrs)]
        public void AUT_RPENDepts_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_rPENDeptsInstanceFixture, 
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
        ///     Class (<see cref="RPEN_Depts" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RPENDepts_Is_Instance_Present_Test()
        {
            // Assert
            _rPENDeptsInstanceType.ShouldNotBeNull();
            _rPENDeptsInstance.ShouldNotBeNull();
            _rPENDeptsInstanceFixture.ShouldNotBeNull();
            _rPENDeptsInstance.ShouldBeAssignableTo<RPEN_Depts>();
            _rPENDeptsInstanceFixture.ShouldBeAssignableTo<RPEN_Depts>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RPEN_Depts) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RPEN_Depts_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RPEN_Depts instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _rPENDeptsInstanceType.ShouldNotBeNull();
            _rPENDeptsInstance.ShouldNotBeNull();
            _rPENDeptsInstanceFixture.ShouldNotBeNull();
            _rPENDeptsInstance.ShouldBeAssignableTo<RPEN_Depts>();
            _rPENDeptsInstanceFixture.ShouldBeAssignableTo<RPEN_Depts>();
        }

        #endregion

        #endregion

        #endregion
    }
}