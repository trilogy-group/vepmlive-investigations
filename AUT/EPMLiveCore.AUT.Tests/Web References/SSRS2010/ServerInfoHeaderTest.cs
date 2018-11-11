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
using EPMLiveCore.SSRS2010;
using ServerInfoHeader = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.ServerInfoHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ServerInfoHeaderTest : AbstractBaseSetupTypedTest<ServerInfoHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ServerInfoHeader) Initializer

        private const string PropertyReportServerVersionNumber = "ReportServerVersionNumber";
        private const string PropertyReportServerEdition = "ReportServerEdition";
        private const string PropertyReportServerVersion = "ReportServerVersion";
        private const string PropertyReportServerDateTime = "ReportServerDateTime";
        private const string PropertyReportServerTimeZoneInfo = "ReportServerTimeZoneInfo";
        private const string PropertyAnyAttr = "AnyAttr";
        private const string FieldreportServerVersionNumberField = "reportServerVersionNumberField";
        private const string FieldreportServerEditionField = "reportServerEditionField";
        private const string FieldreportServerVersionField = "reportServerVersionField";
        private const string FieldreportServerDateTimeField = "reportServerDateTimeField";
        private const string FieldreportServerTimeZoneInfoField = "reportServerTimeZoneInfoField";
        private const string FieldanyAttrField = "anyAttrField";
        private Type _serverInfoHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ServerInfoHeader _serverInfoHeaderInstance;
        private ServerInfoHeader _serverInfoHeaderInstanceFixture;

        #region General Initializer : Class (ServerInfoHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ServerInfoHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _serverInfoHeaderInstanceType = typeof(ServerInfoHeader);
            _serverInfoHeaderInstanceFixture = Create(true);
            _serverInfoHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ServerInfoHeader)

        #region General Initializer : Class (ServerInfoHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ServerInfoHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyReportServerVersionNumber)]
        [TestCase(PropertyReportServerEdition)]
        [TestCase(PropertyReportServerVersion)]
        [TestCase(PropertyReportServerDateTime)]
        [TestCase(PropertyReportServerTimeZoneInfo)]
        [TestCase(PropertyAnyAttr)]
        public void AUT_ServerInfoHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_serverInfoHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ServerInfoHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ServerInfoHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldreportServerVersionNumberField)]
        [TestCase(FieldreportServerEditionField)]
        [TestCase(FieldreportServerVersionField)]
        [TestCase(FieldreportServerDateTimeField)]
        [TestCase(FieldreportServerTimeZoneInfoField)]
        [TestCase(FieldanyAttrField)]
        public void AUT_ServerInfoHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_serverInfoHeaderInstanceFixture, 
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
        ///     Class (<see cref="ServerInfoHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ServerInfoHeader_Is_Instance_Present_Test()
        {
            // Assert
            _serverInfoHeaderInstanceType.ShouldNotBeNull();
            _serverInfoHeaderInstance.ShouldNotBeNull();
            _serverInfoHeaderInstanceFixture.ShouldNotBeNull();
            _serverInfoHeaderInstance.ShouldBeAssignableTo<ServerInfoHeader>();
            _serverInfoHeaderInstanceFixture.ShouldBeAssignableTo<ServerInfoHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ServerInfoHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ServerInfoHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ServerInfoHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _serverInfoHeaderInstanceType.ShouldNotBeNull();
            _serverInfoHeaderInstance.ShouldNotBeNull();
            _serverInfoHeaderInstanceFixture.ShouldNotBeNull();
            _serverInfoHeaderInstance.ShouldBeAssignableTo<ServerInfoHeader>();
            _serverInfoHeaderInstanceFixture.ShouldBeAssignableTo<ServerInfoHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ServerInfoHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyReportServerVersionNumber)]
        [TestCaseGeneric(typeof(string) , PropertyReportServerEdition)]
        [TestCaseGeneric(typeof(string) , PropertyReportServerVersion)]
        [TestCaseGeneric(typeof(string) , PropertyReportServerDateTime)]
        [TestCaseGeneric(typeof(TimeZoneInformation) , PropertyReportServerTimeZoneInfo)]
        [TestCaseGeneric(typeof(System.Xml.XmlAttribute[]) , PropertyAnyAttr)]
        public void AUT_ServerInfoHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ServerInfoHeader, T>(_serverInfoHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ServerInfoHeader) => Property (AnyAttr) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ServerInfoHeader_AnyAttr_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyAnyAttr);
            Action currentAction = () => propertyInfo.SetValue(_serverInfoHeaderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ServerInfoHeader) => Property (AnyAttr) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ServerInfoHeader_Public_Class_AnyAttr_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAnyAttr);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ServerInfoHeader) => Property (ReportServerDateTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ServerInfoHeader_Public_Class_ReportServerDateTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportServerDateTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ServerInfoHeader) => Property (ReportServerEdition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ServerInfoHeader_Public_Class_ReportServerEdition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportServerEdition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ServerInfoHeader) => Property (ReportServerTimeZoneInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ServerInfoHeader_ReportServerTimeZoneInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyReportServerTimeZoneInfo);
            Action currentAction = () => propertyInfo.SetValue(_serverInfoHeaderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ServerInfoHeader) => Property (ReportServerTimeZoneInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ServerInfoHeader_Public_Class_ReportServerTimeZoneInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportServerTimeZoneInfo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ServerInfoHeader) => Property (ReportServerVersion) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ServerInfoHeader_Public_Class_ReportServerVersion_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportServerVersion);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ServerInfoHeader) => Property (ReportServerVersionNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ServerInfoHeader_Public_Class_ReportServerVersionNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportServerVersionNumber);

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