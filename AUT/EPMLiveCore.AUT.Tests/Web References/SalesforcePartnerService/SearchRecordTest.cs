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
using SearchRecord = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.SearchRecord" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SearchRecordTest : AbstractBaseSetupTypedTest<SearchRecord>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SearchRecord) Initializer

        private const string Propertyrecord = "record";
        private const string FieldrecordField = "recordField";
        private Type _searchRecordInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SearchRecord _searchRecordInstance;
        private SearchRecord _searchRecordInstanceFixture;

        #region General Initializer : Class (SearchRecord) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SearchRecord" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _searchRecordInstanceType = typeof(SearchRecord);
            _searchRecordInstanceFixture = Create(true);
            _searchRecordInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SearchRecord)

        #region General Initializer : Class (SearchRecord) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SearchRecord" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyrecord)]
        public void AUT_SearchRecord_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_searchRecordInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SearchRecord) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SearchRecord" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldrecordField)]
        public void AUT_SearchRecord_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_searchRecordInstanceFixture, 
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
        ///     Class (<see cref="SearchRecord" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SearchRecord_Is_Instance_Present_Test()
        {
            // Assert
            _searchRecordInstanceType.ShouldNotBeNull();
            _searchRecordInstance.ShouldNotBeNull();
            _searchRecordInstanceFixture.ShouldNotBeNull();
            _searchRecordInstance.ShouldBeAssignableTo<SearchRecord>();
            _searchRecordInstanceFixture.ShouldBeAssignableTo<SearchRecord>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SearchRecord) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SearchRecord_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SearchRecord instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _searchRecordInstanceType.ShouldNotBeNull();
            _searchRecordInstance.ShouldNotBeNull();
            _searchRecordInstanceFixture.ShouldNotBeNull();
            _searchRecordInstance.ShouldBeAssignableTo<SearchRecord>();
            _searchRecordInstanceFixture.ShouldBeAssignableTo<SearchRecord>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SearchRecord) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(sObject) , Propertyrecord)]
        public void AUT_SearchRecord_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SearchRecord, T>(_searchRecordInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SearchRecord) => Property (record) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchRecord_record_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyrecord);
            Action currentAction = () => propertyInfo.SetValue(_searchRecordInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SearchRecord) => Property (record) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SearchRecord_Public_Class_record_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrecord);

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