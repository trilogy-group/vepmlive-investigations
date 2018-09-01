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
using DescribeSearchScopeOrderResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DescribeSearchScopeOrderResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DescribeSearchScopeOrderResultTest : AbstractBaseSetupTypedTest<DescribeSearchScopeOrderResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DescribeSearchScopeOrderResult) Initializer

        private const string PropertykeyPrefix = "keyPrefix";
        private const string Propertyname = "name";
        private const string FieldkeyPrefixField = "keyPrefixField";
        private const string FieldnameField = "nameField";
        private Type _describeSearchScopeOrderResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DescribeSearchScopeOrderResult _describeSearchScopeOrderResultInstance;
        private DescribeSearchScopeOrderResult _describeSearchScopeOrderResultInstanceFixture;

        #region General Initializer : Class (DescribeSearchScopeOrderResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DescribeSearchScopeOrderResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _describeSearchScopeOrderResultInstanceType = typeof(DescribeSearchScopeOrderResult);
            _describeSearchScopeOrderResultInstanceFixture = Create(true);
            _describeSearchScopeOrderResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DescribeSearchScopeOrderResult)

        #region General Initializer : Class (DescribeSearchScopeOrderResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSearchScopeOrderResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertykeyPrefix)]
        [TestCase(Propertyname)]
        public void AUT_DescribeSearchScopeOrderResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_describeSearchScopeOrderResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DescribeSearchScopeOrderResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DescribeSearchScopeOrderResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldkeyPrefixField)]
        [TestCase(FieldnameField)]
        public void AUT_DescribeSearchScopeOrderResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_describeSearchScopeOrderResultInstanceFixture, 
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
        ///     Class (<see cref="DescribeSearchScopeOrderResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DescribeSearchScopeOrderResult_Is_Instance_Present_Test()
        {
            // Assert
            _describeSearchScopeOrderResultInstanceType.ShouldNotBeNull();
            _describeSearchScopeOrderResultInstance.ShouldNotBeNull();
            _describeSearchScopeOrderResultInstanceFixture.ShouldNotBeNull();
            _describeSearchScopeOrderResultInstance.ShouldBeAssignableTo<DescribeSearchScopeOrderResult>();
            _describeSearchScopeOrderResultInstanceFixture.ShouldBeAssignableTo<DescribeSearchScopeOrderResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DescribeSearchScopeOrderResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DescribeSearchScopeOrderResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DescribeSearchScopeOrderResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _describeSearchScopeOrderResultInstanceType.ShouldNotBeNull();
            _describeSearchScopeOrderResultInstance.ShouldNotBeNull();
            _describeSearchScopeOrderResultInstanceFixture.ShouldNotBeNull();
            _describeSearchScopeOrderResultInstance.ShouldBeAssignableTo<DescribeSearchScopeOrderResult>();
            _describeSearchScopeOrderResultInstanceFixture.ShouldBeAssignableTo<DescribeSearchScopeOrderResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DescribeSearchScopeOrderResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertykeyPrefix)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_DescribeSearchScopeOrderResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DescribeSearchScopeOrderResult, T>(_describeSearchScopeOrderResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSearchScopeOrderResult) => Property (keyPrefix) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSearchScopeOrderResult_Public_Class_keyPrefix_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertykeyPrefix);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DescribeSearchScopeOrderResult) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DescribeSearchScopeOrderResult_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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