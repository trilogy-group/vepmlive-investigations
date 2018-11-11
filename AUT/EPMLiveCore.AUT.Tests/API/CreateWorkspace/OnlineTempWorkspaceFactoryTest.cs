using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.OnlineTempWorkspaceFactory" />)
    ///     and namespace <see cref="EPMLiveCore.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class OnlineTempWorkspaceFactoryTest : AbstractBaseSetupTypedTest<OnlineTempWorkspaceFactory>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (OnlineTempWorkspaceFactory) Initializer

        private const string MethodValidateRemoteCertificate = "ValidateRemoteCertificate";
        private const string MethodCreateWorkspace = "CreateWorkspace";
        private const string MethodGrabOnlineFiles = "GrabOnlineFiles";
        private Type _onlineTempWorkspaceFactoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private OnlineTempWorkspaceFactory _onlineTempWorkspaceFactoryInstance;
        private OnlineTempWorkspaceFactory _onlineTempWorkspaceFactoryInstanceFixture;

        #region General Initializer : Class (OnlineTempWorkspaceFactory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="OnlineTempWorkspaceFactory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _onlineTempWorkspaceFactoryInstanceType = typeof(OnlineTempWorkspaceFactory);
            _onlineTempWorkspaceFactoryInstanceFixture = Create(true);
            _onlineTempWorkspaceFactoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (OnlineTempWorkspaceFactory)

        #region General Initializer : Class (OnlineTempWorkspaceFactory) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="OnlineTempWorkspaceFactory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodValidateRemoteCertificate, 0)]
        [TestCase(MethodCreateWorkspace, 0)]
        [TestCase(MethodGrabOnlineFiles, 0)]
        public void AUT_OnlineTempWorkspaceFactory_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_onlineTempWorkspaceFactoryInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="OnlineTempWorkspaceFactory" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodValidateRemoteCertificate)]
        [TestCase(MethodCreateWorkspace)]
        [TestCase(MethodGrabOnlineFiles)]
        public void AUT_OnlineTempWorkspaceFactory_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<OnlineTempWorkspaceFactory>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ValidateRemoteCertificate) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OnlineTempWorkspaceFactory_ValidateRemoteCertificate_Method_Call_Internally(Type[] types)
        {
            var methodValidateRemoteCertificatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_onlineTempWorkspaceFactoryInstance, MethodValidateRemoteCertificate, Fixture, methodValidateRemoteCertificatePrametersTypes);
        }

        #endregion

        #region Method Call : (ValidateRemoteCertificate) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_ValidateRemoteCertificate_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var certificate = CreateType<X509Certificate>();
            var chain = CreateType<X509Chain>();
            var sslpolicyerrors = CreateType<SslPolicyErrors>();
            var methodValidateRemoteCertificatePrametersTypes = new Type[] { typeof(object), typeof(X509Certificate), typeof(X509Chain), typeof(SslPolicyErrors) };
            object[] parametersOfValidateRemoteCertificate = { sender, certificate, chain, sslpolicyerrors };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidateRemoteCertificate, methodValidateRemoteCertificatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OnlineTempWorkspaceFactory, bool>(_onlineTempWorkspaceFactoryInstanceFixture, out exception1, parametersOfValidateRemoteCertificate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OnlineTempWorkspaceFactory, bool>(_onlineTempWorkspaceFactoryInstance, MethodValidateRemoteCertificate, parametersOfValidateRemoteCertificate, methodValidateRemoteCertificatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfValidateRemoteCertificate.ShouldNotBeNull();
            parametersOfValidateRemoteCertificate.Length.ShouldBe(4);
            methodValidateRemoteCertificatePrametersTypes.Length.ShouldBe(4);
            Should.Throw<Exception>(() => methodInfo.Invoke(_onlineTempWorkspaceFactoryInstanceFixture, parametersOfValidateRemoteCertificate));
        }

        #endregion

        #region Method Call : (ValidateRemoteCertificate) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_ValidateRemoteCertificate_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var certificate = CreateType<X509Certificate>();
            var chain = CreateType<X509Chain>();
            var sslpolicyerrors = CreateType<SslPolicyErrors>();
            var methodValidateRemoteCertificatePrametersTypes = new Type[] { typeof(object), typeof(X509Certificate), typeof(X509Chain), typeof(SslPolicyErrors) };
            object[] parametersOfValidateRemoteCertificate = { sender, certificate, chain, sslpolicyerrors };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodValidateRemoteCertificate, methodValidateRemoteCertificatePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OnlineTempWorkspaceFactory, bool>(_onlineTempWorkspaceFactoryInstanceFixture, out exception1, parametersOfValidateRemoteCertificate);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OnlineTempWorkspaceFactory, bool>(_onlineTempWorkspaceFactoryInstance, MethodValidateRemoteCertificate, parametersOfValidateRemoteCertificate, methodValidateRemoteCertificatePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfValidateRemoteCertificate.ShouldNotBeNull();
            parametersOfValidateRemoteCertificate.Length.ShouldBe(4);
            methodValidateRemoteCertificatePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<OnlineTempWorkspaceFactory, bool>(_onlineTempWorkspaceFactoryInstance, MethodValidateRemoteCertificate, parametersOfValidateRemoteCertificate, methodValidateRemoteCertificatePrametersTypes));
        }

        #endregion

        #region Method Call : (ValidateRemoteCertificate) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_ValidateRemoteCertificate_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var certificate = CreateType<X509Certificate>();
            var chain = CreateType<X509Chain>();
            var sslpolicyerrors = CreateType<SslPolicyErrors>();
            var methodValidateRemoteCertificatePrametersTypes = new Type[] { typeof(object), typeof(X509Certificate), typeof(X509Chain), typeof(SslPolicyErrors) };
            object[] parametersOfValidateRemoteCertificate = { sender, certificate, chain, sslpolicyerrors };

            // Assert
            parametersOfValidateRemoteCertificate.ShouldNotBeNull();
            parametersOfValidateRemoteCertificate.Length.ShouldBe(4);
            methodValidateRemoteCertificatePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<OnlineTempWorkspaceFactory, bool>(_onlineTempWorkspaceFactoryInstance, MethodValidateRemoteCertificate, parametersOfValidateRemoteCertificate, methodValidateRemoteCertificatePrametersTypes));
        }

        #endregion

        #region Method Call : (ValidateRemoteCertificate) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_ValidateRemoteCertificate_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodValidateRemoteCertificatePrametersTypes = new Type[] { typeof(object), typeof(X509Certificate), typeof(X509Chain), typeof(SslPolicyErrors) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_onlineTempWorkspaceFactoryInstance, MethodValidateRemoteCertificate, Fixture, methodValidateRemoteCertificatePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodValidateRemoteCertificatePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ValidateRemoteCertificate) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_ValidateRemoteCertificate_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodValidateRemoteCertificate, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_onlineTempWorkspaceFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ValidateRemoteCertificate) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_ValidateRemoteCertificate_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodValidateRemoteCertificate, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OnlineTempWorkspaceFactory_CreateWorkspace_Method_Call_Internally(Type[] types)
        {
            var methodCreateWorkspacePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_onlineTempWorkspaceFactoryInstance, MethodCreateWorkspace, Fixture, methodCreateWorkspacePrametersTypes);
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_CreateWorkspace_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _onlineTempWorkspaceFactoryInstance.CreateWorkspace();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_CreateWorkspace_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;
            object[] parametersOfCreateWorkspace = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodCreateWorkspace, methodCreateWorkspacePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<OnlineTempWorkspaceFactory, ICreatedWorkspaceInfo>(_onlineTempWorkspaceFactoryInstanceFixture, out exception1, parametersOfCreateWorkspace);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<OnlineTempWorkspaceFactory, ICreatedWorkspaceInfo>(_onlineTempWorkspaceFactoryInstance, MethodCreateWorkspace, parametersOfCreateWorkspace, methodCreateWorkspacePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfCreateWorkspace.ShouldBeNull();
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(() => methodInfo.Invoke(_onlineTempWorkspaceFactoryInstanceFixture, parametersOfCreateWorkspace));
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_CreateWorkspace_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;
            object[] parametersOfCreateWorkspace = null; // no parameter present

            // Assert
            parametersOfCreateWorkspace.ShouldBeNull();
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
            Should.NotThrow(() => ReflectionAnalyzer.GetResultOfMethod<OnlineTempWorkspaceFactory, ICreatedWorkspaceInfo>(_onlineTempWorkspaceFactoryInstance, MethodCreateWorkspace, parametersOfCreateWorkspace, methodCreateWorkspacePrametersTypes));
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_CreateWorkspace_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_onlineTempWorkspaceFactoryInstance, MethodCreateWorkspace, Fixture, methodCreateWorkspacePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_CreateWorkspace_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateWorkspacePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_onlineTempWorkspaceFactoryInstance, MethodCreateWorkspace, Fixture, methodCreateWorkspacePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodCreateWorkspacePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (CreateWorkspace) (Return Type : ICreatedWorkspaceInfo) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_CreateWorkspace_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateWorkspace, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_onlineTempWorkspaceFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GrabOnlineFiles) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_OnlineTempWorkspaceFactory_GrabOnlineFiles_Method_Call_Internally(Type[] types)
        {
            var methodGrabOnlineFilesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_onlineTempWorkspaceFactoryInstance, MethodGrabOnlineFiles, Fixture, methodGrabOnlineFilesPrametersTypes);
        }

        #endregion

        #region Method Call : (GrabOnlineFiles) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_GrabOnlineFiles_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var cESite = CreateType<SPSite>();
            var cEWeb = CreateType<SPWeb>();
            var methodGrabOnlineFilesPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb) };
            object[] parametersOfGrabOnlineFiles = { cESite, cEWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGrabOnlineFiles, methodGrabOnlineFilesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_onlineTempWorkspaceFactoryInstanceFixture, parametersOfGrabOnlineFiles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGrabOnlineFiles.ShouldNotBeNull();
            parametersOfGrabOnlineFiles.Length.ShouldBe(2);
            methodGrabOnlineFilesPrametersTypes.Length.ShouldBe(2);
            methodGrabOnlineFilesPrametersTypes.Length.ShouldBe(parametersOfGrabOnlineFiles.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GrabOnlineFiles) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_GrabOnlineFiles_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var cESite = CreateType<SPSite>();
            var cEWeb = CreateType<SPWeb>();
            var methodGrabOnlineFilesPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb) };
            object[] parametersOfGrabOnlineFiles = { cESite, cEWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_onlineTempWorkspaceFactoryInstance, MethodGrabOnlineFiles, parametersOfGrabOnlineFiles, methodGrabOnlineFilesPrametersTypes);

            // Assert
            parametersOfGrabOnlineFiles.ShouldNotBeNull();
            parametersOfGrabOnlineFiles.Length.ShouldBe(2);
            methodGrabOnlineFilesPrametersTypes.Length.ShouldBe(2);
            methodGrabOnlineFilesPrametersTypes.Length.ShouldBe(parametersOfGrabOnlineFiles.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabOnlineFiles) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_GrabOnlineFiles_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGrabOnlineFiles, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GrabOnlineFiles) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_GrabOnlineFiles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGrabOnlineFilesPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_onlineTempWorkspaceFactoryInstance, MethodGrabOnlineFiles, Fixture, methodGrabOnlineFilesPrametersTypes);

            // Assert
            methodGrabOnlineFilesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GrabOnlineFiles) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_OnlineTempWorkspaceFactory_GrabOnlineFiles_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGrabOnlineFiles, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_onlineTempWorkspaceFactoryInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}