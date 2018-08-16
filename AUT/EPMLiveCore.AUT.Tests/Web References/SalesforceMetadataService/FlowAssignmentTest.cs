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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowAssignment" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowAssignmentTest : AbstractBaseSetupTypedTest<FlowAssignment>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowAssignment) Initializer

        private const string PropertyassignmentItems = "assignmentItems";
        private const string Propertyconnector = "connector";
        private const string FieldassignmentItemsField = "assignmentItemsField";
        private const string FieldconnectorField = "connectorField";
        private Type _flowAssignmentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowAssignment _flowAssignmentInstance;
        private FlowAssignment _flowAssignmentInstanceFixture;

        #region General Initializer : Class (FlowAssignment) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowAssignment" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowAssignmentInstanceType = typeof(FlowAssignment);
            _flowAssignmentInstanceFixture = Create(true);
            _flowAssignmentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowAssignment)

        #region General Initializer : Class (FlowAssignment) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowAssignment" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignmentItems)]
        [TestCase(Propertyconnector)]
        public void AUT_FlowAssignment_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowAssignmentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowAssignment) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowAssignment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignmentItemsField)]
        [TestCase(FieldconnectorField)]
        public void AUT_FlowAssignment_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowAssignmentInstanceFixture, 
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
        ///     Class (<see cref="FlowAssignment" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowAssignment_Is_Instance_Present_Test()
        {
            // Assert
            _flowAssignmentInstanceType.ShouldNotBeNull();
            _flowAssignmentInstance.ShouldNotBeNull();
            _flowAssignmentInstanceFixture.ShouldNotBeNull();
            _flowAssignmentInstance.ShouldBeAssignableTo<FlowAssignment>();
            _flowAssignmentInstanceFixture.ShouldBeAssignableTo<FlowAssignment>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowAssignment) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowAssignment_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowAssignment instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowAssignmentInstanceType.ShouldNotBeNull();
            _flowAssignmentInstance.ShouldNotBeNull();
            _flowAssignmentInstanceFixture.ShouldNotBeNull();
            _flowAssignmentInstance.ShouldBeAssignableTo<FlowAssignment>();
            _flowAssignmentInstanceFixture.ShouldBeAssignableTo<FlowAssignment>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowAssignment) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FlowAssignmentItem[]) , PropertyassignmentItems)]
        [TestCaseGeneric(typeof(FlowConnector) , Propertyconnector)]
        public void AUT_FlowAssignment_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowAssignment, T>(_flowAssignmentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowAssignment) => Property (assignmentItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowAssignment_assignmentItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyassignmentItems);
            Action currentAction = () => propertyInfo.SetValue(_flowAssignmentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowAssignment) => Property (assignmentItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowAssignment_Public_Class_assignmentItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignmentItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowAssignment) => Property (connector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowAssignment_connector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconnector);
            Action currentAction = () => propertyInfo.SetValue(_flowAssignmentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowAssignment) => Property (connector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowAssignment_Public_Class_connector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyconnector);

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