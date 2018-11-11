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
using DescribeTab = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeTab" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeTabTest : AbstractBaseSetupTypedTest<DescribeTab>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeTab) Initializer

        private const string Propertycustom = "custom";
        private const string PropertyiconUrl = "iconUrl";
        private const string Propertylabel = "label";
        private const string PropertyminiIconUrl = "miniIconUrl";
        private const string PropertysobjectName = "sobjectName";
        private const string Propertyurl = "url";
        private const string FieldcustomField = "customField";
        private const string FieldiconUrlField = "iconUrlField";
        private const string FieldlabelField = "labelField";
        private const string FieldminiIconUrlField = "miniIconUrlField";
        private const string FieldsobjectNameField = "sobjectNameField";
        private const string FieldurlField = "urlField";
        private Type _describeTabInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeTab _describeTabInstance;
        private DescribeTab _describeTabInstanceFixture;

        #region General Initializer : Class (DescribeTab) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeTab" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeTabInstanceType = typeof(DescribeTab);
            _describeTabInstanceFixture = Create(true);
            _describeTabInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeTab)

        #region General Initializer : Class (DescribeTab) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeTab" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycustom)]
        [TestCase(PropertyiconUrl)]
        [TestCase(Propertylabel)]
        [TestCase(PropertyminiIconUrl)]
        [TestCase(PropertysobjectName)]
        [TestCase(Propertyurl)]
        public void AUT_DescribeTab_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeTabInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeTab) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeTab" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomField)]
        [TestCase(FieldiconUrlField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldminiIconUrlField)]
        [TestCase(FieldsobjectNameField)]
        [TestCase(FieldurlField)]
        public void AUT_DescribeTab_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeTabInstanceFixture, 
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
        ///     Class (<see cref="DescribeTab" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeTab_Is_Instance_Present_Test()
        {
            // Assert
            _describeTabInstanceType.ShouldNotBeNull();
            _describeTabInstance.ShouldNotBeNull();
            _describeTabInstanceFixture.ShouldNotBeNull();
            _describeTabInstance.ShouldBeAssignableTo<DescribeTab>();
            _describeTabInstanceFixture.ShouldBeAssignableTo<DescribeTab>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeTab) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeTab_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeTab instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeTabInstanceType.ShouldNotBeNull();
            _describeTabInstance.ShouldNotBeNull();
            _describeTabInstanceFixture.ShouldNotBeNull();
            _describeTabInstance.ShouldBeAssignableTo<DescribeTab>();
            _describeTabInstanceFixture.ShouldBeAssignableTo<DescribeTab>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeTab) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertycustom)]
        [TestCaseGeneric(typeof(string) , PropertyiconUrl)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , PropertyminiIconUrl)]
        [TestCaseGeneric(typeof(string) , PropertysobjectName)]
        [TestCaseGeneric(typeof(string) , Propertyurl)]
        public void AUT_DescribeTab_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeTab, T>(_describeTabInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeTab) => Property (custom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTab_Public_Class_custom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycustom);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeTab) => Property (iconUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTab_Public_Class_iconUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyiconUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeTab) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTab_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeTab) => Property (miniIconUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTab_Public_Class_miniIconUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyminiIconUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeTab) => Property (sobjectName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTab_Public_Class_sobjectName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysobjectName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeTab) => Property (url) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTab_Public_Class_url_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyurl);

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