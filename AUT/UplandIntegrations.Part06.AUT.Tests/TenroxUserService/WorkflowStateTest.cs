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
using WorkflowState = UplandIntegrations.TenroxUserService;

namespace UplandIntegrations.TenroxUserService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxUserService.WorkflowState" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxUserService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowStateTest : AbstractBaseSetupV3Test
    {
        public WorkflowStateTest() : base(typeof(WorkflowState))
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

        #region General Initializer : Class (WorkflowState) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyAPPLYCOLOR = "APPLYCOLOR";
        private const string PropertyCOLORCODE = "COLORCODE";
        private const string PropertyCREATEEXPCHARGES = "CREATEEXPCHARGES";
        private const string PropertyCREATEPAYSCHEDULE = "CREATEPAYSCHEDULE";
        private const string PropertyCREATEPREBILLENTRY = "CREATEPREBILLENTRY";
        private const string PropertyCREATEPURORDERS = "CREATEPURORDERS";
        private const string PropertyCWPATTRIBUTES = "CWPATTRIBUTES";
        private const string PropertyCanAttachReceipts = "CanAttachReceipts";
        private const string PropertyDescription = "Description";
        private const string PropertyEXPORTINVOICEACC = "EXPORTINVOICEACC";
        private const string PropertyGENINVOICENO = "GENINVOICENO";
        private const string PropertyISAPPROVEDBYPM = "ISAPPROVEDBYPM";
        private const string PropertyISCOMPLETION = "ISCOMPLETION";
        private const string PropertyISREIMBURSE = "ISREIMBURSE";
        private const string PropertyISREJECTION = "ISREJECTION";
        private const string PropertyISSUEINVOICE = "ISSUEINVOICE";
        private const string PropertyId = "Id";
        private const string PropertyIsApproval = "IsApproval";
        private const string PropertyIsAssignment = "IsAssignment";
        private const string PropertyIsFinal = "IsFinal";
        private const string PropertyIsInitial = "IsInitial";
        private const string PropertyIsReadOnly = "IsReadOnly";
        private const string PropertyIsRequisition = "IsRequisition";
        private const string PropertyName = "Name";
        private const string PropertyPOSTPROCESSACTION = "POSTPROCESSACTION";
        private const string PropertyPREPROCESSACTION = "PREPROCESSACTION";
        private const string PropertyProjectWorkflowStateFlag = "ProjectWorkflowStateFlag";
        private const string PropertyRECOGNIZEINVOICE = "RECOGNIZEINVOICE";
        private const string PropertyRECOMPBILL = "RECOMPBILL";
        private const string PropertyRECOMPCOST = "RECOMPCOST";
        private const string PropertySYNCMSPROJECT = "SYNCMSPROJECT";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTAKEOWNERSHIP = "TAKEOWNERSHIP";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyVERIFYOVRTIME = "VERIFYOVRTIME";
        private const string PropertyVERIFYT_A = "VERIFYT_A";
        private const string PropertyVERIFYWORK = "VERIFYWORK";
        private const string PropertyWorkflowMap = "WorkflowMap";
        private const string PropertyWorkflowMapId = "WorkflowMapId";
        private const string PropertyWorkflowTransition = "WorkflowTransition";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldAPPLYCOLORField = "APPLYCOLORField";
        private const string FieldCOLORCODEField = "COLORCODEField";
        private const string FieldCREATEEXPCHARGESField = "CREATEEXPCHARGESField";
        private const string FieldCREATEPAYSCHEDULEField = "CREATEPAYSCHEDULEField";
        private const string FieldCREATEPREBILLENTRYField = "CREATEPREBILLENTRYField";
        private const string FieldCREATEPURORDERSField = "CREATEPURORDERSField";
        private const string FieldCWPATTRIBUTESField = "CWPATTRIBUTESField";
        private const string FieldCanAttachReceiptsField = "CanAttachReceiptsField";
        private const string FieldDescriptionField = "DescriptionField";
        private const string FieldEXPORTINVOICEACCField = "EXPORTINVOICEACCField";
        private const string FieldGENINVOICENOField = "GENINVOICENOField";
        private const string FieldISAPPROVEDBYPMField = "ISAPPROVEDBYPMField";
        private const string FieldISCOMPLETIONField = "ISCOMPLETIONField";
        private const string FieldISREIMBURSEField = "ISREIMBURSEField";
        private const string FieldISREJECTIONField = "ISREJECTIONField";
        private const string FieldISSUEINVOICEField = "ISSUEINVOICEField";
        private const string FieldIdField = "IdField";
        private const string FieldIsApprovalField = "IsApprovalField";
        private const string FieldIsAssignmentField = "IsAssignmentField";
        private const string FieldIsFinalField = "IsFinalField";
        private const string FieldIsInitialField = "IsInitialField";
        private const string FieldIsReadOnlyField = "IsReadOnlyField";
        private const string FieldIsRequisitionField = "IsRequisitionField";
        private const string FieldNameField = "NameField";
        private const string FieldPOSTPROCESSACTIONField = "POSTPROCESSACTIONField";
        private const string FieldPREPROCESSACTIONField = "PREPROCESSACTIONField";
        private const string FieldProjectWorkflowStateFlagField = "ProjectWorkflowStateFlagField";
        private const string FieldRECOGNIZEINVOICEField = "RECOGNIZEINVOICEField";
        private const string FieldRECOMPBILLField = "RECOMPBILLField";
        private const string FieldRECOMPCOSTField = "RECOMPCOSTField";
        private const string FieldSYNCMSPROJECTField = "SYNCMSPROJECTField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTAKEOWNERSHIPField = "TAKEOWNERSHIPField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldVERIFYOVRTIMEField = "VERIFYOVRTIMEField";
        private const string FieldVERIFYT_AField = "VERIFYT_AField";
        private const string FieldVERIFYWORKField = "VERIFYWORKField";
        private const string FieldWorkflowMapField = "WorkflowMapField";
        private const string FieldWorkflowMapIdField = "WorkflowMapIdField";
        private const string FieldWorkflowTransitionField = "WorkflowTransitionField";

        #endregion

        private Type _workflowStateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private WorkflowState _workflowStateInstance;
        private WorkflowState _workflowStateInstanceFixture;

        #region General Initializer : Class (WorkflowState) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowState" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowStateInstanceType = typeof(WorkflowState);
            _workflowStateInstanceFixture = this.Create<WorkflowState>(true);
            _workflowStateInstance = _workflowStateInstanceFixture ?? this.Create<WorkflowState>(false);
            CurrentInstance = _workflowStateInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowState)

        #region General Initializer : Class (WorkflowState) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkflowState" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_WorkflowState_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workflowStateInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowState) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowState" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyAPPLYCOLOR)]
        [TestCase(PropertyCOLORCODE)]
        [TestCase(PropertyCREATEEXPCHARGES)]
        [TestCase(PropertyCREATEPAYSCHEDULE)]
        [TestCase(PropertyCREATEPREBILLENTRY)]
        [TestCase(PropertyCREATEPURORDERS)]
        [TestCase(PropertyCWPATTRIBUTES)]
        [TestCase(PropertyCanAttachReceipts)]
        [TestCase(PropertyDescription)]
        [TestCase(PropertyEXPORTINVOICEACC)]
        [TestCase(PropertyGENINVOICENO)]
        [TestCase(PropertyISAPPROVEDBYPM)]
        [TestCase(PropertyISCOMPLETION)]
        [TestCase(PropertyISREIMBURSE)]
        [TestCase(PropertyISREJECTION)]
        [TestCase(PropertyISSUEINVOICE)]
        [TestCase(PropertyId)]
        [TestCase(PropertyIsApproval)]
        [TestCase(PropertyIsAssignment)]
        [TestCase(PropertyIsFinal)]
        [TestCase(PropertyIsInitial)]
        [TestCase(PropertyIsReadOnly)]
        [TestCase(PropertyIsRequisition)]
        [TestCase(PropertyName)]
        [TestCase(PropertyPOSTPROCESSACTION)]
        [TestCase(PropertyPREPROCESSACTION)]
        [TestCase(PropertyProjectWorkflowStateFlag)]
        [TestCase(PropertyRECOGNIZEINVOICE)]
        [TestCase(PropertyRECOMPBILL)]
        [TestCase(PropertyRECOMPCOST)]
        [TestCase(PropertySYNCMSPROJECT)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTAKEOWNERSHIP)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyVERIFYOVRTIME)]
        [TestCase(PropertyVERIFYT_A)]
        [TestCase(PropertyVERIFYWORK)]
        [TestCase(PropertyWorkflowMap)]
        [TestCase(PropertyWorkflowMapId)]
        [TestCase(PropertyWorkflowTransition)]
        public void AUT_WorkflowState_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowStateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowState) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowState" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldAPPLYCOLORField)]
        [TestCase(FieldCOLORCODEField)]
        [TestCase(FieldCREATEEXPCHARGESField)]
        [TestCase(FieldCREATEPAYSCHEDULEField)]
        [TestCase(FieldCREATEPREBILLENTRYField)]
        [TestCase(FieldCREATEPURORDERSField)]
        [TestCase(FieldCWPATTRIBUTESField)]
        [TestCase(FieldCanAttachReceiptsField)]
        [TestCase(FieldDescriptionField)]
        [TestCase(FieldEXPORTINVOICEACCField)]
        [TestCase(FieldGENINVOICENOField)]
        [TestCase(FieldISAPPROVEDBYPMField)]
        [TestCase(FieldISCOMPLETIONField)]
        [TestCase(FieldISREIMBURSEField)]
        [TestCase(FieldISREJECTIONField)]
        [TestCase(FieldISSUEINVOICEField)]
        [TestCase(FieldIdField)]
        [TestCase(FieldIsApprovalField)]
        [TestCase(FieldIsAssignmentField)]
        [TestCase(FieldIsFinalField)]
        [TestCase(FieldIsInitialField)]
        [TestCase(FieldIsReadOnlyField)]
        [TestCase(FieldIsRequisitionField)]
        [TestCase(FieldNameField)]
        [TestCase(FieldPOSTPROCESSACTIONField)]
        [TestCase(FieldPREPROCESSACTIONField)]
        [TestCase(FieldProjectWorkflowStateFlagField)]
        [TestCase(FieldRECOGNIZEINVOICEField)]
        [TestCase(FieldRECOMPBILLField)]
        [TestCase(FieldRECOMPCOSTField)]
        [TestCase(FieldSYNCMSPROJECTField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTAKEOWNERSHIPField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldVERIFYOVRTIMEField)]
        [TestCase(FieldVERIFYT_AField)]
        [TestCase(FieldVERIFYWORKField)]
        [TestCase(FieldWorkflowMapField)]
        [TestCase(FieldWorkflowMapIdField)]
        [TestCase(FieldWorkflowTransitionField)]
        public void AUT_WorkflowState_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowStateInstanceFixture, 
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
        ///     Class (<see cref="WorkflowState" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkflowState_Is_Instance_Present_Test()
        {
            // Assert
            _workflowStateInstanceType.ShouldNotBeNull();
            _workflowStateInstance.ShouldNotBeNull();
            _workflowStateInstanceFixture.ShouldNotBeNull();
            _workflowStateInstance.ShouldBeAssignableTo<WorkflowState>();
            _workflowStateInstanceFixture.ShouldBeAssignableTo<WorkflowState>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowState) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowState_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowState instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowStateInstanceType.ShouldNotBeNull();
            _workflowStateInstance.ShouldNotBeNull();
            _workflowStateInstanceFixture.ShouldNotBeNull();
            _workflowStateInstance.ShouldBeAssignableTo<WorkflowState>();
            _workflowStateInstanceFixture.ShouldBeAssignableTo<WorkflowState>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowState) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyAPPLYCOLOR)]
        [TestCaseGeneric(typeof(string) , PropertyCOLORCODE)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCREATEEXPCHARGES)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCREATEPAYSCHEDULE)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCREATEPREBILLENTRY)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCREATEPURORDERS)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCWPATTRIBUTES)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyCanAttachReceipts)]
        [TestCaseGeneric(typeof(string) , PropertyDescription)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyEXPORTINVOICEACC)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyGENINVOICENO)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyISAPPROVEDBYPM)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyISCOMPLETION)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyISREIMBURSE)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyISREJECTION)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyISSUEINVOICE)]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsApproval)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsAssignment)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsFinal)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsInitial)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsReadOnly)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyIsRequisition)]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        [TestCaseGeneric(typeof(string) , PropertyPOSTPROCESSACTION)]
        [TestCaseGeneric(typeof(string) , PropertyPREPROCESSACTION)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.ProjectWorkflowStateFlag[]) , PropertyProjectWorkflowStateFlag)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyRECOGNIZEINVOICE)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyRECOMPBILL)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyRECOMPCOST)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertySYNCMSPROJECT)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyTAKEOWNERSHIP)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyVERIFYOVRTIME)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyVERIFYT_A)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyVERIFYWORK)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.WorkflowMap) , PropertyWorkflowMap)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyWorkflowMapId)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxUserService.WorkflowTransition[]) , PropertyWorkflowTransition)]
        public void AUT_WorkflowState_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowState, T>(_workflowStateInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (APPLYCOLOR) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_APPLYCOLOR_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyAPPLYCOLOR);
            var propertyInfo  = this.GetPropertyInfo(PropertyAPPLYCOLOR);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (CanAttachReceipts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_CanAttachReceipts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCanAttachReceipts);
            var propertyInfo  = this.GetPropertyInfo(PropertyCanAttachReceipts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (COLORCODE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_COLORCODE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCOLORCODE);
            var propertyInfo  = this.GetPropertyInfo(PropertyCOLORCODE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (CREATEEXPCHARGES) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_CREATEEXPCHARGES_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCREATEEXPCHARGES);
            var propertyInfo  = this.GetPropertyInfo(PropertyCREATEEXPCHARGES);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (CREATEPAYSCHEDULE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_CREATEPAYSCHEDULE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCREATEPAYSCHEDULE);
            var propertyInfo  = this.GetPropertyInfo(PropertyCREATEPAYSCHEDULE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (CREATEPREBILLENTRY) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_CREATEPREBILLENTRY_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCREATEPREBILLENTRY);
            var propertyInfo  = this.GetPropertyInfo(PropertyCREATEPREBILLENTRY);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (CREATEPURORDERS) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_CREATEPURORDERS_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCREATEPURORDERS);
            var propertyInfo  = this.GetPropertyInfo(PropertyCREATEPURORDERS);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (CWPATTRIBUTES) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_CWPATTRIBUTES_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCWPATTRIBUTES);
            var propertyInfo  = this.GetPropertyInfo(PropertyCWPATTRIBUTES);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (Description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_Description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowState) => Property (EXPORTINVOICEACC) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_EXPORTINVOICEACC_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyEXPORTINVOICEACC);
            var propertyInfo  = this.GetPropertyInfo(PropertyEXPORTINVOICEACC);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_workflowStateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowState) => Property (GENINVOICENO) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_GENINVOICENO_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyGENINVOICENO);
            var propertyInfo  = this.GetPropertyInfo(PropertyGENINVOICENO);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowState) => Property (IsApproval) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_IsApproval_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsApproval);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsApproval);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (ISAPPROVEDBYPM) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_ISAPPROVEDBYPM_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyISAPPROVEDBYPM);
            var propertyInfo  = this.GetPropertyInfo(PropertyISAPPROVEDBYPM);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (IsAssignment) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_IsAssignment_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsAssignment);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsAssignment);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (ISCOMPLETION) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_ISCOMPLETION_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyISCOMPLETION);
            var propertyInfo  = this.GetPropertyInfo(PropertyISCOMPLETION);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (IsFinal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_IsFinal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsFinal);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsFinal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (IsInitial) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_IsInitial_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsInitial);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsInitial);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (IsReadOnly) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_IsReadOnly_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsReadOnly);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsReadOnly);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (ISREIMBURSE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_ISREIMBURSE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyISREIMBURSE);
            var propertyInfo  = this.GetPropertyInfo(PropertyISREIMBURSE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (ISREJECTION) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_ISREJECTION_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyISREJECTION);
            var propertyInfo  = this.GetPropertyInfo(PropertyISREJECTION);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (IsRequisition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_IsRequisition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyIsRequisition);
            var propertyInfo  = this.GetPropertyInfo(PropertyIsRequisition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (ISSUEINVOICE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_ISSUEINVOICE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyISSUEINVOICE);
            var propertyInfo  = this.GetPropertyInfo(PropertyISSUEINVOICE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowState) => Property (POSTPROCESSACTION) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_POSTPROCESSACTION_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPOSTPROCESSACTION);
            var propertyInfo  = this.GetPropertyInfo(PropertyPOSTPROCESSACTION);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (PREPROCESSACTION) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_PREPROCESSACTION_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPREPROCESSACTION);
            var propertyInfo  = this.GetPropertyInfo(PropertyPREPROCESSACTION);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (ProjectWorkflowStateFlag) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_ProjectWorkflowStateFlag_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflowStateFlag);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyProjectWorkflowStateFlag);
            Action currentAction = () => propertyInfo.SetValue(_workflowStateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (ProjectWorkflowStateFlag) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_ProjectWorkflowStateFlag_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyProjectWorkflowStateFlag);
            var propertyInfo  = this.GetPropertyInfo(PropertyProjectWorkflowStateFlag);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (RECOGNIZEINVOICE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_RECOGNIZEINVOICE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRECOGNIZEINVOICE);
            var propertyInfo  = this.GetPropertyInfo(PropertyRECOGNIZEINVOICE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (RECOMPBILL) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_RECOMPBILL_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRECOMPBILL);
            var propertyInfo  = this.GetPropertyInfo(PropertyRECOMPBILL);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (RECOMPCOST) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_RECOMPCOST_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRECOMPCOST);
            var propertyInfo  = this.GetPropertyInfo(PropertyRECOMPCOST);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (SYNCMSPROJECT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_SYNCMSPROJECT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySYNCMSPROJECT);
            var propertyInfo  = this.GetPropertyInfo(PropertySYNCMSPROJECT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_workflowStateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowState) => Property (TAKEOWNERSHIP) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_TAKEOWNERSHIP_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTAKEOWNERSHIP);
            var propertyInfo  = this.GetPropertyInfo(PropertyTAKEOWNERSHIP);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WorkflowState) => Property (VERIFYOVRTIME) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_VERIFYOVRTIME_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyVERIFYOVRTIME);
            var propertyInfo  = this.GetPropertyInfo(PropertyVERIFYOVRTIME);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (VERIFYT_A) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_VERIFYT_A_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyVERIFYT_A);
            var propertyInfo  = this.GetPropertyInfo(PropertyVERIFYT_A);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (VERIFYWORK) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_VERIFYWORK_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyVERIFYWORK);
            var propertyInfo  = this.GetPropertyInfo(PropertyVERIFYWORK);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (WorkflowMap) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_WorkflowMap_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowMap);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyWorkflowMap);
            Action currentAction = () => propertyInfo.SetValue(_workflowStateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (WorkflowMap) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_WorkflowMap_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowMap);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowMap);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (WorkflowMapId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_WorkflowMapId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowMapId);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowMapId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (WorkflowTransition) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_WorkflowTransition_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowTransition);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyWorkflowTransition);
            Action currentAction = () => propertyInfo.SetValue(_workflowStateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowState) => Property (WorkflowTransition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_WorkflowState_Public_Class_WorkflowTransition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyWorkflowTransition);
            var propertyInfo  = this.GetPropertyInfo(PropertyWorkflowTransition);

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
        private void AUT_WorkflowState_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workflowStateInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkflowState_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workflowStateInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_WorkflowState_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workflowStateInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_WorkflowState_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_WorkflowState_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workflowStateInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkflowState_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workflowStateInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}