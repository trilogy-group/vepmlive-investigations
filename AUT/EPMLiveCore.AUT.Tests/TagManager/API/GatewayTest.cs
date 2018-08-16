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

namespace EPMLiveCore.TagManager.API
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.TagManager.API.Gateway" />)
    ///     and namespace <see cref="EPMLiveCore.TagManager.API"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class GatewayTest : AbstractBaseSetupTypedTest<Gateway>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Gateway) Initializer

        private const string MethodAddTagOrder = "AddTagOrder";
        private const string MethodGetTag = "GetTag";
        private const string MethodRegisterTag = "RegisterTag";
        private const string MethodRemoveTagOrder = "RemoveTagOrder";
        private Type _gatewayInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Gateway _gatewayInstance;
        private Gateway _gatewayInstanceFixture;

        #region General Initializer : Class (Gateway) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Gateway" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _gatewayInstanceType = typeof(Gateway);
            _gatewayInstanceFixture = Create(true);
            _gatewayInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Gateway)

        #region General Initializer : Class (Gateway) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="Gateway" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodAddTagOrder, 0)]
        [TestCase(MethodGetTag, 0)]
        [TestCase(MethodRegisterTag, 0)]
        [TestCase(MethodRemoveTagOrder, 0)]
        public void AUT_Gateway_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_gatewayInstanceFixture, 
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
        ///     Class (<see cref="Gateway" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Gateway_Is_Instance_Present_Test()
        {
            // Assert
            _gatewayInstanceType.ShouldNotBeNull();
            _gatewayInstance.ShouldNotBeNull();
            _gatewayInstanceFixture.ShouldNotBeNull();
            _gatewayInstance.ShouldBeAssignableTo<Gateway>();
            _gatewayInstanceFixture.ShouldBeAssignableTo<Gateway>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Gateway) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Gateway_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Gateway instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _gatewayInstanceType.ShouldNotBeNull();
            _gatewayInstance.ShouldNotBeNull();
            _gatewayInstanceFixture.ShouldNotBeNull();
            _gatewayInstance.ShouldBeAssignableTo<Gateway>();
            _gatewayInstanceFixture.ShouldBeAssignableTo<Gateway>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="Gateway" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodAddTagOrder)]
        [TestCase(MethodGetTag)]
        [TestCase(MethodRegisterTag)]
        [TestCase(MethodRemoveTagOrder)]
        public void AUT_Gateway_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<Gateway>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_AddTagOrder_Method_Call_Internally(Type[] types)
        {
            var methodAddTagOrderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodAddTagOrder, Fixture, methodAddTagOrderPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_AddTagOrder_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _gatewayInstance.AddTagOrder(data, spWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_AddTagOrder_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodAddTagOrderPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfAddTagOrder = { data, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddTagOrder, methodAddTagOrderPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Gateway, string>(_gatewayInstanceFixture, out exception1, parametersOfAddTagOrder);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Gateway, string>(_gatewayInstance, MethodAddTagOrder, parametersOfAddTagOrder, methodAddTagOrderPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddTagOrder.ShouldNotBeNull();
            parametersOfAddTagOrder.Length.ShouldBe(2);
            methodAddTagOrderPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_AddTagOrder_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodAddTagOrderPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfAddTagOrder = { data, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddTagOrder, methodAddTagOrderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gatewayInstanceFixture, parametersOfAddTagOrder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddTagOrder.ShouldNotBeNull();
            parametersOfAddTagOrder.Length.ShouldBe(2);
            methodAddTagOrderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_AddTagOrder_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodAddTagOrderPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfAddTagOrder = { data, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Gateway, string>(_gatewayInstance, MethodAddTagOrder, parametersOfAddTagOrder, methodAddTagOrderPrametersTypes);

            // Assert
            parametersOfAddTagOrder.ShouldNotBeNull();
            parametersOfAddTagOrder.Length.ShouldBe(2);
            methodAddTagOrderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_AddTagOrder_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodAddTagOrderPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodAddTagOrder, Fixture, methodAddTagOrderPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodAddTagOrderPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_AddTagOrder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTagOrderPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodAddTagOrder, Fixture, methodAddTagOrderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddTagOrderPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_AddTagOrder_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTagOrder, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gatewayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AddTagOrder) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_AddTagOrder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddTagOrder, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_GetTag_Method_Call_Internally(Type[] types)
        {
            var methodGetTagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodGetTag, Fixture, methodGetTagPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_GetTag_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _gatewayInstance.GetTag(data, spWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_GetTag_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodGetTagPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetTag = { data, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetTag, methodGetTagPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Gateway, string>(_gatewayInstanceFixture, out exception1, parametersOfGetTag);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Gateway, string>(_gatewayInstance, MethodGetTag, parametersOfGetTag, methodGetTagPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetTag.ShouldNotBeNull();
            parametersOfGetTag.Length.ShouldBe(2);
            methodGetTagPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_GetTag_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodGetTagPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetTag = { data, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetTag, methodGetTagPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gatewayInstanceFixture, parametersOfGetTag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetTag.ShouldNotBeNull();
            parametersOfGetTag.Length.ShouldBe(2);
            methodGetTagPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_GetTag_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodGetTagPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfGetTag = { data, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Gateway, string>(_gatewayInstance, MethodGetTag, parametersOfGetTag, methodGetTagPrametersTypes);

            // Assert
            parametersOfGetTag.ShouldNotBeNull();
            parametersOfGetTag.Length.ShouldBe(2);
            methodGetTagPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_GetTag_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodGetTagPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodGetTag, Fixture, methodGetTagPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetTagPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_GetTag_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTagPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodGetTag, Fixture, methodGetTagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTagPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_GetTag_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetTag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gatewayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetTag) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_GetTag_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTag, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_RegisterTag_Method_Call_Internally(Type[] types)
        {
            var methodRegisterTagPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodRegisterTag, Fixture, methodRegisterTagPrametersTypes);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RegisterTag_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _gatewayInstance.RegisterTag(data, spWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RegisterTag_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodRegisterTagPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfRegisterTag = { data, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRegisterTag, methodRegisterTagPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Gateway, string>(_gatewayInstanceFixture, out exception1, parametersOfRegisterTag);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Gateway, string>(_gatewayInstance, MethodRegisterTag, parametersOfRegisterTag, methodRegisterTagPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRegisterTag.ShouldNotBeNull();
            parametersOfRegisterTag.Length.ShouldBe(2);
            methodRegisterTagPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RegisterTag_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodRegisterTagPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfRegisterTag = { data, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRegisterTag, methodRegisterTagPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gatewayInstanceFixture, parametersOfRegisterTag);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRegisterTag.ShouldNotBeNull();
            parametersOfRegisterTag.Length.ShouldBe(2);
            methodRegisterTagPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RegisterTag_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodRegisterTagPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfRegisterTag = { data, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Gateway, string>(_gatewayInstance, MethodRegisterTag, parametersOfRegisterTag, methodRegisterTagPrametersTypes);

            // Assert
            parametersOfRegisterTag.ShouldNotBeNull();
            parametersOfRegisterTag.Length.ShouldBe(2);
            methodRegisterTagPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RegisterTag_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodRegisterTagPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodRegisterTag, Fixture, methodRegisterTagPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRegisterTagPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RegisterTag_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRegisterTagPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodRegisterTag, Fixture, methodRegisterTagPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRegisterTagPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RegisterTag_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRegisterTag, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gatewayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RegisterTag) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RegisterTag_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRegisterTag, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Gateway_RemoveTagOrder_Method_Call_Internally(Type[] types)
        {
            var methodRemoveTagOrderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodRemoveTagOrder, Fixture, methodRemoveTagOrderPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RemoveTagOrder_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            Action executeAction = null;

            // Act
            executeAction = () => _gatewayInstance.RemoveTagOrder(data, spWeb);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RemoveTagOrder_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodRemoveTagOrderPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfRemoveTagOrder = { data, spWeb };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodRemoveTagOrder, methodRemoveTagOrderPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<Gateway, string>(_gatewayInstanceFixture, out exception1, parametersOfRemoveTagOrder);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<Gateway, string>(_gatewayInstance, MethodRemoveTagOrder, parametersOfRemoveTagOrder, methodRemoveTagOrderPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfRemoveTagOrder.ShouldNotBeNull();
            parametersOfRemoveTagOrder.Length.ShouldBe(2);
            methodRemoveTagOrderPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RemoveTagOrder_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodRemoveTagOrderPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfRemoveTagOrder = { data, spWeb };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRemoveTagOrder, methodRemoveTagOrderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_gatewayInstanceFixture, parametersOfRemoveTagOrder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRemoveTagOrder.ShouldNotBeNull();
            parametersOfRemoveTagOrder.Length.ShouldBe(2);
            methodRemoveTagOrderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RemoveTagOrder_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var data = CreateType<string>();
            var spWeb = CreateType<SPWeb>();
            var methodRemoveTagOrderPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            object[] parametersOfRemoveTagOrder = { data, spWeb };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<Gateway, string>(_gatewayInstance, MethodRemoveTagOrder, parametersOfRemoveTagOrder, methodRemoveTagOrderPrametersTypes);

            // Assert
            parametersOfRemoveTagOrder.ShouldNotBeNull();
            parametersOfRemoveTagOrder.Length.ShouldBe(2);
            methodRemoveTagOrderPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RemoveTagOrder_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            var methodRemoveTagOrderPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodRemoveTagOrder, Fixture, methodRemoveTagOrderPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRemoveTagOrderPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RemoveTagOrder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRemoveTagOrderPrametersTypes = new Type[] { typeof(string), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_gatewayInstance, MethodRemoveTagOrder, Fixture, methodRemoveTagOrderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRemoveTagOrderPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RemoveTagOrder_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRemoveTagOrder, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_gatewayInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RemoveTagOrder) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Gateway_RemoveTagOrder_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRemoveTagOrder, 0);
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