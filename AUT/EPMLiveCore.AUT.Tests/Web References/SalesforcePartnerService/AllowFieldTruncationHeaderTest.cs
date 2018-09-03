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
using AllowFieldTruncationHeader = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.AllowFieldTruncationHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AllowFieldTruncationHeaderTest : AbstractBaseSetupTypedTest<AllowFieldTruncationHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AllowFieldTruncationHeader) Initializer

        private const string PropertyallowFieldTruncation = "allowFieldTruncation";
        private const string FieldallowFieldTruncationField = "allowFieldTruncationField";
        private Type _allowFieldTruncationHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AllowFieldTruncationHeader _allowFieldTruncationHeaderInstance;
        private AllowFieldTruncationHeader _allowFieldTruncationHeaderInstanceFixture;

        #region General Initializer : Class (AllowFieldTruncationHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AllowFieldTruncationHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _allowFieldTruncationHeaderInstanceType = typeof(AllowFieldTruncationHeader);
            _allowFieldTruncationHeaderInstanceFixture = Create(true);
            _allowFieldTruncationHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AllowFieldTruncationHeader)

        #region General Initializer : Class (AllowFieldTruncationHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AllowFieldTruncationHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyallowFieldTruncation)]
        public void AUT_AllowFieldTruncationHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_allowFieldTruncationHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AllowFieldTruncationHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AllowFieldTruncationHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldallowFieldTruncationField)]
        public void AUT_AllowFieldTruncationHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_allowFieldTruncationHeaderInstanceFixture, 
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
        ///     Class (<see cref="AllowFieldTruncationHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AllowFieldTruncationHeader_Is_Instance_Present_Test()
        {
            // Assert
            _allowFieldTruncationHeaderInstanceType.ShouldNotBeNull();
            _allowFieldTruncationHeaderInstance.ShouldNotBeNull();
            _allowFieldTruncationHeaderInstanceFixture.ShouldNotBeNull();
            _allowFieldTruncationHeaderInstance.ShouldBeAssignableTo<AllowFieldTruncationHeader>();
            _allowFieldTruncationHeaderInstanceFixture.ShouldBeAssignableTo<AllowFieldTruncationHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AllowFieldTruncationHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AllowFieldTruncationHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AllowFieldTruncationHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _allowFieldTruncationHeaderInstanceType.ShouldNotBeNull();
            _allowFieldTruncationHeaderInstance.ShouldNotBeNull();
            _allowFieldTruncationHeaderInstanceFixture.ShouldNotBeNull();
            _allowFieldTruncationHeaderInstance.ShouldBeAssignableTo<AllowFieldTruncationHeader>();
            _allowFieldTruncationHeaderInstanceFixture.ShouldBeAssignableTo<AllowFieldTruncationHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AllowFieldTruncationHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyallowFieldTruncation)]
        public void AUT_AllowFieldTruncationHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AllowFieldTruncationHeader, T>(_allowFieldTruncationHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AllowFieldTruncationHeader) => Property (allowFieldTruncation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AllowFieldTruncationHeader_Public_Class_allowFieldTruncation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowFieldTruncation);

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