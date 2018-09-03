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
using DescribeSoftphoneLayoutSection = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeSoftphoneLayoutSection" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeSoftphoneLayoutSectionTest : AbstractBaseSetupTypedTest<DescribeSoftphoneLayoutSection>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeSoftphoneLayoutSection) Initializer

        private const string PropertyentityApiName = "entityApiName";
        private const string Propertyitems = "items";
        private const string FieldentityApiNameField = "entityApiNameField";
        private const string FielditemsField = "itemsField";
        private Type _describeSoftphoneLayoutSectionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeSoftphoneLayoutSection _describeSoftphoneLayoutSectionInstance;
        private DescribeSoftphoneLayoutSection _describeSoftphoneLayoutSectionInstanceFixture;

        #region General Initializer : Class (DescribeSoftphoneLayoutSection) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeSoftphoneLayoutSection" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeSoftphoneLayoutSectionInstanceType = typeof(DescribeSoftphoneLayoutSection);
            _describeSoftphoneLayoutSectionInstanceFixture = Create(true);
            _describeSoftphoneLayoutSectionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeSoftphoneLayoutSection)

        #region General Initializer : Class (DescribeSoftphoneLayoutSection) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneLayoutSection" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyentityApiName)]
        [TestCase(Propertyitems)]
        public void AUT_DescribeSoftphoneLayoutSection_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeSoftphoneLayoutSectionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeSoftphoneLayoutSection) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneLayoutSection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldentityApiNameField)]
        [TestCase(FielditemsField)]
        public void AUT_DescribeSoftphoneLayoutSection_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeSoftphoneLayoutSectionInstanceFixture, 
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
        ///     Class (<see cref="DescribeSoftphoneLayoutSection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeSoftphoneLayoutSection_Is_Instance_Present_Test()
        {
            // Assert
            _describeSoftphoneLayoutSectionInstanceType.ShouldNotBeNull();
            _describeSoftphoneLayoutSectionInstance.ShouldNotBeNull();
            _describeSoftphoneLayoutSectionInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneLayoutSectionInstance.ShouldBeAssignableTo<DescribeSoftphoneLayoutSection>();
            _describeSoftphoneLayoutSectionInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneLayoutSection>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeSoftphoneLayoutSection) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeSoftphoneLayoutSection_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeSoftphoneLayoutSection instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeSoftphoneLayoutSectionInstanceType.ShouldNotBeNull();
            _describeSoftphoneLayoutSectionInstance.ShouldNotBeNull();
            _describeSoftphoneLayoutSectionInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneLayoutSectionInstance.ShouldBeAssignableTo<DescribeSoftphoneLayoutSection>();
            _describeSoftphoneLayoutSectionInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneLayoutSection>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutSection) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyentityApiName)]
        [TestCaseGeneric(typeof(DescribeSoftphoneLayoutItem[]) , Propertyitems)]
        public void AUT_DescribeSoftphoneLayoutSection_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeSoftphoneLayoutSection, T>(_describeSoftphoneLayoutSectionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutSection) => Property (entityApiName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutSection_Public_Class_entityApiName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentityApiName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutSection) => Property (items) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutSection_items_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyitems);
            Action currentAction = () => propertyInfo.SetValue(_describeSoftphoneLayoutSectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutSection) => Property (items) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutSection_Public_Class_items_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyitems);

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