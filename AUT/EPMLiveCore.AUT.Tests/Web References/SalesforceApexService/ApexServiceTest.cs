using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SalesforceApexService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceApexService.ApexService" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceApexService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class ApexServiceTest : AbstractBaseSetupTypedTest<ApexService>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ApexService) Initializer

        private const string PropertySessionHeaderValue = "SessionHeaderValue";
        private const string PropertyDebuggingHeaderValue = "DebuggingHeaderValue";
        private const string PropertyPackageVersionHeaderValue = "PackageVersionHeaderValue";
        private const string PropertyCallOptionsValue = "CallOptionsValue";
        private const string PropertyDebuggingInfoValue = "DebuggingInfoValue";
        private const string PropertyAllowFieldTruncationHeaderValue = "AllowFieldTruncationHeaderValue";
        private const string PropertyDisableFeedTrackingHeaderValue = "DisableFeedTrackingHeaderValue";
        private const string PropertyUrl = "Url";
        private const string PropertyUseDefaultCredentials = "UseDefaultCredentials";
        private const string MethodcompileAndTest = "compileAndTest";
        private const string MethodcompileAndTestAsync = "compileAndTestAsync";
        private const string MethodOncompileAndTestOperationCompleted = "OncompileAndTestOperationCompleted";
        private const string MethodcompileClasses = "compileClasses";
        private const string MethodcompileClassesAsync = "compileClassesAsync";
        private const string MethodOncompileClassesOperationCompleted = "OncompileClassesOperationCompleted";
        private const string MethodcompileTriggers = "compileTriggers";
        private const string MethodcompileTriggersAsync = "compileTriggersAsync";
        private const string MethodOncompileTriggersOperationCompleted = "OncompileTriggersOperationCompleted";
        private const string MethodexecuteAnonymous = "executeAnonymous";
        private const string MethodexecuteAnonymousAsync = "executeAnonymousAsync";
        private const string MethodOnexecuteAnonymousOperationCompleted = "OnexecuteAnonymousOperationCompleted";
        private const string MethodrunTests = "runTests";
        private const string MethodrunTestsAsync = "runTestsAsync";
        private const string MethodOnrunTestsOperationCompleted = "OnrunTestsOperationCompleted";
        private const string MethodwsdlToApex = "wsdlToApex";
        private const string MethodwsdlToApexAsync = "wsdlToApexAsync";
        private const string MethodOnwsdlToApexOperationCompleted = "OnwsdlToApexOperationCompleted";
        private const string MethodCancelAsync = "CancelAsync";
        private const string MethodIsLocalFileSystemWebService = "IsLocalFileSystemWebService";
        private const string FieldsessionHeaderValueField = "sessionHeaderValueField";
        private const string FielddebuggingHeaderValueField = "debuggingHeaderValueField";
        private const string FieldpackageVersionHeaderValueField = "packageVersionHeaderValueField";
        private const string FieldcallOptionsValueField = "callOptionsValueField";
        private const string FielddebuggingInfoValueField = "debuggingInfoValueField";
        private const string FieldcompileAndTestOperationCompleted = "compileAndTestOperationCompleted";
        private const string FieldcompileClassesOperationCompleted = "compileClassesOperationCompleted";
        private const string FieldcompileTriggersOperationCompleted = "compileTriggersOperationCompleted";
        private const string FieldallowFieldTruncationHeaderValueField = "allowFieldTruncationHeaderValueField";
        private const string FielddisableFeedTrackingHeaderValueField = "disableFeedTrackingHeaderValueField";
        private const string FieldexecuteAnonymousOperationCompleted = "executeAnonymousOperationCompleted";
        private const string FieldrunTestsOperationCompleted = "runTestsOperationCompleted";
        private const string FieldwsdlToApexOperationCompleted = "wsdlToApexOperationCompleted";
        private const string FielduseDefaultCredentialsSetExplicitly = "useDefaultCredentialsSetExplicitly";
        private Type _apexServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ApexService _apexServiceInstance;
        private ApexService _apexServiceInstanceFixture;

        #region General Initializer : Class (ApexService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ApexService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _apexServiceInstanceType = typeof(ApexService);
            _apexServiceInstanceFixture = Create(true);
            _apexServiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ApexService)

        #region General Initializer : Class (ApexService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ApexService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodcompileAndTest, 0)]
        [TestCase(MethodOncompileAndTestOperationCompleted, 0)]
        [TestCase(MethodcompileClasses, 0)]
        [TestCase(MethodOncompileClassesOperationCompleted, 0)]
        [TestCase(MethodcompileTriggers, 0)]
        [TestCase(MethodOncompileTriggersOperationCompleted, 0)]
        [TestCase(MethodexecuteAnonymous, 0)]
        [TestCase(MethodOnexecuteAnonymousOperationCompleted, 0)]
        [TestCase(MethodrunTests, 0)]
        [TestCase(MethodOnrunTestsOperationCompleted, 0)]
        [TestCase(MethodwsdlToApex, 0)]
        [TestCase(MethodOnwsdlToApexOperationCompleted, 0)]
        [TestCase(MethodIsLocalFileSystemWebService, 0)]
        public void AUT_ApexService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_apexServiceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ApexService) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ApexService" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertySessionHeaderValue)]
        [TestCase(PropertyDebuggingHeaderValue)]
        [TestCase(PropertyPackageVersionHeaderValue)]
        [TestCase(PropertyCallOptionsValue)]
        [TestCase(PropertyDebuggingInfoValue)]
        [TestCase(PropertyAllowFieldTruncationHeaderValue)]
        [TestCase(PropertyDisableFeedTrackingHeaderValue)]
        [TestCase(PropertyUrl)]
        [TestCase(PropertyUseDefaultCredentials)]
        public void AUT_ApexService_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_apexServiceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ApexService) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ApexService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldsessionHeaderValueField)]
        [TestCase(FielddebuggingHeaderValueField)]
        [TestCase(FieldpackageVersionHeaderValueField)]
        [TestCase(FieldcallOptionsValueField)]
        [TestCase(FielddebuggingInfoValueField)]
        [TestCase(FieldcompileAndTestOperationCompleted)]
        [TestCase(FieldcompileClassesOperationCompleted)]
        [TestCase(FieldcompileTriggersOperationCompleted)]
        [TestCase(FieldallowFieldTruncationHeaderValueField)]
        [TestCase(FielddisableFeedTrackingHeaderValueField)]
        [TestCase(FieldexecuteAnonymousOperationCompleted)]
        [TestCase(FieldrunTestsOperationCompleted)]
        [TestCase(FieldwsdlToApexOperationCompleted)]
        [TestCase(FielduseDefaultCredentialsSetExplicitly)]
        public void AUT_ApexService_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_apexServiceInstanceFixture, 
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
        ///     Class (<see cref="ApexService" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ApexService_Is_Instance_Present_Test()
        {
            // Assert
            _apexServiceInstanceType.ShouldNotBeNull();
            _apexServiceInstance.ShouldNotBeNull();
            _apexServiceInstanceFixture.ShouldNotBeNull();
            _apexServiceInstance.ShouldBeAssignableTo<ApexService>();
            _apexServiceInstanceFixture.ShouldBeAssignableTo<ApexService>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ApexService) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ApexService_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ApexService instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _apexServiceInstanceType.ShouldNotBeNull();
            _apexServiceInstance.ShouldNotBeNull();
            _apexServiceInstanceFixture.ShouldNotBeNull();
            _apexServiceInstance.ShouldBeAssignableTo<ApexService>();
            _apexServiceInstanceFixture.ShouldBeAssignableTo<ApexService>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ApexService) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(SessionHeader) , PropertySessionHeaderValue)]
        [TestCaseGeneric(typeof(DebuggingHeader) , PropertyDebuggingHeaderValue)]
        [TestCaseGeneric(typeof(PackageVersionHeader) , PropertyPackageVersionHeaderValue)]
        [TestCaseGeneric(typeof(CallOptions) , PropertyCallOptionsValue)]
        [TestCaseGeneric(typeof(DebuggingInfo) , PropertyDebuggingInfoValue)]
        [TestCaseGeneric(typeof(AllowFieldTruncationHeader) , PropertyAllowFieldTruncationHeaderValue)]
        [TestCaseGeneric(typeof(DisableFeedTrackingHeader) , PropertyDisableFeedTrackingHeaderValue)]
        [TestCaseGeneric(typeof(string) , PropertyUrl)]
        [TestCaseGeneric(typeof(bool) , PropertyUseDefaultCredentials)]
        public void AUT_ApexService_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ApexService, T>(_apexServiceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (AllowFieldTruncationHeaderValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_AllowFieldTruncationHeaderValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyAllowFieldTruncationHeaderValue);
            Action currentAction = () => propertyInfo.SetValue(_apexServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (AllowFieldTruncationHeaderValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_Public_Class_AllowFieldTruncationHeaderValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAllowFieldTruncationHeaderValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (CallOptionsValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_CallOptionsValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCallOptionsValue);
            Action currentAction = () => propertyInfo.SetValue(_apexServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (CallOptionsValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_Public_Class_CallOptionsValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCallOptionsValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (DebuggingHeaderValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_DebuggingHeaderValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDebuggingHeaderValue);
            Action currentAction = () => propertyInfo.SetValue(_apexServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (DebuggingHeaderValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_Public_Class_DebuggingHeaderValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDebuggingHeaderValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (DebuggingInfoValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_DebuggingInfoValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDebuggingInfoValue);
            Action currentAction = () => propertyInfo.SetValue(_apexServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (DebuggingInfoValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_Public_Class_DebuggingInfoValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDebuggingInfoValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (DisableFeedTrackingHeaderValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_DisableFeedTrackingHeaderValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDisableFeedTrackingHeaderValue);
            Action currentAction = () => propertyInfo.SetValue(_apexServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (DisableFeedTrackingHeaderValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_Public_Class_DisableFeedTrackingHeaderValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDisableFeedTrackingHeaderValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (PackageVersionHeaderValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_PackageVersionHeaderValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyPackageVersionHeaderValue);
            Action currentAction = () => propertyInfo.SetValue(_apexServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (PackageVersionHeaderValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_Public_Class_PackageVersionHeaderValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPackageVersionHeaderValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (SessionHeaderValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_SessionHeaderValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySessionHeaderValue);
            Action currentAction = () => propertyInfo.SetValue(_apexServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (SessionHeaderValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_Public_Class_SessionHeaderValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySessionHeaderValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (Url) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_Public_Class_Url_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ApexService) => Property (UseDefaultCredentials) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ApexService_Public_Class_UseDefaultCredentials_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUseDefaultCredentials);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ApexService" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodcompileAndTest)]
        [TestCase(MethodOncompileAndTestOperationCompleted)]
        [TestCase(MethodcompileClasses)]
        [TestCase(MethodOncompileClassesOperationCompleted)]
        [TestCase(MethodcompileTriggers)]
        [TestCase(MethodOncompileTriggersOperationCompleted)]
        [TestCase(MethodexecuteAnonymous)]
        [TestCase(MethodOnexecuteAnonymousOperationCompleted)]
        [TestCase(MethodrunTests)]
        [TestCase(MethodOnrunTestsOperationCompleted)]
        [TestCase(MethodwsdlToApex)]
        [TestCase(MethodOnwsdlToApexOperationCompleted)]
        [TestCase(MethodIsLocalFileSystemWebService)]
        public void AUT_ApexService_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ApexService>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (compileAndTest) (Return Type : CompileAndTestResult) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_compileAndTest_Method_Call_Internally(Type[] types)
        {
            var methodcompileAndTestPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodcompileAndTest, Fixture, methodcompileAndTestPrametersTypes);
        }

        #endregion

        #region Method Call : (compileAndTest) (Return Type : CompileAndTestResult) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileAndTest_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var CompileAndTestRequest = CreateType<CompileAndTestRequest>();
            Action executeAction = null;

            // Act
            executeAction = () => _apexServiceInstance.compileAndTest(CompileAndTestRequest);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (compileAndTest) (Return Type : CompileAndTestResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileAndTest_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var CompileAndTestRequest = CreateType<CompileAndTestRequest>();
            var methodcompileAndTestPrametersTypes = new Type[] { typeof(CompileAndTestRequest) };
            object[] parametersOfcompileAndTest = { CompileAndTestRequest };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcompileAndTest, methodcompileAndTestPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ApexService, CompileAndTestResult>(_apexServiceInstanceFixture, out exception1, parametersOfcompileAndTest);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ApexService, CompileAndTestResult>(_apexServiceInstance, MethodcompileAndTest, parametersOfcompileAndTest, methodcompileAndTestPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfcompileAndTest.ShouldNotBeNull();
            parametersOfcompileAndTest.Length.ShouldBe(1);
            methodcompileAndTestPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (compileAndTest) (Return Type : CompileAndTestResult) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileAndTest_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var CompileAndTestRequest = CreateType<CompileAndTestRequest>();
            var methodcompileAndTestPrametersTypes = new Type[] { typeof(CompileAndTestRequest) };
            object[] parametersOfcompileAndTest = { CompileAndTestRequest };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ApexService, CompileAndTestResult>(_apexServiceInstance, MethodcompileAndTest, parametersOfcompileAndTest, methodcompileAndTestPrametersTypes);

            // Assert
            parametersOfcompileAndTest.ShouldNotBeNull();
            parametersOfcompileAndTest.Length.ShouldBe(1);
            methodcompileAndTestPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (compileAndTest) (Return Type : CompileAndTestResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileAndTest_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcompileAndTestPrametersTypes = new Type[] { typeof(CompileAndTestRequest) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodcompileAndTest, Fixture, methodcompileAndTestPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcompileAndTestPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (compileAndTest) (Return Type : CompileAndTestResult) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileAndTest_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcompileAndTestPrametersTypes = new Type[] { typeof(CompileAndTestRequest) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodcompileAndTest, Fixture, methodcompileAndTestPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcompileAndTestPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (compileAndTest) (Return Type : CompileAndTestResult) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileAndTest_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcompileAndTest, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (compileAndTest) (Return Type : CompileAndTestResult) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileAndTest_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcompileAndTest, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncompileAndTestOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_OncompileAndTestOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOncompileAndTestOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOncompileAndTestOperationCompleted, Fixture, methodOncompileAndTestOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OncompileAndTestOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileAndTestOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncompileAndTestOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncompileAndTestOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOncompileAndTestOperationCompleted, methodOncompileAndTestOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_apexServiceInstanceFixture, parametersOfOncompileAndTestOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOncompileAndTestOperationCompleted.ShouldNotBeNull();
            parametersOfOncompileAndTestOperationCompleted.Length.ShouldBe(1);
            methodOncompileAndTestOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncompileAndTestOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncompileAndTestOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncompileAndTestOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileAndTestOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncompileAndTestOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncompileAndTestOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_apexServiceInstance, MethodOncompileAndTestOperationCompleted, parametersOfOncompileAndTestOperationCompleted, methodOncompileAndTestOperationCompletedPrametersTypes);

            // Assert
            parametersOfOncompileAndTestOperationCompleted.ShouldNotBeNull();
            parametersOfOncompileAndTestOperationCompleted.Length.ShouldBe(1);
            methodOncompileAndTestOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncompileAndTestOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncompileAndTestOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncompileAndTestOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileAndTestOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOncompileAndTestOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncompileAndTestOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileAndTestOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOncompileAndTestOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOncompileAndTestOperationCompleted, Fixture, methodOncompileAndTestOperationCompletedPrametersTypes);

            // Assert
            methodOncompileAndTestOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncompileAndTestOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileAndTestOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOncompileAndTestOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (compileClasses) (Return Type : CompileClassResult[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_compileClasses_Method_Call_Internally(Type[] types)
        {
            var methodcompileClassesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodcompileClasses, Fixture, methodcompileClassesPrametersTypes);
        }

        #endregion

        #region Method Call : (compileClasses) (Return Type : CompileClassResult[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileClasses_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var scripts = CreateType<string[]>();
            Action executeAction = null;

            // Act
            executeAction = () => _apexServiceInstance.compileClasses(scripts);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (compileClasses) (Return Type : CompileClassResult[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileClasses_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var scripts = CreateType<string[]>();
            var methodcompileClassesPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfcompileClasses = { scripts };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcompileClasses, methodcompileClassesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ApexService, CompileClassResult[]>(_apexServiceInstanceFixture, out exception1, parametersOfcompileClasses);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ApexService, CompileClassResult[]>(_apexServiceInstance, MethodcompileClasses, parametersOfcompileClasses, methodcompileClassesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfcompileClasses.ShouldNotBeNull();
            parametersOfcompileClasses.Length.ShouldBe(1);
            methodcompileClassesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (compileClasses) (Return Type : CompileClassResult[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileClasses_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var scripts = CreateType<string[]>();
            var methodcompileClassesPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfcompileClasses = { scripts };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ApexService, CompileClassResult[]>(_apexServiceInstance, MethodcompileClasses, parametersOfcompileClasses, methodcompileClassesPrametersTypes);

            // Assert
            parametersOfcompileClasses.ShouldNotBeNull();
            parametersOfcompileClasses.Length.ShouldBe(1);
            methodcompileClassesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (compileClasses) (Return Type : CompileClassResult[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileClasses_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcompileClassesPrametersTypes = new Type[] { typeof(string[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodcompileClasses, Fixture, methodcompileClassesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcompileClassesPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (compileClasses) (Return Type : CompileClassResult[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileClasses_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcompileClassesPrametersTypes = new Type[] { typeof(string[]) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodcompileClasses, Fixture, methodcompileClassesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcompileClassesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (compileClasses) (Return Type : CompileClassResult[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileClasses_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcompileClasses, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (compileClasses) (Return Type : CompileClassResult[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileClasses_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcompileClasses, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncompileClassesOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_OncompileClassesOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOncompileClassesOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOncompileClassesOperationCompleted, Fixture, methodOncompileClassesOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OncompileClassesOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileClassesOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncompileClassesOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncompileClassesOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOncompileClassesOperationCompleted, methodOncompileClassesOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_apexServiceInstanceFixture, parametersOfOncompileClassesOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOncompileClassesOperationCompleted.ShouldNotBeNull();
            parametersOfOncompileClassesOperationCompleted.Length.ShouldBe(1);
            methodOncompileClassesOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncompileClassesOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncompileClassesOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncompileClassesOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileClassesOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncompileClassesOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncompileClassesOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_apexServiceInstance, MethodOncompileClassesOperationCompleted, parametersOfOncompileClassesOperationCompleted, methodOncompileClassesOperationCompletedPrametersTypes);

            // Assert
            parametersOfOncompileClassesOperationCompleted.ShouldNotBeNull();
            parametersOfOncompileClassesOperationCompleted.Length.ShouldBe(1);
            methodOncompileClassesOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncompileClassesOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncompileClassesOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncompileClassesOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileClassesOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOncompileClassesOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncompileClassesOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileClassesOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOncompileClassesOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOncompileClassesOperationCompleted, Fixture, methodOncompileClassesOperationCompletedPrametersTypes);

            // Assert
            methodOncompileClassesOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncompileClassesOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileClassesOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOncompileClassesOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (compileTriggers) (Return Type : CompileTriggerResult[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_compileTriggers_Method_Call_Internally(Type[] types)
        {
            var methodcompileTriggersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodcompileTriggers, Fixture, methodcompileTriggersPrametersTypes);
        }

        #endregion

        #region Method Call : (compileTriggers) (Return Type : CompileTriggerResult[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileTriggers_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var scripts = CreateType<string[]>();
            Action executeAction = null;

            // Act
            executeAction = () => _apexServiceInstance.compileTriggers(scripts);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (compileTriggers) (Return Type : CompileTriggerResult[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileTriggers_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var scripts = CreateType<string[]>();
            var methodcompileTriggersPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfcompileTriggers = { scripts };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcompileTriggers, methodcompileTriggersPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ApexService, CompileTriggerResult[]>(_apexServiceInstanceFixture, out exception1, parametersOfcompileTriggers);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ApexService, CompileTriggerResult[]>(_apexServiceInstance, MethodcompileTriggers, parametersOfcompileTriggers, methodcompileTriggersPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfcompileTriggers.ShouldNotBeNull();
            parametersOfcompileTriggers.Length.ShouldBe(1);
            methodcompileTriggersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (compileTriggers) (Return Type : CompileTriggerResult[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileTriggers_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var scripts = CreateType<string[]>();
            var methodcompileTriggersPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfcompileTriggers = { scripts };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ApexService, CompileTriggerResult[]>(_apexServiceInstance, MethodcompileTriggers, parametersOfcompileTriggers, methodcompileTriggersPrametersTypes);

            // Assert
            parametersOfcompileTriggers.ShouldNotBeNull();
            parametersOfcompileTriggers.Length.ShouldBe(1);
            methodcompileTriggersPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (compileTriggers) (Return Type : CompileTriggerResult[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileTriggers_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcompileTriggersPrametersTypes = new Type[] { typeof(string[]) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodcompileTriggers, Fixture, methodcompileTriggersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcompileTriggersPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (compileTriggers) (Return Type : CompileTriggerResult[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileTriggers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcompileTriggersPrametersTypes = new Type[] { typeof(string[]) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodcompileTriggers, Fixture, methodcompileTriggersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcompileTriggersPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (compileTriggers) (Return Type : CompileTriggerResult[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileTriggers_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcompileTriggers, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (compileTriggers) (Return Type : CompileTriggerResult[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_compileTriggers_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcompileTriggers, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncompileTriggersOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_OncompileTriggersOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOncompileTriggersOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOncompileTriggersOperationCompleted, Fixture, methodOncompileTriggersOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OncompileTriggersOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileTriggersOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncompileTriggersOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncompileTriggersOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOncompileTriggersOperationCompleted, methodOncompileTriggersOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_apexServiceInstanceFixture, parametersOfOncompileTriggersOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOncompileTriggersOperationCompleted.ShouldNotBeNull();
            parametersOfOncompileTriggersOperationCompleted.Length.ShouldBe(1);
            methodOncompileTriggersOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncompileTriggersOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncompileTriggersOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncompileTriggersOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileTriggersOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncompileTriggersOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncompileTriggersOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_apexServiceInstance, MethodOncompileTriggersOperationCompleted, parametersOfOncompileTriggersOperationCompleted, methodOncompileTriggersOperationCompletedPrametersTypes);

            // Assert
            parametersOfOncompileTriggersOperationCompleted.ShouldNotBeNull();
            parametersOfOncompileTriggersOperationCompleted.Length.ShouldBe(1);
            methodOncompileTriggersOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncompileTriggersOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncompileTriggersOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncompileTriggersOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileTriggersOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOncompileTriggersOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncompileTriggersOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileTriggersOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOncompileTriggersOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOncompileTriggersOperationCompleted, Fixture, methodOncompileTriggersOperationCompletedPrametersTypes);

            // Assert
            methodOncompileTriggersOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncompileTriggersOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OncompileTriggersOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOncompileTriggersOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (executeAnonymous) (Return Type : ExecuteAnonymousResult) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_executeAnonymous_Method_Call_Internally(Type[] types)
        {
            var methodexecuteAnonymousPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodexecuteAnonymous, Fixture, methodexecuteAnonymousPrametersTypes);
        }

        #endregion

        #region Method Call : (executeAnonymous) (Return Type : ExecuteAnonymousResult) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_executeAnonymous_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var String = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _apexServiceInstance.executeAnonymous(String);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (executeAnonymous) (Return Type : ExecuteAnonymousResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_executeAnonymous_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var String = CreateType<string>();
            var methodexecuteAnonymousPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfexecuteAnonymous = { String };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodexecuteAnonymous, methodexecuteAnonymousPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ApexService, ExecuteAnonymousResult>(_apexServiceInstanceFixture, out exception1, parametersOfexecuteAnonymous);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ApexService, ExecuteAnonymousResult>(_apexServiceInstance, MethodexecuteAnonymous, parametersOfexecuteAnonymous, methodexecuteAnonymousPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfexecuteAnonymous.ShouldNotBeNull();
            parametersOfexecuteAnonymous.Length.ShouldBe(1);
            methodexecuteAnonymousPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (executeAnonymous) (Return Type : ExecuteAnonymousResult) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_executeAnonymous_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var String = CreateType<string>();
            var methodexecuteAnonymousPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfexecuteAnonymous = { String };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ApexService, ExecuteAnonymousResult>(_apexServiceInstance, MethodexecuteAnonymous, parametersOfexecuteAnonymous, methodexecuteAnonymousPrametersTypes);

            // Assert
            parametersOfexecuteAnonymous.ShouldNotBeNull();
            parametersOfexecuteAnonymous.Length.ShouldBe(1);
            methodexecuteAnonymousPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (executeAnonymous) (Return Type : ExecuteAnonymousResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_executeAnonymous_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodexecuteAnonymousPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodexecuteAnonymous, Fixture, methodexecuteAnonymousPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodexecuteAnonymousPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (executeAnonymous) (Return Type : ExecuteAnonymousResult) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_executeAnonymous_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodexecuteAnonymousPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodexecuteAnonymous, Fixture, methodexecuteAnonymousPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodexecuteAnonymousPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (executeAnonymous) (Return Type : ExecuteAnonymousResult) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_executeAnonymous_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodexecuteAnonymous, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (executeAnonymous) (Return Type : ExecuteAnonymousResult) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_executeAnonymous_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodexecuteAnonymous, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnexecuteAnonymousOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_OnexecuteAnonymousOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOnexecuteAnonymousOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOnexecuteAnonymousOperationCompleted, Fixture, methodOnexecuteAnonymousOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnexecuteAnonymousOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnexecuteAnonymousOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnexecuteAnonymousOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnexecuteAnonymousOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnexecuteAnonymousOperationCompleted, methodOnexecuteAnonymousOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_apexServiceInstanceFixture, parametersOfOnexecuteAnonymousOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnexecuteAnonymousOperationCompleted.ShouldNotBeNull();
            parametersOfOnexecuteAnonymousOperationCompleted.Length.ShouldBe(1);
            methodOnexecuteAnonymousOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnexecuteAnonymousOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnexecuteAnonymousOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnexecuteAnonymousOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnexecuteAnonymousOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnexecuteAnonymousOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnexecuteAnonymousOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_apexServiceInstance, MethodOnexecuteAnonymousOperationCompleted, parametersOfOnexecuteAnonymousOperationCompleted, methodOnexecuteAnonymousOperationCompletedPrametersTypes);

            // Assert
            parametersOfOnexecuteAnonymousOperationCompleted.ShouldNotBeNull();
            parametersOfOnexecuteAnonymousOperationCompleted.Length.ShouldBe(1);
            methodOnexecuteAnonymousOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnexecuteAnonymousOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnexecuteAnonymousOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnexecuteAnonymousOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnexecuteAnonymousOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnexecuteAnonymousOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnexecuteAnonymousOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnexecuteAnonymousOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnexecuteAnonymousOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOnexecuteAnonymousOperationCompleted, Fixture, methodOnexecuteAnonymousOperationCompletedPrametersTypes);

            // Assert
            methodOnexecuteAnonymousOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnexecuteAnonymousOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnexecuteAnonymousOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnexecuteAnonymousOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (runTests) (Return Type : RunTestsResult) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_runTests_Method_Call_Internally(Type[] types)
        {
            var methodrunTestsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodrunTests, Fixture, methodrunTestsPrametersTypes);
        }

        #endregion

        #region Method Call : (runTests) (Return Type : RunTestsResult) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_runTests_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var RunTestsRequest = CreateType<RunTestsRequest>();
            Action executeAction = null;

            // Act
            executeAction = () => _apexServiceInstance.runTests(RunTestsRequest);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (runTests) (Return Type : RunTestsResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_runTests_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var RunTestsRequest = CreateType<RunTestsRequest>();
            var methodrunTestsPrametersTypes = new Type[] { typeof(RunTestsRequest) };
            object[] parametersOfrunTests = { RunTestsRequest };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodrunTests, methodrunTestsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ApexService, RunTestsResult>(_apexServiceInstanceFixture, out exception1, parametersOfrunTests);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ApexService, RunTestsResult>(_apexServiceInstance, MethodrunTests, parametersOfrunTests, methodrunTestsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfrunTests.ShouldNotBeNull();
            parametersOfrunTests.Length.ShouldBe(1);
            methodrunTestsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (runTests) (Return Type : RunTestsResult) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_runTests_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var RunTestsRequest = CreateType<RunTestsRequest>();
            var methodrunTestsPrametersTypes = new Type[] { typeof(RunTestsRequest) };
            object[] parametersOfrunTests = { RunTestsRequest };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ApexService, RunTestsResult>(_apexServiceInstance, MethodrunTests, parametersOfrunTests, methodrunTestsPrametersTypes);

            // Assert
            parametersOfrunTests.ShouldNotBeNull();
            parametersOfrunTests.Length.ShouldBe(1);
            methodrunTestsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (runTests) (Return Type : RunTestsResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_runTests_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodrunTestsPrametersTypes = new Type[] { typeof(RunTestsRequest) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodrunTests, Fixture, methodrunTestsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodrunTestsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (runTests) (Return Type : RunTestsResult) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_runTests_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodrunTestsPrametersTypes = new Type[] { typeof(RunTestsRequest) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodrunTests, Fixture, methodrunTestsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodrunTestsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (runTests) (Return Type : RunTestsResult) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_runTests_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodrunTests, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (runTests) (Return Type : RunTestsResult) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_runTests_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodrunTests, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnrunTestsOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_OnrunTestsOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOnrunTestsOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOnrunTestsOperationCompleted, Fixture, methodOnrunTestsOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnrunTestsOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnrunTestsOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnrunTestsOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnrunTestsOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnrunTestsOperationCompleted, methodOnrunTestsOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_apexServiceInstanceFixture, parametersOfOnrunTestsOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnrunTestsOperationCompleted.ShouldNotBeNull();
            parametersOfOnrunTestsOperationCompleted.Length.ShouldBe(1);
            methodOnrunTestsOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnrunTestsOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnrunTestsOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnrunTestsOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnrunTestsOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnrunTestsOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnrunTestsOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_apexServiceInstance, MethodOnrunTestsOperationCompleted, parametersOfOnrunTestsOperationCompleted, methodOnrunTestsOperationCompletedPrametersTypes);

            // Assert
            parametersOfOnrunTestsOperationCompleted.ShouldNotBeNull();
            parametersOfOnrunTestsOperationCompleted.Length.ShouldBe(1);
            methodOnrunTestsOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnrunTestsOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnrunTestsOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnrunTestsOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnrunTestsOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnrunTestsOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnrunTestsOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnrunTestsOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnrunTestsOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOnrunTestsOperationCompleted, Fixture, methodOnrunTestsOperationCompletedPrametersTypes);

            // Assert
            methodOnrunTestsOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnrunTestsOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnrunTestsOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnrunTestsOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (wsdlToApex) (Return Type : WsdlToApexResult) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_wsdlToApex_Method_Call_Internally(Type[] types)
        {
            var methodwsdlToApexPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodwsdlToApex, Fixture, methodwsdlToApexPrametersTypes);
        }

        #endregion

        #region Method Call : (wsdlToApex) (Return Type : WsdlToApexResult) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_wsdlToApex_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var info = CreateType<WsdlToApexInfo>();
            Action executeAction = null;

            // Act
            executeAction = () => _apexServiceInstance.wsdlToApex(info);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (wsdlToApex) (Return Type : WsdlToApexResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_wsdlToApex_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var info = CreateType<WsdlToApexInfo>();
            var methodwsdlToApexPrametersTypes = new Type[] { typeof(WsdlToApexInfo) };
            object[] parametersOfwsdlToApex = { info };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodwsdlToApex, methodwsdlToApexPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ApexService, WsdlToApexResult>(_apexServiceInstanceFixture, out exception1, parametersOfwsdlToApex);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ApexService, WsdlToApexResult>(_apexServiceInstance, MethodwsdlToApex, parametersOfwsdlToApex, methodwsdlToApexPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfwsdlToApex.ShouldNotBeNull();
            parametersOfwsdlToApex.Length.ShouldBe(1);
            methodwsdlToApexPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (wsdlToApex) (Return Type : WsdlToApexResult) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_wsdlToApex_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var info = CreateType<WsdlToApexInfo>();
            var methodwsdlToApexPrametersTypes = new Type[] { typeof(WsdlToApexInfo) };
            object[] parametersOfwsdlToApex = { info };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ApexService, WsdlToApexResult>(_apexServiceInstance, MethodwsdlToApex, parametersOfwsdlToApex, methodwsdlToApexPrametersTypes);

            // Assert
            parametersOfwsdlToApex.ShouldNotBeNull();
            parametersOfwsdlToApex.Length.ShouldBe(1);
            methodwsdlToApexPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (wsdlToApex) (Return Type : WsdlToApexResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_wsdlToApex_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodwsdlToApexPrametersTypes = new Type[] { typeof(WsdlToApexInfo) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodwsdlToApex, Fixture, methodwsdlToApexPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodwsdlToApexPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (wsdlToApex) (Return Type : WsdlToApexResult) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_wsdlToApex_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodwsdlToApexPrametersTypes = new Type[] { typeof(WsdlToApexInfo) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodwsdlToApex, Fixture, methodwsdlToApexPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodwsdlToApexPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (wsdlToApex) (Return Type : WsdlToApexResult) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_wsdlToApex_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodwsdlToApex, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (wsdlToApex) (Return Type : WsdlToApexResult) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_wsdlToApex_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodwsdlToApex, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnwsdlToApexOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_OnwsdlToApexOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOnwsdlToApexOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOnwsdlToApexOperationCompleted, Fixture, methodOnwsdlToApexOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnwsdlToApexOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnwsdlToApexOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnwsdlToApexOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnwsdlToApexOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnwsdlToApexOperationCompleted, methodOnwsdlToApexOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_apexServiceInstanceFixture, parametersOfOnwsdlToApexOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnwsdlToApexOperationCompleted.ShouldNotBeNull();
            parametersOfOnwsdlToApexOperationCompleted.Length.ShouldBe(1);
            methodOnwsdlToApexOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnwsdlToApexOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnwsdlToApexOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnwsdlToApexOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnwsdlToApexOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnwsdlToApexOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnwsdlToApexOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_apexServiceInstance, MethodOnwsdlToApexOperationCompleted, parametersOfOnwsdlToApexOperationCompleted, methodOnwsdlToApexOperationCompletedPrametersTypes);

            // Assert
            parametersOfOnwsdlToApexOperationCompleted.ShouldNotBeNull();
            parametersOfOnwsdlToApexOperationCompleted.Length.ShouldBe(1);
            methodOnwsdlToApexOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnwsdlToApexOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnwsdlToApexOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnwsdlToApexOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnwsdlToApexOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnwsdlToApexOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnwsdlToApexOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnwsdlToApexOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnwsdlToApexOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodOnwsdlToApexOperationCompleted, Fixture, methodOnwsdlToApexOperationCompletedPrametersTypes);

            // Assert
            methodOnwsdlToApexOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnwsdlToApexOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_OnwsdlToApexOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnwsdlToApexOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ApexService_IsLocalFileSystemWebService_Method_Call_Internally(Type[] types)
        {
            var methodIsLocalFileSystemWebServicePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodIsLocalFileSystemWebService, Fixture, methodIsLocalFileSystemWebServicePrametersTypes);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_IsLocalFileSystemWebService_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ApexService, bool>(_apexServiceInstanceFixture, out exception1, parametersOfIsLocalFileSystemWebService);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ApexService, bool>(_apexServiceInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLocalFileSystemWebService.ShouldNotBeNull();
            parametersOfIsLocalFileSystemWebService.Length.ShouldBe(1);
            methodIsLocalFileSystemWebServicePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_IsLocalFileSystemWebService_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ApexService, bool>(_apexServiceInstanceFixture, out exception1, parametersOfIsLocalFileSystemWebService);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ApexService, bool>(_apexServiceInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLocalFileSystemWebService.ShouldNotBeNull();
            parametersOfIsLocalFileSystemWebService.Length.ShouldBe(1);
            methodIsLocalFileSystemWebServicePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_IsLocalFileSystemWebService_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ApexService, bool>(_apexServiceInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

            // Assert
            parametersOfIsLocalFileSystemWebService.ShouldNotBeNull();
            parametersOfIsLocalFileSystemWebService.Length.ShouldBe(1);
            methodIsLocalFileSystemWebServicePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_IsLocalFileSystemWebService_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_apexServiceInstance, MethodIsLocalFileSystemWebService, Fixture, methodIsLocalFileSystemWebServicePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsLocalFileSystemWebServicePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_IsLocalFileSystemWebService_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_apexServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ApexService_IsLocalFileSystemWebService_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, 0);
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