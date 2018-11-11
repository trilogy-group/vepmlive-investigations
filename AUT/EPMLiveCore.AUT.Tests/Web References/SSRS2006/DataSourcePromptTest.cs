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
using DataSourcePrompt = EPMLiveCore.SSRS2006;

namespace EPMLiveCore.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2006.DataSourcePrompt" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DataSourcePromptTest : AbstractBaseSetupTypedTest<DataSourcePrompt>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataSourcePrompt) Initializer

        private const string PropertyName = "Name";
        private const string PropertyDataSourceID = "DataSourceID";
        private const string PropertyPrompt = "Prompt";
        private const string FieldnameField = "nameField";
        private const string FielddataSourceIDField = "dataSourceIDField";
        private const string FieldpromptField = "promptField";
        private Type _dataSourcePromptInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataSourcePrompt _dataSourcePromptInstance;
        private DataSourcePrompt _dataSourcePromptInstanceFixture;

        #region General Initializer : Class (DataSourcePrompt) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataSourcePrompt" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataSourcePromptInstanceType = typeof(DataSourcePrompt);
            _dataSourcePromptInstanceFixture = Create(true);
            _dataSourcePromptInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataSourcePrompt)

        #region General Initializer : Class (DataSourcePrompt) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSourcePrompt" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyName)]
        [TestCase(PropertyDataSourceID)]
        [TestCase(PropertyPrompt)]
        public void AUT_DataSourcePrompt_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dataSourcePromptInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataSourcePrompt) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataSourcePrompt" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnameField)]
        [TestCase(FielddataSourceIDField)]
        [TestCase(FieldpromptField)]
        public void AUT_DataSourcePrompt_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataSourcePromptInstanceFixture, 
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
        ///     Class (<see cref="DataSourcePrompt" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DataSourcePrompt_Is_Instance_Present_Test()
        {
            // Assert
            _dataSourcePromptInstanceType.ShouldNotBeNull();
            _dataSourcePromptInstance.ShouldNotBeNull();
            _dataSourcePromptInstanceFixture.ShouldNotBeNull();
            _dataSourcePromptInstance.ShouldBeAssignableTo<DataSourcePrompt>();
            _dataSourcePromptInstanceFixture.ShouldBeAssignableTo<DataSourcePrompt>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataSourcePrompt) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DataSourcePrompt_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataSourcePrompt instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataSourcePromptInstanceType.ShouldNotBeNull();
            _dataSourcePromptInstance.ShouldNotBeNull();
            _dataSourcePromptInstanceFixture.ShouldNotBeNull();
            _dataSourcePromptInstance.ShouldBeAssignableTo<DataSourcePrompt>();
            _dataSourcePromptInstanceFixture.ShouldBeAssignableTo<DataSourcePrompt>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DataSourcePrompt) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyDataSourceID)]
        [TestCaseGeneric(typeof(string) , PropertyPrompt)]
        public void AUT_DataSourcePrompt_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DataSourcePrompt, T>(_dataSourcePromptInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DataSourcePrompt) => Property (DataSourceID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourcePrompt_Public_Class_DataSourceID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataSourceID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataSourcePrompt) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourcePrompt_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DataSourcePrompt) => Property (Prompt) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataSourcePrompt_Public_Class_Prompt_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPrompt);

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