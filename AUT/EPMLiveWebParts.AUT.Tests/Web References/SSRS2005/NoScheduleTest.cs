using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2005.NoSchedule" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class NoScheduleTest : AbstractBaseSetupTypedTest<NoSchedule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (NoSchedule) Initializer

        private Type _noScheduleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private NoSchedule _noScheduleInstance;
        private NoSchedule _noScheduleInstanceFixture;

        #region General Initializer : Class (NoSchedule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NoSchedule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _noScheduleInstanceType = typeof(NoSchedule);
            _noScheduleInstanceFixture = Create(true);
            _noScheduleInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="NoSchedule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_NoSchedule_Is_Instance_Present_Test()
        {
            // Assert
            _noScheduleInstanceType.ShouldNotBeNull();
            _noScheduleInstance.ShouldNotBeNull();
            _noScheduleInstanceFixture.ShouldNotBeNull();
            _noScheduleInstance.ShouldBeAssignableTo<NoSchedule>();
            _noScheduleInstanceFixture.ShouldBeAssignableTo<NoSchedule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NoSchedule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_NoSchedule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            NoSchedule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _noScheduleInstanceType.ShouldNotBeNull();
            _noScheduleInstance.ShouldNotBeNull();
            _noScheduleInstanceFixture.ShouldNotBeNull();
            _noScheduleInstance.ShouldBeAssignableTo<NoSchedule>();
            _noScheduleInstanceFixture.ShouldBeAssignableTo<NoSchedule>();
        }

        #endregion

        #endregion

        #endregion
    }
}