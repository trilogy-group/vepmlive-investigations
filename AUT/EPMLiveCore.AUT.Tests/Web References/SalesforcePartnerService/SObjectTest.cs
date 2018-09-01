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
using sObject = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.sObject" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SObjectTest : AbstractBaseSetupTypedTest<sObject>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (sObject) Initializer

        private const string Propertytype = "type";
        private const string PropertyfieldsToNull = "fieldsToNull";
        private const string PropertyId = "Id";
        private const string PropertyAny = "Any";
        private const string FieldtypeField = "typeField";
        private const string FieldfieldsToNullField = "fieldsToNullField";
        private const string FieldidField = "idField";
        private const string FieldanyField = "anyField";
        private Type _sObjectInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private sObject _sObjectInstance;
        private sObject _sObjectInstanceFixture;

        #region General Initializer : Class (sObject) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="sObject" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sObjectInstanceType = typeof(sObject);
            _sObjectInstanceFixture = Create(true);
            _sObjectInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (sObject)

        #region General Initializer : Class (sObject) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="sObject" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertytype)]
        [TestCase(PropertyfieldsToNull)]
        [TestCase(PropertyId)]
        [TestCase(PropertyAny)]
        public void AUT_SObject_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sObjectInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (sObject) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="sObject" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldtypeField)]
        [TestCase(FieldfieldsToNullField)]
        [TestCase(FieldidField)]
        [TestCase(FieldanyField)]
        public void AUT_SObject_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sObjectInstanceFixture, 
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
        ///     Class (<see cref="sObject" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SObject_Is_Instance_Present_Test()
        {
            // Assert
            _sObjectInstanceType.ShouldNotBeNull();
            _sObjectInstance.ShouldNotBeNull();
            _sObjectInstanceFixture.ShouldNotBeNull();
            _sObjectInstance.ShouldBeAssignableTo<sObject>();
            _sObjectInstanceFixture.ShouldBeAssignableTo<sObject>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (sObject) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_sObject_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            sObject instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sObjectInstanceType.ShouldNotBeNull();
            _sObjectInstance.ShouldNotBeNull();
            _sObjectInstanceFixture.ShouldNotBeNull();
            _sObjectInstance.ShouldBeAssignableTo<sObject>();
            _sObjectInstanceFixture.ShouldBeAssignableTo<sObject>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (sObject) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertytype)]
        [TestCaseGeneric(typeof(string[]) , PropertyfieldsToNull)]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(System.Xml.XmlElement[]) , PropertyAny)]
        public void AUT_SObject_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<sObject, T>(_sObjectInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (sObject) => Property (Any) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SObject_Any_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyAny);
            Action currentAction = () => propertyInfo.SetValue(_sObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (sObject) => Property (Any) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SObject_Public_Class_Any_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAny);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (sObject) => Property (fieldsToNull) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SObject_fieldsToNull_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfieldsToNull);
            Action currentAction = () => propertyInfo.SetValue(_sObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (sObject) => Property (fieldsToNull) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SObject_Public_Class_fieldsToNull_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfieldsToNull);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (sObject) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SObject_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (sObject) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SObject_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}