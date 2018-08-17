using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.UpdateMetadata" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class UpdateMetadataTest : AbstractBaseSetupTypedTest<UpdateMetadata>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (UpdateMetadata) Initializer

        private const string PropertycurrentName = "currentName";
        private const string Propertymetadata = "metadata";
        private const string FieldcurrentNameField = "currentNameField";
        private const string FieldmetadataField = "metadataField";
        private Type _updateMetadataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private UpdateMetadata _updateMetadataInstance;
        private UpdateMetadata _updateMetadataInstanceFixture;

        #region General Initializer : Class (UpdateMetadata) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UpdateMetadata" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _updateMetadataInstanceType = typeof(UpdateMetadata);
            _updateMetadataInstanceFixture = Create(true);
            _updateMetadataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UpdateMetadata)

        #region General Initializer : Class (UpdateMetadata) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="UpdateMetadata" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycurrentName)]
        [TestCase(Propertymetadata)]
        public void AUT_UpdateMetadata_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_updateMetadataInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UpdateMetadata) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UpdateMetadata" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcurrentNameField)]
        [TestCase(FieldmetadataField)]
        public void AUT_UpdateMetadata_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_updateMetadataInstanceFixture, 
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
        ///     Class (<see cref="UpdateMetadata" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_UpdateMetadata_Is_Instance_Present_Test()
        {
            // Assert
            _updateMetadataInstanceType.ShouldNotBeNull();
            _updateMetadataInstance.ShouldNotBeNull();
            _updateMetadataInstanceFixture.ShouldNotBeNull();
            _updateMetadataInstance.ShouldBeAssignableTo<UpdateMetadata>();
            _updateMetadataInstanceFixture.ShouldBeAssignableTo<UpdateMetadata>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (UpdateMetadata) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_UpdateMetadata_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            UpdateMetadata instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _updateMetadataInstanceType.ShouldNotBeNull();
            _updateMetadataInstance.ShouldNotBeNull();
            _updateMetadataInstanceFixture.ShouldNotBeNull();
            _updateMetadataInstance.ShouldBeAssignableTo<UpdateMetadata>();
            _updateMetadataInstanceFixture.ShouldBeAssignableTo<UpdateMetadata>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (UpdateMetadata) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertycurrentName)]
        [TestCaseGeneric(typeof(Metadata) , Propertymetadata)]
        public void AUT_UpdateMetadata_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<UpdateMetadata, T>(_updateMetadataInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (UpdateMetadata) => Property (currentName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_UpdateMetadata_Public_Class_currentName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycurrentName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (UpdateMetadata) => Property (metadata) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_UpdateMetadata_metadata_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertymetadata);
            Action currentAction = () => propertyInfo.SetValue(_updateMetadataInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (UpdateMetadata) => Property (metadata) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_UpdateMetadata_Public_Class_metadata_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymetadata);

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