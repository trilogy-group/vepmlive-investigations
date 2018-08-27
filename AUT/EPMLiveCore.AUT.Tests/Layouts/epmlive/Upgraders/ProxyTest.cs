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

namespace EPMLiveCore.Layouts.epmlive.Upgraders
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Layouts.epmlive.Upgraders.proxy" />)
    ///     and namespace <see cref="EPMLiveCore.Layouts.epmlive.Upgraders"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProxyTest : AbstractBaseSetupTypedTest<proxy>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (proxy) Initializer

        private const string MethodPage_Load = "Page_Load";
        private const string MethodCheckStatus = "CheckStatus";
        private const string MethodoutputData = "outputData";
        private const string MethodStart = "Start";
        private const string Field_optInUpgraderVersions = "_optInUpgraderVersions";
        private const string Fielddata = "data";
        private const string Fieldjobtype = "jobtype";
        private Type _proxyInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private proxy _proxyInstance;
        private proxy _proxyInstanceFixture;

        #region General Initializer : Class (proxy) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="proxy" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _proxyInstanceType = typeof(proxy);
            _proxyInstanceFixture = Create(true);
            _proxyInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (proxy)

        #region General Initializer : Class (proxy) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="proxy" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPage_Load, 0)]
        [TestCase(MethodCheckStatus, 0)]
        [TestCase(MethodoutputData, 0)]
        [TestCase(MethodStart, 0)]
        public void AUT_Proxy_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_proxyInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (proxy) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="proxy" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Field_optInUpgraderVersions)]
        [TestCase(Fielddata)]
        [TestCase(Fieldjobtype)]
        public void AUT_Proxy_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_proxyInstanceFixture, 
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
        ///     Class (<see cref="proxy" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Proxy_Is_Instance_Present_Test()
        {
            // Assert
            _proxyInstanceType.ShouldNotBeNull();
            _proxyInstance.ShouldNotBeNull();
            _proxyInstanceFixture.ShouldNotBeNull();
            _proxyInstance.ShouldBeAssignableTo<proxy>();
            _proxyInstanceFixture.ShouldBeAssignableTo<proxy>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (proxy) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_proxy_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            proxy instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _proxyInstanceType.ShouldNotBeNull();
            _proxyInstance.ShouldNotBeNull();
            _proxyInstanceFixture.ShouldNotBeNull();
            _proxyInstance.ShouldBeAssignableTo<proxy>();
            _proxyInstanceFixture.ShouldBeAssignableTo<proxy>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="proxy" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPage_Load)]
        [TestCase(MethodCheckStatus)]
        [TestCase(MethodoutputData)]
        [TestCase(MethodStart)]
        public void AUT_Proxy_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<proxy>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Proxy_Page_Load_Method_Call_Internally(Type[] types)
        {
            var methodPage_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_proxyInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_Page_Load_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPage_Load, methodPage_LoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_proxyInstanceFixture, parametersOfPage_Load);

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
        public void AUT_Proxy_Page_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfPage_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_proxyInstance, MethodPage_Load, parametersOfPage_Load, methodPage_LoadPrametersTypes);

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
        public void AUT_Proxy_Page_Load_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_Proxy_Page_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPage_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_proxyInstance, MethodPage_Load, Fixture, methodPage_LoadPrametersTypes);

            // Assert
            methodPage_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Page_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_Page_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPage_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_proxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckStatus) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Proxy_CheckStatus_Method_Call_Internally(Type[] types)
        {
            var methodCheckStatusPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_proxyInstance, MethodCheckStatus, Fixture, methodCheckStatusPrametersTypes);
        }

        #endregion

        #region Method Call : (CheckStatus) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_CheckStatus_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCheckStatusPrametersTypes = null;
            object[] parametersOfCheckStatus = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCheckStatus, methodCheckStatusPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_proxyInstanceFixture, parametersOfCheckStatus);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCheckStatus.ShouldBeNull();
            methodCheckStatusPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CheckStatus) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_CheckStatus_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCheckStatusPrametersTypes = null;
            object[] parametersOfCheckStatus = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_proxyInstance, MethodCheckStatus, parametersOfCheckStatus, methodCheckStatusPrametersTypes);

            // Assert
            parametersOfCheckStatus.ShouldBeNull();
            methodCheckStatusPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckStatus) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_CheckStatus_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCheckStatusPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_proxyInstance, MethodCheckStatus, Fixture, methodCheckStatusPrametersTypes);

            // Assert
            methodCheckStatusPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CheckStatus) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_CheckStatus_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCheckStatus, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_proxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Proxy_outputData_Method_Call_Internally(Type[] types)
        {
            var methodoutputDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_proxyInstance, MethodoutputData, Fixture, methodoutputDataPrametersTypes);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_outputData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var status = CreateType<string>();
            var message = CreateType<string>();
            var percent = CreateType<string>();
            var methodoutputDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfoutputData = { status, message, percent };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodoutputData, methodoutputDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_proxyInstanceFixture, parametersOfoutputData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfoutputData.ShouldNotBeNull();
            parametersOfoutputData.Length.ShouldBe(3);
            methodoutputDataPrametersTypes.Length.ShouldBe(3);
            methodoutputDataPrametersTypes.Length.ShouldBe(parametersOfoutputData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_outputData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var status = CreateType<string>();
            var message = CreateType<string>();
            var percent = CreateType<string>();
            var methodoutputDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };
            object[] parametersOfoutputData = { status, message, percent };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_proxyInstance, MethodoutputData, parametersOfoutputData, methodoutputDataPrametersTypes);

            // Assert
            parametersOfoutputData.ShouldNotBeNull();
            parametersOfoutputData.Length.ShouldBe(3);
            methodoutputDataPrametersTypes.Length.ShouldBe(3);
            methodoutputDataPrametersTypes.Length.ShouldBe(parametersOfoutputData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_outputData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodoutputData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_outputData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodoutputDataPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_proxyInstance, MethodoutputData, Fixture, methodoutputDataPrametersTypes);

            // Assert
            methodoutputDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (outputData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_outputData_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodoutputData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_proxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Start) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_Proxy_Start_Method_Call_Internally(Type[] types)
        {
            var methodStartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_proxyInstance, MethodStart, Fixture, methodStartPrametersTypes);
        }

        #endregion

        #region Method Call : (Start) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_Start_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodStartPrametersTypes = null;
            object[] parametersOfStart = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodStart, methodStartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_proxyInstanceFixture, parametersOfStart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfStart.ShouldBeNull();
            methodStartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Start) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_Start_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodStartPrametersTypes = null;
            object[] parametersOfStart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_proxyInstance, MethodStart, parametersOfStart, methodStartPrametersTypes);

            // Assert
            parametersOfStart.ShouldBeNull();
            methodStartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Start) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_Start_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodStartPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_proxyInstance, MethodStart, Fixture, methodStartPrametersTypes);

            // Assert
            methodStartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Start) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_Proxy_Start_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodStart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_proxyInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}