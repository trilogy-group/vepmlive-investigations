using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.ImportCompletedEventHandlerArgs" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ImportCompletedEventHandlerArgsTest : AbstractBaseSetupTypedTest<ImportCompletedEventHandlerArgs>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ImportCompletedEventHandlerArgs) Initializer

        private Type _importCompletedEventHandlerArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ImportCompletedEventHandlerArgs _importCompletedEventHandlerArgsInstance;
        private ImportCompletedEventHandlerArgs _importCompletedEventHandlerArgsInstanceFixture;

        #region General Initializer : Class (ImportCompletedEventHandlerArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ImportCompletedEventHandlerArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _importCompletedEventHandlerArgsInstanceType = typeof(ImportCompletedEventHandlerArgs);
            _importCompletedEventHandlerArgsInstanceFixture = Create(true);
            _importCompletedEventHandlerArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ImportCompletedEventHandlerArgs" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ImportCompletedEventHandlerArgs_Is_Instance_Present_Test()
        {
            // Assert
            _importCompletedEventHandlerArgsInstanceType.ShouldNotBeNull();
            _importCompletedEventHandlerArgsInstance.ShouldNotBeNull();
            _importCompletedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            _importCompletedEventHandlerArgsInstance.ShouldBeAssignableTo<ImportCompletedEventHandlerArgs>();
            _importCompletedEventHandlerArgsInstanceFixture.ShouldBeAssignableTo<ImportCompletedEventHandlerArgs>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ImportCompletedEventHandlerArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_ImportCompletedEventHandlerArgs_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var error = CreateType<Exception>();
            var cancelled = CreateType<bool>();
            var userState = CreateType<object>();
            ImportCompletedEventHandlerArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ImportCompletedEventHandlerArgs(error, cancelled, userState);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _importCompletedEventHandlerArgsInstance.ShouldNotBeNull();
            _importCompletedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<ImportCompletedEventHandlerArgs>();
        }

        #endregion

        #region General Constructor : Class (ImportCompletedEventHandlerArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_ImportCompletedEventHandlerArgs_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var error = CreateType<Exception>();
            var cancelled = CreateType<bool>();
            var userState = CreateType<object>();
            ImportCompletedEventHandlerArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ImportCompletedEventHandlerArgs(error, cancelled, userState);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _importCompletedEventHandlerArgsInstance.ShouldNotBeNull();
            _importCompletedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #endregion
    }
}