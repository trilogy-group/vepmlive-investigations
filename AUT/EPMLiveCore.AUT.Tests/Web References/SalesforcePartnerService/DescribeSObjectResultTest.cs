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
using DescribeSObjectResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeSObjectResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeSObjectResultTest : AbstractBaseSetupTypedTest<DescribeSObjectResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeSObjectResult) Initializer

        private const string Propertyactivateable = "activateable";
        private const string PropertychildRelationships = "childRelationships";
        private const string Propertycreateable = "createable";
        private const string Propertycustom = "custom";
        private const string PropertycustomSetting = "customSetting";
        private const string Propertydeletable = "deletable";
        private const string PropertydeprecatedAndHidden = "deprecatedAndHidden";
        private const string PropertyfeedEnabled = "feedEnabled";
        private const string Propertyfields = "fields";
        private const string PropertykeyPrefix = "keyPrefix";
        private const string Propertylabel = "label";
        private const string PropertylabelPlural = "labelPlural";
        private const string Propertylayoutable = "layoutable";
        private const string Propertymergeable = "mergeable";
        private const string Propertyname = "name";
        private const string Propertyqueryable = "queryable";
        private const string PropertyrecordTypeInfos = "recordTypeInfos";
        private const string Propertyreplicateable = "replicateable";
        private const string Propertyretrieveable = "retrieveable";
        private const string Propertysearchable = "searchable";
        private const string Propertytriggerable = "triggerable";
        private const string PropertytriggerableSpecified = "triggerableSpecified";
        private const string Propertyundeletable = "undeletable";
        private const string Propertyupdateable = "updateable";
        private const string PropertyurlDetail = "urlDetail";
        private const string PropertyurlEdit = "urlEdit";
        private const string PropertyurlNew = "urlNew";
        private const string FieldactivateableField = "activateableField";
        private const string FieldchildRelationshipsField = "childRelationshipsField";
        private const string FieldcreateableField = "createableField";
        private const string FieldcustomField = "customField";
        private const string FieldcustomSettingField = "customSettingField";
        private const string FielddeletableField = "deletableField";
        private const string FielddeprecatedAndHiddenField = "deprecatedAndHiddenField";
        private const string FieldfeedEnabledField = "feedEnabledField";
        private const string FieldfieldsField = "fieldsField";
        private const string FieldkeyPrefixField = "keyPrefixField";
        private const string FieldlabelField = "labelField";
        private const string FieldlabelPluralField = "labelPluralField";
        private const string FieldlayoutableField = "layoutableField";
        private const string FieldmergeableField = "mergeableField";
        private const string FieldnameField = "nameField";
        private const string FieldqueryableField = "queryableField";
        private const string FieldrecordTypeInfosField = "recordTypeInfosField";
        private const string FieldreplicateableField = "replicateableField";
        private const string FieldretrieveableField = "retrieveableField";
        private const string FieldsearchableField = "searchableField";
        private const string FieldtriggerableField = "triggerableField";
        private const string FieldtriggerableFieldSpecified = "triggerableFieldSpecified";
        private const string FieldundeletableField = "undeletableField";
        private const string FieldupdateableField = "updateableField";
        private const string FieldurlDetailField = "urlDetailField";
        private const string FieldurlEditField = "urlEditField";
        private const string FieldurlNewField = "urlNewField";
        private Type _describeSObjectResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeSObjectResult _describeSObjectResultInstance;
        private DescribeSObjectResult _describeSObjectResultInstanceFixture;

        #region General Initializer : Class (DescribeSObjectResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeSObjectResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeSObjectResultInstanceType = typeof(DescribeSObjectResult);
            _describeSObjectResultInstanceFixture = Create(true);
            _describeSObjectResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeSObjectResult)

        #region General Initializer : Class (DescribeSObjectResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSObjectResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactivateable)]
        [TestCase(PropertychildRelationships)]
        [TestCase(Propertycreateable)]
        [TestCase(Propertycustom)]
        [TestCase(PropertycustomSetting)]
        [TestCase(Propertydeletable)]
        [TestCase(PropertydeprecatedAndHidden)]
        [TestCase(PropertyfeedEnabled)]
        [TestCase(Propertyfields)]
        [TestCase(PropertykeyPrefix)]
        [TestCase(Propertylabel)]
        [TestCase(PropertylabelPlural)]
        [TestCase(Propertylayoutable)]
        [TestCase(Propertymergeable)]
        [TestCase(Propertyname)]
        [TestCase(Propertyqueryable)]
        [TestCase(PropertyrecordTypeInfos)]
        [TestCase(Propertyreplicateable)]
        [TestCase(Propertyretrieveable)]
        [TestCase(Propertysearchable)]
        [TestCase(Propertytriggerable)]
        [TestCase(PropertytriggerableSpecified)]
        [TestCase(Propertyundeletable)]
        [TestCase(Propertyupdateable)]
        [TestCase(PropertyurlDetail)]
        [TestCase(PropertyurlEdit)]
        [TestCase(PropertyurlNew)]
        public void AUT_DescribeSObjectResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeSObjectResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeSObjectResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSObjectResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactivateableField)]
        [TestCase(FieldchildRelationshipsField)]
        [TestCase(FieldcreateableField)]
        [TestCase(FieldcustomField)]
        [TestCase(FieldcustomSettingField)]
        [TestCase(FielddeletableField)]
        [TestCase(FielddeprecatedAndHiddenField)]
        [TestCase(FieldfeedEnabledField)]
        [TestCase(FieldfieldsField)]
        [TestCase(FieldkeyPrefixField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlabelPluralField)]
        [TestCase(FieldlayoutableField)]
        [TestCase(FieldmergeableField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldqueryableField)]
        [TestCase(FieldrecordTypeInfosField)]
        [TestCase(FieldreplicateableField)]
        [TestCase(FieldretrieveableField)]
        [TestCase(FieldsearchableField)]
        [TestCase(FieldtriggerableField)]
        [TestCase(FieldtriggerableFieldSpecified)]
        [TestCase(FieldundeletableField)]
        [TestCase(FieldupdateableField)]
        [TestCase(FieldurlDetailField)]
        [TestCase(FieldurlEditField)]
        [TestCase(FieldurlNewField)]
        public void AUT_DescribeSObjectResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeSObjectResultInstanceFixture, 
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
        ///     Class (<see cref="DescribeSObjectResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeSObjectResult_Is_Instance_Present_Test()
        {
            // Assert
            _describeSObjectResultInstanceType.ShouldNotBeNull();
            _describeSObjectResultInstance.ShouldNotBeNull();
            _describeSObjectResultInstanceFixture.ShouldNotBeNull();
            _describeSObjectResultInstance.ShouldBeAssignableTo<DescribeSObjectResult>();
            _describeSObjectResultInstanceFixture.ShouldBeAssignableTo<DescribeSObjectResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeSObjectResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeSObjectResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeSObjectResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeSObjectResultInstanceType.ShouldNotBeNull();
            _describeSObjectResultInstance.ShouldNotBeNull();
            _describeSObjectResultInstanceFixture.ShouldNotBeNull();
            _describeSObjectResultInstance.ShouldBeAssignableTo<DescribeSObjectResult>();
            _describeSObjectResultInstanceFixture.ShouldBeAssignableTo<DescribeSObjectResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeSObjectResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactivateable)]
        [TestCaseGeneric(typeof(ChildRelationship[]) , PropertychildRelationships)]
        [TestCaseGeneric(typeof(bool) , Propertycreateable)]
        [TestCaseGeneric(typeof(bool) , Propertycustom)]
        [TestCaseGeneric(typeof(bool) , PropertycustomSetting)]
        [TestCaseGeneric(typeof(bool) , Propertydeletable)]
        [TestCaseGeneric(typeof(bool) , PropertydeprecatedAndHidden)]
        [TestCaseGeneric(typeof(bool) , PropertyfeedEnabled)]
        [TestCaseGeneric(typeof(Field[]) , Propertyfields)]
        [TestCaseGeneric(typeof(string) , PropertykeyPrefix)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , PropertylabelPlural)]
        [TestCaseGeneric(typeof(bool) , Propertylayoutable)]
        [TestCaseGeneric(typeof(bool) , Propertymergeable)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(bool) , Propertyqueryable)]
        [TestCaseGeneric(typeof(RecordTypeInfo[]) , PropertyrecordTypeInfos)]
        [TestCaseGeneric(typeof(bool) , Propertyreplicateable)]
        [TestCaseGeneric(typeof(bool) , Propertyretrieveable)]
        [TestCaseGeneric(typeof(bool) , Propertysearchable)]
        [TestCaseGeneric(typeof(bool) , Propertytriggerable)]
        [TestCaseGeneric(typeof(bool) , PropertytriggerableSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertyundeletable)]
        [TestCaseGeneric(typeof(bool) , Propertyupdateable)]
        [TestCaseGeneric(typeof(string) , PropertyurlDetail)]
        [TestCaseGeneric(typeof(string) , PropertyurlEdit)]
        [TestCaseGeneric(typeof(string) , PropertyurlNew)]
        public void AUT_DescribeSObjectResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeSObjectResult, T>(_describeSObjectResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (activateable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_activateable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyactivateable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (childRelationships) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_childRelationships_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertychildRelationships);
            Action currentAction = () => propertyInfo.SetValue(_describeSObjectResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (childRelationships) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_childRelationships_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychildRelationships);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (createable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_createable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (custom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_custom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (customSetting) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_customSetting_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomSetting);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (deletable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_deletable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydeletable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (deprecatedAndHidden) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_deprecatedAndHidden_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (feedEnabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_feedEnabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfeedEnabled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (fields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_fields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfields);
            Action currentAction = () => propertyInfo.SetValue(_describeSObjectResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (fields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_fields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (keyPrefix) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_keyPrefix_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertykeyPrefix);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (labelPlural) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_labelPlural_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylabelPlural);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (layoutable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_layoutable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylayoutable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (mergeable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_mergeable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymergeable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (queryable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_queryable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyqueryable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (recordTypeInfos) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_recordTypeInfos_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrecordTypeInfos);
            Action currentAction = () => propertyInfo.SetValue(_describeSObjectResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (recordTypeInfos) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_recordTypeInfos_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordTypeInfos);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (replicateable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_replicateable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyreplicateable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (retrieveable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_retrieveable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyretrieveable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (searchable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_searchable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysearchable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (triggerable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_triggerable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytriggerable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (triggerableSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_triggerableSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytriggerableSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (undeletable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_undeletable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyundeletable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (updateable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_updateable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (urlDetail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_urlDetail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyurlDetail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (urlEdit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_urlEdit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyurlEdit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSObjectResult) => Property (urlNew) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSObjectResult_Public_Class_urlNew_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyurlNew);

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