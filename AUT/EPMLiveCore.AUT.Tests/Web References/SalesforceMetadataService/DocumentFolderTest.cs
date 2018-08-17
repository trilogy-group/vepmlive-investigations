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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DocumentFolder" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DocumentFolderTest : AbstractBaseSetupTypedTest<DocumentFolder>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DocumentFolder) Initializer

        private Type _documentFolderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DocumentFolder _documentFolderInstance;
        private DocumentFolder _documentFolderInstanceFixture;

        #region General Initializer : Class (DocumentFolder) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DocumentFolder" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _documentFolderInstanceType = typeof(DocumentFolder);
            _documentFolderInstanceFixture = Create(true);
            _documentFolderInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DocumentFolder" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DocumentFolder_Is_Instance_Present_Test()
        {
            // Assert
            _documentFolderInstanceType.ShouldNotBeNull();
            _documentFolderInstance.ShouldNotBeNull();
            _documentFolderInstanceFixture.ShouldNotBeNull();
            _documentFolderInstance.ShouldBeAssignableTo<DocumentFolder>();
            _documentFolderInstanceFixture.ShouldBeAssignableTo<DocumentFolder>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DocumentFolder) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DocumentFolder_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DocumentFolder instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _documentFolderInstanceType.ShouldNotBeNull();
            _documentFolderInstance.ShouldNotBeNull();
            _documentFolderInstanceFixture.ShouldNotBeNull();
            _documentFolderInstance.ShouldBeAssignableTo<DocumentFolder>();
            _documentFolderInstanceFixture.ShouldBeAssignableTo<DocumentFolder>();
        }

        #endregion

        #endregion

        #endregion
    }
}