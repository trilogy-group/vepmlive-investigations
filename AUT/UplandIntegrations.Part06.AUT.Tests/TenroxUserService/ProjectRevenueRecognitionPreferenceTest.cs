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
using ProjectRevenueRecognitionPreference = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.ProjectRevenueRecognitionPreference" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProjectRevenueRecognitionPreferenceTest : AbstractBaseSetupV3Test
    {
        public ProjectRevenueRecognitionPreferenceTest() : base(typeof(ProjectRevenueRecognitionPreference))
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

        #region General Initializer : Class (ProjectRevenueRecognitionPreference) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyFixedPriceWithAverageRateTypeAverageRate = "FixedPriceWithAverageRateTypeAverageRate";
        private const string PropertyFixedPriceWithAverageRateTypeBudgetedHours = "FixedPriceWithAverageRateTypeBudgetedHours";
        private const string PropertyFixedPriceWithAverageRateTypeCanOverridePercentageToRecognize = "FixedPriceWithAverageRateTypeCanOverridePercentageToRecognize";
        private const string PropertyInstallmentTypeTotalRevenue = "InstallmentTypeTotalRevenue";
        private const string PropertyPercentCompleteTypeCanOverridePercentComplete = "PercentCompleteTypeCanOverridePercentComplete";
        private const string PropertyPercentCompleteTypeTotalRevenue = "PercentCompleteTypeTotalRevenue";
        private const string PropertyPercentCompleteTypeUseSystemMilestonePercentageComplete = "PercentCompleteTypeUseSystemMilestonePercentageComplete";
        private const string PropertyProject = "Project";
        private const string PropertyProjectId = "ProjectId";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTimeAndMaterialTypeChargeRevenueAccount = "TimeAndMaterialTypeChargeRevenueAccount";
        private const string PropertyTimeAndMaterialTypeChargeSelected = "TimeAndMaterialTypeChargeSelected";
        private const string PropertyTimeAndMaterialTypeChargeWIPAccount = "TimeAndMaterialTypeChargeWIPAccount";
        private const string PropertyTimeAndMaterialTypeExpenseRevenueAccount = "TimeAndMaterialTypeExpenseRevenueAccount";
        private const string PropertyTimeAndMaterialTypeExpenseSelected = "TimeAndMaterialTypeExpenseSelected";
        private const string PropertyTimeAndMaterialTypeExpenseWIPAccount = "TimeAndMaterialTypeExpenseWIPAccount";
        private const string PropertyTimeAndMaterialTypeProductRevenueAccount = "TimeAndMaterialTypeProductRevenueAccount";
        private const string PropertyTimeAndMaterialTypeProductSelected = "TimeAndMaterialTypeProductSelected";
        private const string PropertyTimeAndMaterialTypeProductWIPAccount = "TimeAndMaterialTypeProductWIPAccount";
        private const string PropertyTimeAndMaterialTypeTimeRevenueAccount = "TimeAndMaterialTypeTimeRevenueAccount";
        private const string PropertyTimeAndMaterialTypeTimeSelected = "TimeAndMaterialTypeTimeSelected";
        private const string PropertyTimeAndMaterialTypeTimeWIPAccount = "TimeAndMaterialTypeTimeWIPAccount";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldFixedPriceWithAverageRateTypeAverageRateField = "FixedPriceWithAverageRateTypeAverageRateField";
        private const string FieldFixedPriceWithAverageRateTypeBudgetedHoursField = "FixedPriceWithAverageRateTypeBudgetedHoursField";
        private const string FieldFixedPriceWithAverageRateTypeCanOverridePercentageToRecognizeField = "FixedPriceWithAverageRateTypeCanOverridePercentageToRecognizeField";
        private const string FieldInstallmentTypeTotalRevenueField = "InstallmentTypeTotalRevenueField";
        private const string FieldPercentCompleteTypeCanOverridePercentCompleteField = "PercentCompleteTypeCanOverridePercentCompleteField";
        private const string FieldPercentCompleteTypeTotalRevenueField = "PercentCompleteTypeTotalRevenueField";
        private const string FieldPercentCompleteTypeUseSystemMilestonePercentageCompleteField = "PercentCompleteTypeUseSystemMilestonePercentageCompleteField";
        private const string FieldProjectField = "ProjectField";
        private const string FieldProjectIdField = "ProjectIdField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTimeAndMaterialTypeChargeRevenueAccountField = "TimeAndMaterialTypeChargeRevenueAccountField";
        private const string FieldTimeAndMaterialTypeChargeSelectedField = "TimeAndMaterialTypeChargeSelectedField";
        private const string FieldTimeAndMaterialTypeChargeWIPAccountField = "TimeAndMaterialTypeChargeWIPAccountField";
        private const string FieldTimeAndMaterialTypeExpenseRevenueAccountField = "TimeAndMaterialTypeExpenseRevenueAccountField";
        private const string FieldTimeAndMaterialTypeExpenseSelectedField = "TimeAndMaterialTypeExpenseSelectedField";
        private const string FieldTimeAndMaterialTypeExpenseWIPAccountField = "TimeAndMaterialTypeExpenseWIPAccountField";
        private const string FieldTimeAndMaterialTypeProductRevenueAccountField = "TimeAndMaterialTypeProductRevenueAccountField";
        private const string FieldTimeAndMaterialTypeProductSelectedField = "TimeAndMaterialTypeProductSelectedField";
        private const string FieldTimeAndMaterialTypeProductWIPAccountField = "TimeAndMaterialTypeProductWIPAccountField";
        private const string FieldTimeAndMaterialTypeTimeRevenueAccountField = "TimeAndMaterialTypeTimeRevenueAccountField";
        private const string FieldTimeAndMaterialTypeTimeSelectedField = "TimeAndMaterialTypeTimeSelectedField";
        private const string FieldTimeAndMaterialTypeTimeWIPAccountField = "TimeAndMaterialTypeTimeWIPAccountField";

        #endregion

        private Type _projectRevenueRecognitionPreferenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private ProjectRevenueRecognitionPreference _projectRevenueRecognitionPreferenceInstance;
        private ProjectRevenueRecognitionPreference _projectRevenueRecognitionPreferenceInstanceFixture;

        #region General Initializer : Class (ProjectRevenueRecognitionPreference) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProjectRevenueRecognitionPreference" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _projectRevenueRecognitionPreferenceInstanceType = typeof(ProjectRevenueRecognitionPreference);
            _projectRevenueRecognitionPreferenceInstanceFixture = this.Create<ProjectRevenueRecognitionPreference>(true);
            _projectRevenueRecognitionPreferenceInstance = _projectRevenueRecognitionPreferenceInstanceFixture ?? this.Create<ProjectRevenueRecognitionPreference>(false);
            CurrentInstance = _projectRevenueRecognitionPreferenceInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProjectRevenueRecognitionPreference)

        #region General Initializer : Class (ProjectRevenueRecognitionPreference) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ProjectRevenueRecognitionPreference" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_ProjectRevenueRecognitionPreference_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_projectRevenueRecognitionPreferenceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProjectRevenueRecognitionPreference) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProjectRevenueRecognitionPreference" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyFixedPriceWithAverageRateTypeAverageRate)]
        [TestCase(PropertyFixedPriceWithAverageRateTypeBudgetedHours)]
        [TestCase(PropertyFixedPriceWithAverageRateTypeCanOverridePercentageToRecognize)]
        [TestCase(PropertyInstallmentTypeTotalRevenue)]
        [TestCase(PropertyPercentCompleteTypeCanOverridePercentComplete)]
        [TestCase(PropertyPercentCompleteTypeTotalRevenue)]
        [TestCase(PropertyPercentCompleteTypeUseSystemMilestonePercentageComplete)]
        [TestCase(PropertyProject)]
        [TestCase(PropertyProjectId)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTimeAndMaterialTypeChargeRevenueAccount)]
        [TestCase(PropertyTimeAndMaterialTypeChargeSelected)]
        [TestCase(PropertyTimeAndMaterialTypeChargeWIPAccount)]
        [TestCase(PropertyTimeAndMaterialTypeExpenseRevenueAccount)]
        [TestCase(PropertyTimeAndMaterialTypeExpenseSelected)]
        [TestCase(PropertyTimeAndMaterialTypeExpenseWIPAccount)]
        [TestCase(PropertyTimeAndMaterialTypeProductRevenueAccount)]
        [TestCase(PropertyTimeAndMaterialTypeProductSelected)]
        [TestCase(PropertyTimeAndMaterialTypeProductWIPAccount)]
        [TestCase(PropertyTimeAndMaterialTypeTimeRevenueAccount)]
        [TestCase(PropertyTimeAndMaterialTypeTimeSelected)]
        [TestCase(PropertyTimeAndMaterialTypeTimeWIPAccount)]
        public void AUT_ProjectRevenueRecognitionPreference_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_projectRevenueRecognitionPreferenceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProjectRevenueRecognitionPreference) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProjectRevenueRecognitionPreference" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldFixedPriceWithAverageRateTypeAverageRateField)]
        [TestCase(FieldFixedPriceWithAverageRateTypeBudgetedHoursField)]
        [TestCase(FieldFixedPriceWithAverageRateTypeCanOverridePercentageToRecognizeField)]
        [TestCase(FieldInstallmentTypeTotalRevenueField)]
        [TestCase(FieldPercentCompleteTypeCanOverridePercentCompleteField)]
        [TestCase(FieldPercentCompleteTypeTotalRevenueField)]
        [TestCase(FieldPercentCompleteTypeUseSystemMilestonePercentageCompleteField)]
        [TestCase(FieldProjectField)]
        [TestCase(FieldProjectIdField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTimeAndMaterialTypeChargeRevenueAccountField)]
        [TestCase(FieldTimeAndMaterialTypeChargeSelectedField)]
        [TestCase(FieldTimeAndMaterialTypeChargeWIPAccountField)]
        [TestCase(FieldTimeAndMaterialTypeExpenseRevenueAccountField)]
        [TestCase(FieldTimeAndMaterialTypeExpenseSelectedField)]
        [TestCase(FieldTimeAndMaterialTypeExpenseWIPAccountField)]
        [TestCase(FieldTimeAndMaterialTypeProductRevenueAccountField)]
        [TestCase(FieldTimeAndMaterialTypeProductSelectedField)]
        [TestCase(FieldTimeAndMaterialTypeProductWIPAccountField)]
        [TestCase(FieldTimeAndMaterialTypeTimeRevenueAccountField)]
        [TestCase(FieldTimeAndMaterialTypeTimeSelectedField)]
        [TestCase(FieldTimeAndMaterialTypeTimeWIPAccountField)]
        public void AUT_ProjectRevenueRecognitionPreference_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_projectRevenueRecognitionPreferenceInstanceFixture, 
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
        ///     Class (<see cref="ProjectRevenueRecognitionPreference" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ProjectRevenueRecognitionPreference_Is_Instance_Present_Test()
        {
            // Assert
            _projectRevenueRecognitionPreferenceInstanceType.ShouldNotBeNull();
            _projectRevenueRecognitionPreferenceInstance.ShouldNotBeNull();
            _projectRevenueRecognitionPreferenceInstanceFixture.ShouldNotBeNull();
            _projectRevenueRecognitionPreferenceInstance.ShouldBeAssignableTo<ProjectRevenueRecognitionPreference>();
            _projectRevenueRecognitionPreferenceInstanceFixture.ShouldBeAssignableTo<ProjectRevenueRecognitionPreference>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProjectRevenueRecognitionPreference) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ProjectRevenueRecognitionPreference_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProjectRevenueRecognitionPreference instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _projectRevenueRecognitionPreferenceInstanceType.ShouldNotBeNull();
            _projectRevenueRecognitionPreferenceInstance.ShouldNotBeNull();
            _projectRevenueRecognitionPreferenceInstanceFixture.ShouldNotBeNull();
            _projectRevenueRecognitionPreferenceInstance.ShouldBeAssignableTo<ProjectRevenueRecognitionPreference>();
            _projectRevenueRecognitionPreferenceInstanceFixture.ShouldBeAssignableTo<ProjectRevenueRecognitionPreference>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyFixedPriceWithAverageRateTypeAverageRate)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyFixedPriceWithAverageRateTypeBudgetedHours)]
        [TestCaseGeneric(typeof(System.Nullable<byte>) , PropertyFixedPriceWithAverageRateTypeCanOverridePercentageToRecognize)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyInstallmentTypeTotalRevenue)]
        [TestCaseGeneric(typeof(System.Nullable<byte>) , PropertyPercentCompleteTypeCanOverridePercentComplete)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyPercentCompleteTypeTotalRevenue)]
        [TestCaseGeneric(typeof(System.Nullable<byte>) , PropertyPercentCompleteTypeUseSystemMilestonePercentageComplete)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.Project) , PropertyProject)]
        [TestCaseGeneric(typeof(int) , PropertyProjectId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeAndMaterialTypeChargeRevenueAccount)]
        [TestCaseGeneric(typeof(System.Nullable<byte>) , PropertyTimeAndMaterialTypeChargeSelected)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeAndMaterialTypeChargeWIPAccount)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeAndMaterialTypeExpenseRevenueAccount)]
        [TestCaseGeneric(typeof(System.Nullable<byte>) , PropertyTimeAndMaterialTypeExpenseSelected)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeAndMaterialTypeExpenseWIPAccount)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeAndMaterialTypeProductRevenueAccount)]
        [TestCaseGeneric(typeof(System.Nullable<byte>) , PropertyTimeAndMaterialTypeProductSelected)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeAndMaterialTypeProductWIPAccount)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeAndMaterialTypeTimeRevenueAccount)]
        [TestCaseGeneric(typeof(System.Nullable<byte>) , PropertyTimeAndMaterialTypeTimeSelected)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTimeAndMaterialTypeTimeWIPAccount)]
        public void AUT_ProjectRevenueRecognitionPreference_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<ProjectRevenueRecognitionPreference, T>(_projectRevenueRecognitionPreferenceInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_projectRevenueRecognitionPreferenceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (FixedPriceWithAverageRateTypeAverageRate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_FixedPriceWithAverageRateTypeAverageRate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFixedPriceWithAverageRateTypeAverageRate);
            var propertyInfo  = this.GetPropertyInfo(PropertyFixedPriceWithAverageRateTypeAverageRate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (FixedPriceWithAverageRateTypeBudgetedHours) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_FixedPriceWithAverageRateTypeBudgetedHours_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFixedPriceWithAverageRateTypeBudgetedHours);
            var propertyInfo  = this.GetPropertyInfo(PropertyFixedPriceWithAverageRateTypeBudgetedHours);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (FixedPriceWithAverageRateTypeCanOverridePercentageToRecognize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_FixedPriceWithAverageRateTypeCanOverridePercentageToRecognize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFixedPriceWithAverageRateTypeCanOverridePercentageToRecognize);
            var propertyInfo  = this.GetPropertyInfo(PropertyFixedPriceWithAverageRateTypeCanOverridePercentageToRecognize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (InstallmentTypeTotalRevenue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_InstallmentTypeTotalRevenue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInstallmentTypeTotalRevenue);
            var propertyInfo  = this.GetPropertyInfo(PropertyInstallmentTypeTotalRevenue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (PercentCompleteTypeCanOverridePercentComplete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_PercentCompleteTypeCanOverridePercentComplete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPercentCompleteTypeCanOverridePercentComplete);
            var propertyInfo  = this.GetPropertyInfo(PropertyPercentCompleteTypeCanOverridePercentComplete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (PercentCompleteTypeTotalRevenue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_PercentCompleteTypeTotalRevenue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPercentCompleteTypeTotalRevenue);
            var propertyInfo  = this.GetPropertyInfo(PropertyPercentCompleteTypeTotalRevenue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (PercentCompleteTypeUseSystemMilestonePercentageComplete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_PercentCompleteTypeUseSystemMilestonePercentageComplete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPercentCompleteTypeUseSystemMilestonePercentageComplete);
            var propertyInfo  = this.GetPropertyInfo(PropertyPercentCompleteTypeUseSystemMilestonePercentageComplete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (Project) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Project_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProject);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProject);
            Action currentAction = () => propertyInfo.SetValue(_projectRevenueRecognitionPreferenceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (Project) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_Project_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProject);
            var propertyInfo  = this.GetPropertyInfo(PropertyProject);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (ProjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_ProjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_projectRevenueRecognitionPreferenceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeChargeRevenueAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeChargeRevenueAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeChargeRevenueAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeChargeRevenueAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeChargeSelected) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeChargeSelected_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeChargeSelected);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeChargeSelected);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeChargeWIPAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeChargeWIPAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeChargeWIPAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeChargeWIPAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeExpenseRevenueAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeExpenseRevenueAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeExpenseRevenueAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeExpenseRevenueAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeExpenseSelected) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeExpenseSelected_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeExpenseSelected);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeExpenseSelected);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeExpenseWIPAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeExpenseWIPAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeExpenseWIPAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeExpenseWIPAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeProductRevenueAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeProductRevenueAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeProductRevenueAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeProductRevenueAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeProductSelected) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeProductSelected_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeProductSelected);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeProductSelected);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeProductWIPAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeProductWIPAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeProductWIPAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeProductWIPAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeTimeRevenueAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeTimeRevenueAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeTimeRevenueAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeTimeRevenueAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeTimeSelected) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeTimeSelected_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeTimeSelected);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeTimeSelected);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProjectRevenueRecognitionPreference) => Property (TimeAndMaterialTypeTimeWIPAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ProjectRevenueRecognitionPreference_Public_Class_TimeAndMaterialTypeTimeWIPAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeAndMaterialTypeTimeWIPAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeAndMaterialTypeTimeWIPAccount);

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
        private void AUT_ProjectRevenueRecognitionPreference_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectRevenueRecognitionPreferenceInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ProjectRevenueRecognitionPreference_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_projectRevenueRecognitionPreferenceInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_ProjectRevenueRecognitionPreference_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_projectRevenueRecognitionPreferenceInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_ProjectRevenueRecognitionPreference_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ProjectRevenueRecognitionPreference_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_projectRevenueRecognitionPreferenceInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ProjectRevenueRecognitionPreference_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_projectRevenueRecognitionPreferenceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}