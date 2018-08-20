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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowElement" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowElementTest : AbstractBaseSetupTypedTest<FlowElement>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowElement) Initializer

        private const string Propertydescription = "description";
        private const string Propertyname = "name";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldnameField = "nameField";
        private Type _flowElementInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowElement _flowElementInstance;
        private FlowElement _flowElementInstanceFixture;

        #region General Initializer : Class (FlowElement) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowElement" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowElementInstanceType = typeof(FlowElement);
            _flowElementInstanceFixture = Create(true);
            _flowElementInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowElement)

        #region General Initializer : Class (FlowElement) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowElement" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        [TestCase(Propertyname)]
        public void AUT_FlowElement_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowElementInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowElement) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowElement" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldnameField)]
        public void AUT_FlowElement_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowElementInstanceFixture, 
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
        ///     Class (<see cref="FlowElement" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowElement_Is_Instance_Present_Test()
        {
            // Assert
            _flowElementInstanceType.ShouldNotBeNull();
            _flowElementInstance.ShouldNotBeNull();
            _flowElementInstanceFixture.ShouldNotBeNull();
            _flowElementInstance.ShouldBeAssignableTo<FlowElement>();
            _flowElementInstanceFixture.ShouldBeAssignableTo<FlowElement>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowElement) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowElement_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowElement instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowElementInstanceType.ShouldNotBeNull();
            _flowElementInstance.ShouldNotBeNull();
            _flowElementInstanceFixture.ShouldNotBeNull();
            _flowElementInstance.ShouldBeAssignableTo<FlowElement>();
            _flowElementInstanceFixture.ShouldBeAssignableTo<FlowElement>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowElement) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_FlowElement_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowElement, T>(_flowElementInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowElement) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElement_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowElement) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElement_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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