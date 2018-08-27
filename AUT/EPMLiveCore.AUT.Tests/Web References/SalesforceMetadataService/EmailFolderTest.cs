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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EmailFolder" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EmailFolderTest : AbstractBaseSetupTypedTest<EmailFolder>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EmailFolder) Initializer

        private Type _emailFolderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EmailFolder _emailFolderInstance;
        private EmailFolder _emailFolderInstanceFixture;

        #region General Initializer : Class (EmailFolder) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EmailFolder" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _emailFolderInstanceType = typeof(EmailFolder);
            _emailFolderInstanceFixture = Create(true);
            _emailFolderInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="EmailFolder" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EmailFolder_Is_Instance_Present_Test()
        {
            // Assert
            _emailFolderInstanceType.ShouldNotBeNull();
            _emailFolderInstance.ShouldNotBeNull();
            _emailFolderInstanceFixture.ShouldNotBeNull();
            _emailFolderInstance.ShouldBeAssignableTo<EmailFolder>();
            _emailFolderInstanceFixture.ShouldBeAssignableTo<EmailFolder>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EmailFolder) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EmailFolder_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EmailFolder instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _emailFolderInstanceType.ShouldNotBeNull();
            _emailFolderInstance.ShouldNotBeNull();
            _emailFolderInstanceFixture.ShouldNotBeNull();
            _emailFolderInstance.ShouldBeAssignableTo<EmailFolder>();
            _emailFolderInstanceFixture.ShouldBeAssignableTo<EmailFolder>();
        }

        #endregion

        #endregion

        #endregion
    }
}