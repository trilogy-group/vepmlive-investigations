using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SharingRules" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SharingRulesTest : AbstractBaseSetupTypedTest<SharingRules>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SharingRules) Initializer

        private Type _sharingRulesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SharingRules _sharingRulesInstance;
        private SharingRules _sharingRulesInstanceFixture;

        #region General Initializer : Class (SharingRules) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SharingRules" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sharingRulesInstanceType = typeof(SharingRules);
            _sharingRulesInstanceFixture = Create(true);
            _sharingRulesInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="SharingRules" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SharingRules_Is_Instance_Present_Test()
        {
            // Assert
            _sharingRulesInstanceType.ShouldNotBeNull();
            _sharingRulesInstance.ShouldNotBeNull();
            _sharingRulesInstanceFixture.ShouldNotBeNull();
            _sharingRulesInstance.ShouldBeAssignableTo<SharingRules>();
            _sharingRulesInstanceFixture.ShouldBeAssignableTo<SharingRules>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SharingRules) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SharingRules_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SharingRules instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sharingRulesInstanceType.ShouldNotBeNull();
            _sharingRulesInstance.ShouldNotBeNull();
            _sharingRulesInstanceFixture.ShouldNotBeNull();
            _sharingRulesInstance.ShouldBeAssignableTo<SharingRules>();
            _sharingRulesInstanceFixture.ShouldBeAssignableTo<SharingRules>();
        }

        #endregion

        #endregion

        #endregion
    }
}