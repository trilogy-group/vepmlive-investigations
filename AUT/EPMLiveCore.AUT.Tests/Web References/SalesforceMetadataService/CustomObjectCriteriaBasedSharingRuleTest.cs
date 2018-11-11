using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomObjectCriteriaBasedSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomObjectCriteriaBasedSharingRuleTest : AbstractBaseSetupTypedTest<CustomObjectCriteriaBasedSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomObjectCriteriaBasedSharingRule) Initializer

        private const string PropertyaccessLevel = "accessLevel";
        private const string PropertybooleanFilter = "booleanFilter";
        private const string Propertyname = "name";
        private const string FieldaccessLevelField = "accessLevelField";
        private const string FieldbooleanFilterField = "booleanFilterField";
        private const string FieldnameField = "nameField";
        private Type _customObjectCriteriaBasedSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomObjectCriteriaBasedSharingRule _customObjectCriteriaBasedSharingRuleInstance;
        private CustomObjectCriteriaBasedSharingRule _customObjectCriteriaBasedSharingRuleInstanceFixture;

        #region General Initializer : Class (CustomObjectCriteriaBasedSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomObjectCriteriaBasedSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customObjectCriteriaBasedSharingRuleInstanceType = typeof(CustomObjectCriteriaBasedSharingRule);
            _customObjectCriteriaBasedSharingRuleInstanceFixture = Create(true);
            _customObjectCriteriaBasedSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomObjectCriteriaBasedSharingRule)

        #region General Initializer : Class (CustomObjectCriteriaBasedSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomObjectCriteriaBasedSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaccessLevel)]
        [TestCase(PropertybooleanFilter)]
        [TestCase(Propertyname)]
        public void AUT_CustomObjectCriteriaBasedSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customObjectCriteriaBasedSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomObjectCriteriaBasedSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomObjectCriteriaBasedSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaccessLevelField)]
        [TestCase(FieldbooleanFilterField)]
        [TestCase(FieldnameField)]
        public void AUT_CustomObjectCriteriaBasedSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customObjectCriteriaBasedSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="CustomObjectCriteriaBasedSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomObjectCriteriaBasedSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _customObjectCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _customObjectCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _customObjectCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _customObjectCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<CustomObjectCriteriaBasedSharingRule>();
            _customObjectCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<CustomObjectCriteriaBasedSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomObjectCriteriaBasedSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomObjectCriteriaBasedSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomObjectCriteriaBasedSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customObjectCriteriaBasedSharingRuleInstanceType.ShouldNotBeNull();
            _customObjectCriteriaBasedSharingRuleInstance.ShouldNotBeNull();
            _customObjectCriteriaBasedSharingRuleInstanceFixture.ShouldNotBeNull();
            _customObjectCriteriaBasedSharingRuleInstance.ShouldBeAssignableTo<CustomObjectCriteriaBasedSharingRule>();
            _customObjectCriteriaBasedSharingRuleInstanceFixture.ShouldBeAssignableTo<CustomObjectCriteriaBasedSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomObjectCriteriaBasedSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyaccessLevel)]
        [TestCaseGeneric(typeof(string) , PropertybooleanFilter)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_CustomObjectCriteriaBasedSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomObjectCriteriaBasedSharingRule, T>(_customObjectCriteriaBasedSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectCriteriaBasedSharingRule) => Property (accessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectCriteriaBasedSharingRule_Public_Class_accessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaccessLevel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectCriteriaBasedSharingRule) => Property (booleanFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectCriteriaBasedSharingRule_Public_Class_booleanFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectCriteriaBasedSharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectCriteriaBasedSharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

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