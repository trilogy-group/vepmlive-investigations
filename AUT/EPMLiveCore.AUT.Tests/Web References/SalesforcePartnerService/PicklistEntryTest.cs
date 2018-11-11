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
using PicklistEntry = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.PicklistEntry" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PicklistEntryTest : AbstractBaseSetupTypedTest<PicklistEntry>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PicklistEntry) Initializer

        private const string Propertyactive = "active";
        private const string PropertydefaultValue = "defaultValue";
        private const string Propertylabel = "label";
        private const string PropertyvalidFor = "validFor";
        private const string Propertyvalue = "value";
        private const string FieldactiveField = "activeField";
        private const string FielddefaultValueField = "defaultValueField";
        private const string FieldlabelField = "labelField";
        private const string FieldvalidForField = "validForField";
        private const string FieldvalueField = "valueField";
        private Type _picklistEntryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PicklistEntry _picklistEntryInstance;
        private PicklistEntry _picklistEntryInstanceFixture;

        #region General Initializer : Class (PicklistEntry) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PicklistEntry" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _picklistEntryInstanceType = typeof(PicklistEntry);
            _picklistEntryInstanceFixture = Create(true);
            _picklistEntryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PicklistEntry)

        #region General Initializer : Class (PicklistEntry) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PicklistEntry" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactive)]
        [TestCase(PropertydefaultValue)]
        [TestCase(Propertylabel)]
        [TestCase(PropertyvalidFor)]
        [TestCase(Propertyvalue)]
        public void AUT_PicklistEntry_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_picklistEntryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PicklistEntry) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PicklistEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactiveField)]
        [TestCase(FielddefaultValueField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldvalidForField)]
        [TestCase(FieldvalueField)]
        public void AUT_PicklistEntry_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_picklistEntryInstanceFixture, 
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
        ///     Class (<see cref="PicklistEntry" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PicklistEntry_Is_Instance_Present_Test()
        {
            // Assert
            _picklistEntryInstanceType.ShouldNotBeNull();
            _picklistEntryInstance.ShouldNotBeNull();
            _picklistEntryInstanceFixture.ShouldNotBeNull();
            _picklistEntryInstance.ShouldBeAssignableTo<PicklistEntry>();
            _picklistEntryInstanceFixture.ShouldBeAssignableTo<PicklistEntry>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PicklistEntry) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PicklistEntry_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PicklistEntry instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _picklistEntryInstanceType.ShouldNotBeNull();
            _picklistEntryInstance.ShouldNotBeNull();
            _picklistEntryInstanceFixture.ShouldNotBeNull();
            _picklistEntryInstance.ShouldBeAssignableTo<PicklistEntry>();
            _picklistEntryInstanceFixture.ShouldBeAssignableTo<PicklistEntry>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PicklistEntry) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactive)]
        [TestCaseGeneric(typeof(bool) , PropertydefaultValue)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(byte[]) , PropertyvalidFor)]
        [TestCaseGeneric(typeof(string) , Propertyvalue)]
        public void AUT_PicklistEntry_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PicklistEntry, T>(_picklistEntryInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PicklistEntry) => Property (active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistEntry_Public_Class_active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyactive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistEntry) => Property (defaultValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistEntry_Public_Class_defaultValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PicklistEntry) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistEntry_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PicklistEntry) => Property (validFor) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistEntry_validFor_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyvalidFor);
            Action currentAction = () => propertyInfo.SetValue(_picklistEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PicklistEntry) => Property (validFor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistEntry_Public_Class_validFor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyvalidFor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistEntry) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistEntry_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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