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
using QueryResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.QueryResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryResultTest : AbstractBaseSetupTypedTest<QueryResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (QueryResult) Initializer

        private const string Propertydone = "done";
        private const string PropertyqueryLocator = "queryLocator";
        private const string Propertyrecords = "records";
        private const string Propertysize = "size";
        private const string FielddoneField = "doneField";
        private const string FieldqueryLocatorField = "queryLocatorField";
        private const string FieldrecordsField = "recordsField";
        private const string FieldsizeField = "sizeField";
        private Type _queryResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private QueryResult _queryResultInstance;
        private QueryResult _queryResultInstanceFixture;

        #region General Initializer : Class (QueryResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryResultInstanceType = typeof(QueryResult);
            _queryResultInstanceFixture = Create(true);
            _queryResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryResult)

        #region General Initializer : Class (QueryResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydone)]
        [TestCase(PropertyqueryLocator)]
        [TestCase(Propertyrecords)]
        [TestCase(Propertysize)]
        public void AUT_QueryResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_queryResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (QueryResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddoneField)]
        [TestCase(FieldqueryLocatorField)]
        [TestCase(FieldrecordsField)]
        [TestCase(FieldsizeField)]
        public void AUT_QueryResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryResultInstanceFixture, 
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
        ///     Class (<see cref="QueryResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_QueryResult_Is_Instance_Present_Test()
        {
            // Assert
            _queryResultInstanceType.ShouldNotBeNull();
            _queryResultInstance.ShouldNotBeNull();
            _queryResultInstanceFixture.ShouldNotBeNull();
            _queryResultInstance.ShouldBeAssignableTo<QueryResult>();
            _queryResultInstanceFixture.ShouldBeAssignableTo<QueryResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_QueryResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryResultInstanceType.ShouldNotBeNull();
            _queryResultInstance.ShouldNotBeNull();
            _queryResultInstanceFixture.ShouldNotBeNull();
            _queryResultInstance.ShouldBeAssignableTo<QueryResult>();
            _queryResultInstanceFixture.ShouldBeAssignableTo<QueryResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (QueryResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertydone)]
        [TestCaseGeneric(typeof(string) , PropertyqueryLocator)]
        [TestCaseGeneric(typeof(sObject[]) , Propertyrecords)]
        [TestCaseGeneric(typeof(int) , Propertysize)]
        public void AUT_QueryResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<QueryResult, T>(_queryResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (QueryResult) => Property (done) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryResult_Public_Class_done_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueryResult) => Property (queryLocator) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryResult_Public_Class_queryLocator_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyqueryLocator);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueryResult) => Property (records) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryResult_records_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyrecords);
            Action currentAction = () => propertyInfo.SetValue(_queryResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (QueryResult) => Property (records) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryResult_Public_Class_records_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrecords);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueryResult) => Property (size) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryResult_Public_Class_size_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysize);

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