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
using QueryOptions = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.QueryOptions" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class QueryOptionsTest : AbstractBaseSetupTypedTest<QueryOptions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (QueryOptions) Initializer

        private const string PropertybatchSize = "batchSize";
        private const string PropertybatchSizeSpecified = "batchSizeSpecified";
        private const string FieldbatchSizeField = "batchSizeField";
        private const string FieldbatchSizeFieldSpecified = "batchSizeFieldSpecified";
        private Type _queryOptionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private QueryOptions _queryOptionsInstance;
        private QueryOptions _queryOptionsInstanceFixture;

        #region General Initializer : Class (QueryOptions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryOptions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryOptionsInstanceType = typeof(QueryOptions);
            _queryOptionsInstanceFixture = Create(true);
            _queryOptionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryOptions)

        #region General Initializer : Class (QueryOptions) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryOptions" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybatchSize)]
        [TestCase(PropertybatchSizeSpecified)]
        public void AUT_QueryOptions_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_queryOptionsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (QueryOptions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="QueryOptions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbatchSizeField)]
        [TestCase(FieldbatchSizeFieldSpecified)]
        public void AUT_QueryOptions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_queryOptionsInstanceFixture, 
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
        ///     Class (<see cref="QueryOptions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_QueryOptions_Is_Instance_Present_Test()
        {
            // Assert
            _queryOptionsInstanceType.ShouldNotBeNull();
            _queryOptionsInstance.ShouldNotBeNull();
            _queryOptionsInstanceFixture.ShouldNotBeNull();
            _queryOptionsInstance.ShouldBeAssignableTo<QueryOptions>();
            _queryOptionsInstanceFixture.ShouldBeAssignableTo<QueryOptions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (QueryOptions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_QueryOptions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            QueryOptions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _queryOptionsInstanceType.ShouldNotBeNull();
            _queryOptionsInstance.ShouldNotBeNull();
            _queryOptionsInstanceFixture.ShouldNotBeNull();
            _queryOptionsInstance.ShouldBeAssignableTo<QueryOptions>();
            _queryOptionsInstanceFixture.ShouldBeAssignableTo<QueryOptions>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (QueryOptions) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertybatchSize)]
        [TestCaseGeneric(typeof(bool) , PropertybatchSizeSpecified)]
        public void AUT_QueryOptions_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<QueryOptions, T>(_queryOptionsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (QueryOptions) => Property (batchSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryOptions_Public_Class_batchSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybatchSize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (QueryOptions) => Property (batchSizeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_QueryOptions_Public_Class_batchSizeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybatchSizeSpecified);

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