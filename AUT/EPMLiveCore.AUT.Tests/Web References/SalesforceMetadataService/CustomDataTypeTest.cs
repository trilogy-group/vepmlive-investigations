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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomDataType" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomDataTypeTest : AbstractBaseSetupTypedTest<CustomDataType>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomDataType) Initializer

        private const string PropertycustomDataTypeComponents = "customDataTypeComponents";
        private const string Propertydescription = "description";
        private const string PropertydisplayFormula = "displayFormula";
        private const string PropertyeditComponentsOnSeparateLines = "editComponentsOnSeparateLines";
        private const string PropertyeditComponentsOnSeparateLinesSpecified = "editComponentsOnSeparateLinesSpecified";
        private const string Propertylabel = "label";
        private const string PropertyrightAligned = "rightAligned";
        private const string PropertyrightAlignedSpecified = "rightAlignedSpecified";
        private const string PropertysupportComponentsInReports = "supportComponentsInReports";
        private const string PropertysupportComponentsInReportsSpecified = "supportComponentsInReportsSpecified";
        private const string FieldcustomDataTypeComponentsField = "customDataTypeComponentsField";
        private const string FielddescriptionField = "descriptionField";
        private const string FielddisplayFormulaField = "displayFormulaField";
        private const string FieldeditComponentsOnSeparateLinesField = "editComponentsOnSeparateLinesField";
        private const string FieldeditComponentsOnSeparateLinesFieldSpecified = "editComponentsOnSeparateLinesFieldSpecified";
        private const string FieldlabelField = "labelField";
        private const string FieldrightAlignedField = "rightAlignedField";
        private const string FieldrightAlignedFieldSpecified = "rightAlignedFieldSpecified";
        private const string FieldsupportComponentsInReportsField = "supportComponentsInReportsField";
        private const string FieldsupportComponentsInReportsFieldSpecified = "supportComponentsInReportsFieldSpecified";
        private Type _customDataTypeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomDataType _customDataTypeInstance;
        private CustomDataType _customDataTypeInstanceFixture;

        #region General Initializer : Class (CustomDataType) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomDataType" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customDataTypeInstanceType = typeof(CustomDataType);
            _customDataTypeInstanceFixture = Create(true);
            _customDataTypeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomDataType)

        #region General Initializer : Class (CustomDataType) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomDataType" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycustomDataTypeComponents)]
        [TestCase(Propertydescription)]
        [TestCase(PropertydisplayFormula)]
        [TestCase(PropertyeditComponentsOnSeparateLines)]
        [TestCase(PropertyeditComponentsOnSeparateLinesSpecified)]
        [TestCase(Propertylabel)]
        [TestCase(PropertyrightAligned)]
        [TestCase(PropertyrightAlignedSpecified)]
        [TestCase(PropertysupportComponentsInReports)]
        [TestCase(PropertysupportComponentsInReportsSpecified)]
        public void AUT_CustomDataType_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customDataTypeInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomDataType) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomDataType" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomDataTypeComponentsField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FielddisplayFormulaField)]
        [TestCase(FieldeditComponentsOnSeparateLinesField)]
        [TestCase(FieldeditComponentsOnSeparateLinesFieldSpecified)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldrightAlignedField)]
        [TestCase(FieldrightAlignedFieldSpecified)]
        [TestCase(FieldsupportComponentsInReportsField)]
        [TestCase(FieldsupportComponentsInReportsFieldSpecified)]
        public void AUT_CustomDataType_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customDataTypeInstanceFixture, 
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
        ///     Class (<see cref="CustomDataType" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomDataType_Is_Instance_Present_Test()
        {
            // Assert
            _customDataTypeInstanceType.ShouldNotBeNull();
            _customDataTypeInstance.ShouldNotBeNull();
            _customDataTypeInstanceFixture.ShouldNotBeNull();
            _customDataTypeInstance.ShouldBeAssignableTo<CustomDataType>();
            _customDataTypeInstanceFixture.ShouldBeAssignableTo<CustomDataType>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomDataType) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomDataType_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomDataType instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customDataTypeInstanceType.ShouldNotBeNull();
            _customDataTypeInstance.ShouldNotBeNull();
            _customDataTypeInstanceFixture.ShouldNotBeNull();
            _customDataTypeInstance.ShouldBeAssignableTo<CustomDataType>();
            _customDataTypeInstanceFixture.ShouldBeAssignableTo<CustomDataType>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomDataType) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CustomDataTypeComponent[]) , PropertycustomDataTypeComponents)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertydisplayFormula)]
        [TestCaseGeneric(typeof(bool) , PropertyeditComponentsOnSeparateLines)]
        [TestCaseGeneric(typeof(bool) , PropertyeditComponentsOnSeparateLinesSpecified)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(bool) , PropertyrightAligned)]
        [TestCaseGeneric(typeof(bool) , PropertyrightAlignedSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertysupportComponentsInReports)]
        [TestCaseGeneric(typeof(bool) , PropertysupportComponentsInReportsSpecified)]
        public void AUT_CustomDataType_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomDataType, T>(_customDataTypeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataType) => Property (customDataTypeComponents) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_customDataTypeComponents_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomDataTypeComponents);
            Action currentAction = () => propertyInfo.SetValue(_customDataTypeInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataType) => Property (customDataTypeComponents) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_Public_Class_customDataTypeComponents_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomDataTypeComponents);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataType) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomDataType) => Property (displayFormula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_Public_Class_displayFormula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayFormula);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataType) => Property (editComponentsOnSeparateLines) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_Public_Class_editComponentsOnSeparateLines_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyeditComponentsOnSeparateLines);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataType) => Property (editComponentsOnSeparateLinesSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_Public_Class_editComponentsOnSeparateLinesSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyeditComponentsOnSeparateLinesSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataType) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomDataType) => Property (rightAligned) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_Public_Class_rightAligned_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrightAligned);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataType) => Property (rightAlignedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_Public_Class_rightAlignedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrightAlignedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataType) => Property (supportComponentsInReports) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_Public_Class_supportComponentsInReports_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysupportComponentsInReports);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataType) => Property (supportComponentsInReportsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataType_Public_Class_supportComponentsInReportsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysupportComponentsInReportsSpecified);

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