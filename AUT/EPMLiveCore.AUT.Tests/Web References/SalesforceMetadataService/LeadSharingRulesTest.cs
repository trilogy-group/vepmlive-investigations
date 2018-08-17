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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.LeadSharingRules" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LeadSharingRulesTest : AbstractBaseSetupTypedTest<LeadSharingRules>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LeadSharingRules) Initializer

        private const string PropertycriteriaBasedRules = "criteriaBasedRules";
        private const string PropertyownerRules = "ownerRules";
        private const string FieldcriteriaBasedRulesField = "criteriaBasedRulesField";
        private const string FieldownerRulesField = "ownerRulesField";
        private Type _leadSharingRulesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LeadSharingRules _leadSharingRulesInstance;
        private LeadSharingRules _leadSharingRulesInstanceFixture;

        #region General Initializer : Class (LeadSharingRules) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LeadSharingRules" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _leadSharingRulesInstanceType = typeof(LeadSharingRules);
            _leadSharingRulesInstanceFixture = Create(true);
            _leadSharingRulesInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LeadSharingRules)

        #region General Initializer : Class (LeadSharingRules) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LeadSharingRules" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycriteriaBasedRules)]
        [TestCase(PropertyownerRules)]
        public void AUT_LeadSharingRules_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_leadSharingRulesInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LeadSharingRules) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LeadSharingRules" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcriteriaBasedRulesField)]
        [TestCase(FieldownerRulesField)]
        public void AUT_LeadSharingRules_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_leadSharingRulesInstanceFixture, 
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
        ///     Class (<see cref="LeadSharingRules" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LeadSharingRules_Is_Instance_Present_Test()
        {
            // Assert
            _leadSharingRulesInstanceType.ShouldNotBeNull();
            _leadSharingRulesInstance.ShouldNotBeNull();
            _leadSharingRulesInstanceFixture.ShouldNotBeNull();
            _leadSharingRulesInstance.ShouldBeAssignableTo<LeadSharingRules>();
            _leadSharingRulesInstanceFixture.ShouldBeAssignableTo<LeadSharingRules>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LeadSharingRules) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LeadSharingRules_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LeadSharingRules instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _leadSharingRulesInstanceType.ShouldNotBeNull();
            _leadSharingRulesInstance.ShouldNotBeNull();
            _leadSharingRulesInstanceFixture.ShouldNotBeNull();
            _leadSharingRulesInstance.ShouldBeAssignableTo<LeadSharingRules>();
            _leadSharingRulesInstanceFixture.ShouldBeAssignableTo<LeadSharingRules>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LeadSharingRules) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(LeadCriteriaBasedSharingRule[]) , PropertycriteriaBasedRules)]
        [TestCaseGeneric(typeof(LeadOwnerSharingRule[]) , PropertyownerRules)]
        public void AUT_LeadSharingRules_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LeadSharingRules, T>(_leadSharingRulesInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LeadSharingRules) => Property (criteriaBasedRules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadSharingRules_criteriaBasedRules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycriteriaBasedRules);
            Action currentAction = () => propertyInfo.SetValue(_leadSharingRulesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeadSharingRules) => Property (criteriaBasedRules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadSharingRules_Public_Class_criteriaBasedRules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LeadSharingRules) => Property (ownerRules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadSharingRules_ownerRules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyownerRules);
            Action currentAction = () => propertyInfo.SetValue(_leadSharingRulesInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeadSharingRules) => Property (ownerRules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadSharingRules_Public_Class_ownerRules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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