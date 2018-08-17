using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SocialEngine.Events.WebEventReceiver
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SocialEngine.Events.WebEventReceiver.WebEventReceiver" />)
    ///     and namespace <see cref="EPMLiveCore.SocialEngine.Events.WebEventReceiver"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WebEventReceiverTest : AbstractBaseSetupTypedTest<WebEventReceiver>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WebEventReceiver) Initializer

        private const string MethodWebDeleting = "WebDeleting";
        private const string MethodWebProvisioned = "WebProvisioned";
        private Type _webEventReceiverInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WebEventReceiver _webEventReceiverInstance;
        private WebEventReceiver _webEventReceiverInstanceFixture;

        #region General Initializer : Class (WebEventReceiver) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WebEventReceiver" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _webEventReceiverInstanceType = typeof(WebEventReceiver);
            _webEventReceiverInstanceFixture = Create(true);
            _webEventReceiverInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WebEventReceiver)

        #region General Initializer : Class (WebEventReceiver) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WebEventReceiver" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodWebDeleting, 0)]
        [TestCase(MethodWebProvisioned, 0)]
        public void AUT_WebEventReceiver_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_webEventReceiverInstanceFixture, 
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
        ///     Class (<see cref="WebEventReceiver" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WebEventReceiver_Is_Instance_Present_Test()
        {
            // Assert
            _webEventReceiverInstanceType.ShouldNotBeNull();
            _webEventReceiverInstance.ShouldNotBeNull();
            _webEventReceiverInstanceFixture.ShouldNotBeNull();
            _webEventReceiverInstance.ShouldBeAssignableTo<WebEventReceiver>();
            _webEventReceiverInstanceFixture.ShouldBeAssignableTo<WebEventReceiver>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WebEventReceiver) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_WebEventReceiver_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WebEventReceiver instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _webEventReceiverInstanceType.ShouldNotBeNull();
            _webEventReceiverInstance.ShouldNotBeNull();
            _webEventReceiverInstanceFixture.ShouldNotBeNull();
            _webEventReceiverInstance.ShouldBeAssignableTo<WebEventReceiver>();
            _webEventReceiverInstanceFixture.ShouldBeAssignableTo<WebEventReceiver>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WebEventReceiver" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodWebDeleting)]
        [TestCase(MethodWebProvisioned)]
        public void AUT_WebEventReceiver_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WebEventReceiver>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebEventReceiver_WebDeleting_Method_Call_Internally(Type[] types)
        {
            var methodWebDeletingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webEventReceiverInstance, MethodWebDeleting, Fixture, methodWebDeletingPrametersTypes);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebDeleting_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPWebEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _webEventReceiverInstance.WebDeleting(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPWebEventProperties>();
            var methodWebDeletingPrametersTypes = new Type[] { typeof(SPWebEventProperties) };
            object[] parametersOfWebDeleting = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWebDeleting, methodWebDeletingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webEventReceiverInstanceFixture, parametersOfWebDeleting);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWebDeleting.ShouldNotBeNull();
            parametersOfWebDeleting.Length.ShouldBe(1);
            methodWebDeletingPrametersTypes.Length.ShouldBe(1);
            methodWebDeletingPrametersTypes.Length.ShouldBe(parametersOfWebDeleting.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebDeleting_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPWebEventProperties>();
            var methodWebDeletingPrametersTypes = new Type[] { typeof(SPWebEventProperties) };
            object[] parametersOfWebDeleting = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_webEventReceiverInstance, MethodWebDeleting, parametersOfWebDeleting, methodWebDeletingPrametersTypes);

            // Assert
            parametersOfWebDeleting.ShouldNotBeNull();
            parametersOfWebDeleting.Length.ShouldBe(1);
            methodWebDeletingPrametersTypes.Length.ShouldBe(1);
            methodWebDeletingPrametersTypes.Length.ShouldBe(parametersOfWebDeleting.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebDeleting_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWebDeleting, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebDeleting_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWebDeletingPrametersTypes = new Type[] { typeof(SPWebEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webEventReceiverInstance, MethodWebDeleting, Fixture, methodWebDeletingPrametersTypes);

            // Assert
            methodWebDeletingPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebDeleting) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebDeleting_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWebDeleting, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_webEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebProvisioned) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WebEventReceiver_WebProvisioned_Method_Call_Internally(Type[] types)
        {
            var methodWebProvisionedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webEventReceiverInstance, MethodWebProvisioned, Fixture, methodWebProvisionedPrametersTypes);
        }

        #endregion

        #region Method Call : (WebProvisioned) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebProvisioned_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPWebEventProperties>();
            Action executeAction = null;

            // Act
            executeAction = () => _webEventReceiverInstance.WebProvisioned(properties);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (WebProvisioned) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebProvisioned_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var properties = CreateType<SPWebEventProperties>();
            var methodWebProvisionedPrametersTypes = new Type[] { typeof(SPWebEventProperties) };
            object[] parametersOfWebProvisioned = { properties };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWebProvisioned, methodWebProvisionedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_webEventReceiverInstanceFixture, parametersOfWebProvisioned);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWebProvisioned.ShouldNotBeNull();
            parametersOfWebProvisioned.Length.ShouldBe(1);
            methodWebProvisionedPrametersTypes.Length.ShouldBe(1);
            methodWebProvisionedPrametersTypes.Length.ShouldBe(parametersOfWebProvisioned.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebProvisioned) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebProvisioned_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var properties = CreateType<SPWebEventProperties>();
            var methodWebProvisionedPrametersTypes = new Type[] { typeof(SPWebEventProperties) };
            object[] parametersOfWebProvisioned = { properties };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_webEventReceiverInstance, MethodWebProvisioned, parametersOfWebProvisioned, methodWebProvisionedPrametersTypes);

            // Assert
            parametersOfWebProvisioned.ShouldNotBeNull();
            parametersOfWebProvisioned.Length.ShouldBe(1);
            methodWebProvisionedPrametersTypes.Length.ShouldBe(1);
            methodWebProvisionedPrametersTypes.Length.ShouldBe(parametersOfWebProvisioned.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebProvisioned) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebProvisioned_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWebProvisioned, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WebProvisioned) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebProvisioned_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWebProvisionedPrametersTypes = new Type[] { typeof(SPWebEventProperties) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_webEventReceiverInstance, MethodWebProvisioned, Fixture, methodWebProvisionedPrametersTypes);

            // Assert
            methodWebProvisionedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WebProvisioned) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_WebEventReceiver_WebProvisioned_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWebProvisioned, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_webEventReceiverInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}