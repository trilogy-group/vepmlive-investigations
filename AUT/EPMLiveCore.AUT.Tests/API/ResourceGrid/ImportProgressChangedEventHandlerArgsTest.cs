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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.ImportProgressChangedEventHandlerArgs" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ImportProgressChangedEventHandlerArgsTest : AbstractBaseSetupTypedTest<ImportProgressChangedEventHandlerArgs>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ImportProgressChangedEventHandlerArgs) Initializer

        private Type _importProgressChangedEventHandlerArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ImportProgressChangedEventHandlerArgs _importProgressChangedEventHandlerArgsInstance;
        private ImportProgressChangedEventHandlerArgs _importProgressChangedEventHandlerArgsInstanceFixture;

        #region General Initializer : Class (ImportProgressChangedEventHandlerArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ImportProgressChangedEventHandlerArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _importProgressChangedEventHandlerArgsInstanceType = typeof(ImportProgressChangedEventHandlerArgs);
            _importProgressChangedEventHandlerArgsInstanceFixture = Create(true);
            _importProgressChangedEventHandlerArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ImportProgressChangedEventHandlerArgs" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ImportProgressChangedEventHandlerArgs_Is_Instance_Present_Test()
        {
            // Assert
            _importProgressChangedEventHandlerArgsInstanceType.ShouldNotBeNull();
            _importProgressChangedEventHandlerArgsInstance.ShouldNotBeNull();
            _importProgressChangedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            _importProgressChangedEventHandlerArgsInstance.ShouldBeAssignableTo<ImportProgressChangedEventHandlerArgs>();
            _importProgressChangedEventHandlerArgsInstanceFixture.ShouldBeAssignableTo<ImportProgressChangedEventHandlerArgs>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ImportProgressChangedEventHandlerArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_ImportProgressChangedEventHandlerArgs_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var progressPercentage = CreateType<int>();
            var userState = CreateType<object>();
            ImportProgressChangedEventHandlerArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ImportProgressChangedEventHandlerArgs(progressPercentage, userState);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _importProgressChangedEventHandlerArgsInstance.ShouldNotBeNull();
            _importProgressChangedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<ImportProgressChangedEventHandlerArgs>();
        }

        #endregion

        #region General Constructor : Class (ImportProgressChangedEventHandlerArgs) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_ImportProgressChangedEventHandlerArgs_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var progressPercentage = CreateType<int>();
            var userState = CreateType<object>();
            ImportProgressChangedEventHandlerArgs instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new ImportProgressChangedEventHandlerArgs(progressPercentage, userState);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _importProgressChangedEventHandlerArgsInstance.ShouldNotBeNull();
            _importProgressChangedEventHandlerArgsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #endregion
    }
}