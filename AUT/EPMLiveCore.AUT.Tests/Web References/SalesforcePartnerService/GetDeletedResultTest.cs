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
using GetDeletedResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.GetDeletedResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetDeletedResultTest : AbstractBaseSetupTypedTest<GetDeletedResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GetDeletedResult) Initializer

        private const string PropertydeletedRecords = "deletedRecords";
        private const string PropertyearliestDateAvailable = "earliestDateAvailable";
        private const string PropertylatestDateCovered = "latestDateCovered";
        private const string PropertysforceReserved = "sforceReserved";
        private const string FielddeletedRecordsField = "deletedRecordsField";
        private const string FieldearliestDateAvailableField = "earliestDateAvailableField";
        private const string FieldlatestDateCoveredField = "latestDateCoveredField";
        private const string FieldsforceReservedField = "sforceReservedField";
        private Type _getDeletedResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GetDeletedResult _getDeletedResultInstance;
        private GetDeletedResult _getDeletedResultInstanceFixture;

        #region General Initializer : Class (GetDeletedResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GetDeletedResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getDeletedResultInstanceType = typeof(GetDeletedResult);
            _getDeletedResultInstanceFixture = Create(true);
            _getDeletedResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GetDeletedResult)

        #region General Initializer : Class (GetDeletedResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GetDeletedResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydeletedRecords)]
        [TestCase(PropertyearliestDateAvailable)]
        [TestCase(PropertylatestDateCovered)]
        [TestCase(PropertysforceReserved)]
        public void AUT_GetDeletedResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_getDeletedResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GetDeletedResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GetDeletedResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddeletedRecordsField)]
        [TestCase(FieldearliestDateAvailableField)]
        [TestCase(FieldlatestDateCoveredField)]
        [TestCase(FieldsforceReservedField)]
        public void AUT_GetDeletedResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getDeletedResultInstanceFixture, 
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
        ///     Class (<see cref="GetDeletedResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_GetDeletedResult_Is_Instance_Present_Test()
        {
            // Assert
            _getDeletedResultInstanceType.ShouldNotBeNull();
            _getDeletedResultInstance.ShouldNotBeNull();
            _getDeletedResultInstanceFixture.ShouldNotBeNull();
            _getDeletedResultInstance.ShouldBeAssignableTo<GetDeletedResult>();
            _getDeletedResultInstanceFixture.ShouldBeAssignableTo<GetDeletedResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GetDeletedResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_GetDeletedResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GetDeletedResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getDeletedResultInstanceType.ShouldNotBeNull();
            _getDeletedResultInstance.ShouldNotBeNull();
            _getDeletedResultInstanceFixture.ShouldNotBeNull();
            _getDeletedResultInstance.ShouldBeAssignableTo<GetDeletedResult>();
            _getDeletedResultInstanceFixture.ShouldBeAssignableTo<GetDeletedResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GetDeletedResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(DeletedRecord[]) , PropertydeletedRecords)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyearliestDateAvailable)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertylatestDateCovered)]
        [TestCaseGeneric(typeof(string) , PropertysforceReserved)]
        public void AUT_GetDeletedResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<GetDeletedResult, T>(_getDeletedResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (GetDeletedResult) => Property (deletedRecords) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDeletedResult_deletedRecords_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydeletedRecords);
            Action currentAction = () => propertyInfo.SetValue(_getDeletedResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GetDeletedResult) => Property (deletedRecords) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDeletedResult_Public_Class_deletedRecords_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeletedRecords);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetDeletedResult) => Property (earliestDateAvailable) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDeletedResult_earliestDateAvailable_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyearliestDateAvailable);
            Action currentAction = () => propertyInfo.SetValue(_getDeletedResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GetDeletedResult) => Property (earliestDateAvailable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDeletedResult_Public_Class_earliestDateAvailable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyearliestDateAvailable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetDeletedResult) => Property (latestDateCovered) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDeletedResult_latestDateCovered_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylatestDateCovered);
            Action currentAction = () => propertyInfo.SetValue(_getDeletedResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GetDeletedResult) => Property (latestDateCovered) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDeletedResult_Public_Class_latestDateCovered_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylatestDateCovered);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetDeletedResult) => Property (sforceReserved) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDeletedResult_Public_Class_sforceReserved_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysforceReserved);

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