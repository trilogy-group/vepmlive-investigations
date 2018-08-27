using System;
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

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.WorkspaceCenter" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkspaceCenterTest : AbstractBaseSetupTypedTest<WorkspaceCenter>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkspaceCenter) Initializer

        private const string MethodGetWorkspaceCenterGridData = "GetWorkspaceCenterGridData";
        private const string MethodGetSpContentDbSqlConnection = "GetSpContentDbSqlConnection";
        private const string MethodGetWorkSpaceCenterLayout = "GetWorkSpaceCenterLayout";
        private Type _workspaceCenterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkspaceCenter _workspaceCenterInstance;
        private WorkspaceCenter _workspaceCenterInstanceFixture;

        #region General Initializer : Class (WorkspaceCenter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkspaceCenter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workspaceCenterInstanceType = typeof(WorkspaceCenter);
            _workspaceCenterInstanceFixture = Create(true);
            _workspaceCenterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkspaceCenter)

        #region General Initializer : Class (WorkspaceCenter) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkspaceCenter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetWorkspaceCenterGridData, 0)]
        [TestCase(MethodGetSpContentDbSqlConnection, 0)]
        [TestCase(MethodGetWorkSpaceCenterLayout, 0)]
        public void AUT_WorkspaceCenter_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workspaceCenterInstanceFixture, 
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
        ///     Class (<see cref="WorkspaceCenter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkspaceCenter_Is_Instance_Present_Test()
        {
            // Assert
            _workspaceCenterInstanceType.ShouldNotBeNull();
            _workspaceCenterInstance.ShouldNotBeNull();
            _workspaceCenterInstanceFixture.ShouldNotBeNull();
            _workspaceCenterInstance.ShouldBeAssignableTo<WorkspaceCenter>();
            _workspaceCenterInstanceFixture.ShouldBeAssignableTo<WorkspaceCenter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkspaceCenter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WorkspaceCenter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkspaceCenter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workspaceCenterInstanceType.ShouldNotBeNull();
            _workspaceCenterInstance.ShouldNotBeNull();
            _workspaceCenterInstanceFixture.ShouldNotBeNull();
            _workspaceCenterInstance.ShouldBeAssignableTo<WorkspaceCenter>();
            _workspaceCenterInstanceFixture.ShouldBeAssignableTo<WorkspaceCenter>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WorkspaceCenter" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetWorkspaceCenterGridData)]
        [TestCase(MethodGetSpContentDbSqlConnection)]
        [TestCase(MethodGetWorkSpaceCenterLayout)]
        public void AUT_WorkspaceCenter_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_workspaceCenterInstanceFixture,
                                                                              _workspaceCenterInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetWorkspaceCenterGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceCenter_GetWorkspaceCenterGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkspaceCenterGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetWorkspaceCenterGridData, Fixture, methodGetWorkspaceCenterGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkspaceCenterGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkspaceCenterGridData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetWorkspaceCenterGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetWorkspaceCenterGridData = { data, oWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWorkspaceCenterGridData, methodGetWorkspaceCenterGridDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetWorkspaceCenterGridData, Fixture, methodGetWorkspaceCenterGridDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetWorkspaceCenterGridData, parametersOfGetWorkspaceCenterGridData, methodGetWorkspaceCenterGridDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workspaceCenterInstanceFixture, parametersOfGetWorkspaceCenterGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWorkspaceCenterGridData.ShouldNotBeNull();
            parametersOfGetWorkspaceCenterGridData.Length.ShouldBe(2);
            methodGetWorkspaceCenterGridDataPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkspaceCenterGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkspaceCenterGridData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var oWeb = CreateType<SPWeb>();
            var methodGetWorkspaceCenterGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetWorkspaceCenterGridData = { data, oWeb };

            // Assert
            parametersOfGetWorkspaceCenterGridData.ShouldNotBeNull();
            parametersOfGetWorkspaceCenterGridData.Length.ShouldBe(2);
            methodGetWorkspaceCenterGridDataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetWorkspaceCenterGridData, parametersOfGetWorkspaceCenterGridData, methodGetWorkspaceCenterGridDataPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkspaceCenterGridData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkspaceCenterGridData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkspaceCenterGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetWorkspaceCenterGridData, Fixture, methodGetWorkspaceCenterGridDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkspaceCenterGridDataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetWorkspaceCenterGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkspaceCenterGridData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkspaceCenterGridDataPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetWorkspaceCenterGridData, Fixture, methodGetWorkspaceCenterGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkspaceCenterGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkspaceCenterGridData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkspaceCenterGridData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkspaceCenterGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceCenterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkspaceCenterGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkspaceCenterGridData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkspaceCenterGridData, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceCenter_GetSpContentDbSqlConnection_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSpContentDbSqlConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetSpContentDbSqlConnection, Fixture, methodGetSpContentDbSqlConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetSpContentDbSqlConnection_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceCenter.GetSpContentDbSqlConnection(spWeb);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetSpContentDbSqlConnection_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodGetSpContentDbSqlConnectionPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetSpContentDbSqlConnection = { spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSpContentDbSqlConnection, methodGetSpContentDbSqlConnectionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetSpContentDbSqlConnection, Fixture, methodGetSpContentDbSqlConnectionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<SqlConnection>(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetSpContentDbSqlConnection, parametersOfGetSpContentDbSqlConnection, methodGetSpContentDbSqlConnectionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_workspaceCenterInstanceFixture, parametersOfGetSpContentDbSqlConnection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSpContentDbSqlConnection.ShouldNotBeNull();
            parametersOfGetSpContentDbSqlConnection.Length.ShouldBe(1);
            methodGetSpContentDbSqlConnectionPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetSpContentDbSqlConnection_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var spWeb = CreateType<SPWeb>();
            var methodGetSpContentDbSqlConnectionPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetSpContentDbSqlConnection = { spWeb };

            // Assert
            parametersOfGetSpContentDbSqlConnection.ShouldNotBeNull();
            parametersOfGetSpContentDbSqlConnection.Length.ShouldBe(1);
            methodGetSpContentDbSqlConnectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<SqlConnection>(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetSpContentDbSqlConnection, parametersOfGetSpContentDbSqlConnection, methodGetSpContentDbSqlConnectionPrametersTypes));
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetSpContentDbSqlConnection_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSpContentDbSqlConnectionPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetSpContentDbSqlConnection, Fixture, methodGetSpContentDbSqlConnectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSpContentDbSqlConnectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetSpContentDbSqlConnection_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSpContentDbSqlConnectionPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetSpContentDbSqlConnection, Fixture, methodGetSpContentDbSqlConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSpContentDbSqlConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetSpContentDbSqlConnection_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSpContentDbSqlConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceCenterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSpContentDbSqlConnection) (Return Type : SqlConnection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetSpContentDbSqlConnection_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSpContentDbSqlConnection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkSpaceCenterLayout) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceCenter_GetWorkSpaceCenterLayout_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkSpaceCenterLayoutPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetWorkSpaceCenterLayout, Fixture, methodGetWorkSpaceCenterLayoutPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkSpaceCenterLayout) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkSpaceCenterLayout_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetWorkSpaceCenterLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetWorkSpaceCenterLayout = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetWorkSpaceCenterLayout, methodGetWorkSpaceCenterLayoutPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetWorkSpaceCenterLayout.ShouldNotBeNull();
            parametersOfGetWorkSpaceCenterLayout.Length.ShouldBe(1);
            methodGetWorkSpaceCenterLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_workspaceCenterInstanceFixture, parametersOfGetWorkSpaceCenterLayout));
        }

        #endregion

        #region Method Call : (GetWorkSpaceCenterLayout) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkSpaceCenterLayout_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodGetWorkSpaceCenterLayoutPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetWorkSpaceCenterLayout = { data };

            // Assert
            parametersOfGetWorkSpaceCenterLayout.ShouldNotBeNull();
            parametersOfGetWorkSpaceCenterLayout.Length.ShouldBe(1);
            methodGetWorkSpaceCenterLayoutPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetWorkSpaceCenterLayout, parametersOfGetWorkSpaceCenterLayout, methodGetWorkSpaceCenterLayoutPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkSpaceCenterLayout) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkSpaceCenterLayout_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkSpaceCenterLayoutPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetWorkSpaceCenterLayout, Fixture, methodGetWorkSpaceCenterLayoutPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkSpaceCenterLayoutPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWorkSpaceCenterLayout) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkSpaceCenterLayout_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkSpaceCenterLayoutPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_workspaceCenterInstanceFixture, _workspaceCenterInstanceType, MethodGetWorkSpaceCenterLayout, Fixture, methodGetWorkSpaceCenterLayoutPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkSpaceCenterLayoutPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkSpaceCenterLayout) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkSpaceCenterLayout_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkSpaceCenterLayout, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_workspaceCenterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetWorkSpaceCenterLayout) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceCenter_GetWorkSpaceCenterLayout_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkSpaceCenterLayout, 0);
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