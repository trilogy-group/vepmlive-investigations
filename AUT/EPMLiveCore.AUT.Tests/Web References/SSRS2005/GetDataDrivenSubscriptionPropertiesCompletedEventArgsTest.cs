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
using EPMLiveCore.SSRS2005;
using GetDataDrivenSubscriptionPropertiesCompletedEventArgs = EPMLiveCore.SSRS2005;

namespace EPMLiveCore.SSRS2005
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2005.GetDataDrivenSubscriptionPropertiesCompletedEventArgs" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2005"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetDataDrivenSubscriptionPropertiesCompletedEventArgsTest : AbstractBaseSetupTypedTest<GetDataDrivenSubscriptionPropertiesCompletedEventArgs>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) Initializer

        private const string PropertyResult = "Result";
        private const string PropertyExtensionSettings = "ExtensionSettings";
        private const string PropertyDataRetrievalPlan = "DataRetrievalPlan";
        private const string PropertyDescription = "Description";
        private const string PropertyActive = "Active";
        private const string PropertyStatus = "Status";
        private const string PropertyEventType = "EventType";
        private const string PropertyMatchData = "MatchData";
        private const string PropertyParameters = "Parameters";
        private const string Fieldresults = "results";
        private Type _getDataDrivenSubscriptionPropertiesCompletedEventArgsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GetDataDrivenSubscriptionPropertiesCompletedEventArgs _getDataDrivenSubscriptionPropertiesCompletedEventArgsInstance;
        private GetDataDrivenSubscriptionPropertiesCompletedEventArgs _getDataDrivenSubscriptionPropertiesCompletedEventArgsInstanceFixture;

        #region General Initializer : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GetDataDrivenSubscriptionPropertiesCompletedEventArgs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getDataDrivenSubscriptionPropertiesCompletedEventArgsInstanceType = typeof(GetDataDrivenSubscriptionPropertiesCompletedEventArgs);
            _getDataDrivenSubscriptionPropertiesCompletedEventArgsInstanceFixture = Create(true);
            _getDataDrivenSubscriptionPropertiesCompletedEventArgsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs)

        #region General Initializer : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GetDataDrivenSubscriptionPropertiesCompletedEventArgs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyResult)]
        [TestCase(PropertyExtensionSettings)]
        [TestCase(PropertyDataRetrievalPlan)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyActive)]
        [TestCase(PropertyStatus)]
        [TestCase(PropertyEventType)]
        [TestCase(PropertyMatchData)]
        [TestCase(PropertyParameters)]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_getDataDrivenSubscriptionPropertiesCompletedEventArgsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GetDataDrivenSubscriptionPropertiesCompletedEventArgs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldresults)]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getDataDrivenSubscriptionPropertiesCompletedEventArgsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (Active) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Active_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyActive);
            Action currentAction = () => propertyInfo.SetValue(_getDataDrivenSubscriptionPropertiesCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (Active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Public_Class_Active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyActive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (DataRetrievalPlan) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_DataRetrievalPlan_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDataRetrievalPlan);
            Action currentAction = () => propertyInfo.SetValue(_getDataDrivenSubscriptionPropertiesCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (DataRetrievalPlan) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Public_Class_DataRetrievalPlan_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDataRetrievalPlan);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (EventType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Public_Class_EventType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEventType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (ExtensionSettings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_ExtensionSettings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyExtensionSettings);
            Action currentAction = () => propertyInfo.SetValue(_getDataDrivenSubscriptionPropertiesCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (ExtensionSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Public_Class_ExtensionSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExtensionSettings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (MatchData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Public_Class_MatchData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyMatchData);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (Parameters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Parameters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyParameters);
            Action currentAction = () => propertyInfo.SetValue(_getDataDrivenSubscriptionPropertiesCompletedEventArgsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (Parameters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Public_Class_Parameters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyParameters);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (Result) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Public_Class_Result_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (GetDataDrivenSubscriptionPropertiesCompletedEventArgs) => Property (Status) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetDataDrivenSubscriptionPropertiesCompletedEventArgs_Public_Class_Status_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStatus);

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