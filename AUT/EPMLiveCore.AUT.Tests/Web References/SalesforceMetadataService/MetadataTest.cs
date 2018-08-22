using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Metadata" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MetadataTest : AbstractBaseSetupTypedTest<Metadata>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Metadata) Initializer

        private const string PropertyfullName = "fullName";
        private const string FieldfullNameField = "fullNameField";
        private Type _metadataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Metadata _metadataInstance;
        private Metadata _metadataInstanceFixture;

        #region General Initializer : Class (Metadata) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Metadata" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _metadataInstanceType = typeof(Metadata);
            _metadataInstanceFixture = Create(true);
            _metadataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Metadata)

        #region General Initializer : Class (Metadata) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Metadata" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyfullName)]
        public void AUT_Metadata_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_metadataInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Metadata) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Metadata" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfullNameField)]
        public void AUT_Metadata_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_metadataInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="Metadata" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Metadata_Is_Instance_Present_Test()
        {
            // Assert
            _metadataInstanceType.ShouldNotBeNull();
            _metadataInstance.ShouldNotBeNull();
            _metadataInstanceFixture.ShouldNotBeNull();
            _metadataInstance.ShouldBeAssignableTo<Metadata>();
            _metadataInstanceFixture.ShouldBeAssignableTo<Metadata>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Metadata) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Metadata_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Metadata instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _metadataInstanceType.ShouldNotBeNull();
            _metadataInstance.ShouldNotBeNull();
            _metadataInstanceFixture.ShouldNotBeNull();
            _metadataInstance.ShouldBeAssignableTo<Metadata>();
            _metadataInstanceFixture.ShouldBeAssignableTo<Metadata>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Metadata) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyfullName)]
        public void AUT_Metadata_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Metadata, T>(_metadataInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Metadata) => Property (fullName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Metadata_Public_Class_fullName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfullName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}