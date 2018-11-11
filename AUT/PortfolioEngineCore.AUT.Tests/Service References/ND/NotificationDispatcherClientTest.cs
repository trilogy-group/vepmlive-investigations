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

namespace PortfolioEngineCore.ND
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.ND.NotificationDispatcherClient" />)
    ///     and namespace <see cref="PortfolioEngineCore.ND"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class NotificationDispatcherClientTest : AbstractBaseSetupTypedTest<NotificationDispatcherClient>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (NotificationDispatcherClient) Initializer

        private const string MethodQueueNotification = "QueueNotification";
        private const string MethodQueueNotificationAsync = "QueueNotificationAsync";
        private Type _notificationDispatcherClientInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private NotificationDispatcherClient _notificationDispatcherClientInstance;
        private NotificationDispatcherClient _notificationDispatcherClientInstanceFixture;

        #region General Initializer : Class (NotificationDispatcherClient) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NotificationDispatcherClient" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _notificationDispatcherClientInstanceType = typeof(NotificationDispatcherClient);
            _notificationDispatcherClientInstanceFixture = Create(true);
            _notificationDispatcherClientInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (NotificationDispatcherClient)

        #region General Initializer : Class (NotificationDispatcherClient) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="NotificationDispatcherClient" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodQueueNotification, 0)]
        public void AUT_NotificationDispatcherClient_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_notificationDispatcherClientInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NotificationDispatcherClient) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="NotificationDispatcherClient" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AUT_NotificationDispatcherClient_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<NotificationDispatcherClient>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<NotificationDispatcherClient>(Fixture);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfNotificationDispatcherClient = {  };
            Type [] methodNotificationDispatcherClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_notificationDispatcherClientInstanceType, methodNotificationDispatcherClientPrametersTypes, parametersOfNotificationDispatcherClient);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodNotificationDispatcherClientPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_notificationDispatcherClientInstanceType, Fixture, methodNotificationDispatcherClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = CreateType<string>();
            object[] parametersOfNotificationDispatcherClient = { endpointConfigurationName };
            var methodNotificationDispatcherClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_notificationDispatcherClientInstanceType, methodNotificationDispatcherClientPrametersTypes, parametersOfNotificationDispatcherClient);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodNotificationDispatcherClientPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_notificationDispatcherClientInstanceType, Fixture, methodNotificationDispatcherClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors with parameter (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_Constructors_Overloading_Of_2_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = CreateType<string>();
            var remoteAddress = CreateType<string>();
            object[] parametersOfNotificationDispatcherClient = { endpointConfigurationName, remoteAddress };
            var methodNotificationDispatcherClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_notificationDispatcherClientInstanceType, methodNotificationDispatcherClientPrametersTypes, parametersOfNotificationDispatcherClient);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors with dynamic parameters (Overloading_Of_2_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_Constructors_Overloading_Of_2_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodNotificationDispatcherClientPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_notificationDispatcherClientInstanceType, Fixture, methodNotificationDispatcherClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors with parameter (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_Constructors_Overloading_Of_3_Explore_Verify_Test()
        {
            // Arrange
            var endpointConfigurationName = CreateType<string>();
            var remoteAddress = CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfNotificationDispatcherClient = { endpointConfigurationName, remoteAddress };
            var methodNotificationDispatcherClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_notificationDispatcherClientInstanceType, methodNotificationDispatcherClientPrametersTypes, parametersOfNotificationDispatcherClient);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors with dynamic parameters (Overloading_Of_3_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_Constructors_Overloading_Of_3_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodNotificationDispatcherClientPrametersTypes = new Type[] { typeof(string), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_notificationDispatcherClientInstanceType, Fixture, methodNotificationDispatcherClientPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors with parameter (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_Constructors_Overloading_Of_4_Explore_Verify_Test()
        {
            // Arrange
            var binding = CreateType<System.ServiceModel.Channels.Binding>();
            var remoteAddress = CreateType<System.ServiceModel.EndpointAddress>();
            object[] parametersOfNotificationDispatcherClient = { binding, remoteAddress };
            var methodNotificationDispatcherClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_notificationDispatcherClientInstanceType, methodNotificationDispatcherClientPrametersTypes, parametersOfNotificationDispatcherClient);
        }

        #endregion

        #region General Constructor : Class (NotificationDispatcherClient) constructors with dynamic parameters (Overloading_Of_4_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="NotificationDispatcherClient" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_NotificationDispatcherClient_Constructors_Overloading_Of_4_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodNotificationDispatcherClientPrametersTypes = new Type[] { typeof(System.ServiceModel.Channels.Binding), typeof(System.ServiceModel.EndpointAddress) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_notificationDispatcherClientInstanceType, Fixture, methodNotificationDispatcherClientPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="NotificationDispatcherClient" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodQueueNotification)]
        public void AUT_NotificationDispatcherClient_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<NotificationDispatcherClient>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (QueueNotification) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_NotificationDispatcherClient_QueueNotification_Method_Call_Internally(Type[] types)
        {
            var methodQueueNotificationPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationDispatcherClientInstance, MethodQueueNotification, Fixture, methodQueueNotificationPrametersTypes);
        }

        #endregion

        #region Method Call : (QueueNotification) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NotificationDispatcherClient_QueueNotification_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var notification = CreateType<PortfolioEngineCore.ND.Notification>();
            Action executeAction = null;

            // Act
            executeAction = () => _notificationDispatcherClientInstance.QueueNotification(notification);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (QueueNotification) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NotificationDispatcherClient_QueueNotification_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var notification = CreateType<PortfolioEngineCore.ND.Notification>();
            var methodQueueNotificationPrametersTypes = new Type[] { typeof(PortfolioEngineCore.ND.Notification) };
            object[] parametersOfQueueNotification = { notification };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodQueueNotification, methodQueueNotificationPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_notificationDispatcherClientInstanceFixture, parametersOfQueueNotification);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfQueueNotification.ShouldNotBeNull();
            parametersOfQueueNotification.Length.ShouldBe(1);
            methodQueueNotificationPrametersTypes.Length.ShouldBe(1);
            methodQueueNotificationPrametersTypes.Length.ShouldBe(parametersOfQueueNotification.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (QueueNotification) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NotificationDispatcherClient_QueueNotification_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var notification = CreateType<PortfolioEngineCore.ND.Notification>();
            var methodQueueNotificationPrametersTypes = new Type[] { typeof(PortfolioEngineCore.ND.Notification) };
            object[] parametersOfQueueNotification = { notification };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_notificationDispatcherClientInstance, MethodQueueNotification, parametersOfQueueNotification, methodQueueNotificationPrametersTypes);

            // Assert
            parametersOfQueueNotification.ShouldNotBeNull();
            parametersOfQueueNotification.Length.ShouldBe(1);
            methodQueueNotificationPrametersTypes.Length.ShouldBe(1);
            methodQueueNotificationPrametersTypes.Length.ShouldBe(parametersOfQueueNotification.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (QueueNotification) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NotificationDispatcherClient_QueueNotification_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodQueueNotification, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (QueueNotification) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NotificationDispatcherClient_QueueNotification_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodQueueNotificationPrametersTypes = new Type[] { typeof(PortfolioEngineCore.ND.Notification) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_notificationDispatcherClientInstance, MethodQueueNotification, Fixture, methodQueueNotificationPrametersTypes);

            // Assert
            methodQueueNotificationPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (QueueNotification) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_NotificationDispatcherClient_QueueNotification_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodQueueNotification, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_notificationDispatcherClientInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}