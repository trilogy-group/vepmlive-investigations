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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FilterItem" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FilterItemTest : AbstractBaseSetupTypedTest<FilterItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FilterItem) Initializer

        private const string Propertyfield = "field";
        private const string Propertyoperation = "operation";
        private const string Propertyvalue = "value";
        private const string PropertyvalueField = "valueField";
        private const string FieldfieldField = "fieldField";
        private const string FieldoperationField = "operationField";
        private const string FieldvalueField1 = "valueField1";
        private const string FieldvalueFieldField = "valueFieldField";
        private Type _filterItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FilterItem _filterItemInstance;
        private FilterItem _filterItemInstanceFixture;

        #region General Initializer : Class (FilterItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FilterItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _filterItemInstanceType = typeof(FilterItem);
            _filterItemInstanceFixture = Create(true);
            _filterItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FilterItem)

        #region General Initializer : Class (FilterItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FilterItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyfield)]
        [TestCase(Propertyoperation)]
        [TestCase(Propertyvalue)]
        [TestCase(PropertyvalueField)]
        public void AUT_FilterItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_filterItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FilterItem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FilterItem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfieldField)]
        [TestCase(FieldoperationField)]
        [TestCase(FieldvalueField1)]
        [TestCase(FieldvalueFieldField)]
        public void AUT_FilterItem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_filterItemInstanceFixture, 
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
        ///     Class (<see cref="FilterItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FilterItem_Is_Instance_Present_Test()
        {
            // Assert
            _filterItemInstanceType.ShouldNotBeNull();
            _filterItemInstance.ShouldNotBeNull();
            _filterItemInstanceFixture.ShouldNotBeNull();
            _filterItemInstance.ShouldBeAssignableTo<FilterItem>();
            _filterItemInstanceFixture.ShouldBeAssignableTo<FilterItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FilterItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FilterItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FilterItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _filterItemInstanceType.ShouldNotBeNull();
            _filterItemInstance.ShouldNotBeNull();
            _filterItemInstanceFixture.ShouldNotBeNull();
            _filterItemInstance.ShouldBeAssignableTo<FilterItem>();
            _filterItemInstanceFixture.ShouldBeAssignableTo<FilterItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FilterItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(FilterOperation) , Propertyoperation)]
        [TestCaseGeneric(typeof(string) , Propertyvalue)]
        [TestCaseGeneric(typeof(string) , PropertyvalueField)]
        public void AUT_FilterItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FilterItem, T>(_filterItemInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FilterItem) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FilterItem_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilterItem) => Property (operation) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FilterItem_operation_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyoperation);
            Action currentAction = () => propertyInfo.SetValue(_filterItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FilterItem) => Property (operation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FilterItem_Public_Class_operation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyoperation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilterItem) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FilterItem_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FilterItem) => Property (valueField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FilterItem_Public_Class_valueField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyvalueField);

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