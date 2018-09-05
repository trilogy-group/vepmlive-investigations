using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM.DataServiceModules
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.DataServiceModules.DSMCompletedEventHandlerArgs" />)
    ///     and namespace <see cref="WorkEnginePPM.DataServiceModules"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DSMCompletedEventHandlerArgsTest : AbstractBaseSetupTypedTest<DSMCompletedEventHandlerArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DSMCompletedEventHandlerArgs) Initializer

        private Type _dSMCompletedEventHandlerArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DSMCompletedEventHandlerArgs _dSMCompletedEventHandlerArgsInstance;
        private DSMCompletedEventHandlerArgs _dSMCompletedEventHandlerArgsInstanceFixture;

        #region General Initializer : Class (DSMCompletedEventHandlerArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DSMCompletedEventHandlerArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dSMCompletedEventHandlerArgsInstanceType = typeof(DSMCompletedEventHandlerArgs);
            _dSMCompletedEventHandlerArgsInstanceFixture = Create(true);
            _dSMCompletedEventHandlerArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DSMCompletedEventHandlerArgs" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DSMCompletedEventHandlerArgs_Is_Instance_Present_Test()
        {
            // Assert
            _dSMCompletedEventHandlerArgsInstanceType.ShouldNotBeNull();
            _dSMCompletedEventHandlerArgsInstance.ShouldNotBeNull();
            _dSMCompletedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            _dSMCompletedEventHandlerArgsInstance.ShouldBeAssignableTo<DSMCompletedEventHandlerArgs>();
            _dSMCompletedEventHandlerArgsInstanceFixture.ShouldBeAssignableTo<DSMCompletedEventHandlerArgs>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DSMCompletedEventHandlerArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_DSMCompletedEventHandlerArgs_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var error = CreateType<Exception>();
            var cancelled = CreateType<bool>();
            var userState = CreateType<object>();
            DSMCompletedEventHandlerArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DSMCompletedEventHandlerArgs(error, cancelled, userState);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _dSMCompletedEventHandlerArgsInstance.ShouldNotBeNull();
            _dSMCompletedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<DSMCompletedEventHandlerArgs>();
        }

        #endregion

        #region General Constructor : Class (DSMCompletedEventHandlerArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_DSMCompletedEventHandlerArgs_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var error = CreateType<Exception>();
            var cancelled = CreateType<bool>();
            var userState = CreateType<object>();
            DSMCompletedEventHandlerArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DSMCompletedEventHandlerArgs(error, cancelled, userState);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _dSMCompletedEventHandlerArgsInstance.ShouldNotBeNull();
            _dSMCompletedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #endregion
    }
}