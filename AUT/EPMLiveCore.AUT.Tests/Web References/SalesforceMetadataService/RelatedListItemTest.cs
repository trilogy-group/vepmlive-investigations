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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.RelatedListItem" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RelatedListItemTest : AbstractBaseSetupTypedTest<RelatedListItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RelatedListItem) Initializer

        private const string PropertycustomButtons = "customButtons";
        private const string PropertyexcludeButtons = "excludeButtons";
        private const string Propertyfields = "fields";
        private const string PropertyrelatedList = "relatedList";
        private const string PropertysortField = "sortField";
        private const string PropertysortOrder = "sortOrder";
        private const string PropertysortOrderSpecified = "sortOrderSpecified";
        private const string FieldcustomButtonsField = "customButtonsField";
        private const string FieldexcludeButtonsField = "excludeButtonsField";
        private const string FieldfieldsField = "fieldsField";
        private const string FieldrelatedListField = "relatedListField";
        private const string FieldsortFieldField = "sortFieldField";
        private const string FieldsortOrderField = "sortOrderField";
        private const string FieldsortOrderFieldSpecified = "sortOrderFieldSpecified";
        private Type _relatedListItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RelatedListItem _relatedListItemInstance;
        private RelatedListItem _relatedListItemInstanceFixture;

        #region General Initializer : Class (RelatedListItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RelatedListItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _relatedListItemInstanceType = typeof(RelatedListItem);
            _relatedListItemInstanceFixture = Create(true);
            _relatedListItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RelatedListItem)

        #region General Initializer : Class (RelatedListItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RelatedListItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycustomButtons)]
        [TestCase(PropertyexcludeButtons)]
        [TestCase(Propertyfields)]
        [TestCase(PropertyrelatedList)]
        [TestCase(PropertysortField)]
        [TestCase(PropertysortOrder)]
        [TestCase(PropertysortOrderSpecified)]
        public void AUT_RelatedListItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_relatedListItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RelatedListItem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RelatedListItem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomButtonsField)]
        [TestCase(FieldexcludeButtonsField)]
        [TestCase(FieldfieldsField)]
        [TestCase(FieldrelatedListField)]
        [TestCase(FieldsortFieldField)]
        [TestCase(FieldsortOrderField)]
        [TestCase(FieldsortOrderFieldSpecified)]
        public void AUT_RelatedListItem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_relatedListItemInstanceFixture, 
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
        ///     Class (<see cref="RelatedListItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RelatedListItem_Is_Instance_Present_Test()
        {
            // Assert
            _relatedListItemInstanceType.ShouldNotBeNull();
            _relatedListItemInstance.ShouldNotBeNull();
            _relatedListItemInstanceFixture.ShouldNotBeNull();
            _relatedListItemInstance.ShouldBeAssignableTo<RelatedListItem>();
            _relatedListItemInstanceFixture.ShouldBeAssignableTo<RelatedListItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RelatedListItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RelatedListItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RelatedListItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _relatedListItemInstanceType.ShouldNotBeNull();
            _relatedListItemInstance.ShouldNotBeNull();
            _relatedListItemInstanceFixture.ShouldNotBeNull();
            _relatedListItemInstance.ShouldBeAssignableTo<RelatedListItem>();
            _relatedListItemInstanceFixture.ShouldBeAssignableTo<RelatedListItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RelatedListItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , PropertycustomButtons)]
        [TestCaseGeneric(typeof(string[]) , PropertyexcludeButtons)]
        [TestCaseGeneric(typeof(string[]) , Propertyfields)]
        [TestCaseGeneric(typeof(string) , PropertyrelatedList)]
        [TestCaseGeneric(typeof(string) , PropertysortField)]
        [TestCaseGeneric(typeof(SortOrder) , PropertysortOrder)]
        [TestCaseGeneric(typeof(bool) , PropertysortOrderSpecified)]
        public void AUT_RelatedListItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RelatedListItem, T>(_relatedListItemInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListItem) => Property (customButtons) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_customButtons_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomButtons);
            Action currentAction = () => propertyInfo.SetValue(_relatedListItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListItem) => Property (customButtons) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_Public_Class_customButtons_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomButtons);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListItem) => Property (excludeButtons) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_excludeButtons_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyexcludeButtons);
            Action currentAction = () => propertyInfo.SetValue(_relatedListItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListItem) => Property (excludeButtons) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_Public_Class_excludeButtons_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexcludeButtons);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListItem) => Property (fields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_fields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfields);
            Action currentAction = () => propertyInfo.SetValue(_relatedListItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListItem) => Property (fields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_Public_Class_fields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListItem) => Property (relatedList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_Public_Class_relatedList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelatedList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListItem) => Property (sortField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_Public_Class_sortField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListItem) => Property (sortOrder) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_sortOrder_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysortOrder);
            Action currentAction = () => propertyInfo.SetValue(_relatedListItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListItem) => Property (sortOrder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_Public_Class_sortOrder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RelatedListItem) => Property (sortOrderSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListItem_Public_Class_sortOrderSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}