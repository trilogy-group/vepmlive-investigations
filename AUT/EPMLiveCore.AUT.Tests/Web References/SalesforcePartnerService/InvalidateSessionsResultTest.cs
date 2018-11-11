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
using InvalidateSessionsResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.InvalidateSessionsResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class InvalidateSessionsResultTest : AbstractBaseSetupTypedTest<InvalidateSessionsResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (InvalidateSessionsResult) Initializer

        private const string Propertyerrors = "errors";
        private const string Propertysuccess = "success";
        private const string FielderrorsField = "errorsField";
        private const string FieldsuccessField = "successField";
        private Type _invalidateSessionsResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private InvalidateSessionsResult _invalidateSessionsResultInstance;
        private InvalidateSessionsResult _invalidateSessionsResultInstanceFixture;

        #region General Initializer : Class (InvalidateSessionsResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="InvalidateSessionsResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _invalidateSessionsResultInstanceType = typeof(InvalidateSessionsResult);
            _invalidateSessionsResultInstanceFixture = Create(true);
            _invalidateSessionsResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (InvalidateSessionsResult)

        #region General Initializer : Class (InvalidateSessionsResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="InvalidateSessionsResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyerrors)]
        [TestCase(Propertysuccess)]
        public void AUT_InvalidateSessionsResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_invalidateSessionsResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (InvalidateSessionsResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="InvalidateSessionsResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielderrorsField)]
        [TestCase(FieldsuccessField)]
        public void AUT_InvalidateSessionsResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_invalidateSessionsResultInstanceFixture, 
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
        ///     Class (<see cref="InvalidateSessionsResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_InvalidateSessionsResult_Is_Instance_Present_Test()
        {
            // Assert
            _invalidateSessionsResultInstanceType.ShouldNotBeNull();
            _invalidateSessionsResultInstance.ShouldNotBeNull();
            _invalidateSessionsResultInstanceFixture.ShouldNotBeNull();
            _invalidateSessionsResultInstance.ShouldBeAssignableTo<InvalidateSessionsResult>();
            _invalidateSessionsResultInstanceFixture.ShouldBeAssignableTo<InvalidateSessionsResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (InvalidateSessionsResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_InvalidateSessionsResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            InvalidateSessionsResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _invalidateSessionsResultInstanceType.ShouldNotBeNull();
            _invalidateSessionsResultInstance.ShouldNotBeNull();
            _invalidateSessionsResultInstanceFixture.ShouldNotBeNull();
            _invalidateSessionsResultInstance.ShouldBeAssignableTo<InvalidateSessionsResult>();
            _invalidateSessionsResultInstanceFixture.ShouldBeAssignableTo<InvalidateSessionsResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (InvalidateSessionsResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Error[]) , Propertyerrors)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        public void AUT_InvalidateSessionsResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<InvalidateSessionsResult, T>(_invalidateSessionsResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (InvalidateSessionsResult) => Property (errors) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_InvalidateSessionsResult_errors_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyerrors);
            Action currentAction = () => propertyInfo.SetValue(_invalidateSessionsResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (InvalidateSessionsResult) => Property (errors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_InvalidateSessionsResult_Public_Class_errors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (InvalidateSessionsResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_InvalidateSessionsResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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