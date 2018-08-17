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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomObjectSharingRules" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomObjectSharingRulesTest : AbstractBaseSetupTypedTest<CustomObjectSharingRules>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomObjectSharingRules) Initializer

        private const string PropertycriteriaBasedRules = "criteriaBasedRules";
        private const string PropertyownerRules = "ownerRules";
        private const string FieldcriteriaBasedRulesField = "criteriaBasedRulesField";
        private const string FieldownerRulesField = "ownerRulesField";
        private Type _customObjectSharingRulesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomObjectSharingRules _customObjectSharingRulesInstance;
        private CustomObjectSharingRules _customObjectSharingRulesInstanceFixture;

        #region General Initializer : Class (CustomObjectSharingRules) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomObjectSharingRules" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customObjectSharingRulesInstanceType = typeof(CustomObjectSharingRules);
            _customObjectSharingRulesInstanceFixture = Create(true);
            _customObjectSharingRulesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomObjectSharingRules)

        #region General Initializer : Class (CustomObjectSharingRules) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomObjectSharingRules" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycriteriaBasedRules)]
        [TestCase(PropertyownerRules)]
        public void AUT_CustomObjectSharingRules_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customObjectSharingRulesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomObjectSharingRules) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomObjectSharingRules" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcriteriaBasedRulesField)]
        [TestCase(FieldownerRulesField)]
        public void AUT_CustomObjectSharingRules_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customObjectSharingRulesInstanceFixture, 
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
        ///     Class (<see cref="CustomObjectSharingRules" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomObjectSharingRules_Is_Instance_Present_Test()
        {
            // Assert
            _customObjectSharingRulesInstanceType.ShouldNotBeNull();
            _customObjectSharingRulesInstance.ShouldNotBeNull();
            _customObjectSharingRulesInstanceFixture.ShouldNotBeNull();
            _customObjectSharingRulesInstance.ShouldBeAssignableTo<CustomObjectSharingRules>();
            _customObjectSharingRulesInstanceFixture.ShouldBeAssignableTo<CustomObjectSharingRules>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomObjectSharingRules) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomObjectSharingRules_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomObjectSharingRules instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customObjectSharingRulesInstanceType.ShouldNotBeNull();
            _customObjectSharingRulesInstance.ShouldNotBeNull();
            _customObjectSharingRulesInstanceFixture.ShouldNotBeNull();
            _customObjectSharingRulesInstance.ShouldBeAssignableTo<CustomObjectSharingRules>();
            _customObjectSharingRulesInstanceFixture.ShouldBeAssignableTo<CustomObjectSharingRules>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomObjectSharingRules) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CustomObjectCriteriaBasedSharingRule[]) , PropertycriteriaBasedRules)]
        [TestCaseGeneric(typeof(CustomObjectOwnerSharingRule[]) , PropertyownerRules)]
        public void AUT_CustomObjectSharingRules_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomObjectSharingRules, T>(_customObjectSharingRulesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectSharingRules) => Property (criteriaBasedRules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectSharingRules_criteriaBasedRules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycriteriaBasedRules);
            Action currentAction = () => propertyInfo.SetValue(_customObjectSharingRulesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectSharingRules) => Property (criteriaBasedRules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectSharingRules_Public_Class_criteriaBasedRules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycriteriaBasedRules);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectSharingRules) => Property (ownerRules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectSharingRules_ownerRules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyownerRules);
            Action currentAction = () => propertyInfo.SetValue(_customObjectSharingRulesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectSharingRules) => Property (ownerRules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectSharingRules_Public_Class_ownerRules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyownerRules);

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