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
using DescribeGlobalSObjectResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeGlobalSObjectResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeGlobalSObjectResultTest : AbstractBaseSetupTypedTest<DescribeGlobalSObjectResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeGlobalSObjectResult) Initializer

        private const string Propertyactivateable = "activateable";
        private const string Propertycreateable = "createable";
        private const string Propertycustom = "custom";
        private const string PropertycustomSetting = "customSetting";
        private const string Propertydeletable = "deletable";
        private const string PropertydeprecatedAndHidden = "deprecatedAndHidden";
        private const string PropertyfeedEnabled = "feedEnabled";
        private const string PropertykeyPrefix = "keyPrefix";
        private const string Propertylabel = "label";
        private const string PropertylabelPlural = "labelPlural";
        private const string Propertylayoutable = "layoutable";
        private const string Propertymergeable = "mergeable";
        private const string Propertyname = "name";
        private const string Propertyqueryable = "queryable";
        private const string Propertyreplicateable = "replicateable";
        private const string Propertyretrieveable = "retrieveable";
        private const string Propertysearchable = "searchable";
        private const string Propertytriggerable = "triggerable";
        private const string Propertyundeletable = "undeletable";
        private const string Propertyupdateable = "updateable";
        private const string FieldactivateableField = "activateableField";
        private const string FieldcreateableField = "createableField";
        private const string FieldcustomField = "customField";
        private const string FieldcustomSettingField = "customSettingField";
        private const string FielddeletableField = "deletableField";
        private const string FielddeprecatedAndHiddenField = "deprecatedAndHiddenField";
        private const string FieldfeedEnabledField = "feedEnabledField";
        private const string FieldkeyPrefixField = "keyPrefixField";
        private const string FieldlabelField = "labelField";
        private const string FieldlabelPluralField = "labelPluralField";
        private const string FieldlayoutableField = "layoutableField";
        private const string FieldmergeableField = "mergeableField";
        private const string FieldnameField = "nameField";
        private const string FieldqueryableField = "queryableField";
        private const string FieldreplicateableField = "replicateableField";
        private const string FieldretrieveableField = "retrieveableField";
        private const string FieldsearchableField = "searchableField";
        private const string FieldtriggerableField = "triggerableField";
        private const string FieldundeletableField = "undeletableField";
        private const string FieldupdateableField = "updateableField";
        private Type _describeGlobalSObjectResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeGlobalSObjectResult _describeGlobalSObjectResultInstance;
        private DescribeGlobalSObjectResult _describeGlobalSObjectResultInstanceFixture;

        #region General Initializer : Class (DescribeGlobalSObjectResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeGlobalSObjectResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeGlobalSObjectResultInstanceType = typeof(DescribeGlobalSObjectResult);
            _describeGlobalSObjectResultInstanceFixture = Create(true);
            _describeGlobalSObjectResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeGlobalSObjectResult)

        #region General Initializer : Class (DescribeGlobalSObjectResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeGlobalSObjectResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactivateable)]
        [TestCase(Propertycreateable)]
        [TestCase(Propertycustom)]
        [TestCase(PropertycustomSetting)]
        [TestCase(Propertydeletable)]
        [TestCase(PropertydeprecatedAndHidden)]
        [TestCase(PropertyfeedEnabled)]
        [TestCase(PropertykeyPrefix)]
        [TestCase(Propertylabel)]
        [TestCase(PropertylabelPlural)]
        [TestCase(Propertylayoutable)]
        [TestCase(Propertymergeable)]
        [TestCase(Propertyname)]
        [TestCase(Propertyqueryable)]
        [TestCase(Propertyreplicateable)]
        [TestCase(Propertyretrieveable)]
        [TestCase(Propertysearchable)]
        [TestCase(Propertytriggerable)]
        [TestCase(Propertyundeletable)]
        [TestCase(Propertyupdateable)]
        public void AUT_DescribeGlobalSObjectResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeGlobalSObjectResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeGlobalSObjectResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeGlobalSObjectResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactivateableField)]
        [TestCase(FieldcreateableField)]
        [TestCase(FieldcustomField)]
        [TestCase(FieldcustomSettingField)]
        [TestCase(FielddeletableField)]
        [TestCase(FielddeprecatedAndHiddenField)]
        [TestCase(FieldfeedEnabledField)]
        [TestCase(FieldkeyPrefixField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlabelPluralField)]
        [TestCase(FieldlayoutableField)]
        [TestCase(FieldmergeableField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldqueryableField)]
        [TestCase(FieldreplicateableField)]
        [TestCase(FieldretrieveableField)]
        [TestCase(FieldsearchableField)]
        [TestCase(FieldtriggerableField)]
        [TestCase(FieldundeletableField)]
        [TestCase(FieldupdateableField)]
        public void AUT_DescribeGlobalSObjectResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeGlobalSObjectResultInstanceFixture, 
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
        ///     Class (<see cref="DescribeGlobalSObjectResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeGlobalSObjectResult_Is_Instance_Present_Test()
        {
            // Assert
            _describeGlobalSObjectResultInstanceType.ShouldNotBeNull();
            _describeGlobalSObjectResultInstance.ShouldNotBeNull();
            _describeGlobalSObjectResultInstanceFixture.ShouldNotBeNull();
            _describeGlobalSObjectResultInstance.ShouldBeAssignableTo<DescribeGlobalSObjectResult>();
            _describeGlobalSObjectResultInstanceFixture.ShouldBeAssignableTo<DescribeGlobalSObjectResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeGlobalSObjectResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeGlobalSObjectResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeGlobalSObjectResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeGlobalSObjectResultInstanceType.ShouldNotBeNull();
            _describeGlobalSObjectResultInstance.ShouldNotBeNull();
            _describeGlobalSObjectResultInstanceFixture.ShouldNotBeNull();
            _describeGlobalSObjectResultInstance.ShouldBeAssignableTo<DescribeGlobalSObjectResult>();
            _describeGlobalSObjectResultInstanceFixture.ShouldBeAssignableTo<DescribeGlobalSObjectResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactivateable)]
        [TestCaseGeneric(typeof(bool) , Propertycreateable)]
        [TestCaseGeneric(typeof(bool) , Propertycustom)]
        [TestCaseGeneric(typeof(bool) , PropertycustomSetting)]
        [TestCaseGeneric(typeof(bool) , Propertydeletable)]
        [TestCaseGeneric(typeof(bool) , PropertydeprecatedAndHidden)]
        [TestCaseGeneric(typeof(bool) , PropertyfeedEnabled)]
        [TestCaseGeneric(typeof(string) , PropertykeyPrefix)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , PropertylabelPlural)]
        [TestCaseGeneric(typeof(bool) , Propertylayoutable)]
        [TestCaseGeneric(typeof(bool) , Propertymergeable)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(bool) , Propertyqueryable)]
        [TestCaseGeneric(typeof(bool) , Propertyreplicateable)]
        [TestCaseGeneric(typeof(bool) , Propertyretrieveable)]
        [TestCaseGeneric(typeof(bool) , Propertysearchable)]
        [TestCaseGeneric(typeof(bool) , Propertytriggerable)]
        [TestCaseGeneric(typeof(bool) , Propertyundeletable)]
        [TestCaseGeneric(typeof(bool) , Propertyupdateable)]
        public void AUT_DescribeGlobalSObjectResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeGlobalSObjectResult, T>(_describeGlobalSObjectResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (activateable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_activateable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (createable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_createable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (custom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_custom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (customSetting) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_customSetting_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (deletable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_deletable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (deprecatedAndHidden) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_deprecatedAndHidden_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (feedEnabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_feedEnabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (keyPrefix) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_keyPrefix_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (labelPlural) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_labelPlural_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (layoutable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_layoutable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (mergeable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_mergeable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (queryable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_queryable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (replicateable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_replicateable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (retrieveable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_retrieveable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (searchable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_searchable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (triggerable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_triggerable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (undeletable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_undeletable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeGlobalSObjectResult) => Property (updateable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeGlobalSObjectResult_Public_Class_updateable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}