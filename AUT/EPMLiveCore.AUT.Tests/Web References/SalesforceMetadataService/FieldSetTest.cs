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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FieldSet" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FieldSetTest : AbstractBaseSetupTypedTest<FieldSet>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FieldSet) Initializer

        private const string PropertyavailableFields = "availableFields";
        private const string Propertydescription = "description";
        private const string PropertydisplayedFields = "displayedFields";
        private const string Propertylabel = "label";
        private const string FieldavailableFieldsField = "availableFieldsField";
        private const string FielddescriptionField = "descriptionField";
        private const string FielddisplayedFieldsField = "displayedFieldsField";
        private const string FieldlabelField = "labelField";
        private Type _fieldSetInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FieldSet _fieldSetInstance;
        private FieldSet _fieldSetInstanceFixture;

        #region General Initializer : Class (FieldSet) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FieldSet" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _fieldSetInstanceType = typeof(FieldSet);
            _fieldSetInstanceFixture = Create(true);
            _fieldSetInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FieldSet)

        #region General Initializer : Class (FieldSet) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FieldSet" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyavailableFields)]
        [TestCase(Propertydescription)]
        [TestCase(PropertydisplayedFields)]
        [TestCase(Propertylabel)]
        public void AUT_FieldSet_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_fieldSetInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FieldSet) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FieldSet" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldavailableFieldsField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FielddisplayedFieldsField)]
        [TestCase(FieldlabelField)]
        public void AUT_FieldSet_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_fieldSetInstanceFixture, 
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
        ///     Class (<see cref="FieldSet" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FieldSet_Is_Instance_Present_Test()
        {
            // Assert
            _fieldSetInstanceType.ShouldNotBeNull();
            _fieldSetInstance.ShouldNotBeNull();
            _fieldSetInstanceFixture.ShouldNotBeNull();
            _fieldSetInstance.ShouldBeAssignableTo<FieldSet>();
            _fieldSetInstanceFixture.ShouldBeAssignableTo<FieldSet>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FieldSet) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FieldSet_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FieldSet instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _fieldSetInstanceType.ShouldNotBeNull();
            _fieldSetInstance.ShouldNotBeNull();
            _fieldSetInstanceFixture.ShouldNotBeNull();
            _fieldSetInstance.ShouldBeAssignableTo<FieldSet>();
            _fieldSetInstanceFixture.ShouldBeAssignableTo<FieldSet>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FieldSet) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FieldSetItem[]) , PropertyavailableFields)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(FieldSetItem[]) , PropertydisplayedFields)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        public void AUT_FieldSet_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FieldSet, T>(_fieldSetInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FieldSet) => Property (availableFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FieldSet_availableFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyavailableFields);
            Action currentAction = () => propertyInfo.SetValue(_fieldSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FieldSet) => Property (availableFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FieldSet_Public_Class_availableFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyavailableFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FieldSet) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FieldSet_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FieldSet) => Property (displayedFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FieldSet_displayedFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydisplayedFields);
            Action currentAction = () => propertyInfo.SetValue(_fieldSetInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FieldSet) => Property (displayedFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FieldSet_Public_Class_displayedFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayedFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FieldSet) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FieldSet_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

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