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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DataCategoryGroup" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DataCategoryGroupTest : AbstractBaseSetupTypedTest<DataCategoryGroup>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataCategoryGroup) Initializer

        private const string Propertyactive = "active";
        private const string PropertydataCategory = "dataCategory";
        private const string Propertydescription = "description";
        private const string Propertylabel = "label";
        private const string PropertyobjectUsage = "objectUsage";
        private const string FieldactiveField = "activeField";
        private const string FielddataCategoryField = "dataCategoryField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldlabelField = "labelField";
        private const string FieldobjectUsageField = "objectUsageField";
        private Type _dataCategoryGroupInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataCategoryGroup _dataCategoryGroupInstance;
        private DataCategoryGroup _dataCategoryGroupInstanceFixture;

        #region General Initializer : Class (DataCategoryGroup) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataCategoryGroup" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataCategoryGroupInstanceType = typeof(DataCategoryGroup);
            _dataCategoryGroupInstanceFixture = Create(true);
            _dataCategoryGroupInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataCategoryGroup)

        #region General Initializer : Class (DataCategoryGroup) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DataCategoryGroup" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactive)]
        [TestCase(PropertydataCategory)]
        [TestCase(Propertydescription)]
        [TestCase(Propertylabel)]
        [TestCase(PropertyobjectUsage)]
        public void AUT_DataCategoryGroup_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dataCategoryGroupInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataCategoryGroup) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataCategoryGroup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactiveField)]
        [TestCase(FielddataCategoryField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldobjectUsageField)]
        public void AUT_DataCategoryGroup_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataCategoryGroupInstanceFixture, 
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
        ///     Class (<see cref="DataCategoryGroup" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DataCategoryGroup_Is_Instance_Present_Test()
        {
            // Assert
            _dataCategoryGroupInstanceType.ShouldNotBeNull();
            _dataCategoryGroupInstance.ShouldNotBeNull();
            _dataCategoryGroupInstanceFixture.ShouldNotBeNull();
            _dataCategoryGroupInstance.ShouldBeAssignableTo<DataCategoryGroup>();
            _dataCategoryGroupInstanceFixture.ShouldBeAssignableTo<DataCategoryGroup>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataCategoryGroup) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DataCategoryGroup_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataCategoryGroup instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataCategoryGroupInstanceType.ShouldNotBeNull();
            _dataCategoryGroupInstance.ShouldNotBeNull();
            _dataCategoryGroupInstanceFixture.ShouldNotBeNull();
            _dataCategoryGroupInstance.ShouldBeAssignableTo<DataCategoryGroup>();
            _dataCategoryGroupInstanceFixture.ShouldBeAssignableTo<DataCategoryGroup>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DataCategoryGroup) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactive)]
        [TestCaseGeneric(typeof(DataCategory) , PropertydataCategory)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string[]) , PropertyobjectUsage)]
        public void AUT_DataCategoryGroup_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DataCategoryGroup, T>(_dataCategoryGroupInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DataCategoryGroup) => Property (active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataCategoryGroup_Public_Class_active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyactive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataCategoryGroup) => Property (dataCategory) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataCategoryGroup_dataCategory_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydataCategory);
            Action currentAction = () => propertyInfo.SetValue(_dataCategoryGroupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataCategoryGroup) => Property (dataCategory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataCategoryGroup_Public_Class_dataCategory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydataCategory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataCategoryGroup) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataCategoryGroup_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DataCategoryGroup) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataCategoryGroup_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DataCategoryGroup) => Property (objectUsage) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataCategoryGroup_objectUsage_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyobjectUsage);
            Action currentAction = () => propertyInfo.SetValue(_dataCategoryGroupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataCategoryGroup) => Property (objectUsage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataCategoryGroup_Public_Class_objectUsage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyobjectUsage);

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