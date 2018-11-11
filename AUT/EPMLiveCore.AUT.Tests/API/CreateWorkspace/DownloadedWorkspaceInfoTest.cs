using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.DownloadedWorkspaceInfo" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DownloadedWorkspaceInfoTest : AbstractBaseSetupTypedTest<DownloadedWorkspaceInfo>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DownloadedWorkspaceInfo) Initializer

        private Type _downloadedWorkspaceInfoInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DownloadedWorkspaceInfo _downloadedWorkspaceInfoInstance;
        private DownloadedWorkspaceInfo _downloadedWorkspaceInfoInstanceFixture;

        #region General Initializer : Class (DownloadedWorkspaceInfo) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DownloadedWorkspaceInfo" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _downloadedWorkspaceInfoInstanceType = typeof(DownloadedWorkspaceInfo);
            _downloadedWorkspaceInfoInstanceFixture = Create(true);
            _downloadedWorkspaceInfoInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DownloadedWorkspaceInfo" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DownloadedWorkspaceInfo_Is_Instance_Present_Test()
        {
            // Assert
            _downloadedWorkspaceInfoInstanceType.ShouldNotBeNull();
            _downloadedWorkspaceInfoInstance.ShouldNotBeNull();
            _downloadedWorkspaceInfoInstanceFixture.ShouldNotBeNull();
            _downloadedWorkspaceInfoInstance.ShouldBeAssignableTo<DownloadedWorkspaceInfo>();
            _downloadedWorkspaceInfoInstanceFixture.ShouldBeAssignableTo<DownloadedWorkspaceInfo>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DownloadedWorkspaceInfo) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DownloadedWorkspaceInfo_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            DownloadedWorkspaceInfo instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DownloadedWorkspaceInfo(data);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _downloadedWorkspaceInfoInstance.ShouldNotBeNull();
            _downloadedWorkspaceInfoInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<DownloadedWorkspaceInfo>();
        }

        #endregion

        #region General Constructor : Class (DownloadedWorkspaceInfo) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DownloadedWorkspaceInfo_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var data = CreateType<string>();
            DownloadedWorkspaceInfo instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DownloadedWorkspaceInfo(data);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _downloadedWorkspaceInfoInstance.ShouldNotBeNull();
            _downloadedWorkspaceInfoInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #endregion
    }
}