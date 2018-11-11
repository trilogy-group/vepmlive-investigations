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
using ProcessWorkitemRequest = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.ProcessWorkitemRequest" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProcessWorkitemRequestTest : AbstractBaseSetupTypedTest<ProcessWorkitemRequest>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProcessWorkitemRequest) Initializer

        private const string Propertyaction = "action";
        private const string PropertyworkitemId = "workitemId";
        private const string FieldactionField = "actionField";
        private const string FieldworkitemIdField = "workitemIdField";
        private Type _processWorkitemRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProcessWorkitemRequest _processWorkitemRequestInstance;
        private ProcessWorkitemRequest _processWorkitemRequestInstanceFixture;

        #region General Initializer : Class (ProcessWorkitemRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProcessWorkitemRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _processWorkitemRequestInstanceType = typeof(ProcessWorkitemRequest);
            _processWorkitemRequestInstanceFixture = Create(true);
            _processWorkitemRequestInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProcessWorkitemRequest)

        #region General Initializer : Class (ProcessWorkitemRequest) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProcessWorkitemRequest" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyaction)]
        [TestCase(PropertyworkitemId)]
        public void AUT_ProcessWorkitemRequest_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_processWorkitemRequestInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProcessWorkitemRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProcessWorkitemRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactionField)]
        [TestCase(FieldworkitemIdField)]
        public void AUT_ProcessWorkitemRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_processWorkitemRequestInstanceFixture, 
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
        ///     Class (<see cref="ProcessWorkitemRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProcessWorkitemRequest_Is_Instance_Present_Test()
        {
            // Assert
            _processWorkitemRequestInstanceType.ShouldNotBeNull();
            _processWorkitemRequestInstance.ShouldNotBeNull();
            _processWorkitemRequestInstanceFixture.ShouldNotBeNull();
            _processWorkitemRequestInstance.ShouldBeAssignableTo<ProcessWorkitemRequest>();
            _processWorkitemRequestInstanceFixture.ShouldBeAssignableTo<ProcessWorkitemRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProcessWorkitemRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProcessWorkitemRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProcessWorkitemRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _processWorkitemRequestInstanceType.ShouldNotBeNull();
            _processWorkitemRequestInstance.ShouldNotBeNull();
            _processWorkitemRequestInstanceFixture.ShouldNotBeNull();
            _processWorkitemRequestInstance.ShouldBeAssignableTo<ProcessWorkitemRequest>();
            _processWorkitemRequestInstanceFixture.ShouldBeAssignableTo<ProcessWorkitemRequest>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProcessWorkitemRequest) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyaction)]
        [TestCaseGeneric(typeof(string) , PropertyworkitemId)]
        public void AUT_ProcessWorkitemRequest_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProcessWorkitemRequest, T>(_processWorkitemRequestInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProcessWorkitemRequest) => Property (action) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProcessWorkitemRequest_Public_Class_action_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyaction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProcessWorkitemRequest) => Property (workitemId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProcessWorkitemRequest_Public_Class_workitemId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyworkitemId);

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