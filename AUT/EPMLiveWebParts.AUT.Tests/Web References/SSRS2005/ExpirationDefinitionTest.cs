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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2005.ExpirationDefinition" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ExpirationDefinitionTest : AbstractBaseSetupTypedTest<ExpirationDefinition>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExpirationDefinition) Initializer

        private Type _expirationDefinitionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ExpirationDefinition _expirationDefinitionInstance;
        private ExpirationDefinition _expirationDefinitionInstanceFixture;

        #region General Initializer : Class (ExpirationDefinition) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExpirationDefinition" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _expirationDefinitionInstanceType = typeof(ExpirationDefinition);
            _expirationDefinitionInstanceFixture = Create(true);
            _expirationDefinitionInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ExpirationDefinition" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ExpirationDefinition_Is_Instance_Present_Test()
        {
            // Assert
            _expirationDefinitionInstanceType.ShouldNotBeNull();
            _expirationDefinitionInstance.ShouldNotBeNull();
            _expirationDefinitionInstanceFixture.ShouldNotBeNull();
            _expirationDefinitionInstance.ShouldBeAssignableTo<ExpirationDefinition>();
            _expirationDefinitionInstanceFixture.ShouldBeAssignableTo<ExpirationDefinition>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ExpirationDefinition) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ExpirationDefinition_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ExpirationDefinition instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _expirationDefinitionInstanceType.ShouldNotBeNull();
            _expirationDefinitionInstance.ShouldNotBeNull();
            _expirationDefinitionInstanceFixture.ShouldNotBeNull();
            _expirationDefinitionInstance.ShouldBeAssignableTo<ExpirationDefinition>();
            _expirationDefinitionInstanceFixture.ShouldBeAssignableTo<ExpirationDefinition>();
        }

        #endregion

        #endregion

        #endregion
    }
}