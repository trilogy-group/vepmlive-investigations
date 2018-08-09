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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.API.Integration.IntegrationControlTemplate" />)
    ///     and namespace <see cref="EPMLiveCore.API.Integration"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class IntegrationControlTemplateTest : AbstractBaseSetupTypedTest<IntegrationControlTemplate>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (IntegrationControlTemplate) Initializer

        private const string MethodInstantiateIn = "InstantiateIn";
        private const string Fieldcontrol = "control";
        private const string Fieldpage = "page";
        private const string Fieldtitle = "title";
        private Type _integrationControlTemplateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private IntegrationControlTemplate _integrationControlTemplateInstance;
        private IntegrationControlTemplate _integrationControlTemplateInstanceFixture;

        #region General Initializer : Class (IntegrationControlTemplate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="IntegrationControlTemplate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _integrationControlTemplateInstanceType = typeof(IntegrationControlTemplate);
            _integrationControlTemplateInstanceFixture = Create(true);
            _integrationControlTemplateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (IntegrationControlTemplate)

        #region General Initializer : Class (IntegrationControlTemplate) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="IntegrationControlTemplate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodInstantiateIn, 0)]
        public void AUT_IntegrationControlTemplate_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_integrationControlTemplateInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (IntegrationControlTemplate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="IntegrationControlTemplate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldcontrol)]
        [TestCase(Fieldpage)]
        [TestCase(Fieldtitle)]
        public void AUT_IntegrationControlTemplate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_integrationControlTemplateInstanceFixture, 
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
        ///     Class (<see cref="IntegrationControlTemplate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_IntegrationControlTemplate_Is_Instance_Present_Test()
        {
            // Assert
            _integrationControlTemplateInstanceType.ShouldNotBeNull();
            _integrationControlTemplateInstance.ShouldNotBeNull();
            _integrationControlTemplateInstanceFixture.ShouldNotBeNull();
            _integrationControlTemplateInstance.ShouldBeAssignableTo<IntegrationControlTemplate>();
            _integrationControlTemplateInstanceFixture.ShouldBeAssignableTo<IntegrationControlTemplate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (IntegrationControlTemplate) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationControlTemplate_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var c = CreateType<Control>();
            var page = CreateType<Page>();
            var title = CreateType<string>();
            IntegrationControlTemplate instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new IntegrationControlTemplate(c, page, title);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _integrationControlTemplateInstance.ShouldNotBeNull();
            _integrationControlTemplateInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<IntegrationControlTemplate>();
        }

        #endregion

        #region General Constructor : Class (IntegrationControlTemplate) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_IntegrationControlTemplate_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var c = CreateType<Control>();
            var page = CreateType<Page>();
            var title = CreateType<string>();
            IntegrationControlTemplate instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new IntegrationControlTemplate(c, page, title);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _integrationControlTemplateInstance.ShouldNotBeNull();
            _integrationControlTemplateInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="IntegrationControlTemplate" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodInstantiateIn)]
        public void AUT_IntegrationControlTemplate_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<IntegrationControlTemplate>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_IntegrationControlTemplate_InstantiateIn_Method_Call_Internally(Type[] types)
        {
            var methodInstantiateInPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationControlTemplateInstance, MethodInstantiateIn, Fixture, methodInstantiateInPrametersTypes);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationControlTemplate_InstantiateIn_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            Action executeAction = null;

            // Act
            executeAction = () => _integrationControlTemplateInstance.InstantiateIn(container);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationControlTemplate_InstantiateIn_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            var methodInstantiateInPrametersTypes = new Type[] { typeof(Control) };
            object[] parametersOfInstantiateIn = { container };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInstantiateIn, methodInstantiateInPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_integrationControlTemplateInstanceFixture, parametersOfInstantiateIn);

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
        public void AUT_IntegrationControlTemplate_InstantiateIn_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var container = CreateType<Control>();
            var methodInstantiateInPrametersTypes = new Type[] { typeof(Control) };
            object[] parametersOfInstantiateIn = { container };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_integrationControlTemplateInstance, MethodInstantiateIn, parametersOfInstantiateIn, methodInstantiateInPrametersTypes);

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
        public void AUT_IntegrationControlTemplate_InstantiateIn_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_IntegrationControlTemplate_InstantiateIn_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodInstantiateInPrametersTypes = new Type[] { typeof(Control) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_integrationControlTemplateInstance, MethodInstantiateIn, Fixture, methodInstantiateInPrametersTypes);

            // Assert
            methodInstantiateInPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InstantiateIn) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_IntegrationControlTemplate_InstantiateIn_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInstantiateIn, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_integrationControlTemplateInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}