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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.RPEN_Delegate" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RPENDelegateTest : AbstractBaseSetupTypedTest<RPEN_Delegate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RPEN_Delegate) Initializer

        private const string Fieldwres_id = "wres_id";
        private const string Fieldwres_res = "wres_res";
        private const string Fieldwres_delg = "wres_delg";
        private Type _rPENDelegateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RPEN_Delegate _rPENDelegateInstance;
        private RPEN_Delegate _rPENDelegateInstanceFixture;

        #region General Initializer : Class (RPEN_Delegate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RPEN_Delegate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rPENDelegateInstanceType = typeof(RPEN_Delegate);
            _rPENDelegateInstanceFixture = Create(true);
            _rPENDelegateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RPEN_Delegate)

        #region General Initializer : Class (RPEN_Delegate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RPEN_Delegate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldwres_id)]
        [TestCase(Fieldwres_res)]
        [TestCase(Fieldwres_delg)]
        public void AUT_RPENDelegate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_rPENDelegateInstanceFixture, 
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
        ///     Class (<see cref="RPEN_Delegate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RPENDelegate_Is_Instance_Present_Test()
        {
            // Assert
            _rPENDelegateInstanceType.ShouldNotBeNull();
            _rPENDelegateInstance.ShouldNotBeNull();
            _rPENDelegateInstanceFixture.ShouldNotBeNull();
            _rPENDelegateInstance.ShouldBeAssignableTo<RPEN_Delegate>();
            _rPENDelegateInstanceFixture.ShouldBeAssignableTo<RPEN_Delegate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RPEN_Delegate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RPEN_Delegate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RPEN_Delegate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _rPENDelegateInstanceType.ShouldNotBeNull();
            _rPENDelegateInstance.ShouldNotBeNull();
            _rPENDelegateInstanceFixture.ShouldNotBeNull();
            _rPENDelegateInstance.ShouldBeAssignableTo<RPEN_Delegate>();
            _rPENDelegateInstanceFixture.ShouldBeAssignableTo<RPEN_Delegate>();
        }

        #endregion

        #endregion

        #endregion
    }
}