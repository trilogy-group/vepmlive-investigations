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
using Portfolio = UplandIntegrations.TenroxClientService;

namespace UplandIntegrations.TenroxClientService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxClientService.Portfolio" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxClientService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PortfolioTest : AbstractBaseSetupV3Test
    {
        public PortfolioTest() : base(typeof(Portfolio))
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

        #region General Initializer : Class (Portfolio) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccessType = "AccessType";
        private const string PropertyBenchmarkProjectAlignA = "BenchmarkProjectAlignA";
        private const string PropertyBenchmarkProjectAlignB = "BenchmarkProjectAlignB";
        private const string PropertyBenchmarkProjectAlignC = "BenchmarkProjectAlignC";
        private const string PropertyBenchmarkProjectReturnA = "BenchmarkProjectReturnA";
        private const string PropertyBenchmarkProjectReturnB = "BenchmarkProjectReturnB";
        private const string PropertyBenchmarkProjectReturnC = "BenchmarkProjectReturnC";
        private const string PropertyBudgets = "Budgets";
        private const string PropertyClientId = "ClientId";
        private const string PropertyDescription = "Description";
        private const string PropertyHierarchyCode = "HierarchyCode";
        private const string PropertyId = "Id";
        private const string PropertyIsPlaceholder = "IsPlaceholder";
        private const string PropertyLargeExpectedCost = "LargeExpectedCost";
        private const string PropertyLargeMaximumLossAcceptable = "LargeMaximumLossAcceptable";
        private const string PropertyLargeMinBenefitAcceptable = "LargeMinBenefitAcceptable";
        private const string PropertyLevelNumber = "LevelNumber";
        private const string PropertyMSProjectFilePath = "MSProjectFilePath";
        private const string PropertyManagerid = "Managerid";
        private const string PropertyName = "Name";
        private const string PropertyParentId = "ParentId";
        private const string PropertyPortfolioType = "PortfolioType";
        private const string PropertyProjectAlias = "ProjectAlias";
        private const string PropertyProjectWorkflowMap = "ProjectWorkflowMap";
        private const string PropertyProjectWorkflowMapId = "ProjectWorkflowMapId";
        private const string PropertyProjects = "Projects";
        private const string PropertyScoreProjects = "ScoreProjects";
        private const string PropertySmallExpectedCost = "SmallExpectedCost";
        private const string PropertySmallMaximumLossAcceptable = "SmallMaximumLossAcceptable";
        private const string PropertySmallMinBenefitAcceptable = "SmallMinBenefitAcceptable";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyType = "Type";
        private const string PropertyUniqueId = "UniqueId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccessTypeField = "AccessTypeField";
        private const string FieldBenchmarkProjectAlignAField = "BenchmarkProjectAlignAField";
        private const string FieldBenchmarkProjectAlignBField = "BenchmarkProjectAlignBField";
        private const string FieldBenchmarkProjectAlignCField = "BenchmarkProjectAlignCField";
        private const string FieldBenchmarkProjectReturnAField = "BenchmarkProjectReturnAField";
        private const string FieldBenchmarkProjectReturnBField = "BenchmarkProjectReturnBField";
        private const string FieldBenchmarkProjectReturnCField = "BenchmarkProjectReturnCField";
        private const string FieldBudgetsField = "BudgetsField";
        private const string FieldClientIdField = "ClientIdField";
        private const string FieldDescriptionField = "DescriptionField";
        private const string FieldHierarchyCodeField = "HierarchyCodeField";
        private const string FieldIdField = "IdField";
        private const string FieldIsPlaceholderField = "IsPlaceholderField";
        private const string FieldLargeExpectedCostField = "LargeExpectedCostField";
        private const string FieldLargeMaximumLossAcceptableField = "LargeMaximumLossAcceptableField";
        private const string FieldLargeMinBenefitAcceptableField = "LargeMinBenefitAcceptableField";
        private const string FieldLevelNumberField = "LevelNumberField";
        private const string FieldMSProjectFilePathField = "MSProjectFilePathField";
        private const string FieldManageridField = "ManageridField";
        private const string FieldNameField = "NameField";
        private const string FieldParentIdField = "ParentIdField";
        private const string FieldPortfolioTypeField = "PortfolioTypeField";
        private const string FieldProjectAliasField = "ProjectAliasField";
        private const string FieldProjectWorkflowMapField = "ProjectWorkflowMapField";
        private const string FieldProjectWorkflowMapIdField = "ProjectWorkflowMapIdField";
        private const string FieldProjectsField = "ProjectsField";
        private const string FieldScoreProjectsField = "ScoreProjectsField";
        private const string FieldSmallExpectedCostField = "SmallExpectedCostField";
        private const string FieldSmallMaximumLossAcceptableField = "SmallMaximumLossAcceptableField";
        private const string FieldSmallMinBenefitAcceptableField = "SmallMinBenefitAcceptableField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTypeField = "TypeField";
        private const string FieldUniqueIdField = "UniqueIdField";

        #endregion

        private Type _portfolioInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private Portfolio _portfolioInstance;
        private Portfolio _portfolioInstanceFixture;

        #region General Initializer : Class (Portfolio) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Portfolio" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _portfolioInstanceType = typeof(Portfolio);
            _portfolioInstanceFixture = this.Create<Portfolio>(true);
            _portfolioInstance = _portfolioInstanceFixture ?? this.Create<Portfolio>(false);
            CurrentInstance = _portfolioInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Portfolio)

        #region General Initializer : Class (Portfolio) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Portfolio" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_Portfolio_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_portfolioInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Portfolio) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Portfolio" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccessType)]
        [TestCase(PropertyBenchmarkProjectAlignA)]
        [TestCase(PropertyBenchmarkProjectAlignB)]
        [TestCase(PropertyBenchmarkProjectAlignC)]
        [TestCase(PropertyBenchmarkProjectReturnA)]
        [TestCase(PropertyBenchmarkProjectReturnB)]
        [TestCase(PropertyBenchmarkProjectReturnC)]
        [TestCase(PropertyBudgets)]
        [TestCase(PropertyClientId)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyHierarchyCode)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIsPlaceholder)]
        [TestCase(PropertyLargeExpectedCost)]
        [TestCase(PropertyLargeMaximumLossAcceptable)]
        [TestCase(PropertyLargeMinBenefitAcceptable)]
        [TestCase(PropertyLevelNumber)]
        [TestCase(PropertyMSProjectFilePath)]
        [TestCase(PropertyManagerid)]
        [TestCase(PropertyName)]
        [TestCase(PropertyParentId)]
        [TestCase(PropertyPortfolioType)]
        [TestCase(PropertyProjectAlias)]
        [TestCase(PropertyProjectWorkflowMap)]
        [TestCase(PropertyProjectWorkflowMapId)]
        [TestCase(PropertyProjects)]
        [TestCase(PropertyScoreProjects)]
        [TestCase(PropertySmallExpectedCost)]
        [TestCase(PropertySmallMaximumLossAcceptable)]
        [TestCase(PropertySmallMinBenefitAcceptable)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyType)]
        [TestCase(PropertyUniqueId)]
        public void AUT_Portfolio_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_portfolioInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Portfolio) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Portfolio" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccessTypeField)]
        [TestCase(FieldBenchmarkProjectAlignAField)]
        [TestCase(FieldBenchmarkProjectAlignBField)]
        [TestCase(FieldBenchmarkProjectAlignCField)]
        [TestCase(FieldBenchmarkProjectReturnAField)]
        [TestCase(FieldBenchmarkProjectReturnBField)]
        [TestCase(FieldBenchmarkProjectReturnCField)]
        [TestCase(FieldBudgetsField)]
        [TestCase(FieldClientIdField)]
        [TestCase(FieldDescriptionField)]
        [TestCase(FieldHierarchyCodeField)]
        [TestCase(FieldIdField)]
        [TestCase(FieldIsPlaceholderField)]
        [TestCase(FieldLargeExpectedCostField)]
        [TestCase(FieldLargeMaximumLossAcceptableField)]
        [TestCase(FieldLargeMinBenefitAcceptableField)]
        [TestCase(FieldLevelNumberField)]
        [TestCase(FieldMSProjectFilePathField)]
        [TestCase(FieldManageridField)]
        [TestCase(FieldNameField)]
        [TestCase(FieldParentIdField)]
        [TestCase(FieldPortfolioTypeField)]
        [TestCase(FieldProjectAliasField)]
        [TestCase(FieldProjectWorkflowMapField)]
        [TestCase(FieldProjectWorkflowMapIdField)]
        [TestCase(FieldProjectsField)]
        [TestCase(FieldScoreProjectsField)]
        [TestCase(FieldSmallExpectedCostField)]
        [TestCase(FieldSmallMaximumLossAcceptableField)]
        [TestCase(FieldSmallMinBenefitAcceptableField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTypeField)]
        [TestCase(FieldUniqueIdField)]
        public void AUT_Portfolio_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_portfolioInstanceFixture, 
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
        ///     Class (<see cref="Portfolio" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Portfolio_Is_Instance_Present_Test()
        {
            // Assert
            _portfolioInstanceType.ShouldNotBeNull();
            _portfolioInstance.ShouldNotBeNull();
            _portfolioInstanceFixture.ShouldNotBeNull();
            _portfolioInstance.ShouldBeAssignableTo<Portfolio>();
            _portfolioInstanceFixture.ShouldBeAssignableTo<Portfolio>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Portfolio) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Portfolio_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Portfolio instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _portfolioInstanceType.ShouldNotBeNull();
            _portfolioInstance.ShouldNotBeNull();
            _portfolioInstanceFixture.ShouldNotBeNull();
            _portfolioInstance.ShouldBeAssignableTo<Portfolio>();
            _portfolioInstanceFixture.ShouldBeAssignableTo<Portfolio>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Portfolio) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyAccessType)]
        [TestCaseGeneric(typeof(string) , PropertyBenchmarkProjectAlignA)]
        [TestCaseGeneric(typeof(string) , PropertyBenchmarkProjectAlignB)]
        [TestCaseGeneric(typeof(string) , PropertyBenchmarkProjectAlignC)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyBenchmarkProjectReturnA)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyBenchmarkProjectReturnB)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyBenchmarkProjectReturnC)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxClientService.PortfolioBudget[]) , PropertyBudgets)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyClientId)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(string) , PropertyHierarchyCode)]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsPlaceholder)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyLargeExpectedCost)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyLargeMaximumLossAcceptable)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyLargeMinBenefitAcceptable)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyLevelNumber)]
        [TestCaseGeneric(typeof(string) , PropertyMSProjectFilePath)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyManagerid)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyParentId)]
        [TestCaseGeneric(typeof(string) , PropertyPortfolioType)]
        [TestCaseGeneric(typeof(string) , PropertyProjectAlias)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxClientService.ProjectWorkflowMap) , PropertyProjectWorkflowMap)]
        [TestCaseGeneric(typeof(int) , PropertyProjectWorkflowMapId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxClientService.Project[]) , PropertyProjects)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyScoreProjects)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertySmallExpectedCost)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertySmallMaximumLossAcceptable)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertySmallMinBenefitAcceptable)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxClientService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(string) , PropertyType)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        public void AUT_Portfolio_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<Portfolio, T>(_portfolioInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (AccessType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_AccessType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccessType);
            var propertyInfo  = this.GetPropertyInfo(PropertyAccessType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (BenchmarkProjectAlignA) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_BenchmarkProjectAlignA_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBenchmarkProjectAlignA);
            var propertyInfo  = this.GetPropertyInfo(PropertyBenchmarkProjectAlignA);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (BenchmarkProjectAlignB) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_BenchmarkProjectAlignB_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBenchmarkProjectAlignB);
            var propertyInfo  = this.GetPropertyInfo(PropertyBenchmarkProjectAlignB);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (BenchmarkProjectAlignC) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_BenchmarkProjectAlignC_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBenchmarkProjectAlignC);
            var propertyInfo  = this.GetPropertyInfo(PropertyBenchmarkProjectAlignC);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (BenchmarkProjectReturnA) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_BenchmarkProjectReturnA_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBenchmarkProjectReturnA);
            var propertyInfo  = this.GetPropertyInfo(PropertyBenchmarkProjectReturnA);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (BenchmarkProjectReturnB) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_BenchmarkProjectReturnB_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBenchmarkProjectReturnB);
            var propertyInfo  = this.GetPropertyInfo(PropertyBenchmarkProjectReturnB);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (BenchmarkProjectReturnC) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_BenchmarkProjectReturnC_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBenchmarkProjectReturnC);
            var propertyInfo  = this.GetPropertyInfo(PropertyBenchmarkProjectReturnC);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (Budgets) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Budgets_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBudgets);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyBudgets);
            Action currentAction = () => propertyInfo.SetValue(_portfolioInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (Budgets) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_Budgets_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBudgets);
            var propertyInfo  = this.GetPropertyInfo(PropertyBudgets);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (ClientId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_ClientId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyClientId);
            var propertyInfo  = this.GetPropertyInfo(PropertyClientId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDescription);
            var propertyInfo  = this.GetPropertyInfo(PropertyDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_portfolioInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var propertyInfo  = this.GetPropertyInfo(PropertyExtensionData);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (HierarchyCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_HierarchyCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyHierarchyCode);
            var propertyInfo  = this.GetPropertyInfo(PropertyHierarchyCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyId);
            var propertyInfo  = this.GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (IsPlaceholder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_IsPlaceholder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsPlaceholder);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsPlaceholder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (LargeExpectedCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_LargeExpectedCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLargeExpectedCost);
            var propertyInfo  = this.GetPropertyInfo(PropertyLargeExpectedCost);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (LargeMaximumLossAcceptable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_LargeMaximumLossAcceptable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLargeMaximumLossAcceptable);
            var propertyInfo  = this.GetPropertyInfo(PropertyLargeMaximumLossAcceptable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (LargeMinBenefitAcceptable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_LargeMinBenefitAcceptable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLargeMinBenefitAcceptable);
            var propertyInfo  = this.GetPropertyInfo(PropertyLargeMinBenefitAcceptable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (LevelNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_LevelNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLevelNumber);
            var propertyInfo  = this.GetPropertyInfo(PropertyLevelNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (Managerid) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_Managerid_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyManagerid);
            var propertyInfo  = this.GetPropertyInfo(PropertyManagerid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (MSProjectFilePath) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_MSProjectFilePath_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMSProjectFilePath);
            var propertyInfo  = this.GetPropertyInfo(PropertyMSProjectFilePath);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyName);
            var propertyInfo  = this.GetPropertyInfo(PropertyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (ParentId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_ParentId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyParentId);
            var propertyInfo  = this.GetPropertyInfo(PropertyParentId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (PortfolioType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_PortfolioType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPortfolioType);
            var propertyInfo  = this.GetPropertyInfo(PropertyPortfolioType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (ProjectAlias) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_ProjectAlias_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectAlias);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectAlias);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (Projects) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Projects_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjects);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjects);
            Action currentAction = () => propertyInfo.SetValue(_portfolioInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (Projects) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_Projects_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjects);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjects);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (ProjectWorkflowMap) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_ProjectWorkflowMap_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflowMap);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectWorkflowMap);
            Action currentAction = () => propertyInfo.SetValue(_portfolioInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (ProjectWorkflowMap) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_ProjectWorkflowMap_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflowMap);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectWorkflowMap);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (ProjectWorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_ProjectWorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflowMapId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectWorkflowMapId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (ScoreProjects) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_ScoreProjects_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyScoreProjects);
            var propertyInfo  = this.GetPropertyInfo(PropertyScoreProjects);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (SmallExpectedCost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_SmallExpectedCost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySmallExpectedCost);
            var propertyInfo  = this.GetPropertyInfo(PropertySmallExpectedCost);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (SmallMaximumLossAcceptable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_SmallMaximumLossAcceptable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySmallMaximumLossAcceptable);
            var propertyInfo  = this.GetPropertyInfo(PropertySmallMaximumLossAcceptable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (SmallMinBenefitAcceptable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_SmallMinBenefitAcceptable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySmallMinBenefitAcceptable);
            var propertyInfo  = this.GetPropertyInfo(PropertySmallMinBenefitAcceptable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_portfolioInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var propertyInfo  = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (Type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_Type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyType);
            var propertyInfo  = this.GetPropertyInfo(PropertyType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portfolio) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Portfolio_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUniqueId);
            var propertyInfo  = this.GetPropertyInfo(PropertyUniqueId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : (RaisePropertyChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Portfolio_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Portfolio_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_portfolioInstanceFixture, parametersOfRaisePropertyChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRaisePropertyChanged.ShouldNotBeNull();
            parametersOfRaisePropertyChanged.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(parametersOfRaisePropertyChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Portfolio_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_portfolioInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

            // Assert
            parametersOfRaisePropertyChanged.ShouldNotBeNull();
            parametersOfRaisePropertyChanged.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(parametersOfRaisePropertyChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Portfolio_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Portfolio_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_portfolioInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Portfolio_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_portfolioInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}