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
using DescribeDataCategoryGroupStructureResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeDataCategoryGroupStructureResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeDataCategoryGroupStructureResultTest : AbstractBaseSetupTypedTest<DescribeDataCategoryGroupStructureResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeDataCategoryGroupStructureResult) Initializer

        private const string Propertydescription = "description";
        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string Propertysobject = "sobject";
        private const string PropertytopCategories = "topCategories";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private const string FieldsobjectField = "sobjectField";
        private const string FieldtopCategoriesField = "topCategoriesField";
        private Type _describeDataCategoryGroupStructureResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeDataCategoryGroupStructureResult _describeDataCategoryGroupStructureResultInstance;
        private DescribeDataCategoryGroupStructureResult _describeDataCategoryGroupStructureResultInstanceFixture;

        #region General Initializer : Class (DescribeDataCategoryGroupStructureResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeDataCategoryGroupStructureResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeDataCategoryGroupStructureResultInstanceType = typeof(DescribeDataCategoryGroupStructureResult);
            _describeDataCategoryGroupStructureResultInstanceFixture = Create(true);
            _describeDataCategoryGroupStructureResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeDataCategoryGroupStructureResult)

        #region General Initializer : Class (DescribeDataCategoryGroupStructureResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeDataCategoryGroupStructureResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        [TestCase(Propertysobject)]
        [TestCase(PropertytopCategories)]
        public void AUT_DescribeDataCategoryGroupStructureResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeDataCategoryGroupStructureResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeDataCategoryGroupStructureResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeDataCategoryGroupStructureResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldsobjectField)]
        [TestCase(FieldtopCategoriesField)]
        public void AUT_DescribeDataCategoryGroupStructureResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeDataCategoryGroupStructureResultInstanceFixture, 
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
        ///     Class (<see cref="DescribeDataCategoryGroupStructureResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeDataCategoryGroupStructureResult_Is_Instance_Present_Test()
        {
            // Assert
            _describeDataCategoryGroupStructureResultInstanceType.ShouldNotBeNull();
            _describeDataCategoryGroupStructureResultInstance.ShouldNotBeNull();
            _describeDataCategoryGroupStructureResultInstanceFixture.ShouldNotBeNull();
            _describeDataCategoryGroupStructureResultInstance.ShouldBeAssignableTo<DescribeDataCategoryGroupStructureResult>();
            _describeDataCategoryGroupStructureResultInstanceFixture.ShouldBeAssignableTo<DescribeDataCategoryGroupStructureResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeDataCategoryGroupStructureResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeDataCategoryGroupStructureResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeDataCategoryGroupStructureResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeDataCategoryGroupStructureResultInstanceType.ShouldNotBeNull();
            _describeDataCategoryGroupStructureResultInstance.ShouldNotBeNull();
            _describeDataCategoryGroupStructureResultInstanceFixture.ShouldNotBeNull();
            _describeDataCategoryGroupStructureResultInstance.ShouldBeAssignableTo<DescribeDataCategoryGroupStructureResult>();
            _describeDataCategoryGroupStructureResultInstanceFixture.ShouldBeAssignableTo<DescribeDataCategoryGroupStructureResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeDataCategoryGroupStructureResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(string) , Propertysobject)]
        [TestCaseGeneric(typeof(DataCategory[]) , PropertytopCategories)]
        public void AUT_DescribeDataCategoryGroupStructureResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeDataCategoryGroupStructureResult, T>(_describeDataCategoryGroupStructureResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeDataCategoryGroupStructureResult) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupStructureResult_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeDataCategoryGroupStructureResult) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupStructureResult_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeDataCategoryGroupStructureResult) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupStructureResult_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeDataCategoryGroupStructureResult) => Property (sobject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupStructureResult_Public_Class_sobject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeDataCategoryGroupStructureResult) => Property (topCategories) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupStructureResult_topCategories_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertytopCategories);
            Action currentAction = () => propertyInfo.SetValue(_describeDataCategoryGroupStructureResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeDataCategoryGroupStructureResult) => Property (topCategories) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupStructureResult_Public_Class_topCategories_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytopCategories);

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