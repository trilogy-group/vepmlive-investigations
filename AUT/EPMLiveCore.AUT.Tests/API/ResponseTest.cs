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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Response" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResponseTest : AbstractBaseSetupTypedTest<Response>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Response) Initializer

        private const string MethodFailure = "Failure";
        private const string MethodSuccess = "Success";
        private Type _responseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Response _responseInstance;
        private Response _responseInstanceFixture;

        #region General Initializer : Class (Response) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Response" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _responseInstanceType = typeof(Response);
            _responseInstanceFixture = Create(true);
            _responseInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Response)

        #region General Initializer : Class (Response) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Response" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodFailure, 0)]
        [TestCase(MethodSuccess, 0)]
        public void AUT_Response_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_responseInstanceFixture, 
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
        ///     Class (<see cref="Response" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Response_Is_Instance_Present_Test()
        {
            // Assert
            _responseInstanceType.ShouldNotBeNull();
            _responseInstance.ShouldNotBeNull();
            _responseInstanceFixture.ShouldNotBeNull();
            _responseInstance.ShouldBeAssignableTo<Response>();
            _responseInstanceFixture.ShouldBeAssignableTo<Response>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Response) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Response_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Response instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _responseInstanceType.ShouldNotBeNull();
            _responseInstance.ShouldNotBeNull();
            _responseInstanceFixture.ShouldNotBeNull();
            _responseInstance.ShouldBeAssignableTo<Response>();
            _responseInstanceFixture.ShouldBeAssignableTo<Response>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="Response" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodFailure)]
        [TestCase(MethodSuccess)]
        public void AUT_Response_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_responseInstanceFixture,
                                                                              _responseInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (Failure) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Response_Failure_Static_Method_Call_Internally(Type[] types)
        {
            var methodFailurePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_responseInstanceFixture, _responseInstanceType, MethodFailure, Fixture, methodFailurePrametersTypes);
        }

        #endregion

        #region Method Call : (Failure) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var errorId = CreateType<int>();
            var errorMessage = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Response.Failure(errorId, errorMessage);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Failure) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var errorId = CreateType<int>();
            var errorMessage = CreateType<string>();
            var methodFailurePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfFailure = { errorId, errorMessage };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFailure, methodFailurePrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFailure.ShouldNotBeNull();
            parametersOfFailure.Length.ShouldBe(2);
            methodFailurePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => methodInfo.Invoke(_responseInstanceFixture, parametersOfFailure));
        }

        #endregion

        #region Method Call : (Failure) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var errorId = CreateType<int>();
            var errorMessage = CreateType<string>();
            var methodFailurePrametersTypes = new Type[] { typeof(int), typeof(string) };
            object[] parametersOfFailure = { errorId, errorMessage };

            // Assert
            parametersOfFailure.ShouldNotBeNull();
            parametersOfFailure.Length.ShouldBe(2);
            methodFailurePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_responseInstanceFixture, _responseInstanceType, MethodFailure, parametersOfFailure, methodFailurePrametersTypes));
        }

        #endregion

        #region Method Call : (Failure) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodFailurePrametersTypes = new Type[] { typeof(int), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_responseInstanceFixture, _responseInstanceType, MethodFailure, Fixture, methodFailurePrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodFailurePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (Failure) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFailurePrametersTypes = new Type[] { typeof(int), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_responseInstanceFixture, _responseInstanceType, MethodFailure, Fixture, methodFailurePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFailurePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Failure) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFailure, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_responseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Failure) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Failure_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFailure, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Success) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Response_Success_Static_Method_Call_Internally(Type[] types)
        {
            var methodSuccessPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_responseInstanceFixture, _responseInstanceType, MethodSuccess, Fixture, methodSuccessPrametersTypes);
        }

        #endregion

        #region Method Call : (Success) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var result = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => Response.Success(result);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (Success) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var result = CreateType<string>();
            var methodSuccessPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSuccess = { result };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSuccess, methodSuccessPrametersTypes, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSuccess.ShouldNotBeNull();
            parametersOfSuccess.Length.ShouldBe(1);
            methodSuccessPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => methodInfo.Invoke(_responseInstanceFixture, parametersOfSuccess));
        }

        #endregion

        #region Method Call : (Success) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var result = CreateType<string>();
            var methodSuccessPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSuccess = { result };

            // Assert
            parametersOfSuccess.ShouldNotBeNull();
            parametersOfSuccess.Length.ShouldBe(1);
            methodSuccessPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_responseInstanceFixture, _responseInstanceType, MethodSuccess, parametersOfSuccess, methodSuccessPrametersTypes));
        }

        #endregion

        #region Method Call : (Success) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSuccessPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_responseInstanceFixture, _responseInstanceType, MethodSuccess, Fixture, methodSuccessPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSuccessPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (Success) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSuccessPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_responseInstanceFixture, _responseInstanceType, MethodSuccess, Fixture, methodSuccessPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSuccessPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Success) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSuccess, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_responseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (Success) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Response_Success_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSuccess, 0);
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