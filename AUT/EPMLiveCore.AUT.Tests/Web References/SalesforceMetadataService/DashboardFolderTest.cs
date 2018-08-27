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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DashboardFolder" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DashboardFolderTest : AbstractBaseSetupTypedTest<DashboardFolder>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DashboardFolder) Initializer

        private Type _dashboardFolderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DashboardFolder _dashboardFolderInstance;
        private DashboardFolder _dashboardFolderInstanceFixture;

        #region General Initializer : Class (DashboardFolder) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DashboardFolder" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dashboardFolderInstanceType = typeof(DashboardFolder);
            _dashboardFolderInstanceFixture = Create(true);
            _dashboardFolderInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DashboardFolder" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DashboardFolder_Is_Instance_Present_Test()
        {
            // Assert
            _dashboardFolderInstanceType.ShouldNotBeNull();
            _dashboardFolderInstance.ShouldNotBeNull();
            _dashboardFolderInstanceFixture.ShouldNotBeNull();
            _dashboardFolderInstance.ShouldBeAssignableTo<DashboardFolder>();
            _dashboardFolderInstanceFixture.ShouldBeAssignableTo<DashboardFolder>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DashboardFolder) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DashboardFolder_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DashboardFolder instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dashboardFolderInstanceType.ShouldNotBeNull();
            _dashboardFolderInstance.ShouldNotBeNull();
            _dashboardFolderInstanceFixture.ShouldNotBeNull();
            _dashboardFolderInstance.ShouldBeAssignableTo<DashboardFolder>();
            _dashboardFolderInstanceFixture.ShouldBeAssignableTo<DashboardFolder>();
        }

        #endregion

        #endregion

        #endregion
    }
}