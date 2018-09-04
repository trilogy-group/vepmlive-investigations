using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore.SalesforcePartnerService;
using Field = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.Field" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class FieldTest : AbstractBaseSetupTypedTest<Field>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Field) Initializer

        private const string PropertyautoNumber = "autoNumber";
        private const string PropertybyteLength = "byteLength";
        private const string Propertycalculated = "calculated";
        private const string PropertycalculatedFormula = "calculatedFormula";
        private const string PropertycascadeDelete = "cascadeDelete";
        private const string PropertycascadeDeleteSpecified = "cascadeDeleteSpecified";
        private const string PropertycaseSensitive = "caseSensitive";
        private const string PropertycontrollerName = "controllerName";
        private const string Propertycreateable = "createable";
        private const string Propertycustom = "custom";
        private const string PropertydefaultValueFormula = "defaultValueFormula";
        private const string PropertydefaultedOnCreate = "defaultedOnCreate";
        private const string PropertydependentPicklist = "dependentPicklist";
        private const string PropertydependentPicklistSpecified = "dependentPicklistSpecified";
        private const string PropertydeprecatedAndHidden = "deprecatedAndHidden";
        private const string Propertydigits = "digits";
        private const string PropertydisplayLocationInDecimal = "displayLocationInDecimal";
        private const string PropertydisplayLocationInDecimalSpecified = "displayLocationInDecimalSpecified";
        private const string PropertyexternalId = "externalId";
        private const string PropertyexternalIdSpecified = "externalIdSpecified";
        private const string Propertyfilterable = "filterable";
        private const string Propertygroupable = "groupable";
        private const string PropertyhtmlFormatted = "htmlFormatted";
        private const string PropertyhtmlFormattedSpecified = "htmlFormattedSpecified";
        private const string PropertyidLookup = "idLookup";
        private const string PropertyinlineHelpText = "inlineHelpText";
        private const string Propertylabel = "label";
        private const string Propertylength = "length";
        private const string Propertyname = "name";
        private const string PropertynameField = "nameField";
        private const string PropertynamePointing = "namePointing";
        private const string PropertynamePointingSpecified = "namePointingSpecified";
        private const string Propertynillable = "nillable";
        private const string Propertypermissionable = "permissionable";
        private const string PropertypicklistValues = "picklistValues";
        private const string Propertyprecision = "precision";
        private const string PropertyreferenceTo = "referenceTo";
        private const string PropertyrelationshipName = "relationshipName";
        private const string PropertyrelationshipOrder = "relationshipOrder";
        private const string PropertyrelationshipOrderSpecified = "relationshipOrderSpecified";
        private const string PropertyrestrictedDelete = "restrictedDelete";
        private const string PropertyrestrictedDeleteSpecified = "restrictedDeleteSpecified";
        private const string PropertyrestrictedPicklist = "restrictedPicklist";
        private const string Propertyscale = "scale";
        private const string PropertysoapType = "soapType";
        private const string Propertysortable = "sortable";
        private const string PropertysortableSpecified = "sortableSpecified";
        private const string Propertytype = "type";
        private const string Propertyunique = "unique";
        private const string Propertyupdateable = "updateable";
        private const string PropertywriteRequiresMasterRead = "writeRequiresMasterRead";
        private const string PropertywriteRequiresMasterReadSpecified = "writeRequiresMasterReadSpecified";
        private const string FieldautoNumberField = "autoNumberField";
        private const string FieldbyteLengthField = "byteLengthField";
        private const string FieldcalculatedField = "calculatedField";
        private const string FieldcalculatedFormulaField = "calculatedFormulaField";
        private const string FieldcascadeDeleteField = "cascadeDeleteField";
        private const string FieldcascadeDeleteFieldSpecified = "cascadeDeleteFieldSpecified";
        private const string FieldcaseSensitiveField = "caseSensitiveField";
        private const string FieldcontrollerNameField = "controllerNameField";
        private const string FieldcreateableField = "createableField";
        private const string FieldcustomField = "customField";
        private const string FielddefaultValueFormulaField = "defaultValueFormulaField";
        private const string FielddefaultedOnCreateField = "defaultedOnCreateField";
        private const string FielddependentPicklistField = "dependentPicklistField";
        private const string FielddependentPicklistFieldSpecified = "dependentPicklistFieldSpecified";
        private const string FielddeprecatedAndHiddenField = "deprecatedAndHiddenField";
        private const string FielddigitsField = "digitsField";
        private const string FielddisplayLocationInDecimalField = "displayLocationInDecimalField";
        private const string FielddisplayLocationInDecimalFieldSpecified = "displayLocationInDecimalFieldSpecified";
        private const string FieldexternalIdField = "externalIdField";
        private const string FieldexternalIdFieldSpecified = "externalIdFieldSpecified";
        private const string FieldfilterableField = "filterableField";
        private const string FieldgroupableField = "groupableField";
        private const string FieldhtmlFormattedField = "htmlFormattedField";
        private const string FieldhtmlFormattedFieldSpecified = "htmlFormattedFieldSpecified";
        private const string FieldidLookupField = "idLookupField";
        private const string FieldinlineHelpTextField = "inlineHelpTextField";
        private const string FieldlabelField = "labelField";
        private const string FieldlengthField = "lengthField";
        private const string FieldnameField1 = "nameField1";
        private const string FieldnameFieldField = "nameFieldField";
        private const string FieldnamePointingField = "namePointingField";
        private const string FieldnamePointingFieldSpecified = "namePointingFieldSpecified";
        private const string FieldnillableField = "nillableField";
        private const string FieldpermissionableField = "permissionableField";
        private const string FieldpicklistValuesField = "picklistValuesField";
        private const string FieldprecisionField = "precisionField";
        private const string FieldreferenceToField = "referenceToField";
        private const string FieldrelationshipNameField = "relationshipNameField";
        private const string FieldrelationshipOrderField = "relationshipOrderField";
        private const string FieldrelationshipOrderFieldSpecified = "relationshipOrderFieldSpecified";
        private const string FieldrestrictedDeleteField = "restrictedDeleteField";
        private const string FieldrestrictedDeleteFieldSpecified = "restrictedDeleteFieldSpecified";
        private const string FieldrestrictedPicklistField = "restrictedPicklistField";
        private const string FieldscaleField = "scaleField";
        private const string FieldsoapTypeField = "soapTypeField";
        private const string FieldsortableField = "sortableField";
        private const string FieldsortableFieldSpecified = "sortableFieldSpecified";
        private const string FieldtypeField = "typeField";
        private const string FielduniqueField = "uniqueField";
        private const string FieldupdateableField = "updateableField";
        private const string FieldwriteRequiresMasterReadField = "writeRequiresMasterReadField";
        private const string FieldwriteRequiresMasterReadFieldSpecified = "writeRequiresMasterReadFieldSpecified";
        private Type _fieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Field _fieldInstance;
        private Field _fieldInstanceFixture;

        #region General Initializer : Class (Field) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Field" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _fieldInstanceType = typeof(Field);
            _fieldInstanceFixture = Create(true);
            _fieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Field)

        #region General Initializer : Class (Field) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Field" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyautoNumber)]
        [TestCase(PropertybyteLength)]
        [TestCase(Propertycalculated)]
        [TestCase(PropertycalculatedFormula)]
        [TestCase(PropertycascadeDelete)]
        [TestCase(PropertycascadeDeleteSpecified)]
        [TestCase(PropertycaseSensitive)]
        [TestCase(PropertycontrollerName)]
        [TestCase(Propertycreateable)]
        [TestCase(Propertycustom)]
        [TestCase(PropertydefaultValueFormula)]
        [TestCase(PropertydefaultedOnCreate)]
        [TestCase(PropertydependentPicklist)]
        [TestCase(PropertydependentPicklistSpecified)]
        [TestCase(PropertydeprecatedAndHidden)]
        [TestCase(Propertydigits)]
        [TestCase(PropertydisplayLocationInDecimal)]
        [TestCase(PropertydisplayLocationInDecimalSpecified)]
        [TestCase(PropertyexternalId)]
        [TestCase(PropertyexternalIdSpecified)]
        [TestCase(Propertyfilterable)]
        [TestCase(Propertygroupable)]
        [TestCase(PropertyhtmlFormatted)]
        [TestCase(PropertyhtmlFormattedSpecified)]
        [TestCase(PropertyidLookup)]
        [TestCase(PropertyinlineHelpText)]
        [TestCase(Propertylabel)]
        [TestCase(Propertylength)]
        [TestCase(Propertyname)]
        [TestCase(PropertynameField)]
        [TestCase(PropertynamePointing)]
        [TestCase(PropertynamePointingSpecified)]
        [TestCase(Propertynillable)]
        [TestCase(Propertypermissionable)]
        [TestCase(PropertypicklistValues)]
        [TestCase(Propertyprecision)]
        [TestCase(PropertyreferenceTo)]
        [TestCase(PropertyrelationshipName)]
        [TestCase(PropertyrelationshipOrder)]
        [TestCase(PropertyrelationshipOrderSpecified)]
        [TestCase(PropertyrestrictedDelete)]
        [TestCase(PropertyrestrictedDeleteSpecified)]
        [TestCase(PropertyrestrictedPicklist)]
        [TestCase(Propertyscale)]
        [TestCase(PropertysoapType)]
        [TestCase(Propertysortable)]
        [TestCase(PropertysortableSpecified)]
        [TestCase(Propertytype)]
        [TestCase(Propertyunique)]
        [TestCase(Propertyupdateable)]
        [TestCase(PropertywriteRequiresMasterRead)]
        [TestCase(PropertywriteRequiresMasterReadSpecified)]
        public void AUT_Field_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_fieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Field) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Field" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldautoNumberField)]
        [TestCase(FieldbyteLengthField)]
        [TestCase(FieldcalculatedField)]
        [TestCase(FieldcalculatedFormulaField)]
        [TestCase(FieldcascadeDeleteField)]
        [TestCase(FieldcascadeDeleteFieldSpecified)]
        [TestCase(FieldcaseSensitiveField)]
        [TestCase(FieldcontrollerNameField)]
        [TestCase(FieldcreateableField)]
        [TestCase(FieldcustomField)]
        [TestCase(FielddefaultValueFormulaField)]
        [TestCase(FielddefaultedOnCreateField)]
        [TestCase(FielddependentPicklistField)]
        [TestCase(FielddependentPicklistFieldSpecified)]
        [TestCase(FielddeprecatedAndHiddenField)]
        [TestCase(FielddigitsField)]
        [TestCase(FielddisplayLocationInDecimalField)]
        [TestCase(FielddisplayLocationInDecimalFieldSpecified)]
        [TestCase(FieldexternalIdField)]
        [TestCase(FieldexternalIdFieldSpecified)]
        [TestCase(FieldfilterableField)]
        [TestCase(FieldgroupableField)]
        [TestCase(FieldhtmlFormattedField)]
        [TestCase(FieldhtmlFormattedFieldSpecified)]
        [TestCase(FieldidLookupField)]
        [TestCase(FieldinlineHelpTextField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlengthField)]
        [TestCase(FieldnameField1)]
        [TestCase(FieldnameFieldField)]
        [TestCase(FieldnamePointingField)]
        [TestCase(FieldnamePointingFieldSpecified)]
        [TestCase(FieldnillableField)]
        [TestCase(FieldpermissionableField)]
        [TestCase(FieldpicklistValuesField)]
        [TestCase(FieldprecisionField)]
        [TestCase(FieldreferenceToField)]
        [TestCase(FieldrelationshipNameField)]
        [TestCase(FieldrelationshipOrderField)]
        [TestCase(FieldrelationshipOrderFieldSpecified)]
        [TestCase(FieldrestrictedDeleteField)]
        [TestCase(FieldrestrictedDeleteFieldSpecified)]
        [TestCase(FieldrestrictedPicklistField)]
        [TestCase(FieldscaleField)]
        [TestCase(FieldsoapTypeField)]
        [TestCase(FieldsortableField)]
        [TestCase(FieldsortableFieldSpecified)]
        [TestCase(FieldtypeField)]
        [TestCase(FielduniqueField)]
        [TestCase(FieldupdateableField)]
        [TestCase(FieldwriteRequiresMasterReadField)]
        [TestCase(FieldwriteRequiresMasterReadFieldSpecified)]
        public void AUT_Field_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_fieldInstanceFixture, 
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
        ///     Class (<see cref="Field" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Field_Is_Instance_Present_Test()
        {
            // Assert
            _fieldInstanceType.ShouldNotBeNull();
            _fieldInstance.ShouldNotBeNull();
            _fieldInstanceFixture.ShouldNotBeNull();
            _fieldInstance.ShouldBeAssignableTo<Field>();
            _fieldInstanceFixture.ShouldBeAssignableTo<Field>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Field) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Field_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Field instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _fieldInstanceType.ShouldNotBeNull();
            _fieldInstance.ShouldNotBeNull();
            _fieldInstanceFixture.ShouldNotBeNull();
            _fieldInstance.ShouldBeAssignableTo<Field>();
            _fieldInstanceFixture.ShouldBeAssignableTo<Field>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Field) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyautoNumber)]
        [TestCaseGeneric(typeof(int) , PropertybyteLength)]
        [TestCaseGeneric(typeof(bool) , Propertycalculated)]
        [TestCaseGeneric(typeof(string) , PropertycalculatedFormula)]
        [TestCaseGeneric(typeof(bool) , PropertycascadeDelete)]
        [TestCaseGeneric(typeof(bool) , PropertycascadeDeleteSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertycaseSensitive)]
        [TestCaseGeneric(typeof(string) , PropertycontrollerName)]
        [TestCaseGeneric(typeof(bool) , Propertycreateable)]
        [TestCaseGeneric(typeof(bool) , Propertycustom)]
        [TestCaseGeneric(typeof(string) , PropertydefaultValueFormula)]
        [TestCaseGeneric(typeof(bool) , PropertydefaultedOnCreate)]
        [TestCaseGeneric(typeof(bool) , PropertydependentPicklist)]
        [TestCaseGeneric(typeof(bool) , PropertydependentPicklistSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertydeprecatedAndHidden)]
        [TestCaseGeneric(typeof(int) , Propertydigits)]
        [TestCaseGeneric(typeof(bool) , PropertydisplayLocationInDecimal)]
        [TestCaseGeneric(typeof(bool) , PropertydisplayLocationInDecimalSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyexternalId)]
        [TestCaseGeneric(typeof(bool) , PropertyexternalIdSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertyfilterable)]
        [TestCaseGeneric(typeof(bool) , Propertygroupable)]
        [TestCaseGeneric(typeof(bool) , PropertyhtmlFormatted)]
        [TestCaseGeneric(typeof(bool) , PropertyhtmlFormattedSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyidLookup)]
        [TestCaseGeneric(typeof(string) , PropertyinlineHelpText)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(int) , Propertylength)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(bool) , PropertynameField)]
        [TestCaseGeneric(typeof(bool) , PropertynamePointing)]
        [TestCaseGeneric(typeof(bool) , PropertynamePointingSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertynillable)]
        [TestCaseGeneric(typeof(bool) , Propertypermissionable)]
        [TestCaseGeneric(typeof(PicklistEntry[]) , PropertypicklistValues)]
        [TestCaseGeneric(typeof(int) , Propertyprecision)]
        [TestCaseGeneric(typeof(string[]) , PropertyreferenceTo)]
        [TestCaseGeneric(typeof(string) , PropertyrelationshipName)]
        [TestCaseGeneric(typeof(int) , PropertyrelationshipOrder)]
        [TestCaseGeneric(typeof(bool) , PropertyrelationshipOrderSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyrestrictedDelete)]
        [TestCaseGeneric(typeof(bool) , PropertyrestrictedDeleteSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyrestrictedPicklist)]
        [TestCaseGeneric(typeof(int) , Propertyscale)]
        [TestCaseGeneric(typeof(soapType) , PropertysoapType)]
        [TestCaseGeneric(typeof(bool) , Propertysortable)]
        [TestCaseGeneric(typeof(bool) , PropertysortableSpecified)]
        [TestCaseGeneric(typeof(fieldType) , Propertytype)]
        [TestCaseGeneric(typeof(bool) , Propertyunique)]
        [TestCaseGeneric(typeof(bool) , Propertyupdateable)]
        [TestCaseGeneric(typeof(bool) , PropertywriteRequiresMasterRead)]
        [TestCaseGeneric(typeof(bool) , PropertywriteRequiresMasterReadSpecified)]
        public void AUT_Field_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Field, T>(_fieldInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (autoNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_autoNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (byteLength) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_byteLength_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybyteLength);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (calculated) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_calculated_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycalculated);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (calculatedFormula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_calculatedFormula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycalculatedFormula);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (cascadeDelete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_cascadeDelete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycascadeDelete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (cascadeDeleteSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_cascadeDeleteSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycascadeDeleteSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (caseSensitive) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_caseSensitive_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseSensitive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (controllerName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_controllerName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycontrollerName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (createable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_createable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycreateable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (custom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_custom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycustom);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (defaultedOnCreate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_defaultedOnCreate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultedOnCreate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (defaultValueFormula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_defaultValueFormula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultValueFormula);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (dependentPicklist) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_dependentPicklist_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydependentPicklist);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (dependentPicklistSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_dependentPicklistSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydependentPicklistSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (deprecatedAndHidden) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_deprecatedAndHidden_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeprecatedAndHidden);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (digits) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_digits_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydigits);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (displayLocationInDecimal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_displayLocationInDecimal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayLocationInDecimal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (displayLocationInDecimalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_displayLocationInDecimalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayLocationInDecimalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (externalId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_externalId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexternalId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (externalIdSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_externalIdSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexternalIdSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (filterable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_filterable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfilterable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (groupable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_groupable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertygroupable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (htmlFormatted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_htmlFormatted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhtmlFormatted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (htmlFormattedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_htmlFormattedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhtmlFormattedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (idLookup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_idLookup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyidLookup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (inlineHelpText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_inlineHelpText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinlineHelpText);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Field) => Property (length) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_length_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylength);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Field) => Property (nameField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_nameField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynameField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (namePointing) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_namePointing_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynamePointing);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (namePointingSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_namePointingSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynamePointingSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (nillable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_nillable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertynillable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (permissionable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_permissionable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertypermissionable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (picklistValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_picklistValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypicklistValues);
            Action currentAction = () => propertyInfo.SetValue(_fieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (picklistValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_picklistValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Field) => Property (precision) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_precision_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyprecision);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (referenceTo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_referenceTo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyreferenceTo);
            Action currentAction = () => propertyInfo.SetValue(_fieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (referenceTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_referenceTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreferenceTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (relationshipName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_relationshipName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelationshipName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (relationshipOrder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_relationshipOrder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelationshipOrder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (relationshipOrderSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_relationshipOrderSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelationshipOrderSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (restrictedDelete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_restrictedDelete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrestrictedDelete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (restrictedDeleteSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_restrictedDeleteSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrestrictedDeleteSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (restrictedPicklist) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_restrictedPicklist_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrestrictedPicklist);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (scale) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_scale_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyscale);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (soapType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_soapType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysoapType);
            Action currentAction = () => propertyInfo.SetValue(_fieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (soapType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_soapType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysoapType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (sortable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_sortable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysortable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (sortableSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_sortableSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortableSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytype);
            Action currentAction = () => propertyInfo.SetValue(_fieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (unique) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_unique_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyunique);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (updateable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_updateable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyupdateable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (writeRequiresMasterRead) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_writeRequiresMasterRead_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywriteRequiresMasterRead);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Field) => Property (writeRequiresMasterReadSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Field_Public_Class_writeRequiresMasterReadSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywriteRequiresMasterReadSpecified);

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