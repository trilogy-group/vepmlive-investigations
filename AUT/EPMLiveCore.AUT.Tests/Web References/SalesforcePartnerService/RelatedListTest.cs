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
using RelatedList = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.RelatedList" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RelatedListTest : AbstractBaseSetupTypedTest<RelatedList>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RelatedList) Initializer

        private const string Propertycolumns = "columns";
        private const string Propertycustom = "custom";
        private const string Propertyfield = "field";
        private const string Propertylabel = "label";
        private const string PropertylimitRows = "limitRows";
        private const string Propertyname = "name";
        private const string Propertysobject = "sobject";
        private const string Propertysort = "sort";
        private const string FieldcolumnsField = "columnsField";
        private const string FieldcustomField = "customField";
        private const string FieldfieldField = "fieldField";
        private const string FieldlabelField = "labelField";
        private const string FieldlimitRowsField = "limitRowsField";
        private const string FieldnameField = "nameField";
        private const string FieldsobjectField = "sobjectField";
        private const string FieldsortField = "sortField";
        private Type _relatedListInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RelatedList _relatedListInstance;
        private RelatedList _relatedListInstanceFixture;

        #region General Initializer : Class (RelatedList) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RelatedList" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _relatedListInstanceType = typeof(RelatedList);
            _relatedListInstanceFixture = Create(true);
            _relatedListInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RelatedList)

        #region General Initializer : Class (RelatedList) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RelatedList" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycolumns)]
        [TestCase(Propertycustom)]
        [TestCase(Propertyfield)]
        [TestCase(Propertylabel)]
        [TestCase(PropertylimitRows)]
        [TestCase(Propertyname)]
        [TestCase(Propertysobject)]
        [TestCase(Propertysort)]
        public void AUT_RelatedList_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_relatedListInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RelatedList) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RelatedList" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcolumnsField)]
        [TestCase(FieldcustomField)]
        [TestCase(FieldfieldField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlimitRowsField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldsobjectField)]
        [TestCase(FieldsortField)]
        public void AUT_RelatedList_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_relatedListInstanceFixture, 
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
        ///     Class (<see cref="RelatedList" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RelatedList_Is_Instance_Present_Test()
        {
            // Assert
            _relatedListInstanceType.ShouldNotBeNull();
            _relatedListInstance.ShouldNotBeNull();
            _relatedListInstanceFixture.ShouldNotBeNull();
            _relatedListInstance.ShouldBeAssignableTo<RelatedList>();
            _relatedListInstanceFixture.ShouldBeAssignableTo<RelatedList>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RelatedList) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RelatedList_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RelatedList instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _relatedListInstanceType.ShouldNotBeNull();
            _relatedListInstance.ShouldNotBeNull();
            _relatedListInstanceFixture.ShouldNotBeNull();
            _relatedListInstance.ShouldBeAssignableTo<RelatedList>();
            _relatedListInstanceFixture.ShouldBeAssignableTo<RelatedList>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RelatedList) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(RelatedListColumn[]) , Propertycolumns)]
        [TestCaseGeneric(typeof(bool) , Propertycustom)]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(int) , PropertylimitRows)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(string) , Propertysobject)]
        [TestCaseGeneric(typeof(RelatedListSort[]) , Propertysort)]
        public void AUT_RelatedList_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RelatedList, T>(_relatedListInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RelatedList) => Property (columns) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedList_columns_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycolumns);
            Action currentAction = () => propertyInfo.SetValue(_relatedListInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RelatedList) => Property (columns) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedList_Public_Class_columns_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycolumns);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedList) => Property (custom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedList_Public_Class_custom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RelatedList) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedList_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedList) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedList_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RelatedList) => Property (limitRows) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedList_Public_Class_limitRows_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylimitRows);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedList) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedList_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RelatedList) => Property (sobject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedList_Public_Class_sobject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysobject);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedList) => Property (sort) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedList_sort_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysort);
            Action currentAction = () => propertyInfo.SetValue(_relatedListInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RelatedList) => Property (sort) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedList_Public_Class_sort_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysort);

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