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
using System.Text;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Microsoft.SharePoint;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using ReportingData = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.ReportingData" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportingDataTest : AbstractBaseSetupTypedTest<ReportingData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingData) Initializer

        private const string MethodGetReportingData = "GetReportingData";
        private const string MethodGetReportQuery = "GetReportQuery";
        private const string MethodGetReportQueryNode = "GetReportQueryNode";
        private const string MethodGetNodeSign = "GetNodeSign";
        private const string MethodProcessReportFilter = "ProcessReportFilter";
        private const string MethodGetReportFilters = "GetReportFilters";
        private Type _reportingDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingData _reportingDataInstance;
        private ReportingData _reportingDataInstanceFixture;

        #region General Initializer : Class (ReportingData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingDataInstanceType = typeof(ReportingData);
            _reportingDataInstanceFixture = Create(true);
            _reportingDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingData)

        #region General Initializer : Class (ReportingData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetReportingData, 0)]
        [TestCase(MethodGetReportingData, 1)]
        [TestCase(MethodGetReportQuery, 0)]
        [TestCase(MethodGetReportQueryNode, 0)]
        [TestCase(MethodGetNodeSign, 0)]
        [TestCase(MethodProcessReportFilter, 0)]
        [TestCase(MethodGetReportFilters, 0)]
        public void AUT_ReportingData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingDataInstanceFixture, 
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
        ///     Class (<see cref="ReportingData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportingData_Is_Instance_Present_Test()
        {
            // Assert
            _reportingDataInstanceType.ShouldNotBeNull();
            _reportingDataInstance.ShouldNotBeNull();
            _reportingDataInstanceFixture.ShouldNotBeNull();
            _reportingDataInstance.ShouldBeAssignableTo<ReportingData>();
            _reportingDataInstanceFixture.ShouldBeAssignableTo<ReportingData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportingData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportingData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportingData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportingDataInstanceType.ShouldNotBeNull();
            _reportingDataInstance.ShouldNotBeNull();
            _reportingDataInstanceFixture.ShouldNotBeNull();
            _reportingDataInstance.ShouldBeAssignableTo<ReportingData>();
            _reportingDataInstanceFixture.ShouldBeAssignableTo<ReportingData>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ReportingData" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetReportingData)]
        [TestCase(MethodGetReportQuery)]
        [TestCase(MethodGetReportQueryNode)]
        [TestCase(MethodGetNodeSign)]
        [TestCase(MethodProcessReportFilter)]
        [TestCase(MethodGetReportFilters)]
        public void AUT_ReportingData_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_reportingDataInstanceFixture,
                                                                              _reportingDataInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataSet) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingData_GetReportingData_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReportingDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, Fixture, methodGetReportingDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataSet) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var bRollup = CreateType<bool>();
            var query = CreateType<string>();
            var orderby = CreateType<string>();
            var page = CreateType<int>();
            var pagesize = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => ReportingData.GetReportingData(web, list, bRollup, query, orderby, page, pagesize);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var bRollup = CreateType<bool>();
            var query = CreateType<string>();
            var orderby = CreateType<string>();
            var page = CreateType<int>();
            var pagesize = CreateType<int>();
            var methodGetReportingDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfGetReportingData = { web, list, bRollup, query, orderby, page, pagesize };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportingData, methodGetReportingDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, Fixture, methodGetReportingDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataSet>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, parametersOfGetReportingData, methodGetReportingDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportingDataInstanceFixture, parametersOfGetReportingData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReportingData.ShouldNotBeNull();
            parametersOfGetReportingData.Length.ShouldBe(7);
            methodGetReportingDataPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataSet) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var bRollup = CreateType<bool>();
            var query = CreateType<string>();
            var orderby = CreateType<string>();
            var page = CreateType<int>();
            var pagesize = CreateType<int>();
            var methodGetReportingDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfGetReportingData = { web, list, bRollup, query, orderby, page, pagesize };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataSet>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, parametersOfGetReportingData, methodGetReportingDataPrametersTypes);

            // Assert
            parametersOfGetReportingData.ShouldNotBeNull();
            parametersOfGetReportingData.Length.ShouldBe(7);
            methodGetReportingDataPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataSet) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReportingDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(string), typeof(string), typeof(int), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, Fixture, methodGetReportingDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReportingDataPrametersTypes.Length.ShouldBe(7);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataSet) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReportingDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(string), typeof(string), typeof(int), typeof(int) };
            const int parametersCount = 7;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, Fixture, methodGetReportingDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReportingDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataSet) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportingData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataSet) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReportingData, 0);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingData_GetReportingData_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetReportingDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, Fixture, methodGetReportingDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var bRollup = CreateType<bool>();
            var query = CreateType<string>();
            var orderby = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ReportingData.GetReportingData(web, list, bRollup, query, orderby);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var bRollup = CreateType<bool>();
            var query = CreateType<string>();
            var orderby = CreateType<string>();
            var methodGetReportingDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(string), typeof(string) };
            object[] parametersOfGetReportingData = { web, list, bRollup, query, orderby };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportingData, methodGetReportingDataPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, Fixture, methodGetReportingDataPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, parametersOfGetReportingData, methodGetReportingDataPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportingDataInstanceFixture, parametersOfGetReportingData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReportingData.ShouldNotBeNull();
            parametersOfGetReportingData.Length.ShouldBe(5);
            methodGetReportingDataPrametersTypes.Length.ShouldBe(5);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<string>();
            var bRollup = CreateType<bool>();
            var query = CreateType<string>();
            var orderby = CreateType<string>();
            var methodGetReportingDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(string), typeof(string) };
            object[] parametersOfGetReportingData = { web, list, bRollup, query, orderby };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataTable>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, parametersOfGetReportingData, methodGetReportingDataPrametersTypes);

            // Assert
            parametersOfGetReportingData.ShouldNotBeNull();
            parametersOfGetReportingData.Length.ShouldBe(5);
            methodGetReportingDataPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReportingDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, Fixture, methodGetReportingDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReportingDataPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReportingDataPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(bool), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportingData, Fixture, methodGetReportingDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReportingDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportingData, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportingData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportingData_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReportingData, 1);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingData_GetReportQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReportQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportQuery, Fixture, methodGetReportQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportQuery) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQuery_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var spquery = CreateType<string>();
            var orderby = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ReportingData.GetReportQuery(web, list, spquery, out orderby);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetReportQuery) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQuery_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var spquery = CreateType<string>();
            var orderby = CreateType<string>();
            var methodGetReportQueryPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string), typeof(string) };
            object[] parametersOfGetReportQuery = { web, list, spquery, orderby };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetReportQuery, methodGetReportQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingDataInstanceFixture, parametersOfGetReportQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetReportQuery.ShouldNotBeNull();
            parametersOfGetReportQuery.Length.ShouldBe(4);
            methodGetReportQueryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var spquery = CreateType<string>();
            var orderby = CreateType<string>();
            var methodGetReportQueryPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string), typeof(string) };
            object[] parametersOfGetReportQuery = { web, list, spquery, orderby };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportQuery, parametersOfGetReportQuery, methodGetReportQueryPrametersTypes);

            // Assert
            parametersOfGetReportQuery.ShouldNotBeNull();
            parametersOfGetReportQuery.Length.ShouldBe(4);
            methodGetReportQueryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQuery_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReportQueryPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportQuery, Fixture, methodGetReportQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReportQueryPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetReportQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReportQueryPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportQuery, Fixture, methodGetReportQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReportQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportQuery) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetReportQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReportQuery, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportQueryNode) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingData_GetReportQueryNode_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReportQueryNodePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportQueryNode, Fixture, methodGetReportQueryNodePrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportQueryNode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQueryNode_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var nd = CreateType<XmlNode>();
            var list = CreateType<SPList>();
            var methodGetReportQueryNodePrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode), typeof(SPList) };
            object[] parametersOfGetReportQueryNode = { web, nd, list };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportQueryNode, methodGetReportQueryNodePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportQueryNode, Fixture, methodGetReportQueryNodePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportQueryNode, parametersOfGetReportQueryNode, methodGetReportQueryNodePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportingDataInstanceFixture, parametersOfGetReportQueryNode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReportQueryNode.ShouldNotBeNull();
            parametersOfGetReportQueryNode.Length.ShouldBe(3);
            methodGetReportQueryNodePrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetReportQueryNode) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQueryNode_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var nd = CreateType<XmlNode>();
            var list = CreateType<SPList>();
            var methodGetReportQueryNodePrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode), typeof(SPList) };
            object[] parametersOfGetReportQueryNode = { web, nd, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportQueryNode, parametersOfGetReportQueryNode, methodGetReportQueryNodePrametersTypes);

            // Assert
            parametersOfGetReportQueryNode.ShouldNotBeNull();
            parametersOfGetReportQueryNode.Length.ShouldBe(3);
            methodGetReportQueryNodePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportQueryNode) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQueryNode_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReportQueryNodePrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode), typeof(SPList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportQueryNode, Fixture, methodGetReportQueryNodePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReportQueryNodePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetReportQueryNode) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQueryNode_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReportQueryNodePrametersTypes = new Type[] { typeof(SPWeb), typeof(XmlNode), typeof(SPList) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportQueryNode, Fixture, methodGetReportQueryNodePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReportQueryNodePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportQueryNode) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQueryNode_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportQueryNode, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportQueryNode) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportQueryNode_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReportQueryNode, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNodeSign) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingData_GetNodeSign_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetNodeSignPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetNodeSign, Fixture, methodGetNodeSignPrametersTypes);
        }

        #endregion

        #region Method Call : (GetNodeSign) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetNodeSign_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ReportingData.GetNodeSign(name);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetNodeSign) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetNodeSign_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodGetNodeSignPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetNodeSign = { name };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetNodeSign, methodGetNodeSignPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetNodeSign, Fixture, methodGetNodeSignPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetNodeSign, parametersOfGetNodeSign, methodGetNodeSignPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetNodeSign.ShouldNotBeNull();
            parametersOfGetNodeSign.Length.ShouldBe(1);
            methodGetNodeSignPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetNodeSign, parametersOfGetNodeSign, methodGetNodeSignPrametersTypes));
        }

        #endregion

        #region Method Call : (GetNodeSign) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetNodeSign_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodGetNodeSignPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetNodeSign = { name };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetNodeSign, methodGetNodeSignPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingDataInstanceFixture, parametersOfGetNodeSign);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetNodeSign.ShouldNotBeNull();
            parametersOfGetNodeSign.Length.ShouldBe(1);
            methodGetNodeSignPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNodeSign) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetNodeSign_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodGetNodeSignPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetNodeSign = { name };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetNodeSign, parametersOfGetNodeSign, methodGetNodeSignPrametersTypes);

            // Assert
            parametersOfGetNodeSign.ShouldNotBeNull();
            parametersOfGetNodeSign.Length.ShouldBe(1);
            methodGetNodeSignPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetNodeSign) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetNodeSign_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetNodeSignPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetNodeSign, Fixture, methodGetNodeSignPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetNodeSignPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetNodeSign) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetNodeSign_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetNodeSignPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetNodeSign, Fixture, methodGetNodeSignPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetNodeSignPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetNodeSign) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetNodeSign_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetNodeSign, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetNodeSign) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetNodeSign_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetNodeSign, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingData_ProcessReportFilter_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessReportFilterPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodProcessReportFilter, Fixture, methodProcessReportFilterPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_ProcessReportFilter_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            var filterWpId = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => ReportingData.ProcessReportFilter(list, web, filterWpId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_ProcessReportFilter_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            var filterWpId = CreateType<string>();
            var methodProcessReportFilterPrametersTypes = new Type[] { typeof(SPList), typeof(SPWeb), typeof(string) };
            object[] parametersOfProcessReportFilter = { list, web, filterWpId };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessReportFilter, methodProcessReportFilterPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodProcessReportFilter, Fixture, methodProcessReportFilterPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodProcessReportFilter, parametersOfProcessReportFilter, methodProcessReportFilterPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportingDataInstanceFixture, parametersOfProcessReportFilter);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfProcessReportFilter.ShouldNotBeNull();
            parametersOfProcessReportFilter.Length.ShouldBe(3);
            methodProcessReportFilterPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_ProcessReportFilter_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var web = CreateType<SPWeb>();
            var filterWpId = CreateType<string>();
            var methodProcessReportFilterPrametersTypes = new Type[] { typeof(SPList), typeof(SPWeb), typeof(string) };
            object[] parametersOfProcessReportFilter = { list, web, filterWpId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodProcessReportFilter, parametersOfProcessReportFilter, methodProcessReportFilterPrametersTypes);

            // Assert
            parametersOfProcessReportFilter.ShouldNotBeNull();
            parametersOfProcessReportFilter.Length.ShouldBe(3);
            methodProcessReportFilterPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_ProcessReportFilter_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodProcessReportFilterPrametersTypes = new Type[] { typeof(SPList), typeof(SPWeb), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodProcessReportFilter, Fixture, methodProcessReportFilterPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodProcessReportFilterPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_ProcessReportFilter_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessReportFilterPrametersTypes = new Type[] { typeof(SPList), typeof(SPWeb), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodProcessReportFilter, Fixture, methodProcessReportFilterPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessReportFilterPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_ProcessReportFilter_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessReportFilter, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ProcessReportFilter) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_ProcessReportFilter_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessReportFilter, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingData_GetReportFilters_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReportFiltersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportFilters, Fixture, methodGetReportFiltersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportFilters_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var reportFilterIDs = CreateType<ArrayList>();
            var methodGetReportFiltersPrametersTypes = new Type[] { typeof(ArrayList) };
            object[] parametersOfGetReportFilters = { reportFilterIDs };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetReportFilters, methodGetReportFiltersPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingDataInstanceFixture, parametersOfGetReportFilters);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetReportFilters.ShouldNotBeNull();
            parametersOfGetReportFilters.Length.ShouldBe(1);
            methodGetReportFiltersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportFilters_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reportFilterIDs = CreateType<ArrayList>();
            var methodGetReportFiltersPrametersTypes = new Type[] { typeof(ArrayList) };
            object[] parametersOfGetReportFilters = { reportFilterIDs };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportFilters, parametersOfGetReportFilters, methodGetReportFiltersPrametersTypes);

            // Assert
            parametersOfGetReportFilters.ShouldNotBeNull();
            parametersOfGetReportFilters.Length.ShouldBe(1);
            methodGetReportFiltersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportFilters_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetReportFiltersPrametersTypes = new Type[] { typeof(ArrayList) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportFilters, Fixture, methodGetReportFiltersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReportFiltersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportFilters_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReportFiltersPrametersTypes = new Type[] { typeof(ArrayList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingDataInstanceFixture, _reportingDataInstanceType, MethodGetReportFilters, Fixture, methodGetReportFiltersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReportFiltersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportFilters_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportFilters, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingDataInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetReportFilters) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingData_GetReportFilters_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReportFilters, 0);
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