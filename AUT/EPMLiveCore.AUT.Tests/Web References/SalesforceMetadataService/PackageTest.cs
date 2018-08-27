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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Package" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PackageTest : AbstractBaseSetupTypedTest<Package>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Package) Initializer

        private const string PropertyapiAccessLevel = "apiAccessLevel";
        private const string PropertyapiAccessLevelSpecified = "apiAccessLevelSpecified";
        private const string Propertydescription = "description";
        private const string PropertynamespacePrefix = "namespacePrefix";
        private const string PropertyobjectPermissions = "objectPermissions";
        private const string PropertypostInstallClass = "postInstallClass";
        private const string PropertysetupWeblink = "setupWeblink";
        private const string Propertytypes = "types";
        private const string PropertyuninstallClass = "uninstallClass";
        private const string Propertyversion = "version";
        private const string FieldapiAccessLevelField = "apiAccessLevelField";
        private const string FieldapiAccessLevelFieldSpecified = "apiAccessLevelFieldSpecified";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldnamespacePrefixField = "namespacePrefixField";
        private const string FieldobjectPermissionsField = "objectPermissionsField";
        private const string FieldpostInstallClassField = "postInstallClassField";
        private const string FieldsetupWeblinkField = "setupWeblinkField";
        private const string FieldtypesField = "typesField";
        private const string FielduninstallClassField = "uninstallClassField";
        private const string FieldversionField = "versionField";
        private Type _packageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Package _packageInstance;
        private Package _packageInstanceFixture;

        #region General Initializer : Class (Package) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Package" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _packageInstanceType = typeof(Package);
            _packageInstanceFixture = Create(true);
            _packageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Package)

        #region General Initializer : Class (Package) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Package" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapiAccessLevel)]
        [TestCase(PropertyapiAccessLevelSpecified)]
        [TestCase(Propertydescription)]
        [TestCase(PropertynamespacePrefix)]
        [TestCase(PropertyobjectPermissions)]
        [TestCase(PropertypostInstallClass)]
        [TestCase(PropertysetupWeblink)]
        [TestCase(Propertytypes)]
        [TestCase(PropertyuninstallClass)]
        [TestCase(Propertyversion)]
        public void AUT_Package_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_packageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Package) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Package" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapiAccessLevelField)]
        [TestCase(FieldapiAccessLevelFieldSpecified)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldnamespacePrefixField)]
        [TestCase(FieldobjectPermissionsField)]
        [TestCase(FieldpostInstallClassField)]
        [TestCase(FieldsetupWeblinkField)]
        [TestCase(FieldtypesField)]
        [TestCase(FielduninstallClassField)]
        [TestCase(FieldversionField)]
        public void AUT_Package_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_packageInstanceFixture, 
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
        ///     Class (<see cref="Package" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Package_Is_Instance_Present_Test()
        {
            // Assert
            _packageInstanceType.ShouldNotBeNull();
            _packageInstance.ShouldNotBeNull();
            _packageInstanceFixture.ShouldNotBeNull();
            _packageInstance.ShouldBeAssignableTo<Package>();
            _packageInstanceFixture.ShouldBeAssignableTo<Package>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Package) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Package_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Package instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _packageInstanceType.ShouldNotBeNull();
            _packageInstance.ShouldNotBeNull();
            _packageInstanceFixture.ShouldNotBeNull();
            _packageInstance.ShouldBeAssignableTo<Package>();
            _packageInstanceFixture.ShouldBeAssignableTo<Package>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Package) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(APIAccessLevel) , PropertyapiAccessLevel)]
        [TestCaseGeneric(typeof(bool) , PropertyapiAccessLevelSpecified)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertynamespacePrefix)]
        [TestCaseGeneric(typeof(ProfileObjectPermissions[]) , PropertyobjectPermissions)]
        [TestCaseGeneric(typeof(string) , PropertypostInstallClass)]
        [TestCaseGeneric(typeof(string) , PropertysetupWeblink)]
        [TestCaseGeneric(typeof(PackageTypeMembers[]) , Propertytypes)]
        [TestCaseGeneric(typeof(string) , PropertyuninstallClass)]
        [TestCaseGeneric(typeof(string) , Propertyversion)]
        public void AUT_Package_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Package, T>(_packageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (apiAccessLevel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_apiAccessLevel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyapiAccessLevel);
            Action currentAction = () => propertyInfo.SetValue(_packageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (apiAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_Public_Class_apiAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapiAccessLevel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (apiAccessLevelSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_Public_Class_apiAccessLevelSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapiAccessLevelSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (namespacePrefix) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_Public_Class_namespacePrefix_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynamespacePrefix);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (objectPermissions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_objectPermissions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyobjectPermissions);
            Action currentAction = () => propertyInfo.SetValue(_packageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (objectPermissions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_Public_Class_objectPermissions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyobjectPermissions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (postInstallClass) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_Public_Class_postInstallClass_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypostInstallClass);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (setupWeblink) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_Public_Class_setupWeblink_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysetupWeblink);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (types) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_types_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytypes);
            Action currentAction = () => propertyInfo.SetValue(_packageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (types) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_Public_Class_types_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytypes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (uninstallClass) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_Public_Class_uninstallClass_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuninstallClass);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Package) => Property (version) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Package_Public_Class_version_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyversion);

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