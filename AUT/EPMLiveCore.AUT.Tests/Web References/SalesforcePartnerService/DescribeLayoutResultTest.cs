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
using DescribeLayoutResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeLayoutResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeLayoutResultTest : AbstractBaseSetupTypedTest<DescribeLayoutResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeLayoutResult) Initializer

        private const string Propertylayouts = "layouts";
        private const string PropertyrecordTypeMappings = "recordTypeMappings";
        private const string PropertyrecordTypeSelectorRequired = "recordTypeSelectorRequired";
        private const string FieldlayoutsField = "layoutsField";
        private const string FieldrecordTypeMappingsField = "recordTypeMappingsField";
        private const string FieldrecordTypeSelectorRequiredField = "recordTypeSelectorRequiredField";
        private Type _describeLayoutResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeLayoutResult _describeLayoutResultInstance;
        private DescribeLayoutResult _describeLayoutResultInstanceFixture;

        #region General Initializer : Class (DescribeLayoutResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeLayoutResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeLayoutResultInstanceType = typeof(DescribeLayoutResult);
            _describeLayoutResultInstanceFixture = Create(true);
            _describeLayoutResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeLayoutResult)

        #region General Initializer : Class (DescribeLayoutResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayoutResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylayouts)]
        [TestCase(PropertyrecordTypeMappings)]
        [TestCase(PropertyrecordTypeSelectorRequired)]
        public void AUT_DescribeLayoutResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeLayoutResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeLayoutResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayoutResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlayoutsField)]
        [TestCase(FieldrecordTypeMappingsField)]
        [TestCase(FieldrecordTypeSelectorRequiredField)]
        public void AUT_DescribeLayoutResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeLayoutResultInstanceFixture, 
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
        ///     Class (<see cref="DescribeLayoutResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeLayoutResult_Is_Instance_Present_Test()
        {
            // Assert
            _describeLayoutResultInstanceType.ShouldNotBeNull();
            _describeLayoutResultInstance.ShouldNotBeNull();
            _describeLayoutResultInstanceFixture.ShouldNotBeNull();
            _describeLayoutResultInstance.ShouldBeAssignableTo<DescribeLayoutResult>();
            _describeLayoutResultInstanceFixture.ShouldBeAssignableTo<DescribeLayoutResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeLayoutResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeLayoutResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeLayoutResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeLayoutResultInstanceType.ShouldNotBeNull();
            _describeLayoutResultInstance.ShouldNotBeNull();
            _describeLayoutResultInstanceFixture.ShouldNotBeNull();
            _describeLayoutResultInstance.ShouldBeAssignableTo<DescribeLayoutResult>();
            _describeLayoutResultInstanceFixture.ShouldBeAssignableTo<DescribeLayoutResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeLayoutResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DescribeLayout[]) , Propertylayouts)]
        [TestCaseGeneric(typeof(RecordTypeMapping[]) , PropertyrecordTypeMappings)]
        [TestCaseGeneric(typeof(bool) , PropertyrecordTypeSelectorRequired)]
        public void AUT_DescribeLayoutResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeLayoutResult, T>(_describeLayoutResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutResult) => Property (layouts) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutResult_layouts_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertylayouts);
            Action currentAction = () => propertyInfo.SetValue(_describeLayoutResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutResult) => Property (layouts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutResult_Public_Class_layouts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylayouts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutResult) => Property (recordTypeMappings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutResult_recordTypeMappings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrecordTypeMappings);
            Action currentAction = () => propertyInfo.SetValue(_describeLayoutResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutResult) => Property (recordTypeMappings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutResult_Public_Class_recordTypeMappings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordTypeMappings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutResult) => Property (recordTypeSelectorRequired) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutResult_Public_Class_recordTypeSelectorRequired_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordTypeSelectorRequired);

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