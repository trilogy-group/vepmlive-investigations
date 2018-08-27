using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.ReportHelper
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportHelper.MyWorkReportData" />)
    ///     and namespace <see cref="EPMLiveCore.ReportHelper"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class MyWorkReportDataTest : AbstractBaseSetupTypedTest<MyWorkReportData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MyWorkReportData) Initializer

        private const string MethodExecuteEpmLiveSql = "ExecuteEpmLiveSql";
        private const string MethodExecuteSql = "ExecuteSql";
        private const string MethodGetData = "GetData";
        private const string MethodGetFields = "GetFields";
        private const string MethodInsertSQL = "InsertSQL";
        private const string MethodAddColumnValues = "AddColumnValues";
        private const string MethodBuildSelectSql = "BuildSelectSql";
        private const string MethodIsLookUpField = "IsLookUpField";
        private const string MethodPopulateDefaultColumnValue = "PopulateDefaultColumnValue";
        private const string MethodPopulateMandatoryHiddenFldsColumnValue = "PopulateMandatoryHiddenFldsColumnValue";
        private const string MethodAddMetaInfoCols = "AddMetaInfoCols";
        private const string MethodGetColumnType = "GetColumnType";
        private const string MethodLogError = "LogError";
        private Type _myWorkReportDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MyWorkReportData _myWorkReportDataInstance;
        private MyWorkReportData _myWorkReportDataInstanceFixture;

        #region General Initializer : Class (MyWorkReportData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MyWorkReportData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _myWorkReportDataInstanceType = typeof(MyWorkReportData);
            _myWorkReportDataInstanceFixture = Create(true);
            _myWorkReportDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MyWorkReportData)

        #region General Initializer : Class (MyWorkReportData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MyWorkReportData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodExecuteEpmLiveSql, 0)]
        [TestCase(MethodExecuteSql, 0)]
        [TestCase(MethodGetData, 0)]
        [TestCase(MethodGetFields, 0)]
        [TestCase(MethodInsertSQL, 0)]
        [TestCase(MethodAddColumnValues, 0)]
        [TestCase(MethodBuildSelectSql, 0)]
        [TestCase(MethodIsLookUpField, 0)]
        [TestCase(MethodPopulateDefaultColumnValue, 0)]
        [TestCase(MethodPopulateMandatoryHiddenFldsColumnValue, 0)]
        [TestCase(MethodAddMetaInfoCols, 0)]
        [TestCase(MethodGetColumnType, 0)]
        [TestCase(MethodLogError, 0)]
        public void AUT_MyWorkReportData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_myWorkReportDataInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MyWorkReportData) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="MyWorkReportData" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void AUT_MyWorkReportData_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<MyWorkReportData>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (MyWorkReportData) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="MyWorkReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_MyWorkReportData_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<MyWorkReportData>(Fixture);
        }

        #endregion

        #region General Constructor : Class (MyWorkReportData) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="MyWorkReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_MyWorkReportData_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var name = CreateType<string>();
            var server = CreateType<string>();
            var useSAccount = CreateType<bool>();
            var username = CreateType<string>();
            var password = CreateType<string>();
            object[] parametersOfMyWorkReportData = { siteId, name, server, useSAccount, username, password };
            var methodMyWorkReportDataPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(bool), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_myWorkReportDataInstanceType, methodMyWorkReportDataPrametersTypes, parametersOfMyWorkReportData);
        }

        #endregion

        #region General Constructor : Class (MyWorkReportData) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="MyWorkReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_MyWorkReportData_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodMyWorkReportDataPrametersTypes = new Type[] { typeof(Guid), typeof(string), typeof(string), typeof(bool), typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_myWorkReportDataInstanceType, Fixture, methodMyWorkReportDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (MyWorkReportData) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="MyWorkReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_MyWorkReportData_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            object[] parametersOfMyWorkReportData = { siteId, webAppId };
            var methodMyWorkReportDataPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_myWorkReportDataInstanceType, methodMyWorkReportDataPrametersTypes, parametersOfMyWorkReportData);
        }

        #endregion

        #region General Constructor : Class (MyWorkReportData) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="MyWorkReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_MyWorkReportData_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodMyWorkReportDataPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_myWorkReportDataInstanceType, Fixture, methodMyWorkReportDataPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (MyWorkReportData) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="MyWorkReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_MyWorkReportData_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            object[] parametersOfMyWorkReportData = { siteId };
            var methodMyWorkReportDataPrametersTypes = new Type[] { typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_myWorkReportDataInstanceType, methodMyWorkReportDataPrametersTypes, parametersOfMyWorkReportData);
        }

        #endregion

        #region General Constructor : Class (MyWorkReportData) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="MyWorkReportData" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_MyWorkReportData_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodMyWorkReportDataPrametersTypes = new Type[] { typeof(Guid) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_myWorkReportDataInstanceType, Fixture, methodMyWorkReportDataPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="MyWorkReportData" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodExecuteEpmLiveSql)]
        [TestCase(MethodExecuteSql)]
        [TestCase(MethodGetData)]
        [TestCase(MethodGetFields)]
        [TestCase(MethodInsertSQL)]
        [TestCase(MethodAddColumnValues)]
        [TestCase(MethodBuildSelectSql)]
        [TestCase(MethodIsLookUpField)]
        [TestCase(MethodPopulateDefaultColumnValue)]
        [TestCase(MethodPopulateMandatoryHiddenFldsColumnValue)]
        [TestCase(MethodAddMetaInfoCols)]
        [TestCase(MethodGetColumnType)]
        [TestCase(MethodLogError)]
        public void AUT_MyWorkReportData_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<MyWorkReportData>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveSql) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_ExecuteEpmLiveSql_Method_Call_Internally(Type[] types)
        {
            var methodExecuteEpmLiveSqlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodExecuteEpmLiveSql, Fixture, methodExecuteEpmLiveSqlPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveSql) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteEpmLiveSql_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sql = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _myWorkReportDataInstance.ExecuteEpmLiveSql(sql);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveSql) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteEpmLiveSql_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sql = CreateType<string>();
            var methodExecuteEpmLiveSqlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfExecuteEpmLiveSql = { sql };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveSql, methodExecuteEpmLiveSqlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, DataTable>(_myWorkReportDataInstanceFixture, out exception1, parametersOfExecuteEpmLiveSql);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, DataTable>(_myWorkReportDataInstance, MethodExecuteEpmLiveSql, parametersOfExecuteEpmLiveSql, methodExecuteEpmLiveSqlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteEpmLiveSql.ShouldNotBeNull();
            parametersOfExecuteEpmLiveSql.Length.ShouldBe(1);
            methodExecuteEpmLiveSqlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveSql) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteEpmLiveSql_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sql = CreateType<string>();
            var methodExecuteEpmLiveSqlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfExecuteEpmLiveSql = { sql };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, DataTable>(_myWorkReportDataInstance, MethodExecuteEpmLiveSql, parametersOfExecuteEpmLiveSql, methodExecuteEpmLiveSqlPrametersTypes);

            // Assert
            parametersOfExecuteEpmLiveSql.ShouldNotBeNull();
            parametersOfExecuteEpmLiveSql.Length.ShouldBe(1);
            methodExecuteEpmLiveSqlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveSql) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteEpmLiveSql_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteEpmLiveSqlPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodExecuteEpmLiveSql, Fixture, methodExecuteEpmLiveSqlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteEpmLiveSqlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveSql) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteEpmLiveSql_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteEpmLiveSqlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodExecuteEpmLiveSql, Fixture, methodExecuteEpmLiveSqlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteEpmLiveSqlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveSql) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteEpmLiveSql_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveSql, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveSql) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteEpmLiveSql_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveSql, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteSql) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_ExecuteSql_Method_Call_Internally(Type[] types)
        {
            var methodExecuteSqlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodExecuteSql, Fixture, methodExecuteSqlPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteSql) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteSql_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sql = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _myWorkReportDataInstance.ExecuteSql(sql);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteSql) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteSql_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sql = CreateType<string>();
            var methodExecuteSqlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfExecuteSql = { sql };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteSql, methodExecuteSqlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, DataTable>(_myWorkReportDataInstanceFixture, out exception1, parametersOfExecuteSql);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, DataTable>(_myWorkReportDataInstance, MethodExecuteSql, parametersOfExecuteSql, methodExecuteSqlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteSql.ShouldNotBeNull();
            parametersOfExecuteSql.Length.ShouldBe(1);
            methodExecuteSqlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteSql) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteSql_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sql = CreateType<string>();
            var methodExecuteSqlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfExecuteSql = { sql };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, DataTable>(_myWorkReportDataInstance, MethodExecuteSql, parametersOfExecuteSql, methodExecuteSqlPrametersTypes);

            // Assert
            parametersOfExecuteSql.ShouldNotBeNull();
            parametersOfExecuteSql.Length.ShouldBe(1);
            methodExecuteSqlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteSql) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteSql_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteSqlPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodExecuteSql, Fixture, methodExecuteSqlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteSqlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteSql) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteSql_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteSqlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodExecuteSql, Fixture, methodExecuteSqlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteSqlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteSql) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteSql_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteSql, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteSql) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_ExecuteSql_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteSql, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_GetData_Method_Call_Internally(Type[] types)
        {
            var methodGetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var filterValues = CreateType<Dictionary<string, IEnumerable<object>>>();
            var reportingScope = CreateType<ReportingScope>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _myWorkReportDataInstance.GetData(filterValues, reportingScope, spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var filterValues = CreateType<Dictionary<string, IEnumerable<object>>>();
            var reportingScope = CreateType<ReportingScope>();
            var spWeb = CreateType<SPWeb>();
            var methodGetDataPrametersTypes = new Type[] { typeof(Dictionary<string, IEnumerable<object>>), typeof(ReportingScope), typeof(SPWeb) };
            object[] parametersOfGetData = { filterValues, reportingScope, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetData, methodGetDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, DataTable>(_myWorkReportDataInstanceFixture, out exception1, parametersOfGetData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, DataTable>(_myWorkReportDataInstance, MethodGetData, parametersOfGetData, methodGetDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetData.ShouldNotBeNull();
            parametersOfGetData.Length.ShouldBe(3);
            methodGetDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var filterValues = CreateType<Dictionary<string, IEnumerable<object>>>();
            var reportingScope = CreateType<ReportingScope>();
            var spWeb = CreateType<SPWeb>();
            var methodGetDataPrametersTypes = new Type[] { typeof(Dictionary<string, IEnumerable<object>>), typeof(ReportingScope), typeof(SPWeb) };
            object[] parametersOfGetData = { filterValues, reportingScope, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, DataTable>(_myWorkReportDataInstance, MethodGetData, parametersOfGetData, methodGetDataPrametersTypes);

            // Assert
            parametersOfGetData.ShouldNotBeNull();
            parametersOfGetData.Length.ShouldBe(3);
            methodGetDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDataPrametersTypes = new Type[] { typeof(Dictionary<string, IEnumerable<object>>), typeof(ReportingScope), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataPrametersTypes = new Type[] { typeof(Dictionary<string, IEnumerable<object>>), typeof(ReportingScope), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodGetData, Fixture, methodGetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_GetFields_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodGetFields, Fixture, methodGetFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : List<string>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetFields_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _myWorkReportDataInstance.GetFields();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFieldsPrametersTypes = null;
            object[] parametersOfGetFields = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFields, methodGetFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, List<string>>(_myWorkReportDataInstanceFixture, out exception1, parametersOfGetFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, List<string>>(_myWorkReportDataInstance, MethodGetFields, parametersOfGetFields, methodGetFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFields.ShouldBeNull();
            methodGetFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFieldsPrametersTypes = null;
            object[] parametersOfGetFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, List<string>>(_myWorkReportDataInstance, MethodGetFields, parametersOfGetFields, methodGetFieldsPrametersTypes);

            // Assert
            parametersOfGetFields.ShouldBeNull();
            methodGetFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFieldsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodGetFields, Fixture, methodGetFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFieldsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodGetFields, Fixture, methodGetFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFields) (Return Type : List<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_InsertSQL_Method_Call_Internally(Type[] types)
        {
            var methodInsertSQLPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodInsertSQL, Fixture, methodInsertSQLPrametersTypes);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_InsertSQL_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var listName = CreateType<string>();
            var columns = CreateType<DataTable>();
            var spListItem = CreateType<SPListItem>();
            var defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            Action executeAction = null;

            // Act
            executeAction = () => _myWorkReportDataInstance.InsertSQL(tableName, listName, columns, spListItem, defaultColumns, mandatoryHiddenFlds);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_InsertSQL_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var listName = CreateType<string>();
            var columns = CreateType<DataTable>();
            var spListItem = CreateType<SPListItem>();
            var defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var methodInsertSQLPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };
            object[] parametersOfInsertSQL = { tableName, listName, columns, spListItem, defaultColumns, mandatoryHiddenFlds };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodInsertSQL, methodInsertSQLPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, string>(_myWorkReportDataInstanceFixture, out exception1, parametersOfInsertSQL);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, string>(_myWorkReportDataInstance, MethodInsertSQL, parametersOfInsertSQL, methodInsertSQLPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfInsertSQL.ShouldNotBeNull();
            parametersOfInsertSQL.Length.ShouldBe(6);
            methodInsertSQLPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_InsertSQL_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var tableName = CreateType<string>();
            var listName = CreateType<string>();
            var columns = CreateType<DataTable>();
            var spListItem = CreateType<SPListItem>();
            var defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var methodInsertSQLPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };
            object[] parametersOfInsertSQL = { tableName, listName, columns, spListItem, defaultColumns, mandatoryHiddenFlds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, string>(_myWorkReportDataInstance, MethodInsertSQL, parametersOfInsertSQL, methodInsertSQLPrametersTypes);

            // Assert
            parametersOfInsertSQL.ShouldNotBeNull();
            parametersOfInsertSQL.Length.ShouldBe(6);
            methodInsertSQLPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_InsertSQL_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodInsertSQLPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodInsertSQL, Fixture, methodInsertSQLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodInsertSQLPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_InsertSQL_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInsertSQLPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(DataTable), typeof(SPListItem), typeof(ArrayList), typeof(ArrayList) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodInsertSQL, Fixture, methodInsertSQLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodInsertSQLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_InsertSQL_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInsertSQL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (InsertSQL) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_InsertSQL_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInsertSQL, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_AddColumnValues_Method_Call_Internally(Type[] types)
        {
            var methodAddColumnValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodAddColumnValues, Fixture, methodAddColumnValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddColumnValues_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spListItem = CreateType<SPListItem>();
            var columns = CreateType<DataTable>();
            var defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var operation = CreateType<string>();
            var sAssignedToText = CreateType<string>();
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string), typeof(string) };
            object[] parametersOfAddColumnValues = { spListItem, columns, defaultColumns, mandatoryHiddenFlds, operation, sAssignedToText };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddColumnValues, methodAddColumnValuesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, string>(_myWorkReportDataInstanceFixture, out exception1, parametersOfAddColumnValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, string>(_myWorkReportDataInstance, MethodAddColumnValues, parametersOfAddColumnValues, methodAddColumnValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddColumnValues.ShouldNotBeNull();
            parametersOfAddColumnValues.Length.ShouldBe(6);
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddColumnValues_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spListItem = CreateType<SPListItem>();
            var columns = CreateType<DataTable>();
            var defaultColumns = CreateType<ArrayList>();
            var mandatoryHiddenFlds = CreateType<ArrayList>();
            var operation = CreateType<string>();
            var sAssignedToText = CreateType<string>();
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string), typeof(string) };
            object[] parametersOfAddColumnValues = { spListItem, columns, defaultColumns, mandatoryHiddenFlds, operation, sAssignedToText };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, string>(_myWorkReportDataInstance, MethodAddColumnValues, parametersOfAddColumnValues, methodAddColumnValuesPrametersTypes);

            // Assert
            parametersOfAddColumnValues.ShouldNotBeNull();
            parametersOfAddColumnValues.Length.ShouldBe(6);
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddColumnValues_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodAddColumnValues, Fixture, methodAddColumnValuesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddColumnValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnValuesPrametersTypes = new Type[] { typeof(SPListItem), typeof(DataTable), typeof(ArrayList), typeof(ArrayList), typeof(string), typeof(string) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodAddColumnValues, Fixture, methodAddColumnValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddColumnValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddColumnValues_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumnValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddColumnValues) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddColumnValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumnValues, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildSelectSql) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_BuildSelectSql_Method_Call_Internally(Type[] types)
        {
            var methodBuildSelectSqlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodBuildSelectSql, Fixture, methodBuildSelectSqlPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildSelectSql) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_BuildSelectSql_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var filterValues = CreateType<Dictionary<string, IEnumerable<object>>>();
            var reportingScope = CreateType<ReportingScope>();
            var spWeb = CreateType<SPWeb>();
            var methodBuildSelectSqlPrametersTypes = new Type[] { typeof(Dictionary<string, IEnumerable<object>>), typeof(ReportingScope), typeof(SPWeb) };
            object[] parametersOfBuildSelectSql = { filterValues, reportingScope, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildSelectSql, methodBuildSelectSqlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, string>(_myWorkReportDataInstanceFixture, out exception1, parametersOfBuildSelectSql);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, string>(_myWorkReportDataInstance, MethodBuildSelectSql, parametersOfBuildSelectSql, methodBuildSelectSqlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildSelectSql.ShouldNotBeNull();
            parametersOfBuildSelectSql.Length.ShouldBe(3);
            methodBuildSelectSqlPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (BuildSelectSql) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_BuildSelectSql_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var filterValues = CreateType<Dictionary<string, IEnumerable<object>>>();
            var reportingScope = CreateType<ReportingScope>();
            var spWeb = CreateType<SPWeb>();
            var methodBuildSelectSqlPrametersTypes = new Type[] { typeof(Dictionary<string, IEnumerable<object>>), typeof(ReportingScope), typeof(SPWeb) };
            object[] parametersOfBuildSelectSql = { filterValues, reportingScope, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, string>(_myWorkReportDataInstance, MethodBuildSelectSql, parametersOfBuildSelectSql, methodBuildSelectSqlPrametersTypes);

            // Assert
            parametersOfBuildSelectSql.ShouldNotBeNull();
            parametersOfBuildSelectSql.Length.ShouldBe(3);
            methodBuildSelectSqlPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildSelectSql) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_BuildSelectSql_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildSelectSqlPrametersTypes = new Type[] { typeof(Dictionary<string, IEnumerable<object>>), typeof(ReportingScope), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodBuildSelectSql, Fixture, methodBuildSelectSqlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildSelectSqlPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (BuildSelectSql) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_BuildSelectSql_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildSelectSqlPrametersTypes = new Type[] { typeof(Dictionary<string, IEnumerable<object>>), typeof(ReportingScope), typeof(SPWeb) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodBuildSelectSql, Fixture, methodBuildSelectSqlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildSelectSqlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildSelectSql) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_BuildSelectSql_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildSelectSql, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildSelectSql) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_BuildSelectSql_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildSelectSql, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_IsLookUpField_Method_Call_Internally(Type[] types)
        {
            var methodIsLookUpFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodIsLookUpField, Fixture, methodIsLookUpFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_IsLookUpField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var columnName = CreateType<string>();
            var methodIsLookUpFieldPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfIsLookUpField = { listName, columnName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLookUpField, methodIsLookUpFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, bool>(_myWorkReportDataInstanceFixture, out exception1, parametersOfIsLookUpField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, bool>(_myWorkReportDataInstance, MethodIsLookUpField, parametersOfIsLookUpField, methodIsLookUpFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLookUpField.ShouldNotBeNull();
            parametersOfIsLookUpField.Length.ShouldBe(2);
            methodIsLookUpFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_IsLookUpField_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var columnName = CreateType<string>();
            var methodIsLookUpFieldPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfIsLookUpField = { listName, columnName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLookUpField, methodIsLookUpFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, bool>(_myWorkReportDataInstanceFixture, out exception1, parametersOfIsLookUpField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, bool>(_myWorkReportDataInstance, MethodIsLookUpField, parametersOfIsLookUpField, methodIsLookUpFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLookUpField.ShouldNotBeNull();
            parametersOfIsLookUpField.Length.ShouldBe(2);
            methodIsLookUpFieldPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_IsLookUpField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var columnName = CreateType<string>();
            var methodIsLookUpFieldPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfIsLookUpField = { listName, columnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, bool>(_myWorkReportDataInstance, MethodIsLookUpField, parametersOfIsLookUpField, methodIsLookUpFieldPrametersTypes);

            // Assert
            parametersOfIsLookUpField.ShouldNotBeNull();
            parametersOfIsLookUpField.Length.ShouldBe(2);
            methodIsLookUpFieldPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_IsLookUpField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsLookUpFieldPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodIsLookUpField, Fixture, methodIsLookUpFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsLookUpFieldPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_IsLookUpField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsLookUpField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLookUpField) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_IsLookUpField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsLookUpField, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_PopulateDefaultColumnValue_Method_Call_Internally(Type[] types)
        {
            var methodPopulateDefaultColumnValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodPopulateDefaultColumnValue, Fixture, methodPopulateDefaultColumnValuePrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateDefaultColumnValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sColumn = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodPopulateDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            object[] parametersOfPopulateDefaultColumnValue = { sColumn, li };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPopulateDefaultColumnValue, methodPopulateDefaultColumnValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, SqlParameter>(_myWorkReportDataInstanceFixture, out exception1, parametersOfPopulateDefaultColumnValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, SqlParameter>(_myWorkReportDataInstance, MethodPopulateDefaultColumnValue, parametersOfPopulateDefaultColumnValue, methodPopulateDefaultColumnValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPopulateDefaultColumnValue.ShouldNotBeNull();
            parametersOfPopulateDefaultColumnValue.Length.ShouldBe(2);
            methodPopulateDefaultColumnValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateDefaultColumnValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sColumn = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodPopulateDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            object[] parametersOfPopulateDefaultColumnValue = { sColumn, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, SqlParameter>(_myWorkReportDataInstance, MethodPopulateDefaultColumnValue, parametersOfPopulateDefaultColumnValue, methodPopulateDefaultColumnValuePrametersTypes);

            // Assert
            parametersOfPopulateDefaultColumnValue.ShouldNotBeNull();
            parametersOfPopulateDefaultColumnValue.Length.ShouldBe(2);
            methodPopulateDefaultColumnValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateDefaultColumnValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPopulateDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodPopulateDefaultColumnValue, Fixture, methodPopulateDefaultColumnValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPopulateDefaultColumnValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateDefaultColumnValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateDefaultColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodPopulateDefaultColumnValue, Fixture, methodPopulateDefaultColumnValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPopulateDefaultColumnValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateDefaultColumnValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateDefaultColumnValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PopulateDefaultColumnValue) (Return Type : SqlParameter) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateDefaultColumnValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateDefaultColumnValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_Internally(Type[] types)
        {
            var methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodPopulateMandatoryHiddenFldsColumnValue, Fixture, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sColumn = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            object[] parametersOfPopulateMandatoryHiddenFldsColumnValue = { sColumn, li };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPopulateMandatoryHiddenFldsColumnValue, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, SqlParameter>(_myWorkReportDataInstanceFixture, out exception1, parametersOfPopulateMandatoryHiddenFldsColumnValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, SqlParameter>(_myWorkReportDataInstance, MethodPopulateMandatoryHiddenFldsColumnValue, parametersOfPopulateMandatoryHiddenFldsColumnValue, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPopulateMandatoryHiddenFldsColumnValue.ShouldNotBeNull();
            parametersOfPopulateMandatoryHiddenFldsColumnValue.Length.ShouldBe(2);
            methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sColumn = CreateType<string>();
            var li = CreateType<SPListItem>();
            var methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            object[] parametersOfPopulateMandatoryHiddenFldsColumnValue = { sColumn, li };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, SqlParameter>(_myWorkReportDataInstance, MethodPopulateMandatoryHiddenFldsColumnValue, parametersOfPopulateMandatoryHiddenFldsColumnValue, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes);

            // Assert
            parametersOfPopulateMandatoryHiddenFldsColumnValue.ShouldNotBeNull();
            parametersOfPopulateMandatoryHiddenFldsColumnValue.Length.ShouldBe(2);
            methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodPopulateMandatoryHiddenFldsColumnValue, Fixture, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes = new Type[] { typeof(string), typeof(SPListItem) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodPopulateMandatoryHiddenFldsColumnValue, Fixture, methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPopulateMandatoryHiddenFldsColumnValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateMandatoryHiddenFldsColumnValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PopulateMandatoryHiddenFldsColumnValue) (Return Type : SqlParameter) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_PopulateMandatoryHiddenFldsColumnValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateMandatoryHiddenFldsColumnValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_AddMetaInfoCols_Method_Call_Internally(Type[] types)
        {
            var methodAddMetaInfoColsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodAddMetaInfoCols, Fixture, methodAddMetaInfoColsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddMetaInfoCols_Method_Call_Void_With_4_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var spListItem = CreateType<SPListItem>();
            var cols = CreateType<string>();
            var values = CreateType<string>();
            var methodAddMetaInfoColsPrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(string), typeof(string) };
            object[] parametersOfAddMetaInfoCols = { listName, spListItem, cols, values };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddMetaInfoCols, methodAddMetaInfoColsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkReportDataInstanceFixture, parametersOfAddMetaInfoCols);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddMetaInfoCols.ShouldNotBeNull();
            parametersOfAddMetaInfoCols.Length.ShouldBe(4);
            methodAddMetaInfoColsPrametersTypes.Length.ShouldBe(4);
            methodAddMetaInfoColsPrametersTypes.Length.ShouldBe(parametersOfAddMetaInfoCols.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddMetaInfoCols_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var spListItem = CreateType<SPListItem>();
            var cols = CreateType<string>();
            var values = CreateType<string>();
            var methodAddMetaInfoColsPrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(string), typeof(string) };
            object[] parametersOfAddMetaInfoCols = { listName, spListItem, cols, values };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myWorkReportDataInstance, MethodAddMetaInfoCols, parametersOfAddMetaInfoCols, methodAddMetaInfoColsPrametersTypes);

            // Assert
            parametersOfAddMetaInfoCols.ShouldNotBeNull();
            parametersOfAddMetaInfoCols.Length.ShouldBe(4);
            methodAddMetaInfoColsPrametersTypes.Length.ShouldBe(4);
            methodAddMetaInfoColsPrametersTypes.Length.ShouldBe(parametersOfAddMetaInfoCols.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddMetaInfoCols_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddMetaInfoCols, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddMetaInfoCols_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddMetaInfoColsPrametersTypes = new Type[] { typeof(string), typeof(SPListItem), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodAddMetaInfoCols, Fixture, methodAddMetaInfoColsPrametersTypes);

            // Assert
            methodAddMetaInfoColsPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddMetaInfoCols) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_AddMetaInfoCols_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddMetaInfoCols, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnType) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_GetColumnType_Method_Call_Internally(Type[] types)
        {
            var methodGetColumnTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodGetColumnType, Fixture, methodGetColumnTypePrametersTypes);
        }

        #endregion

        #region Method Call : (GetColumnType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetColumnType_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var columnName = CreateType<string>();
            var methodGetColumnTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetColumnType = { columnName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetColumnType, methodGetColumnTypePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MyWorkReportData, string>(_myWorkReportDataInstanceFixture, out exception1, parametersOfGetColumnType);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, string>(_myWorkReportDataInstance, MethodGetColumnType, parametersOfGetColumnType, methodGetColumnTypePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetColumnType.ShouldNotBeNull();
            parametersOfGetColumnType.Length.ShouldBe(1);
            methodGetColumnTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetColumnType) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetColumnType_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var columnName = CreateType<string>();
            var methodGetColumnTypePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetColumnType = { columnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MyWorkReportData, string>(_myWorkReportDataInstance, MethodGetColumnType, parametersOfGetColumnType, methodGetColumnTypePrametersTypes);

            // Assert
            parametersOfGetColumnType.ShouldNotBeNull();
            parametersOfGetColumnType.Length.ShouldBe(1);
            methodGetColumnTypePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColumnType) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetColumnType_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetColumnTypePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodGetColumnType, Fixture, methodGetColumnTypePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetColumnTypePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetColumnType) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetColumnType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetColumnTypePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodGetColumnType, Fixture, methodGetColumnTypePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColumnTypePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColumnType) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetColumnType_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetColumnType, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetColumnType) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_GetColumnType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetColumnType, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MyWorkReportData_LogError_Method_Call_Internally(Type[] types)
        {
            var methodLogErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodLogError, Fixture, methodLogErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_LogError_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var ex = CreateType<Exception>();
            var columnName = CreateType<string>();
            var methodLogErrorPrametersTypes = new Type[] { typeof(string), typeof(Exception), typeof(string) };
            object[] parametersOfLogError = { internalName, ex, columnName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLogError, methodLogErrorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_myWorkReportDataInstanceFixture, parametersOfLogError);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLogError.ShouldNotBeNull();
            parametersOfLogError.Length.ShouldBe(3);
            methodLogErrorPrametersTypes.Length.ShouldBe(3);
            methodLogErrorPrametersTypes.Length.ShouldBe(parametersOfLogError.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_LogError_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var ex = CreateType<Exception>();
            var columnName = CreateType<string>();
            var methodLogErrorPrametersTypes = new Type[] { typeof(string), typeof(Exception), typeof(string) };
            object[] parametersOfLogError = { internalName, ex, columnName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_myWorkReportDataInstance, MethodLogError, parametersOfLogError, methodLogErrorPrametersTypes);

            // Assert
            parametersOfLogError.ShouldNotBeNull();
            parametersOfLogError.Length.ShouldBe(3);
            methodLogErrorPrametersTypes.Length.ShouldBe(3);
            methodLogErrorPrametersTypes.Length.ShouldBe(parametersOfLogError.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_LogError_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLogError, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_LogError_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLogErrorPrametersTypes = new Type[] { typeof(string), typeof(Exception), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_myWorkReportDataInstance, MethodLogError, Fixture, methodLogErrorPrametersTypes);

            // Assert
            methodLogErrorPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LogError) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_MyWorkReportData_LogError_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLogError, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_myWorkReportDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}