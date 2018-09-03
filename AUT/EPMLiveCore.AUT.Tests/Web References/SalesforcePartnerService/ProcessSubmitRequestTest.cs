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
using ProcessSubmitRequest = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.ProcessSubmitRequest" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProcessSubmitRequestTest : AbstractBaseSetupTypedTest<ProcessSubmitRequest>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProcessSubmitRequest) Initializer

        private const string PropertyobjectId = "objectId";
        private const string FieldobjectIdField = "objectIdField";
        private Type _processSubmitRequestInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProcessSubmitRequest _processSubmitRequestInstance;
        private ProcessSubmitRequest _processSubmitRequestInstanceFixture;

        #region General Initializer : Class (ProcessSubmitRequest) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProcessSubmitRequest" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _processSubmitRequestInstanceType = typeof(ProcessSubmitRequest);
            _processSubmitRequestInstanceFixture = Create(true);
            _processSubmitRequestInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProcessSubmitRequest)

        #region General Initializer : Class (ProcessSubmitRequest) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProcessSubmitRequest" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyobjectId)]
        public void AUT_ProcessSubmitRequest_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_processSubmitRequestInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProcessSubmitRequest) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProcessSubmitRequest" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldobjectIdField)]
        public void AUT_ProcessSubmitRequest_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_processSubmitRequestInstanceFixture, 
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
        ///     Class (<see cref="ProcessSubmitRequest" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProcessSubmitRequest_Is_Instance_Present_Test()
        {
            // Assert
            _processSubmitRequestInstanceType.ShouldNotBeNull();
            _processSubmitRequestInstance.ShouldNotBeNull();
            _processSubmitRequestInstanceFixture.ShouldNotBeNull();
            _processSubmitRequestInstance.ShouldBeAssignableTo<ProcessSubmitRequest>();
            _processSubmitRequestInstanceFixture.ShouldBeAssignableTo<ProcessSubmitRequest>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProcessSubmitRequest) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProcessSubmitRequest_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProcessSubmitRequest instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _processSubmitRequestInstanceType.ShouldNotBeNull();
            _processSubmitRequestInstance.ShouldNotBeNull();
            _processSubmitRequestInstanceFixture.ShouldNotBeNull();
            _processSubmitRequestInstance.ShouldBeAssignableTo<ProcessSubmitRequest>();
            _processSubmitRequestInstanceFixture.ShouldBeAssignableTo<ProcessSubmitRequest>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProcessSubmitRequest) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyobjectId)]
        public void AUT_ProcessSubmitRequest_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProcessSubmitRequest, T>(_processSubmitRequestInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProcessSubmitRequest) => Property (objectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProcessSubmitRequest_Public_Class_objectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyobjectId);

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