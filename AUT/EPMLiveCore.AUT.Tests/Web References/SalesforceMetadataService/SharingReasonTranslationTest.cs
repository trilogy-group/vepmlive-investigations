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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SharingReasonTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SharingReasonTranslationTest : AbstractBaseSetupTypedTest<SharingReasonTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SharingReasonTranslation) Initializer

        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private Type _sharingReasonTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SharingReasonTranslation _sharingReasonTranslationInstance;
        private SharingReasonTranslation _sharingReasonTranslationInstanceFixture;

        #region General Initializer : Class (SharingReasonTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SharingReasonTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sharingReasonTranslationInstanceType = typeof(SharingReasonTranslation);
            _sharingReasonTranslationInstanceFixture = Create(true);
            _sharingReasonTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SharingReasonTranslation)

        #region General Initializer : Class (SharingReasonTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SharingReasonTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        public void AUT_SharingReasonTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sharingReasonTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SharingReasonTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SharingReasonTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        public void AUT_SharingReasonTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sharingReasonTranslationInstanceFixture, 
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
        ///     Class (<see cref="SharingReasonTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SharingReasonTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _sharingReasonTranslationInstanceType.ShouldNotBeNull();
            _sharingReasonTranslationInstance.ShouldNotBeNull();
            _sharingReasonTranslationInstanceFixture.ShouldNotBeNull();
            _sharingReasonTranslationInstance.ShouldBeAssignableTo<SharingReasonTranslation>();
            _sharingReasonTranslationInstanceFixture.ShouldBeAssignableTo<SharingReasonTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SharingReasonTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SharingReasonTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SharingReasonTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sharingReasonTranslationInstanceType.ShouldNotBeNull();
            _sharingReasonTranslationInstance.ShouldNotBeNull();
            _sharingReasonTranslationInstanceFixture.ShouldNotBeNull();
            _sharingReasonTranslationInstance.ShouldBeAssignableTo<SharingReasonTranslation>();
            _sharingReasonTranslationInstanceFixture.ShouldBeAssignableTo<SharingReasonTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SharingReasonTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_SharingReasonTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SharingReasonTranslation, T>(_sharingReasonTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SharingReasonTranslation) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharingReasonTranslation_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SharingReasonTranslation) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SharingReasonTranslation_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

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