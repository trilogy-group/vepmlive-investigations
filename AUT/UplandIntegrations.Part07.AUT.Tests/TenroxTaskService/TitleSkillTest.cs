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
using UplandIntegrations.TenroxTaskService;
using TitleSkill = UplandIntegrations.TenroxTaskService;

namespace UplandIntegrations.TenroxTaskService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxTaskService.TitleSkill" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxTaskService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TitleSkillTest : AbstractBaseSetupV3Test
    {
        public TitleSkillTest() : base(typeof(TitleSkill))
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

        #region General Initializer : Class (TitleSkill) Initializer

        #region Properties

        private const string PropertyProficiency = "Proficiency";
        private const string PropertySkill = "Skill";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1 = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey1";
        private const string PropertyTitle = "Title";

        #endregion

        #region Fields

        private const string FieldProficiencyField = "ProficiencyField";
        private const string FieldSkillField = "SkillField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field";
        private const string FieldTitleField = "TitleField";

        #endregion

        private Type _titleSkillInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private TitleSkill _titleSkillInstance;
        private TitleSkill _titleSkillInstanceFixture;

        #region General Initializer : Class (TitleSkill) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TitleSkill" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _titleSkillInstanceType = typeof(TitleSkill);
            _titleSkillInstanceFixture = this.Create<TitleSkill>(true);
            _titleSkillInstance = _titleSkillInstanceFixture ?? this.Create<TitleSkill>(false);
            CurrentInstance = _titleSkillInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TitleSkill)

        #region General Initializer : Class (TitleSkill) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TitleSkill" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyProficiency)]
        [TestCase(PropertySkill)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1)]
        [TestCase(PropertyTitle)]
        public void AUT_TitleSkill_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_titleSkillInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TitleSkill) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TitleSkill" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldProficiencyField)]
        [TestCase(FieldSkillField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field)]
        [TestCase(FieldTitleField)]
        public void AUT_TitleSkill_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_titleSkillInstanceFixture, 
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
        ///     Class (<see cref="TitleSkill" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_TitleSkill_Is_Instance_Present_Test()
        {
            // Assert
            _titleSkillInstanceType.ShouldNotBeNull();
            _titleSkillInstance.ShouldNotBeNull();
            _titleSkillInstanceFixture.ShouldNotBeNull();
            _titleSkillInstance.ShouldBeAssignableTo<TitleSkill>();
            _titleSkillInstanceFixture.ShouldBeAssignableTo<TitleSkill>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TitleSkill) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_TitleSkill_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            TitleSkill instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _titleSkillInstanceType.ShouldNotBeNull();
            _titleSkillInstance.ShouldNotBeNull();
            _titleSkillInstanceFixture.ShouldNotBeNull();
            _titleSkillInstance.ShouldBeAssignableTo<TitleSkill>();
            _titleSkillInstanceFixture.ShouldBeAssignableTo<TitleSkill>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TitleSkill) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Proficiency) , PropertyProficiency)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Skill) , PropertySkill)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Title) , PropertyTitle)]
        public void AUT_TitleSkill_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<TitleSkill, T>(_titleSkillInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (TitleSkill) => Property (Proficiency) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TitleSkill_Proficiency_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProficiency);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProficiency);
            Action currentAction = () => propertyInfo.SetValue(_titleSkillInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TitleSkill) => Property (Proficiency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TitleSkill_Public_Class_Proficiency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (TitleSkill) => Property (Skill) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TitleSkill_Skill_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySkill);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySkill);
            Action currentAction = () => propertyInfo.SetValue(_titleSkillInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TitleSkill) => Property (Skill) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TitleSkill_Public_Class_Skill_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (TitleSkill) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey1) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TitleSkill_SystemDataObjectsDataClassesIEntityWithKeyEntityKey1_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1);
            Action currentAction = () => propertyInfo.SetValue(_titleSkillInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TitleSkill) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TitleSkill_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (TitleSkill) => Property (Title) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TitleSkill_Title_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTitle);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTitle);
            Action currentAction = () => propertyInfo.SetValue(_titleSkillInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TitleSkill) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TitleSkill_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTitle);
            var propertyInfo  = this.GetPropertyInfo(PropertyTitle);

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