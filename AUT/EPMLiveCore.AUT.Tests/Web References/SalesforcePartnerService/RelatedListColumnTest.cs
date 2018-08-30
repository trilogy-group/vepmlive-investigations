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
using RelatedListColumn = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.RelatedListColumn" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RelatedListColumnTest : AbstractBaseSetupTypedTest<RelatedListColumn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RelatedListColumn) Initializer

        private const string Propertyfield = "field";
        private const string Propertyformat = "format";
        private const string Propertylabel = "label";
        private const string PropertylookupId = "lookupId";
        private const string Propertyname = "name";
        private const string FieldfieldField = "fieldField";
        private const string FieldformatField = "formatField";
        private const string FieldlabelField = "labelField";
        private const string FieldlookupIdField = "lookupIdField";
        private const string FieldnameField = "nameField";
        private Type _relatedListColumnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RelatedListColumn _relatedListColumnInstance;
        private RelatedListColumn _relatedListColumnInstanceFixture;

        #region General Initializer : Class (RelatedListColumn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RelatedListColumn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _relatedListColumnInstanceType = typeof(RelatedListColumn);
            _relatedListColumnInstanceFixture = Create(true);
            _relatedListColumnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RelatedListColumn)

        #region General Initializer : Class (RelatedListColumn) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RelatedListColumn" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyfield)]
        [TestCase(Propertyformat)]
        [TestCase(Propertylabel)]
        [TestCase(PropertylookupId)]
        [TestCase(Propertyname)]
        public void AUT_RelatedListColumn_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_relatedListColumnInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RelatedListColumn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RelatedListColumn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfieldField)]
        [TestCase(FieldformatField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlookupIdField)]
        [TestCase(FieldnameField)]
        public void AUT_RelatedListColumn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_relatedListColumnInstanceFixture, 
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
        ///     Class (<see cref="RelatedListColumn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RelatedListColumn_Is_Instance_Present_Test()
        {
            // Assert
            _relatedListColumnInstanceType.ShouldNotBeNull();
            _relatedListColumnInstance.ShouldNotBeNull();
            _relatedListColumnInstanceFixture.ShouldNotBeNull();
            _relatedListColumnInstance.ShouldBeAssignableTo<RelatedListColumn>();
            _relatedListColumnInstanceFixture.ShouldBeAssignableTo<RelatedListColumn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RelatedListColumn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RelatedListColumn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RelatedListColumn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _relatedListColumnInstanceType.ShouldNotBeNull();
            _relatedListColumnInstance.ShouldNotBeNull();
            _relatedListColumnInstanceFixture.ShouldNotBeNull();
            _relatedListColumnInstance.ShouldBeAssignableTo<RelatedListColumn>();
            _relatedListColumnInstanceFixture.ShouldBeAssignableTo<RelatedListColumn>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RelatedListColumn) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(string) , Propertyformat)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , PropertylookupId)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_RelatedListColumn_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RelatedListColumn, T>(_relatedListColumnInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListColumn) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListColumn_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListColumn) => Property (format) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListColumn_Public_Class_format_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyformat);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListColumn) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListColumn_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListColumn) => Property (lookupId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListColumn_Public_Class_lookupId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylookupId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RelatedListColumn) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RelatedListColumn_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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