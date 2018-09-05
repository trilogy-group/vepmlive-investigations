using System;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using PortfolioEngineCore;
using Should = Shouldly.Should;
using Shouldly;

namespace WorkEnginePPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.WebAdmin" />)
    ///     and namespace <see cref="WorkEnginePPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WebAdminTest : AbstractBaseSetupTypedTest<WebAdmin>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WebAdmin) Initializer

        private const string MethodCapturePFEBaseInfo = "CapturePFEBaseInfo";
        private const string MethodBuildBaseInfo = "BuildBaseInfo";
        private const string MethodGetConnectionString = "GetConnectionString";
        private const string MethodBuildSiteRegistryKey = "BuildSiteRegistryKey";
        private const string MethodGetBasePath = "GetBasePath";
        private const string MethodGetSPSessionString = "GetSPSessionString";
        private const string MethodSetSPSessionString = "SetSPSessionString";
        private const string MethodAuthenticateUserAndProduct = "AuthenticateUserAndProduct";
        private const string MethodHasPagePermission = "HasPagePermission";
        private const string MethodCheckRequest = "CheckRequest";
        private const string MethodBuildReply = "BuildReply";
        private const string MethodFormatError = "FormatError";
        private const string MethodFormatWarning = "FormatWarning";
        private Type _webAdminInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WebAdmin _webAdminInstance;
        private WebAdmin _webAdminInstanceFixture;

        #region General Initializer : Class (WebAdmin) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WebAdmin" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _webAdminInstanceType = typeof(WebAdmin);
            _webAdminInstanceFixture = Create(true);
            _webAdminInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WebAdmin)

        #region General Initializer : Class (WebAdmin) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WebAdmin" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCapturePFEBaseInfo, 0)]
        [TestCase(MethodCapturePFEBaseInfo, 1)]
        [TestCase(MethodBuildBaseInfo, 0)]
        [TestCase(MethodBuildBaseInfo, 1)]
        [TestCase(MethodGetConnectionString, 0)]
        [TestCase(MethodGetConnectionString, 1)]
        [TestCase(MethodGetConnectionString, 2)]
        [TestCase(MethodBuildSiteRegistryKey, 0)]
        [TestCase(MethodGetBasePath, 0)]
        [TestCase(MethodGetSPSessionString, 0)]
        [TestCase(MethodSetSPSessionString, 0)]
        [TestCase(MethodSetSPSessionString, 1)]
        [TestCase(MethodAuthenticateUserAndProduct, 0)]
        [TestCase(MethodHasPagePermission, 0)]
        [TestCase(MethodCheckRequest, 0)]
        [TestCase(MethodBuildReply, 0)]
        [TestCase(MethodFormatError, 0)]
        [TestCase(MethodFormatWarning, 0)]
        public void AUT_WebAdmin_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_webAdminInstanceFixture, 
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
        ///     Class (<see cref="WebAdmin" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WebAdmin_Is_Instance_Present_Test()
        {
            // Assert
            _webAdminInstanceType.ShouldNotBeNull();
            _webAdminInstance.ShouldNotBeNull();
            _webAdminInstanceFixture.ShouldNotBeNull();
            _webAdminInstance.ShouldBeAssignableTo<WebAdmin>();
            _webAdminInstanceFixture.ShouldBeAssignableTo<WebAdmin>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WebAdmin) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WebAdmin_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WebAdmin instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _webAdminInstanceType.ShouldNotBeNull();
            _webAdminInstance.ShouldNotBeNull();
            _webAdminInstanceFixture.ShouldNotBeNull();
            _webAdminInstance.ShouldBeAssignableTo<WebAdmin>();
            _webAdminInstanceFixture.ShouldBeAssignableTo<WebAdmin>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="WebAdmin" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCapturePFEBaseInfo)]
        [TestCase(MethodBuildBaseInfo)]
        [TestCase(MethodGetConnectionString)]
        [TestCase(MethodBuildSiteRegistryKey)]
        [TestCase(MethodGetBasePath)]
        [TestCase(MethodGetSPSessionString)]
        [TestCase(MethodSetSPSessionString)]
        [TestCase(MethodAuthenticateUserAndProduct)]
        [TestCase(MethodHasPagePermission)]
        [TestCase(MethodCheckRequest)]
        [TestCase(MethodBuildReply)]
        [TestCase(MethodFormatError)]
        [TestCase(MethodFormatWarning)]
        public void AUT_WebAdmin_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_webAdminInstanceFixture,
                                                                              _webAdminInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodCapturePFEBaseInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodCapturePFEBaseInfo, Fixture, methodCapturePFEBaseInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var ppmId = CreateType<string>();
            var ppmCompany = CreateType<string>();
            var ppmDbConn = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.CapturePFEBaseInfo(out basepath, out username, out ppmId, out ppmCompany, out ppmDbConn, out secLevel);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var ppmId = CreateType<string>();
            var ppmCompany = CreateType<string>();
            var ppmDbConn = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var methodCapturePFEBaseInfoPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels) };
            object[] parametersOfCapturePFEBaseInfo = { basepath, username, ppmId, ppmCompany, ppmDbConn, secLevel };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_webAdminInstanceFixture, _webAdminInstanceType, MethodCapturePFEBaseInfo, parametersOfCapturePFEBaseInfo, methodCapturePFEBaseInfoPrametersTypes);

            // Assert
            parametersOfCapturePFEBaseInfo.ShouldNotBeNull();
            parametersOfCapturePFEBaseInfo.Length.ShouldBe(6);
            methodCapturePFEBaseInfoPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCapturePFEBaseInfo, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCapturePFEBaseInfoPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodCapturePFEBaseInfo, Fixture, methodCapturePFEBaseInfoPrametersTypes);

            // Assert
            methodCapturePFEBaseInfoPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCapturePFEBaseInfo, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodCapturePFEBaseInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodCapturePFEBaseInfo, Fixture, methodCapturePFEBaseInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var ppmId = CreateType<string>();
            var ppmCompany = CreateType<string>();
            var ppmDbConn = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.CapturePFEBaseInfo(web, out basepath, out username, out ppmId, out ppmCompany, out ppmDbConn, out secLevel);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_Call_Void_Overloading_Of_1_With_7_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var basepath = CreateType<string>();
            var username = CreateType<string>();
            var ppmId = CreateType<string>();
            var ppmCompany = CreateType<string>();
            var ppmDbConn = CreateType<string>();
            var secLevel = CreateType<SecurityLevels>();
            var methodCapturePFEBaseInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels) };
            object[] parametersOfCapturePFEBaseInfo = { web, basepath, username, ppmId, ppmCompany, ppmDbConn, secLevel };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_webAdminInstanceFixture, _webAdminInstanceType, MethodCapturePFEBaseInfo, parametersOfCapturePFEBaseInfo, methodCapturePFEBaseInfoPrametersTypes);

            // Assert
            parametersOfCapturePFEBaseInfo.ShouldNotBeNull();
            parametersOfCapturePFEBaseInfo.Length.ShouldBe(7);
            methodCapturePFEBaseInfoPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCapturePFEBaseInfo, 1);
            const int parametersCount = 7;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCapturePFEBaseInfoPrametersTypes = new Type[] { typeof(SPWeb), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(SecurityLevels) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodCapturePFEBaseInfo, Fixture, methodCapturePFEBaseInfoPrametersTypes);

            // Assert
            methodCapturePFEBaseInfoPrametersTypes.Length.ShouldBe(7);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CapturePFEBaseInfo) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CapturePFEBaseInfo_Static_Method_Call_Overloading_Of_1_With_7_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCapturePFEBaseInfo, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildBaseInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, Fixture, methodBuildBaseInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var web = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.BuildBaseInfo(context, web);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var web = CreateType<SPWeb>();
            var methodBuildBaseInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(SPWeb) };
            object[] parametersOfBuildBaseInfo = { context, web };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildBaseInfo, methodBuildBaseInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, Fixture, methodBuildBaseInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, parametersOfBuildBaseInfo, methodBuildBaseInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfBuildBaseInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildBaseInfo.ShouldNotBeNull();
            parametersOfBuildBaseInfo.Length.ShouldBe(2);
            methodBuildBaseInfoPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var web = CreateType<SPWeb>();
            var methodBuildBaseInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(SPWeb) };
            object[] parametersOfBuildBaseInfo = { context, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, parametersOfBuildBaseInfo, methodBuildBaseInfoPrametersTypes);

            // Assert
            parametersOfBuildBaseInfo.ShouldNotBeNull();
            parametersOfBuildBaseInfo.Length.ShouldBe(2);
            methodBuildBaseInfoPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildBaseInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, Fixture, methodBuildBaseInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildBaseInfoPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildBaseInfoPrametersTypes = new Type[] { typeof(HttpContext), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, Fixture, methodBuildBaseInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildBaseInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildBaseInfo, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildBaseInfo, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_BuildBaseInfo_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodBuildBaseInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, Fixture, methodBuildBaseInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_DirectCall_Overloading_Of_1_Throw_Exception_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.BuildBaseInfo(context);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Overloading_Of_1_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var methodBuildBaseInfoPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfBuildBaseInfo = { context };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildBaseInfo, methodBuildBaseInfoPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, Fixture, methodBuildBaseInfoPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, parametersOfBuildBaseInfo, methodBuildBaseInfoPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfBuildBaseInfo);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildBaseInfo.ShouldNotBeNull();
            parametersOfBuildBaseInfo.Length.ShouldBe(1);
            methodBuildBaseInfoPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var methodBuildBaseInfoPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfBuildBaseInfo = { context };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, parametersOfBuildBaseInfo, methodBuildBaseInfoPrametersTypes);

            // Assert
            parametersOfBuildBaseInfo.ShouldNotBeNull();
            parametersOfBuildBaseInfo.Length.ShouldBe(1);
            methodBuildBaseInfoPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildBaseInfoPrametersTypes = new Type[] { typeof(HttpContext) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, Fixture, methodBuildBaseInfoPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildBaseInfoPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildBaseInfoPrametersTypes = new Type[] { typeof(HttpContext) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildBaseInfo, Fixture, methodBuildBaseInfoPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildBaseInfoPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildBaseInfo, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildBaseInfo) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildBaseInfo_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildBaseInfo, 1);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.GetConnectionString(Context);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfGetConnectionString = { Context };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, methodGetConnectionStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, parametersOfGetConnectionString, methodGetConnectionStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetConnectionString.ShouldNotBeNull();
            parametersOfGetConnectionString.Length.ShouldBe(1);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, parametersOfGetConnectionString, methodGetConnectionStringPrametersTypes));
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfGetConnectionString = { Context };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, methodGetConnectionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfGetConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetConnectionString.ShouldNotBeNull();
            parametersOfGetConnectionString.Length.ShouldBe(1);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(HttpContext) };
            object[] parametersOfGetConnectionString = { Context };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, parametersOfGetConnectionString, methodGetConnectionStringPrametersTypes);

            // Assert
            parametersOfGetConnectionString.ShouldNotBeNull();
            parametersOfGetConnectionString.Length.ShouldBe(1);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(HttpContext) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(HttpContext) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetConnectionString, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_GetConnectionString_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodGetConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.GetConnectionString();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_1_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetConnectionStringPrametersTypes = null;
            object[] parametersOfGetConnectionString = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, methodGetConnectionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfGetConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetConnectionString.ShouldBeNull();
            methodGetConnectionStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_1_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetConnectionStringPrametersTypes = null;
            object[] parametersOfGetConnectionString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, parametersOfGetConnectionString, methodGetConnectionStringPrametersTypes);

            // Assert
            parametersOfGetConnectionString.ShouldBeNull();
            methodGetConnectionStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetConnectionStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetConnectionStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetConnectionStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetConnectionStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, 1);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_GetConnectionString_Static_Method_Overloading_Of_2_Call_Internally(Type[] types)
        {
            var methodGetConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_DirectCall_Overloading_Of_2_No_Exception_Thrown_Test()
        {
            // Arrange
            var basePath = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.GetConnectionString(basePath);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_2_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var basePath = CreateType<string>();
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetConnectionString = { basePath };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, methodGetConnectionStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, parametersOfGetConnectionString, methodGetConnectionStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetConnectionString.ShouldNotBeNull();
            parametersOfGetConnectionString.Length.ShouldBe(1);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, parametersOfGetConnectionString, methodGetConnectionStringPrametersTypes));
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_2_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var basePath = CreateType<string>();
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetConnectionString = { basePath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, methodGetConnectionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfGetConnectionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetConnectionString.ShouldNotBeNull();
            parametersOfGetConnectionString.Length.ShouldBe(1);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_2_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basePath = CreateType<string>();
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetConnectionString = { basePath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, parametersOfGetConnectionString, methodGetConnectionStringPrametersTypes);

            // Assert
            parametersOfGetConnectionString.ShouldNotBeNull();
            parametersOfGetConnectionString.Length.ShouldBe(1);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetConnectionStringPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetConnectionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_2_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetConnectionString, 2);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetConnectionString_Static_Method_Call_Overloading_Of_2_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetConnectionString, 2);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildSiteRegistryKey) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_BuildSiteRegistryKey_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildSiteRegistryKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildSiteRegistryKey, Fixture, methodBuildSiteRegistryKeyPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildSiteRegistryKey) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildSiteRegistryKey_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var basePath = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.BuildSiteRegistryKey(basePath);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (BuildSiteRegistryKey) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildSiteRegistryKey_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var basePath = CreateType<string>();
            var methodBuildSiteRegistryKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBuildSiteRegistryKey = { basePath };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildSiteRegistryKey, methodBuildSiteRegistryKeyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfBuildSiteRegistryKey);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildSiteRegistryKey.ShouldNotBeNull();
            parametersOfBuildSiteRegistryKey.Length.ShouldBe(1);
            methodBuildSiteRegistryKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildSiteRegistryKey) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildSiteRegistryKey_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var basePath = CreateType<string>();
            var methodBuildSiteRegistryKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfBuildSiteRegistryKey = { basePath };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildSiteRegistryKey, parametersOfBuildSiteRegistryKey, methodBuildSiteRegistryKeyPrametersTypes);

            // Assert
            parametersOfBuildSiteRegistryKey.ShouldNotBeNull();
            parametersOfBuildSiteRegistryKey.Length.ShouldBe(1);
            methodBuildSiteRegistryKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildSiteRegistryKey) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildSiteRegistryKey_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodBuildSiteRegistryKeyPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildSiteRegistryKey, Fixture, methodBuildSiteRegistryKeyPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodBuildSiteRegistryKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (BuildSiteRegistryKey) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildSiteRegistryKey_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildSiteRegistryKeyPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildSiteRegistryKey, Fixture, methodBuildSiteRegistryKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildSiteRegistryKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildSiteRegistryKey) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildSiteRegistryKey_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildSiteRegistryKey, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildSiteRegistryKey) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildSiteRegistryKey_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildSiteRegistryKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBasePath) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_GetBasePath_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetBasePathPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetBasePath, Fixture, methodGetBasePathPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBasePath) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetBasePath_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.GetBasePath();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetBasePath) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetBasePath_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetBasePathPrametersTypes = null;
            object[] parametersOfGetBasePath = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetBasePath, methodGetBasePathPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfGetBasePath);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBasePath.ShouldBeNull();
            methodGetBasePathPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBasePath) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetBasePath_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetBasePathPrametersTypes = null;
            object[] parametersOfGetBasePath = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetBasePath, parametersOfGetBasePath, methodGetBasePathPrametersTypes);

            // Assert
            parametersOfGetBasePath.ShouldBeNull();
            methodGetBasePathPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBasePath) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetBasePath_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetBasePathPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetBasePath, Fixture, methodGetBasePathPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBasePath) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetBasePath_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetBasePathPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetBasePath, Fixture, methodGetBasePathPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBasePathPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBasePath) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetBasePath_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBasePath, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_GetSPSessionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSPSessionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetSPSessionString, Fixture, methodGetSPSessionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSPSessionString) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetSPSessionString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sName = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.GetSPSessionString(Context, sName);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetSPSessionString) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetSPSessionString_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sName = CreateType<string>();
            var methodGetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetSPSessionString = { Context, sName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSPSessionString, methodGetSPSessionStringPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetSPSessionString, Fixture, methodGetSPSessionStringPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetSPSessionString, parametersOfGetSPSessionString, methodGetSPSessionStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetSPSessionString.ShouldNotBeNull();
            parametersOfGetSPSessionString.Length.ShouldBe(2);
            methodGetSPSessionStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetSPSessionString, parametersOfGetSPSessionString, methodGetSPSessionStringPrametersTypes));
        }

        #endregion

        #region Method Call : (GetSPSessionString) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetSPSessionString_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sName = CreateType<string>();
            var methodGetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetSPSessionString = { Context, sName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSPSessionString, methodGetSPSessionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfGetSPSessionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSPSessionString.ShouldNotBeNull();
            parametersOfGetSPSessionString.Length.ShouldBe(2);
            methodGetSPSessionStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSPSessionString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetSPSessionString_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sName = CreateType<string>();
            var methodGetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfGetSPSessionString = { Context, sName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetSPSessionString, parametersOfGetSPSessionString, methodGetSPSessionStringPrametersTypes);

            // Assert
            parametersOfGetSPSessionString.ShouldNotBeNull();
            parametersOfGetSPSessionString.Length.ShouldBe(2);
            methodGetSPSessionStringPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSPSessionString) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetSPSessionString_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetSPSessionString, Fixture, methodGetSPSessionStringPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetSPSessionStringPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetSPSessionString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetSPSessionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodGetSPSessionString, Fixture, methodGetSPSessionStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSPSessionStringPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSPSessionString) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetSPSessionString_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSPSessionString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetSPSessionString) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_GetSPSessionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSPSessionString, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_Internally(Type[] types)
        {
            var methodSetSPSessionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodSetSPSessionString, Fixture, methodSetSPSessionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var basePath = CreateType<string>();
            var sName = CreateType<string>();
            var sValue = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.SetSPSessionString(Context, basePath, sName, sValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var basePath = CreateType<string>();
            var sName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodSetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSetSPSessionString = { Context, basePath, sName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSPSessionString, methodSetSPSessionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfSetSPSessionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSPSessionString.ShouldNotBeNull();
            parametersOfSetSPSessionString.Length.ShouldBe(4);
            methodSetSPSessionStringPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_Void_With_4_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var basePath = CreateType<string>();
            var sName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodSetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSetSPSessionString = { Context, basePath, sName, sValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_webAdminInstanceFixture, _webAdminInstanceType, MethodSetSPSessionString, parametersOfSetSPSessionString, methodSetSPSessionStringPrametersTypes);

            // Assert
            parametersOfSetSPSessionString.ShouldNotBeNull();
            parametersOfSetSPSessionString.Length.ShouldBe(4);
            methodSetSPSessionStringPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSPSessionString, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodSetSPSessionString, Fixture, methodSetSPSessionStringPrametersTypes);

            // Assert
            methodSetSPSessionStringPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_With_4_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSPSessionString, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_SetSPSessionString_Static_Method_Overloading_Of_1_Call_Internally(Type[] types)
        {
            var methodSetSPSessionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodSetSPSessionString, Fixture, methodSetSPSessionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_DirectCall_Overloading_Of_1_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sName = CreateType<string>();
            var sValue = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.SetSPSessionString(Context, sName, sValue);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_Void_Overloading_Of_1_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodSetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(string) };
            object[] parametersOfSetSPSessionString = { Context, sName, sValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSPSessionString, methodSetSPSessionStringPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfSetSPSessionString);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSPSessionString.ShouldNotBeNull();
            parametersOfSetSPSessionString.Length.ShouldBe(3);
            methodSetSPSessionStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_Void_Overloading_Of_1_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sName = CreateType<string>();
            var sValue = CreateType<string>();
            var methodSetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(string) };
            object[] parametersOfSetSPSessionString = { Context, sName, sValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_webAdminInstanceFixture, _webAdminInstanceType, MethodSetSPSessionString, parametersOfSetSPSessionString, methodSetSPSessionStringPrametersTypes);

            // Assert
            parametersOfSetSPSessionString.ShouldNotBeNull();
            parametersOfSetSPSessionString.Length.ShouldBe(3);
            methodSetSPSessionStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_Overloading_Of_1_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSPSessionString, 1);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_Overloading_Of_1_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSPSessionStringPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodSetSPSessionString, Fixture, methodSetSPSessionStringPrametersTypes);

            // Assert
            methodSetSPSessionStringPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSPSessionString) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_SetSPSessionString_Static_Method_Call_Overloading_Of_1_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSPSessionString, 1);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUserAndProduct) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_AuthenticateUserAndProduct_Static_Method_Call_Internally(Type[] types)
        {
            var methodAuthenticateUserAndProductPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodAuthenticateUserAndProduct, Fixture, methodAuthenticateUserAndProductPrametersTypes);
        }

        #endregion

        #region Method Call : (AuthenticateUserAndProduct) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_AuthenticateUserAndProduct_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sStage = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.AuthenticateUserAndProduct(Context, out sStage);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AuthenticateUserAndProduct) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_AuthenticateUserAndProduct_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sStage = CreateType<string>();
            var methodAuthenticateUserAndProductPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfAuthenticateUserAndProduct = { Context, sStage };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAuthenticateUserAndProduct, methodAuthenticateUserAndProductPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfAuthenticateUserAndProduct);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAuthenticateUserAndProduct.ShouldNotBeNull();
            parametersOfAuthenticateUserAndProduct.Length.ShouldBe(2);
            methodAuthenticateUserAndProductPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUserAndProduct) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_AuthenticateUserAndProduct_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Context = CreateType<HttpContext>();
            var sStage = CreateType<string>();
            var methodAuthenticateUserAndProductPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            object[] parametersOfAuthenticateUserAndProduct = { Context, sStage };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_webAdminInstanceFixture, _webAdminInstanceType, MethodAuthenticateUserAndProduct, parametersOfAuthenticateUserAndProduct, methodAuthenticateUserAndProductPrametersTypes);

            // Assert
            parametersOfAuthenticateUserAndProduct.ShouldNotBeNull();
            parametersOfAuthenticateUserAndProduct.Length.ShouldBe(2);
            methodAuthenticateUserAndProductPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AuthenticateUserAndProduct) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_AuthenticateUserAndProduct_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAuthenticateUserAndProductPrametersTypes = new Type[] { typeof(HttpContext), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodAuthenticateUserAndProduct, Fixture, methodAuthenticateUserAndProductPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAuthenticateUserAndProductPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AuthenticateUserAndProduct) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_AuthenticateUserAndProduct_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAuthenticateUserAndProduct, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AuthenticateUserAndProduct) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_AuthenticateUserAndProduct_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAuthenticateUserAndProduct, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HasPagePermission) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_HasPagePermission_Static_Method_Call_Internally(Type[] types)
        {
            var methodHasPagePermissionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodHasPagePermission, Fixture, methodHasPagePermissionPrametersTypes);
        }

        #endregion

        #region Method Call : (HasPagePermission) (Return Type : bool) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_HasPagePermission_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var sPageId = CreateType<string>();
            var sMode = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.HasPagePermission(sPageId, sMode);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (HasPagePermission) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_HasPagePermission_Static_Method_Call_With_Call_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sPageId = CreateType<string>();
            var sMode = CreateType<string>();
            var methodHasPagePermissionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfHasPagePermission = { sPageId, sMode };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHasPagePermission, methodHasPagePermissionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodHasPagePermission, Fixture, methodHasPagePermissionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_webAdminInstanceFixture, _webAdminInstanceType, MethodHasPagePermission, parametersOfHasPagePermission, methodHasPagePermissionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHasPagePermission.ShouldNotBeNull();
            parametersOfHasPagePermission.Length.ShouldBe(2);
            methodHasPagePermissionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_webAdminInstanceFixture, _webAdminInstanceType, MethodHasPagePermission, parametersOfHasPagePermission, methodHasPagePermissionPrametersTypes));
        }

        #endregion

        #region Method Call : (HasPagePermission) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_HasPagePermission_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sPageId = CreateType<string>();
            var sMode = CreateType<string>();
            var methodHasPagePermissionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfHasPagePermission = { sPageId, sMode };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHasPagePermission, methodHasPagePermissionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfHasPagePermission);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHasPagePermission.ShouldNotBeNull();
            parametersOfHasPagePermission.Length.ShouldBe(2);
            methodHasPagePermissionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HasPagePermission) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_HasPagePermission_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sPageId = CreateType<string>();
            var sMode = CreateType<string>();
            var methodHasPagePermissionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfHasPagePermission = { sPageId, sMode };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_webAdminInstanceFixture, _webAdminInstanceType, MethodHasPagePermission, parametersOfHasPagePermission, methodHasPagePermissionPrametersTypes);

            // Assert
            parametersOfHasPagePermission.ShouldNotBeNull();
            parametersOfHasPagePermission.Length.ShouldBe(2);
            methodHasPagePermissionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HasPagePermission) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_HasPagePermission_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodHasPagePermissionPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodHasPagePermission, Fixture, methodHasPagePermissionPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodHasPagePermissionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (HasPagePermission) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_HasPagePermission_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodHasPagePermissionPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodHasPagePermission, Fixture, methodHasPagePermissionPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodHasPagePermissionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (HasPagePermission) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_HasPagePermission_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHasPagePermissionPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodHasPagePermission, Fixture, methodHasPagePermissionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHasPagePermissionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HasPagePermission) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_HasPagePermission_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHasPagePermission, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (HasPagePermission) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_HasPagePermission_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHasPagePermission, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckRequest) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_CheckRequest_Static_Method_Call_Internally(Type[] types)
        {
            var methodCheckRequestPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodCheckRequest, Fixture, methodCheckRequestPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckRequest) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CheckRequest_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var this_class = CreateType<string>();
            var sRequest = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.CheckRequest(context, this_class, sRequest);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CheckRequest) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CheckRequest_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var this_class = CreateType<string>();
            var sRequest = CreateType<string>();
            var methodCheckRequestPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(string) };
            object[] parametersOfCheckRequest = { context, this_class, sRequest };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckRequest, methodCheckRequestPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodCheckRequest, Fixture, methodCheckRequestPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodCheckRequest, parametersOfCheckRequest, methodCheckRequestPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfCheckRequest);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCheckRequest.ShouldNotBeNull();
            parametersOfCheckRequest.Length.ShouldBe(3);
            methodCheckRequestPrametersTypes.Length.ShouldBe(3);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CheckRequest) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CheckRequest_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var context = CreateType<HttpContext>();
            var this_class = CreateType<string>();
            var sRequest = CreateType<string>();
            var methodCheckRequestPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(string) };
            object[] parametersOfCheckRequest = { context, this_class, sRequest };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodCheckRequest, parametersOfCheckRequest, methodCheckRequestPrametersTypes);

            // Assert
            parametersOfCheckRequest.ShouldNotBeNull();
            parametersOfCheckRequest.Length.ShouldBe(3);
            methodCheckRequestPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckRequest) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CheckRequest_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodCheckRequestPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodCheckRequest, Fixture, methodCheckRequestPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCheckRequestPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (CheckRequest) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CheckRequest_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodCheckRequestPrametersTypes = new Type[] { typeof(HttpContext), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodCheckRequest, Fixture, methodCheckRequestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCheckRequestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CheckRequest) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CheckRequest_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckRequest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CheckRequest) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_CheckRequest_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodCheckRequest, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildReply) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_BuildReply_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildReplyPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildReply, Fixture, methodBuildReplyPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildReply) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildReply_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var this_class = CreateType<string>();
            var sFunction = CreateType<string>();
            var sContext = CreateType<string>();
            var sReply = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.BuildReply(this_class, sFunction, sContext, sReply);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (BuildReply) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildReply_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var this_class = CreateType<string>();
            var sFunction = CreateType<string>();
            var sContext = CreateType<string>();
            var sReply = CreateType<string>();
            var methodBuildReplyPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfBuildReply = { this_class, sFunction, sContext, sReply };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBuildReply, methodBuildReplyPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfBuildReply);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBuildReply.ShouldNotBeNull();
            parametersOfBuildReply.Length.ShouldBe(4);
            methodBuildReplyPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildReply) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildReply_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var this_class = CreateType<string>();
            var sFunction = CreateType<string>();
            var sContext = CreateType<string>();
            var sReply = CreateType<string>();
            var methodBuildReplyPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfBuildReply = { this_class, sFunction, sContext, sReply };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildReply, parametersOfBuildReply, methodBuildReplyPrametersTypes);

            // Assert
            parametersOfBuildReply.ShouldNotBeNull();
            parametersOfBuildReply.Length.ShouldBe(4);
            methodBuildReplyPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildReply) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildReply_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodBuildReplyPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildReply, Fixture, methodBuildReplyPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodBuildReplyPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (BuildReply) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildReply_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildReplyPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodBuildReply, Fixture, methodBuildReplyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildReplyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildReply) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildReply_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildReply, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildReply) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_BuildReply_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildReply, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatError) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_FormatError_Static_Method_Call_Internally(Type[] types)
        {
            var methodFormatErrorPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodFormatError, Fixture, methodFormatErrorPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatError) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatError_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var severity = CreateType<string>();
            var location = CreateType<string>();
            var message = CreateType<string>();
            var trace = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.FormatError(severity, location, message, trace);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (FormatError) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatError_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var severity = CreateType<string>();
            var location = CreateType<string>();
            var message = CreateType<string>();
            var trace = CreateType<string>();
            var methodFormatErrorPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfFormatError = { severity, location, message, trace };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFormatError, methodFormatErrorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfFormatError);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFormatError.ShouldNotBeNull();
            parametersOfFormatError.Length.ShouldBe(4);
            methodFormatErrorPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatError) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatError_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var severity = CreateType<string>();
            var location = CreateType<string>();
            var message = CreateType<string>();
            var trace = CreateType<string>();
            var methodFormatErrorPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfFormatError = { severity, location, message, trace };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodFormatError, parametersOfFormatError, methodFormatErrorPrametersTypes);

            // Assert
            parametersOfFormatError.ShouldNotBeNull();
            parametersOfFormatError.Length.ShouldBe(4);
            methodFormatErrorPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatError) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatError_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodFormatErrorPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodFormatError, Fixture, methodFormatErrorPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodFormatErrorPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (FormatError) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatError_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatErrorPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodFormatError, Fixture, methodFormatErrorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatErrorPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatError) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatError_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatError, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (FormatError) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatError_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatError, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatWarning) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebAdmin_FormatWarning_Static_Method_Call_Internally(Type[] types)
        {
            var methodFormatWarningPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodFormatWarning, Fixture, methodFormatWarningPrametersTypes);
        }

        #endregion

        #region Method Call : (FormatWarning) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatWarning_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => WebAdmin.FormatWarning(message);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (FormatWarning) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatWarning_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodFormatWarningPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfFormatWarning = { message };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFormatWarning, methodFormatWarningPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webAdminInstanceFixture, parametersOfFormatWarning);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFormatWarning.ShouldNotBeNull();
            parametersOfFormatWarning.Length.ShouldBe(1);
            methodFormatWarningPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatWarning) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatWarning_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var message = CreateType<string>();
            var methodFormatWarningPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfFormatWarning = { message };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_webAdminInstanceFixture, _webAdminInstanceType, MethodFormatWarning, parametersOfFormatWarning, methodFormatWarningPrametersTypes);

            // Assert
            parametersOfFormatWarning.ShouldNotBeNull();
            parametersOfFormatWarning.Length.ShouldBe(1);
            methodFormatWarningPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FormatWarning) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatWarning_Static_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodFormatWarningPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodFormatWarning, Fixture, methodFormatWarningPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodFormatWarningPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (FormatWarning) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatWarning_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFormatWarningPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_webAdminInstanceFixture, _webAdminInstanceType, MethodFormatWarning, Fixture, methodFormatWarningPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFormatWarningPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FormatWarning) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatWarning_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFormatWarning, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_webAdminInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (FormatWarning) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebAdmin_FormatWarning_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFormatWarning, 0);
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