using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveCore.SSRS2010;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.Layouts.epmlive
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Layouts.epmlive.SSRSNativeReportViewer" />)
    ///     and namespace <see cref="EPMLiveWebParts.Layouts.epmlive"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SSRSNativeReportViewerTest : AbstractBaseSetupTypedTest<SSRSNativeReportViewer>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SSRSNativeReportViewer) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodGetRegs = "GetRegs";
        private const string MethodGetSubscription = "GetSubscription";
        private const string MethodGetSubscriptions = "GetSubscriptions";
        private const string MethodGetDeliveryExtensions = "GetDeliveryExtensions";
        private const string MethodGetReportParameters = "GetReportParameters";
        private const string MethodSaveSubscription = "SaveSubscription";
        private const string MethodGetExtensionSettings = "GetExtensionSettings";
        private const string MethodGetParameterValueList = "GetParameterValueList";
        private const string MethodEnableDisableSubscription = "EnableDisableSubscription";
        private const string MethodDeleteSubscription = "DeleteSubscription";
        private const string MethodDataSetToJSON = "DataSetToJSON";
        private const string FieldwebUrl = "webUrl";
        private const string FielditemUrl = "itemUrl";
        private const string FieldisNativeMode = "isNativeMode";
        private const string Field_reportingServicesUrl = "_reportingServicesUrl";
        private Type _sSRSNativeReportViewerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SSRSNativeReportViewer _sSRSNativeReportViewerInstance;
        private SSRSNativeReportViewer _sSRSNativeReportViewerInstanceFixture;

        #region General Initializer : Class (SSRSNativeReportViewer) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SSRSNativeReportViewer" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sSRSNativeReportViewerInstanceType = typeof(SSRSNativeReportViewer);
            _sSRSNativeReportViewerInstanceFixture = Create(true);
            _sSRSNativeReportViewerInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SSRSNativeReportViewer)

        #region General Initializer : Class (SSRSNativeReportViewer) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SSRSNativeReportViewer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodGetRegs, 0)]
        [TestCase(MethodGetSubscription, 0)]
        [TestCase(MethodGetSubscriptions, 0)]
        [TestCase(MethodGetDeliveryExtensions, 0)]
        [TestCase(MethodGetReportParameters, 0)]
        [TestCase(MethodSaveSubscription, 0)]
        [TestCase(MethodGetExtensionSettings, 0)]
        [TestCase(MethodGetParameterValueList, 0)]
        [TestCase(MethodEnableDisableSubscription, 0)]
        [TestCase(MethodDeleteSubscription, 0)]
        [TestCase(MethodDataSetToJSON, 0)]
        public void AUT_SSRSNativeReportViewer_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_sSRSNativeReportViewerInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SSRSNativeReportViewer) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SSRSNativeReportViewer" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldwebUrl)]
        [TestCase(FielditemUrl)]
        [TestCase(FieldisNativeMode)]
        [TestCase(Field_reportingServicesUrl)]
        public void AUT_SSRSNativeReportViewer_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sSRSNativeReportViewerInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="SSRSNativeReportViewer" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetRegs)]
        [TestCase(MethodGetSubscription)]
        [TestCase(MethodGetSubscriptions)]
        [TestCase(MethodGetDeliveryExtensions)]
        [TestCase(MethodGetReportParameters)]
        [TestCase(MethodSaveSubscription)]
        [TestCase(MethodGetExtensionSettings)]
        [TestCase(MethodGetParameterValueList)]
        [TestCase(MethodEnableDisableSubscription)]
        [TestCase(MethodDeleteSubscription)]
        [TestCase(MethodDataSetToJSON)]
        public void AUT_SSRSNativeReportViewer_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_sSRSNativeReportViewerInstanceFixture,
                                                                              _sSRSNativeReportViewerInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SSRSNativeReportViewer" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        public void AUT_SSRSNativeReportViewer_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SSRSNativeReportViewer>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfPage_Load);

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
        public void AUT_SSRSNativeReportViewer_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_sSRSNativeReportViewerInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_SSRSNativeReportViewer_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_SSRSNativeReportViewer_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRegs) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_GetRegs_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetRegsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetRegs, Fixture, methodGetRegsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetRegs) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetRegs_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => SSRSNativeReportViewer.GetRegs();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetRegs) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetRegs_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetRegsPrametersTypes = null;
            object[] parametersOfGetRegs = null; // no parameter present
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRegs, methodGetRegsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetRegs, Fixture, methodGetRegsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetRegs, parametersOfGetRegs, methodGetRegsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfGetRegs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetRegs.ShouldBeNull();
            methodGetRegsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetRegs) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetRegs_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetRegsPrametersTypes = null;
            object[] parametersOfGetRegs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetRegs, parametersOfGetRegs, methodGetRegsPrametersTypes);

            // Assert
            parametersOfGetRegs.ShouldBeNull();
            methodGetRegsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetRegs) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetRegs_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetRegsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetRegs, Fixture, methodGetRegsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetRegsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRegs) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetRegs_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetRegsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetRegs, Fixture, methodGetRegsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetRegsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetRegs) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetRegs_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetRegs, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubscription) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_GetSubscription_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSubscriptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscription, Fixture, methodGetSubscriptionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSubscription) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscription_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var subsID = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => SSRSNativeReportViewer.GetSubscription(subsID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSubscription) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscription_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var subsID = CreateType<string>();
            var methodGetSubscriptionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSubscription = { subsID };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSubscription, methodGetSubscriptionPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscription, Fixture, methodGetSubscriptionPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscription, parametersOfGetSubscription, methodGetSubscriptionPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfGetSubscription);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSubscription.ShouldNotBeNull();
            parametersOfGetSubscription.Length.ShouldBe(1);
            methodGetSubscriptionPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSubscription) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscription_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var subsID = CreateType<string>();
            var methodGetSubscriptionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSubscription = { subsID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscription, parametersOfGetSubscription, methodGetSubscriptionPrametersTypes);

            // Assert
            parametersOfGetSubscription.ShouldNotBeNull();
            parametersOfGetSubscription.Length.ShouldBe(1);
            methodGetSubscriptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSubscription) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscription_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSubscriptionPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscription, Fixture, methodGetSubscriptionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSubscriptionPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSubscription) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscription_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSubscriptionPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscription, Fixture, methodGetSubscriptionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSubscriptionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSubscription) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscription_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSubscription, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubscription) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscription_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSubscription, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSubscriptions) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_GetSubscriptions_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetSubscriptionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscriptions, Fixture, methodGetSubscriptionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSubscriptions) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscriptions_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => SSRSNativeReportViewer.GetSubscriptions();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetSubscriptions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscriptions_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSubscriptionsPrametersTypes = null;
            object[] parametersOfGetSubscriptions = null; // no parameter present
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSubscriptions, methodGetSubscriptionsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscriptions, Fixture, methodGetSubscriptionsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscriptions, parametersOfGetSubscriptions, methodGetSubscriptionsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfGetSubscriptions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSubscriptions.ShouldBeNull();
            methodGetSubscriptionsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSubscriptions) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscriptions_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSubscriptionsPrametersTypes = null;
            object[] parametersOfGetSubscriptions = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscriptions, parametersOfGetSubscriptions, methodGetSubscriptionsPrametersTypes);

            // Assert
            parametersOfGetSubscriptions.ShouldBeNull();
            methodGetSubscriptionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSubscriptions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscriptions_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSubscriptionsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscriptions, Fixture, methodGetSubscriptionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSubscriptionsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubscriptions) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscriptions_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSubscriptionsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetSubscriptions, Fixture, methodGetSubscriptionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSubscriptionsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSubscriptions) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetSubscriptions_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSubscriptions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDeliveryExtensions) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_GetDeliveryExtensions_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDeliveryExtensionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetDeliveryExtensions, Fixture, methodGetDeliveryExtensionsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDeliveryExtensions) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetDeliveryExtensions_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => SSRSNativeReportViewer.GetDeliveryExtensions();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetDeliveryExtensions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetDeliveryExtensions_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDeliveryExtensionsPrametersTypes = null;
            object[] parametersOfGetDeliveryExtensions = null; // no parameter present
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDeliveryExtensions, methodGetDeliveryExtensionsPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetDeliveryExtensions, Fixture, methodGetDeliveryExtensionsPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetDeliveryExtensions, parametersOfGetDeliveryExtensions, methodGetDeliveryExtensionsPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfGetDeliveryExtensions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetDeliveryExtensions.ShouldBeNull();
            methodGetDeliveryExtensionsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetDeliveryExtensions) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetDeliveryExtensions_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetDeliveryExtensionsPrametersTypes = null;
            object[] parametersOfGetDeliveryExtensions = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetDeliveryExtensions, parametersOfGetDeliveryExtensions, methodGetDeliveryExtensionsPrametersTypes);

            // Assert
            parametersOfGetDeliveryExtensions.ShouldBeNull();
            methodGetDeliveryExtensionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDeliveryExtensions) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetDeliveryExtensions_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetDeliveryExtensionsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetDeliveryExtensions, Fixture, methodGetDeliveryExtensionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDeliveryExtensionsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDeliveryExtensions) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetDeliveryExtensions_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetDeliveryExtensionsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetDeliveryExtensions, Fixture, methodGetDeliveryExtensionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDeliveryExtensionsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetDeliveryExtensions) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetDeliveryExtensions_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetDeliveryExtensions, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportParameters) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_GetReportParameters_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetReportParametersPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetReportParameters, Fixture, methodGetReportParametersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetReportParameters) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetReportParameters_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => SSRSNativeReportViewer.GetReportParameters();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetReportParameters) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetReportParameters_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetReportParametersPrametersTypes = null;
            object[] parametersOfGetReportParameters = null; // no parameter present
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportParameters, methodGetReportParametersPrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetReportParameters, Fixture, methodGetReportParametersPrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetReportParameters, parametersOfGetReportParameters, methodGetReportParametersPrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfGetReportParameters);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetReportParameters.ShouldBeNull();
            methodGetReportParametersPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetReportParameters) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetReportParameters_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetReportParametersPrametersTypes = null;
            object[] parametersOfGetReportParameters = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetReportParameters, parametersOfGetReportParameters, methodGetReportParametersPrametersTypes);

            // Assert
            parametersOfGetReportParameters.ShouldBeNull();
            methodGetReportParametersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetReportParameters) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetReportParameters_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetReportParametersPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetReportParameters, Fixture, methodGetReportParametersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetReportParametersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportParameters) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetReportParameters_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetReportParametersPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetReportParameters, Fixture, methodGetReportParametersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetReportParametersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetReportParameters) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetReportParameters_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetReportParameters, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SaveSubscription) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_SaveSubscription_Static_Method_Call_Internally(Type[] types)
        {
            var methodSaveSubscriptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodSaveSubscription, Fixture, methodSaveSubscriptionPrametersTypes);
        }

        #endregion

        #region Method Call : (SaveSubscription) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_SaveSubscription_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var description = CreateType<string>();
            var deliveryMethod = CreateType<string>();
            var deliveryParams = CreateType<string>();
            var matchData = CreateType<string>();
            var reportParametersList = CreateType<string>();
            var subsID = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => SSRSNativeReportViewer.SaveSubscription(description, deliveryMethod, deliveryParams, matchData, reportParametersList, subsID);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SaveSubscription) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_SaveSubscription_Static_Method_Call_Void_With_6_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var description = CreateType<string>();
            var deliveryMethod = CreateType<string>();
            var deliveryParams = CreateType<string>();
            var matchData = CreateType<string>();
            var reportParametersList = CreateType<string>();
            var subsID = CreateType<string>();
            var methodSaveSubscriptionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSaveSubscription = { description, deliveryMethod, deliveryParams, matchData, reportParametersList, subsID };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSaveSubscription, methodSaveSubscriptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfSaveSubscription);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSaveSubscription.ShouldNotBeNull();
            parametersOfSaveSubscription.Length.ShouldBe(6);
            methodSaveSubscriptionPrametersTypes.Length.ShouldBe(6);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SaveSubscription) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_SaveSubscription_Static_Method_Call_Void_With_6_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var description = CreateType<string>();
            var deliveryMethod = CreateType<string>();
            var deliveryParams = CreateType<string>();
            var matchData = CreateType<string>();
            var reportParametersList = CreateType<string>();
            var subsID = CreateType<string>();
            var methodSaveSubscriptionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfSaveSubscription = { description, deliveryMethod, deliveryParams, matchData, reportParametersList, subsID };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodSaveSubscription, parametersOfSaveSubscription, methodSaveSubscriptionPrametersTypes);

            // Assert
            parametersOfSaveSubscription.ShouldNotBeNull();
            parametersOfSaveSubscription.Length.ShouldBe(6);
            methodSaveSubscriptionPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveSubscription) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_SaveSubscription_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSaveSubscription, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SaveSubscription) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_SaveSubscription_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSaveSubscriptionPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodSaveSubscription, Fixture, methodSaveSubscriptionPrametersTypes);

            // Assert
            methodSaveSubscriptionPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SaveSubscription) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_SaveSubscription_Static_Method_Call_With_6_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSaveSubscription, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExtensionSettings) (Return Type : ExtensionSettings) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_GetExtensionSettings_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetExtensionSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetExtensionSettings, Fixture, methodGetExtensionSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetExtensionSettings) (Return Type : ExtensionSettings) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetExtensionSettings_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var deliveryParams = CreateType<string>();
            var deliveryMethod = CreateType<string>();
            var methodGetExtensionSettingsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetExtensionSettings = { deliveryParams, deliveryMethod };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetExtensionSettings, methodGetExtensionSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfGetExtensionSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetExtensionSettings.ShouldNotBeNull();
            parametersOfGetExtensionSettings.Length.ShouldBe(2);
            methodGetExtensionSettingsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExtensionSettings) (Return Type : ExtensionSettings) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetExtensionSettings_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var deliveryParams = CreateType<string>();
            var deliveryMethod = CreateType<string>();
            var methodGetExtensionSettingsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetExtensionSettings = { deliveryParams, deliveryMethod };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<ExtensionSettings>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetExtensionSettings, parametersOfGetExtensionSettings, methodGetExtensionSettingsPrametersTypes);

            // Assert
            parametersOfGetExtensionSettings.ShouldNotBeNull();
            parametersOfGetExtensionSettings.Length.ShouldBe(2);
            methodGetExtensionSettingsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetExtensionSettings) (Return Type : ExtensionSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetExtensionSettings_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetExtensionSettingsPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetExtensionSettings, Fixture, methodGetExtensionSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetExtensionSettingsPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetExtensionSettings) (Return Type : ExtensionSettings) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetExtensionSettings_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetExtensionSettingsPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetExtensionSettings, Fixture, methodGetExtensionSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetExtensionSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetExtensionSettings) (Return Type : ExtensionSettings) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetExtensionSettings_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetExtensionSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetExtensionSettings) (Return Type : ExtensionSettings) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetExtensionSettings_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetExtensionSettings, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParameterValueList) (Return Type : ParameterValue[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_GetParameterValueList_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetParameterValueListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetParameterValueList, Fixture, methodGetParameterValueListPrametersTypes);
        }

        #endregion

        #region Method Call : (GetParameterValueList) (Return Type : ParameterValue[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetParameterValueList_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var reportParams = CreateType<string>();
            var methodGetParameterValueListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetParameterValueList = { reportParams };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetParameterValueList, methodGetParameterValueListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfGetParameterValueList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetParameterValueList.ShouldNotBeNull();
            parametersOfGetParameterValueList.Length.ShouldBe(1);
            methodGetParameterValueListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParameterValueList) (Return Type : ParameterValue[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetParameterValueList_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var reportParams = CreateType<string>();
            var methodGetParameterValueListPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetParameterValueList = { reportParams };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<ParameterValue[]>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetParameterValueList, parametersOfGetParameterValueList, methodGetParameterValueListPrametersTypes);

            // Assert
            parametersOfGetParameterValueList.ShouldNotBeNull();
            parametersOfGetParameterValueList.Length.ShouldBe(1);
            methodGetParameterValueListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetParameterValueList) (Return Type : ParameterValue[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetParameterValueList_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetParameterValueListPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetParameterValueList, Fixture, methodGetParameterValueListPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetParameterValueListPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetParameterValueList) (Return Type : ParameterValue[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetParameterValueList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetParameterValueListPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodGetParameterValueList, Fixture, methodGetParameterValueListPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetParameterValueListPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetParameterValueList) (Return Type : ParameterValue[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetParameterValueList_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetParameterValueList, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetParameterValueList) (Return Type : ParameterValue[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_GetParameterValueList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetParameterValueList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableDisableSubscription) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_EnableDisableSubscription_Static_Method_Call_Internally(Type[] types)
        {
            var methodEnableDisableSubscriptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodEnableDisableSubscription, Fixture, methodEnableDisableSubscriptionPrametersTypes);
        }

        #endregion

        #region Method Call : (EnableDisableSubscription) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_EnableDisableSubscription_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var subsIdList = CreateType<string>();
            var enable = CreateType<bool>();
            Action executeAction = null;

            // Act
            executeAction = () => SSRSNativeReportViewer.EnableDisableSubscription(subsIdList, enable);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (EnableDisableSubscription) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_EnableDisableSubscription_Static_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var subsIdList = CreateType<string>();
            var enable = CreateType<bool>();
            var methodEnableDisableSubscriptionPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfEnableDisableSubscription = { subsIdList, enable };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodEnableDisableSubscription, methodEnableDisableSubscriptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfEnableDisableSubscription);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfEnableDisableSubscription.ShouldNotBeNull();
            parametersOfEnableDisableSubscription.Length.ShouldBe(2);
            methodEnableDisableSubscriptionPrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (EnableDisableSubscription) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_EnableDisableSubscription_Static_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var subsIdList = CreateType<string>();
            var enable = CreateType<bool>();
            var methodEnableDisableSubscriptionPrametersTypes = new Type[] { typeof(string), typeof(bool) };
            object[] parametersOfEnableDisableSubscription = { subsIdList, enable };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodEnableDisableSubscription, parametersOfEnableDisableSubscription, methodEnableDisableSubscriptionPrametersTypes);

            // Assert
            parametersOfEnableDisableSubscription.ShouldNotBeNull();
            parametersOfEnableDisableSubscription.Length.ShouldBe(2);
            methodEnableDisableSubscriptionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableDisableSubscription) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_EnableDisableSubscription_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodEnableDisableSubscription, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (EnableDisableSubscription) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_EnableDisableSubscription_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodEnableDisableSubscriptionPrametersTypes = new Type[] { typeof(string), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodEnableDisableSubscription, Fixture, methodEnableDisableSubscriptionPrametersTypes);

            // Assert
            methodEnableDisableSubscriptionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (EnableDisableSubscription) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_EnableDisableSubscription_Static_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodEnableDisableSubscription, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_DeleteSubscription_Static_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSubscriptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodDeleteSubscription, Fixture, methodDeleteSubscriptionPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DeleteSubscription_Static_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var subsIdList = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => SSRSNativeReportViewer.DeleteSubscription(subsIdList);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DeleteSubscription_Static_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var subsIdList = CreateType<string>();
            var methodDeleteSubscriptionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteSubscription = { subsIdList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDeleteSubscription, methodDeleteSubscriptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfDeleteSubscription);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDeleteSubscription.ShouldNotBeNull();
            parametersOfDeleteSubscription.Length.ShouldBe(1);
            methodDeleteSubscriptionPrametersTypes.Length.ShouldBe(1);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DeleteSubscription_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var subsIdList = CreateType<string>();
            var methodDeleteSubscriptionPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfDeleteSubscription = { subsIdList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodDeleteSubscription, parametersOfDeleteSubscription, methodDeleteSubscriptionPrametersTypes);

            // Assert
            parametersOfDeleteSubscription.ShouldNotBeNull();
            parametersOfDeleteSubscription.Length.ShouldBe(1);
            methodDeleteSubscriptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DeleteSubscription_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDeleteSubscription, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DeleteSubscription_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDeleteSubscriptionPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodDeleteSubscription, Fixture, methodDeleteSubscriptionPrametersTypes);

            // Assert
            methodDeleteSubscriptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DeleteSubscription) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DeleteSubscription_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDeleteSubscription, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_sSRSNativeReportViewerInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DataSetToJSON) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SSRSNativeReportViewer_DataSetToJSON_Static_Method_Call_Internally(Type[] types)
        {
            var methodDataSetToJSONPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodDataSetToJSON, Fixture, methodDataSetToJSONPrametersTypes);
        }

        #endregion

        #region Method Call : (DataSetToJSON) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DataSetToJSON_Static_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var ds = CreateType<DataSet>();
            Action executeAction = null;

            // Act
            executeAction = () => SSRSNativeReportViewer.DataSetToJSON(ds);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DataSetToJSON) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DataSetToJSON_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var ds = CreateType<DataSet>();
            var methodDataSetToJSONPrametersTypes = new Type[] { typeof(DataSet) };
            object[] parametersOfDataSetToJSON = { ds };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDataSetToJSON, methodDataSetToJSONPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_sSRSNativeReportViewerInstanceFixture, parametersOfDataSetToJSON);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDataSetToJSON.ShouldNotBeNull();
            parametersOfDataSetToJSON.Length.ShouldBe(1);
            methodDataSetToJSONPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DataSetToJSON) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DataSetToJSON_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ds = CreateType<DataSet>();
            var methodDataSetToJSONPrametersTypes = new Type[] { typeof(DataSet) };
            object[] parametersOfDataSetToJSON = { ds };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodDataSetToJSON, parametersOfDataSetToJSON, methodDataSetToJSONPrametersTypes);

            // Assert
            parametersOfDataSetToJSON.ShouldNotBeNull();
            parametersOfDataSetToJSON.Length.ShouldBe(1);
            methodDataSetToJSONPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DataSetToJSON) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DataSetToJSON_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDataSetToJSONPrametersTypes = new Type[] { typeof(DataSet) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_sSRSNativeReportViewerInstanceFixture, _sSRSNativeReportViewerInstanceType, MethodDataSetToJSON, Fixture, methodDataSetToJSONPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodDataSetToJSONPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DataSetToJSON) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_SSRSNativeReportViewer_DataSetToJSON_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDataSetToJSON, 0);
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