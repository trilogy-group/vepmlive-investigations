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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportFilter" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportFilterTest : AbstractBaseSetupTypedTest<ReportFilter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportFilter) Initializer

        private const string PropertybooleanFilter = "booleanFilter";
        private const string PropertycriteriaItems = "criteriaItems";
        private const string Propertylanguage = "language";
        private const string PropertylanguageSpecified = "languageSpecified";
        private const string FieldbooleanFilterField = "booleanFilterField";
        private const string FieldcriteriaItemsField = "criteriaItemsField";
        private const string FieldlanguageField = "languageField";
        private const string FieldlanguageFieldSpecified = "languageFieldSpecified";
        private Type _reportFilterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportFilter _reportFilterInstance;
        private ReportFilter _reportFilterInstanceFixture;

        #region General Initializer : Class (ReportFilter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportFilter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportFilterInstanceType = typeof(ReportFilter);
            _reportFilterInstanceFixture = Create(true);
            _reportFilterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportFilter)

        #region General Initializer : Class (ReportFilter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportFilter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybooleanFilter)]
        [TestCase(PropertycriteriaItems)]
        [TestCase(Propertylanguage)]
        [TestCase(PropertylanguageSpecified)]
        public void AUT_ReportFilter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportFilterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportFilter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportFilter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbooleanFilterField)]
        [TestCase(FieldcriteriaItemsField)]
        [TestCase(FieldlanguageField)]
        [TestCase(FieldlanguageFieldSpecified)]
        public void AUT_ReportFilter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportFilterInstanceFixture, 
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
        ///     Class (<see cref="ReportFilter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportFilter_Is_Instance_Present_Test()
        {
            // Assert
            _reportFilterInstanceType.ShouldNotBeNull();
            _reportFilterInstance.ShouldNotBeNull();
            _reportFilterInstanceFixture.ShouldNotBeNull();
            _reportFilterInstance.ShouldBeAssignableTo<ReportFilter>();
            _reportFilterInstanceFixture.ShouldBeAssignableTo<ReportFilter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportFilter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportFilter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportFilter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportFilterInstanceType.ShouldNotBeNull();
            _reportFilterInstance.ShouldNotBeNull();
            _reportFilterInstanceFixture.ShouldNotBeNull();
            _reportFilterInstance.ShouldBeAssignableTo<ReportFilter>();
            _reportFilterInstanceFixture.ShouldBeAssignableTo<ReportFilter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportFilter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertybooleanFilter)]
        [TestCaseGeneric(typeof(ReportFilterItem[]) , PropertycriteriaItems)]
        [TestCaseGeneric(typeof(Language) , Propertylanguage)]
        [TestCaseGeneric(typeof(bool) , PropertylanguageSpecified)]
        public void AUT_ReportFilter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportFilter, T>(_reportFilterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilter) => Property (booleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportFilter_Public_Class_booleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybooleanFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilter) => Property (criteriaItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportFilter_criteriaItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycriteriaItems);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilter) => Property (criteriaItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportFilter_Public_Class_criteriaItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycriteriaItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilter) => Property (language) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportFilter_language_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertylanguage);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilter) => Property (language) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportFilter_Public_Class_language_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylanguage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilter) => Property (languageSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportFilter_Public_Class_languageSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylanguageSpecified);

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