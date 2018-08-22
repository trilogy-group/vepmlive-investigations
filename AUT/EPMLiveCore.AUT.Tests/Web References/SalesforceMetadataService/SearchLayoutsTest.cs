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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SearchLayouts" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SearchLayoutsTest : AbstractBaseSetupTypedTest<SearchLayouts>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SearchLayouts) Initializer

        private const string PropertycustomTabListAdditionalFields = "customTabListAdditionalFields";
        private const string PropertyexcludedStandardButtons = "excludedStandardButtons";
        private const string PropertylistViewButtons = "listViewButtons";
        private const string PropertylookupDialogsAdditionalFields = "lookupDialogsAdditionalFields";
        private const string PropertylookupFilterFields = "lookupFilterFields";
        private const string PropertylookupPhoneDialogsAdditionalFields = "lookupPhoneDialogsAdditionalFields";
        private const string PropertysearchFilterFields = "searchFilterFields";
        private const string PropertysearchResultsAdditionalFields = "searchResultsAdditionalFields";
        private const string PropertysearchResultsCustomButtons = "searchResultsCustomButtons";
        private const string FieldcustomTabListAdditionalFieldsField = "customTabListAdditionalFieldsField";
        private const string FieldexcludedStandardButtonsField = "excludedStandardButtonsField";
        private const string FieldlistViewButtonsField = "listViewButtonsField";
        private const string FieldlookupDialogsAdditionalFieldsField = "lookupDialogsAdditionalFieldsField";
        private const string FieldlookupFilterFieldsField = "lookupFilterFieldsField";
        private const string FieldlookupPhoneDialogsAdditionalFieldsField = "lookupPhoneDialogsAdditionalFieldsField";
        private const string FieldsearchFilterFieldsField = "searchFilterFieldsField";
        private const string FieldsearchResultsAdditionalFieldsField = "searchResultsAdditionalFieldsField";
        private const string FieldsearchResultsCustomButtonsField = "searchResultsCustomButtonsField";
        private Type _searchLayoutsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SearchLayouts _searchLayoutsInstance;
        private SearchLayouts _searchLayoutsInstanceFixture;

        #region General Initializer : Class (SearchLayouts) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SearchLayouts" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _searchLayoutsInstanceType = typeof(SearchLayouts);
            _searchLayoutsInstanceFixture = Create(true);
            _searchLayoutsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SearchLayouts)

        #region General Initializer : Class (SearchLayouts) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SearchLayouts" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycustomTabListAdditionalFields)]
        [TestCase(PropertyexcludedStandardButtons)]
        [TestCase(PropertylistViewButtons)]
        [TestCase(PropertylookupDialogsAdditionalFields)]
        [TestCase(PropertylookupFilterFields)]
        [TestCase(PropertylookupPhoneDialogsAdditionalFields)]
        [TestCase(PropertysearchFilterFields)]
        [TestCase(PropertysearchResultsAdditionalFields)]
        [TestCase(PropertysearchResultsCustomButtons)]
        public void AUT_SearchLayouts_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_searchLayoutsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SearchLayouts) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SearchLayouts" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomTabListAdditionalFieldsField)]
        [TestCase(FieldexcludedStandardButtonsField)]
        [TestCase(FieldlistViewButtonsField)]
        [TestCase(FieldlookupDialogsAdditionalFieldsField)]
        [TestCase(FieldlookupFilterFieldsField)]
        [TestCase(FieldlookupPhoneDialogsAdditionalFieldsField)]
        [TestCase(FieldsearchFilterFieldsField)]
        [TestCase(FieldsearchResultsAdditionalFieldsField)]
        [TestCase(FieldsearchResultsCustomButtonsField)]
        public void AUT_SearchLayouts_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_searchLayoutsInstanceFixture, 
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
        ///     Class (<see cref="SearchLayouts" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SearchLayouts_Is_Instance_Present_Test()
        {
            // Assert
            _searchLayoutsInstanceType.ShouldNotBeNull();
            _searchLayoutsInstance.ShouldNotBeNull();
            _searchLayoutsInstanceFixture.ShouldNotBeNull();
            _searchLayoutsInstance.ShouldBeAssignableTo<SearchLayouts>();
            _searchLayoutsInstanceFixture.ShouldBeAssignableTo<SearchLayouts>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SearchLayouts) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SearchLayouts_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SearchLayouts instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _searchLayoutsInstanceType.ShouldNotBeNull();
            _searchLayoutsInstance.ShouldNotBeNull();
            _searchLayoutsInstanceFixture.ShouldNotBeNull();
            _searchLayoutsInstance.ShouldBeAssignableTo<SearchLayouts>();
            _searchLayoutsInstanceFixture.ShouldBeAssignableTo<SearchLayouts>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SearchLayouts) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , PropertycustomTabListAdditionalFields)]
        [TestCaseGeneric(typeof(string[]) , PropertyexcludedStandardButtons)]
        [TestCaseGeneric(typeof(string[]) , PropertylistViewButtons)]
        [TestCaseGeneric(typeof(string[]) , PropertylookupDialogsAdditionalFields)]
        [TestCaseGeneric(typeof(string[]) , PropertylookupFilterFields)]
        [TestCaseGeneric(typeof(string[]) , PropertylookupPhoneDialogsAdditionalFields)]
        [TestCaseGeneric(typeof(string[]) , PropertysearchFilterFields)]
        [TestCaseGeneric(typeof(string[]) , PropertysearchResultsAdditionalFields)]
        [TestCaseGeneric(typeof(string[]) , PropertysearchResultsCustomButtons)]
        public void AUT_SearchLayouts_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SearchLayouts, T>(_searchLayoutsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (customTabListAdditionalFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_customTabListAdditionalFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomTabListAdditionalFields);
            Action currentAction = () => propertyInfo.SetValue(_searchLayoutsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (customTabListAdditionalFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_Public_Class_customTabListAdditionalFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomTabListAdditionalFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (excludedStandardButtons) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_excludedStandardButtons_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyexcludedStandardButtons);
            Action currentAction = () => propertyInfo.SetValue(_searchLayoutsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (excludedStandardButtons) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_Public_Class_excludedStandardButtons_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexcludedStandardButtons);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (listViewButtons) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_listViewButtons_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylistViewButtons);
            Action currentAction = () => propertyInfo.SetValue(_searchLayoutsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (listViewButtons) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_Public_Class_listViewButtons_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylistViewButtons);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (lookupDialogsAdditionalFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_lookupDialogsAdditionalFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylookupDialogsAdditionalFields);
            Action currentAction = () => propertyInfo.SetValue(_searchLayoutsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (lookupDialogsAdditionalFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_Public_Class_lookupDialogsAdditionalFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylookupDialogsAdditionalFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (lookupFilterFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_lookupFilterFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylookupFilterFields);
            Action currentAction = () => propertyInfo.SetValue(_searchLayoutsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (lookupFilterFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_Public_Class_lookupFilterFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylookupFilterFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (lookupPhoneDialogsAdditionalFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_lookupPhoneDialogsAdditionalFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylookupPhoneDialogsAdditionalFields);
            Action currentAction = () => propertyInfo.SetValue(_searchLayoutsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (lookupPhoneDialogsAdditionalFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_Public_Class_lookupPhoneDialogsAdditionalFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylookupPhoneDialogsAdditionalFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (searchFilterFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_searchFilterFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysearchFilterFields);
            Action currentAction = () => propertyInfo.SetValue(_searchLayoutsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (searchFilterFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_Public_Class_searchFilterFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysearchFilterFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (searchResultsAdditionalFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_searchResultsAdditionalFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysearchResultsAdditionalFields);
            Action currentAction = () => propertyInfo.SetValue(_searchLayoutsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (searchResultsAdditionalFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_Public_Class_searchResultsAdditionalFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysearchResultsAdditionalFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (searchResultsCustomButtons) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_searchResultsCustomButtons_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysearchResultsCustomButtons);
            Action currentAction = () => propertyInfo.SetValue(_searchLayoutsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchLayouts) => Property (searchResultsCustomButtons) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchLayouts_Public_Class_searchResultsCustomButtons_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysearchResultsCustomButtons);

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