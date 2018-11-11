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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.RecordTypePicklistValue" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RecordTypePicklistValueTest : AbstractBaseSetupTypedTest<RecordTypePicklistValue>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RecordTypePicklistValue) Initializer

        private const string Propertypicklist = "picklist";
        private const string Propertyvalues = "values";
        private const string FieldpicklistField = "picklistField";
        private const string FieldvaluesField = "valuesField";
        private Type _recordTypePicklistValueInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RecordTypePicklistValue _recordTypePicklistValueInstance;
        private RecordTypePicklistValue _recordTypePicklistValueInstanceFixture;

        #region General Initializer : Class (RecordTypePicklistValue) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RecordTypePicklistValue" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _recordTypePicklistValueInstanceType = typeof(RecordTypePicklistValue);
            _recordTypePicklistValueInstanceFixture = Create(true);
            _recordTypePicklistValueInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RecordTypePicklistValue)

        #region General Initializer : Class (RecordTypePicklistValue) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RecordTypePicklistValue" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertypicklist)]
        [TestCase(Propertyvalues)]
        public void AUT_RecordTypePicklistValue_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_recordTypePicklistValueInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RecordTypePicklistValue) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RecordTypePicklistValue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldpicklistField)]
        [TestCase(FieldvaluesField)]
        public void AUT_RecordTypePicklistValue_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_recordTypePicklistValueInstanceFixture, 
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
        ///     Class (<see cref="RecordTypePicklistValue" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RecordTypePicklistValue_Is_Instance_Present_Test()
        {
            // Assert
            _recordTypePicklistValueInstanceType.ShouldNotBeNull();
            _recordTypePicklistValueInstance.ShouldNotBeNull();
            _recordTypePicklistValueInstanceFixture.ShouldNotBeNull();
            _recordTypePicklistValueInstance.ShouldBeAssignableTo<RecordTypePicklistValue>();
            _recordTypePicklistValueInstanceFixture.ShouldBeAssignableTo<RecordTypePicklistValue>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RecordTypePicklistValue) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RecordTypePicklistValue_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RecordTypePicklistValue instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _recordTypePicklistValueInstanceType.ShouldNotBeNull();
            _recordTypePicklistValueInstance.ShouldNotBeNull();
            _recordTypePicklistValueInstanceFixture.ShouldNotBeNull();
            _recordTypePicklistValueInstance.ShouldBeAssignableTo<RecordTypePicklistValue>();
            _recordTypePicklistValueInstanceFixture.ShouldBeAssignableTo<RecordTypePicklistValue>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RecordTypePicklistValue) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertypicklist)]
        [TestCaseGeneric(typeof(PicklistValue[]) , Propertyvalues)]
        public void AUT_RecordTypePicklistValue_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RecordTypePicklistValue, T>(_recordTypePicklistValueInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RecordTypePicklistValue) => Property (picklist) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RecordTypePicklistValue_Public_Class_picklist_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertypicklist);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RecordTypePicklistValue) => Property (values) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RecordTypePicklistValue_values_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvalues);
            Action currentAction = () => propertyInfo.SetValue(_recordTypePicklistValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RecordTypePicklistValue) => Property (values) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RecordTypePicklistValue_Public_Class_values_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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