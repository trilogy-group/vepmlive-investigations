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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomDataTypeComponent" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomDataTypeComponentTest : AbstractBaseSetupTypedTest<CustomDataTypeComponent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomDataTypeComponent) Initializer

        private const string PropertydeveloperSuffix = "developerSuffix";
        private const string PropertyenforceFieldRequiredness = "enforceFieldRequiredness";
        private const string PropertyenforceFieldRequirednessSpecified = "enforceFieldRequirednessSpecified";
        private const string Propertylabel = "label";
        private const string Propertylength = "length";
        private const string PropertylengthSpecified = "lengthSpecified";
        private const string Propertyprecision = "precision";
        private const string PropertyprecisionSpecified = "precisionSpecified";
        private const string Propertyscale = "scale";
        private const string PropertyscaleSpecified = "scaleSpecified";
        private const string PropertysortOrder = "sortOrder";
        private const string PropertysortOrderSpecified = "sortOrderSpecified";
        private const string PropertysortPriority = "sortPriority";
        private const string PropertysortPrioritySpecified = "sortPrioritySpecified";
        private const string Propertytype = "type";
        private const string FielddeveloperSuffixField = "developerSuffixField";
        private const string FieldenforceFieldRequirednessField = "enforceFieldRequirednessField";
        private const string FieldenforceFieldRequirednessFieldSpecified = "enforceFieldRequirednessFieldSpecified";
        private const string FieldlabelField = "labelField";
        private const string FieldlengthField = "lengthField";
        private const string FieldlengthFieldSpecified = "lengthFieldSpecified";
        private const string FieldprecisionField = "precisionField";
        private const string FieldprecisionFieldSpecified = "precisionFieldSpecified";
        private const string FieldscaleField = "scaleField";
        private const string FieldscaleFieldSpecified = "scaleFieldSpecified";
        private const string FieldsortOrderField = "sortOrderField";
        private const string FieldsortOrderFieldSpecified = "sortOrderFieldSpecified";
        private const string FieldsortPriorityField = "sortPriorityField";
        private const string FieldsortPriorityFieldSpecified = "sortPriorityFieldSpecified";
        private const string FieldtypeField = "typeField";
        private Type _customDataTypeComponentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomDataTypeComponent _customDataTypeComponentInstance;
        private CustomDataTypeComponent _customDataTypeComponentInstanceFixture;

        #region General Initializer : Class (CustomDataTypeComponent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomDataTypeComponent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customDataTypeComponentInstanceType = typeof(CustomDataTypeComponent);
            _customDataTypeComponentInstanceFixture = Create(true);
            _customDataTypeComponentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomDataTypeComponent)

        #region General Initializer : Class (CustomDataTypeComponent) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomDataTypeComponent" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydeveloperSuffix)]
        [TestCase(PropertyenforceFieldRequiredness)]
        [TestCase(PropertyenforceFieldRequirednessSpecified)]
        [TestCase(Propertylabel)]
        [TestCase(Propertylength)]
        [TestCase(PropertylengthSpecified)]
        [TestCase(Propertyprecision)]
        [TestCase(PropertyprecisionSpecified)]
        [TestCase(Propertyscale)]
        [TestCase(PropertyscaleSpecified)]
        [TestCase(PropertysortOrder)]
        [TestCase(PropertysortOrderSpecified)]
        [TestCase(PropertysortPriority)]
        [TestCase(PropertysortPrioritySpecified)]
        [TestCase(Propertytype)]
        public void AUT_CustomDataTypeComponent_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customDataTypeComponentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomDataTypeComponent) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomDataTypeComponent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddeveloperSuffixField)]
        [TestCase(FieldenforceFieldRequirednessField)]
        [TestCase(FieldenforceFieldRequirednessFieldSpecified)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlengthField)]
        [TestCase(FieldlengthFieldSpecified)]
        [TestCase(FieldprecisionField)]
        [TestCase(FieldprecisionFieldSpecified)]
        [TestCase(FieldscaleField)]
        [TestCase(FieldscaleFieldSpecified)]
        [TestCase(FieldsortOrderField)]
        [TestCase(FieldsortOrderFieldSpecified)]
        [TestCase(FieldsortPriorityField)]
        [TestCase(FieldsortPriorityFieldSpecified)]
        [TestCase(FieldtypeField)]
        public void AUT_CustomDataTypeComponent_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customDataTypeComponentInstanceFixture, 
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
        ///     Class (<see cref="CustomDataTypeComponent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomDataTypeComponent_Is_Instance_Present_Test()
        {
            // Assert
            _customDataTypeComponentInstanceType.ShouldNotBeNull();
            _customDataTypeComponentInstance.ShouldNotBeNull();
            _customDataTypeComponentInstanceFixture.ShouldNotBeNull();
            _customDataTypeComponentInstance.ShouldBeAssignableTo<CustomDataTypeComponent>();
            _customDataTypeComponentInstanceFixture.ShouldBeAssignableTo<CustomDataTypeComponent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomDataTypeComponent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomDataTypeComponent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomDataTypeComponent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customDataTypeComponentInstanceType.ShouldNotBeNull();
            _customDataTypeComponentInstance.ShouldNotBeNull();
            _customDataTypeComponentInstanceFixture.ShouldNotBeNull();
            _customDataTypeComponentInstance.ShouldBeAssignableTo<CustomDataTypeComponent>();
            _customDataTypeComponentInstanceFixture.ShouldBeAssignableTo<CustomDataTypeComponent>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomDataTypeComponent) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertydeveloperSuffix)]
        [TestCaseGeneric(typeof(bool) , PropertyenforceFieldRequiredness)]
        [TestCaseGeneric(typeof(bool) , PropertyenforceFieldRequirednessSpecified)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(int) , Propertylength)]
        [TestCaseGeneric(typeof(bool) , PropertylengthSpecified)]
        [TestCaseGeneric(typeof(int) , Propertyprecision)]
        [TestCaseGeneric(typeof(bool) , PropertyprecisionSpecified)]
        [TestCaseGeneric(typeof(int) , Propertyscale)]
        [TestCaseGeneric(typeof(bool) , PropertyscaleSpecified)]
        [TestCaseGeneric(typeof(SortOrder) , PropertysortOrder)]
        [TestCaseGeneric(typeof(bool) , PropertysortOrderSpecified)]
        [TestCaseGeneric(typeof(int) , PropertysortPriority)]
        [TestCaseGeneric(typeof(bool) , PropertysortPrioritySpecified)]
        [TestCaseGeneric(typeof(FieldType) , Propertytype)]
        public void AUT_CustomDataTypeComponent_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomDataTypeComponent, T>(_customDataTypeComponentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (developerSuffix) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_developerSuffix_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeveloperSuffix);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (enforceFieldRequiredness) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_enforceFieldRequiredness_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenforceFieldRequiredness);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (enforceFieldRequirednessSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_enforceFieldRequirednessSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenforceFieldRequirednessSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (length) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_length_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylength);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (lengthSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_lengthSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylengthSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (precision) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_precision_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyprecision);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (precisionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_precisionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyprecisionSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (scale) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_scale_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyscale);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (scaleSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_scaleSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyscaleSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (sortOrder) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_sortOrder_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysortOrder);
            Action currentAction = () => propertyInfo.SetValue(_customDataTypeComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (sortOrder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_sortOrder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortOrder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (sortOrderSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_sortOrderSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortOrderSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (sortPriority) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_sortPriority_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortPriority);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (sortPrioritySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_sortPrioritySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortPrioritySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytype);
            Action currentAction = () => propertyInfo.SetValue(_customDataTypeComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeComponent) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeComponent_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

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