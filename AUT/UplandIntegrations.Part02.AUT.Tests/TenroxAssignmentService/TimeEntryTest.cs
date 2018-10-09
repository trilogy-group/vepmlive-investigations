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
using UplandIntegrations.TenroxAssignmentService;
using TimeEntry = UplandIntegrations.TenroxAssignmentService;

namespace UplandIntegrations.TenroxAssignmentService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxAssignmentService.TimeEntry" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxAssignmentService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TimeEntryTest : AbstractBaseSetupV3Test
    {
        public TimeEntryTest() : base(typeof(TimeEntry))
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

        #region General Initializer : Class (TimeEntry) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAppTimestamp = "AppTimestamp";
        private const string PropertyBilledTimespan1 = "BilledTimespan1";
        private const string PropertyBilledTimespan2 = "BilledTimespan2";
        private const string PropertyBilledTimespan3 = "BilledTimespan3";
        private const string PropertyBusinessUnit = "BusinessUnit";
        private const string PropertyBusinessUnitId = "BusinessUnitId";
        private const string PropertyChargeEntry = "ChargeEntry";
        private const string PropertyChargeentryId = "ChargeentryId";
        private const string PropertyCostedTimespan1 = "CostedTimespan1";
        private const string PropertyCostedTimespan2 = "CostedTimespan2";
        private const string PropertyCostedTimespan3 = "CostedTimespan3";
        private const string PropertyCurrentDate = "CurrentDate";
        private const string PropertyDateStart = "DateStart";
        private const string PropertyDay = "Day";
        private const string PropertyIsApproved = "IsApproved";
        private const string PropertyIsBillable = "IsBillable";
        private const string PropertyIsCapitalized = "IsCapitalized";
        private const string PropertyIsCompleted = "IsCompleted";
        private const string PropertyIsCosted = "IsCosted";
        private const string PropertyIsFunded = "IsFunded";
        private const string PropertyIsProjectScheduling = "IsProjectScheduling";
        private const string PropertyIsRandD = "IsRandD";
        private const string PropertyPhaseId = "PhaseId";
        private const string PropertyProjectSchedulingId = "ProjectSchedulingId";
        private const string PropertySite = "Site";
        private const string PropertySiteId = "SiteId";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTPHASE = "TPHASE";
        private const string PropertyTask = "Task";
        private const string PropertyTaskId = "TaskId";
        private const string PropertyTimespan = "Timespan";
        private const string PropertyTimespan1 = "Timespan1";
        private const string PropertyTimespan2 = "Timespan2";
        private const string PropertyTimespan3 = "Timespan3";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUpdateTimestamp = "UpdateTimestamp";
        private const string PropertyUserId = "UserId";
        private const string PropertyUserPeriodId = "UserPeriodId";
        private const string PropertyWorkflowEntry = "WorkflowEntry";
        private const string PropertyWorkflowEntryId = "WorkflowEntryId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAppTimestampField = "AppTimestampField";
        private const string FieldBilledTimespan1Field = "BilledTimespan1Field";
        private const string FieldBilledTimespan2Field = "BilledTimespan2Field";
        private const string FieldBilledTimespan3Field = "BilledTimespan3Field";
        private const string FieldBusinessUnitField = "BusinessUnitField";
        private const string FieldBusinessUnitIdField = "BusinessUnitIdField";
        private const string FieldChargeEntryField = "ChargeEntryField";
        private const string FieldChargeentryIdField = "ChargeentryIdField";
        private const string FieldCostedTimespan1Field = "CostedTimespan1Field";
        private const string FieldCostedTimespan2Field = "CostedTimespan2Field";
        private const string FieldCostedTimespan3Field = "CostedTimespan3Field";
        private const string FieldCurrentDateField = "CurrentDateField";
        private const string FieldDateStartField = "DateStartField";
        private const string FieldDayField = "DayField";
        private const string FieldIsApprovedField = "IsApprovedField";
        private const string FieldIsBillableField = "IsBillableField";
        private const string FieldIsCapitalizedField = "IsCapitalizedField";
        private const string FieldIsCompletedField = "IsCompletedField";
        private const string FieldIsCostedField = "IsCostedField";
        private const string FieldIsFundedField = "IsFundedField";
        private const string FieldIsProjectSchedulingField = "IsProjectSchedulingField";
        private const string FieldIsRandDField = "IsRandDField";
        private const string FieldPhaseIdField = "PhaseIdField";
        private const string FieldProjectSchedulingIdField = "ProjectSchedulingIdField";
        private const string FieldSiteField = "SiteField";
        private const string FieldSiteIdField = "SiteIdField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTPHASEField = "TPHASEField";
        private const string FieldTaskField = "TaskField";
        private const string FieldTaskIdField = "TaskIdField";
        private const string FieldTimespanField = "TimespanField";
        private const string FieldTimespan1Field = "Timespan1Field";
        private const string FieldTimespan2Field = "Timespan2Field";
        private const string FieldTimespan3Field = "Timespan3Field";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUpdateTimestampField = "UpdateTimestampField";
        private const string FieldUserIdField = "UserIdField";
        private const string FieldUserPeriodIdField = "UserPeriodIdField";
        private const string FieldWorkflowEntryField = "WorkflowEntryField";
        private const string FieldWorkflowEntryIdField = "WorkflowEntryIdField";

        #endregion

        private Type _timeEntryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private TimeEntry _timeEntryInstance;
        private TimeEntry _timeEntryInstanceFixture;

        #region General Initializer : Class (TimeEntry) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TimeEntry" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _timeEntryInstanceType = typeof(TimeEntry);
            _timeEntryInstanceFixture = this.Create<TimeEntry>(true);
            _timeEntryInstance = _timeEntryInstanceFixture ?? this.Create<TimeEntry>(false);
            CurrentInstance = _timeEntryInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TimeEntry)

        #region General Initializer : Class (TimeEntry) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="TimeEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_TimeEntry_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_timeEntryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TimeEntry) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TimeEntry" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAppTimestamp)]
        [TestCase(PropertyBilledTimespan1)]
        [TestCase(PropertyBilledTimespan2)]
        [TestCase(PropertyBilledTimespan3)]
        [TestCase(PropertyBusinessUnit)]
        [TestCase(PropertyBusinessUnitId)]
        [TestCase(PropertyChargeEntry)]
        [TestCase(PropertyChargeentryId)]
        [TestCase(PropertyCostedTimespan1)]
        [TestCase(PropertyCostedTimespan2)]
        [TestCase(PropertyCostedTimespan3)]
        [TestCase(PropertyCurrentDate)]
        [TestCase(PropertyDateStart)]
        [TestCase(PropertyDay)]
        [TestCase(PropertyIsApproved)]
        [TestCase(PropertyIsBillable)]
        [TestCase(PropertyIsCapitalized)]
        [TestCase(PropertyIsCompleted)]
        [TestCase(PropertyIsCosted)]
        [TestCase(PropertyIsFunded)]
        [TestCase(PropertyIsProjectScheduling)]
        [TestCase(PropertyIsRandD)]
        [TestCase(PropertyPhaseId)]
        [TestCase(PropertyProjectSchedulingId)]
        [TestCase(PropertySite)]
        [TestCase(PropertySiteId)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTPHASE)]
        [TestCase(PropertyTask)]
        [TestCase(PropertyTaskId)]
        [TestCase(PropertyTimespan)]
        [TestCase(PropertyTimespan1)]
        [TestCase(PropertyTimespan2)]
        [TestCase(PropertyTimespan3)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUpdateTimestamp)]
        [TestCase(PropertyUserId)]
        [TestCase(PropertyUserPeriodId)]
        [TestCase(PropertyWorkflowEntry)]
        [TestCase(PropertyWorkflowEntryId)]
        public void AUT_TimeEntry_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_timeEntryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TimeEntry) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TimeEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAppTimestampField)]
        [TestCase(FieldBilledTimespan1Field)]
        [TestCase(FieldBilledTimespan2Field)]
        [TestCase(FieldBilledTimespan3Field)]
        [TestCase(FieldBusinessUnitField)]
        [TestCase(FieldBusinessUnitIdField)]
        [TestCase(FieldChargeEntryField)]
        [TestCase(FieldChargeentryIdField)]
        [TestCase(FieldCostedTimespan1Field)]
        [TestCase(FieldCostedTimespan2Field)]
        [TestCase(FieldCostedTimespan3Field)]
        [TestCase(FieldCurrentDateField)]
        [TestCase(FieldDateStartField)]
        [TestCase(FieldDayField)]
        [TestCase(FieldIsApprovedField)]
        [TestCase(FieldIsBillableField)]
        [TestCase(FieldIsCapitalizedField)]
        [TestCase(FieldIsCompletedField)]
        [TestCase(FieldIsCostedField)]
        [TestCase(FieldIsFundedField)]
        [TestCase(FieldIsProjectSchedulingField)]
        [TestCase(FieldIsRandDField)]
        [TestCase(FieldPhaseIdField)]
        [TestCase(FieldProjectSchedulingIdField)]
        [TestCase(FieldSiteField)]
        [TestCase(FieldSiteIdField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTPHASEField)]
        [TestCase(FieldTaskField)]
        [TestCase(FieldTaskIdField)]
        [TestCase(FieldTimespanField)]
        [TestCase(FieldTimespan1Field)]
        [TestCase(FieldTimespan2Field)]
        [TestCase(FieldTimespan3Field)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUpdateTimestampField)]
        [TestCase(FieldUserIdField)]
        [TestCase(FieldUserPeriodIdField)]
        [TestCase(FieldWorkflowEntryField)]
        [TestCase(FieldWorkflowEntryIdField)]
        public void AUT_TimeEntry_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_timeEntryInstanceFixture, 
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
        ///     Class (<see cref="TimeEntry" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_TimeEntry_Is_Instance_Present_Test()
        {
            // Assert
            _timeEntryInstanceType.ShouldNotBeNull();
            _timeEntryInstance.ShouldNotBeNull();
            _timeEntryInstanceFixture.ShouldNotBeNull();
            _timeEntryInstance.ShouldBeAssignableTo<TimeEntry>();
            _timeEntryInstanceFixture.ShouldBeAssignableTo<TimeEntry>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TimeEntry) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_TimeEntry_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            TimeEntry instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _timeEntryInstanceType.ShouldNotBeNull();
            _timeEntryInstance.ShouldNotBeNull();
            _timeEntryInstanceFixture.ShouldNotBeNull();
            _timeEntryInstance.ShouldBeAssignableTo<TimeEntry>();
            _timeEntryInstanceFixture.ShouldBeAssignableTo<TimeEntry>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TimeEntry) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyAppTimestamp)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBilledTimespan1)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBilledTimespan2)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyBilledTimespan3)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.BusinessUnit) , PropertyBusinessUnit)]
        [TestCaseGeneric(typeof(int) , PropertyBusinessUnitId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.ChargeEntry) , PropertyChargeEntry)]
        [TestCaseGeneric(typeof(int) , PropertyChargeentryId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyCostedTimespan1)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyCostedTimespan2)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyCostedTimespan3)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyCurrentDate)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyDateStart)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyDay)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsApproved)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsBillable)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsCapitalized)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsCompleted)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsCosted)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsFunded)]
        [TestCaseGeneric(typeof(short) , PropertyIsProjectScheduling)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsRandD)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPhaseId)]
        [TestCaseGeneric(typeof(int) , PropertyProjectSchedulingId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Site) , PropertySite)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertySiteId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Phase) , PropertyTPHASE)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.Task) , PropertyTask)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyTaskId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTimespan)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTimespan1)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTimespan2)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTimespan3)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<System.DateTime>) , PropertyUpdateTimestamp)]
        [TestCaseGeneric(typeof(int) , PropertyUserId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyUserPeriodId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxAssignmentService.WorkflowEntry) , PropertyWorkflowEntry)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkflowEntryId)]
        public void AUT_TimeEntry_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<TimeEntry, T>(_timeEntryInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (AppTimestamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_AppTimestamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAppTimestamp);
            var propertyInfo  = this.GetPropertyInfo(PropertyAppTimestamp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (BilledTimespan1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_BilledTimespan1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBilledTimespan1);
            var propertyInfo  = this.GetPropertyInfo(PropertyBilledTimespan1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (BilledTimespan2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_BilledTimespan2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBilledTimespan2);
            var propertyInfo  = this.GetPropertyInfo(PropertyBilledTimespan2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (BilledTimespan3) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_BilledTimespan3_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBilledTimespan3);
            var propertyInfo  = this.GetPropertyInfo(PropertyBilledTimespan3);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (BusinessUnit) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_BusinessUnit_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBusinessUnit);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyBusinessUnit);
            Action currentAction = () => propertyInfo.SetValue(_timeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (BusinessUnit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_BusinessUnit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (TimeEntry) => Property (BusinessUnitId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_BusinessUnitId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyBusinessUnitId);
            var propertyInfo  = this.GetPropertyInfo(PropertyBusinessUnitId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (ChargeEntry) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_ChargeEntry_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyChargeEntry);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyChargeEntry);
            Action currentAction = () => propertyInfo.SetValue(_timeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (ChargeEntry) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_ChargeEntry_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyChargeEntry);
            var propertyInfo  = this.GetPropertyInfo(PropertyChargeEntry);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (ChargeentryId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_ChargeentryId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyChargeentryId);
            var propertyInfo  = this.GetPropertyInfo(PropertyChargeentryId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (CostedTimespan1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_CostedTimespan1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCostedTimespan1);
            var propertyInfo  = this.GetPropertyInfo(PropertyCostedTimespan1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (CostedTimespan2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_CostedTimespan2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCostedTimespan2);
            var propertyInfo  = this.GetPropertyInfo(PropertyCostedTimespan2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (CostedTimespan3) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_CostedTimespan3_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCostedTimespan3);
            var propertyInfo  = this.GetPropertyInfo(PropertyCostedTimespan3);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (CurrentDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_CurrentDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrentDate);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrentDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (DateStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_DateStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDateStart);
            var propertyInfo  = this.GetPropertyInfo(PropertyDateStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (Day) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_Day_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDay);
            var propertyInfo  = this.GetPropertyInfo(PropertyDay);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_timeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (TimeEntry) => Property (IsApproved) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_IsApproved_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsApproved);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsApproved);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (IsBillable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_IsBillable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsBillable);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsBillable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (IsCapitalized) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_IsCapitalized_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsCapitalized);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsCapitalized);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (IsCompleted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_IsCompleted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsCompleted);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsCompleted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (IsCosted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_IsCosted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsCosted);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsCosted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (IsFunded) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_IsFunded_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsFunded);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsFunded);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (IsProjectScheduling) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_IsProjectScheduling_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsProjectScheduling);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyIsProjectScheduling);
            Action currentAction = () => propertyInfo.SetValue(_timeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (IsProjectScheduling) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_IsProjectScheduling_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsProjectScheduling);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsProjectScheduling);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (IsRandD) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_IsRandD_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsRandD);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsRandD);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (PhaseId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_PhaseId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPhaseId);
            var propertyInfo  = this.GetPropertyInfo(PropertyPhaseId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (ProjectSchedulingId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_ProjectSchedulingId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectSchedulingId);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectSchedulingId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (Site) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Site_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySite);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySite);
            Action currentAction = () => propertyInfo.SetValue(_timeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (Site) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_Site_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySite);
            var propertyInfo  = this.GetPropertyInfo(PropertySite);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySiteId);
            var propertyInfo  = this.GetPropertyInfo(PropertySiteId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_timeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (TimeEntry) => Property (Task) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Task_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTask);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTask);
            Action currentAction = () => propertyInfo.SetValue(_timeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (Task) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_Task_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTask);
            var propertyInfo  = this.GetPropertyInfo(PropertyTask);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (TaskId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_TaskId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTaskId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTaskId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (Timespan) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_Timespan_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimespan);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimespan);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (Timespan1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_Timespan1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimespan1);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimespan1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (Timespan2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_Timespan2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimespan2);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimespan2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (Timespan3) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_Timespan3_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimespan3);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimespan3);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (TPHASE) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_TPHASE_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPHASE);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTPHASE);
            Action currentAction = () => propertyInfo.SetValue(_timeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (TPHASE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_TPHASE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPHASE);
            var propertyInfo  = this.GetPropertyInfo(PropertyTPHASE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (TimeEntry) => Property (UpdateTimestamp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_UpdateTimestamp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUpdateTimestamp);
            var propertyInfo  = this.GetPropertyInfo(PropertyUpdateTimestamp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserId);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (UserPeriodId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_UserPeriodId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyUserPeriodId);
            var propertyInfo  = this.GetPropertyInfo(PropertyUserPeriodId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (WorkflowEntry) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_WorkflowEntry_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowEntry);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyWorkflowEntry);
            Action currentAction = () => propertyInfo.SetValue(_timeEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (WorkflowEntry) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_WorkflowEntry_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowEntry);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowEntry);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TimeEntry) => Property (WorkflowEntryId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_TimeEntry_Public_Class_WorkflowEntryId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowEntryId);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowEntryId);

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
        private void AUT_TimeEntry_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeEntryInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeEntry_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_timeEntryInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_TimeEntry_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_timeEntryInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_TimeEntry_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_TimeEntry_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_timeEntryInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_TimeEntry_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_timeEntryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}