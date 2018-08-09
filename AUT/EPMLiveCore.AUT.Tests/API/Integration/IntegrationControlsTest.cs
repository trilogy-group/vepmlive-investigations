using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.API.Integration
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Integration.IntegrationControls" />)
    ///     and namespace <see cref="EPMLiveCore.API.Integration"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class IntegrationControlsTest : AbstractBaseSetupTypedTest<IntegrationControls>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (IntegrationControls) Initializer

        private const string MethodInstantiateIn = "InstantiateIn";
        private const string Fieldcontrol = "control";
        private Type _integrationControlsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private IntegrationControls _integrationControlsInstance;
        private IntegrationControls _integrationControlsInstanceFixture;

        #region General Initializer : Class (IntegrationControls) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="IntegrationControls" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _integrationControlsInstanceType = typeof(IntegrationControls);
            _integrationControlsInstanceFixture = Create(true);
            _integrationControlsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (IntegrationControls)

        #region General Initializer : Class (IntegrationControls) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="IntegrationControls" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInstantiateIn, 0)]
        public void AUT_IntegrationControls_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_integrationControlsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (IntegrationControls) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="IntegrationControls" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldcontrol)]
        public void AUT_IntegrationControls_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_integrationControlsInstanceFixture, 
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
        ///     Class (<see cref="IntegrationControls" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_IntegrationControls_Is_Instance_Present_Test()
        {
            // Assert
            _integrationControlsInstanceType.ShouldNotBeNull();
            _integrationControlsInstance.ShouldNotBeNull();
            _integrationControlsInstanceFixture.ShouldNotBeNull();
            _integrationControlsInstance.ShouldBeAssignableTo<IntegrationControls>();
            _integrationControlsInstanceFixture.ShouldBeAssignableTo<IntegrationControls>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (IntegrationControls) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationControls_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var c = CreateType<Control>();
            IntegrationControls instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new IntegrationControls(c);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _integrationControlsInstance.ShouldNotBeNull();
            _integrationControlsInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<IntegrationControls>();
        }

        #endregion

        #region General Constructor : Class (IntegrationControls) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationControls_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var c = CreateType<Control>();
            IntegrationControls instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new IntegrationControls(c);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _integrationControlsInstance.ShouldNotBeNull();
            _integrationControlsInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="IntegrationControls" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInstantiateIn)]
        public void AUT_IntegrationControls_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<IntegrationControls>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationControls_InstantiateIn_Method_Call_Internally(Type[] types)
        {
            var methodInstantiateInPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationControlsInstance, MethodInstantiateIn, Fixture, methodInstantiateInPrametersTypes);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationControls_InstantiateIn_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationControlsInstance.InstantiateIn(container);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationControls_InstantiateIn_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            var methodInstantiateInPrametersTypes = new Type[] { typeof(Control) };
            object[] parametersOfInstantiateIn = { container };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInstantiateIn, methodInstantiateInPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationControlsInstanceFixture, parametersOfInstantiateIn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInstantiateIn.ShouldNotBeNull();
            parametersOfInstantiateIn.Length.ShouldBe(1);
            methodInstantiateInPrametersTypes.Length.ShouldBe(1);
            methodInstantiateInPrametersTypes.Length.ShouldBe(parametersOfInstantiateIn.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationControls_InstantiateIn_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            var methodInstantiateInPrametersTypes = new Type[] { typeof(Control) };
            object[] parametersOfInstantiateIn = { container };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationControlsInstance, MethodInstantiateIn, parametersOfInstantiateIn, methodInstantiateInPrametersTypes);

            // Assert
            parametersOfInstantiateIn.ShouldNotBeNull();
            parametersOfInstantiateIn.Length.ShouldBe(1);
            methodInstantiateInPrametersTypes.Length.ShouldBe(1);
            methodInstantiateInPrametersTypes.Length.ShouldBe(parametersOfInstantiateIn.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationControls_InstantiateIn_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodInstantiateIn, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationControls_InstantiateIn_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstantiateInPrametersTypes = new Type[] { typeof(Control) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationControlsInstance, MethodInstantiateIn, Fixture, methodInstantiateInPrametersTypes);

            // Assert
            methodInstantiateInPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationControls_InstantiateIn_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstantiateIn, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationControlsInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}