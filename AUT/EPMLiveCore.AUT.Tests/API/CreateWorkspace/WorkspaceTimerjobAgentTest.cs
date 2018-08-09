using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.WorkspaceTimerjobAgent" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkspaceTimerjobAgentTest : AbstractBaseSetupTest
    {
        public WorkspaceTimerjobAgentTest() : base(typeof(WorkspaceTimerjobAgent))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkspaceTimerjobAgent) Initializer

        private const string MethodAddCreateWorkspaceJob = "AddCreateWorkspaceJob";
        private const string MethodAddCreateWorkspaceJobAndWait = "AddCreateWorkspaceJobAndWait";
        private const string MethodQueueWorkspaceJobOnHoldForSecurity = "QueueWorkspaceJobOnHoldForSecurity";
        private const string MethodQueueCreateWorkspace = "QueueCreateWorkspace";
        private const string MethodAddAndQueueCreateWorkspaceJob = "AddAndQueueCreateWorkspaceJob";
        private const string FieldSecKey = "SecKey";
        private const string FieldCompleted = "Completed";
        private Type _workspaceTimerjobAgentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (WorkspaceTimerjobAgent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkspaceTimerjobAgent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workspaceTimerjobAgentInstanceType = typeof(WorkspaceTimerjobAgent);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkspaceTimerjobAgent)

        #region General Initializer : Class (WorkspaceTimerjobAgent) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkspaceTimerjobAgent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddCreateWorkspaceJob, 0)]
        [TestCase(MethodQueueWorkspaceJobOnHoldForSecurity, 0)]
        [TestCase(MethodQueueWorkspaceJobOnHoldForSecurity, 1)]
        [TestCase(MethodQueueCreateWorkspace, 0)]
        [TestCase(MethodQueueCreateWorkspace, 1)]
        [TestCase(MethodAddAndQueueCreateWorkspaceJob, 0)]
        public void AUT_WorkspaceTimerjobAgent_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
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

        #region General Initializer : Class (WorkspaceTimerjobAgent) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkspaceTimerjobAgent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldSecKey)]
        [TestCase(FieldCompleted)]
        public void AUT_WorkspaceTimerjobAgent_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(null, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="WorkspaceTimerjobAgent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WorkspaceTimerjobAgent_Is_Static_Type_Present_Test()
        {
            // Assert
            _workspaceTimerjobAgentInstanceType.ShouldNotBeNull();
        }

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WorkspaceTimerjobAgent" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddCreateWorkspaceJob)]
        [TestCase(MethodQueueWorkspaceJobOnHoldForSecurity)]
        [TestCase(MethodQueueCreateWorkspace)]
        [TestCase(MethodAddAndQueueCreateWorkspaceJob)]
        public void AUT_WorkspaceTimerjobAgent_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(null,
                                                                              _workspaceTimerjobAgentInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (AddCreateWorkspaceJob) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceTimerjobAgent_AddCreateWorkspaceJob_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddCreateWorkspaceJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodAddCreateWorkspaceJob, Fixture, methodAddCreateWorkspaceJobPrametersTypes);
        }

        #endregion

        #region Method Call : (AddCreateWorkspaceJob) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddCreateWorkspaceJob_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceTimerjobAgent.AddCreateWorkspaceJob(xmlData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddCreateWorkspaceJob) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddCreateWorkspaceJob_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            var methodAddCreateWorkspaceJobPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddCreateWorkspaceJob = { xmlData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddCreateWorkspaceJob, methodAddCreateWorkspaceJobPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodAddCreateWorkspaceJob, Fixture, methodAddCreateWorkspaceJobPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodAddCreateWorkspaceJob, parametersOfAddCreateWorkspaceJob, methodAddCreateWorkspaceJobPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAddCreateWorkspaceJob);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddCreateWorkspaceJob.ShouldNotBeNull();
            parametersOfAddCreateWorkspaceJob.Length.ShouldBe(1);
            methodAddCreateWorkspaceJobPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddCreateWorkspaceJob) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddCreateWorkspaceJob_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            var methodAddCreateWorkspaceJobPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddCreateWorkspaceJob = { xmlData };

            // Assert
            parametersOfAddCreateWorkspaceJob.ShouldNotBeNull();
            parametersOfAddCreateWorkspaceJob.Length.ShouldBe(1);
            methodAddCreateWorkspaceJobPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodAddCreateWorkspaceJob, parametersOfAddCreateWorkspaceJob, methodAddCreateWorkspaceJobPrametersTypes));
        }

        #endregion

        #region Method Call : (AddCreateWorkspaceJob) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddCreateWorkspaceJob_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddCreateWorkspaceJobPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodAddCreateWorkspaceJob, Fixture, methodAddCreateWorkspaceJobPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddCreateWorkspaceJobPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddCreateWorkspaceJob) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddCreateWorkspaceJob_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddCreateWorkspaceJobPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodAddCreateWorkspaceJob, Fixture, methodAddCreateWorkspaceJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddCreateWorkspaceJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddCreateWorkspaceJob) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddCreateWorkspaceJob_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddCreateWorkspaceJob, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddCreateWorkspaceJob) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddCreateWorkspaceJob_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddCreateWorkspaceJob, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Internally(Type[] types)
        {
            var methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, Fixture, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceTimerjobAgent.QueueWorkspaceJobOnHoldForSecurity(xmlData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            var methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfQueueWorkspaceJobOnHoldForSecurity = { xmlData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodQueueWorkspaceJobOnHoldForSecurity, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, Fixture, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, parametersOfQueueWorkspaceJobOnHoldForSecurity, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfQueueWorkspaceJobOnHoldForSecurity);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfQueueWorkspaceJobOnHoldForSecurity.ShouldNotBeNull();
            parametersOfQueueWorkspaceJobOnHoldForSecurity.Length.ShouldBe(1);
            methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            var methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfQueueWorkspaceJobOnHoldForSecurity = { xmlData };

            // Assert
            parametersOfQueueWorkspaceJobOnHoldForSecurity.ShouldNotBeNull();
            parametersOfQueueWorkspaceJobOnHoldForSecurity.Length.ShouldBe(1);
            methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, parametersOfQueueWorkspaceJobOnHoldForSecurity, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes));
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, Fixture, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, Fixture, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQueueWorkspaceJobOnHoldForSecurity, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQueueWorkspaceJobOnHoldForSecurity, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, Fixture, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sid = CreateType<Guid>();
            var wid = CreateType<Guid>();
            var listguid = CreateType<Guid>();
            var itemid = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceTimerjobAgent.QueueWorkspaceJobOnHoldForSecurity(sid, wid, listguid, itemid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sid = CreateType<Guid>();
            var wid = CreateType<Guid>();
            var listguid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfQueueWorkspaceJobOnHoldForSecurity = { sid, wid, listguid, itemid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodQueueWorkspaceJobOnHoldForSecurity, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, Fixture, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, parametersOfQueueWorkspaceJobOnHoldForSecurity, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfQueueWorkspaceJobOnHoldForSecurity);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfQueueWorkspaceJobOnHoldForSecurity.ShouldNotBeNull();
            parametersOfQueueWorkspaceJobOnHoldForSecurity.Length.ShouldBe(4);
            methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sid = CreateType<Guid>();
            var wid = CreateType<Guid>();
            var listguid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfQueueWorkspaceJobOnHoldForSecurity = { sid, wid, listguid, itemid };

            // Assert
            parametersOfQueueWorkspaceJobOnHoldForSecurity.ShouldNotBeNull();
            parametersOfQueueWorkspaceJobOnHoldForSecurity.Length.ShouldBe(4);
            methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, parametersOfQueueWorkspaceJobOnHoldForSecurity, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes));
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, Fixture, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueWorkspaceJobOnHoldForSecurity, Fixture, methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodQueueWorkspaceJobOnHoldForSecurityPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQueueWorkspaceJobOnHoldForSecurity, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (QueueWorkspaceJobOnHoldForSecurity) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueWorkspaceJobOnHoldForSecurity_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQueueWorkspaceJobOnHoldForSecurity, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Internally(Type[] types)
        {
            var methodQueueCreateWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, Fixture, methodQueueCreateWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceTimerjobAgent.QueueCreateWorkspace(xmlData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            var methodQueueCreateWorkspacePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfQueueCreateWorkspace = { xmlData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodQueueCreateWorkspace, methodQueueCreateWorkspacePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, Fixture, methodQueueCreateWorkspacePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, parametersOfQueueCreateWorkspace, methodQueueCreateWorkspacePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfQueueCreateWorkspace);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfQueueCreateWorkspace.ShouldNotBeNull();
            parametersOfQueueCreateWorkspace.Length.ShouldBe(1);
            methodQueueCreateWorkspacePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            var methodQueueCreateWorkspacePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfQueueCreateWorkspace = { xmlData };

            // Assert
            parametersOfQueueCreateWorkspace.ShouldNotBeNull();
            parametersOfQueueCreateWorkspace.Length.ShouldBe(1);
            methodQueueCreateWorkspacePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, parametersOfQueueCreateWorkspace, methodQueueCreateWorkspacePrametersTypes));
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodQueueCreateWorkspacePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, Fixture, methodQueueCreateWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodQueueCreateWorkspacePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQueueCreateWorkspacePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, Fixture, methodQueueCreateWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodQueueCreateWorkspacePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQueueCreateWorkspace, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQueueCreateWorkspace, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodQueueCreateWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, Fixture, methodQueueCreateWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var sid = CreateType<Guid>();
            var wid = CreateType<Guid>();
            var listguid = CreateType<Guid>();
            var itemid = CreateType<int>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceTimerjobAgent.QueueCreateWorkspace(sid, wid, listguid, itemid);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sid = CreateType<Guid>();
            var wid = CreateType<Guid>();
            var listguid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodQueueCreateWorkspacePrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfQueueCreateWorkspace = { sid, wid, listguid, itemid };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodQueueCreateWorkspace, methodQueueCreateWorkspacePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, Fixture, methodQueueCreateWorkspacePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, parametersOfQueueCreateWorkspace, methodQueueCreateWorkspacePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfQueueCreateWorkspace);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfQueueCreateWorkspace.ShouldNotBeNull();
            parametersOfQueueCreateWorkspace.Length.ShouldBe(4);
            methodQueueCreateWorkspacePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sid = CreateType<Guid>();
            var wid = CreateType<Guid>();
            var listguid = CreateType<Guid>();
            var itemid = CreateType<int>();
            var methodQueueCreateWorkspacePrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            object[] parametersOfQueueCreateWorkspace = { sid, wid, listguid, itemid };

            // Assert
            parametersOfQueueCreateWorkspace.ShouldNotBeNull();
            parametersOfQueueCreateWorkspace.Length.ShouldBe(4);
            methodQueueCreateWorkspacePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, parametersOfQueueCreateWorkspace, methodQueueCreateWorkspacePrametersTypes));
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodQueueCreateWorkspacePrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, Fixture, methodQueueCreateWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodQueueCreateWorkspacePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQueueCreateWorkspacePrametersTypes = new Type[] { typeof(Guid), typeof(Guid), typeof(Guid), typeof(int) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodQueueCreateWorkspace, Fixture, methodQueueCreateWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodQueueCreateWorkspacePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQueueCreateWorkspace, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (QueueCreateWorkspace) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_QueueCreateWorkspace_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQueueCreateWorkspace, 1);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddAndQueueCreateWorkspaceJob) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkspaceTimerjobAgent_AddAndQueueCreateWorkspaceJob_Static_Method_Call_Internally(Type[] types)
        {
            var methodAddAndQueueCreateWorkspaceJobPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodAddAndQueueCreateWorkspaceJob, Fixture, methodAddAndQueueCreateWorkspaceJobPrametersTypes);
        }

        #endregion

        #region Method Call : (AddAndQueueCreateWorkspaceJob) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddAndQueueCreateWorkspaceJob_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WorkspaceTimerjobAgent.AddAndQueueCreateWorkspaceJob(xmlData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (AddAndQueueCreateWorkspaceJob) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddAndQueueCreateWorkspaceJob_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            var methodAddAndQueueCreateWorkspaceJobPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddAndQueueCreateWorkspaceJob = { xmlData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddAndQueueCreateWorkspaceJob, methodAddAndQueueCreateWorkspaceJobPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodAddAndQueueCreateWorkspaceJob, Fixture, methodAddAndQueueCreateWorkspaceJobPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodAddAndQueueCreateWorkspaceJob, parametersOfAddAndQueueCreateWorkspaceJob, methodAddAndQueueCreateWorkspaceJobPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(null, parametersOfAddAndQueueCreateWorkspaceJob);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfAddAndQueueCreateWorkspaceJob.ShouldNotBeNull();
            parametersOfAddAndQueueCreateWorkspaceJob.Length.ShouldBe(1);
            methodAddAndQueueCreateWorkspaceJobPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddAndQueueCreateWorkspaceJob) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddAndQueueCreateWorkspaceJob_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xmlData = CreateType<string>();
            var methodAddAndQueueCreateWorkspaceJobPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddAndQueueCreateWorkspaceJob = { xmlData };

            // Assert
            parametersOfAddAndQueueCreateWorkspaceJob.ShouldNotBeNull();
            parametersOfAddAndQueueCreateWorkspaceJob.Length.ShouldBe(1);
            methodAddAndQueueCreateWorkspaceJobPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(null, _workspaceTimerjobAgentInstanceType, MethodAddAndQueueCreateWorkspaceJob, parametersOfAddAndQueueCreateWorkspaceJob, methodAddAndQueueCreateWorkspaceJobPrametersTypes));
        }

        #endregion

        #region Method Call : (AddAndQueueCreateWorkspaceJob) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddAndQueueCreateWorkspaceJob_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodAddAndQueueCreateWorkspaceJobPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodAddAndQueueCreateWorkspaceJob, Fixture, methodAddAndQueueCreateWorkspaceJobPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodAddAndQueueCreateWorkspaceJobPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddAndQueueCreateWorkspaceJob) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddAndQueueCreateWorkspaceJob_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddAndQueueCreateWorkspaceJobPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(null, _workspaceTimerjobAgentInstanceType, MethodAddAndQueueCreateWorkspaceJob, Fixture, methodAddAndQueueCreateWorkspaceJobPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddAndQueueCreateWorkspaceJobPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddAndQueueCreateWorkspaceJob) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddAndQueueCreateWorkspaceJob_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddAndQueueCreateWorkspaceJob, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(null, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddAndQueueCreateWorkspaceJob) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WorkspaceTimerjobAgent_AddAndQueueCreateWorkspaceJob_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddAndQueueCreateWorkspaceJob, 0);
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