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
using DescribeSoftphoneLayoutInfoField = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeSoftphoneLayoutInfoField" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeSoftphoneLayoutInfoFieldTest : AbstractBaseSetupTypedTest<DescribeSoftphoneLayoutInfoField>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeSoftphoneLayoutInfoField) Initializer

        private const string Propertyname = "name";
        private const string FieldnameField = "nameField";
        private Type _describeSoftphoneLayoutInfoFieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeSoftphoneLayoutInfoField _describeSoftphoneLayoutInfoFieldInstance;
        private DescribeSoftphoneLayoutInfoField _describeSoftphoneLayoutInfoFieldInstanceFixture;

        #region General Initializer : Class (DescribeSoftphoneLayoutInfoField) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeSoftphoneLayoutInfoField" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeSoftphoneLayoutInfoFieldInstanceType = typeof(DescribeSoftphoneLayoutInfoField);
            _describeSoftphoneLayoutInfoFieldInstanceFixture = Create(true);
            _describeSoftphoneLayoutInfoFieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeSoftphoneLayoutInfoField)

        #region General Initializer : Class (DescribeSoftphoneLayoutInfoField) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneLayoutInfoField" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyname)]
        public void AUT_DescribeSoftphoneLayoutInfoField_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeSoftphoneLayoutInfoFieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeSoftphoneLayoutInfoField) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneLayoutInfoField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        public void AUT_DescribeSoftphoneLayoutInfoField_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeSoftphoneLayoutInfoFieldInstanceFixture, 
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
        ///     Class (<see cref="DescribeSoftphoneLayoutInfoField" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeSoftphoneLayoutInfoField_Is_Instance_Present_Test()
        {
            // Assert
            _describeSoftphoneLayoutInfoFieldInstanceType.ShouldNotBeNull();
            _describeSoftphoneLayoutInfoFieldInstance.ShouldNotBeNull();
            _describeSoftphoneLayoutInfoFieldInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneLayoutInfoFieldInstance.ShouldBeAssignableTo<DescribeSoftphoneLayoutInfoField>();
            _describeSoftphoneLayoutInfoFieldInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneLayoutInfoField>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeSoftphoneLayoutInfoField) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeSoftphoneLayoutInfoField_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeSoftphoneLayoutInfoField instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeSoftphoneLayoutInfoFieldInstanceType.ShouldNotBeNull();
            _describeSoftphoneLayoutInfoFieldInstance.ShouldNotBeNull();
            _describeSoftphoneLayoutInfoFieldInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneLayoutInfoFieldInstance.ShouldBeAssignableTo<DescribeSoftphoneLayoutInfoField>();
            _describeSoftphoneLayoutInfoFieldInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneLayoutInfoField>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutInfoField) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_DescribeSoftphoneLayoutInfoField_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeSoftphoneLayoutInfoField, T>(_describeSoftphoneLayoutInfoFieldInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutInfoField) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutInfoField_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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