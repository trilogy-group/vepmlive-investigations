using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace RPADataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="RPADataCache.RPConstants" />)
    ///     and namespace <see cref="RPADataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RPConstantsTest : AbstractBaseSetupTest
    {

        public RPConstantsTest() : base(typeof(RPConstants))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RPConstants) Initializer

        private const string MethodStripNum = "StripNum";
        private const string MethodGetCustValue = "GetCustValue";
        private const string FieldCONST_Commitment = "CONST_Commitment";
        private const string FieldCONST_Offer = "CONST_Offer";
        private const string FieldCONST_REQUEST = "CONST_REQUEST";
        private const string FieldCONST_Pending = "CONST_Pending";
        private const string FieldCONST_NW = "CONST_NW";
        private const string FieldCONST_MSPF = "CONST_MSPF";
        private const string FieldCONST_REQUIRE = "CONST_REQUIRE";
        private const string FieldCONST_OPENREQUEST = "CONST_OPENREQUEST";
        private const string FieldCONST_ACTUALWORK = "CONST_ACTUALWORK";
        private const string FieldCONST_MSGBOX_TITLE = "CONST_MSGBOX_TITLE";
        private const string FieldCONST_text_Commitment = "CONST_text_Commitment";
        private const string FieldCONST_text_Request = "CONST_text_Request";
        private const string FieldCONST_text_NW = "CONST_text_NW";
        private const string FieldCONST_text_MSPF = "CONST_text_MSPF";
        private const string FieldCONST_text_ACTUALWORK = "CONST_text_ACTUALWORK";
        private const string FieldCONST_text_OpenRequire = "CONST_text_OpenRequire";
        private const string FieldCONST_DEPT = "CONST_DEPT";
        private const string FieldCONST_ROLE = "CONST_ROLE";
        private const string FieldCONST_RESOURCE = "CONST_RESOURCE";
        private const string FieldCONST_GROUPING = "CONST_GROUPING";
        private const string FieldCONST_ITEM = "CONST_ITEM";
        private const string FieldCONST_ROWTYPE = "CONST_ROWTYPE";
        private const string FieldCONST_START = "CONST_START";
        private const string FieldCONST_FINISH = "CONST_FINISH";
        private const string FieldCONST_POWNER = "CONST_POWNER";
        private const string FieldCONST_STAGE = "CONST_STAGE";
        private const string FieldCONST_SOWNER = "CONST_SOWNER";
        private const string FieldCONST_CSDATE = "CONST_CSDATE";
        private const string FieldCONST_CFDATE = "CONST_CFDATE";
        private const string FieldCONST_CRATE = "CONST_CRATE";
        private const string FieldCONST_CCOST = "CONST_CCOST";
        private const string FieldCONST_CRTYPE = "CONST_CRTYPE";
        private const string FieldCONST_PLANID = "CONST_PLANID";
        private const string FieldCONST_PLANGRP = "CONST_PLANGRP";
        private const string FieldCONST_PRIORITY = "CONST_PRIORITY";
        private const string FieldCONST_ROWCC = "CONST_ROWCC";
        private const string FieldCONST_ROWCCFULL = "CONST_ROWCCFULL";
        private const string FieldCONST_ROWCCROLE = "CONST_ROWCCROLE";
        private const string FieldCONST_ROWCCROLEFULL = "CONST_ROWCCROLEFULL";
        private const string FieldCONST_ROWMAJORCAT = "CONST_ROWMAJORCAT";
        private const string FieldCONST_ROWFULLCATROLE = "CONST_ROWFULLCATROLE";
        private const string FieldCONST_ROWGENERIC = "CONST_ROWGENERIC";
        private const string FieldCONST_BMODE_TOT_HRS = "CONST_BMODE_TOT_HRS";
        private const string FieldCONST_BMODE_TOT_HRS_CAPACITY = "CONST_BMODE_TOT_HRS_CAPACITY";
        private const string FieldCONST_BMODE_CAPACITY = "CONST_BMODE_CAPACITY";
        private const string FieldCONST_BMODE_REM_CAPACITY = "CONST_BMODE_REM_CAPACITY";
        private const string FieldCONST_BMODE_FTE = "CONST_BMODE_FTE";
        private const string FieldCONST_BMODE_FTE_PERCENT = "CONST_BMODE_FTE_PERCENT";
        private const string FieldCONST_BMODE_TOT_SND = "CONST_BMODE_TOT_SND";
        private const string FieldCONST_BMODE_TOT_S = "CONST_BMODE_TOT_S";
        private const string FieldCONST_BMODE_TOT_D = "CONST_BMODE_TOT_D";
        private const string FieldCONST_BMODE_TOT_R = "CONST_BMODE_TOT_R";
        private const string FieldTGRID_MAXCOLS = "TGRID_MAXCOLS";
        private const string FieldTGRID_CHECKCOL = "TGRID_CHECKCOL";
        private const string FieldTGRID_GRP_ID = "TGRID_GRP_ID";
        private const string FieldTGRID_ITEM_ID = "TGRID_ITEM_ID";
        private const string FieldTGRID_RES_ID = "TGRID_RES_ID";
        private const string FieldTGRID_STAT_ID = "TGRID_STAT_ID";
        private const string FieldTGRID_DEPT_ID = "TGRID_DEPT_ID";
        private const string FieldTGRID_ROLE_ID = "TGRID_ROLE_ID";
        private const string FieldTGRID_CC_ID = "TGRID_CC_ID";
        private const string FieldTGRID_CCFULL_ID = "TGRID_CCFULL_ID";
        private const string FieldTGRID_CCROLE_ID = "TGRID_CCROLE_ID";
        private const string FieldTGRID_CCROLEFULL_ID = "TGRID_CCROLEFULL_ID";
        private const string FieldTGRID_SDATE = "TGRID_SDATE";
        private const string FieldTGRID_FDATE = "TGRID_FDATE";
        private const string FieldTGRID_OWNER = "TGRID_OWNER";
        private const string FieldTGRID_STAGE = "TGRID_STAGE";
        private const string FieldTGRID_STAGE_OWNER = "TGRID_STAGE_OWNER";
        private const string FieldTGRID_CSDATE = "TGRID_CSDATE";
        private const string FieldTGRID_CFDATE = "TGRID_CFDATE";
        private const string FieldTGRID_CRATE = "TGRID_CRATE";
        private const string FieldTGRID_CCOST = "TGRID_CCOST";
        private const string FieldTGRID_CRTYPE = "TGRID_CRTYPE";
        private const string FieldTGRID_PLANID = "TGRID_PLANID";
        private const string FieldTGRID_PRIORITY = "TGRID_PRIORITY";
        private const string FieldTGRID_PLANGRP = "TGRID_PLANGRP";
        private const string FieldTGRID_MAJCAT = "TGRID_MAJCAT";
        private const string FieldTGRID_FROLL = "TGRID_FROLL";
        private const string FieldTGRID_GENERIC = "TGRID_GENERIC";
        private const string FieldCONST_TOP_FIXED_FIELDS = "CONST_TOP_FIXED_FIELDS";
        private const string FieldTGRID_TOTDEPT_ID = "TGRID_TOTDEPT_ID";
        private const string FieldTGRID_TOTRESRES_ID = "TGRID_TOTRESRES_ID";
        private const string FieldTGRID_TOTROLE_ID = "TGRID_TOTROLE_ID";
        private const string FieldTGRID_TOTCC_ID = "TGRID_TOTCC_ID";
        private const string FieldTGRID_TOTCCFULL_ID = "TGRID_TOTCCFULL_ID";
        private const string FieldTGRID_TOTITEM_ID = "TGRID_TOTITEM_ID";
        private const string FieldCONST_SORT_ASCENDING = "CONST_SORT_ASCENDING";
        private const string FieldCONST_SORT_DESCENDING = "CONST_SORT_DESCENDING";
        private const string FieldConstRawAvail = "ConstRawAvail";
        private const string FieldConstRawForecast = "ConstRawForecast";
        private const string FieldConstNone = "ConstNone";
        private Type _rPConstantsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (RPConstants) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RPConstants" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rPConstantsInstanceType = typeof(RPConstants);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RPConstants)

        #region General Initializer : Class (RPConstants) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="RPConstants" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodStripNum, 0)]
        [TestCase(MethodGetCustValue, 0)]
        public void AUT_RPConstants_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RPConstants) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RPConstants" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldCONST_Commitment)]
        [TestCase(FieldCONST_Offer)]
        [TestCase(FieldCONST_REQUEST)]
        [TestCase(FieldCONST_Pending)]
        [TestCase(FieldCONST_NW)]
        [TestCase(FieldCONST_MSPF)]
        [TestCase(FieldCONST_REQUIRE)]
        [TestCase(FieldCONST_OPENREQUEST)]
        [TestCase(FieldCONST_ACTUALWORK)]
        [TestCase(FieldCONST_MSGBOX_TITLE)]
        [TestCase(FieldCONST_text_Commitment)]
        [TestCase(FieldCONST_text_Request)]
        [TestCase(FieldCONST_text_NW)]
        [TestCase(FieldCONST_text_MSPF)]
        [TestCase(FieldCONST_text_ACTUALWORK)]
        [TestCase(FieldCONST_text_OpenRequire)]
        [TestCase(FieldCONST_DEPT)]
        [TestCase(FieldCONST_ROLE)]
        [TestCase(FieldCONST_RESOURCE)]
        [TestCase(FieldCONST_GROUPING)]
        [TestCase(FieldCONST_ITEM)]
        [TestCase(FieldCONST_ROWTYPE)]
        [TestCase(FieldCONST_START)]
        [TestCase(FieldCONST_FINISH)]
        [TestCase(FieldCONST_POWNER)]
        [TestCase(FieldCONST_STAGE)]
        [TestCase(FieldCONST_SOWNER)]
        [TestCase(FieldCONST_CSDATE)]
        [TestCase(FieldCONST_CFDATE)]
        [TestCase(FieldCONST_CRATE)]
        [TestCase(FieldCONST_CCOST)]
        [TestCase(FieldCONST_CRTYPE)]
        [TestCase(FieldCONST_PLANID)]
        [TestCase(FieldCONST_PLANGRP)]
        [TestCase(FieldCONST_PRIORITY)]
        [TestCase(FieldCONST_ROWCC)]
        [TestCase(FieldCONST_ROWCCFULL)]
        [TestCase(FieldCONST_ROWCCROLE)]
        [TestCase(FieldCONST_ROWCCROLEFULL)]
        [TestCase(FieldCONST_ROWMAJORCAT)]
        [TestCase(FieldCONST_ROWFULLCATROLE)]
        [TestCase(FieldCONST_ROWGENERIC)]
        [TestCase(FieldCONST_BMODE_TOT_HRS)]
        [TestCase(FieldCONST_BMODE_TOT_HRS_CAPACITY)]
        [TestCase(FieldCONST_BMODE_CAPACITY)]
        [TestCase(FieldCONST_BMODE_REM_CAPACITY)]
        [TestCase(FieldCONST_BMODE_FTE)]
        [TestCase(FieldCONST_BMODE_FTE_PERCENT)]
        [TestCase(FieldCONST_BMODE_TOT_SND)]
        [TestCase(FieldCONST_BMODE_TOT_S)]
        [TestCase(FieldCONST_BMODE_TOT_D)]
        [TestCase(FieldCONST_BMODE_TOT_R)]
        [TestCase(FieldTGRID_MAXCOLS)]
        [TestCase(FieldTGRID_CHECKCOL)]
        [TestCase(FieldTGRID_GRP_ID)]
        [TestCase(FieldTGRID_ITEM_ID)]
        [TestCase(FieldTGRID_RES_ID)]
        [TestCase(FieldTGRID_STAT_ID)]
        [TestCase(FieldTGRID_DEPT_ID)]
        [TestCase(FieldTGRID_ROLE_ID)]
        [TestCase(FieldTGRID_CC_ID)]
        [TestCase(FieldTGRID_CCFULL_ID)]
        [TestCase(FieldTGRID_CCROLE_ID)]
        [TestCase(FieldTGRID_CCROLEFULL_ID)]
        [TestCase(FieldTGRID_SDATE)]
        [TestCase(FieldTGRID_FDATE)]
        [TestCase(FieldTGRID_OWNER)]
        [TestCase(FieldTGRID_STAGE)]
        [TestCase(FieldTGRID_STAGE_OWNER)]
        [TestCase(FieldTGRID_CSDATE)]
        [TestCase(FieldTGRID_CFDATE)]
        [TestCase(FieldTGRID_CRATE)]
        [TestCase(FieldTGRID_CCOST)]
        [TestCase(FieldTGRID_CRTYPE)]
        [TestCase(FieldTGRID_PLANID)]
        [TestCase(FieldTGRID_PRIORITY)]
        [TestCase(FieldTGRID_PLANGRP)]
        [TestCase(FieldTGRID_MAJCAT)]
        [TestCase(FieldTGRID_FROLL)]
        [TestCase(FieldTGRID_GENERIC)]
        [TestCase(FieldCONST_TOP_FIXED_FIELDS)]
        [TestCase(FieldTGRID_TOTDEPT_ID)]
        [TestCase(FieldTGRID_TOTRESRES_ID)]
        [TestCase(FieldTGRID_TOTROLE_ID)]
        [TestCase(FieldTGRID_TOTCC_ID)]
        [TestCase(FieldTGRID_TOTCCFULL_ID)]
        [TestCase(FieldTGRID_TOTITEM_ID)]
        [TestCase(FieldCONST_SORT_ASCENDING)]
        [TestCase(FieldCONST_SORT_DESCENDING)]
        [TestCase(FieldConstRawAvail)]
        [TestCase(FieldConstRawForecast)]
        [TestCase(FieldConstNone)]
        public void AUT_RPConstants_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="RPConstants" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RPConstants_Is_Static_Type_Present_Test()
        {
            // Assert
            _rPConstantsInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="RPConstants" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodStripNum)]
        [TestCase(MethodGetCustValue)]
        public void AUT_RPConstants_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _rPConstantsInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPConstants_StripNum_Static_Method_Call_Internally(Type[] types)
        {
            var methodStripNumPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _rPConstantsInstanceType, MethodStripNum, Fixture, methodStripNumPrametersTypes);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPConstants_StripNum_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => RPConstants.StripNum(ref sin);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPConstants_StripNum_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfStripNum);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPConstants_StripNum_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(null, _rPConstantsInstanceType, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPConstants_StripNum_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _rPConstantsInstanceType, MethodStripNum, Fixture, methodStripNumPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStripNumPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPConstants_StripNum_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStripNum, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPConstants_StripNum_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStripNum, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCustValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_RPConstants_GetCustValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCustValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _rPConstantsInstanceType, MethodGetCustValue, Fixture, methodGetCustValuePrametersTypes);
        }

        #endregion
        
        #region Method Call : (GetCustValue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPConstants_GetCustValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCustValue, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (GetCustValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_RPConstants_GetCustValue_Static_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCustValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}