using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace RPADataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="RPADataCache.clsRXDisp" />)
    ///     and namespace <see cref="RPADataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsRXDispTest : AbstractBaseSetupTypedTest<clsRXDisp>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsRXDisp) Initializer

        private const string Fieldm_realname = "m_realname";
        private const string Fieldm_dispname = "m_dispname";
        private const string Fieldm_col_hidden = "m_col_hidden";
        private const string Fieldm_id = "m_id";
        private const string Fieldm_col = "m_col";
        private const string Fieldm_acc = "m_acc";
        private const string Fieldm_width = "m_width";
        private const string Fieldm_touched = "m_touched";
        private const string Fieldm_type = "m_type";
        private Type _clsRXDispInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsRXDisp _clsRXDispInstance;
        private clsRXDisp _clsRXDispInstanceFixture;

        #region General Initializer : Class (clsRXDisp) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsRXDisp" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsRXDispInstanceType = typeof(clsRXDisp);
            _clsRXDispInstanceFixture = Create(true);
            _clsRXDispInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsRXDisp)

        #region General Initializer : Class (clsRXDisp) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsRXDisp" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldm_realname)]
        [TestCase(Fieldm_dispname)]
        [TestCase(Fieldm_col_hidden)]
        [TestCase(Fieldm_id)]
        [TestCase(Fieldm_col)]
        [TestCase(Fieldm_acc)]
        [TestCase(Fieldm_width)]
        [TestCase(Fieldm_touched)]
        [TestCase(Fieldm_type)]
        public void AUT_ClsRXDisp_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsRXDispInstanceFixture, 
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
        ///     Class (<see cref="clsRXDisp" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsRXDisp_Is_Instance_Present_Test()
        {
            // Assert
            _clsRXDispInstanceType.ShouldNotBeNull();
            _clsRXDispInstance.ShouldNotBeNull();
            _clsRXDispInstanceFixture.ShouldNotBeNull();
            _clsRXDispInstance.ShouldBeAssignableTo<clsRXDisp>();
            _clsRXDispInstanceFixture.ShouldBeAssignableTo<clsRXDisp>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsRXDisp) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsRXDisp_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsRXDisp instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsRXDispInstanceType.ShouldNotBeNull();
            _clsRXDispInstance.ShouldNotBeNull();
            _clsRXDispInstanceFixture.ShouldNotBeNull();
            _clsRXDispInstance.ShouldBeAssignableTo<clsRXDisp>();
            _clsRXDispInstanceFixture.ShouldBeAssignableTo<clsRXDisp>();
        }

        #endregion

        #endregion

        #endregion
    }
}