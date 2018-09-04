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
using AssignmentRuleHeader = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.AssignmentRuleHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AssignmentRuleHeaderTest : AbstractBaseSetupTypedTest<AssignmentRuleHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AssignmentRuleHeader) Initializer

        private const string PropertyassignmentRuleId = "assignmentRuleId";
        private const string PropertyuseDefaultRule = "useDefaultRule";
        private const string FieldassignmentRuleIdField = "assignmentRuleIdField";
        private const string FielduseDefaultRuleField = "useDefaultRuleField";
        private Type _assignmentRuleHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AssignmentRuleHeader _assignmentRuleHeaderInstance;
        private AssignmentRuleHeader _assignmentRuleHeaderInstanceFixture;

        #region General Initializer : Class (AssignmentRuleHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AssignmentRuleHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _assignmentRuleHeaderInstanceType = typeof(AssignmentRuleHeader);
            _assignmentRuleHeaderInstanceFixture = Create(true);
            _assignmentRuleHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AssignmentRuleHeader)

        #region General Initializer : Class (AssignmentRuleHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AssignmentRuleHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignmentRuleId)]
        [TestCase(PropertyuseDefaultRule)]
        public void AUT_AssignmentRuleHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_assignmentRuleHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AssignmentRuleHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AssignmentRuleHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignmentRuleIdField)]
        [TestCase(FielduseDefaultRuleField)]
        public void AUT_AssignmentRuleHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_assignmentRuleHeaderInstanceFixture, 
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
        ///     Class (<see cref="AssignmentRuleHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AssignmentRuleHeader_Is_Instance_Present_Test()
        {
            // Assert
            _assignmentRuleHeaderInstanceType.ShouldNotBeNull();
            _assignmentRuleHeaderInstance.ShouldNotBeNull();
            _assignmentRuleHeaderInstanceFixture.ShouldNotBeNull();
            _assignmentRuleHeaderInstance.ShouldBeAssignableTo<AssignmentRuleHeader>();
            _assignmentRuleHeaderInstanceFixture.ShouldBeAssignableTo<AssignmentRuleHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AssignmentRuleHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AssignmentRuleHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AssignmentRuleHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _assignmentRuleHeaderInstanceType.ShouldNotBeNull();
            _assignmentRuleHeaderInstance.ShouldNotBeNull();
            _assignmentRuleHeaderInstanceFixture.ShouldNotBeNull();
            _assignmentRuleHeaderInstance.ShouldBeAssignableTo<AssignmentRuleHeader>();
            _assignmentRuleHeaderInstanceFixture.ShouldBeAssignableTo<AssignmentRuleHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AssignmentRuleHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyassignmentRuleId)]
        [TestCaseGeneric(typeof(System.Nullable<bool>) , PropertyuseDefaultRule)]
        public void AUT_AssignmentRuleHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AssignmentRuleHeader, T>(_assignmentRuleHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentRuleHeader) => Property (assignmentRuleId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AssignmentRuleHeader_Public_Class_assignmentRuleId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignmentRuleId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AssignmentRuleHeader) => Property (useDefaultRule) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AssignmentRuleHeader_Public_Class_useDefaultRule_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseDefaultRule);

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