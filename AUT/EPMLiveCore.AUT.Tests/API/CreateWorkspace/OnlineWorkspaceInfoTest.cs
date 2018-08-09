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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.OnlineWorkspaceInfo" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class OnlineWorkspaceInfoTest : AbstractBaseSetupTypedTest<OnlineWorkspaceInfo>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (OnlineWorkspaceInfo) Initializer

        private Type _onlineWorkspaceInfoInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private OnlineWorkspaceInfo _onlineWorkspaceInfoInstance;
        private OnlineWorkspaceInfo _onlineWorkspaceInfoInstanceFixture;

        #region General Initializer : Class (OnlineWorkspaceInfo) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="OnlineWorkspaceInfo" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _onlineWorkspaceInfoInstanceType = typeof(OnlineWorkspaceInfo);
            _onlineWorkspaceInfoInstanceFixture = Create(true);
            _onlineWorkspaceInfoInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="OnlineWorkspaceInfo" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_OnlineWorkspaceInfo_Is_Instance_Present_Test()
        {
            // Assert
            _onlineWorkspaceInfoInstanceType.ShouldNotBeNull();
            _onlineWorkspaceInfoInstance.ShouldNotBeNull();
            _onlineWorkspaceInfoInstanceFixture.ShouldNotBeNull();
            _onlineWorkspaceInfoInstance.ShouldBeAssignableTo<OnlineWorkspaceInfo>();
            _onlineWorkspaceInfoInstanceFixture.ShouldBeAssignableTo<OnlineWorkspaceInfo>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (OnlineWorkspaceInfo) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_OnlineWorkspaceInfo_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            OnlineWorkspaceInfo instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new OnlineWorkspaceInfo(data);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _onlineWorkspaceInfoInstance.ShouldNotBeNull();
            _onlineWorkspaceInfoInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<OnlineWorkspaceInfo>();
        }

        #endregion

        #region General Constructor : Class (OnlineWorkspaceInfo) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_OnlineWorkspaceInfo_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var data = CreateType<string>();
            OnlineWorkspaceInfo instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new OnlineWorkspaceInfo(data);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _onlineWorkspaceInfoInstance.ShouldNotBeNull();
            _onlineWorkspaceInfoInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #endregion
    }
}