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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowAssignmentItem" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowAssignmentItemTest : AbstractBaseSetupTypedTest<FlowAssignmentItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowAssignmentItem) Initializer

        private const string PropertyassignToReference = "assignToReference";
        private const string Propertyvalue = "value";
        private const string FieldassignToReferenceField = "assignToReferenceField";
        private const string FieldoperatorField = "operatorField";
        private const string FieldvalueField = "valueField";
        private Type _flowAssignmentItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowAssignmentItem _flowAssignmentItemInstance;
        private FlowAssignmentItem _flowAssignmentItemInstanceFixture;

        #region General Initializer : Class (FlowAssignmentItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowAssignmentItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowAssignmentItemInstanceType = typeof(FlowAssignmentItem);
            _flowAssignmentItemInstanceFixture = Create(true);
            _flowAssignmentItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowAssignmentItem)

        #region General Initializer : Class (FlowAssignmentItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowAssignmentItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignToReference)]
        [TestCase(Propertyvalue)]
        public void AUT_FlowAssignmentItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowAssignmentItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowAssignmentItem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowAssignmentItem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignToReferenceField)]
        [TestCase(FieldoperatorField)]
        [TestCase(FieldvalueField)]
        public void AUT_FlowAssignmentItem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowAssignmentItemInstanceFixture, 
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
        ///     Class (<see cref="FlowAssignmentItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowAssignmentItem_Is_Instance_Present_Test()
        {
            // Assert
            _flowAssignmentItemInstanceType.ShouldNotBeNull();
            _flowAssignmentItemInstance.ShouldNotBeNull();
            _flowAssignmentItemInstanceFixture.ShouldNotBeNull();
            _flowAssignmentItemInstance.ShouldBeAssignableTo<FlowAssignmentItem>();
            _flowAssignmentItemInstanceFixture.ShouldBeAssignableTo<FlowAssignmentItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowAssignmentItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowAssignmentItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowAssignmentItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowAssignmentItemInstanceType.ShouldNotBeNull();
            _flowAssignmentItemInstance.ShouldNotBeNull();
            _flowAssignmentItemInstanceFixture.ShouldNotBeNull();
            _flowAssignmentItemInstance.ShouldBeAssignableTo<FlowAssignmentItem>();
            _flowAssignmentItemInstanceFixture.ShouldBeAssignableTo<FlowAssignmentItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowAssignmentItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyassignToReference)]
        [TestCaseGeneric(typeof(FlowElementReferenceOrValue) , Propertyvalue)]
        public void AUT_FlowAssignmentItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowAssignmentItem, T>(_flowAssignmentItemInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (FlowAssignmentItem) => Property (assignToReference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowAssignmentItem_Public_Class_assignToReference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignToReference);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowAssignmentItem) => Property (value) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowAssignmentItem_value_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvalue);
            Action currentAction = () => propertyInfo.SetValue(_flowAssignmentItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowAssignmentItem) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowAssignmentItem_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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