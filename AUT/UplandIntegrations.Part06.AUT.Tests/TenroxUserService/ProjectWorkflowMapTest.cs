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
using ProjectWorkflowMap = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.ProjectWorkflowMap" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProjectWorkflowMapTest : AbstractBaseSetupV3Test
    {
        public ProjectWorkflowMapTest() : base(typeof(ProjectWorkflowMap))
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

        #region General Initializer : Class (ProjectWorkflowMap) Initializer

        #region Properties

        private const string PropertyDIAGRAMWEBPAGE = "DIAGRAMWEBPAGE";
        private const string PropertyPortfolio = "Portfolio";
        private const string PropertyProjectWorkflowOption = "ProjectWorkflowOption";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1 = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey1";
        private const string PropertySystemDefault = "SystemDefault";

        #endregion

        #region Fields

        private const string FieldDIAGRAMWEBPAGEField = "DIAGRAMWEBPAGEField";
        private const string FieldPortfolioField = "PortfolioField";
        private const string FieldProjectWorkflowOptionField = "ProjectWorkflowOptionField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field";
        private const string FieldSystemDefaultField = "SystemDefaultField";

        #endregion

        private Type _projectWorkflowMapInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ProjectWorkflowMap _projectWorkflowMapInstance;
        private ProjectWorkflowMap _projectWorkflowMapInstanceFixture;

        #region General Initializer : Class (ProjectWorkflowMap) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProjectWorkflowMap" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _projectWorkflowMapInstanceType = typeof(ProjectWorkflowMap);
            _projectWorkflowMapInstanceFixture = this.Create<ProjectWorkflowMap>(true);
            _projectWorkflowMapInstance = _projectWorkflowMapInstanceFixture ?? this.Create<ProjectWorkflowMap>(false);
            CurrentInstance = _projectWorkflowMapInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProjectWorkflowMap)

        #region General Initializer : Class (ProjectWorkflowMap) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProjectWorkflowMap" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDIAGRAMWEBPAGE)]
        [TestCase(PropertyPortfolio)]
        [TestCase(PropertyProjectWorkflowOption)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1)]
        [TestCase(PropertySystemDefault)]
        public void AUT_ProjectWorkflowMap_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_projectWorkflowMapInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProjectWorkflowMap) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProjectWorkflowMap" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldDIAGRAMWEBPAGEField)]
        [TestCase(FieldPortfolioField)]
        [TestCase(FieldProjectWorkflowOptionField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKey1Field)]
        [TestCase(FieldSystemDefaultField)]
        public void AUT_ProjectWorkflowMap_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_projectWorkflowMapInstanceFixture, 
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
        ///     Class (<see cref="ProjectWorkflowMap" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ProjectWorkflowMap_Is_Instance_Present_Test()
        {
            // Assert
            _projectWorkflowMapInstanceType.ShouldNotBeNull();
            _projectWorkflowMapInstance.ShouldNotBeNull();
            _projectWorkflowMapInstanceFixture.ShouldNotBeNull();
            _projectWorkflowMapInstance.ShouldBeAssignableTo<ProjectWorkflowMap>();
            _projectWorkflowMapInstanceFixture.ShouldBeAssignableTo<ProjectWorkflowMap>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProjectWorkflowMap) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ProjectWorkflowMap_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProjectWorkflowMap instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _projectWorkflowMapInstanceType.ShouldNotBeNull();
            _projectWorkflowMapInstance.ShouldNotBeNull();
            _projectWorkflowMapInstanceFixture.ShouldNotBeNull();
            _projectWorkflowMapInstance.ShouldBeAssignableTo<ProjectWorkflowMap>();
            _projectWorkflowMapInstanceFixture.ShouldBeAssignableTo<ProjectWorkflowMap>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProjectWorkflowMap) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyDIAGRAMWEBPAGE)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Portfolio[]) , PropertyPortfolio)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.ProjectWorkflowOption[]) , PropertyProjectWorkflowOption)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.SystemDefault[]) , PropertySystemDefault)]
        public void AUT_ProjectWorkflowMap_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<ProjectWorkflowMap, T>(_projectWorkflowMapInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectWorkflowMap) => Property (DIAGRAMWEBPAGE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectWorkflowMap_Public_Class_DIAGRAMWEBPAGE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDIAGRAMWEBPAGE);
            var propertyInfo  = this.GetPropertyInfo(PropertyDIAGRAMWEBPAGE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectWorkflowMap) => Property (Portfolio) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectWorkflowMap_Portfolio_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPortfolio);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyPortfolio);
            Action currentAction = () => propertyInfo.SetValue(_projectWorkflowMapInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectWorkflowMap) => Property (Portfolio) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectWorkflowMap_Public_Class_Portfolio_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPortfolio);
            var propertyInfo  = this.GetPropertyInfo(PropertyPortfolio);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectWorkflowMap) => Property (ProjectWorkflowOption) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectWorkflowMap_ProjectWorkflowOption_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflowOption);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectWorkflowOption);
            Action currentAction = () => propertyInfo.SetValue(_projectWorkflowMapInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectWorkflowMap) => Property (ProjectWorkflowOption) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectWorkflowMap_Public_Class_ProjectWorkflowOption_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflowOption);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectWorkflowOption);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectWorkflowMap) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey1) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectWorkflowMap_SystemDataObjectsDataClassesIEntityWithKeyEntityKey1_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey1);
            Action currentAction = () => propertyInfo.SetValue(_projectWorkflowMapInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectWorkflowMap) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectWorkflowMap_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProjectWorkflowMap) => Property (SystemDefault) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectWorkflowMap_SystemDefault_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDefault);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDefault);
            Action currentAction = () => propertyInfo.SetValue(_projectWorkflowMapInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectWorkflowMap) => Property (SystemDefault) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectWorkflowMap_Public_Class_SystemDefault_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDefault);
            var propertyInfo  = this.GetPropertyInfo(PropertySystemDefault);

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