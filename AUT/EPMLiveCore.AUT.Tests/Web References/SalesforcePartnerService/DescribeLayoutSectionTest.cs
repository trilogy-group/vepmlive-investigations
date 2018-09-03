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
using DescribeLayoutSection = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeLayoutSection" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeLayoutSectionTest : AbstractBaseSetupTypedTest<DescribeLayoutSection>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeLayoutSection) Initializer

        private const string Propertycolumns = "columns";
        private const string Propertyheading = "heading";
        private const string PropertylayoutRows = "layoutRows";
        private const string Propertyrows = "rows";
        private const string PropertyuseCollapsibleSection = "useCollapsibleSection";
        private const string PropertyuseHeading = "useHeading";
        private const string FieldcolumnsField = "columnsField";
        private const string FieldheadingField = "headingField";
        private const string FieldlayoutRowsField = "layoutRowsField";
        private const string FieldrowsField = "rowsField";
        private const string FielduseCollapsibleSectionField = "useCollapsibleSectionField";
        private const string FielduseHeadingField = "useHeadingField";
        private Type _describeLayoutSectionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeLayoutSection _describeLayoutSectionInstance;
        private DescribeLayoutSection _describeLayoutSectionInstanceFixture;

        #region General Initializer : Class (DescribeLayoutSection) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeLayoutSection" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeLayoutSectionInstanceType = typeof(DescribeLayoutSection);
            _describeLayoutSectionInstanceFixture = Create(true);
            _describeLayoutSectionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeLayoutSection)

        #region General Initializer : Class (DescribeLayoutSection) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayoutSection" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycolumns)]
        [TestCase(Propertyheading)]
        [TestCase(PropertylayoutRows)]
        [TestCase(Propertyrows)]
        [TestCase(PropertyuseCollapsibleSection)]
        [TestCase(PropertyuseHeading)]
        public void AUT_DescribeLayoutSection_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeLayoutSectionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeLayoutSection) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayoutSection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcolumnsField)]
        [TestCase(FieldheadingField)]
        [TestCase(FieldlayoutRowsField)]
        [TestCase(FieldrowsField)]
        [TestCase(FielduseCollapsibleSectionField)]
        [TestCase(FielduseHeadingField)]
        public void AUT_DescribeLayoutSection_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeLayoutSectionInstanceFixture, 
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
        ///     Class (<see cref="DescribeLayoutSection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeLayoutSection_Is_Instance_Present_Test()
        {
            // Assert
            _describeLayoutSectionInstanceType.ShouldNotBeNull();
            _describeLayoutSectionInstance.ShouldNotBeNull();
            _describeLayoutSectionInstanceFixture.ShouldNotBeNull();
            _describeLayoutSectionInstance.ShouldBeAssignableTo<DescribeLayoutSection>();
            _describeLayoutSectionInstanceFixture.ShouldBeAssignableTo<DescribeLayoutSection>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeLayoutSection) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeLayoutSection_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeLayoutSection instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeLayoutSectionInstanceType.ShouldNotBeNull();
            _describeLayoutSectionInstance.ShouldNotBeNull();
            _describeLayoutSectionInstanceFixture.ShouldNotBeNull();
            _describeLayoutSectionInstance.ShouldBeAssignableTo<DescribeLayoutSection>();
            _describeLayoutSectionInstanceFixture.ShouldBeAssignableTo<DescribeLayoutSection>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeLayoutSection) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , Propertycolumns)]
        [TestCaseGeneric(typeof(string) , Propertyheading)]
        [TestCaseGeneric(typeof(DescribeLayoutRow[]) , PropertylayoutRows)]
        [TestCaseGeneric(typeof(int) , Propertyrows)]
        [TestCaseGeneric(typeof(bool) , PropertyuseCollapsibleSection)]
        [TestCaseGeneric(typeof(bool) , PropertyuseHeading)]
        public void AUT_DescribeLayoutSection_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeLayoutSection, T>(_describeLayoutSectionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutSection) => Property (columns) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutSection_Public_Class_columns_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycolumns);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutSection) => Property (heading) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutSection_Public_Class_heading_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyheading);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutSection) => Property (layoutRows) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutSection_layoutRows_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylayoutRows);
            Action currentAction = () => propertyInfo.SetValue(_describeLayoutSectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutSection) => Property (layoutRows) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutSection_Public_Class_layoutRows_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylayoutRows);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutSection) => Property (rows) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutSection_Public_Class_rows_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrows);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutSection) => Property (useCollapsibleSection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutSection_Public_Class_useCollapsibleSection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseCollapsibleSection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutSection) => Property (useHeading) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutSection_Public_Class_useHeading_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseHeading);

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