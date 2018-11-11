using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore.WEIntegration
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.WEIntegration.WEIntegration" />)
    ///     and namespace <see cref="PortfolioEngineCore.WEIntegration"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WEIntegrationTest : AbstractBaseSetupTypedTest<WEIntegration>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WEIntegration) Initializer

        private const string MethodSetDatabaseVersion = "SetDatabaseVersion";
        private const string MethodExecuteReportExtract = "ExecuteReportExtract";
        private const string MethodPostTimesheetData = "PostTimesheetData";
        private const string MethodGetAutoPosts = "GetAutoPosts";
        private const string MethodPostCostValuesForTimesheetData = "PostCostValuesForTimesheetData";
        private const string MethodSetCharge = "SetCharge";
        private const string MethodGetPfeFields = "GetPfeFields";
        private const string MethodGetPfeCostViews = "GetPfeCostViews";
        private const string MethodDisplayProjects = "DisplayProjects";
        private const string MethodconvertToSQL = "convertToSQL";
        private const string MethodImportReportingConnection = "ImportReportingConnection";
        private Type _wEIntegrationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WEIntegration _wEIntegrationInstance;
        private WEIntegration _wEIntegrationInstanceFixture;

        #region General Initializer : Class (WEIntegration) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WEIntegration" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _wEIntegrationInstanceType = typeof(WEIntegration);
            _wEIntegrationInstanceFixture = Create(true);
            _wEIntegrationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WEIntegration)

        #region General Initializer : Class (WEIntegration) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WEIntegration" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodSetDatabaseVersion, 0)]
        [TestCase(MethodExecuteReportExtract, 0)]
        [TestCase(MethodPostTimesheetData, 0)]
        [TestCase(MethodGetAutoPosts, 0)]
        [TestCase(MethodPostCostValuesForTimesheetData, 0)]
        [TestCase(MethodSetCharge, 0)]
        [TestCase(MethodGetPfeFields, 0)]
        [TestCase(MethodGetPfeCostViews, 0)]
        [TestCase(MethodDisplayProjects, 0)]
        [TestCase(MethodconvertToSQL, 0)]
        [TestCase(MethodImportReportingConnection, 0)]
        public void AUT_WEIntegration_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_wEIntegrationInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WEIntegration" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodconvertToSQL)]
        public void AUT_WEIntegration_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_wEIntegrationInstanceFixture,
                                                                              _wEIntegrationInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WEIntegration" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodSetDatabaseVersion)]
        [TestCase(MethodExecuteReportExtract)]
        [TestCase(MethodPostTimesheetData)]
        [TestCase(MethodGetAutoPosts)]
        [TestCase(MethodPostCostValuesForTimesheetData)]
        [TestCase(MethodSetCharge)]
        [TestCase(MethodGetPfeFields)]
        [TestCase(MethodGetPfeCostViews)]
        [TestCase(MethodDisplayProjects)]
        [TestCase(MethodImportReportingConnection)]
        public void AUT_WEIntegration_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WEIntegration>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_SetDatabaseVersion_Method_Call_Internally(Type[] types)
        {
            var methodSetDatabaseVersionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodSetDatabaseVersion, Fixture, methodSetDatabaseVersionPrametersTypes);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_SetDatabaseVersion_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _wEIntegrationInstance.SetDatabaseVersion(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_SetDatabaseVersion_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodSetDatabaseVersionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetDatabaseVersion = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetDatabaseVersion, methodSetDatabaseVersionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, string>(_wEIntegrationInstanceFixture, out exception1, parametersOfSetDatabaseVersion);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, string>(_wEIntegrationInstance, MethodSetDatabaseVersion, parametersOfSetDatabaseVersion, methodSetDatabaseVersionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfSetDatabaseVersion.ShouldNotBeNull();
            parametersOfSetDatabaseVersion.Length.ShouldBe(1);
            methodSetDatabaseVersionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_SetDatabaseVersion_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodSetDatabaseVersionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetDatabaseVersion = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEIntegration, string>(_wEIntegrationInstance, MethodSetDatabaseVersion, parametersOfSetDatabaseVersion, methodSetDatabaseVersionPrametersTypes);

            // Assert
            parametersOfSetDatabaseVersion.ShouldNotBeNull();
            parametersOfSetDatabaseVersion.Length.ShouldBe(1);
            methodSetDatabaseVersionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_SetDatabaseVersion_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodSetDatabaseVersionPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodSetDatabaseVersion, Fixture, methodSetDatabaseVersionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodSetDatabaseVersionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_SetDatabaseVersion_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDatabaseVersionPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodSetDatabaseVersion, Fixture, methodSetDatabaseVersionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetDatabaseVersionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_SetDatabaseVersion_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDatabaseVersion, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetDatabaseVersion) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_SetDatabaseVersion_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetDatabaseVersion, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_ExecuteReportExtract_Method_Call_Internally(Type[] types)
        {
            var methodExecuteReportExtractPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodExecuteReportExtract, Fixture, methodExecuteReportExtractPrametersTypes);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ExecuteReportExtract_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _wEIntegrationInstance.ExecuteReportExtract(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ExecuteReportExtract_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodExecuteReportExtractPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfExecuteReportExtract = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodExecuteReportExtract, methodExecuteReportExtractPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, string>(_wEIntegrationInstanceFixture, out exception1, parametersOfExecuteReportExtract);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, string>(_wEIntegrationInstance, MethodExecuteReportExtract, parametersOfExecuteReportExtract, methodExecuteReportExtractPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfExecuteReportExtract.ShouldNotBeNull();
            parametersOfExecuteReportExtract.Length.ShouldBe(1);
            methodExecuteReportExtractPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ExecuteReportExtract_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodExecuteReportExtractPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfExecuteReportExtract = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEIntegration, string>(_wEIntegrationInstance, MethodExecuteReportExtract, parametersOfExecuteReportExtract, methodExecuteReportExtractPrametersTypes);

            // Assert
            parametersOfExecuteReportExtract.ShouldNotBeNull();
            parametersOfExecuteReportExtract.Length.ShouldBe(1);
            methodExecuteReportExtractPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ExecuteReportExtract_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodExecuteReportExtractPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodExecuteReportExtract, Fixture, methodExecuteReportExtractPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodExecuteReportExtractPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ExecuteReportExtract_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodExecuteReportExtractPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodExecuteReportExtract, Fixture, methodExecuteReportExtractPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodExecuteReportExtractPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ExecuteReportExtract_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodExecuteReportExtract, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ExecuteReportExtract) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ExecuteReportExtract_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodExecuteReportExtract, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_PostTimesheetData_Method_Call_Internally(Type[] types)
        {
            var methodPostTimesheetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodPostTimesheetData, Fixture, methodPostTimesheetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostTimesheetData_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _wEIntegrationInstance.PostTimesheetData(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostTimesheetData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodPostTimesheetDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPostTimesheetData = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPostTimesheetData, methodPostTimesheetDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, string>(_wEIntegrationInstanceFixture, out exception1, parametersOfPostTimesheetData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, string>(_wEIntegrationInstance, MethodPostTimesheetData, parametersOfPostTimesheetData, methodPostTimesheetDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfPostTimesheetData.ShouldNotBeNull();
            parametersOfPostTimesheetData.Length.ShouldBe(1);
            methodPostTimesheetDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostTimesheetData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodPostTimesheetDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPostTimesheetData = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEIntegration, string>(_wEIntegrationInstance, MethodPostTimesheetData, parametersOfPostTimesheetData, methodPostTimesheetDataPrametersTypes);

            // Assert
            parametersOfPostTimesheetData.ShouldNotBeNull();
            parametersOfPostTimesheetData.Length.ShouldBe(1);
            methodPostTimesheetDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostTimesheetData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodPostTimesheetDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodPostTimesheetData, Fixture, methodPostTimesheetDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodPostTimesheetDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostTimesheetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPostTimesheetDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodPostTimesheetData, Fixture, methodPostTimesheetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPostTimesheetDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostTimesheetData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostTimesheetData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostTimesheetData) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostTimesheetData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPostTimesheetData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_GetAutoPosts_Method_Call_Internally(Type[] types)
        {
            var methodGetAutoPostsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodGetAutoPosts, Fixture, methodGetAutoPostsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetAutoPosts_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var datatype = CreateType<string>();
            var autoposts = CreateType<int[,]>();
            var methodGetAutoPostsPrametersTypes = new Type[] { typeof(string), typeof(int[,]) };
            object[] parametersOfGetAutoPosts = { datatype, autoposts };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAutoPosts, methodGetAutoPostsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, bool>(_wEIntegrationInstanceFixture, out exception1, parametersOfGetAutoPosts);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, bool>(_wEIntegrationInstance, MethodGetAutoPosts, parametersOfGetAutoPosts, methodGetAutoPostsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetAutoPosts.ShouldNotBeNull();
            parametersOfGetAutoPosts.Length.ShouldBe(2);
            methodGetAutoPostsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetAutoPosts_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var datatype = CreateType<string>();
            var autoposts = CreateType<int[,]>();
            var methodGetAutoPostsPrametersTypes = new Type[] { typeof(string), typeof(int[,]) };
            object[] parametersOfGetAutoPosts = { datatype, autoposts };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetAutoPosts, methodGetAutoPostsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, bool>(_wEIntegrationInstanceFixture, out exception1, parametersOfGetAutoPosts);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, bool>(_wEIntegrationInstance, MethodGetAutoPosts, parametersOfGetAutoPosts, methodGetAutoPostsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetAutoPosts.ShouldNotBeNull();
            parametersOfGetAutoPosts.Length.ShouldBe(2);
            methodGetAutoPostsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetAutoPosts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var datatype = CreateType<string>();
            var autoposts = CreateType<int[,]>();
            var methodGetAutoPostsPrametersTypes = new Type[] { typeof(string), typeof(int[,]) };
            object[] parametersOfGetAutoPosts = { datatype, autoposts };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEIntegration, bool>(_wEIntegrationInstance, MethodGetAutoPosts, parametersOfGetAutoPosts, methodGetAutoPostsPrametersTypes);

            // Assert
            parametersOfGetAutoPosts.ShouldNotBeNull();
            parametersOfGetAutoPosts.Length.ShouldBe(2);
            methodGetAutoPostsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetAutoPosts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAutoPostsPrametersTypes = new Type[] { typeof(string), typeof(int[,]) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodGetAutoPosts, Fixture, methodGetAutoPostsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAutoPostsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetAutoPosts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetAutoPosts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetAutoPosts) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetAutoPosts_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAutoPosts, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PostCostValuesForTimesheetData) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_PostCostValuesForTimesheetData_Method_Call_Internally(Type[] types)
        {
            var methodPostCostValuesForTimesheetDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodPostCostValuesForTimesheetData, Fixture, methodPostCostValuesForTimesheetDataPrametersTypes);
        }

        #endregion

        #region Method Call : (PostCostValuesForTimesheetData) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostCostValuesForTimesheetData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodPostCostValuesForTimesheetDataPrametersTypes = null;
            object[] parametersOfPostCostValuesForTimesheetData = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPostCostValuesForTimesheetData, methodPostCostValuesForTimesheetDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, bool>(_wEIntegrationInstanceFixture, out exception1, parametersOfPostCostValuesForTimesheetData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, bool>(_wEIntegrationInstance, MethodPostCostValuesForTimesheetData, parametersOfPostCostValuesForTimesheetData, methodPostCostValuesForTimesheetDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPostCostValuesForTimesheetData.ShouldBeNull();
            methodPostCostValuesForTimesheetDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostCostValuesForTimesheetData) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostCostValuesForTimesheetData_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodPostCostValuesForTimesheetDataPrametersTypes = null;
            object[] parametersOfPostCostValuesForTimesheetData = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPostCostValuesForTimesheetData, methodPostCostValuesForTimesheetDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, bool>(_wEIntegrationInstanceFixture, out exception1, parametersOfPostCostValuesForTimesheetData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, bool>(_wEIntegrationInstance, MethodPostCostValuesForTimesheetData, parametersOfPostCostValuesForTimesheetData, methodPostCostValuesForTimesheetDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPostCostValuesForTimesheetData.ShouldBeNull();
            methodPostCostValuesForTimesheetDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostCostValuesForTimesheetData) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostCostValuesForTimesheetData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPostCostValuesForTimesheetDataPrametersTypes = null;
            object[] parametersOfPostCostValuesForTimesheetData = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEIntegration, bool>(_wEIntegrationInstance, MethodPostCostValuesForTimesheetData, parametersOfPostCostValuesForTimesheetData, methodPostCostValuesForTimesheetDataPrametersTypes);

            // Assert
            parametersOfPostCostValuesForTimesheetData.ShouldBeNull();
            methodPostCostValuesForTimesheetDataPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PostCostValuesForTimesheetData) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostCostValuesForTimesheetData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPostCostValuesForTimesheetDataPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodPostCostValuesForTimesheetData, Fixture, methodPostCostValuesForTimesheetDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPostCostValuesForTimesheetDataPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PostCostValuesForTimesheetData) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_PostCostValuesForTimesheetData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPostCostValuesForTimesheetData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetCharge) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_SetCharge_Method_Call_Internally(Type[] types)
        {
            var methodSetChargePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodSetCharge, Fixture, methodSetChargePrametersTypes);
        }

        #endregion

        #region Method Call : (SetCharge) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_SetCharge_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetCharge, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetCharge) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_SetCharge_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetCharge, 0);
            const int parametersCount = 9;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPfeFields) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_GetPfeFields_Method_Call_Internally(Type[] types)
        {
            var methodGetPfeFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodGetPfeFields, Fixture, methodGetPfeFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPfeFields) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeFields_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var type = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => _wEIntegrationInstance.GetPfeFields(type);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPfeFields) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var type = CreateType<int>();
            var methodGetPfeFieldsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetPfeFields = { type };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPfeFields, methodGetPfeFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, DataTable>(_wEIntegrationInstanceFixture, out exception1, parametersOfGetPfeFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, DataTable>(_wEIntegrationInstance, MethodGetPfeFields, parametersOfGetPfeFields, methodGetPfeFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPfeFields.ShouldNotBeNull();
            parametersOfGetPfeFields.Length.ShouldBe(1);
            methodGetPfeFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPfeFields) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var type = CreateType<int>();
            var methodGetPfeFieldsPrametersTypes = new Type[] { typeof(int) };
            object[] parametersOfGetPfeFields = { type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEIntegration, DataTable>(_wEIntegrationInstance, MethodGetPfeFields, parametersOfGetPfeFields, methodGetPfeFieldsPrametersTypes);

            // Assert
            parametersOfGetPfeFields.ShouldNotBeNull();
            parametersOfGetPfeFields.Length.ShouldBe(1);
            methodGetPfeFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPfeFields) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPfeFieldsPrametersTypes = new Type[] { typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodGetPfeFields, Fixture, methodGetPfeFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPfeFieldsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPfeFields) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPfeFieldsPrametersTypes = new Type[] { typeof(int) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodGetPfeFields, Fixture, methodGetPfeFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPfeFieldsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPfeFields) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPfeFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPfeFields) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPfeFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPfeCostViews) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_GetPfeCostViews_Method_Call_Internally(Type[] types)
        {
            var methodGetPfeCostViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodGetPfeCostViews, Fixture, methodGetPfeCostViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPfeCostViews) (Return Type : DataTable) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeCostViews_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _wEIntegrationInstance.GetPfeCostViews();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetPfeCostViews) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeCostViews_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetPfeCostViewsPrametersTypes = null;
            object[] parametersOfGetPfeCostViews = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPfeCostViews, methodGetPfeCostViewsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, DataTable>(_wEIntegrationInstanceFixture, out exception1, parametersOfGetPfeCostViews);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, DataTable>(_wEIntegrationInstance, MethodGetPfeCostViews, parametersOfGetPfeCostViews, methodGetPfeCostViewsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPfeCostViews.ShouldBeNull();
            methodGetPfeCostViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPfeCostViews) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeCostViews_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetPfeCostViewsPrametersTypes = null;
            object[] parametersOfGetPfeCostViews = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEIntegration, DataTable>(_wEIntegrationInstance, MethodGetPfeCostViews, parametersOfGetPfeCostViews, methodGetPfeCostViewsPrametersTypes);

            // Assert
            parametersOfGetPfeCostViews.ShouldBeNull();
            methodGetPfeCostViewsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPfeCostViews) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeCostViews_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetPfeCostViewsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodGetPfeCostViews, Fixture, methodGetPfeCostViewsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPfeCostViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPfeCostViews) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeCostViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetPfeCostViewsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodGetPfeCostViews, Fixture, methodGetPfeCostViewsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPfeCostViewsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPfeCostViews) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_GetPfeCostViews_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPfeCostViews, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DisplayProjects) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_DisplayProjects_Method_Call_Internally(Type[] types)
        {
            var methodDisplayProjectsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodDisplayProjects, Fixture, methodDisplayProjectsPrametersTypes);
        }

        #endregion

        #region Method Call : (DisplayProjects) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_DisplayProjects_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _wEIntegrationInstance.DisplayProjects(data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DisplayProjects) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_DisplayProjects_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDisplayProjectsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisplayProjects = { data };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodDisplayProjects, methodDisplayProjectsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, string>(_wEIntegrationInstanceFixture, out exception1, parametersOfDisplayProjects);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, string>(_wEIntegrationInstance, MethodDisplayProjects, parametersOfDisplayProjects, methodDisplayProjectsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfDisplayProjects.ShouldNotBeNull();
            parametersOfDisplayProjects.Length.ShouldBe(1);
            methodDisplayProjectsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DisplayProjects) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_DisplayProjects_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var methodDisplayProjectsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDisplayProjects = { data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEIntegration, string>(_wEIntegrationInstance, MethodDisplayProjects, parametersOfDisplayProjects, methodDisplayProjectsPrametersTypes);

            // Assert
            parametersOfDisplayProjects.ShouldNotBeNull();
            parametersOfDisplayProjects.Length.ShouldBe(1);
            methodDisplayProjectsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisplayProjects) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_DisplayProjects_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodDisplayProjectsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodDisplayProjects, Fixture, methodDisplayProjectsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodDisplayProjectsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (DisplayProjects) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_DisplayProjects_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisplayProjectsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodDisplayProjects, Fixture, methodDisplayProjectsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDisplayProjectsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisplayProjects) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_DisplayProjects_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisplayProjects, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DisplayProjects) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_DisplayProjects_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDisplayProjects, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_convertToSQL_Static_Method_Call_Internally(Type[] types)
        {
            var methodconvertToSQLPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wEIntegrationInstanceFixture, _wEIntegrationInstanceType, MethodconvertToSQL, Fixture, methodconvertToSQLPrametersTypes);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_convertToSQL_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sOLEDBconnect = CreateType<string>();
            var methodconvertToSQLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfconvertToSQL = { sOLEDBconnect };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodconvertToSQL, methodconvertToSQLPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_wEIntegrationInstanceFixture, parametersOfconvertToSQL);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfconvertToSQL.ShouldNotBeNull();
            parametersOfconvertToSQL.Length.ShouldBe(1);
            methodconvertToSQLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_convertToSQL_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sOLEDBconnect = CreateType<string>();
            var methodconvertToSQLPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfconvertToSQL = { sOLEDBconnect };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_wEIntegrationInstanceFixture, _wEIntegrationInstanceType, MethodconvertToSQL, parametersOfconvertToSQL, methodconvertToSQLPrametersTypes);

            // Assert
            parametersOfconvertToSQL.ShouldNotBeNull();
            parametersOfconvertToSQL.Length.ShouldBe(1);
            methodconvertToSQLPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_convertToSQL_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodconvertToSQLPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wEIntegrationInstanceFixture, _wEIntegrationInstanceType, MethodconvertToSQL, Fixture, methodconvertToSQLPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodconvertToSQLPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_convertToSQL_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodconvertToSQLPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_wEIntegrationInstanceFixture, _wEIntegrationInstanceType, MethodconvertToSQL, Fixture, methodconvertToSQLPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodconvertToSQLPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_convertToSQL_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodconvertToSQL, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (convertToSQL) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_convertToSQL_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodconvertToSQL, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportReportingConnection) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WEIntegration_ImportReportingConnection_Method_Call_Internally(Type[] types)
        {
            var methodImportReportingConnectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodImportReportingConnection, Fixture, methodImportReportingConnectionPrametersTypes);
        }

        #endregion

        #region Method Call : (ImportReportingConnection) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ImportReportingConnection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var connection = CreateType<string>();
            var methodImportReportingConnectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfImportReportingConnection = { connection };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodImportReportingConnection, methodImportReportingConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, bool>(_wEIntegrationInstanceFixture, out exception1, parametersOfImportReportingConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, bool>(_wEIntegrationInstance, MethodImportReportingConnection, parametersOfImportReportingConnection, methodImportReportingConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfImportReportingConnection.ShouldNotBeNull();
            parametersOfImportReportingConnection.Length.ShouldBe(1);
            methodImportReportingConnectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ImportReportingConnection) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ImportReportingConnection_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var connection = CreateType<string>();
            var methodImportReportingConnectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfImportReportingConnection = { connection };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodImportReportingConnection, methodImportReportingConnectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WEIntegration, bool>(_wEIntegrationInstanceFixture, out exception1, parametersOfImportReportingConnection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WEIntegration, bool>(_wEIntegrationInstance, MethodImportReportingConnection, parametersOfImportReportingConnection, methodImportReportingConnectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfImportReportingConnection.ShouldNotBeNull();
            parametersOfImportReportingConnection.Length.ShouldBe(1);
            methodImportReportingConnectionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ImportReportingConnection) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ImportReportingConnection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var connection = CreateType<string>();
            var methodImportReportingConnectionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfImportReportingConnection = { connection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WEIntegration, bool>(_wEIntegrationInstance, MethodImportReportingConnection, parametersOfImportReportingConnection, methodImportReportingConnectionPrametersTypes);

            // Assert
            parametersOfImportReportingConnection.ShouldNotBeNull();
            parametersOfImportReportingConnection.Length.ShouldBe(1);
            methodImportReportingConnectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ImportReportingConnection) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ImportReportingConnection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodImportReportingConnectionPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_wEIntegrationInstance, MethodImportReportingConnection, Fixture, methodImportReportingConnectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodImportReportingConnectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ImportReportingConnection) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ImportReportingConnection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodImportReportingConnection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_wEIntegrationInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ImportReportingConnection) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WEIntegration_ImportReportingConnection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodImportReportingConnection, 0);
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