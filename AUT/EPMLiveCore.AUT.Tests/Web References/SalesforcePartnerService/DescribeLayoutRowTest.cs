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
using DescribeLayoutRow = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeLayoutRow" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeLayoutRowTest : AbstractBaseSetupTypedTest<DescribeLayoutRow>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeLayoutRow) Initializer

        private const string PropertylayoutItems = "layoutItems";
        private const string PropertynumItems = "numItems";
        private const string FieldlayoutItemsField = "layoutItemsField";
        private const string FieldnumItemsField = "numItemsField";
        private Type _describeLayoutRowInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeLayoutRow _describeLayoutRowInstance;
        private DescribeLayoutRow _describeLayoutRowInstanceFixture;

        #region General Initializer : Class (DescribeLayoutRow) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeLayoutRow" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeLayoutRowInstanceType = typeof(DescribeLayoutRow);
            _describeLayoutRowInstanceFixture = Create(true);
            _describeLayoutRowInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeLayoutRow)

        #region General Initializer : Class (DescribeLayoutRow) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayoutRow" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertylayoutItems)]
        [TestCase(PropertynumItems)]
        public void AUT_DescribeLayoutRow_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeLayoutRowInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeLayoutRow) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeLayoutRow" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlayoutItemsField)]
        [TestCase(FieldnumItemsField)]
        public void AUT_DescribeLayoutRow_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeLayoutRowInstanceFixture, 
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
        ///     Class (<see cref="DescribeLayoutRow" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeLayoutRow_Is_Instance_Present_Test()
        {
            // Assert
            _describeLayoutRowInstanceType.ShouldNotBeNull();
            _describeLayoutRowInstance.ShouldNotBeNull();
            _describeLayoutRowInstanceFixture.ShouldNotBeNull();
            _describeLayoutRowInstance.ShouldBeAssignableTo<DescribeLayoutRow>();
            _describeLayoutRowInstanceFixture.ShouldBeAssignableTo<DescribeLayoutRow>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeLayoutRow) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeLayoutRow_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeLayoutRow instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeLayoutRowInstanceType.ShouldNotBeNull();
            _describeLayoutRowInstance.ShouldNotBeNull();
            _describeLayoutRowInstanceFixture.ShouldNotBeNull();
            _describeLayoutRowInstance.ShouldBeAssignableTo<DescribeLayoutRow>();
            _describeLayoutRowInstanceFixture.ShouldBeAssignableTo<DescribeLayoutRow>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeLayoutRow) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DescribeLayoutItem[]) , PropertylayoutItems)]
        [TestCaseGeneric(typeof(int) , PropertynumItems)]
        public void AUT_DescribeLayoutRow_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeLayoutRow, T>(_describeLayoutRowInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutRow) => Property (layoutItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutRow_layoutItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylayoutItems);
            Action currentAction = () => propertyInfo.SetValue(_describeLayoutRowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutRow) => Property (layoutItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutRow_Public_Class_layoutItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylayoutItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeLayoutRow) => Property (numItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeLayoutRow_Public_Class_numItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynumItems);

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