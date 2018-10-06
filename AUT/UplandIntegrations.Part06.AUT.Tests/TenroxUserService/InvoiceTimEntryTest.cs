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
using InvoiceTimEntry = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.InvoiceTimEntry" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class InvoiceTimEntryTest : AbstractBaseSetupV3Test
    {
        public InvoiceTimEntryTest() : base(typeof(InvoiceTimEntry))
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

        #region General Initializer : Class (InvoiceTimEntry) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyInclude = "Include";
        private const string PropertyInvAmount1 = "InvAmount1";
        private const string PropertyInvAmount2 = "InvAmount2";
        private const string PropertyInvAmount3 = "InvAmount3";
        private const string PropertyInvoiceTimeAdjs = "InvoiceTimeAdjs";
        private const string PropertyInvoiceTimeId = "InvoiceTimeId";
        private const string PropertyOrigAmount1 = "OrigAmount1";
        private const string PropertyOrigAmount2 = "OrigAmount2";
        private const string PropertyOrigAmount3 = "OrigAmount3";
        private const string PropertyOrigAmountCurrId = "OrigAmountCurrId";
        private const string PropertyRateToInvCurr = "RateToInvCurr";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTimeEntryRateId = "TimeEntryRateId";
        private const string PropertyTimespan1 = "Timespan1";
        private const string PropertyTimespan2 = "Timespan2";
        private const string PropertyTimespan3 = "Timespan3";
        private const string PropertyUniqueId = "UniqueId";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldIncludeField = "IncludeField";
        private const string FieldInvAmount1Field = "InvAmount1Field";
        private const string FieldInvAmount2Field = "InvAmount2Field";
        private const string FieldInvAmount3Field = "InvAmount3Field";
        private const string FieldInvoiceTimeAdjsField = "InvoiceTimeAdjsField";
        private const string FieldInvoiceTimeIdField = "InvoiceTimeIdField";
        private const string FieldOrigAmount1Field = "OrigAmount1Field";
        private const string FieldOrigAmount2Field = "OrigAmount2Field";
        private const string FieldOrigAmount3Field = "OrigAmount3Field";
        private const string FieldOrigAmountCurrIdField = "OrigAmountCurrIdField";
        private const string FieldRateToInvCurrField = "RateToInvCurrField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTimeEntryRateIdField = "TimeEntryRateIdField";
        private const string FieldTimespan1Field = "Timespan1Field";
        private const string FieldTimespan2Field = "Timespan2Field";
        private const string FieldTimespan3Field = "Timespan3Field";
        private const string FieldUniqueIdField = "UniqueIdField";

        #endregion

        private Type _invoiceTimEntryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private InvoiceTimEntry _invoiceTimEntryInstance;
        private InvoiceTimEntry _invoiceTimEntryInstanceFixture;

        #region General Initializer : Class (InvoiceTimEntry) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="InvoiceTimEntry" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _invoiceTimEntryInstanceType = typeof(InvoiceTimEntry);
            _invoiceTimEntryInstanceFixture = this.Create<InvoiceTimEntry>(true);
            _invoiceTimEntryInstance = _invoiceTimEntryInstanceFixture ?? this.Create<InvoiceTimEntry>(false);
            CurrentInstance = _invoiceTimEntryInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (InvoiceTimEntry)

        #region General Initializer : Class (InvoiceTimEntry) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="InvoiceTimEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_InvoiceTimEntry_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_invoiceTimEntryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (InvoiceTimEntry) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="InvoiceTimEntry" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyInclude)]
        [TestCase(PropertyInvAmount1)]
        [TestCase(PropertyInvAmount2)]
        [TestCase(PropertyInvAmount3)]
        [TestCase(PropertyInvoiceTimeAdjs)]
        [TestCase(PropertyInvoiceTimeId)]
        [TestCase(PropertyOrigAmount1)]
        [TestCase(PropertyOrigAmount2)]
        [TestCase(PropertyOrigAmount3)]
        [TestCase(PropertyOrigAmountCurrId)]
        [TestCase(PropertyRateToInvCurr)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTimeEntryRateId)]
        [TestCase(PropertyTimespan1)]
        [TestCase(PropertyTimespan2)]
        [TestCase(PropertyTimespan3)]
        [TestCase(PropertyUniqueId)]
        public void AUT_InvoiceTimEntry_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_invoiceTimEntryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (InvoiceTimEntry) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="InvoiceTimEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldIncludeField)]
        [TestCase(FieldInvAmount1Field)]
        [TestCase(FieldInvAmount2Field)]
        [TestCase(FieldInvAmount3Field)]
        [TestCase(FieldInvoiceTimeAdjsField)]
        [TestCase(FieldInvoiceTimeIdField)]
        [TestCase(FieldOrigAmount1Field)]
        [TestCase(FieldOrigAmount2Field)]
        [TestCase(FieldOrigAmount3Field)]
        [TestCase(FieldOrigAmountCurrIdField)]
        [TestCase(FieldRateToInvCurrField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTimeEntryRateIdField)]
        [TestCase(FieldTimespan1Field)]
        [TestCase(FieldTimespan2Field)]
        [TestCase(FieldTimespan3Field)]
        [TestCase(FieldUniqueIdField)]
        public void AUT_InvoiceTimEntry_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_invoiceTimEntryInstanceFixture, 
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
        ///     Class (<see cref="InvoiceTimEntry" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_InvoiceTimEntry_Is_Instance_Present_Test()
        {
            // Assert
            _invoiceTimEntryInstanceType.ShouldNotBeNull();
            _invoiceTimEntryInstance.ShouldNotBeNull();
            _invoiceTimEntryInstanceFixture.ShouldNotBeNull();
            _invoiceTimEntryInstance.ShouldBeAssignableTo<InvoiceTimEntry>();
            _invoiceTimEntryInstanceFixture.ShouldBeAssignableTo<InvoiceTimEntry>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (InvoiceTimEntry) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_InvoiceTimEntry_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            InvoiceTimEntry instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _invoiceTimEntryInstanceType.ShouldNotBeNull();
            _invoiceTimEntryInstance.ShouldNotBeNull();
            _invoiceTimEntryInstanceFixture.ShouldNotBeNull();
            _invoiceTimEntryInstance.ShouldBeAssignableTo<InvoiceTimEntry>();
            _invoiceTimEntryInstanceFixture.ShouldBeAssignableTo<InvoiceTimEntry>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (InvoiceTimEntry) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyInclude)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyInvAmount1)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyInvAmount2)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyInvAmount3)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.InvoiceTimeAdj[]) , PropertyInvoiceTimeAdjs)]
        [TestCaseGeneric(typeof(int) , PropertyInvoiceTimeId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyOrigAmount1)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyOrigAmount2)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyOrigAmount3)]
        [TestCaseGeneric(typeof(int) , PropertyOrigAmountCurrId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyRateToInvCurr)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(int) , PropertyTimeEntryRateId)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTimespan1)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTimespan2)]
        [TestCaseGeneric(typeof(System.Nullable<decimal>) , PropertyTimespan3)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        public void AUT_InvoiceTimEntry_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<InvoiceTimEntry, T>(_invoiceTimEntryInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_invoiceTimEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (Include) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_Include_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInclude);
            var propertyInfo  = this.GetPropertyInfo(PropertyInclude);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (InvAmount1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_InvAmount1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvAmount1);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvAmount1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (InvAmount2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_InvAmount2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvAmount2);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvAmount2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (InvAmount3) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_InvAmount3_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvAmount3);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvAmount3);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (InvoiceTimeAdjs) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_InvoiceTimeAdjs_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceTimeAdjs);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyInvoiceTimeAdjs);
            Action currentAction = () => propertyInfo.SetValue(_invoiceTimEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (InvoiceTimeAdjs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_InvoiceTimeAdjs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceTimeAdjs);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceTimeAdjs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (InvoiceTimeId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_InvoiceTimeId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyInvoiceTimeId);
            var propertyInfo  = this.GetPropertyInfo(PropertyInvoiceTimeId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (OrigAmount1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_OrigAmount1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOrigAmount1);
            var propertyInfo  = this.GetPropertyInfo(PropertyOrigAmount1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (OrigAmount2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_OrigAmount2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOrigAmount2);
            var propertyInfo  = this.GetPropertyInfo(PropertyOrigAmount2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (OrigAmount3) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_OrigAmount3_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOrigAmount3);
            var propertyInfo  = this.GetPropertyInfo(PropertyOrigAmount3);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (OrigAmountCurrId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_OrigAmountCurrId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOrigAmountCurrId);
            var propertyInfo  = this.GetPropertyInfo(PropertyOrigAmountCurrId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (RateToInvCurr) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_RateToInvCurr_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRateToInvCurr);
            var propertyInfo  = this.GetPropertyInfo(PropertyRateToInvCurr);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_invoiceTimEntryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (TimeEntryRateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_TimeEntryRateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTimeEntryRateId);
            var propertyInfo  = this.GetPropertyInfo(PropertyTimeEntryRateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (Timespan1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_Timespan1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (Timespan2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_Timespan2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (Timespan3) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_Timespan3_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (InvoiceTimEntry) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_InvoiceTimEntry_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        private void AUT_InvoiceTimEntry_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_invoiceTimEntryInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InvoiceTimEntry_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_invoiceTimEntryInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_InvoiceTimEntry_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_invoiceTimEntryInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_InvoiceTimEntry_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_InvoiceTimEntry_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_invoiceTimEntryInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InvoiceTimEntry_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_invoiceTimEntryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}