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

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.DataSetDefinition" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DataSetDefinitionTest : AbstractBaseSetupTypedTest<DataSetDefinition>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataSetDefinition) Initializer

        private const string PropertyFields = "Fields";
        private const string PropertyQuery = "Query";
        private const string PropertyCaseSensitivity = "CaseSensitivity";
        private const string PropertyCaseSensitivitySpecified = "CaseSensitivitySpecified";
        private const string PropertyCollation = "Collation";
        private const string PropertyAccentSensitivity = "AccentSensitivity";
        private const string PropertyAccentSensitivitySpecified = "AccentSensitivitySpecified";
        private const string PropertyKanatypeSensitivity = "KanatypeSensitivity";
        private const string PropertyKanatypeSensitivitySpecified = "KanatypeSensitivitySpecified";
        private const string PropertyWidthSensitivity = "WidthSensitivity";
        private const string PropertyWidthSensitivitySpecified = "WidthSensitivitySpecified";
        private const string PropertyName = "Name";
        private const string FieldfieldsField = "fieldsField";
        private const string FieldqueryField = "queryField";
        private const string FieldcaseSensitivityField = "caseSensitivityField";
        private const string FieldcaseSensitivityFieldSpecified = "caseSensitivityFieldSpecified";
        private const string FieldcollationField = "collationField";
        private const string FieldaccentSensitivityField = "accentSensitivityField";
        private const string FieldaccentSensitivityFieldSpecified = "accentSensitivityFieldSpecified";
        private const string FieldkanatypeSensitivityField = "kanatypeSensitivityField";
        private const string FieldkanatypeSensitivityFieldSpecified = "kanatypeSensitivityFieldSpecified";
        private const string FieldwidthSensitivityField = "widthSensitivityField";
        private const string FieldwidthSensitivityFieldSpecified = "widthSensitivityFieldSpecified";
        private const string FieldnameField = "nameField";
        private Type _dataSetDefinitionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataSetDefinition _dataSetDefinitionInstance;
        private DataSetDefinition _dataSetDefinitionInstanceFixture;

        #region General Initializer : Class (DataSetDefinition) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataSetDefinition" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataSetDefinitionInstanceType = typeof(DataSetDefinition);
            _dataSetDefinitionInstanceFixture = Create(true);
            _dataSetDefinitionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataSetDefinition)

        #region General Initializer : Class (DataSetDefinition) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSetDefinition" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyFields)]
        [TestCase(PropertyQuery)]
        [TestCase(PropertyCaseSensitivity)]
        [TestCase(PropertyCaseSensitivitySpecified)]
        [TestCase(PropertyCollation)]
        [TestCase(PropertyAccentSensitivity)]
        [TestCase(PropertyAccentSensitivitySpecified)]
        [TestCase(PropertyKanatypeSensitivity)]
        [TestCase(PropertyKanatypeSensitivitySpecified)]
        [TestCase(PropertyWidthSensitivity)]
        [TestCase(PropertyWidthSensitivitySpecified)]
        [TestCase(PropertyName)]
        public void AUT_DataSetDefinition_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dataSetDefinitionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataSetDefinition) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSetDefinition" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfieldsField)]
        [TestCase(FieldqueryField)]
        [TestCase(FieldcaseSensitivityField)]
        [TestCase(FieldcaseSensitivityFieldSpecified)]
        [TestCase(FieldcollationField)]
        [TestCase(FieldaccentSensitivityField)]
        [TestCase(FieldaccentSensitivityFieldSpecified)]
        [TestCase(FieldkanatypeSensitivityField)]
        [TestCase(FieldkanatypeSensitivityFieldSpecified)]
        [TestCase(FieldwidthSensitivityField)]
        [TestCase(FieldwidthSensitivityFieldSpecified)]
        [TestCase(FieldnameField)]
        public void AUT_DataSetDefinition_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataSetDefinitionInstanceFixture, 
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
        ///     Class (<see cref="DataSetDefinition" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DataSetDefinition_Is_Instance_Present_Test()
        {
            // Assert
            _dataSetDefinitionInstanceType.ShouldNotBeNull();
            _dataSetDefinitionInstance.ShouldNotBeNull();
            _dataSetDefinitionInstanceFixture.ShouldNotBeNull();
            _dataSetDefinitionInstance.ShouldBeAssignableTo<DataSetDefinition>();
            _dataSetDefinitionInstanceFixture.ShouldBeAssignableTo<DataSetDefinition>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataSetDefinition) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DataSetDefinition_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataSetDefinition instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataSetDefinitionInstanceType.ShouldNotBeNull();
            _dataSetDefinitionInstance.ShouldNotBeNull();
            _dataSetDefinitionInstanceFixture.ShouldNotBeNull();
            _dataSetDefinitionInstance.ShouldBeAssignableTo<DataSetDefinition>();
            _dataSetDefinitionInstanceFixture.ShouldBeAssignableTo<DataSetDefinition>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DataSetDefinition) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Field[]) , PropertyFields)]
        [TestCaseGeneric(typeof(QueryDefinition) , PropertyQuery)]
        [TestCaseGeneric(typeof(SensitivityEnum) , PropertyCaseSensitivity)]
        [TestCaseGeneric(typeof(bool) , PropertyCaseSensitivitySpecified)]
        [TestCaseGeneric(typeof(string) , PropertyCollation)]
        [TestCaseGeneric(typeof(SensitivityEnum) , PropertyAccentSensitivity)]
        [TestCaseGeneric(typeof(bool) , PropertyAccentSensitivitySpecified)]
        [TestCaseGeneric(typeof(SensitivityEnum) , PropertyKanatypeSensitivity)]
        [TestCaseGeneric(typeof(bool) , PropertyKanatypeSensitivitySpecified)]
        [TestCaseGeneric(typeof(SensitivityEnum) , PropertyWidthSensitivity)]
        [TestCaseGeneric(typeof(bool) , PropertyWidthSensitivitySpecified)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        public void AUT_DataSetDefinition_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DataSetDefinition, T>(_dataSetDefinitionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (AccentSensitivity) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_AccentSensitivity_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyAccentSensitivity);
            Action currentAction = () => propertyInfo.SetValue(_dataSetDefinitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (AccentSensitivity) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_AccentSensitivity_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAccentSensitivity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (AccentSensitivitySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_AccentSensitivitySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAccentSensitivitySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (CaseSensitivity) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_CaseSensitivity_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCaseSensitivity);
            Action currentAction = () => propertyInfo.SetValue(_dataSetDefinitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (CaseSensitivity) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_CaseSensitivity_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCaseSensitivity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (CaseSensitivitySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_CaseSensitivitySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCaseSensitivitySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (Collation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_Collation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCollation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (Fields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Fields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFields);
            Action currentAction = () => propertyInfo.SetValue(_dataSetDefinitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (Fields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_Fields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (KanatypeSensitivity) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_KanatypeSensitivity_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyKanatypeSensitivity);
            Action currentAction = () => propertyInfo.SetValue(_dataSetDefinitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (KanatypeSensitivity) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_KanatypeSensitivity_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyKanatypeSensitivity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (KanatypeSensitivitySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_KanatypeSensitivitySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyKanatypeSensitivitySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (Query) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Query_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyQuery);
            Action currentAction = () => propertyInfo.SetValue(_dataSetDefinitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (Query) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_Query_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyQuery);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (WidthSensitivity) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_WidthSensitivity_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWidthSensitivity);
            Action currentAction = () => propertyInfo.SetValue(_dataSetDefinitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (WidthSensitivity) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_WidthSensitivity_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWidthSensitivity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSetDefinition) => Property (WidthSensitivitySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSetDefinition_Public_Class_WidthSensitivitySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWidthSensitivitySpecified);

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