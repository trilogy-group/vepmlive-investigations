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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowElementReferenceOrValue" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowElementReferenceOrValueTest : AbstractBaseSetupTypedTest<FlowElementReferenceOrValue>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowElementReferenceOrValue) Initializer

        private const string PropertybooleanValue = "booleanValue";
        private const string PropertybooleanValueSpecified = "booleanValueSpecified";
        private const string PropertydateValue = "dateValue";
        private const string PropertydateValueSpecified = "dateValueSpecified";
        private const string PropertyelementReference = "elementReference";
        private const string PropertynumberValue = "numberValue";
        private const string PropertynumberValueSpecified = "numberValueSpecified";
        private const string PropertystringValue = "stringValue";
        private const string FieldbooleanValueField = "booleanValueField";
        private const string FieldbooleanValueFieldSpecified = "booleanValueFieldSpecified";
        private const string FielddateValueField = "dateValueField";
        private const string FielddateValueFieldSpecified = "dateValueFieldSpecified";
        private const string FieldelementReferenceField = "elementReferenceField";
        private const string FieldnumberValueField = "numberValueField";
        private const string FieldnumberValueFieldSpecified = "numberValueFieldSpecified";
        private const string FieldstringValueField = "stringValueField";
        private Type _flowElementReferenceOrValueInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowElementReferenceOrValue _flowElementReferenceOrValueInstance;
        private FlowElementReferenceOrValue _flowElementReferenceOrValueInstanceFixture;

        #region General Initializer : Class (FlowElementReferenceOrValue) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowElementReferenceOrValue" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowElementReferenceOrValueInstanceType = typeof(FlowElementReferenceOrValue);
            _flowElementReferenceOrValueInstanceFixture = Create(true);
            _flowElementReferenceOrValueInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowElementReferenceOrValue)

        #region General Initializer : Class (FlowElementReferenceOrValue) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowElementReferenceOrValue" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybooleanValue)]
        [TestCase(PropertybooleanValueSpecified)]
        [TestCase(PropertydateValue)]
        [TestCase(PropertydateValueSpecified)]
        [TestCase(PropertyelementReference)]
        [TestCase(PropertynumberValue)]
        [TestCase(PropertynumberValueSpecified)]
        [TestCase(PropertystringValue)]
        public void AUT_FlowElementReferenceOrValue_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowElementReferenceOrValueInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowElementReferenceOrValue) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowElementReferenceOrValue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbooleanValueField)]
        [TestCase(FieldbooleanValueFieldSpecified)]
        [TestCase(FielddateValueField)]
        [TestCase(FielddateValueFieldSpecified)]
        [TestCase(FieldelementReferenceField)]
        [TestCase(FieldnumberValueField)]
        [TestCase(FieldnumberValueFieldSpecified)]
        [TestCase(FieldstringValueField)]
        public void AUT_FlowElementReferenceOrValue_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowElementReferenceOrValueInstanceFixture, 
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
        ///     Class (<see cref="FlowElementReferenceOrValue" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowElementReferenceOrValue_Is_Instance_Present_Test()
        {
            // Assert
            _flowElementReferenceOrValueInstanceType.ShouldNotBeNull();
            _flowElementReferenceOrValueInstance.ShouldNotBeNull();
            _flowElementReferenceOrValueInstanceFixture.ShouldNotBeNull();
            _flowElementReferenceOrValueInstance.ShouldBeAssignableTo<FlowElementReferenceOrValue>();
            _flowElementReferenceOrValueInstanceFixture.ShouldBeAssignableTo<FlowElementReferenceOrValue>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowElementReferenceOrValue) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowElementReferenceOrValue_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowElementReferenceOrValue instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowElementReferenceOrValueInstanceType.ShouldNotBeNull();
            _flowElementReferenceOrValueInstance.ShouldNotBeNull();
            _flowElementReferenceOrValueInstanceFixture.ShouldNotBeNull();
            _flowElementReferenceOrValueInstance.ShouldBeAssignableTo<FlowElementReferenceOrValue>();
            _flowElementReferenceOrValueInstanceFixture.ShouldBeAssignableTo<FlowElementReferenceOrValue>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowElementReferenceOrValue) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertybooleanValue)]
        [TestCaseGeneric(typeof(bool) , PropertybooleanValueSpecified)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertydateValue)]
        [TestCaseGeneric(typeof(bool) , PropertydateValueSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyelementReference)]
        [TestCaseGeneric(typeof(double) , PropertynumberValue)]
        [TestCaseGeneric(typeof(bool) , PropertynumberValueSpecified)]
        [TestCaseGeneric(typeof(string) , PropertystringValue)]
        public void AUT_FlowElementReferenceOrValue_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowElementReferenceOrValue, T>(_flowElementReferenceOrValueInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowElementReferenceOrValue) => Property (booleanValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElementReferenceOrValue_Public_Class_booleanValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybooleanValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowElementReferenceOrValue) => Property (booleanValueSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElementReferenceOrValue_Public_Class_booleanValueSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybooleanValueSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowElementReferenceOrValue) => Property (dateValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElementReferenceOrValue_dateValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydateValue);
            Action currentAction = () => propertyInfo.SetValue(_flowElementReferenceOrValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowElementReferenceOrValue) => Property (dateValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElementReferenceOrValue_Public_Class_dateValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydateValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowElementReferenceOrValue) => Property (dateValueSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElementReferenceOrValue_Public_Class_dateValueSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydateValueSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowElementReferenceOrValue) => Property (elementReference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElementReferenceOrValue_Public_Class_elementReference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyelementReference);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowElementReferenceOrValue) => Property (numberValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElementReferenceOrValue_Public_Class_numberValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowElementReferenceOrValue) => Property (numberValueSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElementReferenceOrValue_Public_Class_numberValueSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumberValueSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowElementReferenceOrValue) => Property (stringValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowElementReferenceOrValue_Public_Class_stringValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystringValue);

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