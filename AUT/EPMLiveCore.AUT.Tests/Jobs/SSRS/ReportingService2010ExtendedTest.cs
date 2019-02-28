using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.Jobs.SSRS
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.SSRS.ReportingService2010Extended" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.SSRS"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportingService2010ExtendedTest : AbstractBaseSetupTypedTest<ReportingService2010Extended>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingService2010Extended) Initializer

        private const string MethodGetWebRequest = "GetWebRequest";
        private const string MethodGetWebResponse = "GetWebResponse";
        private const string FieldauthCookies = "authCookies";
        private Type _reportingService2010ExtendedInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingService2010Extended _reportingService2010ExtendedInstance;
        private ReportingService2010Extended _reportingService2010ExtendedInstanceFixture;

        #region General Initializer : Class (ReportingService2010Extended) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingService2010Extended" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingService2010ExtendedInstanceType = typeof(ReportingService2010Extended);
            _reportingService2010ExtendedInstanceFixture = Create(true);
            _reportingService2010ExtendedInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingService2010Extended)

        #region General Initializer : Class (ReportingService2010Extended) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingService2010Extended" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodGetWebRequest, 0)]
        [TestCase(MethodGetWebResponse, 0)]
        public void AUT_ReportingService2010Extended_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingService2010ExtendedInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportingService2010Extended) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportingService2010Extended" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldauthCookies)]
        public void AUT_ReportingService2010Extended_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportingService2010ExtendedInstanceFixture, 
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
        ///     Class (<see cref="ReportingService2010Extended" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportingService2010Extended_Is_Instance_Present_Test()
        {
            // Assert
            _reportingService2010ExtendedInstanceType.ShouldNotBeNull();
            _reportingService2010ExtendedInstance.ShouldNotBeNull();
            _reportingService2010ExtendedInstanceFixture.ShouldNotBeNull();
            _reportingService2010ExtendedInstance.ShouldBeAssignableTo<ReportingService2010Extended>();
            _reportingService2010ExtendedInstanceFixture.ShouldBeAssignableTo<ReportingService2010Extended>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportingService2010Extended) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportingService2010Extended_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportingService2010Extended instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportingService2010ExtendedInstanceType.ShouldNotBeNull();
            _reportingService2010ExtendedInstance.ShouldNotBeNull();
            _reportingService2010ExtendedInstanceFixture.ShouldNotBeNull();
            _reportingService2010ExtendedInstance.ShouldBeAssignableTo<ReportingService2010Extended>();
            _reportingService2010ExtendedInstanceFixture.ShouldBeAssignableTo<ReportingService2010Extended>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportingService2010Extended" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetWebRequest)]
        [TestCase(MethodGetWebResponse)]
        public void AUT_ReportingService2010Extended_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportingService2010Extended>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (GetWebRequest) (Return Type : WebRequest) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService2010Extended_GetWebRequest_Method_Call_Internally(Type[] types)
        {
            var methodGetWebRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingService2010ExtendedInstance, MethodGetWebRequest, Fixture, methodGetWebRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWebRequest) (Return Type : WebRequest) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService2010Extended_GetWebRequest_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var uri = CreateType<Uri>();
            var methodGetWebRequestPrametersTypes = new Type[] { typeof(Uri) };
            object[] parametersOfGetWebRequest = { uri };

            // Assert
            parametersOfGetWebRequest.ShouldNotBeNull();
            parametersOfGetWebRequest.Length.ShouldBe(1);
            methodGetWebRequestPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ReportingService2010Extended, WebRequest>(_reportingService2010ExtendedInstance, MethodGetWebRequest, parametersOfGetWebRequest, methodGetWebRequestPrametersTypes));
        }

        #endregion

        #region Method Call : (GetWebRequest) (Return Type : WebRequest) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService2010Extended_GetWebRequest_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWebRequestPrametersTypes = new Type[] { typeof(Uri) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingService2010ExtendedInstance, MethodGetWebRequest, Fixture, methodGetWebRequestPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWebRequestPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWebRequest) (Return Type : WebRequest) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService2010Extended_GetWebRequest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWebRequestPrametersTypes = new Type[] { typeof(Uri) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingService2010ExtendedInstance, MethodGetWebRequest, Fixture, methodGetWebRequestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWebRequestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebRequest) (Return Type : WebRequest) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService2010Extended_GetWebRequest_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWebRequest, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebResponse) (Return Type : WebResponse) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingService2010Extended_GetWebResponse_Method_Call_Internally(Type[] types)
        {
            var methodGetWebResponsePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingService2010ExtendedInstance, MethodGetWebResponse, Fixture, methodGetWebResponsePrametersTypes);
        }

        #endregion

        #region Method Call : (GetWebResponse) (Return Type : WebResponse) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService2010Extended_GetWebResponse_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var request = CreateType<WebRequest>();
            var methodGetWebResponsePrametersTypes = new Type[] { typeof(WebRequest) };
            object[] parametersOfGetWebResponse = { request };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWebResponse, methodGetWebResponsePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingService2010Extended, WebResponse>(_reportingService2010ExtendedInstanceFixture, out exception1, parametersOfGetWebResponse);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingService2010Extended, WebResponse>(_reportingService2010ExtendedInstance, MethodGetWebResponse, parametersOfGetWebResponse, methodGetWebResponsePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWebResponse.ShouldNotBeNull();
            parametersOfGetWebResponse.Length.ShouldBe(1);
            methodGetWebResponsePrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(() => methodInfo.Invoke(_reportingService2010ExtendedInstanceFixture, parametersOfGetWebResponse));
        }

        #endregion

        #region Method Call : (GetWebResponse) (Return Type : WebResponse) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService2010Extended_GetWebResponse_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var request = CreateType<WebRequest>();
            var methodGetWebResponsePrametersTypes = new Type[] { typeof(WebRequest) };
            object[] parametersOfGetWebResponse = { request };

            // Assert
            parametersOfGetWebResponse.ShouldNotBeNull();
            parametersOfGetWebResponse.Length.ShouldBe(1);
            methodGetWebResponsePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<ReportingService2010Extended, WebResponse>(_reportingService2010ExtendedInstance, MethodGetWebResponse, parametersOfGetWebResponse, methodGetWebResponsePrametersTypes));
        }

        #endregion

        #region Method Call : (GetWebResponse) (Return Type : WebResponse) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService2010Extended_GetWebResponse_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetWebResponsePrametersTypes = new Type[] { typeof(WebRequest) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingService2010ExtendedInstance, MethodGetWebResponse, Fixture, methodGetWebResponsePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWebResponsePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetWebResponse) (Return Type : WebResponse) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService2010Extended_GetWebResponse_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetWebResponsePrametersTypes = new Type[] { typeof(WebRequest) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingService2010ExtendedInstance, MethodGetWebResponse, Fixture, methodGetWebResponsePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWebResponsePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWebResponse) (Return Type : WebResponse) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService2010Extended_GetWebResponse_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWebResponse, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingService2010ExtendedInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWebResponse) (Return Type : WebResponse) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingService2010Extended_GetWebResponse_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetWebResponse, 0);
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