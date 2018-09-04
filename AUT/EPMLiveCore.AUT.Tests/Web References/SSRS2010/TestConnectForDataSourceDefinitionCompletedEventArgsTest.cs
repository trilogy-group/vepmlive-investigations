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
using TestConnectForDataSourceDefinitionCompletedEventArgs = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.TestConnectForDataSourceDefinitionCompletedEventArgs" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TestConnectForDataSourceDefinitionCompletedEventArgsTest : AbstractBaseSetupTypedTest<TestConnectForDataSourceDefinitionCompletedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TestConnectForDataSourceDefinitionCompletedEventArgs) Initializer

        private const string PropertyResult = "Result";
        private const string PropertyConnectError = "ConnectError";
        private const string Fieldresults = "results";
        private Type _testConnectForDataSourceDefinitionCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TestConnectForDataSourceDefinitionCompletedEventArgs _testConnectForDataSourceDefinitionCompletedEventArgsInstance;
        private TestConnectForDataSourceDefinitionCompletedEventArgs _testConnectForDataSourceDefinitionCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (TestConnectForDataSourceDefinitionCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TestConnectForDataSourceDefinitionCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _testConnectForDataSourceDefinitionCompletedEventArgsInstanceType = typeof(TestConnectForDataSourceDefinitionCompletedEventArgs);
            _testConnectForDataSourceDefinitionCompletedEventArgsInstanceFixture = Create(true);
            _testConnectForDataSourceDefinitionCompletedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TestConnectForDataSourceDefinitionCompletedEventArgs)

        #region General Initializer : Class (TestConnectForDataSourceDefinitionCompletedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TestConnectForDataSourceDefinitionCompletedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyResult)]
        [TestCase(PropertyConnectError)]
        public void AUT_TestConnectForDataSourceDefinitionCompletedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_testConnectForDataSourceDefinitionCompletedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TestConnectForDataSourceDefinitionCompletedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TestConnectForDataSourceDefinitionCompletedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldresults)]
        public void AUT_TestConnectForDataSourceDefinitionCompletedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_testConnectForDataSourceDefinitionCompletedEventArgsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TestConnectForDataSourceDefinitionCompletedEventArgs) => Property (ConnectError) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TestConnectForDataSourceDefinitionCompletedEventArgs_Public_Class_ConnectError_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyConnectError);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TestConnectForDataSourceDefinitionCompletedEventArgs) => Property (Result) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TestConnectForDataSourceDefinitionCompletedEventArgs_Public_Class_Result_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyResult);

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