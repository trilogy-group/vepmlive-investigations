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

namespace EPMLiveCore.Jobs.EPMLiveUpgrade.Steps
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.EPMLiveUpgrade.Steps.DdlHelper" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.EPMLiveUpgrade.Steps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class DdlHelperTest : AbstractBaseSetupTest
    {
        public DdlHelperTest() : base(typeof(DdlHelper))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DdlHelper) Initializer

        private const string MethodColumnExist = "ColumnExist";
        private const string MethodTableExist = "TableExist";
        private const string MethodExecuteReader = "ExecuteReader";
        private const string MethodAddColumn = "AddColumn";
        private const string MethodExecuteNonQuery = "ExecuteNonQuery";
        private const string MethodGetDefinition = "GetDefinition";
        private const string MethodGetViewDefinition = "GetViewDefinition";
        private const string MethodGetSpDefinition = "GetSpDefinition";
        private const string MethodIndexDefinition = "IndexDefinition";
        private const string MethodGetIndexDefinition = "GetIndexDefinition";
        private Type _ddlHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (DdlHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DdlHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ddlHelperInstanceType = typeof(DdlHelper);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DdlHelper)

        #region General Initializer : Class (DdlHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="DdlHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodColumnExist, 0)]
        [TestCase(MethodAddColumn, 0)]
        [TestCase(MethodExecuteNonQuery, 0)]
        [TestCase(MethodGetDefinition, 0)]
        [TestCase(MethodGetViewDefinition, 0)]
        [TestCase(MethodGetSpDefinition, 0)]
        [TestCase(MethodIndexDefinition, 0)]
        [TestCase(MethodGetIndexDefinition, 0)]
        public void AUT_DdlHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="DdlHelper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DdlHelper_Is_Static_Type_Present_Test()
        {
            // Assert
            _ddlHelperInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="DdlHelper" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodColumnExist)]
        [TestCase(MethodAddColumn)]
        [TestCase(MethodExecuteNonQuery)]
        [TestCase(MethodGetDefinition)]
        [TestCase(MethodGetViewDefinition)]
        [TestCase(MethodGetSpDefinition)]
        [TestCase(MethodIndexDefinition)]
        [TestCase(MethodGetIndexDefinition)]
        public void AUT_DdlHelper_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _ddlHelperInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ColumnExist) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DdlHelper_ColumnExist_Static_Method_Call_Internally(Type[] types)
        {
            var methodColumnExistPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodColumnExist, Fixture, methodColumnExistPrametersTypes);
        }

        #endregion

        #region Method Call : (ColumnExist) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_ColumnExist_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var tableName = CreateType<string>();
            var columnName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => DdlHelper.ColumnExist(sqlConnection, tableName, columnName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ColumnExist) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_ColumnExist_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var tableName = CreateType<string>();
            var columnName = CreateType<string>();
            var methodColumnExistPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };
            object[] parametersOfColumnExist = { sqlConnection, tableName, columnName };

            // Assert
            parametersOfColumnExist.ShouldNotBeNull();
            parametersOfColumnExist.Length.ShouldBe(3);
            methodColumnExistPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _ddlHelperInstanceType, MethodColumnExist, parametersOfColumnExist, methodColumnExistPrametersTypes));
        }

        #endregion

        #region Method Call : (ColumnExist) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_ColumnExist_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodColumnExistPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodColumnExist, Fixture, methodColumnExistPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodColumnExistPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ColumnExist) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_ColumnExist_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodColumnExist, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ColumnExist) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_ColumnExist_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodColumnExist, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (TableExist) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DdlHelper_TableExist_Static_Method_Call_Internally(Type[] types)
        {
            var methodTableExistPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodTableExist, Fixture, methodTableExistPrametersTypes);
        }

        #endregion

        #region Method Call : (TableExist) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_TableExist_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var tableName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => DdlHelper.TableExist(sqlConnection, tableName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (TableExist) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_TableExist_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var tableName = CreateType<string>();
            var methodTableExistPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfTableExist = { sqlConnection, tableName };

            // Assert
            parametersOfTableExist.ShouldNotBeNull();
            parametersOfTableExist.Length.ShouldBe(2);
            methodTableExistPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _ddlHelperInstanceType, MethodTableExist, parametersOfTableExist, methodTableExistPrametersTypes));
        }

        #endregion

        #region Method Call : (TableExist) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_TableExist_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodTableExistPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodTableExist, Fixture, methodTableExistPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodTableExistPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DdlHelper_AddColumn_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddColumnPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodAddColumn, Fixture, methodAddColumnPrametersTypes);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_AddColumn_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var tableName = CreateType<string>();
            var columnDefinition = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => DdlHelper.AddColumn(sqlConnection, tableName, columnDefinition);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_AddColumn_Static_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var tableName = CreateType<string>();
            var columnDefinition = CreateType<string>();
            var methodAddColumnPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };
            object[] parametersOfAddColumn = { sqlConnection, tableName, columnDefinition };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddColumn, methodAddColumnPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAddColumn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddColumn.ShouldNotBeNull();
            parametersOfAddColumn.Length.ShouldBe(3);
            methodAddColumnPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_AddColumn_Static_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var tableName = CreateType<string>();
            var columnDefinition = CreateType<string>();
            var methodAddColumnPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };
            object[] parametersOfAddColumn = { sqlConnection, tableName, columnDefinition };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _ddlHelperInstanceType, MethodAddColumn, parametersOfAddColumn, methodAddColumnPrametersTypes);

            // Assert
            parametersOfAddColumn.ShouldNotBeNull();
            parametersOfAddColumn.Length.ShouldBe(3);
            methodAddColumnPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_AddColumn_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddColumn, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_AddColumn_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddColumnPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodAddColumn, Fixture, methodAddColumnPrametersTypes);

            // Assert
            methodAddColumnPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddColumn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_AddColumn_Static_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddColumn, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DdlHelper_ExecuteNonQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodExecuteNonQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodExecuteNonQuery, Fixture, methodExecuteNonQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_ExecuteNonQuery_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var sql = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => DdlHelper.ExecuteNonQuery(sqlConnection, sql);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_ExecuteNonQuery_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var sql = CreateType<string>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfExecuteNonQuery = { sqlConnection, sql };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, methodExecuteNonQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfExecuteNonQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfExecuteNonQuery.ShouldNotBeNull();
            parametersOfExecuteNonQuery.Length.ShouldBe(2);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_ExecuteNonQuery_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var sql = CreateType<string>();
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfExecuteNonQuery = { sqlConnection, sql };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _ddlHelperInstanceType, MethodExecuteNonQuery, parametersOfExecuteNonQuery, methodExecuteNonQueryPrametersTypes);

            // Assert
            parametersOfExecuteNonQuery.ShouldNotBeNull();
            parametersOfExecuteNonQuery.Length.ShouldBe(2);
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_ExecuteNonQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, 0);
            const int parametersCount = 2;

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
        public void AUT_DdlHelper_ExecuteNonQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteNonQueryPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodExecuteNonQuery, Fixture, methodExecuteNonQueryPrametersTypes);

            // Assert
            methodExecuteNonQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteNonQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_ExecuteNonQuery_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteNonQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDefinition) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DdlHelper_GetDefinition_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDefinitionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetDefinition, Fixture, methodGetDefinitionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDefinition) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetDefinition_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var objectName = CreateType<string>();
            var objType = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => DdlHelper.GetDefinition(sqlConnection, objectName, objType);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDefinition) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetDefinition_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var objectName = CreateType<string>();
            var objType = CreateType<string>();
            var methodGetDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };
            object[] parametersOfGetDefinition = { sqlConnection, objectName, objType };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetDefinition, methodGetDefinitionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetDefinition, Fixture, methodGetDefinitionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _ddlHelperInstanceType, MethodGetDefinition, parametersOfGetDefinition, methodGetDefinitionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetDefinition);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDefinition.ShouldNotBeNull();
            parametersOfGetDefinition.Length.ShouldBe(3);
            methodGetDefinitionPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDefinition) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetDefinition_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var objectName = CreateType<string>();
            var objType = CreateType<string>();
            var methodGetDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };
            object[] parametersOfGetDefinition = { sqlConnection, objectName, objType };

            // Assert
            parametersOfGetDefinition.ShouldNotBeNull();
            parametersOfGetDefinition.Length.ShouldBe(3);
            methodGetDefinitionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _ddlHelperInstanceType, MethodGetDefinition, parametersOfGetDefinition, methodGetDefinitionPrametersTypes));
        }

        #endregion

        #region Method Call : (GetDefinition) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetDefinition_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetDefinition, Fixture, methodGetDefinitionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDefinitionPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetDefinition) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetDefinition_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetDefinition, Fixture, methodGetDefinitionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDefinitionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDefinition) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetDefinition_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDefinition, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDefinition) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetDefinition_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDefinition, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetViewDefinition) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DdlHelper_GetViewDefinition_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetViewDefinitionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetViewDefinition, Fixture, methodGetViewDefinitionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetViewDefinition) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetViewDefinition_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var viewName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => DdlHelper.GetViewDefinition(sqlConnection, viewName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetViewDefinition) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetViewDefinition_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var viewName = CreateType<string>();
            var methodGetViewDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfGetViewDefinition = { sqlConnection, viewName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetViewDefinition, methodGetViewDefinitionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetViewDefinition, Fixture, methodGetViewDefinitionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _ddlHelperInstanceType, MethodGetViewDefinition, parametersOfGetViewDefinition, methodGetViewDefinitionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetViewDefinition);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetViewDefinition.ShouldNotBeNull();
            parametersOfGetViewDefinition.Length.ShouldBe(2);
            methodGetViewDefinitionPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetViewDefinition) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetViewDefinition_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var viewName = CreateType<string>();
            var methodGetViewDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfGetViewDefinition = { sqlConnection, viewName };

            // Assert
            parametersOfGetViewDefinition.ShouldNotBeNull();
            parametersOfGetViewDefinition.Length.ShouldBe(2);
            methodGetViewDefinitionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _ddlHelperInstanceType, MethodGetViewDefinition, parametersOfGetViewDefinition, methodGetViewDefinitionPrametersTypes));
        }

        #endregion

        #region Method Call : (GetViewDefinition) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetViewDefinition_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetViewDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetViewDefinition, Fixture, methodGetViewDefinitionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetViewDefinitionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetViewDefinition) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetViewDefinition_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetViewDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetViewDefinition, Fixture, methodGetViewDefinitionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetViewDefinitionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetViewDefinition) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetViewDefinition_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetViewDefinition, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetViewDefinition) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetViewDefinition_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetViewDefinition, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSpDefinition) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DdlHelper_GetSpDefinition_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSpDefinitionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetSpDefinition, Fixture, methodGetSpDefinitionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSpDefinition) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetSpDefinition_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var spName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => DdlHelper.GetSpDefinition(sqlConnection, spName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSpDefinition) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetSpDefinition_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var spName = CreateType<string>();
            var methodGetSpDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfGetSpDefinition = { sqlConnection, spName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSpDefinition, methodGetSpDefinitionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetSpDefinition, Fixture, methodGetSpDefinitionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _ddlHelperInstanceType, MethodGetSpDefinition, parametersOfGetSpDefinition, methodGetSpDefinitionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetSpDefinition);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSpDefinition.ShouldNotBeNull();
            parametersOfGetSpDefinition.Length.ShouldBe(2);
            methodGetSpDefinitionPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSpDefinition) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetSpDefinition_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var spName = CreateType<string>();
            var methodGetSpDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfGetSpDefinition = { sqlConnection, spName };

            // Assert
            parametersOfGetSpDefinition.ShouldNotBeNull();
            parametersOfGetSpDefinition.Length.ShouldBe(2);
            methodGetSpDefinitionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _ddlHelperInstanceType, MethodGetSpDefinition, parametersOfGetSpDefinition, methodGetSpDefinitionPrametersTypes));
        }

        #endregion

        #region Method Call : (GetSpDefinition) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetSpDefinition_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSpDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetSpDefinition, Fixture, methodGetSpDefinitionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSpDefinitionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetSpDefinition) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetSpDefinition_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSpDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetSpDefinition, Fixture, methodGetSpDefinitionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSpDefinitionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSpDefinition) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetSpDefinition_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSpDefinition, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSpDefinition) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetSpDefinition_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSpDefinition, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IndexDefinition) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DdlHelper_IndexDefinition_Static_Method_Call_Internally(Type[] types)
        {
            var methodIndexDefinitionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodIndexDefinition, Fixture, methodIndexDefinitionPrametersTypes);
        }

        #endregion

        #region Method Call : (IndexDefinition) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_IndexDefinition_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var indexName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => DdlHelper.IndexDefinition(sqlConnection, indexName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IndexDefinition) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_IndexDefinition_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var indexName = CreateType<string>();
            var methodIndexDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfIndexDefinition = { sqlConnection, indexName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIndexDefinition, methodIndexDefinitionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodIndexDefinition, Fixture, methodIndexDefinitionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _ddlHelperInstanceType, MethodIndexDefinition, parametersOfIndexDefinition, methodIndexDefinitionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIndexDefinition);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfIndexDefinition.ShouldNotBeNull();
            parametersOfIndexDefinition.Length.ShouldBe(2);
            methodIndexDefinitionPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (IndexDefinition) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_IndexDefinition_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var indexName = CreateType<string>();
            var methodIndexDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfIndexDefinition = { sqlConnection, indexName };

            // Assert
            parametersOfIndexDefinition.ShouldNotBeNull();
            parametersOfIndexDefinition.Length.ShouldBe(2);
            methodIndexDefinitionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _ddlHelperInstanceType, MethodIndexDefinition, parametersOfIndexDefinition, methodIndexDefinitionPrametersTypes));
        }

        #endregion

        #region Method Call : (IndexDefinition) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_IndexDefinition_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodIndexDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodIndexDefinition, Fixture, methodIndexDefinitionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodIndexDefinitionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (IndexDefinition) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_IndexDefinition_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIndexDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodIndexDefinition, Fixture, methodIndexDefinitionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIndexDefinitionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IndexDefinition) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_IndexDefinition_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIndexDefinition, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IndexDefinition) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_IndexDefinition_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIndexDefinition, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIndexDefinition) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_DdlHelper_GetIndexDefinition_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetIndexDefinitionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetIndexDefinition, Fixture, methodGetIndexDefinitionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetIndexDefinition) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetIndexDefinition_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var objectName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => DdlHelper.GetIndexDefinition(sqlConnection, objectName);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetIndexDefinition) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetIndexDefinition_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var objectName = CreateType<string>();
            var methodGetIndexDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfGetIndexDefinition = { sqlConnection, objectName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetIndexDefinition, methodGetIndexDefinitionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetIndexDefinition, Fixture, methodGetIndexDefinitionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _ddlHelperInstanceType, MethodGetIndexDefinition, parametersOfGetIndexDefinition, methodGetIndexDefinitionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetIndexDefinition);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetIndexDefinition.ShouldNotBeNull();
            parametersOfGetIndexDefinition.Length.ShouldBe(2);
            methodGetIndexDefinitionPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetIndexDefinition) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetIndexDefinition_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sqlConnection = CreateType<SqlConnection>();
            var objectName = CreateType<string>();
            var methodGetIndexDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            object[] parametersOfGetIndexDefinition = { sqlConnection, objectName };

            // Assert
            parametersOfGetIndexDefinition.ShouldNotBeNull();
            parametersOfGetIndexDefinition.Length.ShouldBe(2);
            methodGetIndexDefinitionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _ddlHelperInstanceType, MethodGetIndexDefinition, parametersOfGetIndexDefinition, methodGetIndexDefinitionPrametersTypes));
        }

        #endregion

        #region Method Call : (GetIndexDefinition) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetIndexDefinition_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetIndexDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetIndexDefinition, Fixture, methodGetIndexDefinitionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetIndexDefinitionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetIndexDefinition) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetIndexDefinition_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetIndexDefinitionPrametersTypes = new Type[] { typeof(SqlConnection), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _ddlHelperInstanceType, MethodGetIndexDefinition, Fixture, methodGetIndexDefinitionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetIndexDefinitionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetIndexDefinition) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetIndexDefinition_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetIndexDefinition, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetIndexDefinition) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_DdlHelper_GetIndexDefinition_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetIndexDefinition, 0);
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