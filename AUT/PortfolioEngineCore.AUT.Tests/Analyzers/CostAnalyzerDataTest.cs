using System;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using CostDataValues;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.CostAnalyzerData" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
	[ExcludeFromCodeCoverage]
    public class CostAnalyzerDataTest : AbstractBaseSetupTypedTest<CostAnalyzerData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CostAnalyzerData) Initializer

        private const string MethodInitalLoadData = "InitalLoadData";
        private const string MethodGrabPidsFromTickect = "GrabPidsFromTickect";
        private const string MethodCheckIfCostViewsExist = "CheckIfCostViewsExist";
        private const string MethodGrabCostViewInfo = "GrabCostViewInfo";
        private const string MethodAppendId = "AppendId";
        private const string MethodGrabStatus = "GrabStatus";
        private const string MethodReadPeriods = "ReadPeriods";
        private const string MethodReadCatItems = "ReadCatItems";
        private const string MethodReadCustomFields = "ReadCustomFields";
        private const string MethodReadCostTypeNames = "ReadCostTypeNames";
        private const string MethodReadStages = "ReadStages";
        private const string MethodReadExtraPifields = "ReadExtraPifields";
        private const string MethodReadPILevelData = "ReadPILevelData";
        private const string MethodReadCostCustomFieldsAndData = "ReadCostCustomFieldsAndData";
        private const string MethodReadBudgetBands = "ReadBudgetBands";
        private const string MethodReadRateTable = "ReadRateTable";
        private const string MethodStashRateCache = "StashRateCache";
        private const string MethodPerformCalcs = "PerformCalcs";
        private const string MethodGetCFFieldName = "GetCFFieldName";
        private const string MethodMyFormat = "MyFormat";
        private const string MethodStripNum = "StripNum";
        private const string MethodGetCostAnalyzerViewsXML = "GetCostAnalyzerViewsXML";
        private const string MethodGetCostAnalyzerViewXML = "GetCostAnalyzerViewXML";
        private const string MethodSaveCostAnalyzerViewXML = "SaveCostAnalyzerViewXML";
        private const string MethodDeleteCostAnalyzerViewXML = "DeleteCostAnalyzerViewXML";
        private const string MethodRenameCostAnalyzerViewXML = "RenameCostAnalyzerViewXML";
        private const string MethodFormatSQLDateTime = "FormatSQLDateTime";
        private const string MethodLoadTargets = "LoadTargets";
        private const string MethodDeleteTarget = "DeleteTarget";
        private const string MethodSaveTargetData = "SaveTargetData";
        private const string MethodReloadTargets = "ReloadTargets";
        private const string Field_sqlConnection = "_sqlConnection";
        private Type _costAnalyzerDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CostAnalyzerData _costAnalyzerDataInstance;
        private CostAnalyzerData _costAnalyzerDataInstanceFixture;

        #region General Initializer : Class (CostAnalyzerData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CostAnalyzerData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _costAnalyzerDataInstanceType = typeof(CostAnalyzerData);
            _costAnalyzerDataInstanceFixture = Create(true);
            _costAnalyzerDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CostAnalyzerData)

        #region General Initializer : Class (CostAnalyzerData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="CostAnalyzerData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInitalLoadData, 0)]
        [TestCase(MethodGrabPidsFromTickect, 0)]
        [TestCase(MethodGrabCostViewInfo, 0)]
        [TestCase(MethodGrabStatus, 0)]
        [TestCase(MethodReadPeriods, 0)]
        [TestCase(MethodReadCatItems, 0)]
        [TestCase(MethodReadCustomFields, 0)]
        [TestCase(MethodReadCostTypeNames, 0)]
        [TestCase(MethodReadStages, 0)]
        [TestCase(MethodReadExtraPifields, 0)]
        [TestCase(MethodReadPILevelData, 0)]
        [TestCase(MethodReadCostCustomFieldsAndData, 0)]
        [TestCase(MethodReadBudgetBands, 0)]
        [TestCase(MethodReadRateTable, 0)]
        [TestCase(MethodStashRateCache, 0)]
        [TestCase(MethodPerformCalcs, 0)]
        [TestCase(MethodGetCFFieldName, 0)]
        [TestCase(MethodMyFormat, 0)]
        [TestCase(MethodStripNum, 0)]
        [TestCase(MethodGetCostAnalyzerViewsXML, 0)]
        [TestCase(MethodGetCostAnalyzerViewXML, 0)]
        [TestCase(MethodSaveCostAnalyzerViewXML, 0)]
        [TestCase(MethodDeleteCostAnalyzerViewXML, 0)]
        [TestCase(MethodRenameCostAnalyzerViewXML, 0)]
        [TestCase(MethodFormatSQLDateTime, 0)]
        [TestCase(MethodLoadTargets, 0)]
        [TestCase(MethodDeleteTarget, 0)]
        [TestCase(MethodSaveTargetData, 0)]
        [TestCase(MethodReloadTargets, 0)]
        public void AUT_CostAnalyzerData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_costAnalyzerDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CostAnalyzerData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CostAnalyzerData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_sqlConnection)]
        public void AUT_CostAnalyzerData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_costAnalyzerDataInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CostAnalyzerData) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="CostAnalyzerData" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_CostAnalyzerData_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<CostAnalyzerData>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (CostAnalyzerData) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="CostAnalyzerData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CostAnalyzerData_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<CostAnalyzerData>(Fixture);
        }

        #endregion

        #region General Constructor : Class (CostAnalyzerData) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CostAnalyzerData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CostAnalyzerData_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfCostAnalyzerData = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodCostAnalyzerDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_costAnalyzerDataInstanceType, methodCostAnalyzerDataPrametersTypes, parametersOfCostAnalyzerData);
        }

        #endregion

        #region General Constructor : Class (CostAnalyzerData) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CostAnalyzerData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CostAnalyzerData_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodCostAnalyzerDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_costAnalyzerDataInstanceType, Fixture, methodCostAnalyzerDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (CostAnalyzerData) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CostAnalyzerData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CostAnalyzerData_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            object[] parametersOfCostAnalyzerData = { sBaseInfo };
            var methodCostAnalyzerDataPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_costAnalyzerDataInstanceType, methodCostAnalyzerDataPrametersTypes, parametersOfCostAnalyzerData);
        }

        #endregion

        #region General Constructor : Class (CostAnalyzerData) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="CostAnalyzerData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_CostAnalyzerData_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodCostAnalyzerDataPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_costAnalyzerDataInstanceType, Fixture, methodCostAnalyzerDataPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="CostAnalyzerData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInitalLoadData)]
        [TestCase(MethodGrabStatus)]
        [TestCase(MethodReadPeriods)]
        [TestCase(MethodReadCatItems)]
        [TestCase(MethodReadCustomFields)]
        [TestCase(MethodReadCostTypeNames)]
        [TestCase(MethodReadStages)]
        [TestCase(MethodReadExtraPifields)]
        [TestCase(MethodReadPILevelData)]
        [TestCase(MethodReadCostCustomFieldsAndData)]
        [TestCase(MethodReadBudgetBands)]
        [TestCase(MethodReadRateTable)]
        [TestCase(MethodStashRateCache)]
        [TestCase(MethodPerformCalcs)]
        [TestCase(MethodGetCFFieldName)]
        [TestCase(MethodMyFormat)]
        [TestCase(MethodStripNum)]
        [TestCase(MethodGetCostAnalyzerViewsXML)]
        [TestCase(MethodGetCostAnalyzerViewXML)]
        [TestCase(MethodSaveCostAnalyzerViewXML)]
        [TestCase(MethodDeleteCostAnalyzerViewXML)]
        [TestCase(MethodRenameCostAnalyzerViewXML)]
        [TestCase(MethodFormatSQLDateTime)]
        [TestCase(MethodLoadTargets)]
        [TestCase(MethodDeleteTarget)]
        [TestCase(MethodSaveTargetData)]
        [TestCase(MethodReloadTargets)]
        public void AUT_CostAnalyzerData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<CostAnalyzerData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : clsCostData) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_InitalLoadData_Method_Call_Internally(Type[] types)
        {
            var methodInitalLoadDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodInitalLoadData, Fixture, methodInitalLoadDataPrametersTypes);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : clsCostData) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_InitalLoadData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var ticket = CreateType<string>();
            var sViewID = CreateType<string>();
            var m_loadmsg = CreateType<string>();
            var m_loaddatareturn = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataInstance.InitalLoadData(ticket, sViewID, out m_loadmsg, out m_loaddatareturn);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : clsCostData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_InitalLoadData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ticket = CreateType<string>();
            var sViewID = CreateType<string>();
            var m_loadmsg = CreateType<string>();
            var m_loaddatareturn = CreateType<int>();
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfInitalLoadData = { ticket, sViewID, m_loadmsg, m_loaddatareturn };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInitalLoadData, methodInitalLoadDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, clsCostData>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfInitalLoadData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, clsCostData>(_costAnalyzerDataInstance, MethodInitalLoadData, parametersOfInitalLoadData, methodInitalLoadDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfInitalLoadData.ShouldNotBeNull();
            parametersOfInitalLoadData.Length.ShouldBe(4);
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : clsCostData) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_InitalLoadData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ticket = CreateType<string>();
            var sViewID = CreateType<string>();
            var m_loadmsg = CreateType<string>();
            var m_loaddatareturn = CreateType<int>();
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };
            object[] parametersOfInitalLoadData = { ticket, sViewID, m_loadmsg, m_loaddatareturn };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, clsCostData>(_costAnalyzerDataInstance, MethodInitalLoadData, parametersOfInitalLoadData, methodInitalLoadDataPrametersTypes);

            // Assert
            parametersOfInitalLoadData.ShouldNotBeNull();
            parametersOfInitalLoadData.Length.ShouldBe(4);
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : clsCostData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_InitalLoadData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodInitalLoadData, Fixture, methodInitalLoadDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : clsCostData) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_InitalLoadData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInitalLoadDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodInitalLoadData, Fixture, methodInitalLoadDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInitalLoadDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : clsCostData) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_InitalLoadData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitalLoadData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InitalLoadData) (Return Type : clsCostData) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_InitalLoadData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInitalLoadData, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabPidsFromTickect) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_GrabPidsFromTickect_Static_Method_Call_Internally(Type[] types)
        {
            var methodGrabPidsFromTickectPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodGrabPidsFromTickect, Fixture, methodGrabPidsFromTickectPrametersTypes);
        }

        #endregion

        #region Method Call : (GrabPidsFromTickect) (Return Type : int) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabPidsFromTickect_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var ticket = CreateType<string>();
            var projectIdsString = CreateType<string>();
            var projectsExist = CreateType<bool>();
            var projectsCount = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzerData.GrabPidsFromTickect(sqlConnection, ticket, out projectIdsString, out projectsExist, out projectsCount);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GrabPidsFromTickect) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabPidsFromTickect_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var ticket = CreateType<string>();
            var projectIdsString = CreateType<string>();
            var projectsExist = CreateType<bool>();
            var projectsCount = CreateType<int>();
            var methodGrabPidsFromTickectPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(bool), typeof(int) };
            object[] parametersOfGrabPidsFromTickect = { sqlConnection, ticket, projectIdsString, projectsExist, projectsCount };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodGrabPidsFromTickect, parametersOfGrabPidsFromTickect, methodGrabPidsFromTickectPrametersTypes);

            // Assert
            parametersOfGrabPidsFromTickect.ShouldNotBeNull();
            parametersOfGrabPidsFromTickect.Length.ShouldBe(5);
            methodGrabPidsFromTickectPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabPidsFromTickect) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabPidsFromTickect_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGrabPidsFromTickectPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(bool), typeof(int) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodGrabPidsFromTickect, Fixture, methodGrabPidsFromTickectPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGrabPidsFromTickectPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabPidsFromTickect) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabPidsFromTickect_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrabPidsFromTickect, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GrabPidsFromTickect) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabPidsFromTickect_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGrabPidsFromTickect, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckIfCostViewsExist) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_CheckIfCostViewsExist_Static_Method_Call_Internally(Type[] types)
        {
            var methodCheckIfCostViewsExistPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodCheckIfCostViewsExist, Fixture, methodCheckIfCostViewsExistPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckIfCostViewsExist) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_CheckIfCostViewsExist_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            Action executeAction = null;

            // Act
            executeAction = () => CostAnalyzerData.CheckIfCostViewsExist(sqlConnection);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CheckIfCostViewsExist) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_CheckIfCostViewsExist_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var methodCheckIfCostViewsExistPrametersTypes = new Type[] { typeof(SqlConnection) };
            object[] parametersOfCheckIfCostViewsExist = { sqlConnection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodCheckIfCostViewsExist, parametersOfCheckIfCostViewsExist, methodCheckIfCostViewsExistPrametersTypes);

            // Assert
            parametersOfCheckIfCostViewsExist.ShouldNotBeNull();
            parametersOfCheckIfCostViewsExist.Length.ShouldBe(1);
            methodCheckIfCostViewsExistPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckIfCostViewsExist) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_CheckIfCostViewsExist_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckIfCostViewsExistPrametersTypes = new Type[] { typeof(SqlConnection) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodCheckIfCostViewsExist, Fixture, methodCheckIfCostViewsExistPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckIfCostViewsExistPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabCostViewInfo) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_GrabCostViewInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodGrabCostViewInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodGrabCostViewInfo, Fixture, methodGrabCostViewInfoPrametersTypes);
        }

        #endregion
        
        #region Method Call : (GrabCostViewInfo) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabCostViewInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var costViewIdString = CreateType<string>();
            var calculatedCostTypesString = CreateType<string>();
            var costBreakdownId = CreateType<int>();
            var costTypesString = CreateType<string>();
            var otherCostTypesString = CreateType<string>();
            var firstPeriod = CreateType<int>();
            var lastPeriod = CreateType<int>();
            var methodGrabCostViewInfoPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfGrabCostViewInfo = { sqlConnection, costViewIdString, calculatedCostTypesString, costBreakdownId, costTypesString, otherCostTypesString, firstPeriod, lastPeriod };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<int>(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodGrabCostViewInfo, parametersOfGrabCostViewInfo, methodGrabCostViewInfoPrametersTypes);

            // Assert
            parametersOfGrabCostViewInfo.ShouldNotBeNull();
            parametersOfGrabCostViewInfo.Length.ShouldBe(8);
            methodGrabCostViewInfoPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabCostViewInfo) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabCostViewInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGrabCostViewInfoPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string), typeof(int), typeof(string), typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 8;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodGrabCostViewInfo, Fixture, methodGrabCostViewInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGrabCostViewInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabCostViewInfo) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabCostViewInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrabCostViewInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GrabCostViewInfo) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabCostViewInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGrabCostViewInfo, 0);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendId) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_AppendId_Static_Method_Call_Internally(Type[] types)
        {
            var methodAppendIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodAppendId, Fixture, methodAppendIdPrametersTypes);
        }

        #endregion

        #region Method Call : (AppendId) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_AppendId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var costTypesString = CreateType<string>();
            var id = CreateType<int>();
            var methodAppendIdPrametersTypes = new Type[] { typeof(string), typeof(int) };
            object[] parametersOfAppendId = { costTypesString, id };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodAppendId, parametersOfAppendId, methodAppendIdPrametersTypes);

            // Assert
            parametersOfAppendId.ShouldNotBeNull();
            parametersOfAppendId.Length.ShouldBe(2);
            methodAppendIdPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendId) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_AppendId_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAppendIdPrametersTypes = new Type[] { typeof(string), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodAppendId, Fixture, methodAppendIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAppendIdPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AppendId) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_AppendId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAppendIdPrametersTypes = new Type[] { typeof(string), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_costAnalyzerDataInstanceFixture, _costAnalyzerDataInstanceType, MethodAppendId, Fixture, methodAppendIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAppendIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabStatus) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_GrabStatus_Method_Call_Internally(Type[] types)
        {
            var methodGrabStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodGrabStatus, Fixture, methodGrabStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (GrabStatus) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabStatus_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodGrabStatusPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfGrabStatus = { oDataAccess, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGrabStatus, methodGrabStatusPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfGrabStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGrabStatus.ShouldNotBeNull();
            parametersOfGrabStatus.Length.ShouldBe(2);
            methodGrabStatusPrametersTypes.Length.ShouldBe(2);
            methodGrabStatusPrametersTypes.Length.ShouldBe(parametersOfGrabStatus.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GrabStatus) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabStatus_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodGrabStatusPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfGrabStatus = { oDataAccess, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodGrabStatus, parametersOfGrabStatus, methodGrabStatusPrametersTypes);

            // Assert
            parametersOfGrabStatus.ShouldNotBeNull();
            parametersOfGrabStatus.Length.ShouldBe(2);
            methodGrabStatusPrametersTypes.Length.ShouldBe(2);
            methodGrabStatusPrametersTypes.Length.ShouldBe(parametersOfGrabStatus.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabStatus) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGrabStatus, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabStatus) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGrabStatusPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodGrabStatus, Fixture, methodGrabStatusPrametersTypes);

            // Assert
            methodGrabStatusPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabStatus) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GrabStatus_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrabStatus, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReadPeriods_Method_Call_Internally(Type[] types)
        {
            var methodReadPeriodsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadPeriods, Fixture, methodReadPeriodsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadPeriods_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadPeriodsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadPeriods = { oDataAccess, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadPeriods, methodReadPeriodsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfReadPeriods);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadPeriods.ShouldNotBeNull();
            parametersOfReadPeriods.Length.ShouldBe(2);
            methodReadPeriodsPrametersTypes.Length.ShouldBe(2);
            methodReadPeriodsPrametersTypes.Length.ShouldBe(parametersOfReadPeriods.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadPeriods_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadPeriodsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadPeriods = { oDataAccess, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodReadPeriods, parametersOfReadPeriods, methodReadPeriodsPrametersTypes);

            // Assert
            parametersOfReadPeriods.ShouldNotBeNull();
            parametersOfReadPeriods.Length.ShouldBe(2);
            methodReadPeriodsPrametersTypes.Length.ShouldBe(2);
            methodReadPeriodsPrametersTypes.Length.ShouldBe(parametersOfReadPeriods.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadPeriods_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadPeriods, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadPeriods_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadPeriodsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadPeriods, Fixture, methodReadPeriodsPrametersTypes);

            // Assert
            methodReadPeriodsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPeriods) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadPeriods_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadPeriods, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReadCatItems_Method_Call_Internally(Type[] types)
        {
            var methodReadCatItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadCatItems, Fixture, methodReadCatItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCatItems_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadCatItemsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadCatItems = { oDataAccess, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadCatItems, methodReadCatItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfReadCatItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadCatItems.ShouldNotBeNull();
            parametersOfReadCatItems.Length.ShouldBe(2);
            methodReadCatItemsPrametersTypes.Length.ShouldBe(2);
            methodReadCatItemsPrametersTypes.Length.ShouldBe(parametersOfReadCatItems.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCatItems_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadCatItemsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadCatItems = { oDataAccess, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodReadCatItems, parametersOfReadCatItems, methodReadCatItemsPrametersTypes);

            // Assert
            parametersOfReadCatItems.ShouldNotBeNull();
            parametersOfReadCatItems.Length.ShouldBe(2);
            methodReadCatItemsPrametersTypes.Length.ShouldBe(2);
            methodReadCatItemsPrametersTypes.Length.ShouldBe(parametersOfReadCatItems.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCatItems_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCatItems, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCatItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCatItemsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadCatItems, Fixture, methodReadCatItemsPrametersTypes);

            // Assert
            methodReadCatItemsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCatItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCatItems_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCatItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReadCustomFields_Method_Call_Internally(Type[] types)
        {
            var methodReadCustomFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadCustomFields, Fixture, methodReadCustomFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCustomFields_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadCustomFieldsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadCustomFields = { oDataAccess, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadCustomFields, methodReadCustomFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfReadCustomFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadCustomFields.ShouldNotBeNull();
            parametersOfReadCustomFields.Length.ShouldBe(2);
            methodReadCustomFieldsPrametersTypes.Length.ShouldBe(2);
            methodReadCustomFieldsPrametersTypes.Length.ShouldBe(parametersOfReadCustomFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCustomFields_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadCustomFieldsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadCustomFields = { oDataAccess, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodReadCustomFields, parametersOfReadCustomFields, methodReadCustomFieldsPrametersTypes);

            // Assert
            parametersOfReadCustomFields.ShouldNotBeNull();
            parametersOfReadCustomFields.Length.ShouldBe(2);
            methodReadCustomFieldsPrametersTypes.Length.ShouldBe(2);
            methodReadCustomFieldsPrametersTypes.Length.ShouldBe(parametersOfReadCustomFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCustomFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCustomFields, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCustomFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCustomFieldsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadCustomFields, Fixture, methodReadCustomFieldsPrametersTypes);

            // Assert
            methodReadCustomFieldsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCustomFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCustomFields_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCustomFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReadCostTypeNames_Method_Call_Internally(Type[] types)
        {
            var methodReadCostTypeNamesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadCostTypeNames, Fixture, methodReadCostTypeNamesPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCostTypeNames_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadCostTypeNamesPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadCostTypeNames = { oDataAccess, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadCostTypeNames, methodReadCostTypeNamesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfReadCostTypeNames);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadCostTypeNames.ShouldNotBeNull();
            parametersOfReadCostTypeNames.Length.ShouldBe(2);
            methodReadCostTypeNamesPrametersTypes.Length.ShouldBe(2);
            methodReadCostTypeNamesPrametersTypes.Length.ShouldBe(parametersOfReadCostTypeNames.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCostTypeNames_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadCostTypeNamesPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadCostTypeNames = { oDataAccess, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodReadCostTypeNames, parametersOfReadCostTypeNames, methodReadCostTypeNamesPrametersTypes);

            // Assert
            parametersOfReadCostTypeNames.ShouldNotBeNull();
            parametersOfReadCostTypeNames.Length.ShouldBe(2);
            methodReadCostTypeNamesPrametersTypes.Length.ShouldBe(2);
            methodReadCostTypeNamesPrametersTypes.Length.ShouldBe(parametersOfReadCostTypeNames.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCostTypeNames_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCostTypeNames, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCostTypeNames_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCostTypeNamesPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadCostTypeNames, Fixture, methodReadCostTypeNamesPrametersTypes);

            // Assert
            methodReadCostTypeNamesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostTypeNames) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCostTypeNames_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCostTypeNames, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReadStages_Method_Call_Internally(Type[] types)
        {
            var methodReadStagesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadStages, Fixture, methodReadStagesPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadStages_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadStagesPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadStages = { oDataAccess, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadStages, methodReadStagesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfReadStages);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadStages.ShouldNotBeNull();
            parametersOfReadStages.Length.ShouldBe(2);
            methodReadStagesPrametersTypes.Length.ShouldBe(2);
            methodReadStagesPrametersTypes.Length.ShouldBe(parametersOfReadStages.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadStages_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadStagesPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadStages = { oDataAccess, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodReadStages, parametersOfReadStages, methodReadStagesPrametersTypes);

            // Assert
            parametersOfReadStages.ShouldNotBeNull();
            parametersOfReadStages.Length.ShouldBe(2);
            methodReadStagesPrametersTypes.Length.ShouldBe(2);
            methodReadStagesPrametersTypes.Length.ShouldBe(parametersOfReadStages.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadStages_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadStages, 0);
            const int parametersCount = 2;

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
        public void AUT_CostAnalyzerData_ReadStages_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadStagesPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadStages, Fixture, methodReadStagesPrametersTypes);

            // Assert
            methodReadStagesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadStages) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadStages_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadStages, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReadExtraPifields_Method_Call_Internally(Type[] types)
        {
            var methodReadExtraPifieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadExtraPifields, Fixture, methodReadExtraPifieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadExtraPifields_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadExtraPifieldsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadExtraPifields = { oDataAccess, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadExtraPifields, methodReadExtraPifieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfReadExtraPifields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadExtraPifields.ShouldNotBeNull();
            parametersOfReadExtraPifields.Length.ShouldBe(2);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(2);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(parametersOfReadExtraPifields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadExtraPifields_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadExtraPifieldsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadExtraPifields = { oDataAccess, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodReadExtraPifields, parametersOfReadExtraPifields, methodReadExtraPifieldsPrametersTypes);

            // Assert
            parametersOfReadExtraPifields.ShouldNotBeNull();
            parametersOfReadExtraPifields.Length.ShouldBe(2);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(2);
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(parametersOfReadExtraPifields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadExtraPifields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadExtraPifields, 0);
            const int parametersCount = 2;

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
        public void AUT_CostAnalyzerData_ReadExtraPifields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadExtraPifieldsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadExtraPifields, Fixture, methodReadExtraPifieldsPrametersTypes);

            // Assert
            methodReadExtraPifieldsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadExtraPifields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadExtraPifields_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadExtraPifields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReadPILevelData_Method_Call_Internally(Type[] types)
        {
            var methodReadPILevelDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadPILevelData, Fixture, methodReadPILevelDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadPILevelData_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var earlystart = CreateType<DateTime>();
            var latefinish = CreateType<DateTime>();
            var methodReadPILevelDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData), typeof(DateTime), typeof(DateTime) };
            object[] parametersOfReadPILevelData = { oDataAccess, clscd, earlystart, latefinish };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadPILevelData, methodReadPILevelDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfReadPILevelData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadPILevelData.ShouldNotBeNull();
            parametersOfReadPILevelData.Length.ShouldBe(4);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(4);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(parametersOfReadPILevelData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadPILevelData_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var earlystart = CreateType<DateTime>();
            var latefinish = CreateType<DateTime>();
            var methodReadPILevelDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData), typeof(DateTime), typeof(DateTime) };
            object[] parametersOfReadPILevelData = { oDataAccess, clscd, earlystart, latefinish };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodReadPILevelData, parametersOfReadPILevelData, methodReadPILevelDataPrametersTypes);

            // Assert
            parametersOfReadPILevelData.ShouldNotBeNull();
            parametersOfReadPILevelData.Length.ShouldBe(4);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(4);
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(parametersOfReadPILevelData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadPILevelData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadPILevelData, 0);
            const int parametersCount = 4;

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
        public void AUT_CostAnalyzerData_ReadPILevelData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadPILevelDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData), typeof(DateTime), typeof(DateTime) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadPILevelData, Fixture, methodReadPILevelDataPrametersTypes);

            // Assert
            methodReadPILevelDataPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadPILevelData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadPILevelData_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadPILevelData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReadCostCustomFieldsAndData_Method_Call_Internally(Type[] types)
        {
            var methodReadCostCustomFieldsAndDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadCostCustomFieldsAndData, Fixture, methodReadCostCustomFieldsAndDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCostCustomFieldsAndData_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadCostCustomFieldsAndDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadCostCustomFieldsAndData = { oDataAccess, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadCostCustomFieldsAndData, methodReadCostCustomFieldsAndDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfReadCostCustomFieldsAndData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadCostCustomFieldsAndData.ShouldNotBeNull();
            parametersOfReadCostCustomFieldsAndData.Length.ShouldBe(2);
            methodReadCostCustomFieldsAndDataPrametersTypes.Length.ShouldBe(2);
            methodReadCostCustomFieldsAndDataPrametersTypes.Length.ShouldBe(parametersOfReadCostCustomFieldsAndData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCostCustomFieldsAndData_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadCostCustomFieldsAndDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadCostCustomFieldsAndData = { oDataAccess, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodReadCostCustomFieldsAndData, parametersOfReadCostCustomFieldsAndData, methodReadCostCustomFieldsAndDataPrametersTypes);

            // Assert
            parametersOfReadCostCustomFieldsAndData.ShouldNotBeNull();
            parametersOfReadCostCustomFieldsAndData.Length.ShouldBe(2);
            methodReadCostCustomFieldsAndDataPrametersTypes.Length.ShouldBe(2);
            methodReadCostCustomFieldsAndDataPrametersTypes.Length.ShouldBe(parametersOfReadCostCustomFieldsAndData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCostCustomFieldsAndData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadCostCustomFieldsAndData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCostCustomFieldsAndData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadCostCustomFieldsAndDataPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadCostCustomFieldsAndData, Fixture, methodReadCostCustomFieldsAndDataPrametersTypes);

            // Assert
            methodReadCostCustomFieldsAndDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadCostCustomFieldsAndData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadCostCustomFieldsAndData_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadCostCustomFieldsAndData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReadBudgetBands_Method_Call_Internally(Type[] types)
        {
            var methodReadBudgetBandsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadBudgetBands, Fixture, methodReadBudgetBandsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadBudgetBands_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadBudgetBandsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadBudgetBands = { oDataAccess, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadBudgetBands, methodReadBudgetBandsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfReadBudgetBands);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadBudgetBands.ShouldNotBeNull();
            parametersOfReadBudgetBands.Length.ShouldBe(2);
            methodReadBudgetBandsPrametersTypes.Length.ShouldBe(2);
            methodReadBudgetBandsPrametersTypes.Length.ShouldBe(parametersOfReadBudgetBands.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadBudgetBands_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadBudgetBandsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadBudgetBands = { oDataAccess, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodReadBudgetBands, parametersOfReadBudgetBands, methodReadBudgetBandsPrametersTypes);

            // Assert
            parametersOfReadBudgetBands.ShouldNotBeNull();
            parametersOfReadBudgetBands.Length.ShouldBe(2);
            methodReadBudgetBandsPrametersTypes.Length.ShouldBe(2);
            methodReadBudgetBandsPrametersTypes.Length.ShouldBe(parametersOfReadBudgetBands.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadBudgetBands_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadBudgetBands, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadBudgetBands_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadBudgetBandsPrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadBudgetBands, Fixture, methodReadBudgetBandsPrametersTypes);

            // Assert
            methodReadBudgetBandsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadBudgetBands) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadBudgetBands_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadBudgetBands, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReadRateTable_Method_Call_Internally(Type[] types)
        {
            var methodReadRateTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadRateTable, Fixture, methodReadRateTablePrametersTypes);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadRateTable_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadRateTablePrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadRateTable = { oDataAccess, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReadRateTable, methodReadRateTablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfReadRateTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReadRateTable.ShouldNotBeNull();
            parametersOfReadRateTable.Length.ShouldBe(2);
            methodReadRateTablePrametersTypes.Length.ShouldBe(2);
            methodReadRateTablePrametersTypes.Length.ShouldBe(parametersOfReadRateTable.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadRateTable_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oDataAccess = CreateType<SqlConnection>();
            var clscd = CreateType<clsCostData>();
            var methodReadRateTablePrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };
            object[] parametersOfReadRateTable = { oDataAccess, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodReadRateTable, parametersOfReadRateTable, methodReadRateTablePrametersTypes);

            // Assert
            parametersOfReadRateTable.ShouldNotBeNull();
            parametersOfReadRateTable.Length.ShouldBe(2);
            methodReadRateTablePrametersTypes.Length.ShouldBe(2);
            methodReadRateTablePrametersTypes.Length.ShouldBe(parametersOfReadRateTable.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadRateTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReadRateTable, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadRateTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReadRateTablePrametersTypes = new Type[] { typeof(SqlConnection), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReadRateTable, Fixture, methodReadRateTablePrametersTypes);

            // Assert
            methodReadRateTablePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReadRateTable) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReadRateTable_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReadRateTable, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_StashRateCache_Method_Call_Internally(Type[] types)
        {
            var methodStashRateCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodStashRateCache, Fixture, methodStashRateCachePrametersTypes);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_StashRateCache_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var clscd = CreateType<clsCostData>();
            var methodStashRateCachePrametersTypes = new Type[] { typeof(clsCostData) };
            object[] parametersOfStashRateCache = { clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStashRateCache, methodStashRateCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfStashRateCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStashRateCache.ShouldNotBeNull();
            parametersOfStashRateCache.Length.ShouldBe(1);
            methodStashRateCachePrametersTypes.Length.ShouldBe(1);
            methodStashRateCachePrametersTypes.Length.ShouldBe(parametersOfStashRateCache.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_StashRateCache_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var clscd = CreateType<clsCostData>();
            var methodStashRateCachePrametersTypes = new Type[] { typeof(clsCostData) };
            object[] parametersOfStashRateCache = { clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodStashRateCache, parametersOfStashRateCache, methodStashRateCachePrametersTypes);

            // Assert
            parametersOfStashRateCache.ShouldNotBeNull();
            parametersOfStashRateCache.Length.ShouldBe(1);
            methodStashRateCachePrametersTypes.Length.ShouldBe(1);
            methodStashRateCachePrametersTypes.Length.ShouldBe(parametersOfStashRateCache.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_StashRateCache_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodStashRateCache, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_StashRateCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStashRateCachePrametersTypes = new Type[] { typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodStashRateCache, Fixture, methodStashRateCachePrametersTypes);

            // Assert
            methodStashRateCachePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (StashRateCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_StashRateCache_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStashRateCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PerformCalcs) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_PerformCalcs_Method_Call_Internally(Type[] types)
        {
            var methodPerformCalcsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodPerformCalcs, Fixture, methodPerformCalcsPrametersTypes);
        }

        #endregion

        #region Method Call : (PerformCalcs) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_PerformCalcs_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var odet = CreateType<clsDetailRowData>();
            var clscd = CreateType<clsCostData>();
            var methodPerformCalcsPrametersTypes = new Type[] { typeof(clsDetailRowData), typeof(clsCostData) };
            object[] parametersOfPerformCalcs = { odet, clscd };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPerformCalcs, methodPerformCalcsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfPerformCalcs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPerformCalcs.ShouldNotBeNull();
            parametersOfPerformCalcs.Length.ShouldBe(2);
            methodPerformCalcsPrametersTypes.Length.ShouldBe(2);
            methodPerformCalcsPrametersTypes.Length.ShouldBe(parametersOfPerformCalcs.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PerformCalcs) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_PerformCalcs_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var odet = CreateType<clsDetailRowData>();
            var clscd = CreateType<clsCostData>();
            var methodPerformCalcsPrametersTypes = new Type[] { typeof(clsDetailRowData), typeof(clsCostData) };
            object[] parametersOfPerformCalcs = { odet, clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodPerformCalcs, parametersOfPerformCalcs, methodPerformCalcsPrametersTypes);

            // Assert
            parametersOfPerformCalcs.ShouldNotBeNull();
            parametersOfPerformCalcs.Length.ShouldBe(2);
            methodPerformCalcsPrametersTypes.Length.ShouldBe(2);
            methodPerformCalcsPrametersTypes.Length.ShouldBe(parametersOfPerformCalcs.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PerformCalcs) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_PerformCalcs_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPerformCalcs, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PerformCalcs) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_PerformCalcs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPerformCalcsPrametersTypes = new Type[] { typeof(clsDetailRowData), typeof(clsCostData) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodPerformCalcs, Fixture, methodPerformCalcsPrametersTypes);

            // Assert
            methodPerformCalcsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PerformCalcs) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_PerformCalcs_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPerformCalcs, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_GetCFFieldName_Method_Call_Internally(Type[] types)
        {
            var methodGetCFFieldNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodGetCFFieldName, Fixture, methodGetCFFieldNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCFFieldName_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
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
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfGetCFFieldName);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCFFieldName.ShouldNotBeNull();
            parametersOfGetCFFieldName.Length.ShouldBe(4);
            methodGetCFFieldNamePrametersTypes.Length.ShouldBe(4);
            methodGetCFFieldNamePrametersTypes.Length.ShouldBe(parametersOfGetCFFieldName.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCFFieldName_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var lTableID = CreateType<int>();
            var lFieldID = CreateType<int>();
            var sTable = CreateType<string>();
            var sField = CreateType<string>();
            var methodGetCFFieldNamePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfGetCFFieldName = { lTableID, lFieldID, sTable, sField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodGetCFFieldName, parametersOfGetCFFieldName, methodGetCFFieldNamePrametersTypes);

            // Assert
            parametersOfGetCFFieldName.ShouldNotBeNull();
            parametersOfGetCFFieldName.Length.ShouldBe(4);
            methodGetCFFieldNamePrametersTypes.Length.ShouldBe(4);
            methodGetCFFieldNamePrametersTypes.Length.ShouldBe(parametersOfGetCFFieldName.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCFFieldName_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_CostAnalyzerData_GetCFFieldName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCFFieldNamePrametersTypes = new Type[] { typeof(int), typeof(int), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodGetCFFieldName, Fixture, methodGetCFFieldNamePrametersTypes);

            // Assert
            methodGetCFFieldNamePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCFFieldName) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCFFieldName_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCFFieldName, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_MyFormat_Method_Call_Internally(Type[] types)
        {
            var methodMyFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodMyFormat, Fixture, methodMyFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_MyFormat_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
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
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, string>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfMyFormat);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, string>(_costAnalyzerDataInstance, MethodMyFormat, parametersOfMyFormat, methodMyFormatPrametersTypes);

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
        public void AUT_CostAnalyzerData_MyFormat_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var obj = CreateType<object>();
            var lt = CreateType<int>();
            var sCodes = CreateType<string>();
            var sRes = CreateType<string>();
            var methodMyFormatPrametersTypes = new Type[] { typeof(object), typeof(int), typeof(string), typeof(string) };
            object[] parametersOfMyFormat = { obj, lt, sCodes, sRes };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, string>(_costAnalyzerDataInstance, MethodMyFormat, parametersOfMyFormat, methodMyFormatPrametersTypes);

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
        public void AUT_CostAnalyzerData_MyFormat_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodMyFormatPrametersTypes = new Type[] { typeof(object), typeof(int), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodMyFormat, Fixture, methodMyFormatPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodMyFormatPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_MyFormat_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodMyFormatPrametersTypes = new Type[] { typeof(object), typeof(int), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodMyFormat, Fixture, methodMyFormatPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodMyFormatPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_MyFormat_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodMyFormat, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (MyFormat) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_MyFormat_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (StripNum) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_StripNum_Method_Call_Internally(Type[] types)
        {
            var methodStripNumPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodStripNum, Fixture, methodStripNumPrametersTypes);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_StripNum_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, int>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfStripNum);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, int>(_costAnalyzerDataInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

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
        public void AUT_CostAnalyzerData_StripNum_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodStripNum, methodStripNumPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, int>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfStripNum);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, int>(_costAnalyzerDataInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

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
        public void AUT_CostAnalyzerData_StripNum_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sin = CreateType<string>();
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfStripNum = { sin };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, int>(_costAnalyzerDataInstance, MethodStripNum, parametersOfStripNum, methodStripNumPrametersTypes);

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
        public void AUT_CostAnalyzerData_StripNum_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodStripNumPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodStripNum, Fixture, methodStripNumPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodStripNumPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_StripNum_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStripNum, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (StripNum) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_StripNum_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (GetCostAnalyzerViewsXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_GetCostAnalyzerViewsXML_Method_Call_Internally(Type[] types)
        {
            var methodGetCostAnalyzerViewsXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodGetCostAnalyzerViewsXML, Fixture, methodGetCostAnalyzerViewsXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewsXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewsXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataInstance.GetCostAnalyzerViewsXML(out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewsXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewsXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetCostAnalyzerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCostAnalyzerViewsXML = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerViewsXML, methodGetCostAnalyzerViewsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, bool>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfGetCostAnalyzerViewsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodGetCostAnalyzerViewsXML, parametersOfGetCostAnalyzerViewsXML, methodGetCostAnalyzerViewsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCostAnalyzerViewsXML.ShouldNotBeNull();
            parametersOfGetCostAnalyzerViewsXML.Length.ShouldBe(1);
            methodGetCostAnalyzerViewsXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewsXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewsXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetCostAnalyzerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCostAnalyzerViewsXML = { sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerViewsXML, methodGetCostAnalyzerViewsXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, bool>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfGetCostAnalyzerViewsXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodGetCostAnalyzerViewsXML, parametersOfGetCostAnalyzerViewsXML, methodGetCostAnalyzerViewsXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCostAnalyzerViewsXML.ShouldNotBeNull();
            parametersOfGetCostAnalyzerViewsXML.Length.ShouldBe(1);
            methodGetCostAnalyzerViewsXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewsXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewsXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sReply = CreateType<string>();
            var methodGetCostAnalyzerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCostAnalyzerViewsXML = { sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodGetCostAnalyzerViewsXML, parametersOfGetCostAnalyzerViewsXML, methodGetCostAnalyzerViewsXMLPrametersTypes);

            // Assert
            parametersOfGetCostAnalyzerViewsXML.ShouldNotBeNull();
            parametersOfGetCostAnalyzerViewsXML.Length.ShouldBe(1);
            methodGetCostAnalyzerViewsXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewsXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewsXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCostAnalyzerViewsXMLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodGetCostAnalyzerViewsXML, Fixture, methodGetCostAnalyzerViewsXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCostAnalyzerViewsXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewsXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewsXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerViewsXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewsXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewsXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerViewsXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_GetCostAnalyzerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodGetCostAnalyzerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodGetCostAnalyzerViewXML, Fixture, methodGetCostAnalyzerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataInstance.GetCostAnalyzerViewXML(guidView, out sReply);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetCostAnalyzerViewXML = { guidView, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerViewXML, methodGetCostAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, bool>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfGetCostAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodGetCostAnalyzerViewXML, parametersOfGetCostAnalyzerViewXML, methodGetCostAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfGetCostAnalyzerViewXML.Length.ShouldBe(2);
            methodGetCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetCostAnalyzerViewXML = { guidView, sReply };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerViewXML, methodGetCostAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, bool>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfGetCostAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodGetCostAnalyzerViewXML, parametersOfGetCostAnalyzerViewXML, methodGetCostAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfGetCostAnalyzerViewXML.Length.ShouldBe(2);
            methodGetCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sReply = CreateType<string>();
            var methodGetCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfGetCostAnalyzerViewXML = { guidView, sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodGetCostAnalyzerViewXML, parametersOfGetCostAnalyzerViewXML, methodGetCostAnalyzerViewXMLPrametersTypes);

            // Assert
            parametersOfGetCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfGetCostAnalyzerViewXML.Length.ShouldBe(2);
            methodGetCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodGetCostAnalyzerViewXML, Fixture, methodGetCostAnalyzerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCostAnalyzerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_GetCostAnalyzerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCostAnalyzerViewXML, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCostAnalyzerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_SaveCostAnalyzerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodSaveCostAnalyzerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodSaveCostAnalyzerViewXML, Fixture, methodSaveCostAnalyzerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveCostAnalyzerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveCostAnalyzerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataInstance.SaveCostAnalyzerViewXML(guidView, sName, bPersonal, bDefault, sData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveCostAnalyzerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveCostAnalyzerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveCostAnalyzerViewXML = { guidView, sName, bPersonal, bDefault, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCostAnalyzerViewXML, methodSaveCostAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, bool>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfSaveCostAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodSaveCostAnalyzerViewXML, parametersOfSaveCostAnalyzerViewXML, methodSaveCostAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfSaveCostAnalyzerViewXML.Length.ShouldBe(5);
            methodSaveCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveCostAnalyzerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveCostAnalyzerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveCostAnalyzerViewXML = { guidView, sName, bPersonal, bDefault, sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSaveCostAnalyzerViewXML, methodSaveCostAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, bool>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfSaveCostAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodSaveCostAnalyzerViewXML, parametersOfSaveCostAnalyzerViewXML, methodSaveCostAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSaveCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfSaveCostAnalyzerViewXML.Length.ShouldBe(5);
            methodSaveCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (SaveCostAnalyzerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveCostAnalyzerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var bPersonal = CreateType<bool>();
            var bDefault = CreateType<bool>();
            var sData = CreateType<string>();
            var methodSaveCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            object[] parametersOfSaveCostAnalyzerViewXML = { guidView, sName, bPersonal, bDefault, sData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodSaveCostAnalyzerViewXML, parametersOfSaveCostAnalyzerViewXML, methodSaveCostAnalyzerViewXMLPrametersTypes);

            // Assert
            parametersOfSaveCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfSaveCostAnalyzerViewXML.Length.ShouldBe(5);
            methodSaveCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveCostAnalyzerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveCostAnalyzerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(bool), typeof(bool), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodSaveCostAnalyzerViewXML, Fixture, methodSaveCostAnalyzerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSaveCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveCostAnalyzerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveCostAnalyzerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveCostAnalyzerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveCostAnalyzerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveCostAnalyzerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveCostAnalyzerViewXML, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_DeleteCostAnalyzerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodDeleteCostAnalyzerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodDeleteCostAnalyzerViewXML, Fixture, methodDeleteCostAnalyzerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteCostAnalyzerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataInstance.DeleteCostAnalyzerViewXML(guidView);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteCostAnalyzerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var methodDeleteCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteCostAnalyzerViewXML = { guidView };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteCostAnalyzerViewXML, methodDeleteCostAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, bool>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfDeleteCostAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodDeleteCostAnalyzerViewXML, parametersOfDeleteCostAnalyzerViewXML, methodDeleteCostAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfDeleteCostAnalyzerViewXML.Length.ShouldBe(1);
            methodDeleteCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteCostAnalyzerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var methodDeleteCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteCostAnalyzerViewXML = { guidView };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDeleteCostAnalyzerViewXML, methodDeleteCostAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, bool>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfDeleteCostAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodDeleteCostAnalyzerViewXML, parametersOfDeleteCostAnalyzerViewXML, methodDeleteCostAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfDeleteCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfDeleteCostAnalyzerViewXML.Length.ShouldBe(1);
            methodDeleteCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteCostAnalyzerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var methodDeleteCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfDeleteCostAnalyzerViewXML = { guidView };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodDeleteCostAnalyzerViewXML, parametersOfDeleteCostAnalyzerViewXML, methodDeleteCostAnalyzerViewXMLPrametersTypes);

            // Assert
            parametersOfDeleteCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfDeleteCostAnalyzerViewXML.Length.ShouldBe(1);
            methodDeleteCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteCostAnalyzerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodDeleteCostAnalyzerViewXML, Fixture, methodDeleteCostAnalyzerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDeleteCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteCostAnalyzerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteCostAnalyzerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DeleteCostAnalyzerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteCostAnalyzerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteCostAnalyzerViewXML, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerViewXML) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_RenameCostAnalyzerViewXML_Method_Call_Internally(Type[] types)
        {
            var methodRenameCostAnalyzerViewXMLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodRenameCostAnalyzerViewXML, Fixture, methodRenameCostAnalyzerViewXMLPrametersTypes);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerViewXML) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_RenameCostAnalyzerViewXML_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataInstance.RenameCostAnalyzerViewXML(guidView, sName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerViewXML) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_RenameCostAnalyzerViewXML_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameCostAnalyzerViewXML = { guidView, sName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenameCostAnalyzerViewXML, methodRenameCostAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, bool>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfRenameCostAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodRenameCostAnalyzerViewXML, parametersOfRenameCostAnalyzerViewXML, methodRenameCostAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRenameCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfRenameCostAnalyzerViewXML.Length.ShouldBe(2);
            methodRenameCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerViewXML) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_RenameCostAnalyzerViewXML_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameCostAnalyzerViewXML = { guidView, sName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRenameCostAnalyzerViewXML, methodRenameCostAnalyzerViewXMLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, bool>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfRenameCostAnalyzerViewXML);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodRenameCostAnalyzerViewXML, parametersOfRenameCostAnalyzerViewXML, methodRenameCostAnalyzerViewXMLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRenameCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfRenameCostAnalyzerViewXML.Length.ShouldBe(2);
            methodRenameCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerViewXML) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_RenameCostAnalyzerViewXML_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var guidView = CreateType<Guid>();
            var sName = CreateType<string>();
            var methodRenameCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            object[] parametersOfRenameCostAnalyzerViewXML = { guidView, sName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, bool>(_costAnalyzerDataInstance, MethodRenameCostAnalyzerViewXML, parametersOfRenameCostAnalyzerViewXML, methodRenameCostAnalyzerViewXMLPrametersTypes);

            // Assert
            parametersOfRenameCostAnalyzerViewXML.ShouldNotBeNull();
            parametersOfRenameCostAnalyzerViewXML.Length.ShouldBe(2);
            methodRenameCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerViewXML) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_RenameCostAnalyzerViewXML_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenameCostAnalyzerViewXMLPrametersTypes = new Type[] { typeof(Guid), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodRenameCostAnalyzerViewXML, Fixture, methodRenameCostAnalyzerViewXMLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenameCostAnalyzerViewXMLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerViewXML) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_RenameCostAnalyzerViewXML_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenameCostAnalyzerViewXML, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenameCostAnalyzerViewXML) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_RenameCostAnalyzerViewXML_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenameCostAnalyzerViewXML, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_FormatSQLDateTime_Method_Call_Internally(Type[] types)
        {
            var methodFormatSQLDateTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodFormatSQLDateTime, Fixture, methodFormatSQLDateTimePrametersTypes);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_FormatSQLDateTime_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dt = CreateType<DateTime>();
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfFormatSQLDateTime = { dt };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodFormatSQLDateTime, methodFormatSQLDateTimePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, string>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfFormatSQLDateTime);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, string>(_costAnalyzerDataInstance, MethodFormatSQLDateTime, parametersOfFormatSQLDateTime, methodFormatSQLDateTimePrametersTypes);

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
        public void AUT_CostAnalyzerData_FormatSQLDateTime_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dt = CreateType<DateTime>();
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };
            object[] parametersOfFormatSQLDateTime = { dt };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, string>(_costAnalyzerDataInstance, MethodFormatSQLDateTime, parametersOfFormatSQLDateTime, methodFormatSQLDateTimePrametersTypes);

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
        public void AUT_CostAnalyzerData_FormatSQLDateTime_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodFormatSQLDateTime, Fixture, methodFormatSQLDateTimePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodFormatSQLDateTimePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_FormatSQLDateTime_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatSQLDateTimePrametersTypes = new Type[] { typeof(DateTime) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodFormatSQLDateTime, Fixture, methodFormatSQLDateTimePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatSQLDateTimePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_FormatSQLDateTime_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatSQLDateTime, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FormatSQLDateTime) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_FormatSQLDateTime_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (LoadTargets) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_LoadTargets_Method_Call_Internally(Type[] types)
        {
            var methodLoadTargetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodLoadTargets, Fixture, methodLoadTargetsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_LoadTargets_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var clscd = CreateType<clsCostData>();
            var methodLoadTargetsPrametersTypes = new Type[] { typeof(clsCostData) };
            object[] parametersOfLoadTargets = { clscd };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadTargets, methodLoadTargetsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, int>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfLoadTargets);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, int>(_costAnalyzerDataInstance, MethodLoadTargets, parametersOfLoadTargets, methodLoadTargetsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadTargets.ShouldNotBeNull();
            parametersOfLoadTargets.Length.ShouldBe(1);
            methodLoadTargetsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_LoadTargets_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var clscd = CreateType<clsCostData>();
            var methodLoadTargetsPrametersTypes = new Type[] { typeof(clsCostData) };
            object[] parametersOfLoadTargets = { clscd };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodLoadTargets, methodLoadTargetsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, int>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfLoadTargets);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, int>(_costAnalyzerDataInstance, MethodLoadTargets, parametersOfLoadTargets, methodLoadTargetsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfLoadTargets.ShouldNotBeNull();
            parametersOfLoadTargets.Length.ShouldBe(1);
            methodLoadTargetsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_LoadTargets_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var clscd = CreateType<clsCostData>();
            var methodLoadTargetsPrametersTypes = new Type[] { typeof(clsCostData) };
            object[] parametersOfLoadTargets = { clscd };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, int>(_costAnalyzerDataInstance, MethodLoadTargets, parametersOfLoadTargets, methodLoadTargetsPrametersTypes);

            // Assert
            parametersOfLoadTargets.ShouldNotBeNull();
            parametersOfLoadTargets.Length.ShouldBe(1);
            methodLoadTargetsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_LoadTargets_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadTargetsPrametersTypes = new Type[] { typeof(clsCostData) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodLoadTargets, Fixture, methodLoadTargetsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodLoadTargetsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_LoadTargets_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadTargets, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (LoadTargets) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_LoadTargets_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadTargets, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_DeleteTarget_Method_Call_Internally(Type[] types)
        {
            var methodDeleteTargetPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodDeleteTarget, Fixture, methodDeleteTargetPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteTarget_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var iTarget = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataInstance.DeleteTarget(iTarget);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteTarget_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var iTarget = CreateType<int>();
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteTarget = { iTarget };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteTarget, methodDeleteTargetPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfDeleteTarget);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteTarget.ShouldNotBeNull();
            parametersOfDeleteTarget.Length.ShouldBe(1);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(1);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(parametersOfDeleteTarget.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteTarget_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var iTarget = CreateType<int>();
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfDeleteTarget = { iTarget };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodDeleteTarget, parametersOfDeleteTarget, methodDeleteTargetPrametersTypes);

            // Assert
            parametersOfDeleteTarget.ShouldNotBeNull();
            parametersOfDeleteTarget.Length.ShouldBe(1);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(1);
            methodDeleteTargetPrametersTypes.Length.ShouldBe(parametersOfDeleteTarget.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteTarget_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteTarget, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteTarget_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteTargetPrametersTypes = new Type[] { typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodDeleteTarget, Fixture, methodDeleteTargetPrametersTypes);

            // Assert
            methodDeleteTargetPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteTarget) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_DeleteTarget_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteTarget, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_SaveTargetData_Method_Call_Internally(Type[] types)
        {
            var methodSaveTargetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodSaveTargetData, Fixture, methodSaveTargetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveTargetData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var CB_ID = CreateType<int>();
            var targetID = CreateType<int>();
            var sTargetName = CreateType<string>();
            var bNewTarget = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataInstance.SaveTargetData(sXML, CB_ID, out targetID, out sTargetName, out bNewTarget);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveTargetData_Method_Call_Void_With_5_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var CB_ID = CreateType<int>();
            var targetID = CreateType<int>();
            var sTargetName = CreateType<string>();
            var bNewTarget = CreateType<bool>();
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int), typeof(string), typeof(bool) };
            object[] parametersOfSaveTargetData = { sXML, CB_ID, targetID, sTargetName, bNewTarget };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveTargetData, methodSaveTargetDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_costAnalyzerDataInstanceFixture, parametersOfSaveTargetData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveTargetData.ShouldNotBeNull();
            parametersOfSaveTargetData.Length.ShouldBe(5);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(5);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(parametersOfSaveTargetData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveTargetData_Method_Call_Void_With_5_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sXML = CreateType<string>();
            var CB_ID = CreateType<int>();
            var targetID = CreateType<int>();
            var sTargetName = CreateType<string>();
            var bNewTarget = CreateType<bool>();
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int), typeof(string), typeof(bool) };
            object[] parametersOfSaveTargetData = { sXML, CB_ID, targetID, sTargetName, bNewTarget };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_costAnalyzerDataInstance, MethodSaveTargetData, parametersOfSaveTargetData, methodSaveTargetDataPrametersTypes);

            // Assert
            parametersOfSaveTargetData.ShouldNotBeNull();
            parametersOfSaveTargetData.Length.ShouldBe(5);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(5);
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(parametersOfSaveTargetData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveTargetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveTargetData, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveTargetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveTargetDataPrametersTypes = new Type[] { typeof(string), typeof(int), typeof(int), typeof(string), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodSaveTargetData, Fixture, methodSaveTargetDataPrametersTypes);

            // Assert
            methodSaveTargetDataPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveTargetData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_SaveTargetData_Method_Call_With_5_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveTargetData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReloadTargets) (Return Type : clsCostData) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_CostAnalyzerData_ReloadTargets_Method_Call_Internally(Type[] types)
        {
            var methodReloadTargetsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReloadTargets, Fixture, methodReloadTargetsPrametersTypes);
        }

        #endregion

        #region Method Call : (ReloadTargets) (Return Type : clsCostData) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReloadTargets_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var CB_ID = CreateType<int>();
            var max_period = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _costAnalyzerDataInstance.ReloadTargets(CB_ID, max_period);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ReloadTargets) (Return Type : clsCostData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReloadTargets_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var CB_ID = CreateType<int>();
            var max_period = CreateType<int>();
            var methodReloadTargetsPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfReloadTargets = { CB_ID, max_period };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodReloadTargets, methodReloadTargetsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<CostAnalyzerData, clsCostData>(_costAnalyzerDataInstanceFixture, out exception1, parametersOfReloadTargets);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, clsCostData>(_costAnalyzerDataInstance, MethodReloadTargets, parametersOfReloadTargets, methodReloadTargetsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfReloadTargets.ShouldNotBeNull();
            parametersOfReloadTargets.Length.ShouldBe(2);
            methodReloadTargetsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReloadTargets) (Return Type : clsCostData) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReloadTargets_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var CB_ID = CreateType<int>();
            var max_period = CreateType<int>();
            var methodReloadTargetsPrametersTypes = new Type[] { typeof(int), typeof(int) };
            object[] parametersOfReloadTargets = { CB_ID, max_period };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<CostAnalyzerData, clsCostData>(_costAnalyzerDataInstance, MethodReloadTargets, parametersOfReloadTargets, methodReloadTargetsPrametersTypes);

            // Assert
            parametersOfReloadTargets.ShouldNotBeNull();
            parametersOfReloadTargets.Length.ShouldBe(2);
            methodReloadTargetsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReloadTargets) (Return Type : clsCostData) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReloadTargets_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReloadTargetsPrametersTypes = new Type[] { typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReloadTargets, Fixture, methodReloadTargetsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReloadTargetsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ReloadTargets) (Return Type : clsCostData) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReloadTargets_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReloadTargetsPrametersTypes = new Type[] { typeof(int), typeof(int) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_costAnalyzerDataInstance, MethodReloadTargets, Fixture, methodReloadTargetsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReloadTargetsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReloadTargets) (Return Type : clsCostData) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReloadTargets_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReloadTargets, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_costAnalyzerDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReloadTargets) (Return Type : clsCostData) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_CostAnalyzerData_ReloadTargets_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReloadTargets, 0);
            const int parametersCount = 2;

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