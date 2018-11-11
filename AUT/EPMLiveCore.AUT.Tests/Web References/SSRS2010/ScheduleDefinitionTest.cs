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
using ScheduleDefinition = EPMLiveCore.SSRS2010;

namespace EPMLiveCore.SSRS2010
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2010.ScheduleDefinition" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2010"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ScheduleDefinitionTest : AbstractBaseSetupTypedTest<ScheduleDefinition>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ScheduleDefinition) Initializer

        private const string PropertyStartDateTime = "StartDateTime";
        private const string PropertyEndDate = "EndDate";
        private const string PropertyEndDateSpecified = "EndDateSpecified";
        private const string PropertyItem = "Item";
        private const string FieldstartDateTimeField = "startDateTimeField";
        private const string FieldendDateField = "endDateField";
        private const string FieldendDateFieldSpecified = "endDateFieldSpecified";
        private const string FielditemField = "itemField";
        private Type _scheduleDefinitionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ScheduleDefinition _scheduleDefinitionInstance;
        private ScheduleDefinition _scheduleDefinitionInstanceFixture;

        #region General Initializer : Class (ScheduleDefinition) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ScheduleDefinition" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _scheduleDefinitionInstanceType = typeof(ScheduleDefinition);
            _scheduleDefinitionInstanceFixture = Create(true);
            _scheduleDefinitionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ScheduleDefinition)

        #region General Initializer : Class (ScheduleDefinition) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ScheduleDefinition" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyStartDateTime)]
        [TestCase(PropertyEndDate)]
        [TestCase(PropertyEndDateSpecified)]
        [TestCase(PropertyItem)]
        public void AUT_ScheduleDefinition_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_scheduleDefinitionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ScheduleDefinition) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ScheduleDefinition" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldstartDateTimeField)]
        [TestCase(FieldendDateField)]
        [TestCase(FieldendDateFieldSpecified)]
        [TestCase(FielditemField)]
        public void AUT_ScheduleDefinition_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_scheduleDefinitionInstanceFixture, 
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
        ///     Class (<see cref="ScheduleDefinition" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ScheduleDefinition_Is_Instance_Present_Test()
        {
            // Assert
            _scheduleDefinitionInstanceType.ShouldNotBeNull();
            _scheduleDefinitionInstance.ShouldNotBeNull();
            _scheduleDefinitionInstanceFixture.ShouldNotBeNull();
            _scheduleDefinitionInstance.ShouldBeAssignableTo<ScheduleDefinition>();
            _scheduleDefinitionInstanceFixture.ShouldBeAssignableTo<ScheduleDefinition>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ScheduleDefinition) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ScheduleDefinition_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ScheduleDefinition instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _scheduleDefinitionInstanceType.ShouldNotBeNull();
            _scheduleDefinitionInstance.ShouldNotBeNull();
            _scheduleDefinitionInstanceFixture.ShouldNotBeNull();
            _scheduleDefinitionInstance.ShouldBeAssignableTo<ScheduleDefinition>();
            _scheduleDefinitionInstanceFixture.ShouldBeAssignableTo<ScheduleDefinition>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ScheduleDefinition) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyStartDateTime)]
        [TestCaseGeneric(typeof(System.DateTime) , PropertyEndDate)]
        [TestCaseGeneric(typeof(bool) , PropertyEndDateSpecified)]
        [TestCaseGeneric(typeof(RecurrencePattern) , PropertyItem)]
        public void AUT_ScheduleDefinition_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ScheduleDefinition, T>(_scheduleDefinitionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDefinition) => Property (EndDate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleDefinition_EndDate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyEndDate);
            Action currentAction = () => propertyInfo.SetValue(_scheduleDefinitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDefinition) => Property (EndDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleDefinition_Public_Class_EndDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEndDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDefinition) => Property (EndDateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleDefinition_Public_Class_EndDateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyEndDateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDefinition) => Property (Item) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleDefinition_Item_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyItem);
            Action currentAction = () => propertyInfo.SetValue(_scheduleDefinitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDefinition) => Property (Item) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleDefinition_Public_Class_Item_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyItem);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDefinition) => Property (StartDateTime) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleDefinition_StartDateTime_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyStartDateTime);
            Action currentAction = () => propertyInfo.SetValue(_scheduleDefinitionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleDefinition) => Property (StartDateTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleDefinition_Public_Class_StartDateTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyStartDateTime);

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