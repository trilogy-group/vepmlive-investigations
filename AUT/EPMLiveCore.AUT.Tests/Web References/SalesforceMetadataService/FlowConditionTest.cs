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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowCondition" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowConditionTest : AbstractBaseSetupTypedTest<FlowCondition>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowCondition) Initializer

        private const string PropertyleftValueReference = "leftValueReference";
        private const string PropertyrightValue = "rightValue";
        private const string FieldleftValueReferenceField = "leftValueReferenceField";
        private const string FieldoperatorField = "operatorField";
        private const string FieldrightValueField = "rightValueField";
        private Type _flowConditionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowCondition _flowConditionInstance;
        private FlowCondition _flowConditionInstanceFixture;

        #region General Initializer : Class (FlowCondition) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowCondition" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowConditionInstanceType = typeof(FlowCondition);
            _flowConditionInstanceFixture = Create(true);
            _flowConditionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowCondition)

        #region General Initializer : Class (FlowCondition) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowCondition" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyleftValueReference)]
        [TestCase(PropertyrightValue)]
        public void AUT_FlowCondition_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowConditionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowCondition) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowCondition" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldleftValueReferenceField)]
        [TestCase(FieldoperatorField)]
        [TestCase(FieldrightValueField)]
        public void AUT_FlowCondition_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowConditionInstanceFixture, 
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
        ///     Class (<see cref="FlowCondition" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowCondition_Is_Instance_Present_Test()
        {
            // Assert
            _flowConditionInstanceType.ShouldNotBeNull();
            _flowConditionInstance.ShouldNotBeNull();
            _flowConditionInstanceFixture.ShouldNotBeNull();
            _flowConditionInstance.ShouldBeAssignableTo<FlowCondition>();
            _flowConditionInstanceFixture.ShouldBeAssignableTo<FlowCondition>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowCondition) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowCondition_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowCondition instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowConditionInstanceType.ShouldNotBeNull();
            _flowConditionInstance.ShouldNotBeNull();
            _flowConditionInstanceFixture.ShouldNotBeNull();
            _flowConditionInstance.ShouldBeAssignableTo<FlowCondition>();
            _flowConditionInstanceFixture.ShouldBeAssignableTo<FlowCondition>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowCondition) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyleftValueReference)]
        [TestCaseGeneric(typeof(FlowElementReferenceOrValue) , PropertyrightValue)]
        public void AUT_FlowCondition_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowCondition, T>(_flowConditionInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (FlowCondition) => Property (leftValueReference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowCondition_Public_Class_leftValueReference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyleftValueReference);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowCondition) => Property (rightValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowCondition_rightValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrightValue);
            Action currentAction = () => propertyInfo.SetValue(_flowConditionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowCondition) => Property (rightValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowCondition_Public_Class_rightValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrightValue);

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