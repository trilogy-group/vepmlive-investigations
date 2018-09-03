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
using GetServerTimestampResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.GetServerTimestampResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetServerTimestampResultTest : AbstractBaseSetupTypedTest<GetServerTimestampResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GetServerTimestampResult) Initializer

        private const string Propertytimestamp = "timestamp";
        private const string FieldtimestampField = "timestampField";
        private Type _getServerTimestampResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GetServerTimestampResult _getServerTimestampResultInstance;
        private GetServerTimestampResult _getServerTimestampResultInstanceFixture;

        #region General Initializer : Class (GetServerTimestampResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GetServerTimestampResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getServerTimestampResultInstanceType = typeof(GetServerTimestampResult);
            _getServerTimestampResultInstanceFixture = Create(true);
            _getServerTimestampResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GetServerTimestampResult)

        #region General Initializer : Class (GetServerTimestampResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GetServerTimestampResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertytimestamp)]
        public void AUT_GetServerTimestampResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_getServerTimestampResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GetServerTimestampResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GetServerTimestampResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldtimestampField)]
        public void AUT_GetServerTimestampResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getServerTimestampResultInstanceFixture, 
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
        ///     Class (<see cref="GetServerTimestampResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_GetServerTimestampResult_Is_Instance_Present_Test()
        {
            // Assert
            _getServerTimestampResultInstanceType.ShouldNotBeNull();
            _getServerTimestampResultInstance.ShouldNotBeNull();
            _getServerTimestampResultInstanceFixture.ShouldNotBeNull();
            _getServerTimestampResultInstance.ShouldBeAssignableTo<GetServerTimestampResult>();
            _getServerTimestampResultInstanceFixture.ShouldBeAssignableTo<GetServerTimestampResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GetServerTimestampResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_GetServerTimestampResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GetServerTimestampResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getServerTimestampResultInstanceType.ShouldNotBeNull();
            _getServerTimestampResultInstance.ShouldNotBeNull();
            _getServerTimestampResultInstanceFixture.ShouldNotBeNull();
            _getServerTimestampResultInstance.ShouldBeAssignableTo<GetServerTimestampResult>();
            _getServerTimestampResultInstanceFixture.ShouldBeAssignableTo<GetServerTimestampResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GetServerTimestampResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.DateTime) , Propertytimestamp)]
        public void AUT_GetServerTimestampResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<GetServerTimestampResult, T>(_getServerTimestampResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (GetServerTimestampResult) => Property (timestamp) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetServerTimestampResult_timestamp_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytimestamp);
            Action currentAction = () => propertyInfo.SetValue(_getServerTimestampResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GetServerTimestampResult) => Property (timestamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetServerTimestampResult_Public_Class_timestamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytimestamp);

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