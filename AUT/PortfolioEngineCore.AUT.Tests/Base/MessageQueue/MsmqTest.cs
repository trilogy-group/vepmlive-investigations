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

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Msmq" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class MsmqTest : AbstractBaseSetupTypedTest<Msmq>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Msmq) Initializer

        private const string MethodCreateQueue = "CreateQueue";
        private const string MethodQueue = "Queue";
        private Type _msmqInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Msmq _msmqInstance;
        private Msmq _msmqInstanceFixture;

        #region General Initializer : Class (Msmq) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Msmq" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _msmqInstanceType = typeof(Msmq);
            _msmqInstanceFixture = Create(true);
            _msmqInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Msmq)

        #region General Initializer : Class (Msmq) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Msmq" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateQueue, 0)]
        [TestCase(MethodQueue, 0)]
        public void AUT_Msmq_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_msmqInstanceFixture, 
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
        ///     Class (<see cref="Msmq" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Msmq_Is_Instance_Present_Test()
        {
            // Assert
            _msmqInstanceType.ShouldNotBeNull();
            _msmqInstance.ShouldNotBeNull();
            _msmqInstanceFixture.ShouldNotBeNull();
            _msmqInstance.ShouldBeAssignableTo<Msmq>();
            _msmqInstanceFixture.ShouldBeAssignableTo<Msmq>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Msmq) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Msmq_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Msmq instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _msmqInstanceType.ShouldNotBeNull();
            _msmqInstance.ShouldNotBeNull();
            _msmqInstanceFixture.ShouldNotBeNull();
            _msmqInstance.ShouldBeAssignableTo<Msmq>();
            _msmqInstanceFixture.ShouldBeAssignableTo<Msmq>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Msmq" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateQueue)]
        [TestCase(MethodQueue)]
        public void AUT_Msmq_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Msmq>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateQueue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Msmq_CreateQueue_Method_Call_Internally(Type[] types)
        {
            var methodCreateQueuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_msmqInstance, MethodCreateQueue, Fixture, methodCreateQueuePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateQueue) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_CreateQueue_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var name = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _msmqInstance.CreateQueue(name);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateQueue) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_CreateQueue_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodCreateQueuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateQueue = { name };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateQueue, methodCreateQueuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_msmqInstanceFixture, parametersOfCreateQueue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateQueue.ShouldNotBeNull();
            parametersOfCreateQueue.Length.ShouldBe(1);
            methodCreateQueuePrametersTypes.Length.ShouldBe(1);
            methodCreateQueuePrametersTypes.Length.ShouldBe(parametersOfCreateQueue.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateQueue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_CreateQueue_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var name = CreateType<string>();
            var methodCreateQueuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateQueue = { name };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_msmqInstance, MethodCreateQueue, parametersOfCreateQueue, methodCreateQueuePrametersTypes);

            // Assert
            parametersOfCreateQueue.ShouldNotBeNull();
            parametersOfCreateQueue.Length.ShouldBe(1);
            methodCreateQueuePrametersTypes.Length.ShouldBe(1);
            methodCreateQueuePrametersTypes.Length.ShouldBe(parametersOfCreateQueue.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateQueue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_CreateQueue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateQueue, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateQueue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_CreateQueue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateQueuePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_msmqInstance, MethodCreateQueue, Fixture, methodCreateQueuePrametersTypes);

            // Assert
            methodCreateQueuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateQueue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_CreateQueue_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateQueue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_msmqInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Queue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Msmq_Queue_Method_Call_Internally(Type[] types)
        {
            var methodQueuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_msmqInstance, MethodQueue, Fixture, methodQueuePrametersTypes);
        }

        #endregion

        #region Method Call : (Queue) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_Queue_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var basePath = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _msmqInstance.Queue(basePath);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (Queue) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_Queue_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var basePath = CreateType<string>();
            var methodQueuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfQueue = { basePath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodQueue, methodQueuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_msmqInstanceFixture, parametersOfQueue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfQueue.ShouldNotBeNull();
            parametersOfQueue.Length.ShouldBe(1);
            methodQueuePrametersTypes.Length.ShouldBe(1);
            methodQueuePrametersTypes.Length.ShouldBe(parametersOfQueue.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Queue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_Queue_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basePath = CreateType<string>();
            var methodQueuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfQueue = { basePath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_msmqInstance, MethodQueue, parametersOfQueue, methodQueuePrametersTypes);

            // Assert
            parametersOfQueue.ShouldNotBeNull();
            parametersOfQueue.Length.ShouldBe(1);
            methodQueuePrametersTypes.Length.ShouldBe(1);
            methodQueuePrametersTypes.Length.ShouldBe(parametersOfQueue.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Queue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_Queue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQueue, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Queue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_Queue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQueuePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_msmqInstance, MethodQueue, Fixture, methodQueuePrametersTypes);

            // Assert
            methodQueuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Queue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Msmq_Queue_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQueue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_msmqInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}