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
using UplandIntegrations.TenroxUserService;
using UserSkill = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.UserSkill" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class UserSkillTest : AbstractBaseSetupV3Test
    {
        public UserSkillTest() : base(typeof(UserSkill))
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

        #region General Initializer : Class (UserSkill) Initializer

        #region Properties

        private const string PropertyProficiency = "Proficiency";
        private const string PropertySkill = "Skill";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1 = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey1";
        private const string PropertyUser = "User";

        #endregion

        #region Fields

        private const string FieldProficiencyField = "ProficiencyField";
        private const string FieldSkillField = "SkillField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field";
        private const string FieldUserField = "UserField";

        #endregion

        private Type _userSkillInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private UserSkill _userSkillInstance;
        private UserSkill _userSkillInstanceFixture;

        #region General Initializer : Class (UserSkill) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UserSkill" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _userSkillInstanceType = typeof(UserSkill);
            _userSkillInstanceFixture = this.Create<UserSkill>(true);
            _userSkillInstance = _userSkillInstanceFixture ?? this.Create<UserSkill>(false);
            CurrentInstance = _userSkillInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UserSkill)

        #region General Initializer : Class (UserSkill) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="UserSkill" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyProficiency)]
        [TestCase(PropertySkill)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1)]
        [TestCase(PropertyUser)]
        public void AUT_UserSkill_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_userSkillInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UserSkill) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UserSkill" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldProficiencyField)]
        [TestCase(FieldSkillField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field)]
        [TestCase(FieldUserField)]
        public void AUT_UserSkill_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_userSkillInstanceFixture, 
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
        ///     Class (<see cref="UserSkill" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_UserSkill_Is_Instance_Present_Test()
        {
            // Assert
            _userSkillInstanceType.ShouldNotBeNull();
            _userSkillInstance.ShouldNotBeNull();
            _userSkillInstanceFixture.ShouldNotBeNull();
            _userSkillInstance.ShouldBeAssignableTo<UserSkill>();
            _userSkillInstanceFixture.ShouldBeAssignableTo<UserSkill>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (UserSkill) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_UserSkill_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            UserSkill instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _userSkillInstanceType.ShouldNotBeNull();
            _userSkillInstance.ShouldNotBeNull();
            _userSkillInstanceFixture.ShouldNotBeNull();
            _userSkillInstance.ShouldBeAssignableTo<UserSkill>();
            _userSkillInstanceFixture.ShouldBeAssignableTo<UserSkill>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (UserSkill) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Proficiency) , PropertyProficiency)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Skill) , PropertySkill)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.User) , PropertyUser)]
        public void AUT_UserSkill_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<UserSkill, T>(_userSkillInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (UserSkill) => Property (Proficiency) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UserSkill_Proficiency_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProficiency);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProficiency);
            Action currentAction = () => propertyInfo.SetValue(_userSkillInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (UserSkill) => Property (Proficiency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UserSkill_Public_Class_Proficiency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProficiency);
            var propertyInfo  = this.GetPropertyInfo(PropertyProficiency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (UserSkill) => Property (Skill) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UserSkill_Skill_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySkill);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySkill);
            Action currentAction = () => propertyInfo.SetValue(_userSkillInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (UserSkill) => Property (Skill) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UserSkill_Public_Class_Skill_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySkill);
            var propertyInfo  = this.GetPropertyInfo(PropertySkill);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (UserSkill) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey1) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UserSkill_SystemDataObjectsDataClassesIEntityWithKeyEntityKey1_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1);
            Action currentAction = () => propertyInfo.SetValue(_userSkillInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (UserSkill) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UserSkill_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (UserSkill) => Property (User) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UserSkill_User_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUser);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyUser);
            Action currentAction = () => propertyInfo.SetValue(_userSkillInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (UserSkill) => Property (User) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_UserSkill_Public_Class_User_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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