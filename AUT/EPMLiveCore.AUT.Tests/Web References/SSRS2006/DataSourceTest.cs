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
using EPMLiveCore.SSRS2006;
using DataSource = EPMLiveCore.SSRS2006;

namespace EPMLiveCore.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2006.DataSource" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DataSourceTest : AbstractBaseSetupTypedTest<DataSource>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataSource) Initializer

        private const string PropertyName = "Name";
        private const string PropertyItem = "Item";
        private const string FieldnameField = "nameField";
        private const string FielditemField = "itemField";
        private Type _dataSourceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataSource _dataSourceInstance;
        private DataSource _dataSourceInstanceFixture;

        #region General Initializer : Class (DataSource) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataSource" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataSourceInstanceType = typeof(DataSource);
            _dataSourceInstanceFixture = Create(true);
            _dataSourceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataSource)

        #region General Initializer : Class (DataSource) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSource" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyName)]
        [TestCase(PropertyItem)]
        public void AUT_DataSource_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dataSourceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataSource) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSource" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        [TestCase(FielditemField)]
        public void AUT_DataSource_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataSourceInstanceFixture, 
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
        ///     Class (<see cref="DataSource" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DataSource_Is_Instance_Present_Test()
        {
            // Assert
            _dataSourceInstanceType.ShouldNotBeNull();
            _dataSourceInstance.ShouldNotBeNull();
            _dataSourceInstanceFixture.ShouldNotBeNull();
            _dataSourceInstance.ShouldBeAssignableTo<DataSource>();
            _dataSourceInstanceFixture.ShouldBeAssignableTo<DataSource>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataSource) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DataSource_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataSource instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataSourceInstanceType.ShouldNotBeNull();
            _dataSourceInstance.ShouldNotBeNull();
            _dataSourceInstanceFixture.ShouldNotBeNull();
            _dataSourceInstance.ShouldBeAssignableTo<DataSource>();
            _dataSourceInstanceFixture.ShouldBeAssignableTo<DataSource>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DataSource) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(DataSourceDefinitionOrReference) , PropertyItem)]
        public void AUT_DataSource_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DataSource, T>(_dataSourceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DataSource) => Property (Item) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSource_Item_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyItem);
            Action currentAction = () => propertyInfo.SetValue(_dataSourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DataSource) => Property (Item) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSource_Public_Class_Item_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyItem);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSource) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSource_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

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