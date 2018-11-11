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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomApplication" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomApplicationTest : AbstractBaseSetupTypedTest<CustomApplication>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomApplication) Initializer

        private const string PropertycustomApplicationComponents = "customApplicationComponents";
        private const string PropertydefaultLandingTab = "defaultLandingTab";
        private const string Propertydescription = "description";
        private const string PropertydetailPageRefreshMethod = "detailPageRefreshMethod";
        private const string PropertydomainWhitelist = "domainWhitelist";
        private const string PropertyisServiceCloudConsole = "isServiceCloudConsole";
        private const string PropertyisServiceCloudConsoleSpecified = "isServiceCloudConsoleSpecified";
        private const string Propertylabel = "label";
        private const string PropertylistPlacement = "listPlacement";
        private const string PropertylistRefreshMethod = "listRefreshMethod";
        private const string Propertylogo = "logo";
        private const string Propertytab = "tab";
        private const string PropertyworkspaceMappings = "workspaceMappings";
        private const string FieldcustomApplicationComponentsField = "customApplicationComponentsField";
        private const string FielddefaultLandingTabField = "defaultLandingTabField";
        private const string FielddescriptionField = "descriptionField";
        private const string FielddetailPageRefreshMethodField = "detailPageRefreshMethodField";
        private const string FielddomainWhitelistField = "domainWhitelistField";
        private const string FieldisServiceCloudConsoleField = "isServiceCloudConsoleField";
        private const string FieldisServiceCloudConsoleFieldSpecified = "isServiceCloudConsoleFieldSpecified";
        private const string FieldlabelField = "labelField";
        private const string FieldlistPlacementField = "listPlacementField";
        private const string FieldlistRefreshMethodField = "listRefreshMethodField";
        private const string FieldlogoField = "logoField";
        private const string FieldtabField = "tabField";
        private const string FieldworkspaceMappingsField = "workspaceMappingsField";
        private Type _customApplicationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomApplication _customApplicationInstance;
        private CustomApplication _customApplicationInstanceFixture;

        #region General Initializer : Class (CustomApplication) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomApplication" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customApplicationInstanceType = typeof(CustomApplication);
            _customApplicationInstanceFixture = Create(true);
            _customApplicationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomApplication)

        #region General Initializer : Class (CustomApplication) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomApplication" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycustomApplicationComponents)]
        [TestCase(PropertydefaultLandingTab)]
        [TestCase(Propertydescription)]
        [TestCase(PropertydetailPageRefreshMethod)]
        [TestCase(PropertydomainWhitelist)]
        [TestCase(PropertyisServiceCloudConsole)]
        [TestCase(PropertyisServiceCloudConsoleSpecified)]
        [TestCase(Propertylabel)]
        [TestCase(PropertylistPlacement)]
        [TestCase(PropertylistRefreshMethod)]
        [TestCase(Propertylogo)]
        [TestCase(Propertytab)]
        [TestCase(PropertyworkspaceMappings)]
        public void AUT_CustomApplication_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customApplicationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomApplication) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomApplication" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomApplicationComponentsField)]
        [TestCase(FielddefaultLandingTabField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FielddetailPageRefreshMethodField)]
        [TestCase(FielddomainWhitelistField)]
        [TestCase(FieldisServiceCloudConsoleField)]
        [TestCase(FieldisServiceCloudConsoleFieldSpecified)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlistPlacementField)]
        [TestCase(FieldlistRefreshMethodField)]
        [TestCase(FieldlogoField)]
        [TestCase(FieldtabField)]
        [TestCase(FieldworkspaceMappingsField)]
        public void AUT_CustomApplication_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customApplicationInstanceFixture, 
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
        ///     Class (<see cref="CustomApplication" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomApplication_Is_Instance_Present_Test()
        {
            // Assert
            _customApplicationInstanceType.ShouldNotBeNull();
            _customApplicationInstance.ShouldNotBeNull();
            _customApplicationInstanceFixture.ShouldNotBeNull();
            _customApplicationInstance.ShouldBeAssignableTo<CustomApplication>();
            _customApplicationInstanceFixture.ShouldBeAssignableTo<CustomApplication>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomApplication) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomApplication_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomApplication instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customApplicationInstanceType.ShouldNotBeNull();
            _customApplicationInstance.ShouldNotBeNull();
            _customApplicationInstanceFixture.ShouldNotBeNull();
            _customApplicationInstance.ShouldBeAssignableTo<CustomApplication>();
            _customApplicationInstanceFixture.ShouldBeAssignableTo<CustomApplication>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomApplication) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CustomApplicationComponents) , PropertycustomApplicationComponents)]
        [TestCaseGeneric(typeof(string) , PropertydefaultLandingTab)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertydetailPageRefreshMethod)]
        [TestCaseGeneric(typeof(string[]) , PropertydomainWhitelist)]
        [TestCaseGeneric(typeof(bool) , PropertyisServiceCloudConsole)]
        [TestCaseGeneric(typeof(bool) , PropertyisServiceCloudConsoleSpecified)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(ListPlacement) , PropertylistPlacement)]
        [TestCaseGeneric(typeof(string) , PropertylistRefreshMethod)]
        [TestCaseGeneric(typeof(string) , Propertylogo)]
        [TestCaseGeneric(typeof(string[]) , Propertytab)]
        [TestCaseGeneric(typeof(WorkspaceMapping[]) , PropertyworkspaceMappings)]
        public void AUT_CustomApplication_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomApplication, T>(_customApplicationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (customApplicationComponents) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_customApplicationComponents_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomApplicationComponents);
            Action currentAction = () => propertyInfo.SetValue(_customApplicationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (customApplicationComponents) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_customApplicationComponents_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomApplicationComponents);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (defaultLandingTab) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_defaultLandingTab_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultLandingTab);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomApplication) => Property (detailPageRefreshMethod) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_detailPageRefreshMethod_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydetailPageRefreshMethod);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (domainWhitelist) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_domainWhitelist_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydomainWhitelist);
            Action currentAction = () => propertyInfo.SetValue(_customApplicationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (domainWhitelist) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_domainWhitelist_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydomainWhitelist);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (isServiceCloudConsole) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_isServiceCloudConsole_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisServiceCloudConsole);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (isServiceCloudConsoleSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_isServiceCloudConsoleSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisServiceCloudConsoleSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomApplication) => Property (listPlacement) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_listPlacement_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylistPlacement);
            Action currentAction = () => propertyInfo.SetValue(_customApplicationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (listPlacement) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_listPlacement_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylistPlacement);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (listRefreshMethod) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_listRefreshMethod_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylistRefreshMethod);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (logo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_logo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylogo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (tab) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_tab_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytab);
            Action currentAction = () => propertyInfo.SetValue(_customApplicationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (tab) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_tab_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytab);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (workspaceMappings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_workspaceMappings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyworkspaceMappings);
            Action currentAction = () => propertyInfo.SetValue(_customApplicationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplication) => Property (workspaceMappings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplication_Public_Class_workspaceMappings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyworkspaceMappings);

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