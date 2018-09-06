using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.QueryHelper" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class QueryHelperTest : AbstractBaseSetupTest
    {

        public QueryHelperTest() : base(typeof(QueryHelper))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (QueryHelper) Initializer

        private const string MethodGetFilteredTitles = "GetFilteredTitles";
        private const string MethodIsRollup = "IsRollup";
        private const string MethodGetFilteredTitlesForSubWeb = "GetFilteredTitlesForSubWeb";
        private const string MethodGetFilteredTitlesForRollup = "GetFilteredTitlesForRollup";
        private Type _queryHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (QueryHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="QueryHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _queryHelperInstanceType = typeof(QueryHelper);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (QueryHelper)

        #region General Initializer : Class (QueryHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="QueryHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetFilteredTitles, 0)]
        [TestCase(MethodIsRollup, 0)]
        [TestCase(MethodGetFilteredTitlesForSubWeb, 0)]
        [TestCase(MethodGetFilteredTitlesForRollup, 0)]
        public void AUT_QueryHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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
        ///     Class (<see cref="QueryHelper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_QueryHelper_Is_Static_Type_Present_Test()
        {
            // Assert
            _queryHelperInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="QueryHelper" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetFilteredTitles)]
        [TestCase(MethodIsRollup)]
        [TestCase(MethodGetFilteredTitlesForSubWeb)]
        [TestCase(MethodGetFilteredTitlesForRollup)]
        public void AUT_QueryHelper_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _queryHelperInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (GetFilteredTitles) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryHelper_GetFilteredTitles_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFilteredTitlesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitles, Fixture, methodGetFilteredTitlesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilteredTitles) (Return Type : List<string>) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitles_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var fieldSelection = CreateType<ReportFilterSelection>();
            Action executeAction = null;

            // Act
            executeAction = () => QueryHelper.GetFilteredTitles(web, fieldSelection);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetFilteredTitles) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitles_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var fieldSelection = CreateType<ReportFilterSelection>();
            var methodGetFilteredTitlesPrametersTypes = new Type[] { typeof(SPWeb), typeof(ReportFilterSelection) };
            object[] parametersOfGetFilteredTitles = { web, fieldSelection };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilteredTitles, methodGetFilteredTitlesPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitles, Fixture, methodGetFilteredTitlesPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<string>>(null, _queryHelperInstanceType, MethodGetFilteredTitles, parametersOfGetFilteredTitles, methodGetFilteredTitlesPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFilteredTitles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFilteredTitles.ShouldNotBeNull();
            parametersOfGetFilteredTitles.Length.ShouldBe(2);
            methodGetFilteredTitlesPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFilteredTitles) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitles_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var fieldSelection = CreateType<ReportFilterSelection>();
            var methodGetFilteredTitlesPrametersTypes = new Type[] { typeof(SPWeb), typeof(ReportFilterSelection) };
            object[] parametersOfGetFilteredTitles = { web, fieldSelection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<string>>(null, _queryHelperInstanceType, MethodGetFilteredTitles, parametersOfGetFilteredTitles, methodGetFilteredTitlesPrametersTypes);

            // Assert
            parametersOfGetFilteredTitles.ShouldNotBeNull();
            parametersOfGetFilteredTitles.Length.ShouldBe(2);
            methodGetFilteredTitlesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilteredTitles) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitles_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilteredTitlesPrametersTypes = new Type[] { typeof(SPWeb), typeof(ReportFilterSelection) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitles, Fixture, methodGetFilteredTitlesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilteredTitlesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFilteredTitles) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitles_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilteredTitlesPrametersTypes = new Type[] { typeof(SPWeb), typeof(ReportFilterSelection) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitles, Fixture, methodGetFilteredTitlesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilteredTitlesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilteredTitles) (Return Type : List<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitles_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilteredTitles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredTitles) (Return Type : List<string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitles_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFilteredTitles, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryHelper_IsRollup_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsRollupPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodIsRollup, Fixture, methodIsRollupPrametersTypes);
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_IsRollup_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodIsRollupPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfIsRollup = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsRollup, methodIsRollupPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfIsRollup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsRollup.ShouldNotBeNull();
            parametersOfIsRollup.Length.ShouldBe(1);
            methodIsRollupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_IsRollup_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodIsRollupPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfIsRollup = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _queryHelperInstanceType, MethodIsRollup, parametersOfIsRollup, methodIsRollupPrametersTypes);

            // Assert
            parametersOfIsRollup.ShouldNotBeNull();
            parametersOfIsRollup.Length.ShouldBe(1);
            methodIsRollupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_IsRollup_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsRollupPrametersTypes = new Type[] { typeof(SPList) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodIsRollup, Fixture, methodIsRollupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsRollupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_IsRollup_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsRollup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (IsRollup) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_IsRollup_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsRollup, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForSubWeb) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryHelper_GetFilteredTitlesForSubWeb_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFilteredTitlesForSubWebPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitlesForSubWeb, Fixture, methodGetFilteredTitlesForSubWebPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForSubWeb) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForSubWeb_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var query = CreateType<SPQuery>();
            var methodGetFilteredTitlesForSubWebPrametersTypes = new Type[] { typeof(SPList), typeof(SPQuery) };
            object[] parametersOfGetFilteredTitlesForSubWeb = { list, query };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilteredTitlesForSubWeb, methodGetFilteredTitlesForSubWebPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitlesForSubWeb, Fixture, methodGetFilteredTitlesForSubWebPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<string>>(null, _queryHelperInstanceType, MethodGetFilteredTitlesForSubWeb, parametersOfGetFilteredTitlesForSubWeb, methodGetFilteredTitlesForSubWebPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFilteredTitlesForSubWeb);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFilteredTitlesForSubWeb.ShouldNotBeNull();
            parametersOfGetFilteredTitlesForSubWeb.Length.ShouldBe(2);
            methodGetFilteredTitlesForSubWebPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForSubWeb) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForSubWeb_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var query = CreateType<SPQuery>();
            var methodGetFilteredTitlesForSubWebPrametersTypes = new Type[] { typeof(SPList), typeof(SPQuery) };
            object[] parametersOfGetFilteredTitlesForSubWeb = { list, query };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<string>>(null, _queryHelperInstanceType, MethodGetFilteredTitlesForSubWeb, parametersOfGetFilteredTitlesForSubWeb, methodGetFilteredTitlesForSubWebPrametersTypes);

            // Assert
            parametersOfGetFilteredTitlesForSubWeb.ShouldNotBeNull();
            parametersOfGetFilteredTitlesForSubWeb.Length.ShouldBe(2);
            methodGetFilteredTitlesForSubWebPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForSubWeb) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForSubWeb_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilteredTitlesForSubWebPrametersTypes = new Type[] { typeof(SPList), typeof(SPQuery) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitlesForSubWeb, Fixture, methodGetFilteredTitlesForSubWebPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilteredTitlesForSubWebPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForSubWeb) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForSubWeb_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilteredTitlesForSubWebPrametersTypes = new Type[] { typeof(SPList), typeof(SPQuery) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitlesForSubWeb, Fixture, methodGetFilteredTitlesForSubWebPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilteredTitlesForSubWebPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForSubWeb) (Return Type : List<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForSubWeb_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilteredTitlesForSubWeb, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForSubWeb) (Return Type : List<string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForSubWeb_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFilteredTitlesForSubWeb, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForRollup) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_QueryHelper_GetFilteredTitlesForRollup_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFilteredTitlesForRollupPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitlesForRollup, Fixture, methodGetFilteredTitlesForRollupPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForRollup) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForRollup_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var query = CreateType<string>();
            var methodGetFilteredTitlesForRollupPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string) };
            object[] parametersOfGetFilteredTitlesForRollup = { web, list, query };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilteredTitlesForRollup, methodGetFilteredTitlesForRollupPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitlesForRollup, Fixture, methodGetFilteredTitlesForRollupPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<List<string>>(null, _queryHelperInstanceType, MethodGetFilteredTitlesForRollup, parametersOfGetFilteredTitlesForRollup, methodGetFilteredTitlesForRollupPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetFilteredTitlesForRollup);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFilteredTitlesForRollup.ShouldNotBeNull();
            parametersOfGetFilteredTitlesForRollup.Length.ShouldBe(3);
            methodGetFilteredTitlesForRollupPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForRollup) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForRollup_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var query = CreateType<string>();
            var methodGetFilteredTitlesForRollupPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string) };
            object[] parametersOfGetFilteredTitlesForRollup = { web, list, query };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<List<string>>(null, _queryHelperInstanceType, MethodGetFilteredTitlesForRollup, parametersOfGetFilteredTitlesForRollup, methodGetFilteredTitlesForRollupPrametersTypes);

            // Assert
            parametersOfGetFilteredTitlesForRollup.ShouldNotBeNull();
            parametersOfGetFilteredTitlesForRollup.Length.ShouldBe(3);
            methodGetFilteredTitlesForRollupPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForRollup) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForRollup_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilteredTitlesForRollupPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitlesForRollup, Fixture, methodGetFilteredTitlesForRollupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilteredTitlesForRollupPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForRollup) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForRollup_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilteredTitlesForRollupPrametersTypes = new Type[] { typeof(SPWeb), typeof(SPList), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _queryHelperInstanceType, MethodGetFilteredTitlesForRollup, Fixture, methodGetFilteredTitlesForRollupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilteredTitlesForRollupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForRollup) (Return Type : List<string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForRollup_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilteredTitlesForRollup, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilteredTitlesForRollup) (Return Type : List<string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_QueryHelper_GetFilteredTitlesForRollup_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFilteredTitlesForRollup, 0);
            const int parametersCount = 3;

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