using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.WebService" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WebServiceTest : AbstractBaseSetupTypedTest<WebService>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WebService) Initializer

        private const string MethodBeginSession = "BeginSession";
        private const string MethodBeginSessionEx = "BeginSessionEx";
        private const string MethodEndSession = "EndSession";
        private const string MethodXMLRequest = "XMLRequest";
        private const string MethodSessionInfo = "SessionInfo";
        private const string MethodHandlePing = "HandlePing";
        private const string MethodHandleError = "HandleError";
        private const string MethodHandleException = "HandleException";
        private Type _webServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WebService _webServiceInstance;
        private WebService _webServiceInstanceFixture;

        #region General Initializer : Class (WebService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WebService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _webServiceInstanceType = typeof(WebService);
            _webServiceInstanceFixture = Create(true);
            _webServiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WebService)

        #region General Initializer : Class (WebService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WebService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodBeginSession, 0)]
        [TestCase(MethodBeginSessionEx, 0)]
        [TestCase(MethodEndSession, 0)]
        [TestCase(MethodXMLRequest, 0)]
        [TestCase(MethodSessionInfo, 0)]
        [TestCase(MethodHandlePing, 0)]
        [TestCase(MethodHandleError, 0)]
        [TestCase(MethodHandleException, 0)]
        public void AUT_WebService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_webServiceInstanceFixture, 
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
        ///     Class (<see cref="WebService" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WebService_Is_Instance_Present_Test()
        {
            // Assert
            _webServiceInstanceType.ShouldNotBeNull();
            _webServiceInstance.ShouldNotBeNull();
            _webServiceInstanceFixture.ShouldNotBeNull();
            _webServiceInstance.ShouldBeAssignableTo<WebService>();
            _webServiceInstanceFixture.ShouldBeAssignableTo<WebService>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WebService) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WebService_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WebService instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _webServiceInstanceType.ShouldNotBeNull();
            _webServiceInstance.ShouldNotBeNull();
            _webServiceInstanceFixture.ShouldNotBeNull();
            _webServiceInstance.ShouldBeAssignableTo<WebService>();
            _webServiceInstanceFixture.ShouldBeAssignableTo<WebService>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WebService" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodHandlePing)]
        [TestCase(MethodHandleError)]
        [TestCase(MethodHandleException)]
        public void AUT_WebService_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_webServiceInstanceFixture,
                                                                              _webServiceInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WebService" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodBeginSession)]
        [TestCase(MethodBeginSessionEx)]
        [TestCase(MethodEndSession)]
        [TestCase(MethodXMLRequest)]
        [TestCase(MethodSessionInfo)]
        public void AUT_WebService_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WebService>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (BeginSession) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebService_BeginSession_Method_Call_Internally(Type[] types)
        {
            var methodBeginSessionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodBeginSession, Fixture, methodBeginSessionPrametersTypes);
        }

        #endregion

        #region Method Call : (BeginSession) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSession_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sUserName = CreateType<string>();
            var sPassword = CreateType<string>();
            var sNTAuth = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _webServiceInstance.BeginSession(sUserName, sPassword, sNTAuth);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (BeginSession) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSession_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sUserName = CreateType<string>();
            var sPassword = CreateType<string>();
            var sNTAuth = CreateType<string>();
            var methodBeginSessionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfBeginSession = { sUserName, sPassword, sNTAuth };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBeginSession, methodBeginSessionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WebService, string>(_webServiceInstanceFixture, out exception1, parametersOfBeginSession);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WebService, string>(_webServiceInstance, MethodBeginSession, parametersOfBeginSession, methodBeginSessionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBeginSession.ShouldNotBeNull();
            parametersOfBeginSession.Length.ShouldBe(3);
            methodBeginSessionPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (BeginSession) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSession_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sUserName = CreateType<string>();
            var sPassword = CreateType<string>();
            var sNTAuth = CreateType<string>();
            var methodBeginSessionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfBeginSession = { sUserName, sPassword, sNTAuth };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WebService, string>(_webServiceInstance, MethodBeginSession, parametersOfBeginSession, methodBeginSessionPrametersTypes);

            // Assert
            parametersOfBeginSession.ShouldNotBeNull();
            parametersOfBeginSession.Length.ShouldBe(3);
            methodBeginSessionPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BeginSession) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSession_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBeginSessionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodBeginSession, Fixture, methodBeginSessionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBeginSessionPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (BeginSession) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSession_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBeginSessionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodBeginSession, Fixture, methodBeginSessionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBeginSessionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BeginSession) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSession_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBeginSession, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BeginSession) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSession_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBeginSession, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BeginSessionEx) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebService_BeginSessionEx_Method_Call_Internally(Type[] types)
        {
            var methodBeginSessionExPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodBeginSessionEx, Fixture, methodBeginSessionExPrametersTypes);
        }

        #endregion

        #region Method Call : (BeginSessionEx) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSessionEx_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _webServiceInstance.BeginSessionEx();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (BeginSessionEx) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSessionEx_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodBeginSessionExPrametersTypes = null;
            object[] parametersOfBeginSessionEx = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBeginSessionEx, methodBeginSessionExPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WebService, string>(_webServiceInstanceFixture, out exception1, parametersOfBeginSessionEx);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WebService, string>(_webServiceInstance, MethodBeginSessionEx, parametersOfBeginSessionEx, methodBeginSessionExPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBeginSessionEx.ShouldBeNull();
            methodBeginSessionExPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BeginSessionEx) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSessionEx_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBeginSessionExPrametersTypes = null;
            object[] parametersOfBeginSessionEx = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WebService, string>(_webServiceInstance, MethodBeginSessionEx, parametersOfBeginSessionEx, methodBeginSessionExPrametersTypes);

            // Assert
            parametersOfBeginSessionEx.ShouldBeNull();
            methodBeginSessionExPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BeginSessionEx) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSessionEx_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodBeginSessionExPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodBeginSessionEx, Fixture, methodBeginSessionExPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBeginSessionExPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BeginSessionEx) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSessionEx_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBeginSessionExPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodBeginSessionEx, Fixture, methodBeginSessionExPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBeginSessionExPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BeginSessionEx) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_BeginSessionEx_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBeginSessionEx, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (EndSession) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebService_EndSession_Method_Call_Internally(Type[] types)
        {
            var methodEndSessionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodEndSession, Fixture, methodEndSessionPrametersTypes);
        }

        #endregion

        #region Method Call : (EndSession) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_EndSession_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _webServiceInstance.EndSession();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (EndSession) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_EndSession_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodEndSessionPrametersTypes = null;
            object[] parametersOfEndSession = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEndSession, methodEndSessionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webServiceInstanceFixture, parametersOfEndSession);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEndSession.ShouldBeNull();
            methodEndSessionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EndSession) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_EndSession_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodEndSessionPrametersTypes = null;
            object[] parametersOfEndSession = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_webServiceInstance, MethodEndSession, parametersOfEndSession, methodEndSessionPrametersTypes);

            // Assert
            parametersOfEndSession.ShouldBeNull();
            methodEndSessionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EndSession) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_EndSession_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodEndSessionPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodEndSession, Fixture, methodEndSessionPrametersTypes);

            // Assert
            methodEndSessionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EndSession) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_EndSession_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEndSession, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_webServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XMLRequest) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebService_XMLRequest_Method_Call_Internally(Type[] types)
        {
            var methodXMLRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodXMLRequest, Fixture, methodXMLRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (XMLRequest) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_XMLRequest_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sRequest = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _webServiceInstance.XMLRequest(sContext, sRequest);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (XMLRequest) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_XMLRequest_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sRequest = CreateType<string>();
            var methodXMLRequestPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfXMLRequest = { sContext, sRequest };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodXMLRequest, methodXMLRequestPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WebService, string>(_webServiceInstanceFixture, out exception1, parametersOfXMLRequest);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WebService, string>(_webServiceInstance, MethodXMLRequest, parametersOfXMLRequest, methodXMLRequestPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfXMLRequest.ShouldNotBeNull();
            parametersOfXMLRequest.Length.ShouldBe(2);
            methodXMLRequestPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (XMLRequest) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_XMLRequest_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sRequest = CreateType<string>();
            var methodXMLRequestPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfXMLRequest = { sContext, sRequest };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WebService, string>(_webServiceInstance, MethodXMLRequest, parametersOfXMLRequest, methodXMLRequestPrametersTypes);

            // Assert
            parametersOfXMLRequest.ShouldNotBeNull();
            parametersOfXMLRequest.Length.ShouldBe(2);
            methodXMLRequestPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (XMLRequest) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_XMLRequest_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodXMLRequestPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodXMLRequest, Fixture, methodXMLRequestPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodXMLRequestPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (XMLRequest) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_XMLRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodXMLRequestPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodXMLRequest, Fixture, methodXMLRequestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodXMLRequestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (XMLRequest) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_XMLRequest_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodXMLRequest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (XMLRequest) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_XMLRequest_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodXMLRequest, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SessionInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebService_SessionInfo_Method_Call_Internally(Type[] types)
        {
            var methodSessionInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodSessionInfo, Fixture, methodSessionInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (SessionInfo) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_SessionInfo_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItem = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _webServiceInstance.SessionInfo(sItem);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SessionInfo) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_SessionInfo_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sItem = CreateType<string>();
            var methodSessionInfoPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSessionInfo = { sItem };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSessionInfo, methodSessionInfoPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<WebService, string>(_webServiceInstanceFixture, out exception1, parametersOfSessionInfo);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<WebService, string>(_webServiceInstance, MethodSessionInfo, parametersOfSessionInfo, methodSessionInfoPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSessionInfo.ShouldNotBeNull();
            parametersOfSessionInfo.Length.ShouldBe(1);
            methodSessionInfoPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SessionInfo) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_SessionInfo_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sItem = CreateType<string>();
            var methodSessionInfoPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSessionInfo = { sItem };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSessionInfo, methodSessionInfoPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webServiceInstanceFixture, parametersOfSessionInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSessionInfo.ShouldNotBeNull();
            parametersOfSessionInfo.Length.ShouldBe(1);
            methodSessionInfoPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SessionInfo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_SessionInfo_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sItem = CreateType<string>();
            var methodSessionInfoPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSessionInfo = { sItem };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<WebService, string>(_webServiceInstance, MethodSessionInfo, parametersOfSessionInfo, methodSessionInfoPrametersTypes);

            // Assert
            parametersOfSessionInfo.ShouldNotBeNull();
            parametersOfSessionInfo.Length.ShouldBe(1);
            methodSessionInfoPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SessionInfo) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_SessionInfo_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodSessionInfoPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodSessionInfo, Fixture, methodSessionInfoPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodSessionInfoPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (SessionInfo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_SessionInfo_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSessionInfoPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webServiceInstance, MethodSessionInfo, Fixture, methodSessionInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSessionInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SessionInfo) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_SessionInfo_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSessionInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (SessionInfo) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_SessionInfo_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSessionInfo, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandlePing) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebService_HandlePing_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandlePingPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandlePing, Fixture, methodHandlePingPrametersTypes);
        }

        #endregion

        #region Method Call : (HandlePing) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandlePing_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var methodHandlePingPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfHandlePing = { Context };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandlePing, methodHandlePingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webServiceInstanceFixture, parametersOfHandlePing);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandlePing.ShouldNotBeNull();
            parametersOfHandlePing.Length.ShouldBe(1);
            methodHandlePingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandlePing) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandlePing_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var methodHandlePingPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfHandlePing = { Context };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandlePing, parametersOfHandlePing, methodHandlePingPrametersTypes);

            // Assert
            parametersOfHandlePing.ShouldNotBeNull();
            parametersOfHandlePing.Length.ShouldBe(1);
            methodHandlePingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandlePing) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandlePing_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandlePingPrametersTypes = new Type[] { typeof(HttpContext) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandlePing, Fixture, methodHandlePingPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandlePingPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (HandlePing) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandlePing_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandlePingPrametersTypes = new Type[] { typeof(HttpContext) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandlePing, Fixture, methodHandlePingPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandlePingPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandlePing) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandlePing_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandlePing, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HandlePing) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandlePing_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandlePing, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebService_HandleError_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleError_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sError = CreateType<string>();
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfHandleError = { sContext, sError };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleError, methodHandleErrorPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleError, parametersOfHandleError, methodHandleErrorPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_webServiceInstanceFixture, parametersOfHandleError);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfHandleError.ShouldNotBeNull();
            parametersOfHandleError.Length.ShouldBe(2);
            methodHandleErrorPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleError_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sContext = CreateType<string>();
            var sError = CreateType<string>();
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfHandleError = { sContext, sError };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleError, parametersOfHandleError, methodHandleErrorPrametersTypes);

            // Assert
            parametersOfHandleError.ShouldNotBeNull();
            parametersOfHandleError.Length.ShouldBe(2);
            methodHandleErrorPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleError_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleErrorPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleError_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleErrorPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleError, Fixture, methodHandleErrorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleErrorPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleError_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleError, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HandleError) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleError_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandleError, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebService_HandleException_Static_Method_Call_Internally(Type[] types)
        {
            var methodHandleExceptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleException_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var ex = CreateType<Exception>();
            var sContext = CreateType<string>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception), typeof(string) };
            object[] parametersOfHandleException = { ex, sContext };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleException, methodHandleExceptionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleException, parametersOfHandleException, methodHandleExceptionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_webServiceInstanceFixture, parametersOfHandleException);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(2);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleException_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ex = CreateType<Exception>();
            var sContext = CreateType<string>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception), typeof(string) };
            object[] parametersOfHandleException = { ex, sContext };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleException, parametersOfHandleException, methodHandleExceptionPrametersTypes);

            // Assert
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(2);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleException_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodHandleExceptionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleException_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webServiceInstanceFixture, _webServiceInstanceType, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleException_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleException, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebService_HandleException_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandleException, 0);
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