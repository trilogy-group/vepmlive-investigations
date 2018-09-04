using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace CADataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CADataCache.clsColDisp" />)
    ///     and namespace <see cref="CADataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsColDispTest : AbstractBaseSetupTypedTest<clsColDisp>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsColDisp) Initializer

        private const string Fieldm_realname = "m_realname";
        private const string Fieldm_dispname = "m_dispname";
        private const string Fieldm_col_hidden = "m_col_hidden";
        private const string Fieldm_id = "m_id";
        private const string Fieldm_col = "m_col";
        private const string Fieldm_acc = "m_acc";
        private const string Fieldm_width = "m_width";
        private const string Fieldm_touched = "m_touched";
        private const string Fieldm_type = "m_type";
        private const string Fieldm_def_fld = "m_def_fld";
        private const string Fieldm_unselectable = "m_unselectable";
        private Type _clsColDispInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsColDisp _clsColDispInstance;
        private clsColDisp _clsColDispInstanceFixture;

        #region General Initializer : Class (clsColDisp) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsColDisp" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsColDispInstanceType = typeof(clsColDisp);
            _clsColDispInstanceFixture = Create(true);
            _clsColDispInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsColDisp)

        #region General Initializer : Class (clsColDisp) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsColDisp" />) explore and verify fields for coverage gain.
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
        [TestCase(Fieldm_def_fld)]
        [TestCase(Fieldm_unselectable)]
        public void AUT_ClsColDisp_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsColDispInstanceFixture, 
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
        ///     Class (<see cref="clsColDisp" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsColDisp_Is_Instance_Present_Test()
        {
            // Assert
            _clsColDispInstanceType.ShouldNotBeNull();
            _clsColDispInstance.ShouldNotBeNull();
            _clsColDispInstanceFixture.ShouldNotBeNull();
            _clsColDispInstance.ShouldBeAssignableTo<clsColDisp>();
            _clsColDispInstanceFixture.ShouldBeAssignableTo<clsColDisp>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsColDisp) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsColDisp_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsColDisp instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsColDispInstanceType.ShouldNotBeNull();
            _clsColDispInstance.ShouldNotBeNull();
            _clsColDispInstanceFixture.ShouldNotBeNull();
            _clsColDispInstance.ShouldBeAssignableTo<clsColDisp>();
            _clsColDispInstanceFixture.ShouldBeAssignableTo<clsColDisp>();
        }

        #endregion

        #endregion

        #endregion
    }
}