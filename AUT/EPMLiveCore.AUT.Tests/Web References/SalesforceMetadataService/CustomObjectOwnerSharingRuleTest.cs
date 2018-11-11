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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomObjectOwnerSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomObjectOwnerSharingRuleTest : AbstractBaseSetupTypedTest<CustomObjectOwnerSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomObjectOwnerSharingRule) Initializer

        private const string PropertyaccessLevel = "accessLevel";
        private const string Propertyname = "name";
        private const string FieldaccessLevelField = "accessLevelField";
        private const string FieldnameField = "nameField";
        private Type _customObjectOwnerSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomObjectOwnerSharingRule _customObjectOwnerSharingRuleInstance;
        private CustomObjectOwnerSharingRule _customObjectOwnerSharingRuleInstanceFixture;

        #region General Initializer : Class (CustomObjectOwnerSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomObjectOwnerSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customObjectOwnerSharingRuleInstanceType = typeof(CustomObjectOwnerSharingRule);
            _customObjectOwnerSharingRuleInstanceFixture = Create(true);
            _customObjectOwnerSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomObjectOwnerSharingRule)

        #region General Initializer : Class (CustomObjectOwnerSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomObjectOwnerSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaccessLevel)]
        [TestCase(Propertyname)]
        public void AUT_CustomObjectOwnerSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customObjectOwnerSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomObjectOwnerSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomObjectOwnerSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaccessLevelField)]
        [TestCase(FieldnameField)]
        public void AUT_CustomObjectOwnerSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customObjectOwnerSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="CustomObjectOwnerSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomObjectOwnerSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _customObjectOwnerSharingRuleInstanceType.ShouldNotBeNull();
            _customObjectOwnerSharingRuleInstance.ShouldNotBeNull();
            _customObjectOwnerSharingRuleInstanceFixture.ShouldNotBeNull();
            _customObjectOwnerSharingRuleInstance.ShouldBeAssignableTo<CustomObjectOwnerSharingRule>();
            _customObjectOwnerSharingRuleInstanceFixture.ShouldBeAssignableTo<CustomObjectOwnerSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomObjectOwnerSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomObjectOwnerSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomObjectOwnerSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customObjectOwnerSharingRuleInstanceType.ShouldNotBeNull();
            _customObjectOwnerSharingRuleInstance.ShouldNotBeNull();
            _customObjectOwnerSharingRuleInstanceFixture.ShouldNotBeNull();
            _customObjectOwnerSharingRuleInstance.ShouldBeAssignableTo<CustomObjectOwnerSharingRule>();
            _customObjectOwnerSharingRuleInstanceFixture.ShouldBeAssignableTo<CustomObjectOwnerSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomObjectOwnerSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyaccessLevel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_CustomObjectOwnerSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomObjectOwnerSharingRule, T>(_customObjectOwnerSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectOwnerSharingRule) => Property (accessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectOwnerSharingRule_Public_Class_accessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectOwnerSharingRule) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectOwnerSharingRule_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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