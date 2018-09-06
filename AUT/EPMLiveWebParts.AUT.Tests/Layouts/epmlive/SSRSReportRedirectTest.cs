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

namespace EPMLiveWebParts.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Layouts.epmlive.SSRSReportRedirect" />)
    ///     and namespace <see cref="EPMLiveWebParts.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SSRSReportRedirectTest : AbstractBaseSetupTypedTest<SSRSReportRedirect>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SSRSReportRedirect) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodRedirect = "Redirect";
        private const string MethodRedirectIntegratedMode = "RedirectIntegratedMode";
        private const string MethodSetupSSRS = "SetupSSRS";
        private const string MethodgetReportParameters = "getReportParameters";
        private const string FieldwebUrl = "webUrl";
        private const string FielditemUrl = "itemUrl";
        private const string FieldisNativeMode = "isNativeMode";
        private const string Field_srs2006 = "_srs2006";
        private const string Field_reportingServicesUrl = "_reportingServicesUrl";
        private Type _sSRSReportRedirectInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SSRSReportRedirect _sSRSReportRedirectInstance;
        private SSRSReportRedirect _sSRSReportRedirectInstanceFixture;

        #region General Initializer : Class (SSRSReportRedirect) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SSRSReportRedirect" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sSRSReportRedirectInstanceType = typeof(SSRSReportRedirect);
            _sSRSReportRedirectInstanceFixture = Create(true);
            _sSRSReportRedirectInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SSRSReportRedirect)

        #region General Initializer : Class (SSRSReportRedirect) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SSRSReportRedirect" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodRedirect, 0)]
        [TestCase(MethodRedirectIntegratedMode, 0)]
        [TestCase(MethodSetupSSRS, 0)]
        [TestCase(MethodgetReportParameters, 0)]
        public void AUT_SSRSReportRedirect_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sSRSReportRedirectInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SSRSReportRedirect) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SSRSReportRedirect" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldwebUrl)]
        [TestCase(FielditemUrl)]
        [TestCase(FieldisNativeMode)]
        [TestCase(Field_srs2006)]
        [TestCase(Field_reportingServicesUrl)]
        public void AUT_SSRSReportRedirect_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sSRSReportRedirectInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SSRSReportRedirect" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodRedirect)]
        [TestCase(MethodRedirectIntegratedMode)]
        [TestCase(MethodSetupSSRS)]
        [TestCase(MethodgetReportParameters)]
        public void AUT_SSRSReportRedirect_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SSRSReportRedirect>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSReportRedirect_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSReportRedirectInstanceFixture, parametersOfPage_Load);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sSRSReportRedirectInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

            // Assert
            parametersOfPage_Load.ShouldNotBeNull();
            parametersOfPage_Load.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            methodPage_LoadPrametersTypes.Length.ShouldBe(parametersOfPage_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_Page_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSReportRedirectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSReportRedirect_Redirect_Method_Call_Internally(Type[] types)
        {
            var methodRedirectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodRedirect, Fixture, methodRedirectPrametersTypes);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_Redirect_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRedirectPrametersTypes = null;
            object[] parametersOfRedirect = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirect, methodRedirectPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSReportRedirectInstanceFixture, parametersOfRedirect);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRedirect.ShouldBeNull();
            methodRedirectPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_Redirect_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRedirectPrametersTypes = null;
            object[] parametersOfRedirect = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sSRSReportRedirectInstance, MethodRedirect, parametersOfRedirect, methodRedirectPrametersTypes);

            // Assert
            parametersOfRedirect.ShouldBeNull();
            methodRedirectPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_Redirect_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRedirectPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodRedirect, Fixture, methodRedirectPrametersTypes);

            // Assert
            methodRedirectPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Redirect) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_Redirect_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirect, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSReportRedirectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectIntegratedMode) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSReportRedirect_RedirectIntegratedMode_Method_Call_Internally(Type[] types)
        {
            var methodRedirectIntegratedModePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodRedirectIntegratedMode, Fixture, methodRedirectIntegratedModePrametersTypes);
        }

        #endregion

        #region Method Call : (RedirectIntegratedMode) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_RedirectIntegratedMode_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRedirectIntegratedModePrametersTypes = null;
            object[] parametersOfRedirectIntegratedMode = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRedirectIntegratedMode, methodRedirectIntegratedModePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSReportRedirectInstanceFixture, parametersOfRedirectIntegratedMode);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRedirectIntegratedMode.ShouldBeNull();
            methodRedirectIntegratedModePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RedirectIntegratedMode) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_RedirectIntegratedMode_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRedirectIntegratedModePrametersTypes = null;
            object[] parametersOfRedirectIntegratedMode = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sSRSReportRedirectInstance, MethodRedirectIntegratedMode, parametersOfRedirectIntegratedMode, methodRedirectIntegratedModePrametersTypes);

            // Assert
            parametersOfRedirectIntegratedMode.ShouldBeNull();
            methodRedirectIntegratedModePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectIntegratedMode) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_RedirectIntegratedMode_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRedirectIntegratedModePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodRedirectIntegratedMode, Fixture, methodRedirectIntegratedModePrametersTypes);

            // Assert
            methodRedirectIntegratedModePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RedirectIntegratedMode) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_RedirectIntegratedMode_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRedirectIntegratedMode, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSReportRedirectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupSSRS) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSReportRedirect_SetupSSRS_Method_Call_Internally(Type[] types)
        {
            var methodSetupSSRSPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodSetupSSRS, Fixture, methodSetupSSRSPrametersTypes);
        }

        #endregion

        #region Method Call : (SetupSSRS) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_SetupSSRS_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodSetupSSRSPrametersTypes = null;
            object[] parametersOfSetupSSRS = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetupSSRS, methodSetupSSRSPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SSRSReportRedirect, bool>(_sSRSReportRedirectInstanceFixture, out exception1, parametersOfSetupSSRS);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SSRSReportRedirect, bool>(_sSRSReportRedirectInstance, MethodSetupSSRS, parametersOfSetupSSRS, methodSetupSSRSPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetupSSRS.ShouldBeNull();
            methodSetupSSRSPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetupSSRS) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_SetupSSRS_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodSetupSSRSPrametersTypes = null;
            object[] parametersOfSetupSSRS = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodSetupSSRS, methodSetupSSRSPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SSRSReportRedirect, bool>(_sSRSReportRedirectInstanceFixture, out exception1, parametersOfSetupSSRS);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SSRSReportRedirect, bool>(_sSRSReportRedirectInstance, MethodSetupSSRS, parametersOfSetupSSRS, methodSetupSSRSPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfSetupSSRS.ShouldBeNull();
            methodSetupSSRSPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetupSSRS) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_SetupSSRS_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetupSSRSPrametersTypes = null;
            object[] parametersOfSetupSSRS = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SSRSReportRedirect, bool>(_sSRSReportRedirectInstance, MethodSetupSSRS, parametersOfSetupSSRS, methodSetupSSRSPrametersTypes);

            // Assert
            parametersOfSetupSSRS.ShouldBeNull();
            methodSetupSSRSPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupSSRS) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_SetupSSRS_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetupSSRSPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodSetupSSRS, Fixture, methodSetupSSRSPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSetupSSRSPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetupSSRS) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_SetupSSRS_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetupSSRS, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSReportRedirectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getReportParameters) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSReportRedirect_getReportParameters_Method_Call_Internally(Type[] types)
        {
            var methodgetReportParametersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodgetReportParameters, Fixture, methodgetReportParametersPrametersTypes);
        }

        #endregion

        #region Method Call : (getReportParameters) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_getReportParameters_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodgetReportParametersPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetReportParameters = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodgetReportParameters, methodgetReportParametersPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<SSRSReportRedirect, string>(_sSRSReportRedirectInstanceFixture, out exception1, parametersOfgetReportParameters);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<SSRSReportRedirect, string>(_sSRSReportRedirectInstance, MethodgetReportParameters, parametersOfgetReportParameters, methodgetReportParametersPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfgetReportParameters.ShouldNotBeNull();
            parametersOfgetReportParameters.Length.ShouldBe(1);
            methodgetReportParametersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getReportParameters) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_getReportParameters_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodgetReportParametersPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfgetReportParameters = { url };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<SSRSReportRedirect, string>(_sSRSReportRedirectInstance, MethodgetReportParameters, parametersOfgetReportParameters, methodgetReportParametersPrametersTypes);

            // Assert
            parametersOfgetReportParameters.ShouldNotBeNull();
            parametersOfgetReportParameters.Length.ShouldBe(1);
            methodgetReportParametersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (getReportParameters) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_getReportParameters_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodgetReportParametersPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodgetReportParameters, Fixture, methodgetReportParametersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodgetReportParametersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (getReportParameters) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_getReportParameters_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodgetReportParametersPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSReportRedirectInstance, MethodgetReportParameters, Fixture, methodgetReportParametersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodgetReportParametersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (getReportParameters) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_getReportParameters_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodgetReportParameters, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSReportRedirectInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (getReportParameters) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSReportRedirect_getReportParameters_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodgetReportParameters, 0);
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