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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PermissionSet" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PermissionSetTest : AbstractBaseSetupTypedTest<PermissionSet>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PermissionSet) Initializer

        private const string PropertyclassAccesses = "classAccesses";
        private const string Propertydescription = "description";
        private const string PropertyexternalDataSourceAccesses = "externalDataSourceAccesses";
        private const string PropertyfieldPermissions = "fieldPermissions";
        private const string Propertylabel = "label";
        private const string PropertyobjectPermissions = "objectPermissions";
        private const string PropertypageAccesses = "pageAccesses";
        private const string PropertytabSettings = "tabSettings";
        private const string PropertyuserLicense = "userLicense";
        private const string PropertyuserPermissions = "userPermissions";
        private const string FieldclassAccessesField = "classAccessesField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldexternalDataSourceAccessesField = "externalDataSourceAccessesField";
        private const string FieldfieldPermissionsField = "fieldPermissionsField";
        private const string FieldlabelField = "labelField";
        private const string FieldobjectPermissionsField = "objectPermissionsField";
        private const string FieldpageAccessesField = "pageAccessesField";
        private const string FieldtabSettingsField = "tabSettingsField";
        private const string FielduserLicenseField = "userLicenseField";
        private const string FielduserPermissionsField = "userPermissionsField";
        private Type _permissionSetInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PermissionSet _permissionSetInstance;
        private PermissionSet _permissionSetInstanceFixture;

        #region General Initializer : Class (PermissionSet) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PermissionSet" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _permissionSetInstanceType = typeof(PermissionSet);
            _permissionSetInstanceFixture = Create(true);
            _permissionSetInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PermissionSet)

        #region General Initializer : Class (PermissionSet) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSet" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyclassAccesses)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyexternalDataSourceAccesses)]
        [TestCase(PropertyfieldPermissions)]
        [TestCase(Propertylabel)]
        [TestCase(PropertyobjectPermissions)]
        [TestCase(PropertypageAccesses)]
        [TestCase(PropertytabSettings)]
        [TestCase(PropertyuserLicense)]
        [TestCase(PropertyuserPermissions)]
        public void AUT_PermissionSet_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_permissionSetInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PermissionSet) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PermissionSet" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldclassAccessesField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldexternalDataSourceAccessesField)]
        [TestCase(FieldfieldPermissionsField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldobjectPermissionsField)]
        [TestCase(FieldpageAccessesField)]
        [TestCase(FieldtabSettingsField)]
        [TestCase(FielduserLicenseField)]
        [TestCase(FielduserPermissionsField)]
        public void AUT_PermissionSet_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_permissionSetInstanceFixture, 
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
        ///     Class (<see cref="PermissionSet" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PermissionSet_Is_Instance_Present_Test()
        {
            // Assert
            _permissionSetInstanceType.ShouldNotBeNull();
            _permissionSetInstance.ShouldNotBeNull();
            _permissionSetInstanceFixture.ShouldNotBeNull();
            _permissionSetInstance.ShouldBeAssignableTo<PermissionSet>();
            _permissionSetInstanceFixture.ShouldBeAssignableTo<PermissionSet>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PermissionSet) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PermissionSet_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PermissionSet instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _permissionSetInstanceType.ShouldNotBeNull();
            _permissionSetInstance.ShouldNotBeNull();
            _permissionSetInstanceFixture.ShouldNotBeNull();
            _permissionSetInstance.ShouldBeAssignableTo<PermissionSet>();
            _permissionSetInstanceFixture.ShouldBeAssignableTo<PermissionSet>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PermissionSet) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(PermissionSetApexClassAccess[]) , PropertyclassAccesses)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(PermissionSetExternalDataSourceAccess[]) , PropertyexternalDataSourceAccesses)]
        [TestCaseGeneric(typeof(PermissionSetFieldPermissions[]) , PropertyfieldPermissions)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(PermissionSetObjectPermissions[]) , PropertyobjectPermissions)]
        [TestCaseGeneric(typeof(PermissionSetApexPageAccess[]) , PropertypageAccesses)]
        [TestCaseGeneric(typeof(PermissionSetTabSetting[]) , PropertytabSettings)]
        [TestCaseGeneric(typeof(string) , PropertyuserLicense)]
        [TestCaseGeneric(typeof(PermissionSetUserPermission[]) , PropertyuserPermissions)]
        public void AUT_PermissionSet_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PermissionSet, T>(_permissionSetInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (classAccesses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_classAccesses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyclassAccesses);
            Action currentAction = () => propertyInfo.SetValue(_permissionSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (classAccesses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_Public_Class_classAccesses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyclassAccesses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PermissionSet) => Property (externalDataSourceAccesses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_externalDataSourceAccesses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyexternalDataSourceAccesses);
            Action currentAction = () => propertyInfo.SetValue(_permissionSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (externalDataSourceAccesses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_Public_Class_externalDataSourceAccesses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexternalDataSourceAccesses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (fieldPermissions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_fieldPermissions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfieldPermissions);
            Action currentAction = () => propertyInfo.SetValue(_permissionSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (fieldPermissions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_Public_Class_fieldPermissions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfieldPermissions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PermissionSet) => Property (objectPermissions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_objectPermissions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyobjectPermissions);
            Action currentAction = () => propertyInfo.SetValue(_permissionSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (objectPermissions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_Public_Class_objectPermissions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PermissionSet) => Property (pageAccesses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_pageAccesses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypageAccesses);
            Action currentAction = () => propertyInfo.SetValue(_permissionSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (pageAccesses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_Public_Class_pageAccesses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypageAccesses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (tabSettings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_tabSettings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertytabSettings);
            Action currentAction = () => propertyInfo.SetValue(_permissionSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (tabSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_Public_Class_tabSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytabSettings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (userLicense) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_Public_Class_userLicense_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserLicense);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (userPermissions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_userPermissions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyuserPermissions);
            Action currentAction = () => propertyInfo.SetValue(_permissionSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PermissionSet) => Property (userPermissions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PermissionSet_Public_Class_userPermissions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserPermissions);

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