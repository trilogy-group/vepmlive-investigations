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
using DataCategoryGroupSobjectTypePair = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DataCategoryGroupSobjectTypePair" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DataCategoryGroupSobjectTypePairTest : AbstractBaseSetupTypedTest<DataCategoryGroupSobjectTypePair>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataCategoryGroupSobjectTypePair) Initializer

        private const string PropertydataCategoryGroupName = "dataCategoryGroupName";
        private const string Propertysobject = "sobject";
        private const string FielddataCategoryGroupNameField = "dataCategoryGroupNameField";
        private const string FieldsobjectField = "sobjectField";
        private Type _dataCategoryGroupSobjectTypePairInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataCategoryGroupSobjectTypePair _dataCategoryGroupSobjectTypePairInstance;
        private DataCategoryGroupSobjectTypePair _dataCategoryGroupSobjectTypePairInstanceFixture;

        #region General Initializer : Class (DataCategoryGroupSobjectTypePair) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataCategoryGroupSobjectTypePair" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataCategoryGroupSobjectTypePairInstanceType = typeof(DataCategoryGroupSobjectTypePair);
            _dataCategoryGroupSobjectTypePairInstanceFixture = Create(true);
            _dataCategoryGroupSobjectTypePairInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataCategoryGroupSobjectTypePair)

        #region General Initializer : Class (DataCategoryGroupSobjectTypePair) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DataCategoryGroupSobjectTypePair" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydataCategoryGroupName)]
        [TestCase(Propertysobject)]
        public void AUT_DataCategoryGroupSobjectTypePair_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dataCategoryGroupSobjectTypePairInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DataCategoryGroupSobjectTypePair) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataCategoryGroupSobjectTypePair" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddataCategoryGroupNameField)]
        [TestCase(FieldsobjectField)]
        public void AUT_DataCategoryGroupSobjectTypePair_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataCategoryGroupSobjectTypePairInstanceFixture, 
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
        ///     Class (<see cref="DataCategoryGroupSobjectTypePair" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DataCategoryGroupSobjectTypePair_Is_Instance_Present_Test()
        {
            // Assert
            _dataCategoryGroupSobjectTypePairInstanceType.ShouldNotBeNull();
            _dataCategoryGroupSobjectTypePairInstance.ShouldNotBeNull();
            _dataCategoryGroupSobjectTypePairInstanceFixture.ShouldNotBeNull();
            _dataCategoryGroupSobjectTypePairInstance.ShouldBeAssignableTo<DataCategoryGroupSobjectTypePair>();
            _dataCategoryGroupSobjectTypePairInstanceFixture.ShouldBeAssignableTo<DataCategoryGroupSobjectTypePair>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataCategoryGroupSobjectTypePair) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DataCategoryGroupSobjectTypePair_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataCategoryGroupSobjectTypePair instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataCategoryGroupSobjectTypePairInstanceType.ShouldNotBeNull();
            _dataCategoryGroupSobjectTypePairInstance.ShouldNotBeNull();
            _dataCategoryGroupSobjectTypePairInstanceFixture.ShouldNotBeNull();
            _dataCategoryGroupSobjectTypePairInstance.ShouldBeAssignableTo<DataCategoryGroupSobjectTypePair>();
            _dataCategoryGroupSobjectTypePairInstanceFixture.ShouldBeAssignableTo<DataCategoryGroupSobjectTypePair>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DataCategoryGroupSobjectTypePair) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertydataCategoryGroupName)]
        [TestCaseGeneric(typeof(string) , Propertysobject)]
        public void AUT_DataCategoryGroupSobjectTypePair_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DataCategoryGroupSobjectTypePair, T>(_dataCategoryGroupSobjectTypePairInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DataCategoryGroupSobjectTypePair) => Property (dataCategoryGroupName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataCategoryGroupSobjectTypePair_Public_Class_dataCategoryGroupName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydataCategoryGroupName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DataCategoryGroupSobjectTypePair) => Property (sobject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DataCategoryGroupSobjectTypePair_Public_Class_sobject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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