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
using UplandIntegrations.TenroxProjectService;
using Account = UplandIntegrations.TenroxProjectService;

namespace UplandIntegrations.TenroxProjectService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxProjectService.Account" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxProjectService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AccountTest : AbstractBaseSetupV3Test
    {
        public AccountTest() : base(typeof(Account))
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

        #region General Initializer : Class (Account) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAccessType = "AccessType";
        private const string PropertyAccountType = "AccountType";
        private const string PropertyDescription = "Description";
        private const string PropertyHierarchyCode = "HierarchyCode";
        private const string PropertyId = "Id";
        private const string PropertyIsPlaceholder = "IsPlaceholder";
        private const string PropertyName = "Name";
        private const string PropertyNormalBalance = "NormalBalance";
        private const string PropertyParentId = "ParentId";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTPROJECTs = "TPROJECTs";
        private const string PropertyTPROJECTs1 = "TPROJECTs1";
        private const string PropertyTPROJECTs2 = "TPROJECTs2";
        private const string PropertyUniqueId = "UniqueId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAccessTypeField = "AccessTypeField";
        private const string FieldAccountTypeField = "AccountTypeField";
        private const string FieldDescriptionField = "DescriptionField";
        private const string FieldHierarchyCodeField = "HierarchyCodeField";
        private const string FieldIdField = "IdField";
        private const string FieldIsPlaceholderField = "IsPlaceholderField";
        private const string FieldNameField = "NameField";
        private const string FieldNormalBalanceField = "NormalBalanceField";
        private const string FieldParentIdField = "ParentIdField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTPROJECTsField = "TPROJECTsField";
        private const string FieldTPROJECTs1Field = "TPROJECTs1Field";
        private const string FieldTPROJECTs2Field = "TPROJECTs2Field";
        private const string FieldUniqueIdField = "UniqueIdField";

        #endregion

        private Type _accountInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private Account _accountInstance;
        private Account _accountInstanceFixture;

        #region General Initializer : Class (Account) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Account" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _accountInstanceType = typeof(Account);
            _accountInstanceFixture = this.Create<Account>(true);
            _accountInstance = _accountInstanceFixture ?? this.Create<Account>(false);
            CurrentInstance = _accountInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Account)

        #region General Initializer : Class (Account) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Account" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_Account_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_accountInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Account) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Account" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAccessType)]
        [TestCase(PropertyAccountType)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyHierarchyCode)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIsPlaceholder)]
        [TestCase(PropertyName)]
        [TestCase(PropertyNormalBalance)]
        [TestCase(PropertyParentId)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTPROJECTs)]
        [TestCase(PropertyTPROJECTs1)]
        [TestCase(PropertyTPROJECTs2)]
        [TestCase(PropertyUniqueId)]
        public void AUT_Account_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_accountInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Account) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Account" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAccessTypeField)]
        [TestCase(FieldAccountTypeField)]
        [TestCase(FieldDescriptionField)]
        [TestCase(FieldHierarchyCodeField)]
        [TestCase(FieldIdField)]
        [TestCase(FieldIsPlaceholderField)]
        [TestCase(FieldNameField)]
        [TestCase(FieldNormalBalanceField)]
        [TestCase(FieldParentIdField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTPROJECTsField)]
        [TestCase(FieldTPROJECTs1Field)]
        [TestCase(FieldTPROJECTs2Field)]
        [TestCase(FieldUniqueIdField)]
        public void AUT_Account_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_accountInstanceFixture, 
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
        ///     Class (<see cref="Account" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Account_Is_Instance_Present_Test()
        {
            // Assert
            _accountInstanceType.ShouldNotBeNull();
            _accountInstance.ShouldNotBeNull();
            _accountInstanceFixture.ShouldNotBeNull();
            _accountInstance.ShouldBeAssignableTo<Account>();
            _accountInstanceFixture.ShouldBeAssignableTo<Account>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Account) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Account_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Account instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _accountInstanceType.ShouldNotBeNull();
            _accountInstance.ShouldNotBeNull();
            _accountInstanceFixture.ShouldNotBeNull();
            _accountInstance.ShouldBeAssignableTo<Account>();
            _accountInstanceFixture.ShouldBeAssignableTo<Account>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Account) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyAccessType)]
        [TestCaseGeneric(typeof(string) , PropertyAccountType)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(string) , PropertyHierarchyCode)]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsPlaceholder)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyNormalBalance)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyParentId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.Project[]) , PropertyTPROJECTs)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.Project[]) , PropertyTPROJECTs1)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.Project[]) , PropertyTPROJECTs2)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        public void AUT_Account_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<Account, T>(_accountInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (AccessType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_AccessType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Account) => Property (AccountType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_AccountType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAccountType);
            var propertyInfo  = this.GetPropertyInfo(PropertyAccountType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Account) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_accountInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Account) => Property (HierarchyCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_HierarchyCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Account) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Account) => Property (IsPlaceholder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_IsPlaceholder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Account) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Account) => Property (NormalBalance) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_NormalBalance_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyNormalBalance);
            var propertyInfo  = this.GetPropertyInfo(PropertyNormalBalance);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (ParentId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_ParentId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Account) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_accountInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Account) => Property (TPROJECTs) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_TPROJECTs_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPROJECTs);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTPROJECTs);
            Action currentAction = () => propertyInfo.SetValue(_accountInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (TPROJECTs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_TPROJECTs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPROJECTs);
            var propertyInfo  = this.GetPropertyInfo(PropertyTPROJECTs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (TPROJECTs1) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_TPROJECTs1_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPROJECTs1);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTPROJECTs1);
            Action currentAction = () => propertyInfo.SetValue(_accountInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (TPROJECTs1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_TPROJECTs1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPROJECTs1);
            var propertyInfo  = this.GetPropertyInfo(PropertyTPROJECTs1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (TPROJECTs2) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_TPROJECTs2_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPROJECTs2);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTPROJECTs2);
            Action currentAction = () => propertyInfo.SetValue(_accountInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (TPROJECTs2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_TPROJECTs2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPROJECTs2);
            var propertyInfo  = this.GetPropertyInfo(PropertyTPROJECTs2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Account) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Account_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        private void AUT_Account_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_accountInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Account_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_accountInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_Account_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_accountInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_Account_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Account_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_accountInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Account_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_accountInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}