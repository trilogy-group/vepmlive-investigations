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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.DataServiceModules.DSMProgressChangedEventHandlerArgs" />)
    ///     and namespace <see cref="WorkEnginePPM.DataServiceModules"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DSMProgressChangedEventHandlerArgsTest : AbstractBaseSetupTypedTest<DSMProgressChangedEventHandlerArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DSMProgressChangedEventHandlerArgs) Initializer

        private Type _dSMProgressChangedEventHandlerArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DSMProgressChangedEventHandlerArgs _dSMProgressChangedEventHandlerArgsInstance;
        private DSMProgressChangedEventHandlerArgs _dSMProgressChangedEventHandlerArgsInstanceFixture;

        #region General Initializer : Class (DSMProgressChangedEventHandlerArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DSMProgressChangedEventHandlerArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dSMProgressChangedEventHandlerArgsInstanceType = typeof(DSMProgressChangedEventHandlerArgs);
            _dSMProgressChangedEventHandlerArgsInstanceFixture = Create(true);
            _dSMProgressChangedEventHandlerArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DSMProgressChangedEventHandlerArgs" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DSMProgressChangedEventHandlerArgs_Is_Instance_Present_Test()
        {
            // Assert
            _dSMProgressChangedEventHandlerArgsInstanceType.ShouldNotBeNull();
            _dSMProgressChangedEventHandlerArgsInstance.ShouldNotBeNull();
            _dSMProgressChangedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            _dSMProgressChangedEventHandlerArgsInstance.ShouldBeAssignableTo<DSMProgressChangedEventHandlerArgs>();
            _dSMProgressChangedEventHandlerArgsInstanceFixture.ShouldBeAssignableTo<DSMProgressChangedEventHandlerArgs>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DSMProgressChangedEventHandlerArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_DSMProgressChangedEventHandlerArgs_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var progressPercentage = CreateType<int>();
            var userState = CreateType<object>();
            DSMProgressChangedEventHandlerArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DSMProgressChangedEventHandlerArgs(progressPercentage, userState);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _dSMProgressChangedEventHandlerArgsInstance.ShouldNotBeNull();
            _dSMProgressChangedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<DSMProgressChangedEventHandlerArgs>();
        }

        #endregion

        #region General Constructor : Class (DSMProgressChangedEventHandlerArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_DSMProgressChangedEventHandlerArgs_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var progressPercentage = CreateType<int>();
            var userState = CreateType<object>();
            DSMProgressChangedEventHandlerArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new DSMProgressChangedEventHandlerArgs(progressPercentage, userState);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _dSMProgressChangedEventHandlerArgsInstance.ShouldNotBeNull();
            _dSMProgressChangedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #endregion
    }
}