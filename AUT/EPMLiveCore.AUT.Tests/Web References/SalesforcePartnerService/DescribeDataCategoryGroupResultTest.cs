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
using DescribeDataCategoryGroupResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeDataCategoryGroupResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeDataCategoryGroupResultTest : AbstractBaseSetupTypedTest<DescribeDataCategoryGroupResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeDataCategoryGroupResult) Initializer

        private const string PropertycategoryCount = "categoryCount";
        private const string Propertydescription = "description";
        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string Propertysobject = "sobject";
        private const string FieldcategoryCountField = "categoryCountField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private const string FieldsobjectField = "sobjectField";
        private Type _describeDataCategoryGroupResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeDataCategoryGroupResult _describeDataCategoryGroupResultInstance;
        private DescribeDataCategoryGroupResult _describeDataCategoryGroupResultInstanceFixture;

        #region General Initializer : Class (DescribeDataCategoryGroupResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeDataCategoryGroupResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeDataCategoryGroupResultInstanceType = typeof(DescribeDataCategoryGroupResult);
            _describeDataCategoryGroupResultInstanceFixture = Create(true);
            _describeDataCategoryGroupResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeDataCategoryGroupResult)

        #region General Initializer : Class (DescribeDataCategoryGroupResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeDataCategoryGroupResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycategoryCount)]
        [TestCase(Propertydescription)]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        [TestCase(Propertysobject)]
        public void AUT_DescribeDataCategoryGroupResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeDataCategoryGroupResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeDataCategoryGroupResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeDataCategoryGroupResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcategoryCountField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldsobjectField)]
        public void AUT_DescribeDataCategoryGroupResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeDataCategoryGroupResultInstanceFixture, 
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
        ///     Class (<see cref="DescribeDataCategoryGroupResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeDataCategoryGroupResult_Is_Instance_Present_Test()
        {
            // Assert
            _describeDataCategoryGroupResultInstanceType.ShouldNotBeNull();
            _describeDataCategoryGroupResultInstance.ShouldNotBeNull();
            _describeDataCategoryGroupResultInstanceFixture.ShouldNotBeNull();
            _describeDataCategoryGroupResultInstance.ShouldBeAssignableTo<DescribeDataCategoryGroupResult>();
            _describeDataCategoryGroupResultInstanceFixture.ShouldBeAssignableTo<DescribeDataCategoryGroupResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeDataCategoryGroupResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeDataCategoryGroupResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeDataCategoryGroupResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeDataCategoryGroupResultInstanceType.ShouldNotBeNull();
            _describeDataCategoryGroupResultInstance.ShouldNotBeNull();
            _describeDataCategoryGroupResultInstanceFixture.ShouldNotBeNull();
            _describeDataCategoryGroupResultInstance.ShouldBeAssignableTo<DescribeDataCategoryGroupResult>();
            _describeDataCategoryGroupResultInstanceFixture.ShouldBeAssignableTo<DescribeDataCategoryGroupResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeDataCategoryGroupResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertycategoryCount)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(string) , Propertysobject)]
        public void AUT_DescribeDataCategoryGroupResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeDataCategoryGroupResult, T>(_describeDataCategoryGroupResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeDataCategoryGroupResult) => Property (categoryCount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupResult_Public_Class_categoryCount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycategoryCount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeDataCategoryGroupResult) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupResult_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeDataCategoryGroupResult) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupResult_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeDataCategoryGroupResult) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupResult_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeDataCategoryGroupResult) => Property (sobject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeDataCategoryGroupResult_Public_Class_sobject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}