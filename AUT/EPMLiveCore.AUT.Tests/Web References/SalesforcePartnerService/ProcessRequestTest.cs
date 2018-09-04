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
using ProcessRequest = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.ProcessRequest" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProcessRequestTest : AbstractBaseSetupTypedTest<ProcessRequest>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProcessRequest) Initializer

        private const string Propertycomments = "comments";
        private const string PropertynextApproverIds = "nextApproverIds";
        private const string FieldcommentsField = "commentsField";
        private const string FieldnextApproverIdsField = "nextApproverIdsField";
        private Type _processRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProcessRequest _processRequestInstance;
        private ProcessRequest _processRequestInstanceFixture;

        #region General Initializer : Class (ProcessRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProcessRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _processRequestInstanceType = typeof(ProcessRequest);
            _processRequestInstanceFixture = Create(true);
            _processRequestInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProcessRequest)

        #region General Initializer : Class (ProcessRequest) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProcessRequest" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycomments)]
        [TestCase(PropertynextApproverIds)]
        public void AUT_ProcessRequest_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_processRequestInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProcessRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProcessRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcommentsField)]
        [TestCase(FieldnextApproverIdsField)]
        public void AUT_ProcessRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_processRequestInstanceFixture, 
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
        ///     Class (<see cref="ProcessRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProcessRequest_Is_Instance_Present_Test()
        {
            // Assert
            _processRequestInstanceType.ShouldNotBeNull();
            _processRequestInstance.ShouldNotBeNull();
            _processRequestInstanceFixture.ShouldNotBeNull();
            _processRequestInstance.ShouldBeAssignableTo<ProcessRequest>();
            _processRequestInstanceFixture.ShouldBeAssignableTo<ProcessRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProcessRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProcessRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProcessRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _processRequestInstanceType.ShouldNotBeNull();
            _processRequestInstance.ShouldNotBeNull();
            _processRequestInstanceFixture.ShouldNotBeNull();
            _processRequestInstance.ShouldBeAssignableTo<ProcessRequest>();
            _processRequestInstanceFixture.ShouldBeAssignableTo<ProcessRequest>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProcessRequest) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertycomments)]
        [TestCaseGeneric(typeof(string[]) , PropertynextApproverIds)]
        public void AUT_ProcessRequest_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProcessRequest, T>(_processRequestInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProcessRequest) => Property (comments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProcessRequest_Public_Class_comments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycomments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProcessRequest) => Property (nextApproverIds) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProcessRequest_nextApproverIds_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertynextApproverIds);
            Action currentAction = () => propertyInfo.SetValue(_processRequestInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProcessRequest) => Property (nextApproverIds) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProcessRequest_Public_Class_nextApproverIds_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynextApproverIds);

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