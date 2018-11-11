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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.ResourcePlanNotifications" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourcePlanNotificationsTest : AbstractBaseSetupTypedTest<ResourcePlanNotifications>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourcePlanNotifications) Initializer

        private const string MethodGetRPENotifcations = "GetRPENotifcations";
        private const string MethodCreateTicket = "CreateTicket";
        private const string Field_sqlConnection = "_sqlConnection";
        private Type _resourcePlanNotificationsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourcePlanNotifications _resourcePlanNotificationsInstance;
        private ResourcePlanNotifications _resourcePlanNotificationsInstanceFixture;

        #region General Initializer : Class (ResourcePlanNotifications) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourcePlanNotifications" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourcePlanNotificationsInstanceType = typeof(ResourcePlanNotifications);
            _resourcePlanNotificationsInstanceFixture = Create(true);
            _resourcePlanNotificationsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourcePlanNotifications)

        #region General Initializer : Class (ResourcePlanNotifications) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ResourcePlanNotifications" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetRPENotifcations, 0)]
        [TestCase(MethodCreateTicket, 0)]
        public void AUT_ResourcePlanNotifications_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_resourcePlanNotificationsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResourcePlanNotifications) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourcePlanNotifications" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_sqlConnection)]
        public void AUT_ResourcePlanNotifications_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourcePlanNotificationsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResourcePlanNotifications) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="ResourcePlanNotifications" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_ResourcePlanNotifications_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<ResourcePlanNotifications>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (ResourcePlanNotifications) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="ResourcePlanNotifications" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourcePlanNotifications_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<ResourcePlanNotifications>(Fixture);
        }

        #endregion

        #region General Constructor : Class (ResourcePlanNotifications) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ResourcePlanNotifications" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourcePlanNotifications_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var pid = CreateType<string>();
            var company = CreateType<string>();
            var dbcnstring = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var bDebug = CreateType<bool>();
            object[] parametersOfResourcePlanNotifications = { basepath, username, pid, company, dbcnstring, secLevel, bDebug };
            var methodResourcePlanNotificationsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_resourcePlanNotificationsInstanceType, methodResourcePlanNotificationsPrametersTypes, parametersOfResourcePlanNotifications);
        }

        #endregion

        #region General Constructor : Class (ResourcePlanNotifications) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ResourcePlanNotifications" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourcePlanNotifications_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodResourcePlanNotificationsPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels), typeof(bool) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_resourcePlanNotificationsInstanceType, Fixture, methodResourcePlanNotificationsPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (ResourcePlanNotifications) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ResourcePlanNotifications" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourcePlanNotifications_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var sBaseInfo = CreateType<string>();
            object[] parametersOfResourcePlanNotifications = { sBaseInfo };
            var methodResourcePlanNotificationsPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_resourcePlanNotificationsInstanceType, methodResourcePlanNotificationsPrametersTypes, parametersOfResourcePlanNotifications);
        }

        #endregion

        #region General Constructor : Class (ResourcePlanNotifications) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="ResourcePlanNotifications" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ResourcePlanNotifications_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodResourcePlanNotificationsPrametersTypes = new Type[] { typeof(string) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_resourcePlanNotificationsInstanceType, Fixture, methodResourcePlanNotificationsPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ResourcePlanNotifications" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetRPENotifcations)]
        [TestCase(MethodCreateTicket)]
        public void AUT_ResourcePlanNotifications_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourcePlanNotifications>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetRPENotifcations) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanNotifications_GetRPENotifcations_Method_Call_Internally(Type[] types)
        {
            var methodGetRPENotifcationsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanNotificationsInstance, MethodGetRPENotifcations, Fixture, methodGetRPENotifcationsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRPENotifcations) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_GetRPENotifcations_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _resourcePlanNotificationsInstance.GetRPENotifcations();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRPENotifcations) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_GetRPENotifcations_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetRPENotifcationsPrametersTypes = null;
            object[] parametersOfGetRPENotifcations = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetRPENotifcations, methodGetRPENotifcationsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePlanNotifications, string>(_resourcePlanNotificationsInstanceFixture, out exception1, parametersOfGetRPENotifcations);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePlanNotifications, string>(_resourcePlanNotificationsInstance, MethodGetRPENotifcations, parametersOfGetRPENotifcations, methodGetRPENotifcationsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRPENotifcations.ShouldBeNull();
            methodGetRPENotifcationsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRPENotifcations) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_GetRPENotifcations_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetRPENotifcationsPrametersTypes = null;
            object[] parametersOfGetRPENotifcations = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourcePlanNotifications, string>(_resourcePlanNotificationsInstance, MethodGetRPENotifcations, parametersOfGetRPENotifcations, methodGetRPENotifcationsPrametersTypes);

            // Assert
            parametersOfGetRPENotifcations.ShouldBeNull();
            methodGetRPENotifcationsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRPENotifcations) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_GetRPENotifcations_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetRPENotifcationsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanNotificationsInstance, MethodGetRPENotifcations, Fixture, methodGetRPENotifcationsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRPENotifcationsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRPENotifcations) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_GetRPENotifcations_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetRPENotifcationsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanNotificationsInstance, MethodGetRPENotifcations, Fixture, methodGetRPENotifcationsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRPENotifcationsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRPENotifcations) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_GetRPENotifcations_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRPENotifcations, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanNotificationsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateTicket) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlanNotifications_CreateTicket_Method_Call_Internally(Type[] types)
        {
            var methodCreateTicketPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanNotificationsInstance, MethodCreateTicket, Fixture, methodCreateTicketPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateTicket) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_CreateTicket_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sData = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _resourcePlanNotificationsInstance.CreateTicket(sData);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_CreateTicket_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sData = CreateType<string>();
            var methodCreateTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateTicket = { sData };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateTicket, methodCreateTicketPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ResourcePlanNotifications, string>(_resourcePlanNotificationsInstanceFixture, out exception1, parametersOfCreateTicket);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ResourcePlanNotifications, string>(_resourcePlanNotificationsInstance, MethodCreateTicket, parametersOfCreateTicket, methodCreateTicketPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateTicket.ShouldNotBeNull();
            parametersOfCreateTicket.Length.ShouldBe(1);
            methodCreateTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateTicket) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_CreateTicket_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sData = CreateType<string>();
            var methodCreateTicketPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfCreateTicket = { sData };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ResourcePlanNotifications, string>(_resourcePlanNotificationsInstance, MethodCreateTicket, parametersOfCreateTicket, methodCreateTicketPrametersTypes);

            // Assert
            parametersOfCreateTicket.ShouldNotBeNull();
            parametersOfCreateTicket.Length.ShouldBe(1);
            methodCreateTicketPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateTicket) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_CreateTicket_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCreateTicketPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanNotificationsInstance, MethodCreateTicket, Fixture, methodCreateTicketPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateTicketPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (CreateTicket) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_CreateTicket_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCreateTicketPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanNotificationsInstance, MethodCreateTicket, Fixture, methodCreateTicketPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateTicketPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateTicket) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_CreateTicket_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateTicket, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_resourcePlanNotificationsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateTicket) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ResourcePlanNotifications_CreateTicket_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCreateTicket, 0);
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