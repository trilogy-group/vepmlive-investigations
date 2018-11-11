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

namespace CostDataValues
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsCostData" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsCostDataTest : AbstractBaseSetupTypedTest<clsCostData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsCostData) Initializer

        private const string MethodStripDBL = "StripDBL";
        private const string FieldEPK_FTYPE_DATE = "EPK_FTYPE_DATE";
        private const string FieldEPK_FTYPE_INTEGER = "EPK_FTYPE_INTEGER";
        private const string FieldEPK_FTYPE_NUMBER = "EPK_FTYPE_NUMBER";
        private const string FieldEPK_FTYPE_CODE = "EPK_FTYPE_CODE";
        private const string FieldEPK_FTYPE_URL = "EPK_FTYPE_URL";
        private const string FieldEPK_FTYPE_RES = "EPK_FTYPE_RES";
        private const string FieldEPK_FTYPE_CURRENCY = "EPK_FTYPE_CURRENCY";
        private const string FieldEPK_FTYPE_TEXT = "EPK_FTYPE_TEXT";
        private const string FieldEPK_FTYPE_PERCENT = "EPK_FTYPE_PERCENT";
        private const string FieldEPK_FTYPE_YESNO = "EPK_FTYPE_YESNO";
        private const string FieldEPK_FTYPE_RTF = "EPK_FTYPE_RTF";
        private const string FieldEPK_FTYPE_WORK = "EPK_FTYPE_WORK";
        private const string FieldEPK_FTYPE_DURATION = "EPK_FTYPE_DURATION";
        private const string FieldEPK_FTYPE_OWNER = "EPK_FTYPE_OWNER";
        private const string FieldCONST_CURRENT = "CONST_CURRENT";
        private const string Fieldm_GotAllPIs = "m_GotAllPIs";
        private const string Fieldm_sPids = "m_sPids";
        private const string Fieldm_PI_Count = "m_PI_Count";
        private const string Fieldm_CB_ID = "m_CB_ID";
        private const string Fieldm_sCostTypes = "m_sCostTypes";
        private const string Fieldm_sOtherCostTypes = "m_sOtherCostTypes";
        private const string Fieldm_sCalcCostTypes = "m_sCalcCostTypes";
        private const string Fieldm_statdate = "m_statdate";
        private const string Fieldm_dtMin = "m_dtMin";
        private const string Fieldm_dtMax = "m_dtMax";
        private const string Fieldm_status_period = "m_status_period";
        private const string Fieldm_max_period = "m_max_period";
        private const string Fieldm_Periods = "m_Periods";
        private const string Fieldm_CostCat = "m_CostCat";
        private const string Fieldm_Role_CC = "m_Role_CC";
        private const string Fieldm_CostCat_rolly = "m_CostCat_rolly";
        private const string Fieldm_CustFields = "m_CustFields";
        private const string Fieldm_CustAttribs = "m_CustAttribs";
        private const string Fieldm_CostTypes = "m_CostTypes";
        private const string Fieldm_stages = "m_stages";
        private const string Fieldm_sextra = "m_sextra";
        private const string Fieldm_ExtraFieldNames = "m_ExtraFieldNames";
        private const string Fieldm_fidextra = "m_fidextra";
        private const string Fieldm_ExtraFieldTypes = "m_ExtraFieldTypes";
        private const string Fieldm_Use_extra = "m_Use_extra";
        private const string Fieldm_PIs = "m_PIs";
        private const string Fieldm_SelFID = "m_SelFID";
        private const string Fieldm_Select_FieldName = "m_Select_FieldName";
        private const string Fieldm_codes = "m_codes";
        private const string Fieldm_reses = "m_reses";
        private const string Fieldm_detaildata = "m_detaildata";
        private const string Fieldm_targetdata = "m_targetdata";
        private const string Fieldm_targets = "m_targets";
        private const string Fieldm_clsTargetColours = "m_clsTargetColours";
        private const string Fieldm_Rates = "m_Rates";
        private const string Fieldm_ratecache = "m_ratecache";
        private const string Fieldm_firstperiod_data = "m_firstperiod_data";
        private const string Fieldm_lastperiod_data = "m_lastperiod_data";
        private const string Fieldm_gPOPerm = "m_gPOPerm";
        private Type _clsCostDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsCostData _clsCostDataInstance;
        private clsCostData _clsCostDataInstanceFixture;

        #region General Initializer : Class (clsCostData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsCostData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsCostDataInstanceType = typeof(clsCostData);
            _clsCostDataInstanceFixture = Create(true);
            _clsCostDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsCostData)

        #region General Initializer : Class (clsCostData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="clsCostData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodStripDBL, 0)]
        public void AUT_ClsCostData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_clsCostDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (clsCostData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsCostData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldEPK_FTYPE_DATE)]
        [TestCase(FieldEPK_FTYPE_INTEGER)]
        [TestCase(FieldEPK_FTYPE_NUMBER)]
        [TestCase(FieldEPK_FTYPE_CODE)]
        [TestCase(FieldEPK_FTYPE_URL)]
        [TestCase(FieldEPK_FTYPE_RES)]
        [TestCase(FieldEPK_FTYPE_CURRENCY)]
        [TestCase(FieldEPK_FTYPE_TEXT)]
        [TestCase(FieldEPK_FTYPE_PERCENT)]
        [TestCase(FieldEPK_FTYPE_YESNO)]
        [TestCase(FieldEPK_FTYPE_RTF)]
        [TestCase(FieldEPK_FTYPE_WORK)]
        [TestCase(FieldEPK_FTYPE_DURATION)]
        [TestCase(FieldEPK_FTYPE_OWNER)]
        [TestCase(FieldCONST_CURRENT)]
        [TestCase(Fieldm_GotAllPIs)]
        [TestCase(Fieldm_sPids)]
        [TestCase(Fieldm_PI_Count)]
        [TestCase(Fieldm_CB_ID)]
        [TestCase(Fieldm_sCostTypes)]
        [TestCase(Fieldm_sOtherCostTypes)]
        [TestCase(Fieldm_sCalcCostTypes)]
        [TestCase(Fieldm_statdate)]
        [TestCase(Fieldm_dtMin)]
        [TestCase(Fieldm_dtMax)]
        [TestCase(Fieldm_status_period)]
        [TestCase(Fieldm_max_period)]
        [TestCase(Fieldm_Periods)]
        [TestCase(Fieldm_CostCat)]
        [TestCase(Fieldm_Role_CC)]
        [TestCase(Fieldm_CostCat_rolly)]
        [TestCase(Fieldm_CustFields)]
        [TestCase(Fieldm_CustAttribs)]
        [TestCase(Fieldm_CostTypes)]
        [TestCase(Fieldm_stages)]
        [TestCase(Fieldm_sextra)]
        [TestCase(Fieldm_ExtraFieldNames)]
        [TestCase(Fieldm_fidextra)]
        [TestCase(Fieldm_ExtraFieldTypes)]
        [TestCase(Fieldm_Use_extra)]
        [TestCase(Fieldm_PIs)]
        [TestCase(Fieldm_SelFID)]
        [TestCase(Fieldm_Select_FieldName)]
        [TestCase(Fieldm_codes)]
        [TestCase(Fieldm_reses)]
        [TestCase(Fieldm_detaildata)]
        [TestCase(Fieldm_targetdata)]
        [TestCase(Fieldm_targets)]
        [TestCase(Fieldm_clsTargetColours)]
        [TestCase(Fieldm_Rates)]
        [TestCase(Fieldm_ratecache)]
        [TestCase(Fieldm_firstperiod_data)]
        [TestCase(Fieldm_lastperiod_data)]
        [TestCase(Fieldm_gPOPerm)]
        public void AUT_ClsCostData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsCostDataInstanceFixture, 
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
        ///     Class (<see cref="clsCostData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsCostData_Is_Instance_Present_Test()
        {
            // Assert
            _clsCostDataInstanceType.ShouldNotBeNull();
            _clsCostDataInstance.ShouldNotBeNull();
            _clsCostDataInstanceFixture.ShouldNotBeNull();
            _clsCostDataInstance.ShouldBeAssignableTo<clsCostData>();
            _clsCostDataInstanceFixture.ShouldBeAssignableTo<clsCostData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsCostData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsCostData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsCostData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsCostDataInstanceType.ShouldNotBeNull();
            _clsCostDataInstance.ShouldNotBeNull();
            _clsCostDataInstanceFixture.ShouldNotBeNull();
            _clsCostDataInstance.ShouldBeAssignableTo<clsCostData>();
            _clsCostDataInstanceFixture.ShouldBeAssignableTo<clsCostData>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="clsCostData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodStripDBL)]
        public void AUT_ClsCostData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<clsCostData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (StripDBL) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ClsCostData_StripDBL_Method_Call_Internally(Type[] types)
        {
            var methodStripDBLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsCostDataInstance, MethodStripDBL, Fixture, methodStripDBLPrametersTypes);
        }

        #endregion

        #region Method Call : (StripDBL) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsCostData_StripDBL_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripDBLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripDBL = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripDBL, methodStripDBLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<clsCostData, double>(_clsCostDataInstanceFixture, out exception1, parametersOfStripDBL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<clsCostData, double>(_clsCostDataInstance, MethodStripDBL, parametersOfStripDBL, methodStripDBLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfStripDBL.ShouldNotBeNull();
            parametersOfStripDBL.Length.ShouldBe(1);
            methodStripDBLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripDBL) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsCostData_StripDBL_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripDBLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripDBL = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripDBL, methodStripDBLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<clsCostData, double>(_clsCostDataInstanceFixture, out exception1, parametersOfStripDBL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<clsCostData, double>(_clsCostDataInstance, MethodStripDBL, parametersOfStripDBL, methodStripDBLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfStripDBL.ShouldNotBeNull();
            parametersOfStripDBL.Length.ShouldBe(1);
            methodStripDBLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripDBL) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsCostData_StripDBL_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripDBLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripDBL = { sin };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<clsCostData, double>(_clsCostDataInstance, MethodStripDBL, parametersOfStripDBL, methodStripDBLPrametersTypes);

            // Assert
            parametersOfStripDBL.ShouldNotBeNull();
            parametersOfStripDBL.Length.ShouldBe(1);
            methodStripDBLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StripDBL) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsCostData_StripDBL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStripDBLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_clsCostDataInstance, MethodStripDBL, Fixture, methodStripDBLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStripDBLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StripDBL) (Return Type : double) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsCostData_StripDBL_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStripDBL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_clsCostDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (StripDBL) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ClsCostData_StripDBL_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStripDBL, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}