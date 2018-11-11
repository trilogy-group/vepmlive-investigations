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
using AccountingConnection = UplandIntegrations.TenroxProjectService;

namespace UplandIntegrations.TenroxProjectService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="UplandIntegrations.TenroxProjectService.AccountingConnection" />)
    ///     and namespace <see cref="UplandIntegrations.TenroxProjectService"/> class using generator(v:0.2.2)'s 
    ///     artificial intelligence. Compatible with <see cref="AUT.ConfigureTestProjects" /> v4.2.6.
    /// </summary>
    [TestFixture]
    public partial class AccountingConnectionTest : AbstractBaseSetupV3Test
    {
        public AccountingConnectionTest() : base(typeof(AccountingConnection))
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

        #region General Initializer : Class (AccountingConnection) Initializer

        #region Properties

        private const string PropertyExtensionData = "ExtensionData";
        private const string PropertyACCRUAL_CURR_ACCRUAL_NUM = "ACCRUAL_CURR_ACCRUAL_NUM";
        private const string PropertyACCRUAL_NUMBER_OF_DIGITS = "ACCRUAL_NUMBER_OF_DIGITS";
        private const string PropertyACCRUAL_NUMBER_OVERIDE = "ACCRUAL_NUMBER_OVERIDE";
        private const string PropertyACCRUAL_NUM_PREFIX = "ACCRUAL_NUM_PREFIX";
        private const string PropertyACCRUAL_WIP_TRANS_TYPE = "ACCRUAL_WIP_TRANS_TYPE";
        private const string PropertyADDRESSLINE1 = "ADDRESSLINE1";
        private const string PropertyADDRESSLINE2 = "ADDRESSLINE2";
        private const string PropertyCITY = "CITY";
        private const string PropertyCOUNTRY = "COUNTRY";
        private const string PropertyCURRENTINVOICENUM = "CURRENTINVOICENUM";
        private const string PropertyCURRENTPAYABLENUM = "CURRENTPAYABLENUM";
        private const string PropertyCURRENTPAYROLLNUM = "CURRENTPAYROLLNUM";
        private const string PropertyCompanyId = "CompanyId";
        private const string PropertyCompanyName = "CompanyName";
        private const string PropertyCurrencyId = "CurrencyId";
        private const string PropertyDEF_CHARGEREVACCOUNT = "DEF_CHARGEREVACCOUNT";
        private const string PropertyDEF_CHARGEWIPACCOUNT = "DEF_CHARGEWIPACCOUNT";
        private const string PropertyDEF_EXPENSEREVACCOUNT = "DEF_EXPENSEREVACCOUNT";
        private const string PropertyDEF_EXPENSEWIPACCOUNT = "DEF_EXPENSEWIPACCOUNT";
        private const string PropertyDEF_PRODUCTREVACCOUNT = "DEF_PRODUCTREVACCOUNT";
        private const string PropertyDEF_PRODUCTWIPACCOUNT = "DEF_PRODUCTWIPACCOUNT";
        private const string PropertyDEF_REVREQ_CHARGEFLAG = "DEF_REVREQ_CHARGEFLAG";
        private const string PropertyDEF_REVREQ_EXPENSEFLAG = "DEF_REVREQ_EXPENSEFLAG";
        private const string PropertyDEF_REVREQ_PRODUCTFLAG = "DEF_REVREQ_PRODUCTFLAG";
        private const string PropertyDEF_REVREQ_TIMEFLAG = "DEF_REVREQ_TIMEFLAG";
        private const string PropertyDEF_TIMEREVACCOUNT = "DEF_TIMEREVACCOUNT";
        private const string PropertyDEF_TIMEWIPACCOUNT = "DEF_TIMEWIPACCOUNT";
        private const string PropertyDataConnection = "DataConnection";
        private const string PropertyDefaultRevenueAccount = "DefaultRevenueAccount";
        private const string PropertyDefaultWIPAccount = "DefaultWIPAccount";
        private const string PropertyFAX_NUMBER = "FAX_NUMBER";
        private const string PropertyINVOICENUMOFDIGITS = "INVOICENUMOFDIGITS";
        private const string PropertyINVOICENUMPREFIX = "INVOICENUMPREFIX";
        private const string PropertyOVERRIDEINVOICENUM = "OVERRIDEINVOICENUM";
        private const string PropertyOVERRIDEPAYABLENUM = "OVERRIDEPAYABLENUM";
        private const string PropertyOVERRIDEPAYROLLNUM = "OVERRIDEPAYROLLNUM";
        private const string PropertyPAYABLENUMOFDIGITS = "PAYABLENUMOFDIGITS";
        private const string PropertyPAYABLENUMPREFIX = "PAYABLENUMPREFIX";
        private const string PropertyPAYROLLNUMOFDIGITS = "PAYROLLNUMOFDIGITS";
        private const string PropertyPAYROLLNUMPREFIX = "PAYROLLNUMPREFIX";
        private const string PropertyPHONE_NUMBER = "PHONE_NUMBER";
        private const string PropertyPassword = "Password";
        private const string PropertyRVRCBATCHNUMCURRENT = "RVRCBATCHNUMCURRENT";
        private const string PropertyRVRCBATCHNUMDIGITS = "RVRCBATCHNUMDIGITS";
        private const string PropertyRVRCBATCHNUMOVERRIDE = "RVRCBATCHNUMOVERRIDE";
        private const string PropertyRVRCBATCHNUMPREFIX = "RVRCBATCHNUMPREFIX";
        private const string PropertySQLVERSION = "SQLVERSION";
        private const string PropertySTATE = "STATE";
        private const string PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey = "SystemDataObjectsDataClassesIEntityWithKeyEntityKey";
        private const string PropertyTCURRENCY = "TCURRENCY";
        private const string PropertyTINVOICEs = "TINVOICEs";
        private const string PropertyTPAYABLEBATCHes = "TPAYABLEBATCHes";
        private const string PropertyTPAYROLLBATCHes = "TPAYROLLBATCHes";
        private const string PropertyTSYSDEFS = "TSYSDEFS";
        private const string PropertyUniqueId = "UniqueId";
        private const string PropertyUserId = "UserId";
        private const string PropertyZIPCODE = "ZIPCODE";

        #endregion

        #region Methods

        private const string MethodRaisePropertyChanged = "RaisePropertyChanged";

        #endregion

        #region Fields

        private const string FieldextensionDataField = "extensionDataField";
        private const string FieldACCRUAL_CURR_ACCRUAL_NUMField = "ACCRUAL_CURR_ACCRUAL_NUMField";
        private const string FieldACCRUAL_NUMBER_OF_DIGITSField = "ACCRUAL_NUMBER_OF_DIGITSField";
        private const string FieldACCRUAL_NUMBER_OVERIDEField = "ACCRUAL_NUMBER_OVERIDEField";
        private const string FieldACCRUAL_NUM_PREFIXField = "ACCRUAL_NUM_PREFIXField";
        private const string FieldACCRUAL_WIP_TRANS_TYPEField = "ACCRUAL_WIP_TRANS_TYPEField";
        private const string FieldADDRESSLINE1Field = "ADDRESSLINE1Field";
        private const string FieldADDRESSLINE2Field = "ADDRESSLINE2Field";
        private const string FieldCITYField = "CITYField";
        private const string FieldCOUNTRYField = "COUNTRYField";
        private const string FieldCURRENTINVOICENUMField = "CURRENTINVOICENUMField";
        private const string FieldCURRENTPAYABLENUMField = "CURRENTPAYABLENUMField";
        private const string FieldCURRENTPAYROLLNUMField = "CURRENTPAYROLLNUMField";
        private const string FieldCompanyIdField = "CompanyIdField";
        private const string FieldCompanyNameField = "CompanyNameField";
        private const string FieldCurrencyIdField = "CurrencyIdField";
        private const string FieldDEF_CHARGEREVACCOUNTField = "DEF_CHARGEREVACCOUNTField";
        private const string FieldDEF_CHARGEWIPACCOUNTField = "DEF_CHARGEWIPACCOUNTField";
        private const string FieldDEF_EXPENSEREVACCOUNTField = "DEF_EXPENSEREVACCOUNTField";
        private const string FieldDEF_EXPENSEWIPACCOUNTField = "DEF_EXPENSEWIPACCOUNTField";
        private const string FieldDEF_PRODUCTREVACCOUNTField = "DEF_PRODUCTREVACCOUNTField";
        private const string FieldDEF_PRODUCTWIPACCOUNTField = "DEF_PRODUCTWIPACCOUNTField";
        private const string FieldDEF_REVREQ_CHARGEFLAGField = "DEF_REVREQ_CHARGEFLAGField";
        private const string FieldDEF_REVREQ_EXPENSEFLAGField = "DEF_REVREQ_EXPENSEFLAGField";
        private const string FieldDEF_REVREQ_PRODUCTFLAGField = "DEF_REVREQ_PRODUCTFLAGField";
        private const string FieldDEF_REVREQ_TIMEFLAGField = "DEF_REVREQ_TIMEFLAGField";
        private const string FieldDEF_TIMEREVACCOUNTField = "DEF_TIMEREVACCOUNTField";
        private const string FieldDEF_TIMEWIPACCOUNTField = "DEF_TIMEWIPACCOUNTField";
        private const string FieldDataConnectionField = "DataConnectionField";
        private const string FieldDefaultRevenueAccountField = "DefaultRevenueAccountField";
        private const string FieldDefaultWIPAccountField = "DefaultWIPAccountField";
        private const string FieldFAX_NUMBERField = "FAX_NUMBERField";
        private const string FieldINVOICENUMOFDIGITSField = "INVOICENUMOFDIGITSField";
        private const string FieldINVOICENUMPREFIXField = "INVOICENUMPREFIXField";
        private const string FieldOVERRIDEINVOICENUMField = "OVERRIDEINVOICENUMField";
        private const string FieldOVERRIDEPAYABLENUMField = "OVERRIDEPAYABLENUMField";
        private const string FieldOVERRIDEPAYROLLNUMField = "OVERRIDEPAYROLLNUMField";
        private const string FieldPAYABLENUMOFDIGITSField = "PAYABLENUMOFDIGITSField";
        private const string FieldPAYABLENUMPREFIXField = "PAYABLENUMPREFIXField";
        private const string FieldPAYROLLNUMOFDIGITSField = "PAYROLLNUMOFDIGITSField";
        private const string FieldPAYROLLNUMPREFIXField = "PAYROLLNUMPREFIXField";
        private const string FieldPHONE_NUMBERField = "PHONE_NUMBERField";
        private const string FieldPasswordField = "PasswordField";
        private const string FieldRVRCBATCHNUMCURRENTField = "RVRCBATCHNUMCURRENTField";
        private const string FieldRVRCBATCHNUMDIGITSField = "RVRCBATCHNUMDIGITSField";
        private const string FieldRVRCBATCHNUMOVERRIDEField = "RVRCBATCHNUMOVERRIDEField";
        private const string FieldRVRCBATCHNUMPREFIXField = "RVRCBATCHNUMPREFIXField";
        private const string FieldSQLVERSIONField = "SQLVERSIONField";
        private const string FieldSTATEField = "STATEField";
        private const string FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField = "SystemDataObjectsDataClassesIEntityWithKeyEntityKeyField";
        private const string FieldTCURRENCYField = "TCURRENCYField";
        private const string FieldTINVOICEsField = "TINVOICEsField";
        private const string FieldTPAYABLEBATCHesField = "TPAYABLEBATCHesField";
        private const string FieldTPAYROLLBATCHesField = "TPAYROLLBATCHesField";
        private const string FieldTSYSDEFSField = "TSYSDEFSField";
        private const string FieldUniqueIdField = "UniqueIdField";
        private const string FieldUserIdField = "UserIdField";
        private const string FieldZIPCODEField = "ZIPCODEField";

        #endregion

        private Type _accountingConnectionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutEightSeconds;
        private AccountingConnection _accountingConnectionInstance;
        private AccountingConnection _accountingConnectionInstanceFixture;

        #region General Initializer : Class (AccountingConnection) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AccountingConnection" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _accountingConnectionInstanceType = typeof(AccountingConnection);
            _accountingConnectionInstanceFixture = this.Create<AccountingConnection>(true);
            _accountingConnectionInstance = _accountingConnectionInstanceFixture ?? this.Create<AccountingConnection>(false);
            CurrentInstance = _accountingConnectionInstanceFixture;
            ConfigureIgnoringTests();
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AccountingConnection)

        #region General Initializer : Class (AccountingConnection) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="AccountingConnection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRaisePropertyChanged, 0)]
        public void AUT_AccountingConnection_All_Methods_Explore_Verify_Test(string name, int overloadingIndex = 0)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var currentMethodInfo = this.GetMethodInfo(name, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_accountingConnectionInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AccountingConnection) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AccountingConnection" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExtensionData)]
        [TestCase(PropertyACCRUAL_CURR_ACCRUAL_NUM)]
        [TestCase(PropertyACCRUAL_NUMBER_OF_DIGITS)]
        [TestCase(PropertyACCRUAL_NUMBER_OVERIDE)]
        [TestCase(PropertyACCRUAL_NUM_PREFIX)]
        [TestCase(PropertyACCRUAL_WIP_TRANS_TYPE)]
        [TestCase(PropertyADDRESSLINE1)]
        [TestCase(PropertyADDRESSLINE2)]
        [TestCase(PropertyCITY)]
        [TestCase(PropertyCOUNTRY)]
        [TestCase(PropertyCURRENTINVOICENUM)]
        [TestCase(PropertyCURRENTPAYABLENUM)]
        [TestCase(PropertyCURRENTPAYROLLNUM)]
        [TestCase(PropertyCompanyId)]
        [TestCase(PropertyCompanyName)]
        [TestCase(PropertyCurrencyId)]
        [TestCase(PropertyDEF_CHARGEREVACCOUNT)]
        [TestCase(PropertyDEF_CHARGEWIPACCOUNT)]
        [TestCase(PropertyDEF_EXPENSEREVACCOUNT)]
        [TestCase(PropertyDEF_EXPENSEWIPACCOUNT)]
        [TestCase(PropertyDEF_PRODUCTREVACCOUNT)]
        [TestCase(PropertyDEF_PRODUCTWIPACCOUNT)]
        [TestCase(PropertyDEF_REVREQ_CHARGEFLAG)]
        [TestCase(PropertyDEF_REVREQ_EXPENSEFLAG)]
        [TestCase(PropertyDEF_REVREQ_PRODUCTFLAG)]
        [TestCase(PropertyDEF_REVREQ_TIMEFLAG)]
        [TestCase(PropertyDEF_TIMEREVACCOUNT)]
        [TestCase(PropertyDEF_TIMEWIPACCOUNT)]
        [TestCase(PropertyDataConnection)]
        [TestCase(PropertyDefaultRevenueAccount)]
        [TestCase(PropertyDefaultWIPAccount)]
        [TestCase(PropertyFAX_NUMBER)]
        [TestCase(PropertyINVOICENUMOFDIGITS)]
        [TestCase(PropertyINVOICENUMPREFIX)]
        [TestCase(PropertyOVERRIDEINVOICENUM)]
        [TestCase(PropertyOVERRIDEPAYABLENUM)]
        [TestCase(PropertyOVERRIDEPAYROLLNUM)]
        [TestCase(PropertyPAYABLENUMOFDIGITS)]
        [TestCase(PropertyPAYABLENUMPREFIX)]
        [TestCase(PropertyPAYROLLNUMOFDIGITS)]
        [TestCase(PropertyPAYROLLNUMPREFIX)]
        [TestCase(PropertyPHONE_NUMBER)]
        [TestCase(PropertyPassword)]
        [TestCase(PropertyRVRCBATCHNUMCURRENT)]
        [TestCase(PropertyRVRCBATCHNUMDIGITS)]
        [TestCase(PropertyRVRCBATCHNUMOVERRIDE)]
        [TestCase(PropertyRVRCBATCHNUMPREFIX)]
        [TestCase(PropertySQLVERSION)]
        [TestCase(PropertySTATE)]
        [TestCase(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCase(PropertyTCURRENCY)]
        [TestCase(PropertyTINVOICEs)]
        [TestCase(PropertyTPAYABLEBATCHes)]
        [TestCase(PropertyTPAYROLLBATCHes)]
        [TestCase(PropertyTSYSDEFS)]
        [TestCase(PropertyUniqueId)]
        [TestCase(PropertyUserId)]
        [TestCase(PropertyZIPCODE)]
        public void AUT_AccountingConnection_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var propertyInfo = this.GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_accountingConnectionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AccountingConnection) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AccountingConnection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldextensionDataField)]
        [TestCase(FieldACCRUAL_CURR_ACCRUAL_NUMField)]
        [TestCase(FieldACCRUAL_NUMBER_OF_DIGITSField)]
        [TestCase(FieldACCRUAL_NUMBER_OVERIDEField)]
        [TestCase(FieldACCRUAL_NUM_PREFIXField)]
        [TestCase(FieldACCRUAL_WIP_TRANS_TYPEField)]
        [TestCase(FieldADDRESSLINE1Field)]
        [TestCase(FieldADDRESSLINE2Field)]
        [TestCase(FieldCITYField)]
        [TestCase(FieldCOUNTRYField)]
        [TestCase(FieldCURRENTINVOICENUMField)]
        [TestCase(FieldCURRENTPAYABLENUMField)]
        [TestCase(FieldCURRENTPAYROLLNUMField)]
        [TestCase(FieldCompanyIdField)]
        [TestCase(FieldCompanyNameField)]
        [TestCase(FieldCurrencyIdField)]
        [TestCase(FieldDEF_CHARGEREVACCOUNTField)]
        [TestCase(FieldDEF_CHARGEWIPACCOUNTField)]
        [TestCase(FieldDEF_EXPENSEREVACCOUNTField)]
        [TestCase(FieldDEF_EXPENSEWIPACCOUNTField)]
        [TestCase(FieldDEF_PRODUCTREVACCOUNTField)]
        [TestCase(FieldDEF_PRODUCTWIPACCOUNTField)]
        [TestCase(FieldDEF_REVREQ_CHARGEFLAGField)]
        [TestCase(FieldDEF_REVREQ_EXPENSEFLAGField)]
        [TestCase(FieldDEF_REVREQ_PRODUCTFLAGField)]
        [TestCase(FieldDEF_REVREQ_TIMEFLAGField)]
        [TestCase(FieldDEF_TIMEREVACCOUNTField)]
        [TestCase(FieldDEF_TIMEWIPACCOUNTField)]
        [TestCase(FieldDataConnectionField)]
        [TestCase(FieldDefaultRevenueAccountField)]
        [TestCase(FieldDefaultWIPAccountField)]
        [TestCase(FieldFAX_NUMBERField)]
        [TestCase(FieldINVOICENUMOFDIGITSField)]
        [TestCase(FieldINVOICENUMPREFIXField)]
        [TestCase(FieldOVERRIDEINVOICENUMField)]
        [TestCase(FieldOVERRIDEPAYABLENUMField)]
        [TestCase(FieldOVERRIDEPAYROLLNUMField)]
        [TestCase(FieldPAYABLENUMOFDIGITSField)]
        [TestCase(FieldPAYABLENUMPREFIXField)]
        [TestCase(FieldPAYROLLNUMOFDIGITSField)]
        [TestCase(FieldPAYROLLNUMPREFIXField)]
        [TestCase(FieldPHONE_NUMBERField)]
        [TestCase(FieldPasswordField)]
        [TestCase(FieldRVRCBATCHNUMCURRENTField)]
        [TestCase(FieldRVRCBATCHNUMDIGITSField)]
        [TestCase(FieldRVRCBATCHNUMOVERRIDEField)]
        [TestCase(FieldRVRCBATCHNUMPREFIXField)]
        [TestCase(FieldSQLVERSIONField)]
        [TestCase(FieldSTATEField)]
        [TestCase(FieldSystemDataObjectsDataClassesIEntityWithKeyEntityKeyField)]
        [TestCase(FieldTCURRENCYField)]
        [TestCase(FieldTINVOICEsField)]
        [TestCase(FieldTPAYABLEBATCHesField)]
        [TestCase(FieldTPAYROLLBATCHesField)]
        [TestCase(FieldTSYSDEFSField)]
        [TestCase(FieldUniqueIdField)]
        [TestCase(FieldUserIdField)]
        [TestCase(FieldZIPCODEField)]
        public void AUT_AccountingConnection_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);
            var fieldInfo = this.GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_accountingConnectionInstanceFixture, 
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
        ///     Class (<see cref="AccountingConnection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_AccountingConnection_Is_Instance_Present_Test()
        {
            // Assert
            _accountingConnectionInstanceType.ShouldNotBeNull();
            _accountingConnectionInstance.ShouldNotBeNull();
            _accountingConnectionInstanceFixture.ShouldNotBeNull();
            _accountingConnectionInstance.ShouldBeAssignableTo<AccountingConnection>();
            _accountingConnectionInstanceFixture.ShouldBeAssignableTo<AccountingConnection>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AccountingConnection) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_AccountingConnection_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AccountingConnection instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _accountingConnectionInstanceType.ShouldNotBeNull();
            _accountingConnectionInstance.ShouldNotBeNull();
            _accountingConnectionInstanceFixture.ShouldNotBeNull();
            _accountingConnectionInstance.ShouldBeAssignableTo<AccountingConnection>();
            _accountingConnectionInstanceFixture.ShouldBeAssignableTo<AccountingConnection>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AccountingConnection) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Runtime.Serialization.ExtensionDataObject) , PropertyExtensionData)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyACCRUAL_CURR_ACCRUAL_NUM)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyACCRUAL_NUMBER_OF_DIGITS)]
        [TestCaseGeneric(typeof(System.Nullable<byte>) , PropertyACCRUAL_NUMBER_OVERIDE)]
        [TestCaseGeneric(typeof(string) , PropertyACCRUAL_NUM_PREFIX)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyACCRUAL_WIP_TRANS_TYPE)]
        [TestCaseGeneric(typeof(string) , PropertyADDRESSLINE1)]
        [TestCaseGeneric(typeof(string) , PropertyADDRESSLINE2)]
        [TestCaseGeneric(typeof(string) , PropertyCITY)]
        [TestCaseGeneric(typeof(string) , PropertyCOUNTRY)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCURRENTINVOICENUM)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCURRENTPAYABLENUM)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCURRENTPAYROLLNUM)]
        [TestCaseGeneric(typeof(string) , PropertyCompanyId)]
        [TestCaseGeneric(typeof(string) , PropertyCompanyName)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyCurrencyId)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDEF_CHARGEREVACCOUNT)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDEF_CHARGEWIPACCOUNT)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDEF_EXPENSEREVACCOUNT)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDEF_EXPENSEWIPACCOUNT)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDEF_PRODUCTREVACCOUNT)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDEF_PRODUCTWIPACCOUNT)]
        [TestCaseGeneric(typeof(byte) , PropertyDEF_REVREQ_CHARGEFLAG)]
        [TestCaseGeneric(typeof(byte) , PropertyDEF_REVREQ_EXPENSEFLAG)]
        [TestCaseGeneric(typeof(byte) , PropertyDEF_REVREQ_PRODUCTFLAG)]
        [TestCaseGeneric(typeof(byte) , PropertyDEF_REVREQ_TIMEFLAG)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDEF_TIMEREVACCOUNT)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDEF_TIMEWIPACCOUNT)]
        [TestCaseGeneric(typeof(string) , PropertyDataConnection)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDefaultRevenueAccount)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyDefaultWIPAccount)]
        [TestCaseGeneric(typeof(string) , PropertyFAX_NUMBER)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyINVOICENUMOFDIGITS)]
        [TestCaseGeneric(typeof(string) , PropertyINVOICENUMPREFIX)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOVERRIDEINVOICENUM)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOVERRIDEPAYABLENUM)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyOVERRIDEPAYROLLNUM)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPAYABLENUMOFDIGITS)]
        [TestCaseGeneric(typeof(string) , PropertyPAYABLENUMPREFIX)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyPAYROLLNUMOFDIGITS)]
        [TestCaseGeneric(typeof(string) , PropertyPAYROLLNUMPREFIX)]
        [TestCaseGeneric(typeof(string) , PropertyPHONE_NUMBER)]
        [TestCaseGeneric(typeof(string) , PropertyPassword)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyRVRCBATCHNUMCURRENT)]
        [TestCaseGeneric(typeof(System.Nullable<int>) , PropertyRVRCBATCHNUMDIGITS)]
        [TestCaseGeneric(typeof(System.Nullable<short>) , PropertyRVRCBATCHNUMOVERRIDE)]
        [TestCaseGeneric(typeof(string) , PropertyRVRCBATCHNUMPREFIX)]
        [TestCaseGeneric(typeof(string) , PropertySQLVERSION)]
        [TestCaseGeneric(typeof(string) , PropertySTATE)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.EntityKey) , PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.Currency) , PropertyTCURRENCY)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.Invoice[]) , PropertyTINVOICEs)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.PayableBatch[]) , PropertyTPAYABLEBATCHes)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.PayrollBatch[]) , PropertyTPAYROLLBATCHes)]
        [TestCaseGeneric(typeof(UplandIntegrations.TenroxProjectService.SystemDefault[]) , PropertyTSYSDEFS)]
        [TestCaseGeneric(typeof(int) , PropertyUniqueId)]
        [TestCaseGeneric(typeof(string) , PropertyUserId)]
        [TestCaseGeneric(typeof(string) , PropertyZIPCODE)]
        public void AUT_AccountingConnection_Property_Type_Verify_Explore_By_Name_Test<T>(string name)
        {
            // Arrange
            this.ValidateExecuteCondition(name);

            // Assert
            ShouldlyExtension.PropertyTypeVerify<AccountingConnection, T>(_accountingConnectionInstance, name, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (ACCRUAL_CURR_ACCRUAL_NUM) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_ACCRUAL_CURR_ACCRUAL_NUM_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyACCRUAL_CURR_ACCRUAL_NUM);
            var propertyInfo  = this.GetPropertyInfo(PropertyACCRUAL_CURR_ACCRUAL_NUM);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (ACCRUAL_NUM_PREFIX) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_ACCRUAL_NUM_PREFIX_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyACCRUAL_NUM_PREFIX);
            var propertyInfo  = this.GetPropertyInfo(PropertyACCRUAL_NUM_PREFIX);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (ACCRUAL_NUMBER_OF_DIGITS) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_ACCRUAL_NUMBER_OF_DIGITS_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyACCRUAL_NUMBER_OF_DIGITS);
            var propertyInfo  = this.GetPropertyInfo(PropertyACCRUAL_NUMBER_OF_DIGITS);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (ACCRUAL_NUMBER_OVERIDE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_ACCRUAL_NUMBER_OVERIDE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyACCRUAL_NUMBER_OVERIDE);
            var propertyInfo  = this.GetPropertyInfo(PropertyACCRUAL_NUMBER_OVERIDE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (ACCRUAL_WIP_TRANS_TYPE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_ACCRUAL_WIP_TRANS_TYPE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyACCRUAL_WIP_TRANS_TYPE);
            var propertyInfo  = this.GetPropertyInfo(PropertyACCRUAL_WIP_TRANS_TYPE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (ADDRESSLINE1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_ADDRESSLINE1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyADDRESSLINE1);
            var propertyInfo  = this.GetPropertyInfo(PropertyADDRESSLINE1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (ADDRESSLINE2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_ADDRESSLINE2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyADDRESSLINE2);
            var propertyInfo  = this.GetPropertyInfo(PropertyADDRESSLINE2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (CITY) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_CITY_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCITY);
            var propertyInfo  = this.GetPropertyInfo(PropertyCITY);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (CompanyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_CompanyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCompanyId);
            var propertyInfo  = this.GetPropertyInfo(PropertyCompanyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (CompanyName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_CompanyName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCompanyName);
            var propertyInfo  = this.GetPropertyInfo(PropertyCompanyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (COUNTRY) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_COUNTRY_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCOUNTRY);
            var propertyInfo  = this.GetPropertyInfo(PropertyCOUNTRY);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (CurrencyId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_CurrencyId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCurrencyId);
            var propertyInfo  = this.GetPropertyInfo(PropertyCurrencyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (CURRENTINVOICENUM) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_CURRENTINVOICENUM_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCURRENTINVOICENUM);
            var propertyInfo  = this.GetPropertyInfo(PropertyCURRENTINVOICENUM);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (CURRENTPAYABLENUM) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_CURRENTPAYABLENUM_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCURRENTPAYABLENUM);
            var propertyInfo  = this.GetPropertyInfo(PropertyCURRENTPAYABLENUM);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (CURRENTPAYROLLNUM) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_CURRENTPAYROLLNUM_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyCURRENTPAYROLLNUM);
            var propertyInfo  = this.GetPropertyInfo(PropertyCURRENTPAYROLLNUM);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DataConnection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DataConnection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDataConnection);
            var propertyInfo  = this.GetPropertyInfo(PropertyDataConnection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_CHARGEREVACCOUNT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_CHARGEREVACCOUNT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_CHARGEREVACCOUNT);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_CHARGEREVACCOUNT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_CHARGEWIPACCOUNT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_CHARGEWIPACCOUNT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_CHARGEWIPACCOUNT);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_CHARGEWIPACCOUNT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_EXPENSEREVACCOUNT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_EXPENSEREVACCOUNT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_EXPENSEREVACCOUNT);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_EXPENSEREVACCOUNT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_EXPENSEWIPACCOUNT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_EXPENSEWIPACCOUNT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_EXPENSEWIPACCOUNT);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_EXPENSEWIPACCOUNT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_PRODUCTREVACCOUNT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_PRODUCTREVACCOUNT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_PRODUCTREVACCOUNT);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_PRODUCTREVACCOUNT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_PRODUCTWIPACCOUNT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_PRODUCTWIPACCOUNT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_PRODUCTWIPACCOUNT);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_PRODUCTWIPACCOUNT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_REVREQ_CHARGEFLAG) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_DEF_REVREQ_CHARGEFLAG_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_REVREQ_CHARGEFLAG);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyDEF_REVREQ_CHARGEFLAG);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_REVREQ_CHARGEFLAG) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_REVREQ_CHARGEFLAG_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_REVREQ_CHARGEFLAG);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_REVREQ_CHARGEFLAG);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_REVREQ_EXPENSEFLAG) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_DEF_REVREQ_EXPENSEFLAG_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_REVREQ_EXPENSEFLAG);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyDEF_REVREQ_EXPENSEFLAG);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_REVREQ_EXPENSEFLAG) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_REVREQ_EXPENSEFLAG_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_REVREQ_EXPENSEFLAG);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_REVREQ_EXPENSEFLAG);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_REVREQ_PRODUCTFLAG) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_DEF_REVREQ_PRODUCTFLAG_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_REVREQ_PRODUCTFLAG);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyDEF_REVREQ_PRODUCTFLAG);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_REVREQ_PRODUCTFLAG) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_REVREQ_PRODUCTFLAG_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_REVREQ_PRODUCTFLAG);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_REVREQ_PRODUCTFLAG);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_REVREQ_TIMEFLAG) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_DEF_REVREQ_TIMEFLAG_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_REVREQ_TIMEFLAG);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyDEF_REVREQ_TIMEFLAG);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_REVREQ_TIMEFLAG) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_REVREQ_TIMEFLAG_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_REVREQ_TIMEFLAG);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_REVREQ_TIMEFLAG);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_TIMEREVACCOUNT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_TIMEREVACCOUNT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_TIMEREVACCOUNT);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_TIMEREVACCOUNT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DEF_TIMEWIPACCOUNT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DEF_TIMEWIPACCOUNT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDEF_TIMEWIPACCOUNT);
            var propertyInfo  = this.GetPropertyInfo(PropertyDEF_TIMEWIPACCOUNT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DefaultRevenueAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DefaultRevenueAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDefaultRevenueAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyDefaultRevenueAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (DefaultWIPAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_DefaultWIPAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyDefaultWIPAccount);
            var propertyInfo  = this.GetPropertyInfo(PropertyDefaultWIPAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (ExtensionData) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_ExtensionData_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyExtensionData);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyExtensionData);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (ExtensionData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_ExtensionData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountingConnection) => Property (FAX_NUMBER) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_FAX_NUMBER_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyFAX_NUMBER);
            var propertyInfo  = this.GetPropertyInfo(PropertyFAX_NUMBER);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (INVOICENUMOFDIGITS) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_INVOICENUMOFDIGITS_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyINVOICENUMOFDIGITS);
            var propertyInfo  = this.GetPropertyInfo(PropertyINVOICENUMOFDIGITS);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (INVOICENUMPREFIX) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_INVOICENUMPREFIX_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyINVOICENUMPREFIX);
            var propertyInfo  = this.GetPropertyInfo(PropertyINVOICENUMPREFIX);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (OVERRIDEINVOICENUM) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_OVERRIDEINVOICENUM_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOVERRIDEINVOICENUM);
            var propertyInfo  = this.GetPropertyInfo(PropertyOVERRIDEINVOICENUM);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (OVERRIDEPAYABLENUM) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_OVERRIDEPAYABLENUM_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOVERRIDEPAYABLENUM);
            var propertyInfo  = this.GetPropertyInfo(PropertyOVERRIDEPAYABLENUM);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (OVERRIDEPAYROLLNUM) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_OVERRIDEPAYROLLNUM_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyOVERRIDEPAYROLLNUM);
            var propertyInfo  = this.GetPropertyInfo(PropertyOVERRIDEPAYROLLNUM);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (Password) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_Password_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPassword);
            var propertyInfo  = this.GetPropertyInfo(PropertyPassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (PAYABLENUMOFDIGITS) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_PAYABLENUMOFDIGITS_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPAYABLENUMOFDIGITS);
            var propertyInfo  = this.GetPropertyInfo(PropertyPAYABLENUMOFDIGITS);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (PAYABLENUMPREFIX) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_PAYABLENUMPREFIX_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPAYABLENUMPREFIX);
            var propertyInfo  = this.GetPropertyInfo(PropertyPAYABLENUMPREFIX);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (PAYROLLNUMOFDIGITS) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_PAYROLLNUMOFDIGITS_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPAYROLLNUMOFDIGITS);
            var propertyInfo  = this.GetPropertyInfo(PropertyPAYROLLNUMOFDIGITS);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (PAYROLLNUMPREFIX) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_PAYROLLNUMPREFIX_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPAYROLLNUMPREFIX);
            var propertyInfo  = this.GetPropertyInfo(PropertyPAYROLLNUMPREFIX);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (PHONE_NUMBER) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_PHONE_NUMBER_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyPHONE_NUMBER);
            var propertyInfo  = this.GetPropertyInfo(PropertyPHONE_NUMBER);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (RVRCBATCHNUMCURRENT) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_RVRCBATCHNUMCURRENT_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRVRCBATCHNUMCURRENT);
            var propertyInfo  = this.GetPropertyInfo(PropertyRVRCBATCHNUMCURRENT);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (RVRCBATCHNUMDIGITS) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_RVRCBATCHNUMDIGITS_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRVRCBATCHNUMDIGITS);
            var propertyInfo  = this.GetPropertyInfo(PropertyRVRCBATCHNUMDIGITS);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (RVRCBATCHNUMOVERRIDE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_RVRCBATCHNUMOVERRIDE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRVRCBATCHNUMOVERRIDE);
            var propertyInfo  = this.GetPropertyInfo(PropertyRVRCBATCHNUMOVERRIDE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (RVRCBATCHNUMPREFIX) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_RVRCBATCHNUMPREFIX_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyRVRCBATCHNUMPREFIX);
            var propertyInfo  = this.GetPropertyInfo(PropertyRVRCBATCHNUMPREFIX);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (SQLVERSION) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_SQLVERSION_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySQLVERSION);
            var propertyInfo  = this.GetPropertyInfo(PropertySQLVERSION);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (STATE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_STATE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySTATE);
            var propertyInfo  = this.GetPropertyInfo(PropertySTATE);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertySystemDataObjectsDataClassesIEntityWithKeyEntityKey);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (SystemDataObjectsDataClassesIEntityWithKeyEntityKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_SystemDataObjectsDataClassesIEntityWithKeyEntityKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountingConnection) => Property (TCURRENCY) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_TCURRENCY_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTCURRENCY);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTCURRENCY);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (TCURRENCY) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_TCURRENCY_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTCURRENCY);
            var propertyInfo  = this.GetPropertyInfo(PropertyTCURRENCY);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (TINVOICEs) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_TINVOICEs_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTINVOICEs);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTINVOICEs);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (TINVOICEs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_TINVOICEs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTINVOICEs);
            var propertyInfo  = this.GetPropertyInfo(PropertyTINVOICEs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (TPAYABLEBATCHes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_TPAYABLEBATCHes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPAYABLEBATCHes);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTPAYABLEBATCHes);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (TPAYABLEBATCHes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_TPAYABLEBATCHes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPAYABLEBATCHes);
            var propertyInfo  = this.GetPropertyInfo(PropertyTPAYABLEBATCHes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (TPAYROLLBATCHes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_TPAYROLLBATCHes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPAYROLLBATCHes);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTPAYROLLBATCHes);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (TPAYROLLBATCHes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_TPAYROLLBATCHes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTPAYROLLBATCHes);
            var propertyInfo  = this.GetPropertyInfo(PropertyTPAYROLLBATCHes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (TSYSDEFS) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_TSYSDEFS_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTSYSDEFS);
            var randomString = this.CreateType<string>();

            // Act
            var propertyInfo = this.GetPropertyInfo(PropertyTSYSDEFS);
            Action currentAction = () => propertyInfo.SetValue(_accountingConnectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (TSYSDEFS) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_TSYSDEFS_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyTSYSDEFS);
            var propertyInfo  = this.GetPropertyInfo(PropertyTSYSDEFS);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AccountingConnection) => Property (UniqueId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_UniqueId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountingConnection) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AccountingConnection) => Property (ZIPCODE) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_AccountingConnection_Public_Class_ZIPCODE_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(PropertyZIPCODE);
            var propertyInfo  = this.GetPropertyInfo(PropertyZIPCODE);

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
        private void AUT_AccountingConnection_RaisePropertyChanged_Method_Call_Internally(Type[] types)
        {
            var methodRaisePropertyChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_accountingConnectionInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AccountingConnection_RaisePropertyChanged_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };
            Exception exception = null;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_accountingConnectionInstanceFixture, parametersOfRaisePropertyChanged);

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
        public void AUT_AccountingConnection_RaisePropertyChanged_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var propertyName = this.CreateType<string>();
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfRaisePropertyChanged = { propertyName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_accountingConnectionInstance, MethodRaisePropertyChanged, parametersOfRaisePropertyChanged, methodRaisePropertyChangedPrametersTypes);

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
        public void AUT_AccountingConnection_RaisePropertyChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_AccountingConnection_RaisePropertyChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            var methodRaisePropertyChangedPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_accountingConnectionInstance, MethodRaisePropertyChanged, Fixture, methodRaisePropertyChangedPrametersTypes);

            // Assert
            methodRaisePropertyChangedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RaisePropertyChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_AccountingConnection_RaisePropertyChanged_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            this.ValidateExecuteCondition(MethodRaisePropertyChanged);
            Exception exception;
            var methodInfo = this.GetMethodInfo(MethodRaisePropertyChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_accountingConnectionInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}