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
using EmptyRecycleBinResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.EmptyRecycleBinResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EmptyRecycleBinResultTest : AbstractBaseSetupTypedTest<EmptyRecycleBinResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EmptyRecycleBinResult) Initializer

        private const string Propertyerrors = "errors";
        private const string Propertyid = "id";
        private const string Propertysuccess = "success";
        private const string FielderrorsField = "errorsField";
        private const string FieldidField = "idField";
        private const string FieldsuccessField = "successField";
        private Type _emptyRecycleBinResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EmptyRecycleBinResult _emptyRecycleBinResultInstance;
        private EmptyRecycleBinResult _emptyRecycleBinResultInstanceFixture;

        #region General Initializer : Class (EmptyRecycleBinResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EmptyRecycleBinResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _emptyRecycleBinResultInstanceType = typeof(EmptyRecycleBinResult);
            _emptyRecycleBinResultInstanceFixture = Create(true);
            _emptyRecycleBinResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EmptyRecycleBinResult)

        #region General Initializer : Class (EmptyRecycleBinResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EmptyRecycleBinResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyerrors)]
        [TestCase(Propertyid)]
        [TestCase(Propertysuccess)]
        public void AUT_EmptyRecycleBinResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_emptyRecycleBinResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EmptyRecycleBinResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EmptyRecycleBinResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielderrorsField)]
        [TestCase(FieldidField)]
        [TestCase(FieldsuccessField)]
        public void AUT_EmptyRecycleBinResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_emptyRecycleBinResultInstanceFixture, 
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
        ///     Class (<see cref="EmptyRecycleBinResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EmptyRecycleBinResult_Is_Instance_Present_Test()
        {
            // Assert
            _emptyRecycleBinResultInstanceType.ShouldNotBeNull();
            _emptyRecycleBinResultInstance.ShouldNotBeNull();
            _emptyRecycleBinResultInstanceFixture.ShouldNotBeNull();
            _emptyRecycleBinResultInstance.ShouldBeAssignableTo<EmptyRecycleBinResult>();
            _emptyRecycleBinResultInstanceFixture.ShouldBeAssignableTo<EmptyRecycleBinResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EmptyRecycleBinResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EmptyRecycleBinResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EmptyRecycleBinResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _emptyRecycleBinResultInstanceType.ShouldNotBeNull();
            _emptyRecycleBinResultInstance.ShouldNotBeNull();
            _emptyRecycleBinResultInstanceFixture.ShouldNotBeNull();
            _emptyRecycleBinResultInstance.ShouldBeAssignableTo<EmptyRecycleBinResult>();
            _emptyRecycleBinResultInstanceFixture.ShouldBeAssignableTo<EmptyRecycleBinResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EmptyRecycleBinResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Error[]) , Propertyerrors)]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        public void AUT_EmptyRecycleBinResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EmptyRecycleBinResult, T>(_emptyRecycleBinResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EmptyRecycleBinResult) => Property (errors) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmptyRecycleBinResult_errors_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyerrors);
            Action currentAction = () => propertyInfo.SetValue(_emptyRecycleBinResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmptyRecycleBinResult) => Property (errors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmptyRecycleBinResult_Public_Class_errors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyerrors);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmptyRecycleBinResult) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmptyRecycleBinResult_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmptyRecycleBinResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmptyRecycleBinResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysuccess);

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