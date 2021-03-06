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
using DeletedRecord = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.DeletedRecord" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DeletedRecordTest : AbstractBaseSetupTypedTest<DeletedRecord>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DeletedRecord) Initializer

        private const string PropertydeletedDate = "deletedDate";
        private const string Propertyid = "id";
        private const string FielddeletedDateField = "deletedDateField";
        private const string FieldidField = "idField";
        private Type _deletedRecordInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DeletedRecord _deletedRecordInstance;
        private DeletedRecord _deletedRecordInstanceFixture;

        #region General Initializer : Class (DeletedRecord) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DeletedRecord" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _deletedRecordInstanceType = typeof(DeletedRecord);
            _deletedRecordInstanceFixture = Create(true);
            _deletedRecordInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DeletedRecord)

        #region General Initializer : Class (DeletedRecord) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DeletedRecord" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydeletedDate)]
        [TestCase(Propertyid)]
        public void AUT_DeletedRecord_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_deletedRecordInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DeletedRecord) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DeletedRecord" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddeletedDateField)]
        [TestCase(FieldidField)]
        public void AUT_DeletedRecord_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_deletedRecordInstanceFixture, 
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
        ///     Class (<see cref="DeletedRecord" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DeletedRecord_Is_Instance_Present_Test()
        {
            // Assert
            _deletedRecordInstanceType.ShouldNotBeNull();
            _deletedRecordInstance.ShouldNotBeNull();
            _deletedRecordInstanceFixture.ShouldNotBeNull();
            _deletedRecordInstance.ShouldBeAssignableTo<DeletedRecord>();
            _deletedRecordInstanceFixture.ShouldBeAssignableTo<DeletedRecord>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DeletedRecord) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DeletedRecord_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DeletedRecord instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _deletedRecordInstanceType.ShouldNotBeNull();
            _deletedRecordInstance.ShouldNotBeNull();
            _deletedRecordInstanceFixture.ShouldNotBeNull();
            _deletedRecordInstance.ShouldBeAssignableTo<DeletedRecord>();
            _deletedRecordInstanceFixture.ShouldBeAssignableTo<DeletedRecord>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DeletedRecord) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.DateTime) , PropertydeletedDate)]
        [TestCaseGeneric(typeof(string) , Propertyid)]
        public void AUT_DeletedRecord_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DeletedRecord, T>(_deletedRecordInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DeletedRecord) => Property (deletedDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeletedRecord_deletedDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydeletedDate);
            Action currentAction = () => propertyInfo.SetValue(_deletedRecordInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DeletedRecord) => Property (deletedDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeletedRecord_Public_Class_deletedDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeletedDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DeletedRecord) => Property (id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DeletedRecord_Public_Class_id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}