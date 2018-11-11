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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.BusinessProcess" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class BusinessProcessTest : AbstractBaseSetupTypedTest<BusinessProcess>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (BusinessProcess) Initializer

        private const string Propertydescription = "description";
        private const string PropertyisActive = "isActive";
        private const string PropertyisActiveSpecified = "isActiveSpecified";
        private const string Propertyvalues = "values";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldisActiveField = "isActiveField";
        private const string FieldisActiveFieldSpecified = "isActiveFieldSpecified";
        private const string FieldvaluesField = "valuesField";
        private Type _businessProcessInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private BusinessProcess _businessProcessInstance;
        private BusinessProcess _businessProcessInstanceFixture;

        #region General Initializer : Class (BusinessProcess) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="BusinessProcess" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _businessProcessInstanceType = typeof(BusinessProcess);
            _businessProcessInstanceFixture = Create(true);
            _businessProcessInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (BusinessProcess)

        #region General Initializer : Class (BusinessProcess) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="BusinessProcess" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        [TestCase(PropertyisActive)]
        [TestCase(PropertyisActiveSpecified)]
        [TestCase(Propertyvalues)]
        public void AUT_BusinessProcess_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_businessProcessInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (BusinessProcess) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="BusinessProcess" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldisActiveField)]
        [TestCase(FieldisActiveFieldSpecified)]
        [TestCase(FieldvaluesField)]
        public void AUT_BusinessProcess_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_businessProcessInstanceFixture, 
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
        ///     Class (<see cref="BusinessProcess" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_BusinessProcess_Is_Instance_Present_Test()
        {
            // Assert
            _businessProcessInstanceType.ShouldNotBeNull();
            _businessProcessInstance.ShouldNotBeNull();
            _businessProcessInstanceFixture.ShouldNotBeNull();
            _businessProcessInstance.ShouldBeAssignableTo<BusinessProcess>();
            _businessProcessInstanceFixture.ShouldBeAssignableTo<BusinessProcess>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (BusinessProcess) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_BusinessProcess_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            BusinessProcess instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _businessProcessInstanceType.ShouldNotBeNull();
            _businessProcessInstance.ShouldNotBeNull();
            _businessProcessInstanceFixture.ShouldNotBeNull();
            _businessProcessInstance.ShouldBeAssignableTo<BusinessProcess>();
            _businessProcessInstanceFixture.ShouldBeAssignableTo<BusinessProcess>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (BusinessProcess) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(bool) , PropertyisActive)]
        [TestCaseGeneric(typeof(bool) , PropertyisActiveSpecified)]
        [TestCaseGeneric(typeof(PicklistValue[]) , Propertyvalues)]
        public void AUT_BusinessProcess_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<BusinessProcess, T>(_businessProcessInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (BusinessProcess) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_BusinessProcess_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (BusinessProcess) => Property (isActive) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_BusinessProcess_Public_Class_isActive_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisActive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (BusinessProcess) => Property (isActiveSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_BusinessProcess_Public_Class_isActiveSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisActiveSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (BusinessProcess) => Property (values) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_BusinessProcess_values_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvalues);
            Action currentAction = () => propertyInfo.SetValue(_businessProcessInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (BusinessProcess) => Property (values) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_BusinessProcess_Public_Class_values_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalues);

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