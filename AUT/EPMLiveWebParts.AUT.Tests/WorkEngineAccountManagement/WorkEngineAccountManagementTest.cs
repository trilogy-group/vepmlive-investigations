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

namespace EPMLiveWebParts.WorkEngineAccountManagement
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.WorkEngineAccountManagement.WorkEngineAccountManagement" />)
    ///     and namespace <see cref="EPMLiveWebParts.WorkEngineAccountManagement"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WorkEngineAccountManagementTest : AbstractBaseSetupTypedTest<WorkEngineAccountManagement>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkEngineAccountManagement) Initializer

        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodRender = "Render";
        private const string Fieldexpired = "expired";
        private const string Fieldmax = "max";
        private const string Fieldcount = "count";
        private const string Fieldaccountid = "accountid";
        private const string Fieldownerusername = "ownerusername";
        private const string Fieldowneremail = "owneremail";
        private const string Fieldownername = "ownername";
        private const string Fieldbillingtype = "billingtype";
        private const string Fieldaccountref = "accountref";
        private const string FieldinTrial = "inTrial";
        private Type _workEngineAccountManagementInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkEngineAccountManagement _workEngineAccountManagementInstance;
        private WorkEngineAccountManagement _workEngineAccountManagementInstanceFixture;

        #region General Initializer : Class (WorkEngineAccountManagement) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkEngineAccountManagement" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workEngineAccountManagementInstanceType = typeof(WorkEngineAccountManagement);
            _workEngineAccountManagementInstanceFixture = Create(true);
            _workEngineAccountManagementInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkEngineAccountManagement)

        #region General Initializer : Class (WorkEngineAccountManagement) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="WorkEngineAccountManagement" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodRender, 0)]
        public void AUT_WorkEngineAccountManagement_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_workEngineAccountManagementInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkEngineAccountManagement) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkEngineAccountManagement" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Fieldexpired)]
        [TestCase(Fieldmax)]
        [TestCase(Fieldcount)]
        [TestCase(Fieldaccountid)]
        [TestCase(Fieldownerusername)]
        [TestCase(Fieldowneremail)]
        [TestCase(Fieldownername)]
        [TestCase(Fieldbillingtype)]
        [TestCase(Fieldaccountref)]
        [TestCase(FieldinTrial)]
        public void AUT_WorkEngineAccountManagement_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workEngineAccountManagementInstanceFixture, 
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
        ///     Class (<see cref="WorkEngineAccountManagement" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkEngineAccountManagement_Is_Instance_Present_Test()
        {
            // Assert
            _workEngineAccountManagementInstanceType.ShouldNotBeNull();
            _workEngineAccountManagementInstance.ShouldNotBeNull();
            _workEngineAccountManagementInstanceFixture.ShouldNotBeNull();
            _workEngineAccountManagementInstance.ShouldBeAssignableTo<WorkEngineAccountManagement>();
            _workEngineAccountManagementInstanceFixture.ShouldBeAssignableTo<WorkEngineAccountManagement>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkEngineAccountManagement) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkEngineAccountManagement_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkEngineAccountManagement instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workEngineAccountManagementInstanceType.ShouldNotBeNull();
            _workEngineAccountManagementInstance.ShouldNotBeNull();
            _workEngineAccountManagementInstanceFixture.ShouldNotBeNull();
            _workEngineAccountManagementInstance.ShouldBeAssignableTo<WorkEngineAccountManagement>();
            _workEngineAccountManagementInstanceFixture.ShouldBeAssignableTo<WorkEngineAccountManagement>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="WorkEngineAccountManagement" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodRender)]
        public void AUT_WorkEngineAccountManagement_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<WorkEngineAccountManagement>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAccountManagement_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineAccountManagementInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_WorkEngineAccountManagement_CreateChildControls_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineAccountManagementInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_WorkEngineAccountManagement_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineAccountManagementInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_WorkEngineAccountManagement_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineAccountManagementInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_WorkEngineAccountManagement_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineAccountManagementInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_WorkEngineAccountManagement_Render_Method_Call_Internally(Type[] types)
        {
            var methodRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineAccountManagementInstance, MethodRender, Fixture, methodRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_WorkEngineAccountManagement_Render_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRender, methodRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_workEngineAccountManagementInstanceFixture, parametersOfRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_WorkEngineAccountManagement_Render_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRender = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_workEngineAccountManagementInstance, MethodRender, parametersOfRender, methodRenderPrametersTypes);

            // Assert
            parametersOfRender.ShouldNotBeNull();
            parametersOfRender.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(1);
            methodRenderPrametersTypes.Length.ShouldBe(parametersOfRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_WorkEngineAccountManagement_Render_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_WorkEngineAccountManagement_Render_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_workEngineAccountManagementInstance, MethodRender, Fixture, methodRenderPrametersTypes);

            // Assert
            methodRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (Render) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_WorkEngineAccountManagement_Render_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_workEngineAccountManagementInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}