using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.BaseSetup.Version.V2;
using AUT.ConfigureTestProjects.BaseSetup.Version.V3;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.Model;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using UplandIntegrations.TenroxClientService;
using UsersBusinessUnits = UplandIntegrations.TenroxClientService;

namespace UplandIntegrations.TenroxClientService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxClientService.UsersBusinessUnits" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxClientService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class UsersBusinessUnitsTest : AbstractBaseSetupV3Test
    {
        public UsersBusinessUnitsTest() : base(typeof(UsersBusinessUnits))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Overrides of IAbstractBaseSetupV2Test

        /// <summary>
        ///    Configure and ignore problematic tests.
        ///    Added tests will be ignored.
        /// </summary>
        public override void ConfigureIgnoringTests()
        {
            base.ConfigureIgnoringTests();
        }

        #endregion

        #region General Initializer : Class (UsersBusinessUnits) Initializer

        #region Properties

        private const string PropertyBusinessUnit = "BusinessUnit";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1 = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey1";
        private const string PropertyUser = "User";

        #endregion

        #region Fields

        private const string FieldBusinessUnitField = "BusinessUnitField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field";
        private const string FieldUserField = "UserField";

        #endregion

        private Type _usersBusinessUnitsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private UsersBusinessUnits _usersBusinessUnitsInstance;
        private UsersBusinessUnits _usersBusinessUnitsInstanceFixture;

        #region General Initializer : Class (UsersBusinessUnits) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UsersBusinessUnits" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _usersBusinessUnitsInstanceType = typeof(UsersBusinessUnits);
            _usersBusinessUnitsInstanceFixture = this.Create<UsersBusinessUnits>(true);
            _usersBusinessUnitsInstance = _usersBusinessUnitsInstanceFixture ?? this.Create<UsersBusinessUnits>(false);
            CurrentInstance = _usersBusinessUnitsInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UsersBusinessUnits)

        #region General Initializer : Class (UsersBusinessUnits) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="UsersBusinessUnits" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyBusinessUnit)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1)]
        [TestCase(PropertyUser)]
        public void AUT_UsersBusinessUnits_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_usersBusinessUnitsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UsersBusinessUnits) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UsersBusinessUnits" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldBusinessUnitField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field)]
        [TestCase(FieldUserField)]
        public void AUT_UsersBusinessUnits_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_usersBusinessUnitsInstanceFixture, 
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
        ///     Class (<see cref="UsersBusinessUnits" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_UsersBusinessUnits_Is_Instance_Present_Test()
        {
            // Assert
            _usersBusinessUnitsInstanceType.ShouldNotBeNull();
            _usersBusinessUnitsInstance.ShouldNotBeNull();
            _usersBusinessUnitsInstanceFixture.ShouldNotBeNull();
            _usersBusinessUnitsInstance.ShouldBeAssignableTo<UsersBusinessUnits>();
            _usersBusinessUnitsInstanceFixture.ShouldBeAssignableTo<UsersBusinessUnits>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (UsersBusinessUnits) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_UsersBusinessUnits_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            UsersBusinessUnits instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _usersBusinessUnitsInstanceType.ShouldNotBeNull();
            _usersBusinessUnitsInstance.ShouldNotBeNull();
            _usersBusinessUnitsInstanceFixture.ShouldNotBeNull();
            _usersBusinessUnitsInstance.ShouldBeAssignableTo<UsersBusinessUnits>();
            _usersBusinessUnitsInstanceFixture.ShouldBeAssignableTo<UsersBusinessUnits>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (UsersBusinessUnits) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxClientService.BusinessUnit) , PropertyBusinessUnit)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxClientService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxClientService.User) , PropertyUser)]
        public void AUT_UsersBusinessUnits_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<UsersBusinessUnits, T>(_usersBusinessUnitsInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (UsersBusinessUnits) => Property (BusinessUnit) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UsersBusinessUnits_BusinessUnit_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBusinessUnit);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyBusinessUnit);
            Action currentAction = () => propertyInfo.SetValue(_usersBusinessUnitsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (UsersBusinessUnits) => Property (BusinessUnit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UsersBusinessUnits_Public_Class_BusinessUnit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBusinessUnit);
            var propertyInfo  = this.GetPropertyInfo(PropertyBusinessUnit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (UsersBusinessUnits) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey1) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UsersBusinessUnits_SystemDataObjectsDataClassesIEntityWithKeyEntityKey1_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1);
            Action currentAction = () => propertyInfo.SetValue(_usersBusinessUnitsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (UsersBusinessUnits) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UsersBusinessUnits_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1);
            var propertyInfo  = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (UsersBusinessUnits) => Property (User) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UsersBusinessUnits_User_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUser);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyUser);
            Action currentAction = () => propertyInfo.SetValue(_usersBusinessUnitsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (UsersBusinessUnits) => Property (User) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UsersBusinessUnits_Public_Class_User_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUser);
            var propertyInfo  = this.GetPropertyInfo(PropertyUser);

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