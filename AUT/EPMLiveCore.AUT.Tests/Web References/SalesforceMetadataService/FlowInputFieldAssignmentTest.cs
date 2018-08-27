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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowInputFieldAssignment" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowInputFieldAssignmentTest : AbstractBaseSetupTypedTest<FlowInputFieldAssignment>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowInputFieldAssignment) Initializer

        private const string Propertyfield = "field";
        private const string Propertyvalue = "value";
        private const string FieldfieldField = "fieldField";
        private const string FieldvalueField = "valueField";
        private Type _flowInputFieldAssignmentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowInputFieldAssignment _flowInputFieldAssignmentInstance;
        private FlowInputFieldAssignment _flowInputFieldAssignmentInstanceFixture;

        #region General Initializer : Class (FlowInputFieldAssignment) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowInputFieldAssignment" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowInputFieldAssignmentInstanceType = typeof(FlowInputFieldAssignment);
            _flowInputFieldAssignmentInstanceFixture = Create(true);
            _flowInputFieldAssignmentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowInputFieldAssignment)

        #region General Initializer : Class (FlowInputFieldAssignment) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowInputFieldAssignment" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyfield)]
        [TestCase(Propertyvalue)]
        public void AUT_FlowInputFieldAssignment_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowInputFieldAssignmentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowInputFieldAssignment) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowInputFieldAssignment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfieldField)]
        [TestCase(FieldvalueField)]
        public void AUT_FlowInputFieldAssignment_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowInputFieldAssignmentInstanceFixture, 
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
        ///     Class (<see cref="FlowInputFieldAssignment" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowInputFieldAssignment_Is_Instance_Present_Test()
        {
            // Assert
            _flowInputFieldAssignmentInstanceType.ShouldNotBeNull();
            _flowInputFieldAssignmentInstance.ShouldNotBeNull();
            _flowInputFieldAssignmentInstanceFixture.ShouldNotBeNull();
            _flowInputFieldAssignmentInstance.ShouldBeAssignableTo<FlowInputFieldAssignment>();
            _flowInputFieldAssignmentInstanceFixture.ShouldBeAssignableTo<FlowInputFieldAssignment>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowInputFieldAssignment) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowInputFieldAssignment_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowInputFieldAssignment instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowInputFieldAssignmentInstanceType.ShouldNotBeNull();
            _flowInputFieldAssignmentInstance.ShouldNotBeNull();
            _flowInputFieldAssignmentInstanceFixture.ShouldNotBeNull();
            _flowInputFieldAssignmentInstance.ShouldBeAssignableTo<FlowInputFieldAssignment>();
            _flowInputFieldAssignmentInstanceFixture.ShouldBeAssignableTo<FlowInputFieldAssignment>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowInputFieldAssignment) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(FlowElementReferenceOrValue) , Propertyvalue)]
        public void AUT_FlowInputFieldAssignment_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowInputFieldAssignment, T>(_flowInputFieldAssignmentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowInputFieldAssignment) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowInputFieldAssignment_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowInputFieldAssignment) => Property (value) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowInputFieldAssignment_value_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvalue);
            Action currentAction = () => propertyInfo.SetValue(_flowInputFieldAssignmentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowInputFieldAssignment) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowInputFieldAssignment_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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