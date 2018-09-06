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

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportingServicesToolPart" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportingServicesToolPartTest : AbstractBaseSetupTypedTest<ReportingServicesToolPart>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingServicesToolPart) Initializer

        private const string MethodRenderToolPart = "RenderToolPart";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodApplyChanges = "ApplyChanges";
        private Type _reportingServicesToolPartInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingServicesToolPart _reportingServicesToolPartInstance;
        private ReportingServicesToolPart _reportingServicesToolPartInstanceFixture;

        #region General Initializer : Class (ReportingServicesToolPart) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingServicesToolPart" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingServicesToolPartInstanceType = typeof(ReportingServicesToolPart);
            _reportingServicesToolPartInstanceFixture = Create(true);
            _reportingServicesToolPartInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingServicesToolPart)

        #region General Initializer : Class (ReportingServicesToolPart) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingServicesToolPart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodRenderToolPart, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodApplyChanges, 0)]
        public void AUT_ReportingServicesToolPart_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingServicesToolPartInstanceFixture, 
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
        ///     Class (<see cref="ReportingServicesToolPart" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportingServicesToolPart_Is_Instance_Present_Test()
        {
            // Assert
            _reportingServicesToolPartInstanceType.ShouldNotBeNull();
            _reportingServicesToolPartInstance.ShouldNotBeNull();
            _reportingServicesToolPartInstanceFixture.ShouldNotBeNull();
            _reportingServicesToolPartInstance.ShouldBeAssignableTo<ReportingServicesToolPart>();
            _reportingServicesToolPartInstanceFixture.ShouldBeAssignableTo<ReportingServicesToolPart>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportingServicesToolPart) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportingServicesToolPart_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportingServicesToolPart instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportingServicesToolPartInstanceType.ShouldNotBeNull();
            _reportingServicesToolPartInstance.ShouldNotBeNull();
            _reportingServicesToolPartInstanceFixture.ShouldNotBeNull();
            _reportingServicesToolPartInstance.ShouldBeAssignableTo<ReportingServicesToolPart>();
            _reportingServicesToolPartInstanceFixture.ShouldBeAssignableTo<ReportingServicesToolPart>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportingServicesToolPart" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodRenderToolPart)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodApplyChanges)]
        public void AUT_ReportingServicesToolPart_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportingServicesToolPart>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingServicesToolPart_RenderToolPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderToolPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServicesToolPartInstance, MethodRenderToolPart, Fixture, methodRenderToolPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_RenderToolPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderToolPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderToolPart, methodRenderToolPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServicesToolPartInstanceFixture, parametersOfRenderToolPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderToolPart.ShouldNotBeNull();
            parametersOfRenderToolPart.Length.ShouldBe(1);
            methodRenderToolPartPrametersTypes.Length.ShouldBe(1);
            methodRenderToolPartPrametersTypes.Length.ShouldBe(parametersOfRenderToolPart.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_RenderToolPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderToolPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServicesToolPartInstance, MethodRenderToolPart, parametersOfRenderToolPart, methodRenderToolPartPrametersTypes);

            // Assert
            parametersOfRenderToolPart.ShouldNotBeNull();
            parametersOfRenderToolPart.Length.ShouldBe(1);
            methodRenderToolPartPrametersTypes.Length.ShouldBe(1);
            methodRenderToolPartPrametersTypes.Length.ShouldBe(parametersOfRenderToolPart.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_RenderToolPart_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderToolPart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_RenderToolPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServicesToolPartInstance, MethodRenderToolPart, Fixture, methodRenderToolPartPrametersTypes);

            // Assert
            methodRenderToolPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_RenderToolPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderToolPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServicesToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingServicesToolPart_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServicesToolPartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_CreateChildControls_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServicesToolPartInstanceFixture, parametersOfCreateChildControls);

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
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServicesToolPartInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServicesToolPartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServicesToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingServicesToolPart_ApplyChanges_Method_Call_Internally(Type[] types)
        {
            var methodApplyChangesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServicesToolPartInstance, MethodApplyChanges, Fixture, methodApplyChangesPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_ApplyChanges_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportingServicesToolPartInstance.ApplyChanges();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_ApplyChanges_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;
            object[] parametersOfApplyChanges = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodApplyChanges, methodApplyChangesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingServicesToolPartInstanceFixture, parametersOfApplyChanges);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfApplyChanges.ShouldBeNull();
            methodApplyChangesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_ApplyChanges_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;
            object[] parametersOfApplyChanges = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingServicesToolPartInstance, MethodApplyChanges, parametersOfApplyChanges, methodApplyChangesPrametersTypes);

            // Assert
            parametersOfApplyChanges.ShouldBeNull();
            methodApplyChangesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_ApplyChanges_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingServicesToolPartInstance, MethodApplyChanges, Fixture, methodApplyChangesPrametersTypes);

            // Assert
            methodApplyChangesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingServicesToolPart_ApplyChanges_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyChanges, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingServicesToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}