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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportFolder" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportFolderTest : AbstractBaseSetupTypedTest<ReportFolder>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportFolder) Initializer

        private Type _reportFolderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportFolder _reportFolderInstance;
        private ReportFolder _reportFolderInstanceFixture;

        #region General Initializer : Class (ReportFolder) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportFolder" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportFolderInstanceType = typeof(ReportFolder);
            _reportFolderInstanceFixture = Create(true);
            _reportFolderInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ReportFolder" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportFolder_Is_Instance_Present_Test()
        {
            // Assert
            _reportFolderInstanceType.ShouldNotBeNull();
            _reportFolderInstance.ShouldNotBeNull();
            _reportFolderInstanceFixture.ShouldNotBeNull();
            _reportFolderInstance.ShouldBeAssignableTo<ReportFolder>();
            _reportFolderInstanceFixture.ShouldBeAssignableTo<ReportFolder>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportFolder) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportFolder_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportFolder instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportFolderInstanceType.ShouldNotBeNull();
            _reportFolderInstance.ShouldNotBeNull();
            _reportFolderInstanceFixture.ShouldNotBeNull();
            _reportFolderInstance.ShouldBeAssignableTo<ReportFolder>();
            _reportFolderInstanceFixture.ShouldBeAssignableTo<ReportFolder>();
        }

        #endregion

        #endregion

        #endregion
    }
}