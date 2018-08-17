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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Profile" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProfileTest : AbstractBaseSetupTypedTest<Profile>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Profile) Initializer

        private const string PropertyapplicationVisibilities = "applicationVisibilities";
        private const string PropertyclassAccesses = "classAccesses";
        private const string PropertyexternalDataSourceAccesses = "externalDataSourceAccesses";
        private const string PropertyfieldPermissions = "fieldPermissions";
        private const string PropertylayoutAssignments = "layoutAssignments";
        private const string PropertyloginHours = "loginHours";
        private const string PropertyloginIpRanges = "loginIpRanges";
        private const string PropertyobjectPermissions = "objectPermissions";
        private const string PropertypageAccesses = "pageAccesses";
        private const string PropertyrecordTypeVisibilities = "recordTypeVisibilities";
        private const string PropertytabVisibilities = "tabVisibilities";
        private const string PropertyuserLicense = "userLicense";
        private const string FieldapplicationVisibilitiesField = "applicationVisibilitiesField";
        private const string FieldclassAccessesField = "classAccessesField";
        private const string FieldexternalDataSourceAccessesField = "externalDataSourceAccessesField";
        private const string FieldfieldPermissionsField = "fieldPermissionsField";
        private const string FieldlayoutAssignmentsField = "layoutAssignmentsField";
        private const string FieldloginHoursField = "loginHoursField";
        private const string FieldloginIpRangesField = "loginIpRangesField";
        private const string FieldobjectPermissionsField = "objectPermissionsField";
        private const string FieldpageAccessesField = "pageAccessesField";
        private const string FieldrecordTypeVisibilitiesField = "recordTypeVisibilitiesField";
        private const string FieldtabVisibilitiesField = "tabVisibilitiesField";
        private const string FielduserLicenseField = "userLicenseField";
        private Type _profileInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Profile _profileInstance;
        private Profile _profileInstanceFixture;

        #region General Initializer : Class (Profile) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Profile" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _profileInstanceType = typeof(Profile);
            _profileInstanceFixture = Create(true);
            _profileInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Profile)

        #region General Initializer : Class (Profile) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Profile" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapplicationVisibilities)]
        [TestCase(PropertyclassAccesses)]
        [TestCase(PropertyexternalDataSourceAccesses)]
        [TestCase(PropertyfieldPermissions)]
        [TestCase(PropertylayoutAssignments)]
        [TestCase(PropertyloginHours)]
        [TestCase(PropertyloginIpRanges)]
        [TestCase(PropertyobjectPermissions)]
        [TestCase(PropertypageAccesses)]
        [TestCase(PropertyrecordTypeVisibilities)]
        [TestCase(PropertytabVisibilities)]
        [TestCase(PropertyuserLicense)]
        public void AUT_Profile_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_profileInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Profile) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Profile" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapplicationVisibilitiesField)]
        [TestCase(FieldclassAccessesField)]
        [TestCase(FieldexternalDataSourceAccessesField)]
        [TestCase(FieldfieldPermissionsField)]
        [TestCase(FieldlayoutAssignmentsField)]
        [TestCase(FieldloginHoursField)]
        [TestCase(FieldloginIpRangesField)]
        [TestCase(FieldobjectPermissionsField)]
        [TestCase(FieldpageAccessesField)]
        [TestCase(FieldrecordTypeVisibilitiesField)]
        [TestCase(FieldtabVisibilitiesField)]
        [TestCase(FielduserLicenseField)]
        public void AUT_Profile_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_profileInstanceFixture, 
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
        ///     Class (<see cref="Profile" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Profile_Is_Instance_Present_Test()
        {
            // Assert
            _profileInstanceType.ShouldNotBeNull();
            _profileInstance.ShouldNotBeNull();
            _profileInstanceFixture.ShouldNotBeNull();
            _profileInstance.ShouldBeAssignableTo<Profile>();
            _profileInstanceFixture.ShouldBeAssignableTo<Profile>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Profile) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Profile_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Profile instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _profileInstanceType.ShouldNotBeNull();
            _profileInstance.ShouldNotBeNull();
            _profileInstanceFixture.ShouldNotBeNull();
            _profileInstance.ShouldBeAssignableTo<Profile>();
            _profileInstanceFixture.ShouldBeAssignableTo<Profile>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Profile) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ProfileApplicationVisibility[]) , PropertyapplicationVisibilities)]
        [TestCaseGeneric(typeof(ProfileApexClassAccess[]) , PropertyclassAccesses)]
        [TestCaseGeneric(typeof(ProfileExternalDataSourceAccess[]) , PropertyexternalDataSourceAccesses)]
        [TestCaseGeneric(typeof(ProfileFieldLevelSecurity[]) , PropertyfieldPermissions)]
        [TestCaseGeneric(typeof(ProfileLayoutAssignment[]) , PropertylayoutAssignments)]
        [TestCaseGeneric(typeof(ProfileLoginHours) , PropertyloginHours)]
        [TestCaseGeneric(typeof(ProfileLoginIpRange[]) , PropertyloginIpRanges)]
        [TestCaseGeneric(typeof(ProfileObjectPermissions[]) , PropertyobjectPermissions)]
        [TestCaseGeneric(typeof(ProfileApexPageAccess[]) , PropertypageAccesses)]
        [TestCaseGeneric(typeof(ProfileRecordTypeVisibility[]) , PropertyrecordTypeVisibilities)]
        [TestCaseGeneric(typeof(ProfileTabVisibility[]) , PropertytabVisibilities)]
        [TestCaseGeneric(typeof(string) , PropertyuserLicense)]
        public void AUT_Profile_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Profile, T>(_profileInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (applicationVisibilities) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_applicationVisibilities_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyapplicationVisibilities);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (applicationVisibilities) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_applicationVisibilities_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapplicationVisibilities);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (classAccesses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_classAccesses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyclassAccesses);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (classAccesses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_classAccesses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Profile) => Property (externalDataSourceAccesses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_externalDataSourceAccesses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyexternalDataSourceAccesses);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (externalDataSourceAccesses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_externalDataSourceAccesses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Profile) => Property (fieldPermissions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_fieldPermissions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfieldPermissions);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (fieldPermissions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_fieldPermissions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Profile) => Property (layoutAssignments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_layoutAssignments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylayoutAssignments);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (layoutAssignments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_layoutAssignments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylayoutAssignments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (loginHours) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_loginHours_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyloginHours);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (loginHours) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_loginHours_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyloginHours);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (loginIpRanges) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_loginIpRanges_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyloginIpRanges);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (loginIpRanges) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_loginIpRanges_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyloginIpRanges);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (objectPermissions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_objectPermissions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyobjectPermissions);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (objectPermissions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_objectPermissions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Profile) => Property (pageAccesses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_pageAccesses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypageAccesses);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (pageAccesses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_pageAccesses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Profile) => Property (recordTypeVisibilities) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_recordTypeVisibilities_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrecordTypeVisibilities);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (recordTypeVisibilities) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_recordTypeVisibilities_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordTypeVisibilities);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (tabVisibilities) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_tabVisibilities_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertytabVisibilities);
            Action currentAction = () => propertyInfo.SetValue(_profileInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (tabVisibilities) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_tabVisibilities_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytabVisibilities);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Profile) => Property (userLicense) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Profile_Public_Class_userLicense_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}