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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Picklist" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PicklistTest : AbstractBaseSetupTypedTest<Picklist>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Picklist) Initializer

        private const string PropertycontrollingField = "controllingField";
        private const string PropertypicklistValues = "picklistValues";
        private const string Propertysorted = "sorted";
        private const string FieldcontrollingFieldField = "controllingFieldField";
        private const string FieldpicklistValuesField = "picklistValuesField";
        private const string FieldsortedField = "sortedField";
        private Type _picklistInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Picklist _picklistInstance;
        private Picklist _picklistInstanceFixture;

        #region General Initializer : Class (Picklist) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Picklist" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _picklistInstanceType = typeof(Picklist);
            _picklistInstanceFixture = Create(true);
            _picklistInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Picklist)

        #region General Initializer : Class (Picklist) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Picklist" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycontrollingField)]
        [TestCase(PropertypicklistValues)]
        [TestCase(Propertysorted)]
        public void AUT_Picklist_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_picklistInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Picklist) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Picklist" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcontrollingFieldField)]
        [TestCase(FieldpicklistValuesField)]
        [TestCase(FieldsortedField)]
        public void AUT_Picklist_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_picklistInstanceFixture, 
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
        ///     Class (<see cref="Picklist" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Picklist_Is_Instance_Present_Test()
        {
            // Assert
            _picklistInstanceType.ShouldNotBeNull();
            _picklistInstance.ShouldNotBeNull();
            _picklistInstanceFixture.ShouldNotBeNull();
            _picklistInstance.ShouldBeAssignableTo<Picklist>();
            _picklistInstanceFixture.ShouldBeAssignableTo<Picklist>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Picklist) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Picklist_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Picklist instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _picklistInstanceType.ShouldNotBeNull();
            _picklistInstance.ShouldNotBeNull();
            _picklistInstanceFixture.ShouldNotBeNull();
            _picklistInstance.ShouldBeAssignableTo<Picklist>();
            _picklistInstanceFixture.ShouldBeAssignableTo<Picklist>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Picklist) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertycontrollingField)]
        [TestCaseGeneric(typeof(PicklistValue[]) , PropertypicklistValues)]
        [TestCaseGeneric(typeof(bool) , Propertysorted)]
        public void AUT_Picklist_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Picklist, T>(_picklistInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Picklist) => Property (controllingField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Picklist_Public_Class_controllingField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycontrollingField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Picklist) => Property (picklistValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Picklist_picklistValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypicklistValues);
            Action currentAction = () => propertyInfo.SetValue(_picklistInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Picklist) => Property (picklistValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Picklist_Public_Class_picklistValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypicklistValues);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Picklist) => Property (sorted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Picklist_Public_Class_sorted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysorted);

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