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
using RecordTypeMapping = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.RecordTypeMapping" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RecordTypeMappingTest : AbstractBaseSetupTypedTest<RecordTypeMapping>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RecordTypeMapping) Initializer

        private const string Propertyavailable = "available";
        private const string PropertydefaultRecordTypeMapping = "defaultRecordTypeMapping";
        private const string PropertylayoutId = "layoutId";
        private const string Propertyname = "name";
        private const string PropertypicklistsForRecordType = "picklistsForRecordType";
        private const string PropertyrecordTypeId = "recordTypeId";
        private const string FieldavailableField = "availableField";
        private const string FielddefaultRecordTypeMappingField = "defaultRecordTypeMappingField";
        private const string FieldlayoutIdField = "layoutIdField";
        private const string FieldnameField = "nameField";
        private const string FieldpicklistsForRecordTypeField = "picklistsForRecordTypeField";
        private const string FieldrecordTypeIdField = "recordTypeIdField";
        private Type _recordTypeMappingInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RecordTypeMapping _recordTypeMappingInstance;
        private RecordTypeMapping _recordTypeMappingInstanceFixture;

        #region General Initializer : Class (RecordTypeMapping) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RecordTypeMapping" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _recordTypeMappingInstanceType = typeof(RecordTypeMapping);
            _recordTypeMappingInstanceFixture = Create(true);
            _recordTypeMappingInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RecordTypeMapping)

        #region General Initializer : Class (RecordTypeMapping) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RecordTypeMapping" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyavailable)]
        [TestCase(PropertydefaultRecordTypeMapping)]
        [TestCase(PropertylayoutId)]
        [TestCase(Propertyname)]
        [TestCase(PropertypicklistsForRecordType)]
        [TestCase(PropertyrecordTypeId)]
        public void AUT_RecordTypeMapping_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_recordTypeMappingInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RecordTypeMapping) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RecordTypeMapping" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldavailableField)]
        [TestCase(FielddefaultRecordTypeMappingField)]
        [TestCase(FieldlayoutIdField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldpicklistsForRecordTypeField)]
        [TestCase(FieldrecordTypeIdField)]
        public void AUT_RecordTypeMapping_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_recordTypeMappingInstanceFixture, 
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
        ///     Class (<see cref="RecordTypeMapping" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RecordTypeMapping_Is_Instance_Present_Test()
        {
            // Assert
            _recordTypeMappingInstanceType.ShouldNotBeNull();
            _recordTypeMappingInstance.ShouldNotBeNull();
            _recordTypeMappingInstanceFixture.ShouldNotBeNull();
            _recordTypeMappingInstance.ShouldBeAssignableTo<RecordTypeMapping>();
            _recordTypeMappingInstanceFixture.ShouldBeAssignableTo<RecordTypeMapping>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RecordTypeMapping) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RecordTypeMapping_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RecordTypeMapping instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _recordTypeMappingInstanceType.ShouldNotBeNull();
            _recordTypeMappingInstance.ShouldNotBeNull();
            _recordTypeMappingInstanceFixture.ShouldNotBeNull();
            _recordTypeMappingInstance.ShouldBeAssignableTo<RecordTypeMapping>();
            _recordTypeMappingInstanceFixture.ShouldBeAssignableTo<RecordTypeMapping>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RecordTypeMapping) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyavailable)]
        [TestCaseGeneric(typeof(bool) , PropertydefaultRecordTypeMapping)]
        [TestCaseGeneric(typeof(string) , PropertylayoutId)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(PicklistForRecordType[]) , PropertypicklistsForRecordType)]
        [TestCaseGeneric(typeof(string) , PropertyrecordTypeId)]
        public void AUT_RecordTypeMapping_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RecordTypeMapping, T>(_recordTypeMappingInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RecordTypeMapping) => Property (available) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RecordTypeMapping_Public_Class_available_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyavailable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RecordTypeMapping) => Property (defaultRecordTypeMapping) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RecordTypeMapping_Public_Class_defaultRecordTypeMapping_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultRecordTypeMapping);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RecordTypeMapping) => Property (layoutId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RecordTypeMapping_Public_Class_layoutId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylayoutId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RecordTypeMapping) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RecordTypeMapping_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (RecordTypeMapping) => Property (picklistsForRecordType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RecordTypeMapping_picklistsForRecordType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypicklistsForRecordType);
            Action currentAction = () => propertyInfo.SetValue(_recordTypeMappingInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (RecordTypeMapping) => Property (picklistsForRecordType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RecordTypeMapping_Public_Class_picklistsForRecordType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypicklistsForRecordType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RecordTypeMapping) => Property (recordTypeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RecordTypeMapping_Public_Class_recordTypeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordTypeId);

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