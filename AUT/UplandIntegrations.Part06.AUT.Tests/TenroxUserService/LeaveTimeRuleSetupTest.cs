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
using LeaveTimeRuleSetup = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.LeaveTimeRuleSetup" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LeaveTimeRuleSetupTest : AbstractBaseSetupV3Test
    {
        public LeaveTimeRuleSetupTest() : base(typeof(LeaveTimeRuleSetup))
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

        #region General Initializer : Class (LeaveTimeRuleSetup) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyApplyOverTiemForAllAssocUser = "ApplyOverTiemForAllAssocUser";
        private const string PropertyBlockValue = "BlockValue";
        private const string PropertyBorrowingMaxValue = "BorrowingMaxValue";
        private const string PropertyDayMaxValue = "DayMaxValue";
        private const string PropertyEnforceBlocks = "EnforceBlocks";
        private const string PropertyEnforceMaxValue = "EnforceMaxValue";
        private const string PropertyIncludeInOverTime = "IncludeInOverTime";
        private const string PropertyLeaveTimeRule = "LeaveTimeRule";
        private const string PropertyLimitBorrowing = "LimitBorrowing";
        private const string PropertyLimitDay = "LimitDay";
        private const string PropertyLimitPeriod = "LimitPeriod";
        private const string PropertyMaxValue = "MaxValue";
        private const string PropertyObjectId = "ObjectId";
        private const string PropertyObjectType = "ObjectType";
        private const string PropertyOverride = "Override";
        private const string PropertyPeriodMaxValue = "PeriodMaxValue";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyWorkType = "WorkType";
        private const string PropertyWorktypeId = "WorktypeId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldApplyOverTiemForAllAssocUserField = "ApplyOverTiemForAllAssocUserField";
        private const string FieldBlockValueField = "BlockValueField";
        private const string FieldBorrowingMaxValueField = "BorrowingMaxValueField";
        private const string FieldDayMaxValueField = "DayMaxValueField";
        private const string FieldEnforceBlocksField = "EnforceBlocksField";
        private const string FieldEnforceMaxValueField = "EnforceMaxValueField";
        private const string FieldIncludeInOverTimeField = "IncludeInOverTimeField";
        private const string FieldLeaveTimeRuleField = "LeaveTimeRuleField";
        private const string FieldLimitBorrowingField = "LimitBorrowingField";
        private const string FieldLimitDayField = "LimitDayField";
        private const string FieldLimitPeriodField = "LimitPeriodField";
        private const string FieldMaxValueField = "MaxValueField";
        private const string FieldObjectIdField = "ObjectIdField";
        private const string FieldObjectTypeField = "ObjectTypeField";
        private const string FieldOverrideField = "OverrideField";
        private const string FieldPeriodMaxValueField = "PeriodMaxValueField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldWorkTypeField = "WorkTypeField";
        private const string FieldWorktypeIdField = "WorktypeIdField";

        #endregion

        private Type _leaveTimeRuleSetupInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private LeaveTimeRuleSetup _leaveTimeRuleSetupInstance;
        private LeaveTimeRuleSetup _leaveTimeRuleSetupInstanceFixture;

        #region General Initializer : Class (LeaveTimeRuleSetup) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LeaveTimeRuleSetup" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _leaveTimeRuleSetupInstanceType = typeof(LeaveTimeRuleSetup);
            _leaveTimeRuleSetupInstanceFixture = this.Create<LeaveTimeRuleSetup>(true);
            _leaveTimeRuleSetupInstance = _leaveTimeRuleSetupInstanceFixture ?? this.Create<LeaveTimeRuleSetup>(false);
            CurrentInstance = _leaveTimeRuleSetupInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LeaveTimeRuleSetup)

        #region General Initializer : Class (LeaveTimeRuleSetup) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="LeaveTimeRuleSetup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_LeaveTimeRuleSetup_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_leaveTimeRuleSetupInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LeaveTimeRuleSetup) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LeaveTimeRuleSetup" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyApplyOverTiemForAllAssocUser)]
        [TestCase(PropertyBlockValue)]
        [TestCase(PropertyBorrowingMaxValue)]
        [TestCase(PropertyDayMaxValue)]
        [TestCase(PropertyEnforceBlocks)]
        [TestCase(PropertyEnforceMaxValue)]
        [TestCase(PropertyIncludeInOverTime)]
        [TestCase(PropertyLeaveTimeRule)]
        [TestCase(PropertyLimitBorrowing)]
        [TestCase(PropertyLimitDay)]
        [TestCase(PropertyLimitPeriod)]
        [TestCase(PropertyMaxValue)]
        [TestCase(PropertyObjectId)]
        [TestCase(PropertyObjectType)]
        [TestCase(PropertyOverride)]
        [TestCase(PropertyPeriodMaxValue)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyWorkType)]
        [TestCase(PropertyWorktypeId)]
        public void AUT_LeaveTimeRuleSetup_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_leaveTimeRuleSetupInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LeaveTimeRuleSetup) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LeaveTimeRuleSetup" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldApplyOverTiemForAllAssocUserField)]
        [TestCase(FieldBlockValueField)]
        [TestCase(FieldBorrowingMaxValueField)]
        [TestCase(FieldDayMaxValueField)]
        [TestCase(FieldEnforceBlocksField)]
        [TestCase(FieldEnforceMaxValueField)]
        [TestCase(FieldIncludeInOverTimeField)]
        [TestCase(FieldLeaveTimeRuleField)]
        [TestCase(FieldLimitBorrowingField)]
        [TestCase(FieldLimitDayField)]
        [TestCase(FieldLimitPeriodField)]
        [TestCase(FieldMaxValueField)]
        [TestCase(FieldObjectIdField)]
        [TestCase(FieldObjectTypeField)]
        [TestCase(FieldOverrideField)]
        [TestCase(FieldPeriodMaxValueField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldWorkTypeField)]
        [TestCase(FieldWorktypeIdField)]
        public void AUT_LeaveTimeRuleSetup_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_leaveTimeRuleSetupInstanceFixture, 
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
        ///     Class (<see cref="LeaveTimeRuleSetup" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_LeaveTimeRuleSetup_Is_Instance_Present_Test()
        {
            // Assert
            _leaveTimeRuleSetupInstanceType.ShouldNotBeNull();
            _leaveTimeRuleSetupInstance.ShouldNotBeNull();
            _leaveTimeRuleSetupInstanceFixture.ShouldNotBeNull();
            _leaveTimeRuleSetupInstance.ShouldBeAssignableTo<LeaveTimeRuleSetup>();
            _leaveTimeRuleSetupInstanceFixture.ShouldBeAssignableTo<LeaveTimeRuleSetup>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LeaveTimeRuleSetup) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_LeaveTimeRuleSetup_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LeaveTimeRuleSetup instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _leaveTimeRuleSetupInstanceType.ShouldNotBeNull();
            _leaveTimeRuleSetupInstance.ShouldNotBeNull();
            _leaveTimeRuleSetupInstanceFixture.ShouldNotBeNull();
            _leaveTimeRuleSetupInstance.ShouldBeAssignableTo<LeaveTimeRuleSetup>();
            _leaveTimeRuleSetupInstanceFixture.ShouldBeAssignableTo<LeaveTimeRuleSetup>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(short) , PropertyApplyOverTiemForAllAssocUser)]
        [TestCaseGeneric(typeof(decimal) , PropertyBlockValue)]
        [TestCaseGeneric(typeof(decimal) , PropertyBorrowingMaxValue)]
        [TestCaseGeneric(typeof(decimal) , PropertyDayMaxValue)]
        [TestCaseGeneric(typeof(short) , PropertyEnforceBlocks)]
        [TestCaseGeneric(typeof(short) , PropertyEnforceMaxValue)]
        [TestCaseGeneric(typeof(short) , PropertyIncludeInOverTime)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.LeaveTimeRule[]) , PropertyLeaveTimeRule)]
        [TestCaseGeneric(typeof(short) , PropertyLimitBorrowing)]
        [TestCaseGeneric(typeof(short) , PropertyLimitDay)]
        [TestCaseGeneric(typeof(short) , PropertyLimitPeriod)]
        [TestCaseGeneric(typeof(decimal) , PropertyMaxValue)]
        [TestCaseGeneric(typeof(int) , PropertyObjectId)]
        [TestCaseGeneric(typeof(int) , PropertyObjectType)]
        [TestCaseGeneric(typeof(short) , PropertyOverride)]
        [TestCaseGeneric(typeof(decimal) , PropertyPeriodMaxValue)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.BaseWorkType) , PropertyWorkType)]
        [TestCaseGeneric(typeof(int) , PropertyWorktypeId)]
        public void AUT_LeaveTimeRuleSetup_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<LeaveTimeRuleSetup, T>(_leaveTimeRuleSetupInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (ApplyOverTiemForAllAssocUser) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_ApplyOverTiemForAllAssocUser_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyApplyOverTiemForAllAssocUser);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyApplyOverTiemForAllAssocUser);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (ApplyOverTiemForAllAssocUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_ApplyOverTiemForAllAssocUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyApplyOverTiemForAllAssocUser);
            var propertyInfo  = this.GetPropertyInfo(PropertyApplyOverTiemForAllAssocUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (BlockValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_BlockValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBlockValue);
            var propertyInfo  = this.GetPropertyInfo(PropertyBlockValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (BorrowingMaxValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_BorrowingMaxValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBorrowingMaxValue);
            var propertyInfo  = this.GetPropertyInfo(PropertyBorrowingMaxValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (DayMaxValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_DayMaxValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDayMaxValue);
            var propertyInfo  = this.GetPropertyInfo(PropertyDayMaxValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (EnforceBlocks) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_EnforceBlocks_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEnforceBlocks);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyEnforceBlocks);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (EnforceBlocks) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_EnforceBlocks_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEnforceBlocks);
            var propertyInfo  = this.GetPropertyInfo(PropertyEnforceBlocks);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (EnforceMaxValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_EnforceMaxValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEnforceMaxValue);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyEnforceMaxValue);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (EnforceMaxValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_EnforceMaxValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEnforceMaxValue);
            var propertyInfo  = this.GetPropertyInfo(PropertyEnforceMaxValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (IncludeInOverTime) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_IncludeInOverTime_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeInOverTime);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyIncludeInOverTime);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (IncludeInOverTime) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_IncludeInOverTime_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIncludeInOverTime);
            var propertyInfo  = this.GetPropertyInfo(PropertyIncludeInOverTime);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (LeaveTimeRule) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_LeaveTimeRule_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLeaveTimeRule);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyLeaveTimeRule);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (LeaveTimeRule) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_LeaveTimeRule_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLeaveTimeRule);
            var propertyInfo  = this.GetPropertyInfo(PropertyLeaveTimeRule);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (LimitBorrowing) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_LimitBorrowing_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLimitBorrowing);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyLimitBorrowing);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (LimitBorrowing) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_LimitBorrowing_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLimitBorrowing);
            var propertyInfo  = this.GetPropertyInfo(PropertyLimitBorrowing);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (LimitDay) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_LimitDay_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLimitDay);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyLimitDay);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (LimitDay) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_LimitDay_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLimitDay);
            var propertyInfo  = this.GetPropertyInfo(PropertyLimitDay);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (LimitPeriod) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_LimitPeriod_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLimitPeriod);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyLimitPeriod);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (LimitPeriod) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_LimitPeriod_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyLimitPeriod);
            var propertyInfo  = this.GetPropertyInfo(PropertyLimitPeriod);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (MaxValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_MaxValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyMaxValue);
            var propertyInfo  = this.GetPropertyInfo(PropertyMaxValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (ObjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_ObjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyObjectId);
            var propertyInfo  = this.GetPropertyInfo(PropertyObjectId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (ObjectType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_ObjectType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyObjectType);
            var propertyInfo  = this.GetPropertyInfo(PropertyObjectType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (Override) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Override_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverride);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyOverride);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (Override) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_Override_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOverride);
            var propertyInfo  = this.GetPropertyInfo(PropertyOverride);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (PeriodMaxValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_PeriodMaxValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPeriodMaxValue);
            var propertyInfo  = this.GetPropertyInfo(PropertyPeriodMaxValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (WorkType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_WorkType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkType);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyWorkType);
            Action currentAction = () => propertyInfo.SetValue(_leaveTimeRuleSetupInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (WorkType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_WorkType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkType);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeaveTimeRuleSetup) => Property (WorktypeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_LeaveTimeRuleSetup_Public_Class_WorktypeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorktypeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorktypeId);

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
        private void AUT_LeaveTimeRuleSetup_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_leaveTimeRuleSetupInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LeaveTimeRuleSetup_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_leaveTimeRuleSetupInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_LeaveTimeRuleSetup_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_leaveTimeRuleSetupInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_LeaveTimeRuleSetup_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_LeaveTimeRuleSetup_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_leaveTimeRuleSetupInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_LeaveTimeRuleSetup_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_leaveTimeRuleSetupInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}