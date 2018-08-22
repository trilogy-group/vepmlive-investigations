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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowSubflowOutputAssignment" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowSubflowOutputAssignmentTest : AbstractBaseSetupTypedTest<FlowSubflowOutputAssignment>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowSubflowOutputAssignment) Initializer

        private const string PropertyassignToReference = "assignToReference";
        private const string Propertyname = "name";
        private const string FieldassignToReferenceField = "assignToReferenceField";
        private const string FieldnameField = "nameField";
        private Type _flowSubflowOutputAssignmentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowSubflowOutputAssignment _flowSubflowOutputAssignmentInstance;
        private FlowSubflowOutputAssignment _flowSubflowOutputAssignmentInstanceFixture;

        #region General Initializer : Class (FlowSubflowOutputAssignment) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowSubflowOutputAssignment" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowSubflowOutputAssignmentInstanceType = typeof(FlowSubflowOutputAssignment);
            _flowSubflowOutputAssignmentInstanceFixture = Create(true);
            _flowSubflowOutputAssignmentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowSubflowOutputAssignment)

        #region General Initializer : Class (FlowSubflowOutputAssignment) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowSubflowOutputAssignment" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignToReference)]
        [TestCase(Propertyname)]
        public void AUT_FlowSubflowOutputAssignment_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowSubflowOutputAssignmentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowSubflowOutputAssignment) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowSubflowOutputAssignment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignToReferenceField)]
        [TestCase(FieldnameField)]
        public void AUT_FlowSubflowOutputAssignment_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowSubflowOutputAssignmentInstanceFixture, 
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
        ///     Class (<see cref="FlowSubflowOutputAssignment" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowSubflowOutputAssignment_Is_Instance_Present_Test()
        {
            // Assert
            _flowSubflowOutputAssignmentInstanceType.ShouldNotBeNull();
            _flowSubflowOutputAssignmentInstance.ShouldNotBeNull();
            _flowSubflowOutputAssignmentInstanceFixture.ShouldNotBeNull();
            _flowSubflowOutputAssignmentInstance.ShouldBeAssignableTo<FlowSubflowOutputAssignment>();
            _flowSubflowOutputAssignmentInstanceFixture.ShouldBeAssignableTo<FlowSubflowOutputAssignment>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowSubflowOutputAssignment) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowSubflowOutputAssignment_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowSubflowOutputAssignment instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowSubflowOutputAssignmentInstanceType.ShouldNotBeNull();
            _flowSubflowOutputAssignmentInstance.ShouldNotBeNull();
            _flowSubflowOutputAssignmentInstanceFixture.ShouldNotBeNull();
            _flowSubflowOutputAssignmentInstance.ShouldBeAssignableTo<FlowSubflowOutputAssignment>();
            _flowSubflowOutputAssignmentInstanceFixture.ShouldBeAssignableTo<FlowSubflowOutputAssignment>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowSubflowOutputAssignment) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyassignToReference)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_FlowSubflowOutputAssignment_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowSubflowOutputAssignment, T>(_flowSubflowOutputAssignmentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowSubflowOutputAssignment) => Property (assignToReference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowSubflowOutputAssignment_Public_Class_assignToReference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowSubflowOutputAssignment) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowSubflowOutputAssignment_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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