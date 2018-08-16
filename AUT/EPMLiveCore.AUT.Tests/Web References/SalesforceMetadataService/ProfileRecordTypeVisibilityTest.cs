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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ProfileRecordTypeVisibility" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProfileRecordTypeVisibilityTest : AbstractBaseSetupTypedTest<ProfileRecordTypeVisibility>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProfileRecordTypeVisibility) Initializer
        
        private const string PropertypersonAccountDefault = "personAccountDefault";
        private const string PropertypersonAccountDefaultSpecified = "personAccountDefaultSpecified";
        private const string PropertyrecordType = "recordType";
        private const string Propertyvisible = "visible";
        private const string FielddefaultField = "defaultField";
        private const string FieldpersonAccountDefaultField = "personAccountDefaultField";
        private const string FieldpersonAccountDefaultFieldSpecified = "personAccountDefaultFieldSpecified";
        private const string FieldrecordTypeField = "recordTypeField";
        private const string FieldvisibleField = "visibleField";
        private Type _profileRecordTypeVisibilityInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProfileRecordTypeVisibility _profileRecordTypeVisibilityInstance;
        private ProfileRecordTypeVisibility _profileRecordTypeVisibilityInstanceFixture;

        #region General Initializer : Class (ProfileRecordTypeVisibility) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProfileRecordTypeVisibility" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _profileRecordTypeVisibilityInstanceType = typeof(ProfileRecordTypeVisibility);
            _profileRecordTypeVisibilityInstanceFixture = Create(true);
            _profileRecordTypeVisibilityInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProfileRecordTypeVisibility)

        #region General Initializer : Class (ProfileRecordTypeVisibility) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileRecordTypeVisibility" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertypersonAccountDefault)]
        [TestCase(PropertypersonAccountDefaultSpecified)]
        [TestCase(PropertyrecordType)]
        [TestCase(Propertyvisible)]
        public void AUT_ProfileRecordTypeVisibility_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_profileRecordTypeVisibilityInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProfileRecordTypeVisibility) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileRecordTypeVisibility" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddefaultField)]
        [TestCase(FieldpersonAccountDefaultField)]
        [TestCase(FieldpersonAccountDefaultFieldSpecified)]
        [TestCase(FieldrecordTypeField)]
        [TestCase(FieldvisibleField)]
        public void AUT_ProfileRecordTypeVisibility_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_profileRecordTypeVisibilityInstanceFixture, 
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
        ///     Class (<see cref="ProfileRecordTypeVisibility" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProfileRecordTypeVisibility_Is_Instance_Present_Test()
        {
            // Assert
            _profileRecordTypeVisibilityInstanceType.ShouldNotBeNull();
            _profileRecordTypeVisibilityInstance.ShouldNotBeNull();
            _profileRecordTypeVisibilityInstanceFixture.ShouldNotBeNull();
            _profileRecordTypeVisibilityInstance.ShouldBeAssignableTo<ProfileRecordTypeVisibility>();
            _profileRecordTypeVisibilityInstanceFixture.ShouldBeAssignableTo<ProfileRecordTypeVisibility>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProfileRecordTypeVisibility) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProfileRecordTypeVisibility_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProfileRecordTypeVisibility instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _profileRecordTypeVisibilityInstanceType.ShouldNotBeNull();
            _profileRecordTypeVisibilityInstance.ShouldNotBeNull();
            _profileRecordTypeVisibilityInstanceFixture.ShouldNotBeNull();
            _profileRecordTypeVisibilityInstance.ShouldBeAssignableTo<ProfileRecordTypeVisibility>();
            _profileRecordTypeVisibilityInstanceFixture.ShouldBeAssignableTo<ProfileRecordTypeVisibility>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProfileRecordTypeVisibility) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertypersonAccountDefault)]
        [TestCaseGeneric(typeof(bool) , PropertypersonAccountDefaultSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyrecordType)]
        [TestCaseGeneric(typeof(bool) , Propertyvisible)]
        public void AUT_ProfileRecordTypeVisibility_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProfileRecordTypeVisibility, T>(_profileRecordTypeVisibilityInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (ProfileRecordTypeVisibility) => Property (personAccountDefault) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileRecordTypeVisibility_Public_Class_personAccountDefault_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypersonAccountDefault);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileRecordTypeVisibility) => Property (personAccountDefaultSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileRecordTypeVisibility_Public_Class_personAccountDefaultSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypersonAccountDefaultSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileRecordTypeVisibility) => Property (recordType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileRecordTypeVisibility_Public_Class_recordType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileRecordTypeVisibility) => Property (visible) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileRecordTypeVisibility_Public_Class_visible_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvisible);

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