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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportBucketField" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportBucketFieldTest : AbstractBaseSetupTypedTest<ReportBucketField>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportBucketField) Initializer

        private const string PropertybucketType = "bucketType";
        private const string PropertydeveloperName = "developerName";
        private const string PropertymasterLabel = "masterLabel";
        private const string PropertynullTreatment = "nullTreatment";
        private const string PropertynullTreatmentSpecified = "nullTreatmentSpecified";
        private const string PropertyotherBucketLabel = "otherBucketLabel";
        private const string PropertysourceColumnName = "sourceColumnName";
        private const string PropertyuseOther = "useOther";
        private const string PropertyuseOtherSpecified = "useOtherSpecified";
        private const string Propertyvalues = "values";
        private const string FieldbucketTypeField = "bucketTypeField";
        private const string FielddeveloperNameField = "developerNameField";
        private const string FieldmasterLabelField = "masterLabelField";
        private const string FieldnullTreatmentField = "nullTreatmentField";
        private const string FieldnullTreatmentFieldSpecified = "nullTreatmentFieldSpecified";
        private const string FieldotherBucketLabelField = "otherBucketLabelField";
        private const string FieldsourceColumnNameField = "sourceColumnNameField";
        private const string FielduseOtherField = "useOtherField";
        private const string FielduseOtherFieldSpecified = "useOtherFieldSpecified";
        private const string FieldvaluesField = "valuesField";
        private Type _reportBucketFieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportBucketField _reportBucketFieldInstance;
        private ReportBucketField _reportBucketFieldInstanceFixture;

        #region General Initializer : Class (ReportBucketField) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportBucketField" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportBucketFieldInstanceType = typeof(ReportBucketField);
            _reportBucketFieldInstanceFixture = Create(true);
            _reportBucketFieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportBucketField)

        #region General Initializer : Class (ReportBucketField) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportBucketField" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybucketType)]
        [TestCase(PropertydeveloperName)]
        [TestCase(PropertymasterLabel)]
        [TestCase(PropertynullTreatment)]
        [TestCase(PropertynullTreatmentSpecified)]
        [TestCase(PropertyotherBucketLabel)]
        [TestCase(PropertysourceColumnName)]
        [TestCase(PropertyuseOther)]
        [TestCase(PropertyuseOtherSpecified)]
        [TestCase(Propertyvalues)]
        public void AUT_ReportBucketField_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportBucketFieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportBucketField) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportBucketField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbucketTypeField)]
        [TestCase(FielddeveloperNameField)]
        [TestCase(FieldmasterLabelField)]
        [TestCase(FieldnullTreatmentField)]
        [TestCase(FieldnullTreatmentFieldSpecified)]
        [TestCase(FieldotherBucketLabelField)]
        [TestCase(FieldsourceColumnNameField)]
        [TestCase(FielduseOtherField)]
        [TestCase(FielduseOtherFieldSpecified)]
        [TestCase(FieldvaluesField)]
        public void AUT_ReportBucketField_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportBucketFieldInstanceFixture, 
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
        ///     Class (<see cref="ReportBucketField" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportBucketField_Is_Instance_Present_Test()
        {
            // Assert
            _reportBucketFieldInstanceType.ShouldNotBeNull();
            _reportBucketFieldInstance.ShouldNotBeNull();
            _reportBucketFieldInstanceFixture.ShouldNotBeNull();
            _reportBucketFieldInstance.ShouldBeAssignableTo<ReportBucketField>();
            _reportBucketFieldInstanceFixture.ShouldBeAssignableTo<ReportBucketField>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportBucketField) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportBucketField_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportBucketField instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportBucketFieldInstanceType.ShouldNotBeNull();
            _reportBucketFieldInstance.ShouldNotBeNull();
            _reportBucketFieldInstanceFixture.ShouldNotBeNull();
            _reportBucketFieldInstance.ShouldBeAssignableTo<ReportBucketField>();
            _reportBucketFieldInstanceFixture.ShouldBeAssignableTo<ReportBucketField>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportBucketField) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportBucketFieldType) , PropertybucketType)]
        [TestCaseGeneric(typeof(string) , PropertydeveloperName)]
        [TestCaseGeneric(typeof(string) , PropertymasterLabel)]
        [TestCaseGeneric(typeof(ReportBucketFieldNullTreatment) , PropertynullTreatment)]
        [TestCaseGeneric(typeof(bool) , PropertynullTreatmentSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyotherBucketLabel)]
        [TestCaseGeneric(typeof(string) , PropertysourceColumnName)]
        [TestCaseGeneric(typeof(bool) , PropertyuseOther)]
        [TestCaseGeneric(typeof(bool) , PropertyuseOtherSpecified)]
        [TestCaseGeneric(typeof(ReportBucketFieldValue[]) , Propertyvalues)]
        public void AUT_ReportBucketField_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportBucketField, T>(_reportBucketFieldInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (bucketType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_bucketType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertybucketType);
            Action currentAction = () => propertyInfo.SetValue(_reportBucketFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (bucketType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_Public_Class_bucketType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybucketType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (developerName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_Public_Class_developerName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeveloperName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (masterLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_Public_Class_masterLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymasterLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (nullTreatment) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_nullTreatment_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertynullTreatment);
            Action currentAction = () => propertyInfo.SetValue(_reportBucketFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (nullTreatment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_Public_Class_nullTreatment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynullTreatment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (nullTreatmentSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_Public_Class_nullTreatmentSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynullTreatmentSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (otherBucketLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_Public_Class_otherBucketLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyotherBucketLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (sourceColumnName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_Public_Class_sourceColumnName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysourceColumnName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (useOther) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_Public_Class_useOther_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseOther);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (useOtherSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_Public_Class_useOtherSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseOtherSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (values) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_values_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvalues);
            Action currentAction = () => propertyInfo.SetValue(_reportBucketFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportBucketField) => Property (values) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportBucketField_Public_Class_values_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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