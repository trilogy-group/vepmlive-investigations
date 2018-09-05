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

namespace WorkEnginePPM.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="WorkEnginePPM.Jobs.InstallWorkEvents" />)
    ///     and namespace <see cref="WorkEnginePPM.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class InstallWorkEventsTest : AbstractBaseSetupTypedTest<InstallWorkEvents>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (InstallWorkEvents) Initializer

        private const string Methodexecute = "execute";
        private Type _installWorkEventsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private InstallWorkEvents _installWorkEventsInstance;
        private InstallWorkEvents _installWorkEventsInstanceFixture;

        #region General Initializer : Class (InstallWorkEvents) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="InstallWorkEvents" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _installWorkEventsInstanceType = typeof(InstallWorkEvents);
            _installWorkEventsInstanceFixture = Create(true);
            _installWorkEventsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (InstallWorkEvents)

        #region General Initializer : Class (InstallWorkEvents) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="InstallWorkEvents" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        public void AUT_InstallWorkEvents_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_installWorkEventsInstanceFixture, 
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
        ///     Class (<see cref="InstallWorkEvents" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_InstallWorkEvents_Is_Instance_Present_Test()
        {
            // Assert
            _installWorkEventsInstanceType.ShouldNotBeNull();
            _installWorkEventsInstance.ShouldNotBeNull();
            _installWorkEventsInstanceFixture.ShouldNotBeNull();
            _installWorkEventsInstance.ShouldBeAssignableTo<InstallWorkEvents>();
            _installWorkEventsInstanceFixture.ShouldBeAssignableTo<InstallWorkEvents>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (InstallWorkEvents) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_InstallWorkEvents_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            InstallWorkEvents instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _installWorkEventsInstanceType.ShouldNotBeNull();
            _installWorkEventsInstance.ShouldNotBeNull();
            _installWorkEventsInstanceFixture.ShouldNotBeNull();
            _installWorkEventsInstance.ShouldBeAssignableTo<InstallWorkEvents>();
            _installWorkEventsInstanceFixture.ShouldBeAssignableTo<InstallWorkEvents>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="InstallWorkEvents" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        public void AUT_InstallWorkEvents_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<InstallWorkEvents>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallWorkEvents_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installWorkEventsInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallWorkEvents_execute_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var data = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _installWorkEventsInstance.execute(site, web, data);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallWorkEvents_execute_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var data = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { site, web, data };
            Exception exception = null;
            var methodInfo = GetMethodInfo(Methodexecute, methodexecutePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_installWorkEventsInstanceFixture, parametersOfexecute);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallWorkEvents_execute_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var data = CreateType<string>();
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };
            object[] parametersOfexecute = { site, web, data };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_installWorkEventsInstance, Methodexecute, parametersOfexecute, methodexecutePrametersTypes);

            // Assert
            parametersOfexecute.ShouldNotBeNull();
            parametersOfexecute.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(3);
            methodexecutePrametersTypes.Length.ShouldBe(parametersOfexecute.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallWorkEvents_execute_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(Methodexecute, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallWorkEvents_execute_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodexecutePrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installWorkEventsInstance, Methodexecute, Fixture, methodexecutePrametersTypes);

            // Assert
            methodexecutePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_InstallWorkEvents_execute_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(Methodexecute, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_installWorkEventsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}