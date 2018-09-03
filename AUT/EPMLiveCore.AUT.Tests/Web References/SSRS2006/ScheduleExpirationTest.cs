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
using EPMLiveCore.SSRS2006;
using ScheduleExpiration = EPMLiveCore.SSRS2006;

namespace EPMLiveCore.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SSRS2006.ScheduleExpiration" />)
    ///     and namespace <see cref="EPMLiveCore.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ScheduleExpirationTest : AbstractBaseSetupTypedTest<ScheduleExpiration>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ScheduleExpiration) Initializer

        private const string PropertyItem = "Item";
        private const string FielditemField = "itemField";
        private Type _scheduleExpirationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ScheduleExpiration _scheduleExpirationInstance;
        private ScheduleExpiration _scheduleExpirationInstanceFixture;

        #region General Initializer : Class (ScheduleExpiration) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ScheduleExpiration" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _scheduleExpirationInstanceType = typeof(ScheduleExpiration);
            _scheduleExpirationInstanceFixture = Create(true);
            _scheduleExpirationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ScheduleExpiration)

        #region General Initializer : Class (ScheduleExpiration) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ScheduleExpiration" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyItem)]
        public void AUT_ScheduleExpiration_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_scheduleExpirationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ScheduleExpiration) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ScheduleExpiration" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielditemField)]
        public void AUT_ScheduleExpiration_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_scheduleExpirationInstanceFixture, 
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
        ///     Class (<see cref="ScheduleExpiration" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ScheduleExpiration_Is_Instance_Present_Test()
        {
            // Assert
            _scheduleExpirationInstanceType.ShouldNotBeNull();
            _scheduleExpirationInstance.ShouldNotBeNull();
            _scheduleExpirationInstanceFixture.ShouldNotBeNull();
            _scheduleExpirationInstance.ShouldBeAssignableTo<ScheduleExpiration>();
            _scheduleExpirationInstanceFixture.ShouldBeAssignableTo<ScheduleExpiration>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ScheduleExpiration) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ScheduleExpiration_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ScheduleExpiration instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _scheduleExpirationInstanceType.ShouldNotBeNull();
            _scheduleExpirationInstance.ShouldNotBeNull();
            _scheduleExpirationInstanceFixture.ShouldNotBeNull();
            _scheduleExpirationInstance.ShouldBeAssignableTo<ScheduleExpiration>();
            _scheduleExpirationInstanceFixture.ShouldBeAssignableTo<ScheduleExpiration>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ScheduleExpiration) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ScheduleDefinitionOrReference) , PropertyItem)]
        public void AUT_ScheduleExpiration_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ScheduleExpiration, T>(_scheduleExpirationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleExpiration) => Property (Item) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleExpiration_Item_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyItem);
            Action currentAction = () => propertyInfo.SetValue(_scheduleExpirationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ScheduleExpiration) => Property (Item) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ScheduleExpiration_Public_Class_Item_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}