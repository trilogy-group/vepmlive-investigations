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
using DescribeSoftphoneLayoutCallType = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeSoftphoneLayoutCallType" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeSoftphoneLayoutCallTypeTest : AbstractBaseSetupTypedTest<DescribeSoftphoneLayoutCallType>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeSoftphoneLayoutCallType) Initializer

        private const string PropertyinfoFields = "infoFields";
        private const string Propertyname = "name";
        private const string PropertyscreenPopOptions = "screenPopOptions";
        private const string PropertyscreenPopsOpenWithin = "screenPopsOpenWithin";
        private const string Propertysections = "sections";
        private const string FieldinfoFieldsField = "infoFieldsField";
        private const string FieldnameField = "nameField";
        private const string FieldscreenPopOptionsField = "screenPopOptionsField";
        private const string FieldscreenPopsOpenWithinField = "screenPopsOpenWithinField";
        private const string FieldsectionsField = "sectionsField";
        private Type _describeSoftphoneLayoutCallTypeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeSoftphoneLayoutCallType _describeSoftphoneLayoutCallTypeInstance;
        private DescribeSoftphoneLayoutCallType _describeSoftphoneLayoutCallTypeInstanceFixture;

        #region General Initializer : Class (DescribeSoftphoneLayoutCallType) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeSoftphoneLayoutCallType" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeSoftphoneLayoutCallTypeInstanceType = typeof(DescribeSoftphoneLayoutCallType);
            _describeSoftphoneLayoutCallTypeInstanceFixture = Create(true);
            _describeSoftphoneLayoutCallTypeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeSoftphoneLayoutCallType)

        #region General Initializer : Class (DescribeSoftphoneLayoutCallType) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneLayoutCallType" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyinfoFields)]
        [TestCase(Propertyname)]
        [TestCase(PropertyscreenPopOptions)]
        [TestCase(PropertyscreenPopsOpenWithin)]
        [TestCase(Propertysections)]
        public void AUT_DescribeSoftphoneLayoutCallType_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeSoftphoneLayoutCallTypeInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeSoftphoneLayoutCallType) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSoftphoneLayoutCallType" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldinfoFieldsField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldscreenPopOptionsField)]
        [TestCase(FieldscreenPopsOpenWithinField)]
        [TestCase(FieldsectionsField)]
        public void AUT_DescribeSoftphoneLayoutCallType_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeSoftphoneLayoutCallTypeInstanceFixture, 
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
        ///     Class (<see cref="DescribeSoftphoneLayoutCallType" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeSoftphoneLayoutCallType_Is_Instance_Present_Test()
        {
            // Assert
            _describeSoftphoneLayoutCallTypeInstanceType.ShouldNotBeNull();
            _describeSoftphoneLayoutCallTypeInstance.ShouldNotBeNull();
            _describeSoftphoneLayoutCallTypeInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneLayoutCallTypeInstance.ShouldBeAssignableTo<DescribeSoftphoneLayoutCallType>();
            _describeSoftphoneLayoutCallTypeInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneLayoutCallType>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeSoftphoneLayoutCallType) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeSoftphoneLayoutCallType_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeSoftphoneLayoutCallType instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeSoftphoneLayoutCallTypeInstanceType.ShouldNotBeNull();
            _describeSoftphoneLayoutCallTypeInstance.ShouldNotBeNull();
            _describeSoftphoneLayoutCallTypeInstanceFixture.ShouldNotBeNull();
            _describeSoftphoneLayoutCallTypeInstance.ShouldBeAssignableTo<DescribeSoftphoneLayoutCallType>();
            _describeSoftphoneLayoutCallTypeInstanceFixture.ShouldBeAssignableTo<DescribeSoftphoneLayoutCallType>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutCallType) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DescribeSoftphoneLayoutInfoField[]) , PropertyinfoFields)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(DescribeSoftphoneScreenPopOption[]) , PropertyscreenPopOptions)]
        [TestCaseGeneric(typeof(string) , PropertyscreenPopsOpenWithin)]
        [TestCaseGeneric(typeof(DescribeSoftphoneLayoutSection[]) , Propertysections)]
        public void AUT_DescribeSoftphoneLayoutCallType_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeSoftphoneLayoutCallType, T>(_describeSoftphoneLayoutCallTypeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutCallType) => Property (infoFields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutCallType_infoFields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyinfoFields);
            Action currentAction = () => propertyInfo.SetValue(_describeSoftphoneLayoutCallTypeInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutCallType) => Property (infoFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutCallType_Public_Class_infoFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinfoFields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutCallType) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutCallType_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutCallType) => Property (screenPopOptions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutCallType_screenPopOptions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyscreenPopOptions);
            Action currentAction = () => propertyInfo.SetValue(_describeSoftphoneLayoutCallTypeInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutCallType) => Property (screenPopOptions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutCallType_Public_Class_screenPopOptions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyscreenPopOptions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutCallType) => Property (screenPopsOpenWithin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutCallType_Public_Class_screenPopsOpenWithin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyscreenPopsOpenWithin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutCallType) => Property (sections) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutCallType_sections_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysections);
            Action currentAction = () => propertyInfo.SetValue(_describeSoftphoneLayoutCallTypeInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSoftphoneLayoutCallType) => Property (sections) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSoftphoneLayoutCallType_Public_Class_sections_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysections);

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