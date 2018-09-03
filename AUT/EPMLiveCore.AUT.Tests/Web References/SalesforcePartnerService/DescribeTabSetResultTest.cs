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
using DescribeTabSetResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeTabSetResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeTabSetResultTest : AbstractBaseSetupTypedTest<DescribeTabSetResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeTabSetResult) Initializer

        private const string Propertylabel = "label";
        private const string PropertylogoUrl = "logoUrl";
        private const string Propertyselected = "selected";
        private const string Propertytabs = "tabs";
        private const string FieldlabelField = "labelField";
        private const string FieldlogoUrlField = "logoUrlField";
        private const string FieldnamespaceField = "namespaceField";
        private const string FieldselectedField = "selectedField";
        private const string FieldtabsField = "tabsField";
        private Type _describeTabSetResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeTabSetResult _describeTabSetResultInstance;
        private DescribeTabSetResult _describeTabSetResultInstanceFixture;

        #region General Initializer : Class (DescribeTabSetResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeTabSetResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeTabSetResultInstanceType = typeof(DescribeTabSetResult);
            _describeTabSetResultInstanceFixture = Create(true);
            _describeTabSetResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeTabSetResult)

        #region General Initializer : Class (DescribeTabSetResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeTabSetResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabel)]
        [TestCase(PropertylogoUrl)]
        [TestCase(Propertyselected)]
        [TestCase(Propertytabs)]
        public void AUT_DescribeTabSetResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeTabSetResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeTabSetResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeTabSetResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlogoUrlField)]
        [TestCase(FieldnamespaceField)]
        [TestCase(FieldselectedField)]
        [TestCase(FieldtabsField)]
        public void AUT_DescribeTabSetResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeTabSetResultInstanceFixture, 
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
        ///     Class (<see cref="DescribeTabSetResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeTabSetResult_Is_Instance_Present_Test()
        {
            // Assert
            _describeTabSetResultInstanceType.ShouldNotBeNull();
            _describeTabSetResultInstance.ShouldNotBeNull();
            _describeTabSetResultInstanceFixture.ShouldNotBeNull();
            _describeTabSetResultInstance.ShouldBeAssignableTo<DescribeTabSetResult>();
            _describeTabSetResultInstanceFixture.ShouldBeAssignableTo<DescribeTabSetResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeTabSetResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeTabSetResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeTabSetResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeTabSetResultInstanceType.ShouldNotBeNull();
            _describeTabSetResultInstance.ShouldNotBeNull();
            _describeTabSetResultInstanceFixture.ShouldNotBeNull();
            _describeTabSetResultInstance.ShouldBeAssignableTo<DescribeTabSetResult>();
            _describeTabSetResultInstanceFixture.ShouldBeAssignableTo<DescribeTabSetResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeTabSetResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , PropertylogoUrl)]
        [TestCaseGeneric(typeof(bool) , Propertyselected)]
        [TestCaseGeneric(typeof(DescribeTab[]) , Propertytabs)]
        public void AUT_DescribeTabSetResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeTabSetResult, T>(_describeTabSetResultInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (DescribeTabSetResult) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTabSetResult_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DescribeTabSetResult) => Property (logoUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTabSetResult_Public_Class_logoUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylogoUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeTabSetResult) => Property (selected) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTabSetResult_Public_Class_selected_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyselected);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeTabSetResult) => Property (tabs) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTabSetResult_tabs_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytabs);
            Action currentAction = () => propertyInfo.SetValue(_describeTabSetResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeTabSetResult) => Property (tabs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeTabSetResult_Public_Class_tabs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytabs);

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