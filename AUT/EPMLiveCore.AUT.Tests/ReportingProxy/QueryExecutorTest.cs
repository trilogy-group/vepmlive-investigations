using System;
using System.Collections.Generic;
using System.Data;
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

namespace EPMLiveCore.ReportingProxy
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportingProxy.QueryExecutor" />)
    ///     and namespace <see cref="EPMLiveCore.ReportingProxy"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class QueryExecutorTest : AbstractBaseSetupTypedTest<QueryExecutor>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (QueryExecutor) Initializer

        private const string MethodExecuteEpmLiveNonQuery = "ExecuteEpmLiveNonQuery";
        private const string MethodExecuteEpmLiveQuery = "ExecuteEpmLiveQuery";
        private const string MethodExecuteEpmLiveStoredProc = "ExecuteEpmLiveStoredProc";
        private const string MethodExecuteReportingDBNonQuery = "ExecuteReportingDBNonQuery";
        private const string MethodExecuteReportingDBQuery = "ExecuteReportingDBQuery";
        private const string MethodExecuteReportingDBStoredProc = "ExecuteReportingDBStoredProc";
        private const string MethodGetMappedListIds = "GetMappedListIds";
        private const string MethodGetTableName = "GetTableName";
        private const string MethodExecuteNonQuery = "ExecuteNonQuery";
        private const string MethodExecuteQuery = "ExecuteQuery";
        private Type _queryExecutorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private QueryExecutor _queryExecutorInstance;
        private QueryExecutor _queryExecutorInstanceFixture;

        #region General Initializer : Class (QueryExecutor) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryExecutor" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryExecutorInstanceType = typeof(QueryExecutor);
            _queryExecutorInstanceFixture = Create(true);
            _queryExecutorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryExecutor)

        #region General Initializer : Class (QueryExecutor) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="QueryExecutor" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodExecuteEpmLiveNonQuery, 0)]
        [TestCase(MethodExecuteEpmLiveQuery, 0)]
        [TestCase(MethodExecuteEpmLiveStoredProc, 0)]
        [TestCase(MethodExecuteReportingDBNonQuery, 0)]
        [TestCase(MethodExecuteReportingDBQuery, 0)]
        [TestCase(MethodExecuteReportingDBStoredProc, 0)]
        [TestCase(MethodGetMappedListIds, 0)]
        [TestCase(MethodGetTableName, 0)]
        [TestCase(MethodExecuteNonQuery, 0)]
        [TestCase(MethodExecuteQuery, 0)]
        public void AUT_QueryExecutor_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_queryExecutorInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
        
        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="QueryExecutor" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodExecuteEpmLiveNonQuery)]
        [TestCase(MethodExecuteEpmLiveQuery)]
        [TestCase(MethodExecuteEpmLiveStoredProc)]
        [TestCase(MethodExecuteReportingDBNonQuery)]
        [TestCase(MethodExecuteReportingDBQuery)]
        [TestCase(MethodExecuteReportingDBStoredProc)]
        [TestCase(MethodGetMappedListIds)]
        [TestCase(MethodGetTableName)]
        [TestCase(MethodExecuteNonQuery)]
        [TestCase(MethodExecuteQuery)]
        public void AUT_QueryExecutor_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<QueryExecutor>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveNonQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryExecutor_ExecuteEpmLiveNonQuery_Method_Call_Internally(Type[] types)
        {
            var methodExecuteEpmLiveNonQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteEpmLiveNonQuery, Fixture, methodExecuteEpmLiveNonQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveNonQuery) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveNonQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            Action executeAction = null;

            // Act
            executeAction = () => _queryExecutorInstance.ExecuteEpmLiveNonQuery(query, parameters);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveNonQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveNonQuery_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteEpmLiveNonQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteEpmLiveNonQuery = { query, parameters };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveNonQuery, methodExecuteEpmLiveNonQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queryExecutorInstanceFixture, parametersOfExecuteEpmLiveNonQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteEpmLiveNonQuery.ShouldNotBeNull();
            parametersOfExecuteEpmLiveNonQuery.Length.ShouldBe(2);
            methodExecuteEpmLiveNonQueryPrametersTypes.Length.ShouldBe(2);
            methodExecuteEpmLiveNonQueryPrametersTypes.Length.ShouldBe(parametersOfExecuteEpmLiveNonQuery.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveNonQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveNonQuery_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteEpmLiveNonQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteEpmLiveNonQuery = { query, parameters };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_queryExecutorInstance, MethodExecuteEpmLiveNonQuery, parametersOfExecuteEpmLiveNonQuery, methodExecuteEpmLiveNonQueryPrametersTypes);

            // Assert
            parametersOfExecuteEpmLiveNonQuery.ShouldNotBeNull();
            parametersOfExecuteEpmLiveNonQuery.Length.ShouldBe(2);
            methodExecuteEpmLiveNonQueryPrametersTypes.Length.ShouldBe(2);
            methodExecuteEpmLiveNonQueryPrametersTypes.Length.ShouldBe(parametersOfExecuteEpmLiveNonQuery.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveNonQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveNonQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveNonQuery, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveNonQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveNonQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteEpmLiveNonQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteEpmLiveNonQuery, Fixture, methodExecuteEpmLiveNonQueryPrametersTypes);

            // Assert
            methodExecuteEpmLiveNonQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveNonQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveNonQuery_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveNonQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_queryExecutorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveQuery) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryExecutor_ExecuteEpmLiveQuery_Method_Call_Internally(Type[] types)
        {
            var methodExecuteEpmLiveQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteEpmLiveQuery, Fixture, methodExecuteEpmLiveQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveQuery) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            Action executeAction = null;

            // Act
            executeAction = () => _queryExecutorInstance.ExecuteEpmLiveQuery(query, parameters);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveQuery) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteEpmLiveQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteEpmLiveQuery = { query, parameters };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveQuery, methodExecuteEpmLiveQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueryExecutor, DataTable>(_queryExecutorInstanceFixture, out exception1, parametersOfExecuteEpmLiveQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, DataTable>(_queryExecutorInstance, MethodExecuteEpmLiveQuery, parametersOfExecuteEpmLiveQuery, methodExecuteEpmLiveQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteEpmLiveQuery.ShouldNotBeNull();
            parametersOfExecuteEpmLiveQuery.Length.ShouldBe(2);
            methodExecuteEpmLiveQueryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveQuery) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteEpmLiveQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteEpmLiveQuery = { query, parameters };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, DataTable>(_queryExecutorInstance, MethodExecuteEpmLiveQuery, parametersOfExecuteEpmLiveQuery, methodExecuteEpmLiveQueryPrametersTypes);

            // Assert
            parametersOfExecuteEpmLiveQuery.ShouldNotBeNull();
            parametersOfExecuteEpmLiveQuery.Length.ShouldBe(2);
            methodExecuteEpmLiveQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveQuery) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveQuery_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteEpmLiveQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteEpmLiveQuery, Fixture, methodExecuteEpmLiveQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteEpmLiveQueryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveQuery) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteEpmLiveQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteEpmLiveQuery, Fixture, methodExecuteEpmLiveQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteEpmLiveQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveQuery) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queryExecutorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveQuery) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveQuery, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveStoredProc) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryExecutor_ExecuteEpmLiveStoredProc_Method_Call_Internally(Type[] types)
        {
            var methodExecuteEpmLiveStoredProcPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteEpmLiveStoredProc, Fixture, methodExecuteEpmLiveStoredProcPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveStoredProc) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveStoredProc_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var storedProcName = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            Action executeAction = null;

            // Act
            executeAction = () => _queryExecutorInstance.ExecuteEpmLiveStoredProc(storedProcName, parameters);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveStoredProc) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveStoredProc_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var storedProcName = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteEpmLiveStoredProcPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteEpmLiveStoredProc = { storedProcName, parameters };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveStoredProc, methodExecuteEpmLiveStoredProcPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueryExecutor, DataTable>(_queryExecutorInstanceFixture, out exception1, parametersOfExecuteEpmLiveStoredProc);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, DataTable>(_queryExecutorInstance, MethodExecuteEpmLiveStoredProc, parametersOfExecuteEpmLiveStoredProc, methodExecuteEpmLiveStoredProcPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteEpmLiveStoredProc.ShouldNotBeNull();
            parametersOfExecuteEpmLiveStoredProc.Length.ShouldBe(2);
            methodExecuteEpmLiveStoredProcPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveStoredProc) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveStoredProc_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var storedProcName = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteEpmLiveStoredProcPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteEpmLiveStoredProc = { storedProcName, parameters };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, DataTable>(_queryExecutorInstance, MethodExecuteEpmLiveStoredProc, parametersOfExecuteEpmLiveStoredProc, methodExecuteEpmLiveStoredProcPrametersTypes);

            // Assert
            parametersOfExecuteEpmLiveStoredProc.ShouldNotBeNull();
            parametersOfExecuteEpmLiveStoredProc.Length.ShouldBe(2);
            methodExecuteEpmLiveStoredProcPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveStoredProc) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveStoredProc_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteEpmLiveStoredProcPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteEpmLiveStoredProc, Fixture, methodExecuteEpmLiveStoredProcPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteEpmLiveStoredProcPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveStoredProc) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveStoredProc_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteEpmLiveStoredProcPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteEpmLiveStoredProc, Fixture, methodExecuteEpmLiveStoredProcPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteEpmLiveStoredProcPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveStoredProc) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveStoredProc_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveStoredProc, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queryExecutorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteEpmLiveStoredProc) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteEpmLiveStoredProc_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteEpmLiveStoredProc, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBNonQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryExecutor_ExecuteReportingDBNonQuery_Method_Call_Internally(Type[] types)
        {
            var methodExecuteReportingDBNonQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteReportingDBNonQuery, Fixture, methodExecuteReportingDBNonQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBNonQuery) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBNonQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            Action executeAction = null;

            // Act
            executeAction = () => _queryExecutorInstance.ExecuteReportingDBNonQuery(query, parameters);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBNonQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBNonQuery_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteReportingDBNonQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteReportingDBNonQuery = { query, parameters };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteReportingDBNonQuery, methodExecuteReportingDBNonQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queryExecutorInstanceFixture, parametersOfExecuteReportingDBNonQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteReportingDBNonQuery.ShouldNotBeNull();
            parametersOfExecuteReportingDBNonQuery.Length.ShouldBe(2);
            methodExecuteReportingDBNonQueryPrametersTypes.Length.ShouldBe(2);
            methodExecuteReportingDBNonQueryPrametersTypes.Length.ShouldBe(parametersOfExecuteReportingDBNonQuery.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBNonQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBNonQuery_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteReportingDBNonQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteReportingDBNonQuery = { query, parameters };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_queryExecutorInstance, MethodExecuteReportingDBNonQuery, parametersOfExecuteReportingDBNonQuery, methodExecuteReportingDBNonQueryPrametersTypes);

            // Assert
            parametersOfExecuteReportingDBNonQuery.ShouldNotBeNull();
            parametersOfExecuteReportingDBNonQuery.Length.ShouldBe(2);
            methodExecuteReportingDBNonQueryPrametersTypes.Length.ShouldBe(2);
            methodExecuteReportingDBNonQueryPrametersTypes.Length.ShouldBe(parametersOfExecuteReportingDBNonQuery.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBNonQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBNonQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteReportingDBNonQuery, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBNonQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBNonQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteReportingDBNonQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteReportingDBNonQuery, Fixture, methodExecuteReportingDBNonQueryPrametersTypes);

            // Assert
            methodExecuteReportingDBNonQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBNonQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBNonQuery_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteReportingDBNonQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_queryExecutorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBQuery) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryExecutor_ExecuteReportingDBQuery_Method_Call_Internally(Type[] types)
        {
            var methodExecuteReportingDBQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteReportingDBQuery, Fixture, methodExecuteReportingDBQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBQuery) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBQuery_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            Action executeAction = null;

            // Act
            executeAction = () => _queryExecutorInstance.ExecuteReportingDBQuery(query, parameters);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBQuery) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteReportingDBQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteReportingDBQuery = { query, parameters };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteReportingDBQuery, methodExecuteReportingDBQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueryExecutor, DataTable>(_queryExecutorInstanceFixture, out exception1, parametersOfExecuteReportingDBQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, DataTable>(_queryExecutorInstance, MethodExecuteReportingDBQuery, parametersOfExecuteReportingDBQuery, methodExecuteReportingDBQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteReportingDBQuery.ShouldNotBeNull();
            parametersOfExecuteReportingDBQuery.Length.ShouldBe(2);
            methodExecuteReportingDBQueryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBQuery) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteReportingDBQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteReportingDBQuery = { query, parameters };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, DataTable>(_queryExecutorInstance, MethodExecuteReportingDBQuery, parametersOfExecuteReportingDBQuery, methodExecuteReportingDBQueryPrametersTypes);

            // Assert
            parametersOfExecuteReportingDBQuery.ShouldNotBeNull();
            parametersOfExecuteReportingDBQuery.Length.ShouldBe(2);
            methodExecuteReportingDBQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBQuery) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBQuery_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteReportingDBQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteReportingDBQuery, Fixture, methodExecuteReportingDBQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteReportingDBQueryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBQuery) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteReportingDBQueryPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteReportingDBQuery, Fixture, methodExecuteReportingDBQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteReportingDBQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBQuery) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteReportingDBQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queryExecutorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteReportingDBQuery) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteReportingDBQuery, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBStoredProc) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryExecutor_ExecuteReportingDBStoredProc_Method_Call_Internally(Type[] types)
        {
            var methodExecuteReportingDBStoredProcPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteReportingDBStoredProc, Fixture, methodExecuteReportingDBStoredProcPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBStoredProc) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBStoredProc_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var storedProcName = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            Action executeAction = null;

            // Act
            executeAction = () => _queryExecutorInstance.ExecuteReportingDBStoredProc(storedProcName, parameters);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBStoredProc) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBStoredProc_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var storedProcName = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteReportingDBStoredProcPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteReportingDBStoredProc = { storedProcName, parameters };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteReportingDBStoredProc, methodExecuteReportingDBStoredProcPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueryExecutor, DataTable>(_queryExecutorInstanceFixture, out exception1, parametersOfExecuteReportingDBStoredProc);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, DataTable>(_queryExecutorInstance, MethodExecuteReportingDBStoredProc, parametersOfExecuteReportingDBStoredProc, methodExecuteReportingDBStoredProcPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteReportingDBStoredProc.ShouldNotBeNull();
            parametersOfExecuteReportingDBStoredProc.Length.ShouldBe(2);
            methodExecuteReportingDBStoredProcPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBStoredProc) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBStoredProc_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var storedProcName = CreateType<string>();
            var parameters = CreateType<IDictionary<string, object>>();
            var methodExecuteReportingDBStoredProcPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            object[] parametersOfExecuteReportingDBStoredProc = { storedProcName, parameters };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, DataTable>(_queryExecutorInstance, MethodExecuteReportingDBStoredProc, parametersOfExecuteReportingDBStoredProc, methodExecuteReportingDBStoredProcPrametersTypes);

            // Assert
            parametersOfExecuteReportingDBStoredProc.ShouldNotBeNull();
            parametersOfExecuteReportingDBStoredProc.Length.ShouldBe(2);
            methodExecuteReportingDBStoredProcPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBStoredProc) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBStoredProc_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteReportingDBStoredProcPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteReportingDBStoredProc, Fixture, methodExecuteReportingDBStoredProcPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteReportingDBStoredProcPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBStoredProc) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBStoredProc_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteReportingDBStoredProcPrametersTypes = new Type[] { typeof(string), typeof(IDictionary<string, object>) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteReportingDBStoredProc, Fixture, methodExecuteReportingDBStoredProcPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteReportingDBStoredProcPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteReportingDBStoredProc) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBStoredProc_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteReportingDBStoredProc, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queryExecutorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteReportingDBStoredProc) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteReportingDBStoredProc_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteReportingDBStoredProc, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMappedListIds) (Return Type : IEnumerable<Guid>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryExecutor_GetMappedListIds_Method_Call_Internally(Type[] types)
        {
            var methodGetMappedListIdsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodGetMappedListIds, Fixture, methodGetMappedListIdsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMappedListIds) (Return Type : IEnumerable<Guid>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetMappedListIds_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _queryExecutorInstance.GetMappedListIds();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetMappedListIds) (Return Type : IEnumerable<Guid>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetMappedListIds_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedListIdsPrametersTypes = null;
            object[] parametersOfGetMappedListIds = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMappedListIds, methodGetMappedListIdsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueryExecutor, IEnumerable<Guid>>(_queryExecutorInstanceFixture, out exception1, parametersOfGetMappedListIds);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, IEnumerable<Guid>>(_queryExecutorInstance, MethodGetMappedListIds, parametersOfGetMappedListIds, methodGetMappedListIdsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMappedListIds.ShouldBeNull();
            methodGetMappedListIdsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedListIds) (Return Type : IEnumerable<Guid>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetMappedListIds_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMappedListIdsPrametersTypes = null;
            object[] parametersOfGetMappedListIds = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, IEnumerable<Guid>>(_queryExecutorInstance, MethodGetMappedListIds, parametersOfGetMappedListIds, methodGetMappedListIdsPrametersTypes);

            // Assert
            parametersOfGetMappedListIds.ShouldBeNull();
            methodGetMappedListIdsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedListIds) (Return Type : IEnumerable<Guid>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetMappedListIds_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedListIdsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodGetMappedListIds, Fixture, methodGetMappedListIdsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMappedListIdsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedListIds) (Return Type : IEnumerable<Guid>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetMappedListIds_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMappedListIdsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodGetMappedListIds, Fixture, methodGetMappedListIdsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMappedListIdsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedListIds) (Return Type : IEnumerable<Guid>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetMappedListIds_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMappedListIds, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queryExecutorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryExecutor_GetTableName_Method_Call_Internally(Type[] types)
        {
            var methodGetTableNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetTableName_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _queryExecutorInstance.GetTableName(listName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetTableName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTableName = { listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTableName, methodGetTableNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueryExecutor, string>(_queryExecutorInstanceFixture, out exception1, parametersOfGetTableName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, string>(_queryExecutorInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetTableName.ShouldNotBeNull();
            parametersOfGetTableName.Length.ShouldBe(1);
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetTableName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetTableName = { listName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, string>(_queryExecutorInstance, MethodGetTableName, parametersOfGetTableName, methodGetTableNamePrametersTypes);

            // Assert
            parametersOfGetTableName.ShouldNotBeNull();
            parametersOfGetTableName.Length.ShouldBe(1);
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetTableName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTableNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetTableName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTableNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodGetTableName, Fixture, methodGetTableNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTableNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetTableName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTableName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queryExecutorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTableName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_GetTableName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTableName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryExecutor_ExecuteNonQuery_Method_Call_Internally(Type[] types)
        {
            var methodExecuteNonQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteNonQuery, Fixture, methodExecuteNonQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteNonQuery_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IEnumerable<KeyValuePair<string, object>>>();
            var connectionType = CreateType<string>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<KeyValuePair<string, object>>), typeof(string) };
            object[] parametersOfExecuteNonQuery = { query, parameters, connectionType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, methodExecuteNonQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_queryExecutorInstanceFixture, parametersOfExecuteNonQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteNonQuery.ShouldNotBeNull();
            parametersOfExecuteNonQuery.Length.ShouldBe(3);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(3);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(parametersOfExecuteNonQuery.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteNonQuery_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IEnumerable<KeyValuePair<string, object>>>();
            var connectionType = CreateType<string>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<KeyValuePair<string, object>>), typeof(string) };
            object[] parametersOfExecuteNonQuery = { query, parameters, connectionType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_queryExecutorInstance, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

            // Assert
            parametersOfExecuteNonQuery.ShouldNotBeNull();
            parametersOfExecuteNonQuery.Length.ShouldBe(3);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(3);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(parametersOfExecuteNonQuery.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteNonQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteNonQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<KeyValuePair<string, object>>), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteNonQuery, Fixture, methodExecuteNonQueryPrametersTypes);

            // Assert
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteNonQuery_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_queryExecutorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryExecutor_ExecuteQuery_Method_Call_Internally(Type[] types)
        {
            var methodExecuteQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteQuery, Fixture, methodExecuteQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IEnumerable<KeyValuePair<string, object>>>();
            var commandType = CreateType<CommandType>();
            var connectionType = CreateType<string>();
            var methodExecuteQueryPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<KeyValuePair<string, object>>), typeof(CommandType), typeof(string) };
            object[] parametersOfExecuteQuery = { query, parameters, commandType, connectionType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteQuery, methodExecuteQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<QueryExecutor, DataTable>(_queryExecutorInstanceFixture, out exception1, parametersOfExecuteQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, DataTable>(_queryExecutorInstance, MethodExecuteQuery, parametersOfExecuteQuery, methodExecuteQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteQuery.ShouldNotBeNull();
            parametersOfExecuteQuery.Length.ShouldBe(4);
            methodExecuteQueryPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var query = CreateType<string>();
            var parameters = CreateType<IEnumerable<KeyValuePair<string, object>>>();
            var commandType = CreateType<CommandType>();
            var connectionType = CreateType<string>();
            var methodExecuteQueryPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<KeyValuePair<string, object>>), typeof(CommandType), typeof(string) };
            object[] parametersOfExecuteQuery = { query, parameters, commandType, connectionType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<QueryExecutor, DataTable>(_queryExecutorInstance, MethodExecuteQuery, parametersOfExecuteQuery, methodExecuteQueryPrametersTypes);

            // Assert
            parametersOfExecuteQuery.ShouldNotBeNull();
            parametersOfExecuteQuery.Length.ShouldBe(4);
            methodExecuteQueryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteQuery_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteQueryPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<KeyValuePair<string, object>>), typeof(CommandType), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteQuery, Fixture, methodExecuteQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteQueryPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteQueryPrametersTypes = new Type[] { typeof(string), typeof(IEnumerable<KeyValuePair<string, object>>), typeof(CommandType), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_queryExecutorInstance, MethodExecuteQuery, Fixture, methodExecuteQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_queryExecutorInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteQuery) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryExecutor_ExecuteQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteQuery, 0);
            const int parametersCount = 4;

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