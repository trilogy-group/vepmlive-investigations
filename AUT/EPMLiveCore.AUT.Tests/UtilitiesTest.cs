using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
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
using Microsoft.Win32;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore;
using Utilities = EPMLiveCore;

namespace EPMLiveCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Utilities" />)
    ///     and namespace <see cref="EPMLiveCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UtilitiesTest : AbstractBaseSetupTest
    {

        public UtilitiesTest() : base(typeof(Utilities))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Utilities) Initializer

        private const string MethodComposeCamlQuery = "ComposeCamlQuery";
        private const string MethodDecodeGridData = "DecodeGridData";
        private const string MethodGetReportingDbConnectionString = "GetReportingDbConnectionString";
        private const string MethodGetPFEDBConnectionString = "GetPFEDBConnectionString";
        private const string MethodDecrypt = "Decrypt";
        private const string MethodGetRegistryKey = "GetRegistryKey";
        private const string MethodCheckEditResourcePlanPermission = "CheckEditResourcePlanPermission";
        private const string MethodReloadListItem = "ReloadListItem";
        private const string MethodGetRoleRates = "GetRoleRates";
        private Type _utilitiesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (Utilities) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Utilities" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _utilitiesInstanceType = typeof(Utilities);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Utilities)

        #region General Initializer : Class (Utilities) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Utilities" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodComposeCamlQuery, 0)]
        [TestCase(MethodDecodeGridData, 0)]
        [TestCase(MethodGetReportingDbConnectionString, 0)]
        [TestCase(MethodGetPFEDBConnectionString, 0)]
        [TestCase(MethodDecrypt, 0)]
        [TestCase(MethodGetRegistryKey, 0)]
        [TestCase(MethodCheckEditResourcePlanPermission, 0)]
        [TestCase(MethodReloadListItem, 0)]
        [TestCase(MethodGetRoleRates, 0)]
        public void AUT_Utilities_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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
        ///     Class (<see cref="Utilities" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Utilities_Is_Static_Type_Present_Test()
        {
            // Assert
            _utilitiesInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Utilities" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodComposeCamlQuery)]
        [TestCase(MethodDecodeGridData)]
        [TestCase(MethodGetReportingDbConnectionString)]
        [TestCase(MethodGetPFEDBConnectionString)]
        [TestCase(MethodDecrypt)]
        [TestCase(MethodGetRegistryKey)]
        [TestCase(MethodCheckEditResourcePlanPermission)]
        [TestCase(MethodReloadListItem)]
        [TestCase(MethodGetRoleRates)]
        public void AUT_Utilities_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _utilitiesInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (ComposeCamlQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_ComposeCamlQuery_Static_Method_Call_Internally(Type[] types)
        {
            var methodComposeCamlQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodComposeCamlQuery, Fixture, methodComposeCamlQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (ComposeCamlQuery) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ComposeCamlQuery_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var parameters = CreateType<IList<string>>();
            var op = CreateType<string>();
            var whereClause = CreateType<string>();
            var query = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.ComposeCamlQuery(parameters, op, whereClause, query);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ComposeCamlQuery) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ComposeCamlQuery_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var parameters = CreateType<IList<string>>();
            var op = CreateType<string>();
            var whereClause = CreateType<string>();
            var query = CreateType<string>();
            var methodComposeCamlQueryPrametersTypes = new Type[] { typeof(IList<string>), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfComposeCamlQuery = { parameters, op, whereClause, query };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodComposeCamlQuery, methodComposeCamlQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfComposeCamlQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfComposeCamlQuery.ShouldNotBeNull();
            parametersOfComposeCamlQuery.Length.ShouldBe(4);
            methodComposeCamlQueryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ComposeCamlQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ComposeCamlQuery_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var parameters = CreateType<IList<string>>();
            var op = CreateType<string>();
            var whereClause = CreateType<string>();
            var query = CreateType<string>();
            var methodComposeCamlQueryPrametersTypes = new Type[] { typeof(IList<string>), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfComposeCamlQuery = { parameters, op, whereClause, query };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodComposeCamlQuery, parametersOfComposeCamlQuery, methodComposeCamlQueryPrametersTypes);

            // Assert
            parametersOfComposeCamlQuery.ShouldNotBeNull();
            parametersOfComposeCamlQuery.Length.ShouldBe(4);
            methodComposeCamlQueryPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ComposeCamlQuery) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ComposeCamlQuery_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodComposeCamlQueryPrametersTypes = new Type[] { typeof(IList<string>), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodComposeCamlQuery, Fixture, methodComposeCamlQueryPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodComposeCamlQueryPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (ComposeCamlQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ComposeCamlQuery_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodComposeCamlQueryPrametersTypes = new Type[] { typeof(IList<string>), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodComposeCamlQuery, Fixture, methodComposeCamlQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodComposeCamlQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ComposeCamlQuery) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ComposeCamlQuery_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodComposeCamlQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ComposeCamlQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ComposeCamlQuery_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodComposeCamlQuery, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeGridData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_DecodeGridData_Static_Method_Call_Internally(Type[] types)
        {
            var methodDecodeGridDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodDecodeGridData, Fixture, methodDecodeGridDataPrametersTypes);
        }

        #endregion

        #region Method Call : (DecodeGridData) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DecodeGridData_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.DecodeGridData(data);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DecodeGridData) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DecodeGridData_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDecodeGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecodeGridData = { data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDecodeGridData, methodDecodeGridDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfDecodeGridData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDecodeGridData.ShouldNotBeNull();
            parametersOfDecodeGridData.Length.ShouldBe(1);
            methodDecodeGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeGridData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DecodeGridData_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDecodeGridDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecodeGridData = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodDecodeGridData, parametersOfDecodeGridData, methodDecodeGridDataPrametersTypes);

            // Assert
            parametersOfDecodeGridData.ShouldNotBeNull();
            parametersOfDecodeGridData.Length.ShouldBe(1);
            methodDecodeGridDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DecodeGridData) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DecodeGridData_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodDecodeGridDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodDecodeGridData, Fixture, methodDecodeGridDataPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodDecodeGridDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DecodeGridData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DecodeGridData_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecodeGridDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodDecodeGridData, Fixture, methodDecodeGridDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecodeGridDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DecodeGridData) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DecodeGridData_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecodeGridData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DecodeGridData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_DecodeGridData_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecodeGridData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportingDbConnectionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetReportingDbConnectionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReportingDbConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetReportingDbConnectionString, Fixture, methodGetReportingDbConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportingDbConnectionString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetReportingDbConnectionString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var epmliveConnection = CreateType<string>();
            var siteId = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetReportingDbConnectionString(epmliveConnection, siteId, webAppId);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetReportingDbConnectionString) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetReportingDbConnectionString_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var epmliveConnection = CreateType<string>();
            var siteId = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            var methodGetReportingDbConnectionStringPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid) };
            object[] parametersOfGetReportingDbConnectionString = { epmliveConnection, siteId, webAppId };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportingDbConnectionString, methodGetReportingDbConnectionStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetReportingDbConnectionString, Fixture, methodGetReportingDbConnectionStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetReportingDbConnectionString, parametersOfGetReportingDbConnectionString, methodGetReportingDbConnectionStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetReportingDbConnectionString.ShouldNotBeNull();
            parametersOfGetReportingDbConnectionString.Length.ShouldBe(3);
            methodGetReportingDbConnectionStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetReportingDbConnectionString, parametersOfGetReportingDbConnectionString, methodGetReportingDbConnectionStringPrametersTypes));
        }

        #endregion

        #region Method Call : (GetReportingDbConnectionString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetReportingDbConnectionString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var epmliveConnection = CreateType<string>();
            var siteId = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            var methodGetReportingDbConnectionStringPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid) };
            object[] parametersOfGetReportingDbConnectionString = { epmliveConnection, siteId, webAppId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetReportingDbConnectionString, methodGetReportingDbConnectionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetReportingDbConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetReportingDbConnectionString.ShouldNotBeNull();
            parametersOfGetReportingDbConnectionString.Length.ShouldBe(3);
            methodGetReportingDbConnectionStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingDbConnectionString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetReportingDbConnectionString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var epmliveConnection = CreateType<string>();
            var siteId = CreateType<Guid>();
            var webAppId = CreateType<Guid>();
            var methodGetReportingDbConnectionStringPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid) };
            object[] parametersOfGetReportingDbConnectionString = { epmliveConnection, siteId, webAppId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetReportingDbConnectionString, parametersOfGetReportingDbConnectionString, methodGetReportingDbConnectionStringPrametersTypes);

            // Assert
            parametersOfGetReportingDbConnectionString.ShouldNotBeNull();
            parametersOfGetReportingDbConnectionString.Length.ShouldBe(3);
            methodGetReportingDbConnectionStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportingDbConnectionString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetReportingDbConnectionString_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetReportingDbConnectionStringPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetReportingDbConnectionString, Fixture, methodGetReportingDbConnectionStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetReportingDbConnectionStringPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetReportingDbConnectionString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetReportingDbConnectionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetReportingDbConnectionStringPrametersTypes = new Type[] { typeof(string), typeof(Guid), typeof(Guid) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetReportingDbConnectionString, Fixture, methodGetReportingDbConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReportingDbConnectionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetReportingDbConnectionString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetReportingDbConnectionString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportingDbConnectionString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetReportingDbConnectionString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetReportingDbConnectionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetReportingDbConnectionString, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPFEDBConnectionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetPFEDBConnectionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetPFEDBConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetPFEDBConnectionString, Fixture, methodGetPFEDBConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPFEDBConnectionString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetPFEDBConnectionString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetPFEDBConnectionString(basepath);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetPFEDBConnectionString) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetPFEDBConnectionString_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var methodGetPFEDBConnectionStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPFEDBConnectionString = { basepath };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPFEDBConnectionString, methodGetPFEDBConnectionStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetPFEDBConnectionString, Fixture, methodGetPFEDBConnectionStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetPFEDBConnectionString, parametersOfGetPFEDBConnectionString, methodGetPFEDBConnectionStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetPFEDBConnectionString.ShouldNotBeNull();
            parametersOfGetPFEDBConnectionString.Length.ShouldBe(1);
            methodGetPFEDBConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetPFEDBConnectionString, parametersOfGetPFEDBConnectionString, methodGetPFEDBConnectionStringPrametersTypes));
        }

        #endregion

        #region Method Call : (GetPFEDBConnectionString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetPFEDBConnectionString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var methodGetPFEDBConnectionStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPFEDBConnectionString = { basepath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetPFEDBConnectionString, methodGetPFEDBConnectionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetPFEDBConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetPFEDBConnectionString.ShouldNotBeNull();
            parametersOfGetPFEDBConnectionString.Length.ShouldBe(1);
            methodGetPFEDBConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPFEDBConnectionString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetPFEDBConnectionString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var methodGetPFEDBConnectionStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetPFEDBConnectionString = { basepath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodGetPFEDBConnectionString, parametersOfGetPFEDBConnectionString, methodGetPFEDBConnectionStringPrametersTypes);

            // Assert
            parametersOfGetPFEDBConnectionString.ShouldNotBeNull();
            parametersOfGetPFEDBConnectionString.Length.ShouldBe(1);
            methodGetPFEDBConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPFEDBConnectionString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetPFEDBConnectionString_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetPFEDBConnectionStringPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetPFEDBConnectionString, Fixture, methodGetPFEDBConnectionStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetPFEDBConnectionStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPFEDBConnectionString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetPFEDBConnectionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPFEDBConnectionStringPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetPFEDBConnectionString, Fixture, methodGetPFEDBConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPFEDBConnectionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPFEDBConnectionString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetPFEDBConnectionString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPFEDBConnectionString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetPFEDBConnectionString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetPFEDBConnectionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPFEDBConnectionString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_Decrypt_Static_Method_Call_Internally(Type[] types)
        {
            var methodDecryptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_Decrypt_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var base64Text = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecrypt = { base64Text };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDecrypt, methodDecryptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfDecrypt);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(1);
            methodDecryptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_Decrypt_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var base64Text = CreateType<string>();
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDecrypt = { base64Text };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _utilitiesInstanceType, MethodDecrypt, parametersOfDecrypt, methodDecryptPrametersTypes);

            // Assert
            parametersOfDecrypt.ShouldNotBeNull();
            parametersOfDecrypt.Length.ShouldBe(1);
            methodDecryptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_Decrypt_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDecryptPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_Decrypt_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDecryptPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodDecrypt, Fixture, methodDecryptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDecryptPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_Decrypt_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDecrypt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Decrypt) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_Decrypt_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDecrypt, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetRegistryKey_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRegistryKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetRegistryKey, Fixture, methodGetRegistryKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var methodGetRegistryKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetRegistryKey = { basepath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetRegistryKey, methodGetRegistryKeyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRegistryKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetRegistryKey.ShouldNotBeNull();
            parametersOfGetRegistryKey.Length.ShouldBe(1);
            methodGetRegistryKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var methodGetRegistryKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetRegistryKey = { basepath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<RegistryKey>(null, _utilitiesInstanceType, MethodGetRegistryKey, parametersOfGetRegistryKey, methodGetRegistryKeyPrametersTypes);

            // Assert
            parametersOfGetRegistryKey.ShouldNotBeNull();
            parametersOfGetRegistryKey.Length.ShouldBe(1);
            methodGetRegistryKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetRegistryKeyPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetRegistryKey, Fixture, methodGetRegistryKeyPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRegistryKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRegistryKeyPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetRegistryKey, Fixture, methodGetRegistryKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRegistryKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRegistryKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRegistryKey) (Return Type : RegistryKey) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRegistryKey_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRegistryKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckEditResourcePlanPermission) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_CheckEditResourcePlanPermission_Static_Method_Call_Internally(Type[] types)
        {
            var methodCheckEditResourcePlanPermissionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodCheckEditResourcePlanPermission, Fixture, methodCheckEditResourcePlanPermissionPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckEditResourcePlanPermission) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckEditResourcePlanPermission_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.CheckEditResourcePlanPermission(basepath, username);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CheckEditResourcePlanPermission) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckEditResourcePlanPermission_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var methodCheckEditResourcePlanPermissionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfCheckEditResourcePlanPermission = { basepath, username };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _utilitiesInstanceType, MethodCheckEditResourcePlanPermission, parametersOfCheckEditResourcePlanPermission, methodCheckEditResourcePlanPermissionPrametersTypes);

            // Assert
            parametersOfCheckEditResourcePlanPermission.ShouldNotBeNull();
            parametersOfCheckEditResourcePlanPermission.Length.ShouldBe(2);
            methodCheckEditResourcePlanPermissionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckEditResourcePlanPermission) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckEditResourcePlanPermission_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckEditResourcePlanPermissionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodCheckEditResourcePlanPermission, Fixture, methodCheckEditResourcePlanPermissionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckEditResourcePlanPermissionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckEditResourcePlanPermission) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckEditResourcePlanPermission_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckEditResourcePlanPermission, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckEditResourcePlanPermission) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_CheckEditResourcePlanPermission_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckEditResourcePlanPermission, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReloadListItem) (Return Type : SPListItem) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_ReloadListItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodReloadListItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodReloadListItem, Fixture, methodReloadListItemPrametersTypes);
        }

        #endregion

        #region Method Call : (ReloadListItem) (Return Type : SPListItem) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ReloadListItem_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.ReloadListItem(item);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ReloadListItem) (Return Type : SPListItem) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ReloadListItem_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodReloadListItemPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfReloadListItem = { item };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReloadListItem, methodReloadListItemPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfReloadListItem);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReloadListItem.ShouldNotBeNull();
            parametersOfReloadListItem.Length.ShouldBe(1);
            methodReloadListItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReloadListItem) (Return Type : SPListItem) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ReloadListItem_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var item = CreateType<SPListItem>();
            var methodReloadListItemPrametersTypes = new Type[] { typeof(SPListItem) };
            object[] parametersOfReloadListItem = { item };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<SPListItem>(null, _utilitiesInstanceType, MethodReloadListItem, parametersOfReloadListItem, methodReloadListItemPrametersTypes);

            // Assert
            parametersOfReloadListItem.ShouldNotBeNull();
            parametersOfReloadListItem.Length.ShouldBe(1);
            methodReloadListItemPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReloadListItem) (Return Type : SPListItem) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ReloadListItem_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodReloadListItemPrametersTypes = new Type[] { typeof(SPListItem) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodReloadListItem, Fixture, methodReloadListItemPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodReloadListItemPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ReloadListItem) (Return Type : SPListItem) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ReloadListItem_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReloadListItemPrametersTypes = new Type[] { typeof(SPListItem) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodReloadListItem, Fixture, methodReloadListItemPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReloadListItemPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReloadListItem) (Return Type : SPListItem) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ReloadListItem_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReloadListItem, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReloadListItem) (Return Type : SPListItem) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_ReloadListItem_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReloadListItem, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRoleRates) (Return Type : DataSet) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Utilities_GetRoleRates_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRoleRatesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetRoleRates, Fixture, methodGetRoleRatesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRoleRates) (Return Type : DataSet) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRoleRates_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var prd_start = CreateType<string>();
            var prd_end = CreateType<string>();
            var extid = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Utilities.GetRoleRates(basepath, username, prd_start, prd_end, extid);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetRoleRates) (Return Type : DataSet) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRoleRates_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var prd_start = CreateType<string>();
            var prd_end = CreateType<string>();
            var extid = CreateType<string>();
            var methodGetRoleRatesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetRoleRates = { basepath, username, prd_start, prd_end, extid };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetRoleRates, methodGetRoleRatesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetRoleRates);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetRoleRates.ShouldNotBeNull();
            parametersOfGetRoleRates.Length.ShouldBe(5);
            methodGetRoleRatesPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRoleRates) (Return Type : DataSet) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRoleRates_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var prd_start = CreateType<string>();
            var prd_end = CreateType<string>();
            var extid = CreateType<string>();
            var methodGetRoleRatesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetRoleRates = { basepath, username, prd_start, prd_end, extid };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<DataSet>(null, _utilitiesInstanceType, MethodGetRoleRates, parametersOfGetRoleRates, methodGetRoleRatesPrametersTypes);

            // Assert
            parametersOfGetRoleRates.ShouldNotBeNull();
            parametersOfGetRoleRates.Length.ShouldBe(5);
            methodGetRoleRatesPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRoleRates) (Return Type : DataSet) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRoleRates_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetRoleRatesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetRoleRates, Fixture, methodGetRoleRatesPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetRoleRatesPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetRoleRates) (Return Type : DataSet) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRoleRates_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetRoleRatesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _utilitiesInstanceType, MethodGetRoleRates, Fixture, methodGetRoleRatesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRoleRatesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetRoleRates) (Return Type : DataSet) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRoleRates_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRoleRates, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetRoleRates) (Return Type : DataSet) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Utilities_GetRoleRates_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetRoleRates, 0);
            const int parametersCount = 5;

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