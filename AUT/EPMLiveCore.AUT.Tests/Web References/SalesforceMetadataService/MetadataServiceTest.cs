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

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.MetadataService" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public partial class MetadataServiceTest : AbstractBaseSetupTypedTest<MetadataService>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MetadataService) Initializer

        private const string PropertySessionHeaderValue = "SessionHeaderValue";
        private const string PropertyCallOptionsValue = "CallOptionsValue";
        private const string PropertyDebuggingInfoValue = "DebuggingInfoValue";
        private const string PropertyDebuggingHeaderValue = "DebuggingHeaderValue";
        private const string PropertyUrl = "Url";
        private const string PropertyUseDefaultCredentials = "UseDefaultCredentials";
        private const string MethodcheckDeployStatus = "checkDeployStatus";
        private const string MethodcheckDeployStatusAsync = "checkDeployStatusAsync";
        private const string MethodOncheckDeployStatusOperationCompleted = "OncheckDeployStatusOperationCompleted";
        private const string MethodcheckRetrieveStatus = "checkRetrieveStatus";
        private const string MethodcheckRetrieveStatusAsync = "checkRetrieveStatusAsync";
        private const string MethodOncheckRetrieveStatusOperationCompleted = "OncheckRetrieveStatusOperationCompleted";
        private const string MethodcheckStatus = "checkStatus";
        private const string MethodcheckStatusAsync = "checkStatusAsync";
        private const string MethodOncheckStatusOperationCompleted = "OncheckStatusOperationCompleted";
        private const string Methodcreate = "create";
        private const string MethodcreateAsync = "createAsync";
        private const string MethodOncreateOperationCompleted = "OncreateOperationCompleted";
        private const string Methoddelete = "delete";
        private const string MethoddeleteAsync = "deleteAsync";
        private const string MethodOndeleteOperationCompleted = "OndeleteOperationCompleted";
        private const string Methoddeploy = "deploy";
        private const string MethoddeployAsync = "deployAsync";
        private const string MethodOndeployOperationCompleted = "OndeployOperationCompleted";
        private const string MethoddescribeMetadata = "describeMetadata";
        private const string MethoddescribeMetadataAsync = "describeMetadataAsync";
        private const string MethodOndescribeMetadataOperationCompleted = "OndescribeMetadataOperationCompleted";
        private const string MethodlistMetadata = "listMetadata";
        private const string MethodlistMetadataAsync = "listMetadataAsync";
        private const string MethodOnlistMetadataOperationCompleted = "OnlistMetadataOperationCompleted";
        private const string Methodretrieve = "retrieve";
        private const string MethodretrieveAsync = "retrieveAsync";
        private const string MethodOnretrieveOperationCompleted = "OnretrieveOperationCompleted";
        private const string Methodupdate = "update";
        private const string MethodupdateAsync = "updateAsync";
        private const string MethodOnupdateOperationCompleted = "OnupdateOperationCompleted";
        private const string MethodCancelAsync = "CancelAsync";
        private const string MethodIsLocalFileSystemWebService = "IsLocalFileSystemWebService";
        private const string FieldsessionHeaderValueField = "sessionHeaderValueField";
        private const string FieldcallOptionsValueField = "callOptionsValueField";
        private const string FielddebuggingInfoValueField = "debuggingInfoValueField";
        private const string FieldcheckDeployStatusOperationCompleted = "checkDeployStatusOperationCompleted";
        private const string FieldcheckRetrieveStatusOperationCompleted = "checkRetrieveStatusOperationCompleted";
        private const string FieldcheckStatusOperationCompleted = "checkStatusOperationCompleted";
        private const string FieldcreateOperationCompleted = "createOperationCompleted";
        private const string FielddeleteOperationCompleted = "deleteOperationCompleted";
        private const string FielddebuggingHeaderValueField = "debuggingHeaderValueField";
        private const string FielddeployOperationCompleted = "deployOperationCompleted";
        private const string FielddescribeMetadataOperationCompleted = "describeMetadataOperationCompleted";
        private const string FieldlistMetadataOperationCompleted = "listMetadataOperationCompleted";
        private const string FieldretrieveOperationCompleted = "retrieveOperationCompleted";
        private const string FieldupdateOperationCompleted = "updateOperationCompleted";
        private const string FielduseDefaultCredentialsSetExplicitly = "useDefaultCredentialsSetExplicitly";
        private Type _metadataServiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MetadataService _metadataServiceInstance;
        private MetadataService _metadataServiceInstanceFixture;

        #region General Initializer : Class (MetadataService) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MetadataService" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _metadataServiceInstanceType = typeof(MetadataService);
            _metadataServiceInstanceFixture = Create(true);
            _metadataServiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MetadataService)

        #region General Initializer : Class (MetadataService) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="MetadataService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodcheckDeployStatus, 0)]
        [TestCase(MethodOncheckDeployStatusOperationCompleted, 0)]
        [TestCase(MethodcheckRetrieveStatus, 0)]
        [TestCase(MethodOncheckRetrieveStatusOperationCompleted, 0)]
        [TestCase(MethodOncheckStatusOperationCompleted, 0)]
        [TestCase(MethodOncreateOperationCompleted, 0)]
        [TestCase(MethodOndeleteOperationCompleted, 0)]
        [TestCase(MethodOndeployOperationCompleted, 0)]
        [TestCase(MethoddescribeMetadata, 0)]
        [TestCase(MethodOndescribeMetadataOperationCompleted, 0)]
        [TestCase(MethodlistMetadata, 0)]
        [TestCase(MethodOnlistMetadataOperationCompleted, 0)]
        [TestCase(MethodOnretrieveOperationCompleted, 0)]
        [TestCase(MethodOnupdateOperationCompleted, 0)]
        [TestCase(MethodIsLocalFileSystemWebService, 0)]
        public void AUT_MetadataService_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_metadataServiceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MetadataService) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MetadataService" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertySessionHeaderValue)]
        [TestCase(PropertyCallOptionsValue)]
        [TestCase(PropertyDebuggingInfoValue)]
        [TestCase(PropertyDebuggingHeaderValue)]
        [TestCase(PropertyUrl)]
        [TestCase(PropertyUseDefaultCredentials)]
        public void AUT_MetadataService_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_metadataServiceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MetadataService) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MetadataService" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldsessionHeaderValueField)]
        [TestCase(FieldcallOptionsValueField)]
        [TestCase(FielddebuggingInfoValueField)]
        [TestCase(FieldcheckDeployStatusOperationCompleted)]
        [TestCase(FieldcheckRetrieveStatusOperationCompleted)]
        [TestCase(FieldcheckStatusOperationCompleted)]
        [TestCase(FieldcreateOperationCompleted)]
        [TestCase(FielddeleteOperationCompleted)]
        [TestCase(FielddebuggingHeaderValueField)]
        [TestCase(FielddeployOperationCompleted)]
        [TestCase(FielddescribeMetadataOperationCompleted)]
        [TestCase(FieldlistMetadataOperationCompleted)]
        [TestCase(FieldretrieveOperationCompleted)]
        [TestCase(FieldupdateOperationCompleted)]
        [TestCase(FielduseDefaultCredentialsSetExplicitly)]
        public void AUT_MetadataService_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_metadataServiceInstanceFixture, 
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
        ///     Class (<see cref="MetadataService" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MetadataService_Is_Instance_Present_Test()
        {
            // Assert
            _metadataServiceInstanceType.ShouldNotBeNull();
            _metadataServiceInstance.ShouldNotBeNull();
            _metadataServiceInstanceFixture.ShouldNotBeNull();
            _metadataServiceInstance.ShouldBeAssignableTo<MetadataService>();
            _metadataServiceInstanceFixture.ShouldBeAssignableTo<MetadataService>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MetadataService) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MetadataService_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MetadataService instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _metadataServiceInstanceType.ShouldNotBeNull();
            _metadataServiceInstance.ShouldNotBeNull();
            _metadataServiceInstanceFixture.ShouldNotBeNull();
            _metadataServiceInstance.ShouldBeAssignableTo<MetadataService>();
            _metadataServiceInstanceFixture.ShouldBeAssignableTo<MetadataService>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MetadataService) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(SessionHeader) , PropertySessionHeaderValue)]
        [TestCaseGeneric(typeof(CallOptions) , PropertyCallOptionsValue)]
        [TestCaseGeneric(typeof(DebuggingInfo) , PropertyDebuggingInfoValue)]
        [TestCaseGeneric(typeof(DebuggingHeader) , PropertyDebuggingHeaderValue)]
        [TestCaseGeneric(typeof(string) , PropertyUrl)]
        [TestCaseGeneric(typeof(bool) , PropertyUseDefaultCredentials)]
        public void AUT_MetadataService_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MetadataService, T>(_metadataServiceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MetadataService) => Property (CallOptionsValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataService_CallOptionsValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCallOptionsValue);
            Action currentAction = () => propertyInfo.SetValue(_metadataServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MetadataService) => Property (CallOptionsValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataService_Public_Class_CallOptionsValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MetadataService) => Property (DebuggingHeaderValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataService_DebuggingHeaderValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDebuggingHeaderValue);
            Action currentAction = () => propertyInfo.SetValue(_metadataServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MetadataService) => Property (DebuggingHeaderValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataService_Public_Class_DebuggingHeaderValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MetadataService) => Property (DebuggingInfoValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataService_DebuggingInfoValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyDebuggingInfoValue);
            Action currentAction = () => propertyInfo.SetValue(_metadataServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MetadataService) => Property (DebuggingInfoValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataService_Public_Class_DebuggingInfoValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MetadataService) => Property (SessionHeaderValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataService_SessionHeaderValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySessionHeaderValue);
            Action currentAction = () => propertyInfo.SetValue(_metadataServiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MetadataService) => Property (SessionHeaderValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataService_Public_Class_SessionHeaderValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MetadataService) => Property (Url) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataService_Public_Class_Url_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (MetadataService) => Property (UseDefaultCredentials) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MetadataService_Public_Class_UseDefaultCredentials_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///      Class (<see cref="MetadataService" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodcheckDeployStatus)]
        [TestCase(MethodOncheckDeployStatusOperationCompleted)]
        [TestCase(MethodcheckRetrieveStatus)]
        [TestCase(MethodOncheckRetrieveStatusOperationCompleted)]
        [TestCase(MethodOncheckStatusOperationCompleted)]
        [TestCase(MethodOncreateOperationCompleted)]
        [TestCase(MethodOndeleteOperationCompleted)]
        [TestCase(MethodOndeployOperationCompleted)]
        [TestCase(MethoddescribeMetadata)]
        [TestCase(MethodOndescribeMetadataOperationCompleted)]
        [TestCase(MethodlistMetadata)]
        [TestCase(MethodOnlistMetadataOperationCompleted)]
        [TestCase(MethodOnretrieveOperationCompleted)]
        [TestCase(MethodOnupdateOperationCompleted)]
        [TestCase(MethodIsLocalFileSystemWebService)]
        public void AUT_MetadataService_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<MetadataService>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (checkDeployStatus) (Return Type : DeployResult) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_checkDeployStatus_Method_Call_Internally(Type[] types)
        {
            var methodcheckDeployStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodcheckDeployStatus, Fixture, methodcheckDeployStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (checkDeployStatus) (Return Type : DeployResult) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkDeployStatus_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var asyncProcessId = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _metadataServiceInstance.checkDeployStatus(asyncProcessId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (checkDeployStatus) (Return Type : DeployResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkDeployStatus_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var asyncProcessId = CreateType<string>();
            var methodcheckDeployStatusPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfcheckDeployStatus = { asyncProcessId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcheckDeployStatus, methodcheckDeployStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MetadataService, DeployResult>(_metadataServiceInstanceFixture, out exception1, parametersOfcheckDeployStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MetadataService, DeployResult>(_metadataServiceInstance, MethodcheckDeployStatus, parametersOfcheckDeployStatus, methodcheckDeployStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfcheckDeployStatus.ShouldNotBeNull();
            parametersOfcheckDeployStatus.Length.ShouldBe(1);
            methodcheckDeployStatusPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (checkDeployStatus) (Return Type : DeployResult) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkDeployStatus_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var asyncProcessId = CreateType<string>();
            var methodcheckDeployStatusPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfcheckDeployStatus = { asyncProcessId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MetadataService, DeployResult>(_metadataServiceInstance, MethodcheckDeployStatus, parametersOfcheckDeployStatus, methodcheckDeployStatusPrametersTypes);

            // Assert
            parametersOfcheckDeployStatus.ShouldNotBeNull();
            parametersOfcheckDeployStatus.Length.ShouldBe(1);
            methodcheckDeployStatusPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (checkDeployStatus) (Return Type : DeployResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkDeployStatus_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcheckDeployStatusPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodcheckDeployStatus, Fixture, methodcheckDeployStatusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcheckDeployStatusPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (checkDeployStatus) (Return Type : DeployResult) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkDeployStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcheckDeployStatusPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodcheckDeployStatus, Fixture, methodcheckDeployStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcheckDeployStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (checkDeployStatus) (Return Type : DeployResult) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkDeployStatus_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcheckDeployStatus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (checkDeployStatus) (Return Type : DeployResult) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkDeployStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcheckDeployStatus, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncheckDeployStatusOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_OncheckDeployStatusOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOncheckDeployStatusOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOncheckDeployStatusOperationCompleted, Fixture, methodOncheckDeployStatusOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OncheckDeployStatusOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckDeployStatusOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncheckDeployStatusOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncheckDeployStatusOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOncheckDeployStatusOperationCompleted, methodOncheckDeployStatusOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_metadataServiceInstanceFixture, parametersOfOncheckDeployStatusOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOncheckDeployStatusOperationCompleted.ShouldNotBeNull();
            parametersOfOncheckDeployStatusOperationCompleted.Length.ShouldBe(1);
            methodOncheckDeployStatusOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncheckDeployStatusOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncheckDeployStatusOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncheckDeployStatusOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckDeployStatusOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncheckDeployStatusOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncheckDeployStatusOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_metadataServiceInstance, MethodOncheckDeployStatusOperationCompleted, parametersOfOncheckDeployStatusOperationCompleted, methodOncheckDeployStatusOperationCompletedPrametersTypes);

            // Assert
            parametersOfOncheckDeployStatusOperationCompleted.ShouldNotBeNull();
            parametersOfOncheckDeployStatusOperationCompleted.Length.ShouldBe(1);
            methodOncheckDeployStatusOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncheckDeployStatusOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncheckDeployStatusOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncheckDeployStatusOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckDeployStatusOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOncheckDeployStatusOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncheckDeployStatusOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckDeployStatusOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOncheckDeployStatusOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOncheckDeployStatusOperationCompleted, Fixture, methodOncheckDeployStatusOperationCompletedPrametersTypes);

            // Assert
            methodOncheckDeployStatusOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncheckDeployStatusOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckDeployStatusOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOncheckDeployStatusOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (checkRetrieveStatus) (Return Type : RetrieveResult) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_checkRetrieveStatus_Method_Call_Internally(Type[] types)
        {
            var methodcheckRetrieveStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodcheckRetrieveStatus, Fixture, methodcheckRetrieveStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (checkRetrieveStatus) (Return Type : RetrieveResult) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkRetrieveStatus_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var asyncProcessId = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _metadataServiceInstance.checkRetrieveStatus(asyncProcessId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (checkRetrieveStatus) (Return Type : RetrieveResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkRetrieveStatus_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var asyncProcessId = CreateType<string>();
            var methodcheckRetrieveStatusPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfcheckRetrieveStatus = { asyncProcessId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodcheckRetrieveStatus, methodcheckRetrieveStatusPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MetadataService, RetrieveResult>(_metadataServiceInstanceFixture, out exception1, parametersOfcheckRetrieveStatus);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MetadataService, RetrieveResult>(_metadataServiceInstance, MethodcheckRetrieveStatus, parametersOfcheckRetrieveStatus, methodcheckRetrieveStatusPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfcheckRetrieveStatus.ShouldNotBeNull();
            parametersOfcheckRetrieveStatus.Length.ShouldBe(1);
            methodcheckRetrieveStatusPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (checkRetrieveStatus) (Return Type : RetrieveResult) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkRetrieveStatus_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var asyncProcessId = CreateType<string>();
            var methodcheckRetrieveStatusPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfcheckRetrieveStatus = { asyncProcessId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MetadataService, RetrieveResult>(_metadataServiceInstance, MethodcheckRetrieveStatus, parametersOfcheckRetrieveStatus, methodcheckRetrieveStatusPrametersTypes);

            // Assert
            parametersOfcheckRetrieveStatus.ShouldNotBeNull();
            parametersOfcheckRetrieveStatus.Length.ShouldBe(1);
            methodcheckRetrieveStatusPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (checkRetrieveStatus) (Return Type : RetrieveResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkRetrieveStatus_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodcheckRetrieveStatusPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodcheckRetrieveStatus, Fixture, methodcheckRetrieveStatusPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodcheckRetrieveStatusPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (checkRetrieveStatus) (Return Type : RetrieveResult) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkRetrieveStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodcheckRetrieveStatusPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodcheckRetrieveStatus, Fixture, methodcheckRetrieveStatusPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodcheckRetrieveStatusPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (checkRetrieveStatus) (Return Type : RetrieveResult) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkRetrieveStatus_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodcheckRetrieveStatus, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (checkRetrieveStatus) (Return Type : RetrieveResult) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_checkRetrieveStatus_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodcheckRetrieveStatus, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncheckRetrieveStatusOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_OncheckRetrieveStatusOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOncheckRetrieveStatusOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOncheckRetrieveStatusOperationCompleted, Fixture, methodOncheckRetrieveStatusOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OncheckRetrieveStatusOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckRetrieveStatusOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncheckRetrieveStatusOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncheckRetrieveStatusOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOncheckRetrieveStatusOperationCompleted, methodOncheckRetrieveStatusOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_metadataServiceInstanceFixture, parametersOfOncheckRetrieveStatusOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOncheckRetrieveStatusOperationCompleted.ShouldNotBeNull();
            parametersOfOncheckRetrieveStatusOperationCompleted.Length.ShouldBe(1);
            methodOncheckRetrieveStatusOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncheckRetrieveStatusOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncheckRetrieveStatusOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncheckRetrieveStatusOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckRetrieveStatusOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncheckRetrieveStatusOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncheckRetrieveStatusOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_metadataServiceInstance, MethodOncheckRetrieveStatusOperationCompleted, parametersOfOncheckRetrieveStatusOperationCompleted, methodOncheckRetrieveStatusOperationCompletedPrametersTypes);

            // Assert
            parametersOfOncheckRetrieveStatusOperationCompleted.ShouldNotBeNull();
            parametersOfOncheckRetrieveStatusOperationCompleted.Length.ShouldBe(1);
            methodOncheckRetrieveStatusOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncheckRetrieveStatusOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncheckRetrieveStatusOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncheckRetrieveStatusOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckRetrieveStatusOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOncheckRetrieveStatusOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncheckRetrieveStatusOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckRetrieveStatusOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOncheckRetrieveStatusOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOncheckRetrieveStatusOperationCompleted, Fixture, methodOncheckRetrieveStatusOperationCompletedPrametersTypes);

            // Assert
            methodOncheckRetrieveStatusOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncheckRetrieveStatusOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckRetrieveStatusOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOncheckRetrieveStatusOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncheckStatusOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_OncheckStatusOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOncheckStatusOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOncheckStatusOperationCompleted, Fixture, methodOncheckStatusOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OncheckStatusOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckStatusOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncheckStatusOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncheckStatusOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOncheckStatusOperationCompleted, methodOncheckStatusOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_metadataServiceInstanceFixture, parametersOfOncheckStatusOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOncheckStatusOperationCompleted.ShouldNotBeNull();
            parametersOfOncheckStatusOperationCompleted.Length.ShouldBe(1);
            methodOncheckStatusOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncheckStatusOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncheckStatusOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncheckStatusOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckStatusOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncheckStatusOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncheckStatusOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_metadataServiceInstance, MethodOncheckStatusOperationCompleted, parametersOfOncheckStatusOperationCompleted, methodOncheckStatusOperationCompletedPrametersTypes);

            // Assert
            parametersOfOncheckStatusOperationCompleted.ShouldNotBeNull();
            parametersOfOncheckStatusOperationCompleted.Length.ShouldBe(1);
            methodOncheckStatusOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncheckStatusOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncheckStatusOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncheckStatusOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckStatusOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOncheckStatusOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncheckStatusOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckStatusOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOncheckStatusOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOncheckStatusOperationCompleted, Fixture, methodOncheckStatusOperationCompletedPrametersTypes);

            // Assert
            methodOncheckStatusOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncheckStatusOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncheckStatusOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOncheckStatusOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncreateOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_OncreateOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOncreateOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOncreateOperationCompleted, Fixture, methodOncreateOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OncreateOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncreateOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncreateOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncreateOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOncreateOperationCompleted, methodOncreateOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_metadataServiceInstanceFixture, parametersOfOncreateOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOncreateOperationCompleted.ShouldNotBeNull();
            parametersOfOncreateOperationCompleted.Length.ShouldBe(1);
            methodOncreateOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncreateOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncreateOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncreateOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncreateOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOncreateOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOncreateOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_metadataServiceInstance, MethodOncreateOperationCompleted, parametersOfOncreateOperationCompleted, methodOncreateOperationCompletedPrametersTypes);

            // Assert
            parametersOfOncreateOperationCompleted.ShouldNotBeNull();
            parametersOfOncreateOperationCompleted.Length.ShouldBe(1);
            methodOncreateOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOncreateOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOncreateOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncreateOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncreateOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOncreateOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OncreateOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncreateOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOncreateOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOncreateOperationCompleted, Fixture, methodOncreateOperationCompletedPrametersTypes);

            // Assert
            methodOncreateOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OncreateOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OncreateOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOncreateOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndeleteOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_OndeleteOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOndeleteOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOndeleteOperationCompleted, Fixture, methodOndeleteOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OndeleteOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndeleteOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOndeleteOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOndeleteOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOndeleteOperationCompleted, methodOndeleteOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_metadataServiceInstanceFixture, parametersOfOndeleteOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOndeleteOperationCompleted.ShouldNotBeNull();
            parametersOfOndeleteOperationCompleted.Length.ShouldBe(1);
            methodOndeleteOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOndeleteOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOndeleteOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndeleteOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndeleteOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOndeleteOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOndeleteOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_metadataServiceInstance, MethodOndeleteOperationCompleted, parametersOfOndeleteOperationCompleted, methodOndeleteOperationCompletedPrametersTypes);

            // Assert
            parametersOfOndeleteOperationCompleted.ShouldNotBeNull();
            parametersOfOndeleteOperationCompleted.Length.ShouldBe(1);
            methodOndeleteOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOndeleteOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOndeleteOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndeleteOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndeleteOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOndeleteOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OndeleteOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndeleteOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOndeleteOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOndeleteOperationCompleted, Fixture, methodOndeleteOperationCompletedPrametersTypes);

            // Assert
            methodOndeleteOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndeleteOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndeleteOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOndeleteOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndeployOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_OndeployOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOndeployOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOndeployOperationCompleted, Fixture, methodOndeployOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OndeployOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndeployOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOndeployOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOndeployOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOndeployOperationCompleted, methodOndeployOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_metadataServiceInstanceFixture, parametersOfOndeployOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOndeployOperationCompleted.ShouldNotBeNull();
            parametersOfOndeployOperationCompleted.Length.ShouldBe(1);
            methodOndeployOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOndeployOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOndeployOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndeployOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndeployOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOndeployOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOndeployOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_metadataServiceInstance, MethodOndeployOperationCompleted, parametersOfOndeployOperationCompleted, methodOndeployOperationCompletedPrametersTypes);

            // Assert
            parametersOfOndeployOperationCompleted.ShouldNotBeNull();
            parametersOfOndeployOperationCompleted.Length.ShouldBe(1);
            methodOndeployOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOndeployOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOndeployOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndeployOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndeployOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOndeployOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OndeployOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndeployOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOndeployOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOndeployOperationCompleted, Fixture, methodOndeployOperationCompletedPrametersTypes);

            // Assert
            methodOndeployOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndeployOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndeployOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOndeployOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (describeMetadata) (Return Type : DescribeMetadataResult) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_describeMetadata_Method_Call_Internally(Type[] types)
        {
            var methoddescribeMetadataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethoddescribeMetadata, Fixture, methoddescribeMetadataPrametersTypes);
        }

        #endregion

        #region Method Call : (describeMetadata) (Return Type : DescribeMetadataResult) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_describeMetadata_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var asOfVersion = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _metadataServiceInstance.describeMetadata(asOfVersion);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (describeMetadata) (Return Type : DescribeMetadataResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_describeMetadata_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var asOfVersion = CreateType<double>();
            var methoddescribeMetadataPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfdescribeMetadata = { asOfVersion };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethoddescribeMetadata, methoddescribeMetadataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MetadataService, DescribeMetadataResult>(_metadataServiceInstanceFixture, out exception1, parametersOfdescribeMetadata);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MetadataService, DescribeMetadataResult>(_metadataServiceInstance, MethoddescribeMetadata, parametersOfdescribeMetadata, methoddescribeMetadataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfdescribeMetadata.ShouldNotBeNull();
            parametersOfdescribeMetadata.Length.ShouldBe(1);
            methoddescribeMetadataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (describeMetadata) (Return Type : DescribeMetadataResult) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_describeMetadata_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var asOfVersion = CreateType<double>();
            var methoddescribeMetadataPrametersTypes = new Type[] { typeof(double) };
            object[] parametersOfdescribeMetadata = { asOfVersion };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MetadataService, DescribeMetadataResult>(_metadataServiceInstance, MethoddescribeMetadata, parametersOfdescribeMetadata, methoddescribeMetadataPrametersTypes);

            // Assert
            parametersOfdescribeMetadata.ShouldNotBeNull();
            parametersOfdescribeMetadata.Length.ShouldBe(1);
            methoddescribeMetadataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (describeMetadata) (Return Type : DescribeMetadataResult) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_describeMetadata_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methoddescribeMetadataPrametersTypes = new Type[] { typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethoddescribeMetadata, Fixture, methoddescribeMetadataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methoddescribeMetadataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (describeMetadata) (Return Type : DescribeMetadataResult) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_describeMetadata_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methoddescribeMetadataPrametersTypes = new Type[] { typeof(double) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethoddescribeMetadata, Fixture, methoddescribeMetadataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methoddescribeMetadataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (describeMetadata) (Return Type : DescribeMetadataResult) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_describeMetadata_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethoddescribeMetadata, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (describeMetadata) (Return Type : DescribeMetadataResult) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_describeMetadata_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethoddescribeMetadata, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OndescribeMetadataOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_OndescribeMetadataOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOndescribeMetadataOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOndescribeMetadataOperationCompleted, Fixture, methodOndescribeMetadataOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OndescribeMetadataOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndescribeMetadataOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOndescribeMetadataOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOndescribeMetadataOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOndescribeMetadataOperationCompleted, methodOndescribeMetadataOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_metadataServiceInstanceFixture, parametersOfOndescribeMetadataOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOndescribeMetadataOperationCompleted.ShouldNotBeNull();
            parametersOfOndescribeMetadataOperationCompleted.Length.ShouldBe(1);
            methodOndescribeMetadataOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOndescribeMetadataOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOndescribeMetadataOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndescribeMetadataOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndescribeMetadataOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOndescribeMetadataOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOndescribeMetadataOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_metadataServiceInstance, MethodOndescribeMetadataOperationCompleted, parametersOfOndescribeMetadataOperationCompleted, methodOndescribeMetadataOperationCompletedPrametersTypes);

            // Assert
            parametersOfOndescribeMetadataOperationCompleted.ShouldNotBeNull();
            parametersOfOndescribeMetadataOperationCompleted.Length.ShouldBe(1);
            methodOndescribeMetadataOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOndescribeMetadataOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOndescribeMetadataOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndescribeMetadataOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndescribeMetadataOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOndescribeMetadataOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OndescribeMetadataOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndescribeMetadataOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOndescribeMetadataOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOndescribeMetadataOperationCompleted, Fixture, methodOndescribeMetadataOperationCompletedPrametersTypes);

            // Assert
            methodOndescribeMetadataOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OndescribeMetadataOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OndescribeMetadataOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOndescribeMetadataOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (listMetadata) (Return Type : FileProperties[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_listMetadata_Method_Call_Internally(Type[] types)
        {
            var methodlistMetadataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodlistMetadata, Fixture, methodlistMetadataPrametersTypes);
        }

        #endregion

        #region Method Call : (listMetadata) (Return Type : FileProperties[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_listMetadata_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var queries = CreateType<ListMetadataQuery[]>();
            var asOfVersion = CreateType<double>();
            Action executeAction = null;

            // Act
            executeAction = () => _metadataServiceInstance.listMetadata(queries, asOfVersion);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (listMetadata) (Return Type : FileProperties[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_listMetadata_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var queries = CreateType<ListMetadataQuery[]>();
            var asOfVersion = CreateType<double>();
            var methodlistMetadataPrametersTypes = new Type[] { typeof(ListMetadataQuery[]), typeof(double) };
            object[] parametersOflistMetadata = { queries, asOfVersion };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodlistMetadata, methodlistMetadataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MetadataService, FileProperties[]>(_metadataServiceInstanceFixture, out exception1, parametersOflistMetadata);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MetadataService, FileProperties[]>(_metadataServiceInstance, MethodlistMetadata, parametersOflistMetadata, methodlistMetadataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOflistMetadata.ShouldNotBeNull();
            parametersOflistMetadata.Length.ShouldBe(2);
            methodlistMetadataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (listMetadata) (Return Type : FileProperties[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_listMetadata_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var queries = CreateType<ListMetadataQuery[]>();
            var asOfVersion = CreateType<double>();
            var methodlistMetadataPrametersTypes = new Type[] { typeof(ListMetadataQuery[]), typeof(double) };
            object[] parametersOflistMetadata = { queries, asOfVersion };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MetadataService, FileProperties[]>(_metadataServiceInstance, MethodlistMetadata, parametersOflistMetadata, methodlistMetadataPrametersTypes);

            // Assert
            parametersOflistMetadata.ShouldNotBeNull();
            parametersOflistMetadata.Length.ShouldBe(2);
            methodlistMetadataPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (listMetadata) (Return Type : FileProperties[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_listMetadata_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodlistMetadataPrametersTypes = new Type[] { typeof(ListMetadataQuery[]), typeof(double) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodlistMetadata, Fixture, methodlistMetadataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodlistMetadataPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (listMetadata) (Return Type : FileProperties[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_listMetadata_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodlistMetadataPrametersTypes = new Type[] { typeof(ListMetadataQuery[]), typeof(double) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodlistMetadata, Fixture, methodlistMetadataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodlistMetadataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (listMetadata) (Return Type : FileProperties[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_listMetadata_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodlistMetadata, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (listMetadata) (Return Type : FileProperties[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_listMetadata_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodlistMetadata, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnlistMetadataOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_OnlistMetadataOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOnlistMetadataOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOnlistMetadataOperationCompleted, Fixture, methodOnlistMetadataOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnlistMetadataOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnlistMetadataOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnlistMetadataOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnlistMetadataOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnlistMetadataOperationCompleted, methodOnlistMetadataOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_metadataServiceInstanceFixture, parametersOfOnlistMetadataOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnlistMetadataOperationCompleted.ShouldNotBeNull();
            parametersOfOnlistMetadataOperationCompleted.Length.ShouldBe(1);
            methodOnlistMetadataOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnlistMetadataOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnlistMetadataOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnlistMetadataOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnlistMetadataOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnlistMetadataOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnlistMetadataOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_metadataServiceInstance, MethodOnlistMetadataOperationCompleted, parametersOfOnlistMetadataOperationCompleted, methodOnlistMetadataOperationCompletedPrametersTypes);

            // Assert
            parametersOfOnlistMetadataOperationCompleted.ShouldNotBeNull();
            parametersOfOnlistMetadataOperationCompleted.Length.ShouldBe(1);
            methodOnlistMetadataOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnlistMetadataOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnlistMetadataOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnlistMetadataOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnlistMetadataOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnlistMetadataOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnlistMetadataOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnlistMetadataOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnlistMetadataOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOnlistMetadataOperationCompleted, Fixture, methodOnlistMetadataOperationCompletedPrametersTypes);

            // Assert
            methodOnlistMetadataOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnlistMetadataOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnlistMetadataOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnlistMetadataOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnretrieveOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_OnretrieveOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOnretrieveOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOnretrieveOperationCompleted, Fixture, methodOnretrieveOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnretrieveOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnretrieveOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnretrieveOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnretrieveOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnretrieveOperationCompleted, methodOnretrieveOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_metadataServiceInstanceFixture, parametersOfOnretrieveOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnretrieveOperationCompleted.ShouldNotBeNull();
            parametersOfOnretrieveOperationCompleted.Length.ShouldBe(1);
            methodOnretrieveOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnretrieveOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnretrieveOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnretrieveOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnretrieveOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnretrieveOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnretrieveOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_metadataServiceInstance, MethodOnretrieveOperationCompleted, parametersOfOnretrieveOperationCompleted, methodOnretrieveOperationCompletedPrametersTypes);

            // Assert
            parametersOfOnretrieveOperationCompleted.ShouldNotBeNull();
            parametersOfOnretrieveOperationCompleted.Length.ShouldBe(1);
            methodOnretrieveOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnretrieveOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnretrieveOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnretrieveOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnretrieveOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnretrieveOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnretrieveOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnretrieveOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnretrieveOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOnretrieveOperationCompleted, Fixture, methodOnretrieveOperationCompletedPrametersTypes);

            // Assert
            methodOnretrieveOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnretrieveOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnretrieveOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnretrieveOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnupdateOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_OnupdateOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOnupdateOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOnupdateOperationCompleted, Fixture, methodOnupdateOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnupdateOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnupdateOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnupdateOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnupdateOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnupdateOperationCompleted, methodOnupdateOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_metadataServiceInstanceFixture, parametersOfOnupdateOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnupdateOperationCompleted.ShouldNotBeNull();
            parametersOfOnupdateOperationCompleted.Length.ShouldBe(1);
            methodOnupdateOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnupdateOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnupdateOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnupdateOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnupdateOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnupdateOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnupdateOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_metadataServiceInstance, MethodOnupdateOperationCompleted, parametersOfOnupdateOperationCompleted, methodOnupdateOperationCompletedPrametersTypes);

            // Assert
            parametersOfOnupdateOperationCompleted.ShouldNotBeNull();
            parametersOfOnupdateOperationCompleted.Length.ShouldBe(1);
            methodOnupdateOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnupdateOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnupdateOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnupdateOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnupdateOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnupdateOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnupdateOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnupdateOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnupdateOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodOnupdateOperationCompleted, Fixture, methodOnupdateOperationCompletedPrametersTypes);

            // Assert
            methodOnupdateOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnupdateOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_OnupdateOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnupdateOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_MetadataService_IsLocalFileSystemWebService_Method_Call_Internally(Type[] types)
        {
            var methodIsLocalFileSystemWebServicePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodIsLocalFileSystemWebService, Fixture, methodIsLocalFileSystemWebServicePrametersTypes);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_IsLocalFileSystemWebService_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MetadataService, bool>(_metadataServiceInstanceFixture, out exception1, parametersOfIsLocalFileSystemWebService);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MetadataService, bool>(_metadataServiceInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

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
        public void AUT_MetadataService_IsLocalFileSystemWebService_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<MetadataService, bool>(_metadataServiceInstanceFixture, out exception1, parametersOfIsLocalFileSystemWebService);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<MetadataService, bool>(_metadataServiceInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

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
        public void AUT_MetadataService_IsLocalFileSystemWebService_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<MetadataService, bool>(_metadataServiceInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

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
        public void AUT_MetadataService_IsLocalFileSystemWebService_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_metadataServiceInstance, MethodIsLocalFileSystemWebService, Fixture, methodIsLocalFileSystemWebServicePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsLocalFileSystemWebServicePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_IsLocalFileSystemWebService_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_metadataServiceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_MetadataService_IsLocalFileSystemWebService_Method_Call_Parameters_Count_Verification_Test()
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