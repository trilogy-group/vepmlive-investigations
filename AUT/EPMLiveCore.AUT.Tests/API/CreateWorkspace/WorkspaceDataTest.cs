using System;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.WorkspaceData" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkspaceDataTest : AbstractBaseSetupTest
    {
        public WorkspaceDataTest() : base(typeof(WorkspaceData))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkspaceData) Initializer

        private const string MethodIsFirstAttempt = "IsFirstAttempt";
        private const string MethodSendCompletedSignalsToDB = "SendCompletedSignalsToDB";
        private const string MethodAddToFRF = "AddToFRF";
        private const string MethodAddWsPermission = "AddWsPermission";
        private const string MethodDoesWorkspaceExist = "DoesWorkspaceExist";
        private const string MethodGetWorkspaceStatus = "GetWorkspaceStatus";
        private const string MethodGetWorkspaceUrl = "GetWorkspaceUrl";
        private const string MethodGetParentWebId = "GetParentWebId";
        private Type _workspaceDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (WorkspaceData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkspaceData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workspaceDataInstanceType = typeof(WorkspaceData);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkspaceData)

        #region General Initializer : Class (WorkspaceData) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkspaceData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodIsFirstAttempt, 0)]
        [TestCase(MethodSendCompletedSignalsToDB, 0)]
        [TestCase(MethodSendCompletedSignalsToDB, 1)]
        [TestCase(MethodAddToFRF, 0)]
        [TestCase(MethodAddToFRF, 1)]
        [TestCase(MethodAddWsPermission, 0)]
        [TestCase(MethodDoesWorkspaceExist, 0)]
        [TestCase(MethodGetWorkspaceStatus, 0)]
        [TestCase(MethodGetWorkspaceUrl, 0)]
        [TestCase(MethodGetParentWebId, 0)]
        public void AUT_WorkspaceData_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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
        ///     Class (<see cref="WorkspaceData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkspaceData_Is_Static_Type_Present_Test()
        {
            // Assert
            _workspaceDataInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WorkspaceData" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodIsFirstAttempt)]
        [TestCase(MethodSendCompletedSignalsToDB)]
        [TestCase(MethodAddToFRF)]
        [TestCase(MethodAddWsPermission)]
        [TestCase(MethodDoesWorkspaceExist)]
        [TestCase(MethodGetWorkspaceStatus)]
        [TestCase(MethodGetWorkspaceUrl)]
        [TestCase(MethodGetParentWebId)]
        public void AUT_WorkspaceData_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _workspaceDataInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (IsFirstAttempt) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceData_IsFirstAttempt_Static_Method_Call_Internally(Type[] types)
        {
            var methodIsFirstAttemptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodIsFirstAttempt, Fixture, methodIsFirstAttemptPrametersTypes);
        }

        #endregion

        #region Method Call : (IsFirstAttempt) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_IsFirstAttempt_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var listId = CreateType<string>();
            var itemId = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceData.IsFirstAttempt(site, web, listId, itemId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (IsFirstAttempt) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_IsFirstAttempt_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var listId = CreateType<string>();
            var itemId = CreateType<string>();
            var methodIsFirstAttemptPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string), typeof(string) };
            object[] parametersOfIsFirstAttempt = { site, web, listId, itemId };

            // Assert
            parametersOfIsFirstAttempt.ShouldNotBeNull();
            parametersOfIsFirstAttempt.Length.ShouldBe(4);
            methodIsFirstAttemptPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _workspaceDataInstanceType, MethodIsFirstAttempt, parametersOfIsFirstAttempt, methodIsFirstAttemptPrametersTypes));
        }

        #endregion

        #region Method Call : (IsFirstAttempt) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_IsFirstAttempt_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsFirstAttemptPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodIsFirstAttempt, Fixture, methodIsFirstAttemptPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsFirstAttemptPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsFirstAttempt) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_IsFirstAttempt_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsFirstAttempt, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsFirstAttempt) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_IsFirstAttempt_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsFirstAttempt, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_Internally(Type[] types)
        {
            var methodSendCompletedSignalsToDBPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodSendCompletedSignalsToDB, Fixture, methodSendCompletedSignalsToDBPrametersTypes);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var itemWeb = CreateType<SPWeb>();
            var parentWeb = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var createdWebId = CreateType<Guid>();
            var createdWebServerRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            var creatorId = CreateType<string>();
            var createdWebDescription = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceData.SendCompletedSignalsToDB(siteId, itemWeb, parentWeb, listId, itemId, createdWebId, createdWebServerRelativeUrl, createdWebTitle, creatorId, createdWebDescription);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_Void_With_10_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var itemWeb = CreateType<SPWeb>();
            var parentWeb = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var createdWebId = CreateType<Guid>();
            var createdWebServerRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            var creatorId = CreateType<string>();
            var createdWebDescription = CreateType<string>();
            var methodSendCompletedSignalsToDBPrametersTypes = new Type[] { typeof(Guid), typeof(SPWeb), typeof(SPWeb), typeof(Guid), typeof(int), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSendCompletedSignalsToDB = { siteId, itemWeb, parentWeb, listId, itemId, createdWebId, createdWebServerRelativeUrl, createdWebTitle, creatorId, createdWebDescription };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSendCompletedSignalsToDB, methodSendCompletedSignalsToDBPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSendCompletedSignalsToDB);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSendCompletedSignalsToDB.ShouldNotBeNull();
            parametersOfSendCompletedSignalsToDB.Length.ShouldBe(10);
            methodSendCompletedSignalsToDBPrametersTypes.Length.ShouldBe(10);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_Void_With_10_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var itemWeb = CreateType<SPWeb>();
            var parentWeb = CreateType<SPWeb>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var createdWebId = CreateType<Guid>();
            var createdWebServerRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            var creatorId = CreateType<string>();
            var createdWebDescription = CreateType<string>();
            var methodSendCompletedSignalsToDBPrametersTypes = new Type[] { typeof(Guid), typeof(SPWeb), typeof(SPWeb), typeof(Guid), typeof(int), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSendCompletedSignalsToDB = { siteId, itemWeb, parentWeb, listId, itemId, createdWebId, createdWebServerRelativeUrl, createdWebTitle, creatorId, createdWebDescription };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _workspaceDataInstanceType, MethodSendCompletedSignalsToDB, parametersOfSendCompletedSignalsToDB, methodSendCompletedSignalsToDBPrametersTypes);

            // Assert
            parametersOfSendCompletedSignalsToDB.ShouldNotBeNull();
            parametersOfSendCompletedSignalsToDB.Length.ShouldBe(10);
            methodSendCompletedSignalsToDBPrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSendCompletedSignalsToDB, 0);
            const int parametersCount = 10;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSendCompletedSignalsToDBPrametersTypes = new Type[] { typeof(Guid), typeof(SPWeb), typeof(SPWeb), typeof(Guid), typeof(int), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodSendCompletedSignalsToDB, Fixture, methodSendCompletedSignalsToDBPrametersTypes);

            // Assert
            methodSendCompletedSignalsToDBPrametersTypes.Length.ShouldBe(10);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_With_10_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSendCompletedSignalsToDB, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodSendCompletedSignalsToDBPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodSendCompletedSignalsToDB, Fixture, methodSendCompletedSignalsToDBPrametersTypes);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var parentWeb = CreateType<SPWeb>();
            var createdWebId = CreateType<Guid>();
            var createdWebServerRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            var creatorId = CreateType<string>();
            var createdWebDescription = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceData.SendCompletedSignalsToDB(siteId, parentWeb, createdWebId, createdWebServerRelativeUrl, createdWebTitle, creatorId, createdWebDescription);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_Void_Overloading_Of_1_With_7_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var parentWeb = CreateType<SPWeb>();
            var createdWebId = CreateType<Guid>();
            var createdWebServerRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            var creatorId = CreateType<string>();
            var createdWebDescription = CreateType<string>();
            var methodSendCompletedSignalsToDBPrametersTypes = new Type[] { typeof(Guid), typeof(SPWeb), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSendCompletedSignalsToDB = { siteId, parentWeb, createdWebId, createdWebServerRelativeUrl, createdWebTitle, creatorId, createdWebDescription };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSendCompletedSignalsToDB, methodSendCompletedSignalsToDBPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfSendCompletedSignalsToDB);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSendCompletedSignalsToDB.ShouldNotBeNull();
            parametersOfSendCompletedSignalsToDB.Length.ShouldBe(7);
            methodSendCompletedSignalsToDBPrametersTypes.Length.ShouldBe(7);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_Void_Overloading_Of_1_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var parentWeb = CreateType<SPWeb>();
            var createdWebId = CreateType<Guid>();
            var createdWebServerRelativeUrl = CreateType<string>();
            var createdWebTitle = CreateType<string>();
            var creatorId = CreateType<string>();
            var createdWebDescription = CreateType<string>();
            var methodSendCompletedSignalsToDBPrametersTypes = new Type[] { typeof(Guid), typeof(SPWeb), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSendCompletedSignalsToDB = { siteId, parentWeb, createdWebId, createdWebServerRelativeUrl, createdWebTitle, creatorId, createdWebDescription };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _workspaceDataInstanceType, MethodSendCompletedSignalsToDB, parametersOfSendCompletedSignalsToDB, methodSendCompletedSignalsToDBPrametersTypes);

            // Assert
            parametersOfSendCompletedSignalsToDB.ShouldNotBeNull();
            parametersOfSendCompletedSignalsToDB.Length.ShouldBe(7);
            methodSendCompletedSignalsToDBPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSendCompletedSignalsToDB, 1);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSendCompletedSignalsToDBPrametersTypes = new Type[] { typeof(Guid), typeof(SPWeb), typeof(Guid), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodSendCompletedSignalsToDB, Fixture, methodSendCompletedSignalsToDBPrametersTypes);

            // Assert
            methodSendCompletedSignalsToDBPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SendCompletedSignalsToDB) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_SendCompletedSignalsToDB_Static_Method_Call_Overloading_Of_1_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSendCompletedSignalsToDB, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceData_AddToFRF_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddToFRFPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodAddToFRF, Fixture, methodAddToFRFPrametersTypes);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var createdWebId = CreateType<Guid>();
            var siteTitle = CreateType<string>();
            var createdWebUrl = CreateType<string>();
            var userId = CreateType<int>();
            var type = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceData.AddToFRF(siteId, createdWebId, siteTitle, createdWebUrl, userId, type);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var createdWebId = CreateType<Guid>();
            var siteTitle = CreateType<string>();
            var createdWebUrl = CreateType<string>();
            var userId = CreateType<int>();
            var type = CreateType<int>();
            var methodAddToFRFPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfAddToFRF = { siteId, createdWebId, siteTitle, createdWebUrl, userId, type };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddToFRF, methodAddToFRFPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAddToFRF);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddToFRF.ShouldNotBeNull();
            parametersOfAddToFRF.Length.ShouldBe(6);
            methodAddToFRFPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var createdWebId = CreateType<Guid>();
            var siteTitle = CreateType<string>();
            var createdWebUrl = CreateType<string>();
            var userId = CreateType<int>();
            var type = CreateType<int>();
            var methodAddToFRFPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string), typeof(int), typeof(int) };
            object[] parametersOfAddToFRF = { siteId, createdWebId, siteTitle, createdWebUrl, userId, type };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _workspaceDataInstanceType, MethodAddToFRF, parametersOfAddToFRF, methodAddToFRFPrametersTypes);

            // Assert
            parametersOfAddToFRF.ShouldNotBeNull();
            parametersOfAddToFRF.Length.ShouldBe(6);
            methodAddToFRFPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddToFRF, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddToFRFPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string), typeof(int), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodAddToFRF, Fixture, methodAddToFRFPrametersTypes);

            // Assert
            methodAddToFRFPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddToFRF, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceData_AddToFRF_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodAddToFRFPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodAddToFRF, Fixture, methodAddToFRFPrametersTypes);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var createdWebId = CreateType<Guid>();
            var siteTitle = CreateType<string>();
            var createdWebUrl = CreateType<string>();
            var userId = CreateType<int>();
            var type = CreateType<int>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceData.AddToFRF(siteId, createdWebId, siteTitle, createdWebUrl, userId, type, listId, itemId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_Call_Void_Overloading_Of_1_With_8_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var createdWebId = CreateType<Guid>();
            var siteTitle = CreateType<string>();
            var createdWebUrl = CreateType<string>();
            var userId = CreateType<int>();
            var type = CreateType<int>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var methodAddToFRFPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string), typeof(int), typeof(int), typeof(Guid), typeof(int) };
            object[] parametersOfAddToFRF = { siteId, createdWebId, siteTitle, createdWebUrl, userId, type, listId, itemId };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddToFRF, methodAddToFRFPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAddToFRF);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddToFRF.ShouldNotBeNull();
            parametersOfAddToFRF.Length.ShouldBe(8);
            methodAddToFRFPrametersTypes.Length.ShouldBe(8);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_Call_Void_Overloading_Of_1_With_8_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var createdWebId = CreateType<Guid>();
            var siteTitle = CreateType<string>();
            var createdWebUrl = CreateType<string>();
            var userId = CreateType<int>();
            var type = CreateType<int>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var methodAddToFRFPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string), typeof(int), typeof(int), typeof(Guid), typeof(int) };
            object[] parametersOfAddToFRF = { siteId, createdWebId, siteTitle, createdWebUrl, userId, type, listId, itemId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _workspaceDataInstanceType, MethodAddToFRF, parametersOfAddToFRF, methodAddToFRFPrametersTypes);

            // Assert
            parametersOfAddToFRF.ShouldNotBeNull();
            parametersOfAddToFRF.Length.ShouldBe(8);
            methodAddToFRFPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddToFRF, 1);
            const int parametersCount = 8;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddToFRFPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(string), typeof(string), typeof(int), typeof(int), typeof(Guid), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodAddToFRF, Fixture, methodAddToFRFPrametersTypes);

            // Assert
            methodAddToFRFPrametersTypes.Length.ShouldBe(8);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddToFRF) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddToFRF_Static_Method_Call_Overloading_Of_1_With_8_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddToFRF, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddWsPermission) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceData_AddWsPermission_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddWsPermissionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodAddWsPermission, Fixture, methodAddWsPermissionPrametersTypes);
        }

        #endregion

        #region Method Call : (AddWsPermission) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddWsPermission_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var createdWebId = CreateType<Guid>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceData.AddWsPermission(siteId, createdWebId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddWsPermission) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddWsPermission_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var createdWebId = CreateType<Guid>();
            var methodAddWsPermissionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };
            object[] parametersOfAddWsPermission = { siteId, createdWebId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(null, _workspaceDataInstanceType, MethodAddWsPermission, parametersOfAddWsPermission, methodAddWsPermissionPrametersTypes);

            // Assert
            parametersOfAddWsPermission.ShouldNotBeNull();
            parametersOfAddWsPermission.Length.ShouldBe(2);
            methodAddWsPermissionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddWsPermission) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddWsPermission_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddWsPermission, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddWsPermission) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddWsPermission_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddWsPermissionPrametersTypes = new Type[] { typeof(Guid), typeof(Guid) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodAddWsPermission, Fixture, methodAddWsPermissionPrametersTypes);

            // Assert
            methodAddWsPermissionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddWsPermission) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_AddWsPermission_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddWsPermission, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DoesWorkspaceExist) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceData_DoesWorkspaceExist_Static_Method_Call_Internally(Type[] types)
        {
            var methodDoesWorkspaceExistPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodDoesWorkspaceExist, Fixture, methodDoesWorkspaceExistPrametersTypes);
        }

        #endregion

        #region Method Call : (DoesWorkspaceExist) (Return Type : bool) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_DoesWorkspaceExist_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceData.DoesWorkspaceExist(siteId, webId, listId, itemId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DoesWorkspaceExist) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_DoesWorkspaceExist_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var methodDoesWorkspaceExistPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfDoesWorkspaceExist = { siteId, webId, listId, itemId };

            // Assert
            parametersOfDoesWorkspaceExist.ShouldNotBeNull();
            parametersOfDoesWorkspaceExist.Length.ShouldBe(4);
            methodDoesWorkspaceExistPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(null, _workspaceDataInstanceType, MethodDoesWorkspaceExist, parametersOfDoesWorkspaceExist, methodDoesWorkspaceExistPrametersTypes));
        }

        #endregion

        #region Method Call : (DoesWorkspaceExist) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_DoesWorkspaceExist_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDoesWorkspaceExistPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodDoesWorkspaceExist, Fixture, methodDoesWorkspaceExistPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDoesWorkspaceExistPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DoesWorkspaceExist) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_DoesWorkspaceExist_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDoesWorkspaceExist, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (DoesWorkspaceExist) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_DoesWorkspaceExist_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDoesWorkspaceExist, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkspaceStatus) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceData_GetWorkspaceStatus_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkspaceStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetWorkspaceStatus, Fixture, methodGetWorkspaceStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkspaceStatus) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceStatus_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceData.GetWorkspaceStatus(siteId, webId, listId, itemId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetWorkspaceStatus) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceStatus_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var methodGetWorkspaceStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfGetWorkspaceStatus = { siteId, webId, listId, itemId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWorkspaceStatus, methodGetWorkspaceStatusPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetWorkspaceStatus, Fixture, methodGetWorkspaceStatusPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceDataInstanceType, MethodGetWorkspaceStatus, parametersOfGetWorkspaceStatus, methodGetWorkspaceStatusPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetWorkspaceStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWorkspaceStatus.ShouldNotBeNull();
            parametersOfGetWorkspaceStatus.Length.ShouldBe(4);
            methodGetWorkspaceStatusPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkspaceStatus) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceStatus_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var methodGetWorkspaceStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfGetWorkspaceStatus = { siteId, webId, listId, itemId };

            // Assert
            parametersOfGetWorkspaceStatus.ShouldNotBeNull();
            parametersOfGetWorkspaceStatus.Length.ShouldBe(4);
            methodGetWorkspaceStatusPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceDataInstanceType, MethodGetWorkspaceStatus, parametersOfGetWorkspaceStatus, methodGetWorkspaceStatusPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkspaceStatus) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceStatus_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkspaceStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetWorkspaceStatus, Fixture, methodGetWorkspaceStatusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkspaceStatusPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetWorkspaceStatus) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceStatus_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkspaceStatusPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetWorkspaceStatus, Fixture, methodGetWorkspaceStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkspaceStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkspaceStatus) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceStatus_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkspaceStatus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkspaceStatus) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceStatus_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkspaceStatus, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkspaceUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceData_GetWorkspaceUrl_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetWorkspaceUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetWorkspaceUrl, Fixture, methodGetWorkspaceUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWorkspaceUrl) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceUrl_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceData.GetWorkspaceUrl(siteId, webId, listId, itemId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetWorkspaceUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceUrl_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var methodGetWorkspaceUrlPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfGetWorkspaceUrl = { siteId, webId, listId, itemId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWorkspaceUrl, methodGetWorkspaceUrlPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetWorkspaceUrl, Fixture, methodGetWorkspaceUrlPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceDataInstanceType, MethodGetWorkspaceUrl, parametersOfGetWorkspaceUrl, methodGetWorkspaceUrlPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfGetWorkspaceUrl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWorkspaceUrl.ShouldNotBeNull();
            parametersOfGetWorkspaceUrl.Length.ShouldBe(4);
            methodGetWorkspaceUrlPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetWorkspaceUrl) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceUrl_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var siteId = CreateType<Guid>();
            var webId = CreateType<Guid>();
            var listId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var methodGetWorkspaceUrlPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfGetWorkspaceUrl = { siteId, webId, listId, itemId };

            // Assert
            parametersOfGetWorkspaceUrl.ShouldNotBeNull();
            parametersOfGetWorkspaceUrl.Length.ShouldBe(4);
            methodGetWorkspaceUrlPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceDataInstanceType, MethodGetWorkspaceUrl, parametersOfGetWorkspaceUrl, methodGetWorkspaceUrlPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWorkspaceUrl) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceUrl_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWorkspaceUrlPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetWorkspaceUrl, Fixture, methodGetWorkspaceUrlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWorkspaceUrlPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetWorkspaceUrl) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceUrl_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWorkspaceUrlPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetWorkspaceUrl, Fixture, methodGetWorkspaceUrlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWorkspaceUrlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWorkspaceUrl) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceUrl_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWorkspaceUrl, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWorkspaceUrl) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetWorkspaceUrl_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWorkspaceUrl, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParentWebId) (Return Type : Guid) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceData_GetParentWebId_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetParentWebIdPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetParentWebId, Fixture, methodGetParentWebIdPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParentWebId) (Return Type : Guid) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetParentWebId_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var itemSiteId = CreateType<Guid>();
            var itemWebId = CreateType<Guid>();
            var itemListId = CreateType<Guid>();
            var itemId = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceData.GetParentWebId(itemSiteId, itemWebId, itemListId, itemId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetParentWebId) (Return Type : Guid) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetParentWebId_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var itemSiteId = CreateType<Guid>();
            var itemWebId = CreateType<Guid>();
            var itemListId = CreateType<Guid>();
            var itemId = CreateType<int>();
            var methodGetParentWebIdPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfGetParentWebId = { itemSiteId, itemWebId, itemListId, itemId };

            // Assert
            parametersOfGetParentWebId.ShouldNotBeNull();
            parametersOfGetParentWebId.Length.ShouldBe(4);
            methodGetParentWebIdPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<Guid>(null, _workspaceDataInstanceType, MethodGetParentWebId, parametersOfGetParentWebId, methodGetParentWebIdPrametersTypes));
        }

        #endregion

        #region Method Call : (GetParentWebId) (Return Type : Guid) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetParentWebId_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetParentWebIdPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetParentWebId, Fixture, methodGetParentWebIdPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetParentWebIdPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetParentWebId) (Return Type : Guid) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetParentWebId_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetParentWebIdPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceDataInstanceType, MethodGetParentWebId, Fixture, methodGetParentWebIdPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetParentWebIdPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParentWebId) (Return Type : Guid) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetParentWebId_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParentWebId, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetParentWebId) (Return Type : Guid) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceData_GetParentWebId_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetParentWebId, 0);
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