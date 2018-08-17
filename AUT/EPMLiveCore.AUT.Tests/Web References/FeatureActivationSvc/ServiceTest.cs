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

namespace EPMLiveCore.FeatureActivationSvc
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.FeatureActivationSvc.Service" />)
    ///     and namespace <see cref="EPMLiveCore.FeatureActivationSvc"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ServiceTest : AbstractBaseSetupTypedTest<Service>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Service) Initializer

        private const string PropertyUrl = "Url";
        private const string PropertyUseDefaultCredentials = "UseDefaultCredentials";
        private const string MethodActivateKey = "ActivateKey";
        private const string MethodActivateKeyAsync = "ActivateKeyAsync";
        private const string MethodOnActivateKeyOperationCompleted = "OnActivateKeyOperationCompleted";
        private const string MethodCancelAsync = "CancelAsync";
        private const string MethodIsLocalFileSystemWebService = "IsLocalFileSystemWebService";
        private const string FieldActivateKeyOperationCompleted = "ActivateKeyOperationCompleted";
        private const string FielduseDefaultCredentialsSetExplicitly = "useDefaultCredentialsSetExplicitly";
        private Type _serviceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Service _serviceInstance;
        private Service _serviceInstanceFixture;

        #region General Initializer : Class (Service) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Service" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _serviceInstanceType = typeof(Service);
            _serviceInstanceFixture = Create(true);
            _serviceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Service)

        #region General Initializer : Class (Service) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Service" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodActivateKey, 0)]
        [TestCase(MethodOnActivateKeyOperationCompleted, 0)]
        [TestCase(MethodIsLocalFileSystemWebService, 0)]
        public void AUT_Service_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_serviceInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Service) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Service" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyUrl)]
        [TestCase(PropertyUseDefaultCredentials)]
        public void AUT_Service_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_serviceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Service) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Service" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldActivateKeyOperationCompleted)]
        [TestCase(FielduseDefaultCredentialsSetExplicitly)]
        public void AUT_Service_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_serviceInstanceFixture, 
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
        ///     Class (<see cref="Service" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Service_Is_Instance_Present_Test()
        {
            // Assert
            _serviceInstanceType.ShouldNotBeNull();
            _serviceInstance.ShouldNotBeNull();
            _serviceInstanceFixture.ShouldNotBeNull();
            _serviceInstance.ShouldBeAssignableTo<Service>();
            _serviceInstanceFixture.ShouldBeAssignableTo<Service>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Service) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Service_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Service instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _serviceInstanceType.ShouldNotBeNull();
            _serviceInstance.ShouldNotBeNull();
            _serviceInstanceFixture.ShouldNotBeNull();
            _serviceInstance.ShouldBeAssignableTo<Service>();
            _serviceInstanceFixture.ShouldBeAssignableTo<Service>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Service) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyUrl)]
        [TestCaseGeneric(typeof(bool) , PropertyUseDefaultCredentials)]
        public void AUT_Service_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Service, T>(_serviceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Service) => Property (Url) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Service_Public_Class_Url_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Service) => Property (UseDefaultCredentials) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Service_Public_Class_UseDefaultCredentials_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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
        ///      Class (<see cref="Service" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodActivateKey)]
        [TestCase(MethodOnActivateKeyOperationCompleted)]
        [TestCase(MethodIsLocalFileSystemWebService)]
        public void AUT_Service_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Service>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ActivateKey) (Return Type : int) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Service_ActivateKey_Method_Call_Internally(Type[] types)
        {
            var methodActivateKeyPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceInstance, MethodActivateKey, Fixture, methodActivateKeyPrametersTypes);
        }

        #endregion
        
        #region Method Call : (ActivateKey) (Return Type : int) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_ActivateKey_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodActivateKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfActivateKey = { key };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodActivateKey, methodActivateKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Service, int>(_serviceInstanceFixture, out exception1, parametersOfActivateKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Service, int>(_serviceInstance, MethodActivateKey, parametersOfActivateKey, methodActivateKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfActivateKey.ShouldNotBeNull();
            parametersOfActivateKey.Length.ShouldBe(1);
            methodActivateKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ActivateKey) (Return Type : int) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_ActivateKey_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodActivateKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfActivateKey = { key };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodActivateKey, methodActivateKeyPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Service, int>(_serviceInstanceFixture, out exception1, parametersOfActivateKey);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Service, int>(_serviceInstance, MethodActivateKey, parametersOfActivateKey, methodActivateKeyPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfActivateKey.ShouldNotBeNull();
            parametersOfActivateKey.Length.ShouldBe(1);
            methodActivateKeyPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (ActivateKey) (Return Type : int) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_ActivateKey_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var key = CreateType<string>();
            var methodActivateKeyPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfActivateKey = { key };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Service, int>(_serviceInstance, MethodActivateKey, parametersOfActivateKey, methodActivateKeyPrametersTypes);

            // Assert
            parametersOfActivateKey.ShouldNotBeNull();
            parametersOfActivateKey.Length.ShouldBe(1);
            methodActivateKeyPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ActivateKey) (Return Type : int) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_ActivateKey_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodActivateKeyPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceInstance, MethodActivateKey, Fixture, methodActivateKeyPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodActivateKeyPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (ActivateKey) (Return Type : int) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_ActivateKey_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodActivateKey, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnActivateKeyOperationCompleted) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Service_OnActivateKeyOperationCompleted_Method_Call_Internally(Type[] types)
        {
            var methodOnActivateKeyOperationCompletedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceInstance, MethodOnActivateKeyOperationCompleted, Fixture, methodOnActivateKeyOperationCompletedPrametersTypes);
        }

        #endregion

        #region Method Call : (OnActivateKeyOperationCompleted) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_OnActivateKeyOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnActivateKeyOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnActivateKeyOperationCompleted = { arg };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnActivateKeyOperationCompleted, methodOnActivateKeyOperationCompletedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_serviceInstanceFixture, parametersOfOnActivateKeyOperationCompleted);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnActivateKeyOperationCompleted.ShouldNotBeNull();
            parametersOfOnActivateKeyOperationCompleted.Length.ShouldBe(1);
            methodOnActivateKeyOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnActivateKeyOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnActivateKeyOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnActivateKeyOperationCompleted) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_OnActivateKeyOperationCompleted_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var arg = CreateType<object>();
            var methodOnActivateKeyOperationCompletedPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfOnActivateKeyOperationCompleted = { arg };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_serviceInstance, MethodOnActivateKeyOperationCompleted, parametersOfOnActivateKeyOperationCompleted, methodOnActivateKeyOperationCompletedPrametersTypes);

            // Assert
            parametersOfOnActivateKeyOperationCompleted.ShouldNotBeNull();
            parametersOfOnActivateKeyOperationCompleted.Length.ShouldBe(1);
            methodOnActivateKeyOperationCompletedPrametersTypes.Length.ShouldBe(1);
            methodOnActivateKeyOperationCompletedPrametersTypes.Length.ShouldBe(parametersOfOnActivateKeyOperationCompleted.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnActivateKeyOperationCompleted) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_OnActivateKeyOperationCompleted_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnActivateKeyOperationCompleted, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnActivateKeyOperationCompleted) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_OnActivateKeyOperationCompleted_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnActivateKeyOperationCompletedPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceInstance, MethodOnActivateKeyOperationCompleted, Fixture, methodOnActivateKeyOperationCompletedPrametersTypes);

            // Assert
            methodOnActivateKeyOperationCompletedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnActivateKeyOperationCompleted) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_OnActivateKeyOperationCompleted_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnActivateKeyOperationCompleted, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Service_IsLocalFileSystemWebService_Method_Call_Internally(Type[] types)
        {
            var methodIsLocalFileSystemWebServicePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceInstance, MethodIsLocalFileSystemWebService, Fixture, methodIsLocalFileSystemWebServicePrametersTypes);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_IsLocalFileSystemWebService_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Service, bool>(_serviceInstanceFixture, out exception1, parametersOfIsLocalFileSystemWebService);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Service, bool>(_serviceInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

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
        public void AUT_Service_IsLocalFileSystemWebService_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Service, bool>(_serviceInstanceFixture, out exception1, parametersOfIsLocalFileSystemWebService);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Service, bool>(_serviceInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

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
        public void AUT_Service_IsLocalFileSystemWebService_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var url = CreateType<string>();
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLocalFileSystemWebService = { url };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Service, bool>(_serviceInstance, MethodIsLocalFileSystemWebService, parametersOfIsLocalFileSystemWebService, methodIsLocalFileSystemWebServicePrametersTypes);

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
        public void AUT_Service_IsLocalFileSystemWebService_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsLocalFileSystemWebServicePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_serviceInstance, MethodIsLocalFileSystemWebService, Fixture, methodIsLocalFileSystemWebServicePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsLocalFileSystemWebServicePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_IsLocalFileSystemWebService_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsLocalFileSystemWebService, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_serviceInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLocalFileSystemWebService) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_Service_IsLocalFileSystemWebService_Method_Call_Parameters_Count_Verification_Test()
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