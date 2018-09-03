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
using StreamingEnabledHeader = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.StreamingEnabledHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class StreamingEnabledHeaderTest : AbstractBaseSetupTypedTest<StreamingEnabledHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (StreamingEnabledHeader) Initializer

        private const string PropertystreamingEnabled = "streamingEnabled";
        private const string FieldstreamingEnabledField = "streamingEnabledField";
        private Type _streamingEnabledHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private StreamingEnabledHeader _streamingEnabledHeaderInstance;
        private StreamingEnabledHeader _streamingEnabledHeaderInstanceFixture;

        #region General Initializer : Class (StreamingEnabledHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="StreamingEnabledHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _streamingEnabledHeaderInstanceType = typeof(StreamingEnabledHeader);
            _streamingEnabledHeaderInstanceFixture = Create(true);
            _streamingEnabledHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (StreamingEnabledHeader)

        #region General Initializer : Class (StreamingEnabledHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="StreamingEnabledHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertystreamingEnabled)]
        public void AUT_StreamingEnabledHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_streamingEnabledHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (StreamingEnabledHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="StreamingEnabledHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldstreamingEnabledField)]
        public void AUT_StreamingEnabledHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_streamingEnabledHeaderInstanceFixture, 
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
        ///     Class (<see cref="StreamingEnabledHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_StreamingEnabledHeader_Is_Instance_Present_Test()
        {
            // Assert
            _streamingEnabledHeaderInstanceType.ShouldNotBeNull();
            _streamingEnabledHeaderInstance.ShouldNotBeNull();
            _streamingEnabledHeaderInstanceFixture.ShouldNotBeNull();
            _streamingEnabledHeaderInstance.ShouldBeAssignableTo<StreamingEnabledHeader>();
            _streamingEnabledHeaderInstanceFixture.ShouldBeAssignableTo<StreamingEnabledHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (StreamingEnabledHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_StreamingEnabledHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            StreamingEnabledHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _streamingEnabledHeaderInstanceType.ShouldNotBeNull();
            _streamingEnabledHeaderInstance.ShouldNotBeNull();
            _streamingEnabledHeaderInstanceFixture.ShouldNotBeNull();
            _streamingEnabledHeaderInstance.ShouldBeAssignableTo<StreamingEnabledHeader>();
            _streamingEnabledHeaderInstanceFixture.ShouldBeAssignableTo<StreamingEnabledHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (StreamingEnabledHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertystreamingEnabled)]
        public void AUT_StreamingEnabledHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<StreamingEnabledHeader, T>(_streamingEnabledHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (StreamingEnabledHeader) => Property (streamingEnabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_StreamingEnabledHeader_Public_Class_streamingEnabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystreamingEnabled);

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