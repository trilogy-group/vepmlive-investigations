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
using PPMExpectedDuration = UplandIntegrations.TenroxTaskService;

namespace UplandIntegrations.TenroxTaskService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxTaskService.PPMExpectedDuration" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxTaskService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PPMExpectedDurationTest : AbstractBaseSetupV3Test
    {
        public PPMExpectedDurationTest() : base(typeof(PPMExpectedDuration))
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

        #region General Initializer : Class (PPMExpectedDuration) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyDescription = "Description";
        private const string PropertyMaximum = "Maximum";
        private const string PropertyMinimum = "Minimum";
        private const string PropertyProbability = "Probability";
        private const string PropertyProject = "Project";
        private const string PropertyProjectId = "ProjectId";
        private const string PropertyScheduleItem = "ScheduleItem";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyValue = "Value";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldDescriptionField = "DescriptionField";
        private const string FieldMaximumField = "MaximumField";
        private const string FieldMinimumField = "MinimumField";
        private const string FieldProbabilityField = "ProbabilityField";
        private const string FieldProjectField = "ProjectField";
        private const string FieldProjectIdField = "ProjectIdField";
        private const string FieldScheduleItemField = "ScheduleItemField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldValueField = "ValueField";

        #endregion

        private Type _pPMExpectedDurationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private PPMExpectedDuration _pPMExpectedDurationInstance;
        private PPMExpectedDuration _pPMExpectedDurationInstanceFixture;

        #region General Initializer : Class (PPMExpectedDuration) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PPMExpectedDuration" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _pPMExpectedDurationInstanceType = typeof(PPMExpectedDuration);
            _pPMExpectedDurationInstanceFixture = this.Create<PPMExpectedDuration>(true);
            _pPMExpectedDurationInstance = _pPMExpectedDurationInstanceFixture ?? this.Create<PPMExpectedDuration>(false);
            CurrentInstance = _pPMExpectedDurationInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PPMExpectedDuration)

        #region General Initializer : Class (PPMExpectedDuration) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PPMExpectedDuration" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_PPMExpectedDuration_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_pPMExpectedDurationInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PPMExpectedDuration) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PPMExpectedDuration" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyMaximum)]
        [TestCase(PropertyMinimum)]
        [TestCase(PropertyProbability)]
        [TestCase(PropertyProject)]
        [TestCase(PropertyProjectId)]
        [TestCase(PropertyScheduleItem)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyValue)]
        public void AUT_PPMExpectedDuration_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_pPMExpectedDurationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PPMExpectedDuration) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PPMExpectedDuration" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldDescriptionField)]
        [TestCase(FieldMaximumField)]
        [TestCase(FieldMinimumField)]
        [TestCase(FieldProbabilityField)]
        [TestCase(FieldProjectField)]
        [TestCase(FieldProjectIdField)]
        [TestCase(FieldScheduleItemField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldValueField)]
        public void AUT_PPMExpectedDuration_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_pPMExpectedDurationInstanceFixture, 
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
        ///     Class (<see cref="PPMExpectedDuration" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PPMExpectedDuration_Is_Instance_Present_Test()
        {
            // Assert
            _pPMExpectedDurationInstanceType.ShouldNotBeNull();
            _pPMExpectedDurationInstance.ShouldNotBeNull();
            _pPMExpectedDurationInstanceFixture.ShouldNotBeNull();
            _pPMExpectedDurationInstance.ShouldBeAssignableTo<PPMExpectedDuration>();
            _pPMExpectedDurationInstanceFixture.ShouldBeAssignableTo<PPMExpectedDuration>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PPMExpectedDuration) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PPMExpectedDuration_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PPMExpectedDuration instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _pPMExpectedDurationInstanceType.ShouldNotBeNull();
            _pPMExpectedDurationInstance.ShouldNotBeNull();
            _pPMExpectedDurationInstanceFixture.ShouldNotBeNull();
            _pPMExpectedDurationInstance.ShouldBeAssignableTo<PPMExpectedDuration>();
            _pPMExpectedDurationInstanceFixture.ShouldBeAssignableTo<PPMExpectedDuration>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PPMExpectedDuration) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(decimal) , PropertyMaximum)]
        [TestCaseGeneric(typeof(decimal) , PropertyMinimum)]
        [TestCaseGeneric(typeof(int) , PropertyProbability)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.Project) , PropertyProject)]
        [TestCaseGeneric(typeof(int) , PropertyProjectId)]
        [TestCaseGeneric(typeof(string) , PropertyScheduleItem)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxTaskService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(decimal) , PropertyValue)]
        public void AUT_PPMExpectedDuration_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<PPMExpectedDuration, T>(_pPMExpectedDurationInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_pPMExpectedDurationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (Maximum) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_Maximum_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMaximum);
            var propertyInfo  = this.GetPropertyInfo(PropertyMaximum);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (Minimum) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_Minimum_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMinimum);
            var propertyInfo  = this.GetPropertyInfo(PropertyMinimum);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (Probability) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_Probability_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProbability);
            var propertyInfo  = this.GetPropertyInfo(PropertyProbability);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (Project) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Project_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProject);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProject);
            Action currentAction = () => propertyInfo.SetValue(_pPMExpectedDurationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (Project) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_Project_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (ProjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_ProjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (ScheduleItem) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_ScheduleItem_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyScheduleItem);
            var propertyInfo  = this.GetPropertyInfo(PropertyScheduleItem);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_pPMExpectedDurationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PPMExpectedDuration) => Property (Value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PPMExpectedDuration_Public_Class_Value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyValue);
            var propertyInfo  = this.GetPropertyInfo(PropertyValue);

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
        private void AUT_PPMExpectedDuration_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pPMExpectedDurationInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PPMExpectedDuration_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_pPMExpectedDurationInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_PPMExpectedDuration_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_pPMExpectedDurationInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_PPMExpectedDuration_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_PPMExpectedDuration_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pPMExpectedDurationInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_PPMExpectedDuration_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_pPMExpectedDurationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}