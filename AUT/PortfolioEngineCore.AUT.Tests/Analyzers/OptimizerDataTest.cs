using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.OptimizerData" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
	[ExcludeFromCodeCoverage]
    public class OptimizerDataTest : AbstractBaseSetupTypedTest<OptimizerData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (OptimizerData) Initializer

        private const string MethodGrabPidsFromTicket = "GrabPidsFromTicket";
        private const string MethodOptimizerLoadData = "OptimizerLoadData";
        private const string MethodGetOptimizerViewsXML = "GetOptimizerViewsXML";
        private const string MethodGetOptimizerViewXML = "GetOptimizerViewXML";
        private const string MethodSaveOptimizerViewXML = "SaveOptimizerViewXML";
        private const string MethodDeleteOptimizerViewXML = "DeleteOptimizerViewXML";
        private const string MethodRenameOptimizerViewXML = "RenameOptimizerViewXML";
        private const string MethodGetOptimizerStratagiesXML = "GetOptimizerStratagiesXML";
        private const string MethodGetOptimizerStratagyXML = "GetOptimizerStratagyXML";
        private const string MethodSaveOptimizerStratagyXML = "SaveOptimizerStratagyXML";
        private const string MethodDeleteOptimizerStratagyXML = "DeleteOptimizerStratagyXML";
        private const string MethodRenameOptimizerStratagyXML = "RenameOptimizerStratagyXML";
        private const string MethodCommitOptimizerStratagy = "CommitOptimizerStratagy";
        private const string MethodReadCurrencySettings = "ReadCurrencySettings";
        private const string MethodReadStages = "ReadStages";
        private const string MethodReadExtraPifields = "ReadExtraPifields";
        private const string MethodReadFieldDataFieldId = "ReadFieldDataFieldId";
        private const string MethodReadFieldDataFieldName = "ReadFieldDataFieldName";
        private const string MethodReadFieldDataFieldFormat = "ReadFieldDataFieldFormat";
        private const string MethodReadFieldDataSExtra = "ReadFieldDataSExtra";
        private const string MethodReadPILevelData = "ReadPILevelData";
        private const string MethodGetCFFieldName = "GetCFFieldName";
        private const string MethodMyFormat = "MyFormat";
        private const string MethodFormatExportExtraData = "FormatExportExtraData";
        private const string MethodOptimizeThisType = "OptimizeThisType";
        private const string MethodStripNum = "StripNum";
        private const string MethodFormatSQLDateTime = "FormatSQLDateTime";
        private const string FieldMAX_PI_EXTRA = "MAX_PI_EXTRA";
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
        private const string Field_sqlConnection = "_sqlConnection";
        private const string Fieldm_stages = "m_stages";
        private const string Fieldm_PIs = "m_PIs";
        private const string Fieldm_reses = "m_reses";
        private const string Fieldm_codes = "m_codes";
        private const string Fieldm_SelFID = "m_SelFID";
        private const string Fieldm_Select_FieldName = "m_Select_FieldName";
        private const string Fieldm_sextra = "m_sextra";
        private const string Fieldm_ExtraFieldNames = "m_ExtraFieldNames";
        private const string Fieldm_fidextra = "m_fidextra";
        private const string Fieldm_ExtraFieldTypes = "m_ExtraFieldTypes";
        private const string Fieldm_Use_extra = "m_Use_extra";
        private const string Fieldm_curr_pos = "m_curr_pos";
        private const string Fieldm_curr_digits = "m_curr_digits";
        private const string Fieldm_curr_sym = "m_curr_sym";
        private Type _optimizerDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private OptimizerData _optimizerDataInstance;
        private OptimizerData _optimizerDataInstanceFixture;

        #region General Initializer : Class (OptimizerData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="OptimizerData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _optimizerDataInstanceType = typeof(OptimizerData);
            _optimizerDataInstanceFixture = Create(true);
            _optimizerDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (OptimizerData)

        #region General Initializer : Class (OptimizerData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="OptimizerData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldMAX_PI_EXTRA)]
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
        [TestCase(Field_sqlConnection)]
        [TestCase(Fieldm_stages)]
        [TestCase(Fieldm_PIs)]
        [TestCase(Fieldm_reses)]
        [TestCase(Fieldm_codes)]
        [TestCase(Fieldm_SelFID)]
        [TestCase(Fieldm_Select_FieldName)]
        [TestCase(Fieldm_sextra)]
        [TestCase(Fieldm_ExtraFieldNames)]
        [TestCase(Fieldm_fidextra)]
        [TestCase(Fieldm_ExtraFieldTypes)]
        [TestCase(Fieldm_Use_extra)]
        [TestCase(Fieldm_curr_pos)]
        [TestCase(Fieldm_curr_digits)]
        [TestCase(Fieldm_curr_sym)]
        public void AUT_OptimizerData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_optimizerDataInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (OptimizerData) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="OptimizerData" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_OptimizerData_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<OptimizerData>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (OptimizerData) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="OptimizerData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_OptimizerData_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<OptimizerData>(Fixture);
        }

        #endregion

        #region General Constructor : Class (OptimizerData) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="OptimizerData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_OptimizerData_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfOptimizerData = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodOptimizerDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_optimizerDataInstanceType, methodOptimizerDataPrametersTypes, parametersOfOptimizerData);
        }

        #endregion

        #region General Constructor : Class (OptimizerData) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="OptimizerData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_OptimizerData_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodOptimizerDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_optimizerDataInstanceType, Fixture, methodOptimizerDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (OptimizerData) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="OptimizerData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_OptimizerData_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            object[] parametersOfOptimizerData = { sBaseInfo };
            var methodOptimizerDataPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_optimizerDataInstanceType, methodOptimizerDataPrametersTypes, parametersOfOptimizerData);
        }

        #endregion

        #region General Constructor : Class (OptimizerData) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="OptimizerData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_OptimizerData_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodOptimizerDataPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_optimizerDataInstanceType, Fixture, methodOptimizerDataPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="OptimizerData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGrabPidsFromTicket)]
        [TestCase(MethodOptimizerLoadData)]
        [TestCase(MethodGetOptimizerViewsXML)]
        [TestCase(MethodGetOptimizerViewXML)]
        [TestCase(MethodSaveOptimizerViewXML)]
        [TestCase(MethodDeleteOptimizerViewXML)]
        [TestCase(MethodRenameOptimizerViewXML)]
        [TestCase(MethodGetOptimizerStratagiesXML)]
        [TestCase(MethodGetOptimizerStratagyXML)]
        [TestCase(MethodSaveOptimizerStratagyXML)]
        [TestCase(MethodDeleteOptimizerStratagyXML)]
        [TestCase(MethodRenameOptimizerStratagyXML)]
        [TestCase(MethodCommitOptimizerStratagy)]
        [TestCase(MethodReadCurrencySettings)]
        [TestCase(MethodReadStages)]
        [TestCase(MethodReadExtraPifields)]
        [TestCase(MethodReadPILevelData)]
        [TestCase(MethodMyFormat)]
        [TestCase(MethodFormatExportExtraData)]
        [TestCase(MethodOptimizeThisType)]
        [TestCase(MethodStripNum)]
        [TestCase(MethodFormatSQLDateTime)]
        public void AUT_OptimizerData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<OptimizerData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GrabPidsFromTicket) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_GrabPidsFromTicket_Method_Call_Internally(Type[] types)
        {
            var methodGrabPidsFromTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGrabPidsFromTicket, Fixture, methodGrabPidsFromTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (GrabPidsFromTicket) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GrabPidsFromTicket_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ticket = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.GrabPidsFromTicket(ticket);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GrabPidsFromTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GrabPidsFromTicket_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ticket = CreateType<string>();
            var methodGrabPidsFromTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGrabPidsFromTicket = { ticket };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGrabPidsFromTicket, methodGrabPidsFromTicketPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, string>(_optimizerDataInstanceFixture, out exception1, parametersOfGrabPidsFromTicket);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, string>(_optimizerDataInstance, MethodGrabPidsFromTicket, parametersOfGrabPidsFromTicket, methodGrabPidsFromTicketPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGrabPidsFromTicket.ShouldNotBeNull();
            parametersOfGrabPidsFromTicket.Length.ShouldBe(1);
            methodGrabPidsFromTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GrabPidsFromTicket) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GrabPidsFromTicket_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ticket = CreateType<string>();
            var methodGrabPidsFromTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGrabPidsFromTicket = { ticket };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, string>(_optimizerDataInstance, MethodGrabPidsFromTicket, parametersOfGrabPidsFromTicket, methodGrabPidsFromTicketPrametersTypes);

            // Assert
            parametersOfGrabPidsFromTicket.ShouldNotBeNull();
            parametersOfGrabPidsFromTicket.Length.ShouldBe(1);
            methodGrabPidsFromTicketPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabPidsFromTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GrabPidsFromTicket_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGrabPidsFromTicketPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGrabPidsFromTicket, Fixture, methodGrabPidsFromTicketPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGrabPidsFromTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GrabPidsFromTicket) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GrabPidsFromTicket_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGrabPidsFromTicketPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGrabPidsFromTicket, Fixture, methodGrabPidsFromTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGrabPidsFromTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabPidsFromTicket) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GrabPidsFromTicket_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrabPidsFromTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GrabPidsFromTicket) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GrabPidsFromTicket_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGrabPidsFromTicket, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OptimizerLoadData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_OptimizerLoadData_Method_Call_Internally(Type[] types)
        {
            var methodOptimizerLoadDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodOptimizerLoadData, Fixture, methodOptimizerLoadDataPrametersTypes);
        }

        #endregion

        #region Method Call : (OptimizerLoadData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizerLoadData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sPIListIn = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.OptimizerLoadData(sPIListIn);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (OptimizerLoadData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizerLoadData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sPIListIn = CreateType<string>();
            var methodOptimizerLoadDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfOptimizerLoadData = { sPIListIn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodOptimizerLoadData, methodOptimizerLoadDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, string>(_optimizerDataInstanceFixture, out exception1, parametersOfOptimizerLoadData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, string>(_optimizerDataInstance, MethodOptimizerLoadData, parametersOfOptimizerLoadData, methodOptimizerLoadDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfOptimizerLoadData.ShouldNotBeNull();
            parametersOfOptimizerLoadData.Length.ShouldBe(1);
            methodOptimizerLoadDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (OptimizerLoadData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizerLoadData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sPIListIn = CreateType<string>();
            var methodOptimizerLoadDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfOptimizerLoadData = { sPIListIn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, string>(_optimizerDataInstance, MethodOptimizerLoadData, parametersOfOptimizerLoadData, methodOptimizerLoadDataPrametersTypes);

            // Assert
            parametersOfOptimizerLoadData.ShouldNotBeNull();
            parametersOfOptimizerLoadData.Length.ShouldBe(1);
            methodOptimizerLoadDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OptimizerLoadData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizerLoadData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodOptimizerLoadDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodOptimizerLoadData, Fixture, methodOptimizerLoadDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodOptimizerLoadDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (OptimizerLoadData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizerLoadData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOptimizerLoadDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodOptimizerLoadData, Fixture, methodOptimizerLoadDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodOptimizerLoadDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OptimizerLoadData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizerLoadData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOptimizerLoadData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (OptimizerLoadData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizerLoadData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOptimizerLoadData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOptimizerViewsXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_GetOptimizerViewsXML_Method_Call_Internally(Type[] types)
        {
            var methodGetOptimizerViewsXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGetOptimizerViewsXML, Fixture, methodGetOptimizerViewsXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetOptimizerViewsXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewsXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.GetOptimizerViewsXML(out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetOptimizerViewsXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewsXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetOptimizerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetOptimizerViewsXML = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOptimizerViewsXML, methodGetOptimizerViewsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfGetOptimizerViewsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerViewsXML, parametersOfGetOptimizerViewsXML, methodGetOptimizerViewsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetOptimizerViewsXML.ShouldNotBeNull();
            parametersOfGetOptimizerViewsXML.Length.ShouldBe(1);
            methodGetOptimizerViewsXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetOptimizerViewsXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewsXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetOptimizerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetOptimizerViewsXML = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOptimizerViewsXML, methodGetOptimizerViewsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfGetOptimizerViewsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerViewsXML, parametersOfGetOptimizerViewsXML, methodGetOptimizerViewsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetOptimizerViewsXML.ShouldNotBeNull();
            parametersOfGetOptimizerViewsXML.Length.ShouldBe(1);
            methodGetOptimizerViewsXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetOptimizerViewsXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewsXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetOptimizerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetOptimizerViewsXML = { sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerViewsXML, parametersOfGetOptimizerViewsXML, methodGetOptimizerViewsXMLPrametersTypes);

            // Assert
            parametersOfGetOptimizerViewsXML.ShouldNotBeNull();
            parametersOfGetOptimizerViewsXML.Length.ShouldBe(1);
            methodGetOptimizerViewsXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOptimizerViewsXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewsXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetOptimizerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGetOptimizerViewsXML, Fixture, methodGetOptimizerViewsXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetOptimizerViewsXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOptimizerViewsXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewsXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOptimizerViewsXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptimizerViewsXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewsXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetOptimizerViewsXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOptimizerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_GetOptimizerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodGetOptimizerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGetOptimizerViewXML, Fixture, methodGetOptimizerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetOptimizerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.GetOptimizerViewXML(guidView, out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetOptimizerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetOptimizerViewXML = { guidView, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOptimizerViewXML, methodGetOptimizerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfGetOptimizerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerViewXML, parametersOfGetOptimizerViewXML, methodGetOptimizerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetOptimizerViewXML.ShouldNotBeNull();
            parametersOfGetOptimizerViewXML.Length.ShouldBe(2);
            methodGetOptimizerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetOptimizerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetOptimizerViewXML = { guidView, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOptimizerViewXML, methodGetOptimizerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfGetOptimizerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerViewXML, parametersOfGetOptimizerViewXML, methodGetOptimizerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetOptimizerViewXML.ShouldNotBeNull();
            parametersOfGetOptimizerViewXML.Length.ShouldBe(2);
            methodGetOptimizerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetOptimizerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetOptimizerViewXML = { guidView, sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerViewXML, parametersOfGetOptimizerViewXML, methodGetOptimizerViewXMLPrametersTypes);

            // Assert
            parametersOfGetOptimizerViewXML.ShouldNotBeNull();
            parametersOfGetOptimizerViewXML.Length.ShouldBe(2);
            methodGetOptimizerViewXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOptimizerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGetOptimizerViewXML, Fixture, methodGetOptimizerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetOptimizerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOptimizerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOptimizerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptimizerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetOptimizerViewXML, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveOptimizerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_SaveOptimizerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodSaveOptimizerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodSaveOptimizerViewXML, Fixture, methodSaveOptimizerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveOptimizerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.SaveOptimizerViewXML(guidView, sName, bPersonal, bDefault, sData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveOptimizerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveOptimizerViewXML = { guidView, sName, bPersonal, bDefault, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveOptimizerViewXML, methodSaveOptimizerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfSaveOptimizerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodSaveOptimizerViewXML, parametersOfSaveOptimizerViewXML, methodSaveOptimizerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveOptimizerViewXML.ShouldNotBeNull();
            parametersOfSaveOptimizerViewXML.Length.ShouldBe(5);
            methodSaveOptimizerViewXMLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveOptimizerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveOptimizerViewXML = { guidView, sName, bPersonal, bDefault, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveOptimizerViewXML, methodSaveOptimizerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfSaveOptimizerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodSaveOptimizerViewXML, parametersOfSaveOptimizerViewXML, methodSaveOptimizerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveOptimizerViewXML.ShouldNotBeNull();
            parametersOfSaveOptimizerViewXML.Length.ShouldBe(5);
            methodSaveOptimizerViewXMLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveOptimizerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveOptimizerViewXML = { guidView, sName, bPersonal, bDefault, sData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodSaveOptimizerViewXML, parametersOfSaveOptimizerViewXML, methodSaveOptimizerViewXMLPrametersTypes);

            // Assert
            parametersOfSaveOptimizerViewXML.ShouldNotBeNull();
            parametersOfSaveOptimizerViewXML.Length.ShouldBe(5);
            methodSaveOptimizerViewXMLPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveOptimizerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodSaveOptimizerViewXML, Fixture, methodSaveOptimizerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveOptimizerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveOptimizerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveOptimizerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveOptimizerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveOptimizerViewXML, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteOptimizerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_DeleteOptimizerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodDeleteOptimizerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodDeleteOptimizerViewXML, Fixture, methodDeleteOptimizerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteOptimizerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.DeleteOptimizerViewXML(guidView);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteOptimizerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var methodDeleteOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteOptimizerViewXML = { guidView };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerViewXML, methodDeleteOptimizerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfDeleteOptimizerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodDeleteOptimizerViewXML, parametersOfDeleteOptimizerViewXML, methodDeleteOptimizerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteOptimizerViewXML.ShouldNotBeNull();
            parametersOfDeleteOptimizerViewXML.Length.ShouldBe(1);
            methodDeleteOptimizerViewXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteOptimizerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var methodDeleteOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteOptimizerViewXML = { guidView };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerViewXML, methodDeleteOptimizerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfDeleteOptimizerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodDeleteOptimizerViewXML, parametersOfDeleteOptimizerViewXML, methodDeleteOptimizerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteOptimizerViewXML.ShouldNotBeNull();
            parametersOfDeleteOptimizerViewXML.Length.ShouldBe(1);
            methodDeleteOptimizerViewXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteOptimizerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var methodDeleteOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteOptimizerViewXML = { guidView };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodDeleteOptimizerViewXML, parametersOfDeleteOptimizerViewXML, methodDeleteOptimizerViewXMLPrametersTypes);

            // Assert
            parametersOfDeleteOptimizerViewXML.ShouldNotBeNull();
            parametersOfDeleteOptimizerViewXML.Length.ShouldBe(1);
            methodDeleteOptimizerViewXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteOptimizerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodDeleteOptimizerViewXML, Fixture, methodDeleteOptimizerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteOptimizerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteOptimizerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteOptimizerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerViewXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameOptimizerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_RenameOptimizerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodRenameOptimizerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodRenameOptimizerViewXML, Fixture, methodRenameOptimizerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameOptimizerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.RenameOptimizerViewXML(guidView, sName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenameOptimizerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameOptimizerViewXML = { guidView, sName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenameOptimizerViewXML, methodRenameOptimizerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfRenameOptimizerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodRenameOptimizerViewXML, parametersOfRenameOptimizerViewXML, methodRenameOptimizerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRenameOptimizerViewXML.ShouldNotBeNull();
            parametersOfRenameOptimizerViewXML.Length.ShouldBe(2);
            methodRenameOptimizerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RenameOptimizerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameOptimizerViewXML = { guidView, sName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenameOptimizerViewXML, methodRenameOptimizerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfRenameOptimizerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodRenameOptimizerViewXML, parametersOfRenameOptimizerViewXML, methodRenameOptimizerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRenameOptimizerViewXML.ShouldNotBeNull();
            parametersOfRenameOptimizerViewXML.Length.ShouldBe(2);
            methodRenameOptimizerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RenameOptimizerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameOptimizerViewXML = { guidView, sName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodRenameOptimizerViewXML, parametersOfRenameOptimizerViewXML, methodRenameOptimizerViewXMLPrametersTypes);

            // Assert
            parametersOfRenameOptimizerViewXML.ShouldNotBeNull();
            parametersOfRenameOptimizerViewXML.Length.ShouldBe(2);
            methodRenameOptimizerViewXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameOptimizerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameOptimizerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodRenameOptimizerViewXML, Fixture, methodRenameOptimizerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenameOptimizerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameOptimizerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameOptimizerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenameOptimizerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameOptimizerViewXML, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagiesXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_GetOptimizerStratagiesXML_Method_Call_Internally(Type[] types)
        {
            var methodGetOptimizerStratagiesXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGetOptimizerStratagiesXML, Fixture, methodGetOptimizerStratagiesXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagiesXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagiesXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ListID = CreateType<string>();
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.GetOptimizerStratagiesXML(ListID, out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagiesXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagiesXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ListID = CreateType<string>();
            var sReply = CreateType<string>();
            var methodGetOptimizerStratagiesXMLPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetOptimizerStratagiesXML = { ListID, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOptimizerStratagiesXML, methodGetOptimizerStratagiesXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfGetOptimizerStratagiesXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerStratagiesXML, parametersOfGetOptimizerStratagiesXML, methodGetOptimizerStratagiesXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetOptimizerStratagiesXML.ShouldNotBeNull();
            parametersOfGetOptimizerStratagiesXML.Length.ShouldBe(2);
            methodGetOptimizerStratagiesXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagiesXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagiesXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var ListID = CreateType<string>();
            var sReply = CreateType<string>();
            var methodGetOptimizerStratagiesXMLPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetOptimizerStratagiesXML = { ListID, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOptimizerStratagiesXML, methodGetOptimizerStratagiesXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfGetOptimizerStratagiesXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerStratagiesXML, parametersOfGetOptimizerStratagiesXML, methodGetOptimizerStratagiesXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetOptimizerStratagiesXML.ShouldNotBeNull();
            parametersOfGetOptimizerStratagiesXML.Length.ShouldBe(2);
            methodGetOptimizerStratagiesXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagiesXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagiesXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ListID = CreateType<string>();
            var sReply = CreateType<string>();
            var methodGetOptimizerStratagiesXMLPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetOptimizerStratagiesXML = { ListID, sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerStratagiesXML, parametersOfGetOptimizerStratagiesXML, methodGetOptimizerStratagiesXMLPrametersTypes);

            // Assert
            parametersOfGetOptimizerStratagiesXML.ShouldNotBeNull();
            parametersOfGetOptimizerStratagiesXML.Length.ShouldBe(2);
            methodGetOptimizerStratagiesXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagiesXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagiesXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetOptimizerStratagiesXMLPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGetOptimizerStratagiesXML, Fixture, methodGetOptimizerStratagiesXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetOptimizerStratagiesXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagiesXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagiesXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOptimizerStratagiesXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptimizerStratagiesXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagiesXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetOptimizerStratagiesXML, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagyXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_GetOptimizerStratagyXML_Method_Call_Internally(Type[] types)
        {
            var methodGetOptimizerStratagyXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGetOptimizerStratagyXML, Fixture, methodGetOptimizerStratagyXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagyXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagyXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.GetOptimizerStratagyXML(guidView, out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagyXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagyXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetOptimizerStratagyXML = { guidView, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOptimizerStratagyXML, methodGetOptimizerStratagyXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfGetOptimizerStratagyXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerStratagyXML, parametersOfGetOptimizerStratagyXML, methodGetOptimizerStratagyXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfGetOptimizerStratagyXML.Length.ShouldBe(2);
            methodGetOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagyXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagyXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetOptimizerStratagyXML = { guidView, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetOptimizerStratagyXML, methodGetOptimizerStratagyXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfGetOptimizerStratagyXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerStratagyXML, parametersOfGetOptimizerStratagyXML, methodGetOptimizerStratagyXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfGetOptimizerStratagyXML.Length.ShouldBe(2);
            methodGetOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagyXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagyXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetOptimizerStratagyXML = { guidView, sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodGetOptimizerStratagyXML, parametersOfGetOptimizerStratagyXML, methodGetOptimizerStratagyXMLPrametersTypes);

            // Assert
            parametersOfGetOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfGetOptimizerStratagyXML.Length.ShouldBe(2);
            methodGetOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagyXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagyXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodGetOptimizerStratagyXML, Fixture, methodGetOptimizerStratagyXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetOptimizerStratagyXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagyXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetOptimizerStratagyXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetOptimizerStratagyXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetOptimizerStratagyXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetOptimizerStratagyXML, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagyXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_SaveOptimizerStratagyXML_Method_Call_Internally(Type[] types)
        {
            var methodSaveOptimizerStratagyXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodSaveOptimizerStratagyXML, Fixture, methodSaveOptimizerStratagyXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagyXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerStratagyXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.SaveOptimizerStratagyXML(guidStratagy, sName, bPersonal, bDefault, sData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagyXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerStratagyXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveOptimizerStratagyXML = { guidStratagy, sName, bPersonal, bDefault, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveOptimizerStratagyXML, methodSaveOptimizerStratagyXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfSaveOptimizerStratagyXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodSaveOptimizerStratagyXML, parametersOfSaveOptimizerStratagyXML, methodSaveOptimizerStratagyXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfSaveOptimizerStratagyXML.Length.ShouldBe(5);
            methodSaveOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagyXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerStratagyXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveOptimizerStratagyXML = { guidStratagy, sName, bPersonal, bDefault, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveOptimizerStratagyXML, methodSaveOptimizerStratagyXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfSaveOptimizerStratagyXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodSaveOptimizerStratagyXML, parametersOfSaveOptimizerStratagyXML, methodSaveOptimizerStratagyXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfSaveOptimizerStratagyXML.Length.ShouldBe(5);
            methodSaveOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagyXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerStratagyXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveOptimizerStratagyXML = { guidStratagy, sName, bPersonal, bDefault, sData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodSaveOptimizerStratagyXML, parametersOfSaveOptimizerStratagyXML, methodSaveOptimizerStratagyXMLPrametersTypes);

            // Assert
            parametersOfSaveOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfSaveOptimizerStratagyXML.Length.ShouldBe(5);
            methodSaveOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagyXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerStratagyXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodSaveOptimizerStratagyXML, Fixture, methodSaveOptimizerStratagyXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagyXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerStratagyXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveOptimizerStratagyXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveOptimizerStratagyXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_SaveOptimizerStratagyXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveOptimizerStratagyXML, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagyXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_DeleteOptimizerStratagyXML_Method_Call_Internally(Type[] types)
        {
            var methodDeleteOptimizerStratagyXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodDeleteOptimizerStratagyXML, Fixture, methodDeleteOptimizerStratagyXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagyXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerStratagyXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.DeleteOptimizerStratagyXML(guidStratagy);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagyXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerStratagyXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var methodDeleteOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteOptimizerStratagyXML = { guidStratagy };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerStratagyXML, methodDeleteOptimizerStratagyXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfDeleteOptimizerStratagyXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodDeleteOptimizerStratagyXML, parametersOfDeleteOptimizerStratagyXML, methodDeleteOptimizerStratagyXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfDeleteOptimizerStratagyXML.Length.ShouldBe(1);
            methodDeleteOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagyXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerStratagyXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var methodDeleteOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteOptimizerStratagyXML = { guidStratagy };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerStratagyXML, methodDeleteOptimizerStratagyXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfDeleteOptimizerStratagyXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodDeleteOptimizerStratagyXML, parametersOfDeleteOptimizerStratagyXML, methodDeleteOptimizerStratagyXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfDeleteOptimizerStratagyXML.Length.ShouldBe(1);
            methodDeleteOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagyXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerStratagyXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var methodDeleteOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteOptimizerStratagyXML = { guidStratagy };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodDeleteOptimizerStratagyXML, parametersOfDeleteOptimizerStratagyXML, methodDeleteOptimizerStratagyXMLPrametersTypes);

            // Assert
            parametersOfDeleteOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfDeleteOptimizerStratagyXML.Length.ShouldBe(1);
            methodDeleteOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagyXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerStratagyXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodDeleteOptimizerStratagyXML, Fixture, methodDeleteOptimizerStratagyXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagyXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerStratagyXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerStratagyXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteOptimizerStratagyXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_DeleteOptimizerStratagyXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteOptimizerStratagyXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagyXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_RenameOptimizerStratagyXML_Method_Call_Internally(Type[] types)
        {
            var methodRenameOptimizerStratagyXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodRenameOptimizerStratagyXML, Fixture, methodRenameOptimizerStratagyXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagyXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerStratagyXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var sName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.RenameOptimizerStratagyXML(guidStratagy, sName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagyXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerStratagyXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameOptimizerStratagyXML = { guidStratagy, sName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenameOptimizerStratagyXML, methodRenameOptimizerStratagyXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfRenameOptimizerStratagyXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodRenameOptimizerStratagyXML, parametersOfRenameOptimizerStratagyXML, methodRenameOptimizerStratagyXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRenameOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfRenameOptimizerStratagyXML.Length.ShouldBe(2);
            methodRenameOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagyXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerStratagyXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameOptimizerStratagyXML = { guidStratagy, sName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenameOptimizerStratagyXML, methodRenameOptimizerStratagyXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfRenameOptimizerStratagyXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodRenameOptimizerStratagyXML, parametersOfRenameOptimizerStratagyXML, methodRenameOptimizerStratagyXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRenameOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfRenameOptimizerStratagyXML.Length.ShouldBe(2);
            methodRenameOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagyXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerStratagyXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidStratagy = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameOptimizerStratagyXML = { guidStratagy, sName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodRenameOptimizerStratagyXML, parametersOfRenameOptimizerStratagyXML, methodRenameOptimizerStratagyXMLPrametersTypes);

            // Assert
            parametersOfRenameOptimizerStratagyXML.ShouldNotBeNull();
            parametersOfRenameOptimizerStratagyXML.Length.ShouldBe(2);
            methodRenameOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagyXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerStratagyXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameOptimizerStratagyXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodRenameOptimizerStratagyXML, Fixture, methodRenameOptimizerStratagyXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenameOptimizerStratagyXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagyXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerStratagyXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameOptimizerStratagyXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenameOptimizerStratagyXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_RenameOptimizerStratagyXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameOptimizerStratagyXML, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_CommitOptimizerStratagy_Method_Call_Internally(Type[] types)
        {
            var methodCommitOptimizerStratagyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodCommitOptimizerStratagy, Fixture, methodCommitOptimizerStratagyPrametersTypes);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_CommitOptimizerStratagy_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sFname = CreateType<string>();
            var sIn = CreateType<string>();
            var sOut = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _optimizerDataInstance.CommitOptimizerStratagy(sFname, sIn, sOut);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_CommitOptimizerStratagy_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sFname = CreateType<string>();
            var sIn = CreateType<string>();
            var sOut = CreateType<string>();
            var methodCommitOptimizerStratagyPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfCommitOptimizerStratagy = { sFname, sIn, sOut };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCommitOptimizerStratagy, methodCommitOptimizerStratagyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerDataInstanceFixture, parametersOfCommitOptimizerStratagy);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCommitOptimizerStratagy.ShouldNotBeNull();
            parametersOfCommitOptimizerStratagy.Length.ShouldBe(3);
            methodCommitOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            methodCommitOptimizerStratagyPrametersTypes.Length.ShouldBe(parametersOfCommitOptimizerStratagy.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_CommitOptimizerStratagy_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sFname = CreateType<string>();
            var sIn = CreateType<string>();
            var sOut = CreateType<string>();
            var methodCommitOptimizerStratagyPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfCommitOptimizerStratagy = { sFname, sIn, sOut };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_optimizerDataInstance, MethodCommitOptimizerStratagy, parametersOfCommitOptimizerStratagy, methodCommitOptimizerStratagyPrametersTypes);

            // Assert
            parametersOfCommitOptimizerStratagy.ShouldNotBeNull();
            parametersOfCommitOptimizerStratagy.Length.ShouldBe(3);
            methodCommitOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            methodCommitOptimizerStratagyPrametersTypes.Length.ShouldBe(parametersOfCommitOptimizerStratagy.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_CommitOptimizerStratagy_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCommitOptimizerStratagy, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_CommitOptimizerStratagy_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCommitOptimizerStratagyPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodCommitOptimizerStratagy, Fixture, methodCommitOptimizerStratagyPrametersTypes);

            // Assert
            methodCommitOptimizerStratagyPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CommitOptimizerStratagy) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_CommitOptimizerStratagy_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCommitOptimizerStratagy, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCurrencySettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_ReadCurrencySettings_Method_Call_Internally(Type[] types)
        {
            var methodReadCurrencySettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodReadCurrencySettings, Fixture, methodReadCurrencySettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCurrencySettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadCurrencySettings_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadCurrencySettingsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadCurrencySettings = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadCurrencySettings, methodReadCurrencySettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerDataInstanceFixture, parametersOfReadCurrencySettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadCurrencySettings.ShouldNotBeNull();
            parametersOfReadCurrencySettings.Length.ShouldBe(1);
            methodReadCurrencySettingsPrametersTypes.Length.ShouldBe(1);
            methodReadCurrencySettingsPrametersTypes.Length.ShouldBe(parametersOfReadCurrencySettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadCurrencySettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadCurrencySettings_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadCurrencySettingsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadCurrencySettings = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_optimizerDataInstance, MethodReadCurrencySettings, parametersOfReadCurrencySettings, methodReadCurrencySettingsPrametersTypes);

            // Assert
            parametersOfReadCurrencySettings.ShouldNotBeNull();
            parametersOfReadCurrencySettings.Length.ShouldBe(1);
            methodReadCurrencySettingsPrametersTypes.Length.ShouldBe(1);
            methodReadCurrencySettingsPrametersTypes.Length.ShouldBe(parametersOfReadCurrencySettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCurrencySettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadCurrencySettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCurrencySettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCurrencySettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadCurrencySettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCurrencySettingsPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodReadCurrencySettings, Fixture, methodReadCurrencySettingsPrametersTypes);

            // Assert
            methodReadCurrencySettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCurrencySettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadCurrencySettings_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCurrencySettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_ReadStages_Method_Call_Internally(Type[] types)
        {
            var methodReadStagesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodReadStages, Fixture, methodReadStagesPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadStages_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadStagesPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadStages = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadStages, methodReadStagesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerDataInstanceFixture, parametersOfReadStages);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadStages.ShouldNotBeNull();
            parametersOfReadStages.Length.ShouldBe(1);
            methodReadStagesPrametersTypes.Length.ShouldBe(1);
            methodReadStagesPrametersTypes.Length.ShouldBe(parametersOfReadStages.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadStages_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadStagesPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadStages = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_optimizerDataInstance, MethodReadStages, parametersOfReadStages, methodReadStagesPrametersTypes);

            // Assert
            parametersOfReadStages.ShouldNotBeNull();
            parametersOfReadStages.Length.ShouldBe(1);
            methodReadStagesPrametersTypes.Length.ShouldBe(1);
            methodReadStagesPrametersTypes.Length.ShouldBe(parametersOfReadStages.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadStages_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadStages, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadStages_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadStagesPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodReadStages, Fixture, methodReadStagesPrametersTypes);

            // Assert
            methodReadStagesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadStages_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadStages, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_ReadExtraPifields_Method_Call_Internally(Type[] types)
        {
            var methodReadExtraPifieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodReadExtraPifields, Fixture, methodReadExtraPifieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadExtraPifields_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadExtraPifieldsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadExtraPifields = { oDataAccess };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadExtraPifields, methodReadExtraPifieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerDataInstanceFixture, parametersOfReadExtraPifields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadExtraPifields.ShouldNotBeNull();
            parametersOfReadExtraPifields.Length.ShouldBe(1);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(1);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(parametersOfReadExtraPifields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadExtraPifields_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var methodReadExtraPifieldsPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfReadExtraPifields = { oDataAccess };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_optimizerDataInstance, MethodReadExtraPifields, parametersOfReadExtraPifields, methodReadExtraPifieldsPrametersTypes);

            // Assert
            parametersOfReadExtraPifields.ShouldNotBeNull();
            parametersOfReadExtraPifields.Length.ShouldBe(1);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(1);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(parametersOfReadExtraPifields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadExtraPifields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadExtraPifields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadExtraPifields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadExtraPifieldsPrametersTypes = new Type[] { typeof(SqlConnection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodReadExtraPifields, Fixture, methodReadExtraPifieldsPrametersTypes);

            // Assert
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadExtraPifields_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadExtraPifields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldId) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_ReadFieldDataFieldId_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadFieldDataFieldIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataFieldId, Fixture, methodReadFieldDataFieldIdPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldId) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataFieldId_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var reader = CreateType<SqlDataReader>();
            var columnName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => OptimizerData.ReadFieldDataFieldId(reader, columnName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldId) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataFieldId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reader = CreateType<SqlDataReader>();
            var columnName = CreateType<string>();
            var methodReadFieldDataFieldIdPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            object[] parametersOfReadFieldDataFieldId = { reader, columnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataFieldId, parametersOfReadFieldDataFieldId, methodReadFieldDataFieldIdPrametersTypes);

            // Assert
            parametersOfReadFieldDataFieldId.ShouldNotBeNull();
            parametersOfReadFieldDataFieldId.Length.ShouldBe(2);
            methodReadFieldDataFieldIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldId) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataFieldId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadFieldDataFieldIdPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataFieldId, Fixture, methodReadFieldDataFieldIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadFieldDataFieldIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_ReadFieldDataFieldName_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadFieldDataFieldNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataFieldName, Fixture, methodReadFieldDataFieldNamePrametersTypes);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataFieldName_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var reader = CreateType<SqlDataReader>();
            var columns = CreateType<string[]>();
            Action executeAction = null;

            // Act
            executeAction = () => OptimizerData.ReadFieldDataFieldName(reader, columns);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataFieldName_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reader = CreateType<SqlDataReader>();
            var columns = CreateType<string[]>();
            var methodReadFieldDataFieldNamePrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string[]) };
            object[] parametersOfReadFieldDataFieldName = { reader, columns };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataFieldName, parametersOfReadFieldDataFieldName, methodReadFieldDataFieldNamePrametersTypes);

            // Assert
            parametersOfReadFieldDataFieldName.ShouldNotBeNull();
            parametersOfReadFieldDataFieldName.Length.ShouldBe(2);
            methodReadFieldDataFieldNamePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataFieldName_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReadFieldDataFieldNamePrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataFieldName, Fixture, methodReadFieldDataFieldNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReadFieldDataFieldNamePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataFieldName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadFieldDataFieldNamePrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string[]) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataFieldName, Fixture, methodReadFieldDataFieldNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadFieldDataFieldNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldFormat) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_ReadFieldDataFieldFormat_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadFieldDataFieldFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataFieldFormat, Fixture, methodReadFieldDataFieldFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldFormat) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataFieldFormat_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var reader = CreateType<SqlDataReader>();
            var fieldExtraId = CreateType<int>();
            var columns = CreateType<string[]>();
            Action executeAction = null;

            // Act
            executeAction = () => OptimizerData.ReadFieldDataFieldFormat(reader, fieldExtraId, columns);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldFormat) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataFieldFormat_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reader = CreateType<SqlDataReader>();
            var fieldExtraId = CreateType<int>();
            var columns = CreateType<string[]>();
            var methodReadFieldDataFieldFormatPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(int), typeof(string[]) };
            object[] parametersOfReadFieldDataFieldFormat = { reader, fieldExtraId, columns };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataFieldFormat, parametersOfReadFieldDataFieldFormat, methodReadFieldDataFieldFormatPrametersTypes);

            // Assert
            parametersOfReadFieldDataFieldFormat.ShouldNotBeNull();
            parametersOfReadFieldDataFieldFormat.Length.ShouldBe(3);
            methodReadFieldDataFieldFormatPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataFieldFormat) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataFieldFormat_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadFieldDataFieldFormatPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(int), typeof(string[]) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataFieldFormat, Fixture, methodReadFieldDataFieldFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadFieldDataFieldFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadFieldDataSExtra) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_ReadFieldDataSExtra_Static_Method_Call_Internally(Type[] types)
        {
            var methodReadFieldDataSExtraPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataSExtra, Fixture, methodReadFieldDataSExtraPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadFieldDataSExtra) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataSExtra_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var reader = CreateType<SqlDataReader>();
            var columnName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => OptimizerData.ReadFieldDataSExtra(reader, columnName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataSExtra) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataSExtra_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reader = CreateType<SqlDataReader>();
            var columnName = CreateType<string>();
            var methodReadFieldDataSExtraPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            object[] parametersOfReadFieldDataSExtra = { reader, columnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataSExtra, parametersOfReadFieldDataSExtra, methodReadFieldDataSExtraPrametersTypes);

            // Assert
            parametersOfReadFieldDataSExtra.ShouldNotBeNull();
            parametersOfReadFieldDataSExtra.Length.ShouldBe(2);
            methodReadFieldDataSExtraPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataSExtra) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataSExtra_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReadFieldDataSExtraPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataSExtra, Fixture, methodReadFieldDataSExtraPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReadFieldDataSExtraPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReadFieldDataSExtra) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataSExtra_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadFieldDataSExtraPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataSExtra, Fixture, methodReadFieldDataSExtraPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadFieldDataSExtraPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadFieldDataSExtra) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_ReadFieldDataSExtra_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodReadFieldDataSExtraPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataSExtra, Fixture, methodReadFieldDataSExtraPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadFieldDataSExtra) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataSExtra_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var reader = CreateType<SqlDataReader>();
            var columnName = CreateType<string>();
            var tableIdColumnName = CreateType<string>();
            var fieldInTableColumnName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => OptimizerData.ReadFieldDataSExtra(reader, columnName, tableIdColumnName, fieldInTableColumnName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataSExtra) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataSExtra_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reader = CreateType<SqlDataReader>();
            var columnName = CreateType<string>();
            var tableIdColumnName = CreateType<string>();
            var fieldInTableColumnName = CreateType<string>();
            var methodReadFieldDataSExtraPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfReadFieldDataSExtra = { reader, columnName, tableIdColumnName, fieldInTableColumnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataSExtra, parametersOfReadFieldDataSExtra, methodReadFieldDataSExtraPrametersTypes);

            // Assert
            parametersOfReadFieldDataSExtra.ShouldNotBeNull();
            parametersOfReadFieldDataSExtra.Length.ShouldBe(4);
            methodReadFieldDataSExtraPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadFieldDataSExtra) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataSExtra_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReadFieldDataSExtraPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataSExtra, Fixture, methodReadFieldDataSExtraPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReadFieldDataSExtraPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (ReadFieldDataSExtra) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadFieldDataSExtra_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadFieldDataSExtraPrametersTypes = new Type[] { typeof(SqlDataReader), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodReadFieldDataSExtra, Fixture, methodReadFieldDataSExtraPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReadFieldDataSExtraPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_ReadPILevelData_Method_Call_Internally(Type[] types)
        {
            var methodReadPILevelDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodReadPILevelData, Fixture, methodReadPILevelDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadPILevelData_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sPIList = CreateType<string>();
            var methodReadPILevelDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfReadPILevelData = { oDataAccess, sPIList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadPILevelData, methodReadPILevelDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerDataInstanceFixture, parametersOfReadPILevelData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadPILevelData.ShouldNotBeNull();
            parametersOfReadPILevelData.Length.ShouldBe(2);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(2);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(parametersOfReadPILevelData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadPILevelData_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var sPIList = CreateType<string>();
            var methodReadPILevelDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfReadPILevelData = { oDataAccess, sPIList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_optimizerDataInstance, MethodReadPILevelData, parametersOfReadPILevelData, methodReadPILevelDataPrametersTypes);

            // Assert
            parametersOfReadPILevelData.ShouldNotBeNull();
            parametersOfReadPILevelData.Length.ShouldBe(2);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(2);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(parametersOfReadPILevelData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadPILevelData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadPILevelData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadPILevelData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadPILevelDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodReadPILevelData, Fixture, methodReadPILevelDataPrametersTypes);

            // Assert
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_ReadPILevelData_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadPILevelData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_GetCFFieldName_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetCFFieldNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodGetCFFieldName, Fixture, methodGetCFFieldNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetCFFieldName_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var lTableID = CreateType<int>();
            var lFieldID = CreateType<int>();
            var sTable = CreateType<string>();
            var sField = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => OptimizerData.GetCFFieldName(lTableID, lFieldID, out sTable, out sField);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetCFFieldName_Static_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var lTableID = CreateType<int>();
            var lFieldID = CreateType<int>();
            var sTable = CreateType<string>();
            var sField = CreateType<string>();
            var methodGetCFFieldNamePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGetCFFieldName = { lTableID, lFieldID, sTable, sField };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCFFieldName, methodGetCFFieldNamePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_optimizerDataInstanceFixture, parametersOfGetCFFieldName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCFFieldName.ShouldNotBeNull();
            parametersOfGetCFFieldName.Length.ShouldBe(4);
            methodGetCFFieldNamePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetCFFieldName_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lTableID = CreateType<int>();
            var lFieldID = CreateType<int>();
            var sTable = CreateType<string>();
            var sField = CreateType<string>();
            var methodGetCFFieldNamePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGetCFFieldName = { lTableID, lFieldID, sTable, sField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodGetCFFieldName, parametersOfGetCFFieldName, methodGetCFFieldNamePrametersTypes);

            // Assert
            parametersOfGetCFFieldName.ShouldNotBeNull();
            parametersOfGetCFFieldName.Length.ShouldBe(4);
            methodGetCFFieldNamePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetCFFieldName_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCFFieldName, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetCFFieldName_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCFFieldNamePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_optimizerDataInstanceFixture, _optimizerDataInstanceType, MethodGetCFFieldName, Fixture, methodGetCFFieldNamePrametersTypes);

            // Assert
            methodGetCFFieldNamePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_GetCFFieldName_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCFFieldName, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_MyFormat_Method_Call_Internally(Type[] types)
        {
            var methodMyFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodMyFormat, Fixture, methodMyFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_MyFormat_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var lt = CreateType<int>();
            var sCodes = CreateType<string>();
            var sRes = CreateType<string>();
            var methodMyFormatPrametersTypes = new Type[] { typeof(object), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfMyFormat = { obj, lt, sCodes, sRes };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodMyFormat, methodMyFormatPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, string>(_optimizerDataInstanceFixture, out exception1, parametersOfMyFormat);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, string>(_optimizerDataInstance, MethodMyFormat, parametersOfMyFormat, methodMyFormatPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfMyFormat.ShouldNotBeNull();
            parametersOfMyFormat.Length.ShouldBe(4);
            methodMyFormatPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_MyFormat_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var lt = CreateType<int>();
            var sCodes = CreateType<string>();
            var sRes = CreateType<string>();
            var methodMyFormatPrametersTypes = new Type[] { typeof(object), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfMyFormat = { obj, lt, sCodes, sRes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, string>(_optimizerDataInstance, MethodMyFormat, parametersOfMyFormat, methodMyFormatPrametersTypes);

            // Assert
            parametersOfMyFormat.ShouldNotBeNull();
            parametersOfMyFormat.Length.ShouldBe(4);
            methodMyFormatPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_MyFormat_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodMyFormatPrametersTypes = new Type[] { typeof(object), typeof(int), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodMyFormat, Fixture, methodMyFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodMyFormatPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_MyFormat_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMyFormatPrametersTypes = new Type[] { typeof(object), typeof(int), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodMyFormat, Fixture, methodMyFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMyFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_MyFormat_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMyFormat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_MyFormat_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodMyFormat, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatExportExtraData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_FormatExportExtraData_Method_Call_Internally(Type[] types)
        {
            var methodFormatExportExtraDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodFormatExportExtraData, Fixture, methodFormatExportExtraDataPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatExportExtraData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatExportExtraData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var lt = CreateType<int>();
            var methodFormatExportExtraDataPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfFormatExportExtraData = { sIn, lt };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatExportExtraData, methodFormatExportExtraDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, string>(_optimizerDataInstanceFixture, out exception1, parametersOfFormatExportExtraData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, string>(_optimizerDataInstance, MethodFormatExportExtraData, parametersOfFormatExportExtraData, methodFormatExportExtraDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFormatExportExtraData.ShouldNotBeNull();
            parametersOfFormatExportExtraData.Length.ShouldBe(2);
            methodFormatExportExtraDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FormatExportExtraData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatExportExtraData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sIn = CreateType<string>();
            var lt = CreateType<int>();
            var methodFormatExportExtraDataPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfFormatExportExtraData = { sIn, lt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, string>(_optimizerDataInstance, MethodFormatExportExtraData, parametersOfFormatExportExtraData, methodFormatExportExtraDataPrametersTypes);

            // Assert
            parametersOfFormatExportExtraData.ShouldNotBeNull();
            parametersOfFormatExportExtraData.Length.ShouldBe(2);
            methodFormatExportExtraDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatExportExtraData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatExportExtraData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatExportExtraDataPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodFormatExportExtraData, Fixture, methodFormatExportExtraDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatExportExtraDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (FormatExportExtraData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatExportExtraData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatExportExtraDataPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodFormatExportExtraData, Fixture, methodFormatExportExtraDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatExportExtraDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatExportExtraData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatExportExtraData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatExportExtraData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatExportExtraData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatExportExtraData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatExportExtraData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OptimizeThisType) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_OptimizeThisType_Method_Call_Internally(Type[] types)
        {
            var methodOptimizeThisTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodOptimizeThisType, Fixture, methodOptimizeThisTypePrametersTypes);
        }

        #endregion

        #region Method Call : (OptimizeThisType) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizeThisType_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var fldtype = CreateType<int>();
            var methodOptimizeThisTypePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfOptimizeThisType = { fldtype };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodOptimizeThisType, methodOptimizeThisTypePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfOptimizeThisType);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodOptimizeThisType, parametersOfOptimizeThisType, methodOptimizeThisTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfOptimizeThisType.ShouldNotBeNull();
            parametersOfOptimizeThisType.Length.ShouldBe(1);
            methodOptimizeThisTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (OptimizeThisType) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizeThisType_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var fldtype = CreateType<int>();
            var methodOptimizeThisTypePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfOptimizeThisType = { fldtype };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodOptimizeThisType, methodOptimizeThisTypePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, bool>(_optimizerDataInstanceFixture, out exception1, parametersOfOptimizeThisType);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodOptimizeThisType, parametersOfOptimizeThisType, methodOptimizeThisTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfOptimizeThisType.ShouldNotBeNull();
            parametersOfOptimizeThisType.Length.ShouldBe(1);
            methodOptimizeThisTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (OptimizeThisType) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizeThisType_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var fldtype = CreateType<int>();
            var methodOptimizeThisTypePrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfOptimizeThisType = { fldtype };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, bool>(_optimizerDataInstance, MethodOptimizeThisType, parametersOfOptimizeThisType, methodOptimizeThisTypePrametersTypes);

            // Assert
            parametersOfOptimizeThisType.ShouldNotBeNull();
            parametersOfOptimizeThisType.Length.ShouldBe(1);
            methodOptimizeThisTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OptimizeThisType) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizeThisType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOptimizeThisTypePrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodOptimizeThisType, Fixture, methodOptimizeThisTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodOptimizeThisTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OptimizeThisType) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizeThisType_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOptimizeThisType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (OptimizeThisType) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_OptimizeThisType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOptimizeThisType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_StripNum_Method_Call_Internally(Type[] types)
        {
            var methodStripNumPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodStripNum, Fixture, methodStripNumPrametersTypes);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_StripNum_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, int>(_optimizerDataInstanceFixture, out exception1, parametersOfStripNum);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, int>(_optimizerDataInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_StripNum_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, int>(_optimizerDataInstanceFixture, out exception1, parametersOfStripNum);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, int>(_optimizerDataInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfStripNum.ShouldNotBeNull();
            parametersOfStripNum.Length.ShouldBe(1);
            methodStripNumPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_StripNum_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, int>(_optimizerDataInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

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
        public void AUT_OptimizerData_StripNum_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodStripNum, Fixture, methodStripNumPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStripNumPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_StripNum_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStripNum, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_StripNum_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (FormatSQLDateTime) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OptimizerData_FormatSQLDateTime_Method_Call_Internally(Type[] types)
        {
            var methodFormatSQLDateTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodFormatSQLDateTime, Fixture, methodFormatSQLDateTimePrametersTypes);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatSQLDateTime_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dt = CreateType<DateTime>();
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfFormatSQLDateTime = { dt };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatSQLDateTime, methodFormatSQLDateTimePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OptimizerData, string>(_optimizerDataInstanceFixture, out exception1, parametersOfFormatSQLDateTime);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OptimizerData, string>(_optimizerDataInstance, MethodFormatSQLDateTime, parametersOfFormatSQLDateTime, methodFormatSQLDateTimePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfFormatSQLDateTime.ShouldNotBeNull();
            parametersOfFormatSQLDateTime.Length.ShouldBe(1);
            methodFormatSQLDateTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatSQLDateTime_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DateTime>();
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfFormatSQLDateTime = { dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<OptimizerData, string>(_optimizerDataInstance, MethodFormatSQLDateTime, parametersOfFormatSQLDateTime, methodFormatSQLDateTimePrametersTypes);

            // Assert
            parametersOfFormatSQLDateTime.ShouldNotBeNull();
            parametersOfFormatSQLDateTime.Length.ShouldBe(1);
            methodFormatSQLDateTimePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatSQLDateTime_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodFormatSQLDateTime, Fixture, methodFormatSQLDateTimePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatSQLDateTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatSQLDateTime_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_optimizerDataInstance, MethodFormatSQLDateTime, Fixture, methodFormatSQLDateTimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatSQLDateTimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatSQLDateTime_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatSQLDateTime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_optimizerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OptimizerData_FormatSQLDateTime_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatSQLDateTime, 0);
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