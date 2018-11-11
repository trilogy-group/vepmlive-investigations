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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomField" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomFieldTest : AbstractBaseSetupTypedTest<CustomField>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomField) Initializer

        private const string PropertycaseSensitive = "caseSensitive";
        private const string PropertycaseSensitiveSpecified = "caseSensitiveSpecified";
        private const string PropertycustomDataType = "customDataType";
        private const string PropertydefaultValue = "defaultValue";
        private const string PropertydeleteConstraint = "deleteConstraint";
        private const string PropertydeleteConstraintSpecified = "deleteConstraintSpecified";
        private const string Propertydeprecated = "deprecated";
        private const string PropertydeprecatedSpecified = "deprecatedSpecified";
        private const string Propertydescription = "description";
        private const string PropertydisplayFormat = "displayFormat";
        private const string PropertyescapeMarkup = "escapeMarkup";
        private const string PropertyescapeMarkupSpecified = "escapeMarkupSpecified";
        private const string PropertyexternalDeveloperName = "externalDeveloperName";
        private const string PropertyexternalId = "externalId";
        private const string PropertyexternalIdSpecified = "externalIdSpecified";
        private const string Propertyformula = "formula";
        private const string PropertyformulaTreatBlanksAs = "formulaTreatBlanksAs";
        private const string PropertyformulaTreatBlanksAsSpecified = "formulaTreatBlanksAsSpecified";
        private const string PropertyinlineHelpText = "inlineHelpText";
        private const string PropertyisFilteringDisabled = "isFilteringDisabled";
        private const string PropertyisFilteringDisabledSpecified = "isFilteringDisabledSpecified";
        private const string PropertyisNameField = "isNameField";
        private const string PropertyisNameFieldSpecified = "isNameFieldSpecified";
        private const string PropertyisSortingDisabled = "isSortingDisabled";
        private const string PropertyisSortingDisabledSpecified = "isSortingDisabledSpecified";
        private const string Propertylabel = "label";
        private const string Propertylength = "length";
        private const string PropertylengthSpecified = "lengthSpecified";
        private const string PropertymaskChar = "maskChar";
        private const string PropertymaskCharSpecified = "maskCharSpecified";
        private const string PropertymaskType = "maskType";
        private const string PropertymaskTypeSpecified = "maskTypeSpecified";
        private const string Propertypicklist = "picklist";
        private const string PropertypopulateExistingRows = "populateExistingRows";
        private const string PropertypopulateExistingRowsSpecified = "populateExistingRowsSpecified";
        private const string Propertyprecision = "precision";
        private const string PropertyprecisionSpecified = "precisionSpecified";
        private const string PropertyreferenceTo = "referenceTo";
        private const string PropertyrelationshipLabel = "relationshipLabel";
        private const string PropertyrelationshipName = "relationshipName";
        private const string PropertyrelationshipOrder = "relationshipOrder";
        private const string PropertyrelationshipOrderSpecified = "relationshipOrderSpecified";
        private const string PropertyreparentableMasterDetail = "reparentableMasterDetail";
        private const string PropertyreparentableMasterDetailSpecified = "reparentableMasterDetailSpecified";
        private const string Propertyrequired = "required";
        private const string PropertyrequiredSpecified = "requiredSpecified";
        private const string PropertyrestrictedAdminField = "restrictedAdminField";
        private const string PropertyrestrictedAdminFieldSpecified = "restrictedAdminFieldSpecified";
        private const string Propertyscale = "scale";
        private const string PropertyscaleSpecified = "scaleSpecified";
        private const string PropertystartingNumber = "startingNumber";
        private const string PropertystartingNumberSpecified = "startingNumberSpecified";
        private const string PropertystripMarkup = "stripMarkup";
        private const string PropertystripMarkupSpecified = "stripMarkupSpecified";
        private const string PropertysummarizedField = "summarizedField";
        private const string PropertysummaryFilterItems = "summaryFilterItems";
        private const string PropertysummaryForeignKey = "summaryForeignKey";
        private const string PropertysummaryOperation = "summaryOperation";
        private const string PropertysummaryOperationSpecified = "summaryOperationSpecified";
        private const string PropertytrackFeedHistory = "trackFeedHistory";
        private const string PropertytrackFeedHistorySpecified = "trackFeedHistorySpecified";
        private const string PropertytrackHistory = "trackHistory";
        private const string PropertytrackHistorySpecified = "trackHistorySpecified";
        private const string Propertytype = "type";
        private const string Propertyunique = "unique";
        private const string PropertyuniqueSpecified = "uniqueSpecified";
        private const string PropertyvisibleLines = "visibleLines";
        private const string PropertyvisibleLinesSpecified = "visibleLinesSpecified";
        private const string PropertywriteRequiresMasterRead = "writeRequiresMasterRead";
        private const string PropertywriteRequiresMasterReadSpecified = "writeRequiresMasterReadSpecified";
        private const string FieldcaseSensitiveField = "caseSensitiveField";
        private const string FieldcaseSensitiveFieldSpecified = "caseSensitiveFieldSpecified";
        private const string FieldcustomDataTypeField = "customDataTypeField";
        private const string FielddefaultValueField = "defaultValueField";
        private const string FielddeleteConstraintField = "deleteConstraintField";
        private const string FielddeleteConstraintFieldSpecified = "deleteConstraintFieldSpecified";
        private const string FielddeprecatedField = "deprecatedField";
        private const string FielddeprecatedFieldSpecified = "deprecatedFieldSpecified";
        private const string FielddescriptionField = "descriptionField";
        private const string FielddisplayFormatField = "displayFormatField";
        private const string FieldescapeMarkupField = "escapeMarkupField";
        private const string FieldescapeMarkupFieldSpecified = "escapeMarkupFieldSpecified";
        private const string FieldexternalDeveloperNameField = "externalDeveloperNameField";
        private const string FieldexternalIdField = "externalIdField";
        private const string FieldexternalIdFieldSpecified = "externalIdFieldSpecified";
        private const string FieldformulaField = "formulaField";
        private const string FieldformulaTreatBlanksAsField = "formulaTreatBlanksAsField";
        private const string FieldformulaTreatBlanksAsFieldSpecified = "formulaTreatBlanksAsFieldSpecified";
        private const string FieldinlineHelpTextField = "inlineHelpTextField";
        private const string FieldisFilteringDisabledField = "isFilteringDisabledField";
        private const string FieldisFilteringDisabledFieldSpecified = "isFilteringDisabledFieldSpecified";
        private const string FieldisNameFieldField = "isNameFieldField";
        private const string FieldisNameFieldFieldSpecified = "isNameFieldFieldSpecified";
        private const string FieldisSortingDisabledField = "isSortingDisabledField";
        private const string FieldisSortingDisabledFieldSpecified = "isSortingDisabledFieldSpecified";
        private const string FieldlabelField = "labelField";
        private const string FieldlengthField = "lengthField";
        private const string FieldlengthFieldSpecified = "lengthFieldSpecified";
        private const string FieldmaskCharField = "maskCharField";
        private const string FieldmaskCharFieldSpecified = "maskCharFieldSpecified";
        private const string FieldmaskTypeField = "maskTypeField";
        private const string FieldmaskTypeFieldSpecified = "maskTypeFieldSpecified";
        private const string FieldpicklistField = "picklistField";
        private const string FieldpopulateExistingRowsField = "populateExistingRowsField";
        private const string FieldpopulateExistingRowsFieldSpecified = "populateExistingRowsFieldSpecified";
        private const string FieldprecisionField = "precisionField";
        private const string FieldprecisionFieldSpecified = "precisionFieldSpecified";
        private const string FieldreferenceToField = "referenceToField";
        private const string FieldrelationshipLabelField = "relationshipLabelField";
        private const string FieldrelationshipNameField = "relationshipNameField";
        private const string FieldrelationshipOrderField = "relationshipOrderField";
        private const string FieldrelationshipOrderFieldSpecified = "relationshipOrderFieldSpecified";
        private const string FieldreparentableMasterDetailField = "reparentableMasterDetailField";
        private const string FieldreparentableMasterDetailFieldSpecified = "reparentableMasterDetailFieldSpecified";
        private const string FieldrequiredField = "requiredField";
        private const string FieldrequiredFieldSpecified = "requiredFieldSpecified";
        private const string FieldrestrictedAdminFieldField = "restrictedAdminFieldField";
        private const string FieldrestrictedAdminFieldFieldSpecified = "restrictedAdminFieldFieldSpecified";
        private const string FieldscaleField = "scaleField";
        private const string FieldscaleFieldSpecified = "scaleFieldSpecified";
        private const string FieldstartingNumberField = "startingNumberField";
        private const string FieldstartingNumberFieldSpecified = "startingNumberFieldSpecified";
        private const string FieldstripMarkupField = "stripMarkupField";
        private const string FieldstripMarkupFieldSpecified = "stripMarkupFieldSpecified";
        private const string FieldsummarizedFieldField = "summarizedFieldField";
        private const string FieldsummaryFilterItemsField = "summaryFilterItemsField";
        private const string FieldsummaryForeignKeyField = "summaryForeignKeyField";
        private const string FieldsummaryOperationField = "summaryOperationField";
        private const string FieldsummaryOperationFieldSpecified = "summaryOperationFieldSpecified";
        private const string FieldtrackFeedHistoryField = "trackFeedHistoryField";
        private const string FieldtrackFeedHistoryFieldSpecified = "trackFeedHistoryFieldSpecified";
        private const string FieldtrackHistoryField = "trackHistoryField";
        private const string FieldtrackHistoryFieldSpecified = "trackHistoryFieldSpecified";
        private const string FieldtypeField = "typeField";
        private const string FielduniqueField = "uniqueField";
        private const string FielduniqueFieldSpecified = "uniqueFieldSpecified";
        private const string FieldvisibleLinesField = "visibleLinesField";
        private const string FieldvisibleLinesFieldSpecified = "visibleLinesFieldSpecified";
        private const string FieldwriteRequiresMasterReadField = "writeRequiresMasterReadField";
        private const string FieldwriteRequiresMasterReadFieldSpecified = "writeRequiresMasterReadFieldSpecified";
        private Type _customFieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomField _customFieldInstance;
        private CustomField _customFieldInstanceFixture;

        #region General Initializer : Class (CustomField) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomField" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customFieldInstanceType = typeof(CustomField);
            _customFieldInstanceFixture = Create(true);
            _customFieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomField)

        #region General Initializer : Class (CustomField) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomField" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycaseSensitive)]
        [TestCase(PropertycaseSensitiveSpecified)]
        [TestCase(PropertycustomDataType)]
        [TestCase(PropertydefaultValue)]
        [TestCase(PropertydeleteConstraint)]
        [TestCase(PropertydeleteConstraintSpecified)]
        [TestCase(Propertydeprecated)]
        [TestCase(PropertydeprecatedSpecified)]
        [TestCase(Propertydescription)]
        [TestCase(PropertydisplayFormat)]
        [TestCase(PropertyescapeMarkup)]
        [TestCase(PropertyescapeMarkupSpecified)]
        [TestCase(PropertyexternalDeveloperName)]
        [TestCase(PropertyexternalId)]
        [TestCase(PropertyexternalIdSpecified)]
        [TestCase(Propertyformula)]
        [TestCase(PropertyformulaTreatBlanksAs)]
        [TestCase(PropertyformulaTreatBlanksAsSpecified)]
        [TestCase(PropertyinlineHelpText)]
        [TestCase(PropertyisFilteringDisabled)]
        [TestCase(PropertyisFilteringDisabledSpecified)]
        [TestCase(PropertyisNameField)]
        [TestCase(PropertyisNameFieldSpecified)]
        [TestCase(PropertyisSortingDisabled)]
        [TestCase(PropertyisSortingDisabledSpecified)]
        [TestCase(Propertylabel)]
        [TestCase(Propertylength)]
        [TestCase(PropertylengthSpecified)]
        [TestCase(PropertymaskChar)]
        [TestCase(PropertymaskCharSpecified)]
        [TestCase(PropertymaskType)]
        [TestCase(PropertymaskTypeSpecified)]
        [TestCase(Propertypicklist)]
        [TestCase(PropertypopulateExistingRows)]
        [TestCase(PropertypopulateExistingRowsSpecified)]
        [TestCase(Propertyprecision)]
        [TestCase(PropertyprecisionSpecified)]
        [TestCase(PropertyreferenceTo)]
        [TestCase(PropertyrelationshipLabel)]
        [TestCase(PropertyrelationshipName)]
        [TestCase(PropertyrelationshipOrder)]
        [TestCase(PropertyrelationshipOrderSpecified)]
        [TestCase(PropertyreparentableMasterDetail)]
        [TestCase(PropertyreparentableMasterDetailSpecified)]
        [TestCase(Propertyrequired)]
        [TestCase(PropertyrequiredSpecified)]
        [TestCase(PropertyrestrictedAdminField)]
        [TestCase(PropertyrestrictedAdminFieldSpecified)]
        [TestCase(Propertyscale)]
        [TestCase(PropertyscaleSpecified)]
        [TestCase(PropertystartingNumber)]
        [TestCase(PropertystartingNumberSpecified)]
        [TestCase(PropertystripMarkup)]
        [TestCase(PropertystripMarkupSpecified)]
        [TestCase(PropertysummarizedField)]
        [TestCase(PropertysummaryFilterItems)]
        [TestCase(PropertysummaryForeignKey)]
        [TestCase(PropertysummaryOperation)]
        [TestCase(PropertysummaryOperationSpecified)]
        [TestCase(PropertytrackFeedHistory)]
        [TestCase(PropertytrackFeedHistorySpecified)]
        [TestCase(PropertytrackHistory)]
        [TestCase(PropertytrackHistorySpecified)]
        [TestCase(Propertytype)]
        [TestCase(Propertyunique)]
        [TestCase(PropertyuniqueSpecified)]
        [TestCase(PropertyvisibleLines)]
        [TestCase(PropertyvisibleLinesSpecified)]
        [TestCase(PropertywriteRequiresMasterRead)]
        [TestCase(PropertywriteRequiresMasterReadSpecified)]
        public void AUT_CustomField_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customFieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomField) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcaseSensitiveField)]
        [TestCase(FieldcaseSensitiveFieldSpecified)]
        [TestCase(FieldcustomDataTypeField)]
        [TestCase(FielddefaultValueField)]
        [TestCase(FielddeleteConstraintField)]
        [TestCase(FielddeleteConstraintFieldSpecified)]
        [TestCase(FielddeprecatedField)]
        [TestCase(FielddeprecatedFieldSpecified)]
        [TestCase(FielddescriptionField)]
        [TestCase(FielddisplayFormatField)]
        [TestCase(FieldescapeMarkupField)]
        [TestCase(FieldescapeMarkupFieldSpecified)]
        [TestCase(FieldexternalDeveloperNameField)]
        [TestCase(FieldexternalIdField)]
        [TestCase(FieldexternalIdFieldSpecified)]
        [TestCase(FieldformulaField)]
        [TestCase(FieldformulaTreatBlanksAsField)]
        [TestCase(FieldformulaTreatBlanksAsFieldSpecified)]
        [TestCase(FieldinlineHelpTextField)]
        [TestCase(FieldisFilteringDisabledField)]
        [TestCase(FieldisFilteringDisabledFieldSpecified)]
        [TestCase(FieldisNameFieldField)]
        [TestCase(FieldisNameFieldFieldSpecified)]
        [TestCase(FieldisSortingDisabledField)]
        [TestCase(FieldisSortingDisabledFieldSpecified)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlengthField)]
        [TestCase(FieldlengthFieldSpecified)]
        [TestCase(FieldmaskCharField)]
        [TestCase(FieldmaskCharFieldSpecified)]
        [TestCase(FieldmaskTypeField)]
        [TestCase(FieldmaskTypeFieldSpecified)]
        [TestCase(FieldpicklistField)]
        [TestCase(FieldpopulateExistingRowsField)]
        [TestCase(FieldpopulateExistingRowsFieldSpecified)]
        [TestCase(FieldprecisionField)]
        [TestCase(FieldprecisionFieldSpecified)]
        [TestCase(FieldreferenceToField)]
        [TestCase(FieldrelationshipLabelField)]
        [TestCase(FieldrelationshipNameField)]
        [TestCase(FieldrelationshipOrderField)]
        [TestCase(FieldrelationshipOrderFieldSpecified)]
        [TestCase(FieldreparentableMasterDetailField)]
        [TestCase(FieldreparentableMasterDetailFieldSpecified)]
        [TestCase(FieldrequiredField)]
        [TestCase(FieldrequiredFieldSpecified)]
        [TestCase(FieldrestrictedAdminFieldField)]
        [TestCase(FieldrestrictedAdminFieldFieldSpecified)]
        [TestCase(FieldscaleField)]
        [TestCase(FieldscaleFieldSpecified)]
        [TestCase(FieldstartingNumberField)]
        [TestCase(FieldstartingNumberFieldSpecified)]
        [TestCase(FieldstripMarkupField)]
        [TestCase(FieldstripMarkupFieldSpecified)]
        [TestCase(FieldsummarizedFieldField)]
        [TestCase(FieldsummaryFilterItemsField)]
        [TestCase(FieldsummaryForeignKeyField)]
        [TestCase(FieldsummaryOperationField)]
        [TestCase(FieldsummaryOperationFieldSpecified)]
        [TestCase(FieldtrackFeedHistoryField)]
        [TestCase(FieldtrackFeedHistoryFieldSpecified)]
        [TestCase(FieldtrackHistoryField)]
        [TestCase(FieldtrackHistoryFieldSpecified)]
        [TestCase(FieldtypeField)]
        [TestCase(FielduniqueField)]
        [TestCase(FielduniqueFieldSpecified)]
        [TestCase(FieldvisibleLinesField)]
        [TestCase(FieldvisibleLinesFieldSpecified)]
        [TestCase(FieldwriteRequiresMasterReadField)]
        [TestCase(FieldwriteRequiresMasterReadFieldSpecified)]
        public void AUT_CustomField_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customFieldInstanceFixture, 
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
        ///     Class (<see cref="CustomField" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomField_Is_Instance_Present_Test()
        {
            // Assert
            _customFieldInstanceType.ShouldNotBeNull();
            _customFieldInstance.ShouldNotBeNull();
            _customFieldInstanceFixture.ShouldNotBeNull();
            _customFieldInstance.ShouldBeAssignableTo<CustomField>();
            _customFieldInstanceFixture.ShouldBeAssignableTo<CustomField>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomField) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomField_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomField instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customFieldInstanceType.ShouldNotBeNull();
            _customFieldInstance.ShouldNotBeNull();
            _customFieldInstanceFixture.ShouldNotBeNull();
            _customFieldInstance.ShouldBeAssignableTo<CustomField>();
            _customFieldInstanceFixture.ShouldBeAssignableTo<CustomField>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomField) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertycaseSensitive)]
        [TestCaseGeneric(typeof(bool) , PropertycaseSensitiveSpecified)]
        [TestCaseGeneric(typeof(string) , PropertycustomDataType)]
        [TestCaseGeneric(typeof(string) , PropertydefaultValue)]
        [TestCaseGeneric(typeof(DeleteConstraint) , PropertydeleteConstraint)]
        [TestCaseGeneric(typeof(bool) , PropertydeleteConstraintSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertydeprecated)]
        [TestCaseGeneric(typeof(bool) , PropertydeprecatedSpecified)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertydisplayFormat)]
        [TestCaseGeneric(typeof(bool) , PropertyescapeMarkup)]
        [TestCaseGeneric(typeof(bool) , PropertyescapeMarkupSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyexternalDeveloperName)]
        [TestCaseGeneric(typeof(bool) , PropertyexternalId)]
        [TestCaseGeneric(typeof(bool) , PropertyexternalIdSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyformula)]
        [TestCaseGeneric(typeof(TreatBlanksAs) , PropertyformulaTreatBlanksAs)]
        [TestCaseGeneric(typeof(bool) , PropertyformulaTreatBlanksAsSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyinlineHelpText)]
        [TestCaseGeneric(typeof(bool) , PropertyisFilteringDisabled)]
        [TestCaseGeneric(typeof(bool) , PropertyisFilteringDisabledSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyisNameField)]
        [TestCaseGeneric(typeof(bool) , PropertyisNameFieldSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyisSortingDisabled)]
        [TestCaseGeneric(typeof(bool) , PropertyisSortingDisabledSpecified)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(int) , Propertylength)]
        [TestCaseGeneric(typeof(bool) , PropertylengthSpecified)]
        [TestCaseGeneric(typeof(EncryptedFieldMaskChar) , PropertymaskChar)]
        [TestCaseGeneric(typeof(bool) , PropertymaskCharSpecified)]
        [TestCaseGeneric(typeof(EncryptedFieldMaskType) , PropertymaskType)]
        [TestCaseGeneric(typeof(bool) , PropertymaskTypeSpecified)]
        [TestCaseGeneric(typeof(Picklist) , Propertypicklist)]
        [TestCaseGeneric(typeof(bool) , PropertypopulateExistingRows)]
        [TestCaseGeneric(typeof(bool) , PropertypopulateExistingRowsSpecified)]
        [TestCaseGeneric(typeof(int) , Propertyprecision)]
        [TestCaseGeneric(typeof(bool) , PropertyprecisionSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyreferenceTo)]
        [TestCaseGeneric(typeof(string) , PropertyrelationshipLabel)]
        [TestCaseGeneric(typeof(string) , PropertyrelationshipName)]
        [TestCaseGeneric(typeof(int) , PropertyrelationshipOrder)]
        [TestCaseGeneric(typeof(bool) , PropertyrelationshipOrderSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyreparentableMasterDetail)]
        [TestCaseGeneric(typeof(bool) , PropertyreparentableMasterDetailSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertyrequired)]
        [TestCaseGeneric(typeof(bool) , PropertyrequiredSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyrestrictedAdminField)]
        [TestCaseGeneric(typeof(bool) , PropertyrestrictedAdminFieldSpecified)]
        [TestCaseGeneric(typeof(int) , Propertyscale)]
        [TestCaseGeneric(typeof(bool) , PropertyscaleSpecified)]
        [TestCaseGeneric(typeof(int) , PropertystartingNumber)]
        [TestCaseGeneric(typeof(bool) , PropertystartingNumberSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertystripMarkup)]
        [TestCaseGeneric(typeof(bool) , PropertystripMarkupSpecified)]
        [TestCaseGeneric(typeof(string) , PropertysummarizedField)]
        [TestCaseGeneric(typeof(FilterItem[]) , PropertysummaryFilterItems)]
        [TestCaseGeneric(typeof(string) , PropertysummaryForeignKey)]
        [TestCaseGeneric(typeof(SummaryOperations) , PropertysummaryOperation)]
        [TestCaseGeneric(typeof(bool) , PropertysummaryOperationSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertytrackFeedHistory)]
        [TestCaseGeneric(typeof(bool) , PropertytrackFeedHistorySpecified)]
        [TestCaseGeneric(typeof(bool) , PropertytrackHistory)]
        [TestCaseGeneric(typeof(bool) , PropertytrackHistorySpecified)]
        [TestCaseGeneric(typeof(FieldType) , Propertytype)]
        [TestCaseGeneric(typeof(bool) , Propertyunique)]
        [TestCaseGeneric(typeof(bool) , PropertyuniqueSpecified)]
        [TestCaseGeneric(typeof(int) , PropertyvisibleLines)]
        [TestCaseGeneric(typeof(bool) , PropertyvisibleLinesSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertywriteRequiresMasterRead)]
        [TestCaseGeneric(typeof(bool) , PropertywriteRequiresMasterReadSpecified)]
        public void AUT_CustomField_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomField, T>(_customFieldInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (caseSensitive) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_caseSensitive_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (caseSensitiveSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_caseSensitiveSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseSensitiveSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (customDataType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_customDataType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomDataType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (defaultValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_defaultValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (deleteConstraint) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_deleteConstraint_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeleteConstraint);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (deleteConstraintSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_deleteConstraintSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeleteConstraintSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (deprecated) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_deprecated_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydeprecated);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (deprecatedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_deprecatedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeprecatedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (displayFormat) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_displayFormat_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayFormat);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (escapeMarkup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_escapeMarkup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyescapeMarkup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (escapeMarkupSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_escapeMarkupSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyescapeMarkupSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (externalDeveloperName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_externalDeveloperName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexternalDeveloperName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (externalId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_externalId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (externalIdSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_externalIdSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (formula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_formula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyformula);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (formulaTreatBlanksAs) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_formulaTreatBlanksAs_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyformulaTreatBlanksAs);
            Action currentAction = () => propertyInfo.SetValue(_customFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (formulaTreatBlanksAs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_formulaTreatBlanksAs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyformulaTreatBlanksAs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (formulaTreatBlanksAsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_formulaTreatBlanksAsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyformulaTreatBlanksAsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (inlineHelpText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_inlineHelpText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (isFilteringDisabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_isFilteringDisabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisFilteringDisabled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (isFilteringDisabledSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_isFilteringDisabledSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisFilteringDisabledSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (isNameField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_isNameField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisNameField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (isNameFieldSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_isNameFieldSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisNameFieldSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (isSortingDisabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_isSortingDisabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisSortingDisabled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (isSortingDisabledSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_isSortingDisabledSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisSortingDisabledSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (length) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_length_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (lengthSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_lengthSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylengthSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (maskChar) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_maskChar_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertymaskChar);
            Action currentAction = () => propertyInfo.SetValue(_customFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (maskChar) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_maskChar_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymaskChar);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (maskCharSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_maskCharSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymaskCharSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (maskType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_maskType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertymaskType);
            Action currentAction = () => propertyInfo.SetValue(_customFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (maskType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_maskType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymaskType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (maskTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_maskTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymaskTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (picklist) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_picklist_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertypicklist);
            Action currentAction = () => propertyInfo.SetValue(_customFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (picklist) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_picklist_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (populateExistingRows) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_populateExistingRows_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypopulateExistingRows);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (populateExistingRowsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_populateExistingRowsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypopulateExistingRowsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (precision) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_precision_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (precisionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_precisionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyprecisionSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (referenceTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_referenceTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (relationshipLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_relationshipLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelationshipLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (relationshipName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_relationshipName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (relationshipOrder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_relationshipOrder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (relationshipOrderSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_relationshipOrderSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (reparentableMasterDetail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_reparentableMasterDetail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreparentableMasterDetail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (reparentableMasterDetailSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_reparentableMasterDetailSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreparentableMasterDetailSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (required) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_required_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrequired);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (requiredSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_requiredSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrequiredSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (restrictedAdminField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_restrictedAdminField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrestrictedAdminField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (restrictedAdminFieldSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_restrictedAdminFieldSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrestrictedAdminFieldSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (scale) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_scale_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (scaleSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_scaleSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyscaleSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (startingNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_startingNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystartingNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (startingNumberSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_startingNumberSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystartingNumberSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (stripMarkup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_stripMarkup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystripMarkup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (stripMarkupSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_stripMarkupSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystripMarkupSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (summarizedField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_summarizedField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummarizedField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (summaryFilterItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_summaryFilterItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysummaryFilterItems);
            Action currentAction = () => propertyInfo.SetValue(_customFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (summaryFilterItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_summaryFilterItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryFilterItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (summaryForeignKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_summaryForeignKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryForeignKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (summaryOperation) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_summaryOperation_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysummaryOperation);
            Action currentAction = () => propertyInfo.SetValue(_customFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (summaryOperation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_summaryOperation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryOperation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (summaryOperationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_summaryOperationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryOperationSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (trackFeedHistory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_trackFeedHistory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytrackFeedHistory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (trackFeedHistorySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_trackFeedHistorySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytrackFeedHistorySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (trackHistory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_trackHistory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytrackHistory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (trackHistorySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_trackHistorySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytrackHistorySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytype);
            Action currentAction = () => propertyInfo.SetValue(_customFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (unique) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_unique_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (uniqueSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_uniqueSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuniqueSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (visibleLines) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_visibleLines_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyvisibleLines);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (visibleLinesSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_visibleLinesSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyvisibleLinesSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomField) => Property (writeRequiresMasterRead) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_writeRequiresMasterRead_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomField) => Property (writeRequiresMasterReadSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomField_Public_Class_writeRequiresMasterReadSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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