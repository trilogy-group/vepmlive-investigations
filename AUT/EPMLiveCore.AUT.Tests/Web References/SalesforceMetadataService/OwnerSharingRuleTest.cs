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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.OwnerSharingRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class OwnerSharingRuleTest : AbstractBaseSetupTypedTest<OwnerSharingRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (OwnerSharingRule) Initializer

        private const string PropertysharedFrom = "sharedFrom";
        private const string FieldsharedFromField = "sharedFromField";
        private Type _ownerSharingRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private OwnerSharingRule _ownerSharingRuleInstance;
        private OwnerSharingRule _ownerSharingRuleInstanceFixture;

        #region General Initializer : Class (OwnerSharingRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="OwnerSharingRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ownerSharingRuleInstanceType = typeof(OwnerSharingRule);
            _ownerSharingRuleInstanceFixture = Create(true);
            _ownerSharingRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (OwnerSharingRule)

        #region General Initializer : Class (OwnerSharingRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="OwnerSharingRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertysharedFrom)]
        public void AUT_OwnerSharingRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ownerSharingRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (OwnerSharingRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="OwnerSharingRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldsharedFromField)]
        public void AUT_OwnerSharingRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ownerSharingRuleInstanceFixture, 
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
        ///     Class (<see cref="OwnerSharingRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_OwnerSharingRule_Is_Instance_Present_Test()
        {
            // Assert
            _ownerSharingRuleInstanceType.ShouldNotBeNull();
            _ownerSharingRuleInstance.ShouldNotBeNull();
            _ownerSharingRuleInstanceFixture.ShouldNotBeNull();
            _ownerSharingRuleInstance.ShouldBeAssignableTo<OwnerSharingRule>();
            _ownerSharingRuleInstanceFixture.ShouldBeAssignableTo<OwnerSharingRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (OwnerSharingRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_OwnerSharingRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            OwnerSharingRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ownerSharingRuleInstanceType.ShouldNotBeNull();
            _ownerSharingRuleInstance.ShouldNotBeNull();
            _ownerSharingRuleInstanceFixture.ShouldNotBeNull();
            _ownerSharingRuleInstance.ShouldBeAssignableTo<OwnerSharingRule>();
            _ownerSharingRuleInstanceFixture.ShouldBeAssignableTo<OwnerSharingRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (OwnerSharingRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(SharedTo) , PropertysharedFrom)]
        public void AUT_OwnerSharingRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<OwnerSharingRule, T>(_ownerSharingRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (OwnerSharingRule) => Property (sharedFrom) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OwnerSharingRule_sharedFrom_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysharedFrom);
            Action currentAction = () => propertyInfo.SetValue(_ownerSharingRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (OwnerSharingRule) => Property (sharedFrom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_OwnerSharingRule_Public_Class_sharedFrom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysharedFrom);

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