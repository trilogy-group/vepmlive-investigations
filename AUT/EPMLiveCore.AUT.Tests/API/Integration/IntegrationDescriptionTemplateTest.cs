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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Integration.IntegrationDescriptionTemplate" />)
    ///     and namespace <see cref="EPMLiveCore.API.Integration"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class IntegrationDescriptionTemplateTest : AbstractBaseSetupTypedTest<IntegrationDescriptionTemplate>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (IntegrationDescriptionTemplate) Initializer

        private const string MethodInstantiateIn = "InstantiateIn";
        private const string Fieldlbl = "lbl";
        private const string Field_text = "_text";
        private Type _integrationDescriptionTemplateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private IntegrationDescriptionTemplate _integrationDescriptionTemplateInstance;
        private IntegrationDescriptionTemplate _integrationDescriptionTemplateInstanceFixture;

        #region General Initializer : Class (IntegrationDescriptionTemplate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="IntegrationDescriptionTemplate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _integrationDescriptionTemplateInstanceType = typeof(IntegrationDescriptionTemplate);
            _integrationDescriptionTemplateInstanceFixture = Create(true);
            _integrationDescriptionTemplateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (IntegrationDescriptionTemplate)

        #region General Initializer : Class (IntegrationDescriptionTemplate) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="IntegrationDescriptionTemplate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInstantiateIn, 0)]
        public void AUT_IntegrationDescriptionTemplate_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_integrationDescriptionTemplateInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (IntegrationDescriptionTemplate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="IntegrationDescriptionTemplate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldlbl)]
        [TestCase(Field_text)]
        public void AUT_IntegrationDescriptionTemplate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_integrationDescriptionTemplateInstanceFixture, 
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
        ///     Class (<see cref="IntegrationDescriptionTemplate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_IntegrationDescriptionTemplate_Is_Instance_Present_Test()
        {
            // Assert
            _integrationDescriptionTemplateInstanceType.ShouldNotBeNull();
            _integrationDescriptionTemplateInstance.ShouldNotBeNull();
            _integrationDescriptionTemplateInstanceFixture.ShouldNotBeNull();
            _integrationDescriptionTemplateInstance.ShouldBeAssignableTo<IntegrationDescriptionTemplate>();
            _integrationDescriptionTemplateInstanceFixture.ShouldBeAssignableTo<IntegrationDescriptionTemplate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (IntegrationDescriptionTemplate) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationDescriptionTemplate_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var text = CreateType<string>();
            IntegrationDescriptionTemplate instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new IntegrationDescriptionTemplate(text);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _integrationDescriptionTemplateInstance.ShouldNotBeNull();
            _integrationDescriptionTemplateInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<IntegrationDescriptionTemplate>();
        }

        #endregion

        #region General Constructor : Class (IntegrationDescriptionTemplate) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationDescriptionTemplate_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var text = CreateType<string>();
            IntegrationDescriptionTemplate instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new IntegrationDescriptionTemplate(text);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _integrationDescriptionTemplateInstance.ShouldNotBeNull();
            _integrationDescriptionTemplateInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="IntegrationDescriptionTemplate" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInstantiateIn)]
        public void AUT_IntegrationDescriptionTemplate_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<IntegrationDescriptionTemplate>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationDescriptionTemplate_InstantiateIn_Method_Call_Internally(Type[] types)
        {
            var methodInstantiateInPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationDescriptionTemplateInstance, MethodInstantiateIn, Fixture, methodInstantiateInPrametersTypes);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationDescriptionTemplate_InstantiateIn_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationDescriptionTemplateInstance.InstantiateIn(container);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationDescriptionTemplate_InstantiateIn_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            var methodInstantiateInPrametersTypes = new Type[] { typeof(Control) };
            object[] parametersOfInstantiateIn = { container };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInstantiateIn, methodInstantiateInPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationDescriptionTemplateInstanceFixture, parametersOfInstantiateIn);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInstantiateIn.ShouldNotBeNull();
            parametersOfInstantiateIn.Length.ShouldBe(1);
            methodInstantiateInPrametersTypes.Length.ShouldBe(1);
            methodInstantiateInPrametersTypes.Length.ShouldBe(parametersOfInstantiateIn.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationDescriptionTemplate_InstantiateIn_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            var methodInstantiateInPrametersTypes = new Type[] { typeof(Control) };
            object[] parametersOfInstantiateIn = { container };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationDescriptionTemplateInstance, MethodInstantiateIn, parametersOfInstantiateIn, methodInstantiateInPrametersTypes);

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
        public void AUT_IntegrationDescriptionTemplate_InstantiateIn_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_IntegrationDescriptionTemplate_InstantiateIn_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstantiateInPrametersTypes = new Type[] { typeof(Control) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationDescriptionTemplateInstance, MethodInstantiateIn, Fixture, methodInstantiateInPrametersTypes);

            // Assert
            methodInstantiateInPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationDescriptionTemplate_InstantiateIn_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstantiateIn, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationDescriptionTemplateInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}