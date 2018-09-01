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
using DescribeLayoutComponent = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeLayoutComponent" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeLayoutComponentTest : AbstractBaseSetupTypedTest<DescribeLayoutComponent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeLayoutComponent) Initializer

        private const string PropertydisplayLines = "displayLines";
        private const string PropertytabOrder = "tabOrder";
        private const string Propertytype = "type";
        private const string Propertyvalue = "value";
        private const string FielddisplayLinesField = "displayLinesField";
        private const string FieldtabOrderField = "tabOrderField";
        private const string FieldtypeField = "typeField";
        private const string FieldvalueField = "valueField";
        private Type _describeLayoutComponentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeLayoutComponent _describeLayoutComponentInstance;
        private DescribeLayoutComponent _describeLayoutComponentInstanceFixture;

        #region General Initializer : Class (DescribeLayoutComponent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeLayoutComponent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeLayoutComponentInstanceType = typeof(DescribeLayoutComponent);
            _describeLayoutComponentInstanceFixture = Create(true);
            _describeLayoutComponentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeLayoutComponent)

        #region General Initializer : Class (DescribeLayoutComponent) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayoutComponent" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydisplayLines)]
        [TestCase(PropertytabOrder)]
        [TestCase(Propertytype)]
        [TestCase(Propertyvalue)]
        public void AUT_DescribeLayoutComponent_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeLayoutComponentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeLayoutComponent) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayoutComponent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddisplayLinesField)]
        [TestCase(FieldtabOrderField)]
        [TestCase(FieldtypeField)]
        [TestCase(FieldvalueField)]
        public void AUT_DescribeLayoutComponent_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeLayoutComponentInstanceFixture, 
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
        ///     Class (<see cref="DescribeLayoutComponent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeLayoutComponent_Is_Instance_Present_Test()
        {
            // Assert
            _describeLayoutComponentInstanceType.ShouldNotBeNull();
            _describeLayoutComponentInstance.ShouldNotBeNull();
            _describeLayoutComponentInstanceFixture.ShouldNotBeNull();
            _describeLayoutComponentInstance.ShouldBeAssignableTo<DescribeLayoutComponent>();
            _describeLayoutComponentInstanceFixture.ShouldBeAssignableTo<DescribeLayoutComponent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeLayoutComponent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeLayoutComponent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeLayoutComponent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeLayoutComponentInstanceType.ShouldNotBeNull();
            _describeLayoutComponentInstance.ShouldNotBeNull();
            _describeLayoutComponentInstanceFixture.ShouldNotBeNull();
            _describeLayoutComponentInstance.ShouldBeAssignableTo<DescribeLayoutComponent>();
            _describeLayoutComponentInstanceFixture.ShouldBeAssignableTo<DescribeLayoutComponent>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeLayoutComponent) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertydisplayLines)]
        [TestCaseGeneric(typeof(int) , PropertytabOrder)]
        [TestCaseGeneric(typeof(layoutComponentType) , Propertytype)]
        [TestCaseGeneric(typeof(string) , Propertyvalue)]
        public void AUT_DescribeLayoutComponent_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeLayoutComponent, T>(_describeLayoutComponentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutComponent) => Property (displayLines) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutComponent_Public_Class_displayLines_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayLines);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutComponent) => Property (tabOrder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutComponent_Public_Class_tabOrder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytabOrder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutComponent) => Property (type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutComponent_type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytype);
            Action currentAction = () => propertyInfo.SetValue(_describeLayoutComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutComponent) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutComponent_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutComponent) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutComponent_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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