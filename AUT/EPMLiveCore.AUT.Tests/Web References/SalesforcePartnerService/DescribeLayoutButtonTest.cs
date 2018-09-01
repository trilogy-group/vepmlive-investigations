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
using DescribeLayoutButton = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeLayoutButton" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeLayoutButtonTest : AbstractBaseSetupTypedTest<DescribeLayoutButton>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeLayoutButton) Initializer

        private const string Propertycustom = "custom";
        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string FieldcustomField = "customField";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private Type _describeLayoutButtonInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeLayoutButton _describeLayoutButtonInstance;
        private DescribeLayoutButton _describeLayoutButtonInstanceFixture;

        #region General Initializer : Class (DescribeLayoutButton) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeLayoutButton" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeLayoutButtonInstanceType = typeof(DescribeLayoutButton);
            _describeLayoutButtonInstanceFixture = Create(true);
            _describeLayoutButtonInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeLayoutButton)

        #region General Initializer : Class (DescribeLayoutButton) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayoutButton" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycustom)]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        public void AUT_DescribeLayoutButton_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeLayoutButtonInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeLayoutButton) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayoutButton" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        public void AUT_DescribeLayoutButton_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeLayoutButtonInstanceFixture, 
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
        ///     Class (<see cref="DescribeLayoutButton" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeLayoutButton_Is_Instance_Present_Test()
        {
            // Assert
            _describeLayoutButtonInstanceType.ShouldNotBeNull();
            _describeLayoutButtonInstance.ShouldNotBeNull();
            _describeLayoutButtonInstanceFixture.ShouldNotBeNull();
            _describeLayoutButtonInstance.ShouldBeAssignableTo<DescribeLayoutButton>();
            _describeLayoutButtonInstanceFixture.ShouldBeAssignableTo<DescribeLayoutButton>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeLayoutButton) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeLayoutButton_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeLayoutButton instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeLayoutButtonInstanceType.ShouldNotBeNull();
            _describeLayoutButtonInstance.ShouldNotBeNull();
            _describeLayoutButtonInstanceFixture.ShouldNotBeNull();
            _describeLayoutButtonInstance.ShouldBeAssignableTo<DescribeLayoutButton>();
            _describeLayoutButtonInstanceFixture.ShouldBeAssignableTo<DescribeLayoutButton>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeLayoutButton) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertycustom)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_DescribeLayoutButton_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeLayoutButton, T>(_describeLayoutButtonInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutButton) => Property (custom) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutButton_Public_Class_custom_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeLayoutButton) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutButton_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeLayoutButton) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutButton_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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