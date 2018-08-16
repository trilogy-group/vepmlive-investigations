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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CallCenter" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CallCenterTest : AbstractBaseSetupTypedTest<CallCenter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CallCenter) Initializer

        private const string PropertyadapterUrl = "adapterUrl";
        private const string PropertycustomSettings = "customSettings";
        private const string PropertydisplayName = "displayName";
        private const string PropertydisplayNameLabel = "displayNameLabel";
        private const string PropertyinternalNameLabel = "internalNameLabel";
        private const string Propertysections = "sections";
        private const string Propertyversion = "version";
        private const string FieldadapterUrlField = "adapterUrlField";
        private const string FieldcustomSettingsField = "customSettingsField";
        private const string FielddisplayNameField = "displayNameField";
        private const string FielddisplayNameLabelField = "displayNameLabelField";
        private const string FieldinternalNameLabelField = "internalNameLabelField";
        private const string FieldsectionsField = "sectionsField";
        private const string FieldversionField = "versionField";
        private Type _callCenterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CallCenter _callCenterInstance;
        private CallCenter _callCenterInstanceFixture;

        #region General Initializer : Class (CallCenter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CallCenter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _callCenterInstanceType = typeof(CallCenter);
            _callCenterInstanceFixture = Create(true);
            _callCenterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CallCenter)

        #region General Initializer : Class (CallCenter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CallCenter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyadapterUrl)]
        [TestCase(PropertycustomSettings)]
        [TestCase(PropertydisplayName)]
        [TestCase(PropertydisplayNameLabel)]
        [TestCase(PropertyinternalNameLabel)]
        [TestCase(Propertysections)]
        [TestCase(Propertyversion)]
        public void AUT_CallCenter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_callCenterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CallCenter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CallCenter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldadapterUrlField)]
        [TestCase(FieldcustomSettingsField)]
        [TestCase(FielddisplayNameField)]
        [TestCase(FielddisplayNameLabelField)]
        [TestCase(FieldinternalNameLabelField)]
        [TestCase(FieldsectionsField)]
        [TestCase(FieldversionField)]
        public void AUT_CallCenter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_callCenterInstanceFixture, 
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
        ///     Class (<see cref="CallCenter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CallCenter_Is_Instance_Present_Test()
        {
            // Assert
            _callCenterInstanceType.ShouldNotBeNull();
            _callCenterInstance.ShouldNotBeNull();
            _callCenterInstanceFixture.ShouldNotBeNull();
            _callCenterInstance.ShouldBeAssignableTo<CallCenter>();
            _callCenterInstanceFixture.ShouldBeAssignableTo<CallCenter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CallCenter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CallCenter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CallCenter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _callCenterInstanceType.ShouldNotBeNull();
            _callCenterInstance.ShouldNotBeNull();
            _callCenterInstanceFixture.ShouldNotBeNull();
            _callCenterInstance.ShouldBeAssignableTo<CallCenter>();
            _callCenterInstanceFixture.ShouldBeAssignableTo<CallCenter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CallCenter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyadapterUrl)]
        [TestCaseGeneric(typeof(string) , PropertycustomSettings)]
        [TestCaseGeneric(typeof(string) , PropertydisplayName)]
        [TestCaseGeneric(typeof(string) , PropertydisplayNameLabel)]
        [TestCaseGeneric(typeof(string) , PropertyinternalNameLabel)]
        [TestCaseGeneric(typeof(CallCenterSection[]) , Propertysections)]
        [TestCaseGeneric(typeof(string) , Propertyversion)]
        public void AUT_CallCenter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CallCenter, T>(_callCenterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CallCenter) => Property (adapterUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenter_Public_Class_adapterUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyadapterUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CallCenter) => Property (customSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenter_Public_Class_customSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomSettings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CallCenter) => Property (displayName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenter_Public_Class_displayName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CallCenter) => Property (displayNameLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenter_Public_Class_displayNameLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayNameLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CallCenter) => Property (internalNameLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenter_Public_Class_internalNameLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinternalNameLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CallCenter) => Property (sections) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenter_sections_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysections);
            Action currentAction = () => propertyInfo.SetValue(_callCenterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CallCenter) => Property (sections) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenter_Public_Class_sections_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysections);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CallCenter) => Property (version) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CallCenter_Public_Class_version_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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