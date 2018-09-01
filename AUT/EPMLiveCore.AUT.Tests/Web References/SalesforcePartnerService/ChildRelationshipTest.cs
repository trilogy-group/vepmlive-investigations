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
using ChildRelationship = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.ChildRelationship" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ChildRelationshipTest : AbstractBaseSetupTypedTest<ChildRelationship>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ChildRelationship) Initializer

        private const string PropertycascadeDelete = "cascadeDelete";
        private const string PropertychildSObject = "childSObject";
        private const string PropertydeprecatedAndHidden = "deprecatedAndHidden";
        private const string Propertyfield = "field";
        private const string PropertyrelationshipName = "relationshipName";
        private const string PropertyrestrictedDelete = "restrictedDelete";
        private const string PropertyrestrictedDeleteSpecified = "restrictedDeleteSpecified";
        private const string FieldcascadeDeleteField = "cascadeDeleteField";
        private const string FieldchildSObjectField = "childSObjectField";
        private const string FielddeprecatedAndHiddenField = "deprecatedAndHiddenField";
        private const string FieldfieldField = "fieldField";
        private const string FieldrelationshipNameField = "relationshipNameField";
        private const string FieldrestrictedDeleteField = "restrictedDeleteField";
        private const string FieldrestrictedDeleteFieldSpecified = "restrictedDeleteFieldSpecified";
        private Type _childRelationshipInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ChildRelationship _childRelationshipInstance;
        private ChildRelationship _childRelationshipInstanceFixture;

        #region General Initializer : Class (ChildRelationship) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChildRelationship" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _childRelationshipInstanceType = typeof(ChildRelationship);
            _childRelationshipInstanceFixture = Create(true);
            _childRelationshipInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChildRelationship)

        #region General Initializer : Class (ChildRelationship) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ChildRelationship" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycascadeDelete)]
        [TestCase(PropertychildSObject)]
        [TestCase(PropertydeprecatedAndHidden)]
        [TestCase(Propertyfield)]
        [TestCase(PropertyrelationshipName)]
        [TestCase(PropertyrestrictedDelete)]
        [TestCase(PropertyrestrictedDeleteSpecified)]
        public void AUT_ChildRelationship_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_childRelationshipInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChildRelationship) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ChildRelationship" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcascadeDeleteField)]
        [TestCase(FieldchildSObjectField)]
        [TestCase(FielddeprecatedAndHiddenField)]
        [TestCase(FieldfieldField)]
        [TestCase(FieldrelationshipNameField)]
        [TestCase(FieldrestrictedDeleteField)]
        [TestCase(FieldrestrictedDeleteFieldSpecified)]
        public void AUT_ChildRelationship_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_childRelationshipInstanceFixture, 
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
        ///     Class (<see cref="ChildRelationship" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ChildRelationship_Is_Instance_Present_Test()
        {
            // Assert
            _childRelationshipInstanceType.ShouldNotBeNull();
            _childRelationshipInstance.ShouldNotBeNull();
            _childRelationshipInstanceFixture.ShouldNotBeNull();
            _childRelationshipInstance.ShouldBeAssignableTo<ChildRelationship>();
            _childRelationshipInstanceFixture.ShouldBeAssignableTo<ChildRelationship>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ChildRelationship) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ChildRelationship_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ChildRelationship instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _childRelationshipInstanceType.ShouldNotBeNull();
            _childRelationshipInstance.ShouldNotBeNull();
            _childRelationshipInstanceFixture.ShouldNotBeNull();
            _childRelationshipInstance.ShouldBeAssignableTo<ChildRelationship>();
            _childRelationshipInstanceFixture.ShouldBeAssignableTo<ChildRelationship>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ChildRelationship) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertycascadeDelete)]
        [TestCaseGeneric(typeof(string) , PropertychildSObject)]
        [TestCaseGeneric(typeof(bool) , PropertydeprecatedAndHidden)]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(string) , PropertyrelationshipName)]
        [TestCaseGeneric(typeof(bool) , PropertyrestrictedDelete)]
        [TestCaseGeneric(typeof(bool) , PropertyrestrictedDeleteSpecified)]
        public void AUT_ChildRelationship_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ChildRelationship, T>(_childRelationshipInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ChildRelationship) => Property (cascadeDelete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChildRelationship_Public_Class_cascadeDelete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycascadeDelete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChildRelationship) => Property (childSObject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChildRelationship_Public_Class_childSObject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychildSObject);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChildRelationship) => Property (deprecatedAndHidden) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChildRelationship_Public_Class_deprecatedAndHidden_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeprecatedAndHidden);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChildRelationship) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChildRelationship_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ChildRelationship) => Property (relationshipName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChildRelationship_Public_Class_relationshipName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelationshipName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChildRelationship) => Property (restrictedDelete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChildRelationship_Public_Class_restrictedDelete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrestrictedDelete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChildRelationship) => Property (restrictedDeleteSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChildRelationship_Public_Class_restrictedDeleteSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrestrictedDeleteSpecified);

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