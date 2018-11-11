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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowOutputFieldAssignment" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowOutputFieldAssignmentTest : AbstractBaseSetupTypedTest<FlowOutputFieldAssignment>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowOutputFieldAssignment) Initializer

        private const string PropertyassignToReference = "assignToReference";
        private const string Propertyfield = "field";
        private const string FieldassignToReferenceField = "assignToReferenceField";
        private const string FieldfieldField = "fieldField";
        private Type _flowOutputFieldAssignmentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowOutputFieldAssignment _flowOutputFieldAssignmentInstance;
        private FlowOutputFieldAssignment _flowOutputFieldAssignmentInstanceFixture;

        #region General Initializer : Class (FlowOutputFieldAssignment) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowOutputFieldAssignment" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowOutputFieldAssignmentInstanceType = typeof(FlowOutputFieldAssignment);
            _flowOutputFieldAssignmentInstanceFixture = Create(true);
            _flowOutputFieldAssignmentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowOutputFieldAssignment)

        #region General Initializer : Class (FlowOutputFieldAssignment) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowOutputFieldAssignment" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignToReference)]
        [TestCase(Propertyfield)]
        public void AUT_FlowOutputFieldAssignment_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowOutputFieldAssignmentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowOutputFieldAssignment) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowOutputFieldAssignment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignToReferenceField)]
        [TestCase(FieldfieldField)]
        public void AUT_FlowOutputFieldAssignment_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowOutputFieldAssignmentInstanceFixture, 
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
        ///     Class (<see cref="FlowOutputFieldAssignment" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowOutputFieldAssignment_Is_Instance_Present_Test()
        {
            // Assert
            _flowOutputFieldAssignmentInstanceType.ShouldNotBeNull();
            _flowOutputFieldAssignmentInstance.ShouldNotBeNull();
            _flowOutputFieldAssignmentInstanceFixture.ShouldNotBeNull();
            _flowOutputFieldAssignmentInstance.ShouldBeAssignableTo<FlowOutputFieldAssignment>();
            _flowOutputFieldAssignmentInstanceFixture.ShouldBeAssignableTo<FlowOutputFieldAssignment>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowOutputFieldAssignment) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowOutputFieldAssignment_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowOutputFieldAssignment instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowOutputFieldAssignmentInstanceType.ShouldNotBeNull();
            _flowOutputFieldAssignmentInstance.ShouldNotBeNull();
            _flowOutputFieldAssignmentInstanceFixture.ShouldNotBeNull();
            _flowOutputFieldAssignmentInstance.ShouldBeAssignableTo<FlowOutputFieldAssignment>();
            _flowOutputFieldAssignmentInstanceFixture.ShouldBeAssignableTo<FlowOutputFieldAssignment>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowOutputFieldAssignment) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyassignToReference)]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        public void AUT_FlowOutputFieldAssignment_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowOutputFieldAssignment, T>(_flowOutputFieldAssignmentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowOutputFieldAssignment) => Property (assignToReference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowOutputFieldAssignment_Public_Class_assignToReference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowOutputFieldAssignment) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowOutputFieldAssignment_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}