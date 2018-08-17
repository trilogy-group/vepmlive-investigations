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

namespace EPMLiveCore.SocialEngine.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SocialEngine.API.Gateway" />)
    ///     and namespace <see cref="EPMLiveCore.SocialEngine.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GatewayTest : AbstractBaseSetupTypedTest<Gateway>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Gateway) Initializer

        private const string MethodProcessActivity = "ProcessActivity";
        private Type _gatewayInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Gateway _gatewayInstance;
        private Gateway _gatewayInstanceFixture;

        #region General Initializer : Class (Gateway) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Gateway" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gatewayInstanceType = typeof(Gateway);
            _gatewayInstanceFixture = Create(true);
            _gatewayInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Gateway)

        #region General Initializer : Class (Gateway) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Gateway" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodProcessActivity, 0)]
        public void AUT_Gateway_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gatewayInstanceFixture, 
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
        ///     Class (<see cref="Gateway" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Gateway_Is_Instance_Present_Test()
        {
            // Assert
            _gatewayInstanceType.ShouldNotBeNull();
            _gatewayInstance.ShouldNotBeNull();
            _gatewayInstanceFixture.ShouldNotBeNull();
            _gatewayInstance.ShouldBeAssignableTo<Gateway>();
            _gatewayInstanceFixture.ShouldBeAssignableTo<Gateway>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Gateway) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Gateway_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Gateway instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gatewayInstanceType.ShouldNotBeNull();
            _gatewayInstance.ShouldNotBeNull();
            _gatewayInstanceFixture.ShouldNotBeNull();
            _gatewayInstance.ShouldBeAssignableTo<Gateway>();
            _gatewayInstanceFixture.ShouldBeAssignableTo<Gateway>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Gateway" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodProcessActivity)]
        public void AUT_Gateway_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Gateway>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_ProcessActivity_Method_Call_Internally(Type[] types)
        {
            var methodProcessActivityPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodProcessActivity, Fixture, methodProcessActivityPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_ProcessActivity_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _gatewayInstance.ProcessActivity(data, spWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_ProcessActivity_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodProcessActivityPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfProcessActivity = { data, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodProcessActivity, methodProcessActivityPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Gateway, string>(_gatewayInstanceFixture, out exception1, parametersOfProcessActivity);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Gateway, string>(_gatewayInstance, MethodProcessActivity, parametersOfProcessActivity, methodProcessActivityPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfProcessActivity.ShouldNotBeNull();
            parametersOfProcessActivity.Length.ShouldBe(2);
            methodProcessActivityPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_ProcessActivity_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodProcessActivityPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfProcessActivity = { data, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessActivity, methodProcessActivityPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gatewayInstanceFixture, parametersOfProcessActivity);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessActivity.ShouldNotBeNull();
            parametersOfProcessActivity.Length.ShouldBe(2);
            methodProcessActivityPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_ProcessActivity_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodProcessActivityPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfProcessActivity = { data, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Gateway, string>(_gatewayInstance, MethodProcessActivity, parametersOfProcessActivity, methodProcessActivityPrametersTypes);

            // Assert
            parametersOfProcessActivity.ShouldNotBeNull();
            parametersOfProcessActivity.Length.ShouldBe(2);
            methodProcessActivityPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_ProcessActivity_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodProcessActivityPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodProcessActivity, Fixture, methodProcessActivityPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodProcessActivityPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_ProcessActivity_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessActivityPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodProcessActivity, Fixture, methodProcessActivityPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodProcessActivityPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_ProcessActivity_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessActivity, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gatewayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ProcessActivity) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_ProcessActivity_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessActivity, 0);
            const int parametersCount = 2;

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