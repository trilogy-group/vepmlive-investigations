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
using DescribeSoftphoneLayoutResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeSoftphoneLayoutResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeSoftphoneLayoutResultTest : AbstractBaseSetupTypedTest<DescribeSoftphoneLayoutResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeSoftphoneLayoutResult) Initializer

        private const string PropertycallTypes = "callTypes";
        private const string Propertyid = "id";
        private const string Propertyname = "name";
        private const string FieldcallTypesField = "callTypesField";
        private const string FieldidField = "idField";
        private const string FieldnameField = "nameField";
        private Type _describeSoftphoneLayoutResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeSoftphoneLayoutResult _describeSoftphoneLayoutResultInstance;
        private DescribeSoftphoneLayoutResult _describeSoftphoneLayoutResultInstanceFixture;

        #region General Initializer : Class (DescribeSoftphoneLayoutResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeSoftphoneLayoutResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeSoftphoneLayoutResultInstanceType = typeof(DescribeSoftphoneLayoutResult);
            _describeSoftphoneLayoutResultInstanceFixture = Create(true);
            _describeSoftphoneLayoutResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeSoftphoneLayoutResult)

        #region General Initializer : Class (DescribeSoftphoneLayoutResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneLayoutResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycallTypes)]
        [TestCase(Propertyid)]
        [TestCase(Propertyname)]
        public void AUT_DescribeSoftphoneLayoutResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeSoftphoneLayoutResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeSoftphoneLayoutResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneLayoutResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcallTypesField)]
        [TestCase(FieldidField)]
        [TestCase(FieldnameField)]
        public void AUT_DescribeSoftphoneLayoutResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeSoftphoneLayoutResultInstanceFixture, 
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
        ///     Class (<see cref="DescribeSoftphoneLayoutResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeSoftphoneLayoutResult_Is_Instance_Present_Test()
        {
            // Assert
            _describeSoftphoneLayoutResultInstanceType.ShouldNotBeNull();
            _describeSoftphoneLayoutResultInstance.ShouldNotBeNull();
            _describeSoftphoneLayoutResultInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneLayoutResultInstance.ShouldBeAssignableTo<DescribeSoftphoneLayoutResult>();
            _describeSoftphoneLayoutResultInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneLayoutResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeSoftphoneLayoutResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeSoftphoneLayoutResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeSoftphoneLayoutResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeSoftphoneLayoutResultInstanceType.ShouldNotBeNull();
            _describeSoftphoneLayoutResultInstance.ShouldNotBeNull();
            _describeSoftphoneLayoutResultInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneLayoutResultInstance.ShouldBeAssignableTo<DescribeSoftphoneLayoutResult>();
            _describeSoftphoneLayoutResultInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneLayoutResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DescribeSoftphoneLayoutCallType[]) , PropertycallTypes)]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_DescribeSoftphoneLayoutResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeSoftphoneLayoutResult, T>(_describeSoftphoneLayoutResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutResult) => Property (callTypes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutResult_callTypes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycallTypes);
            Action currentAction = () => propertyInfo.SetValue(_describeSoftphoneLayoutResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutResult) => Property (callTypes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutResult_Public_Class_callTypes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycallTypes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutResult) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutResult_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutResult) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutResult_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}