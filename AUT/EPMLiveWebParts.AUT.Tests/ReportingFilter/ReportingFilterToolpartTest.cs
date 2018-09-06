using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportingFilterToolpart" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportingFilterToolpartTest : AbstractBaseSetupTypedTest<ReportingFilterToolpart>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingFilterToolpart) Initializer

        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodRenderToolPart = "RenderToolPart";
        private const string MethodSharepointListDropDownListSelectedIndexChanged = "SharepointListDropDownListSelectedIndexChanged";
        private const string MethodApplyChanges = "ApplyChanges";
        private const string MethodInitializeChildControls = "InitializeChildControls";
        private const string MethodPopulateListDropDown = "PopulateListDropDown";
        private const string MethodPopulateFieldsDropDown = "PopulateFieldsDropDown";
        private const string MethodPopulateDefaultValueListBox = "PopulateDefaultValueListBox";
        private const string MethodRenderDefaultValueControls = "RenderDefaultValueControls";
        private const string MethodSetControlState = "SetControlState";
        private const string MethodSetDefaultValueControlState = "SetDefaultValueControlState";
        private const string MethodHideOrShowControlsBasedOnType = "HideOrShowControlsBasedOnType";
        private const string MethodGetFieldObjectFromSelectedField = "GetFieldObjectFromSelectedField";
        private const string MethodFieldIsSupportedByThisWebPart = "FieldIsSupportedByThisWebPart";
        private const string MethodAddJavascriptForDateTimeControls = "AddJavascriptForDateTimeControls";
        private const string FieldDefaultFieldValue = "DefaultFieldValue";
        private const string FieldDefaultListValue = "DefaultListValue";
        private const string FieldSharepointListDropDownList = "SharepointListDropDownList";
        private const string FieldSharepointListFieldDropDownList = "SharepointListFieldDropDownList";
        private const string FieldShowTitlesDropDownCheckBox = "ShowTitlesDropDownCheckBox";
        private const string FieldAllowMultipleFieldsSelectedDropDownCheckBox = "AllowMultipleFieldsSelectedDropDownCheckBox";
        private const string FieldAllowMultipleTitlesSelectedDropDownCheckBox = "AllowMultipleTitlesSelectedDropDownCheckBox";
        private const string FieldIsPercentageCheckBox = "IsPercentageCheckBox";
        private const string FieldDefaultValueAsListBox = "DefaultValueAsListBox";
        private const string FieldDefaultValueAsTextBox = "DefaultValueAsTextBox";
        private const string FieldDefaultValueAsPeopleEditor = "DefaultValueAsPeopleEditor";
        private const string FieldJqueryDatePickerBeginDate = "JqueryDatePickerBeginDate";
        private const string FieldJqueryDatePickerEndDate = "JqueryDatePickerEndDate";
        private const string FieldWebControlUpdatePanel = "WebControlUpdatePanel";
        private const string FieldBeginDateLabel = "BeginDateLabel";
        private const string FieldEndDateLabel = "EndDateLabel";
        private Type _reportingFilterToolpartInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingFilterToolpart _reportingFilterToolpartInstance;
        private ReportingFilterToolpart _reportingFilterToolpartInstanceFixture;

        #region General Initializer : Class (ReportingFilterToolpart) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingFilterToolpart" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingFilterToolpartInstanceType = typeof(ReportingFilterToolpart);
            _reportingFilterToolpartInstanceFixture = Create(true);
            _reportingFilterToolpartInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingFilterToolpart)

        #region General Initializer : Class (ReportingFilterToolpart) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingFilterToolpart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodRenderToolPart, 0)]
        [TestCase(MethodSharepointListDropDownListSelectedIndexChanged, 0)]
        [TestCase(MethodApplyChanges, 0)]
        [TestCase(MethodInitializeChildControls, 0)]
        [TestCase(MethodPopulateListDropDown, 0)]
        [TestCase(MethodPopulateFieldsDropDown, 0)]
        [TestCase(MethodPopulateDefaultValueListBox, 0)]
        [TestCase(MethodRenderDefaultValueControls, 0)]
        [TestCase(MethodSetControlState, 0)]
        [TestCase(MethodSetDefaultValueControlState, 0)]
        [TestCase(MethodHideOrShowControlsBasedOnType, 0)]
        [TestCase(MethodGetFieldObjectFromSelectedField, 0)]
        [TestCase(MethodFieldIsSupportedByThisWebPart, 0)]
        [TestCase(MethodAddJavascriptForDateTimeControls, 0)]
        public void AUT_ReportingFilterToolpart_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingFilterToolpartInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportingFilterToolpart) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportingFilterToolpart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldDefaultFieldValue)]
        [TestCase(FieldDefaultListValue)]
        [TestCase(FieldSharepointListDropDownList)]
        [TestCase(FieldSharepointListFieldDropDownList)]
        [TestCase(FieldShowTitlesDropDownCheckBox)]
        [TestCase(FieldAllowMultipleFieldsSelectedDropDownCheckBox)]
        [TestCase(FieldAllowMultipleTitlesSelectedDropDownCheckBox)]
        [TestCase(FieldIsPercentageCheckBox)]
        [TestCase(FieldDefaultValueAsListBox)]
        [TestCase(FieldDefaultValueAsTextBox)]
        [TestCase(FieldDefaultValueAsPeopleEditor)]
        [TestCase(FieldJqueryDatePickerBeginDate)]
        [TestCase(FieldJqueryDatePickerEndDate)]
        [TestCase(FieldWebControlUpdatePanel)]
        [TestCase(FieldBeginDateLabel)]
        [TestCase(FieldEndDateLabel)]
        public void AUT_ReportingFilterToolpart_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportingFilterToolpartInstanceFixture, 
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
        ///     Class (<see cref="ReportingFilterToolpart" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportingFilterToolpart_Is_Instance_Present_Test()
        {
            // Assert
            _reportingFilterToolpartInstanceType.ShouldNotBeNull();
            _reportingFilterToolpartInstance.ShouldNotBeNull();
            _reportingFilterToolpartInstanceFixture.ShouldNotBeNull();
            _reportingFilterToolpartInstance.ShouldBeAssignableTo<ReportingFilterToolpart>();
            _reportingFilterToolpartInstanceFixture.ShouldBeAssignableTo<ReportingFilterToolpart>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportingFilterToolpart) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportingFilterToolpart_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportingFilterToolpart instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportingFilterToolpartInstanceType.ShouldNotBeNull();
            _reportingFilterToolpartInstance.ShouldNotBeNull();
            _reportingFilterToolpartInstanceFixture.ShouldNotBeNull();
            _reportingFilterToolpartInstance.ShouldBeAssignableTo<ReportingFilterToolpart>();
            _reportingFilterToolpartInstanceFixture.ShouldBeAssignableTo<ReportingFilterToolpart>();
        }

        #endregion

        #region General Constructor : Class (ReportingFilterToolpart) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportingFilterToolpart_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var reportingFilterToolpartInstance  = new ReportingFilterToolpart();

            // Asserts
            reportingFilterToolpartInstance.ShouldNotBeNull();
            reportingFilterToolpartInstance.ShouldBeAssignableTo<ReportingFilterToolpart>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ReportingFilterToolpart" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodFieldIsSupportedByThisWebPart)]
        public void AUT_ReportingFilterToolpart_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_reportingFilterToolpartInstanceFixture,
                                                                              _reportingFilterToolpartInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportingFilterToolpart" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodRenderToolPart)]
        [TestCase(MethodSharepointListDropDownListSelectedIndexChanged)]
        [TestCase(MethodApplyChanges)]
        [TestCase(MethodInitializeChildControls)]
        [TestCase(MethodPopulateListDropDown)]
        [TestCase(MethodPopulateFieldsDropDown)]
        [TestCase(MethodPopulateDefaultValueListBox)]
        [TestCase(MethodRenderDefaultValueControls)]
        [TestCase(MethodSetControlState)]
        [TestCase(MethodSetDefaultValueControlState)]
        [TestCase(MethodHideOrShowControlsBasedOnType)]
        [TestCase(MethodGetFieldObjectFromSelectedField)]
        [TestCase(MethodAddJavascriptForDateTimeControls)]
        public void AUT_ReportingFilterToolpart_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportingFilterToolpart>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfCreateChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_ReportingFilterToolpart_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfOnPreRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

            // Assert
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_RenderToolPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderToolPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodRenderToolPart, Fixture, methodRenderToolPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_RenderToolPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderToolPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderToolPart, methodRenderToolPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfRenderToolPart);

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
        public void AUT_ReportingFilterToolpart_RenderToolPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderToolPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodRenderToolPart, parametersOfRenderToolPart, methodRenderToolPartPrametersTypes);

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
        public void AUT_ReportingFilterToolpart_RenderToolPart_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportingFilterToolpart_RenderToolPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodRenderToolPart, Fixture, methodRenderToolPartPrametersTypes);

            // Assert
            methodRenderToolPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_RenderToolPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderToolPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SharepointListDropDownListSelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_SharepointListDropDownListSelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodSharepointListDropDownListSelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodSharepointListDropDownListSelectedIndexChanged, Fixture, methodSharepointListDropDownListSelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (SharepointListDropDownListSelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SharepointListDropDownListSelectedIndexChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSharepointListDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSharepointListDropDownListSelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSharepointListDropDownListSelectedIndexChanged, methodSharepointListDropDownListSelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfSharepointListDropDownListSelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSharepointListDropDownListSelectedIndexChanged.ShouldNotBeNull();
            parametersOfSharepointListDropDownListSelectedIndexChanged.Length.ShouldBe(2);
            methodSharepointListDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodSharepointListDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfSharepointListDropDownListSelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SharepointListDropDownListSelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SharepointListDropDownListSelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodSharepointListDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfSharepointListDropDownListSelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodSharepointListDropDownListSelectedIndexChanged, parametersOfSharepointListDropDownListSelectedIndexChanged, methodSharepointListDropDownListSelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfSharepointListDropDownListSelectedIndexChanged.ShouldNotBeNull();
            parametersOfSharepointListDropDownListSelectedIndexChanged.Length.ShouldBe(2);
            methodSharepointListDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodSharepointListDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfSharepointListDropDownListSelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SharepointListDropDownListSelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SharepointListDropDownListSelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSharepointListDropDownListSelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SharepointListDropDownListSelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SharepointListDropDownListSelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSharepointListDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodSharepointListDropDownListSelectedIndexChanged, Fixture, methodSharepointListDropDownListSelectedIndexChangedPrametersTypes);

            // Assert
            methodSharepointListDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SharepointListDropDownListSelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SharepointListDropDownListSelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSharepointListDropDownListSelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_ApplyChanges_Method_Call_Internally(Type[] types)
        {
            var methodApplyChangesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodApplyChanges, Fixture, methodApplyChangesPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_ApplyChanges_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportingFilterToolpartInstance.ApplyChanges();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_ApplyChanges_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;
            object[] parametersOfApplyChanges = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodApplyChanges, methodApplyChangesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfApplyChanges);

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
        public void AUT_ReportingFilterToolpart_ApplyChanges_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;
            object[] parametersOfApplyChanges = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodApplyChanges, parametersOfApplyChanges, methodApplyChangesPrametersTypes);

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
        public void AUT_ReportingFilterToolpart_ApplyChanges_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodApplyChanges, Fixture, methodApplyChangesPrametersTypes);

            // Assert
            methodApplyChangesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_ApplyChanges_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyChanges, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_InitializeChildControls_Method_Call_Internally(Type[] types)
        {
            var methodInitializeChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodInitializeChildControls, Fixture, methodInitializeChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_InitializeChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitializeChildControlsPrametersTypes = null;
            object[] parametersOfInitializeChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeChildControls, methodInitializeChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfInitializeChildControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeChildControls.ShouldBeNull();
            methodInitializeChildControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitializeChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_InitializeChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializeChildControlsPrametersTypes = null;
            object[] parametersOfInitializeChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodInitializeChildControls, parametersOfInitializeChildControls, methodInitializeChildControlsPrametersTypes);

            // Assert
            parametersOfInitializeChildControls.ShouldBeNull();
            methodInitializeChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_InitializeChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializeChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodInitializeChildControls, Fixture, methodInitializeChildControlsPrametersTypes);

            // Assert
            methodInitializeChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_InitializeChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateListDropDown) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_PopulateListDropDown_Method_Call_Internally(Type[] types)
        {
            var methodPopulateListDropDownPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodPopulateListDropDown, Fixture, methodPopulateListDropDownPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateListDropDown) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateListDropDown_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodPopulateListDropDownPrametersTypes = null;
            object[] parametersOfPopulateListDropDown = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateListDropDown, methodPopulateListDropDownPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfPopulateListDropDown);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateListDropDown.ShouldBeNull();
            methodPopulateListDropDownPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateListDropDown) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateListDropDown_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPopulateListDropDownPrametersTypes = null;
            object[] parametersOfPopulateListDropDown = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodPopulateListDropDown, parametersOfPopulateListDropDown, methodPopulateListDropDownPrametersTypes);

            // Assert
            parametersOfPopulateListDropDown.ShouldBeNull();
            methodPopulateListDropDownPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateListDropDown) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateListDropDown_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPopulateListDropDownPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodPopulateListDropDown, Fixture, methodPopulateListDropDownPrametersTypes);

            // Assert
            methodPopulateListDropDownPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateListDropDown) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateListDropDown_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateListDropDown, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFieldsDropDown) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_PopulateFieldsDropDown_Method_Call_Internally(Type[] types)
        {
            var methodPopulateFieldsDropDownPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodPopulateFieldsDropDown, Fixture, methodPopulateFieldsDropDownPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateFieldsDropDown) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateFieldsDropDown_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var selectedSharepointList = CreateType<string>();
            var methodPopulateFieldsDropDownPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPopulateFieldsDropDown = { selectedSharepointList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateFieldsDropDown, methodPopulateFieldsDropDownPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfPopulateFieldsDropDown);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateFieldsDropDown.ShouldNotBeNull();
            parametersOfPopulateFieldsDropDown.Length.ShouldBe(1);
            methodPopulateFieldsDropDownPrametersTypes.Length.ShouldBe(1);
            methodPopulateFieldsDropDownPrametersTypes.Length.ShouldBe(parametersOfPopulateFieldsDropDown.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFieldsDropDown) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateFieldsDropDown_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var selectedSharepointList = CreateType<string>();
            var methodPopulateFieldsDropDownPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfPopulateFieldsDropDown = { selectedSharepointList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodPopulateFieldsDropDown, parametersOfPopulateFieldsDropDown, methodPopulateFieldsDropDownPrametersTypes);

            // Assert
            parametersOfPopulateFieldsDropDown.ShouldNotBeNull();
            parametersOfPopulateFieldsDropDown.Length.ShouldBe(1);
            methodPopulateFieldsDropDownPrametersTypes.Length.ShouldBe(1);
            methodPopulateFieldsDropDownPrametersTypes.Length.ShouldBe(parametersOfPopulateFieldsDropDown.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFieldsDropDown) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateFieldsDropDown_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateFieldsDropDown, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateFieldsDropDown) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateFieldsDropDown_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateFieldsDropDownPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodPopulateFieldsDropDown, Fixture, methodPopulateFieldsDropDownPrametersTypes);

            // Assert
            methodPopulateFieldsDropDownPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateFieldsDropDown) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateFieldsDropDown_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateFieldsDropDown, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDefaultValueListBox) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_PopulateDefaultValueListBox_Method_Call_Internally(Type[] types)
        {
            var methodPopulateDefaultValueListBoxPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodPopulateDefaultValueListBox, Fixture, methodPopulateDefaultValueListBoxPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateDefaultValueListBox) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateDefaultValueListBox_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodPopulateDefaultValueListBoxPrametersTypes = null;
            object[] parametersOfPopulateDefaultValueListBox = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateDefaultValueListBox, methodPopulateDefaultValueListBoxPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfPopulateDefaultValueListBox);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateDefaultValueListBox.ShouldBeNull();
            methodPopulateDefaultValueListBoxPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDefaultValueListBox) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateDefaultValueListBox_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPopulateDefaultValueListBoxPrametersTypes = null;
            object[] parametersOfPopulateDefaultValueListBox = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodPopulateDefaultValueListBox, parametersOfPopulateDefaultValueListBox, methodPopulateDefaultValueListBoxPrametersTypes);

            // Assert
            parametersOfPopulateDefaultValueListBox.ShouldBeNull();
            methodPopulateDefaultValueListBoxPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDefaultValueListBox) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateDefaultValueListBox_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPopulateDefaultValueListBoxPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodPopulateDefaultValueListBox, Fixture, methodPopulateDefaultValueListBoxPrametersTypes);

            // Assert
            methodPopulateDefaultValueListBoxPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateDefaultValueListBox) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_PopulateDefaultValueListBox_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateDefaultValueListBox, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderDefaultValueControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_RenderDefaultValueControls_Method_Call_Internally(Type[] types)
        {
            var methodRenderDefaultValueControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodRenderDefaultValueControls, Fixture, methodRenderDefaultValueControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderDefaultValueControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_RenderDefaultValueControls_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderDefaultValueControlsPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderDefaultValueControls = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderDefaultValueControls, methodRenderDefaultValueControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfRenderDefaultValueControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderDefaultValueControls.ShouldNotBeNull();
            parametersOfRenderDefaultValueControls.Length.ShouldBe(1);
            methodRenderDefaultValueControlsPrametersTypes.Length.ShouldBe(1);
            methodRenderDefaultValueControlsPrametersTypes.Length.ShouldBe(parametersOfRenderDefaultValueControls.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderDefaultValueControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_RenderDefaultValueControls_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderDefaultValueControlsPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderDefaultValueControls = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodRenderDefaultValueControls, parametersOfRenderDefaultValueControls, methodRenderDefaultValueControlsPrametersTypes);

            // Assert
            parametersOfRenderDefaultValueControls.ShouldNotBeNull();
            parametersOfRenderDefaultValueControls.Length.ShouldBe(1);
            methodRenderDefaultValueControlsPrametersTypes.Length.ShouldBe(1);
            methodRenderDefaultValueControlsPrametersTypes.Length.ShouldBe(parametersOfRenderDefaultValueControls.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderDefaultValueControls) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_RenderDefaultValueControls_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderDefaultValueControls, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderDefaultValueControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_RenderDefaultValueControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderDefaultValueControlsPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodRenderDefaultValueControls, Fixture, methodRenderDefaultValueControlsPrametersTypes);

            // Assert
            methodRenderDefaultValueControlsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderDefaultValueControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_RenderDefaultValueControls_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderDefaultValueControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetControlState) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_SetControlState_Method_Call_Internally(Type[] types)
        {
            var methodSetControlStatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodSetControlState, Fixture, methodSetControlStatePrametersTypes);
        }

        #endregion

        #region Method Call : (SetControlState) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SetControlState_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetControlStatePrametersTypes = null;
            object[] parametersOfSetControlState = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetControlState, methodSetControlStatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfSetControlState);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetControlState.ShouldBeNull();
            methodSetControlStatePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetControlState) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SetControlState_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetControlStatePrametersTypes = null;
            object[] parametersOfSetControlState = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodSetControlState, parametersOfSetControlState, methodSetControlStatePrametersTypes);

            // Assert
            parametersOfSetControlState.ShouldBeNull();
            methodSetControlStatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetControlState) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SetControlState_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetControlStatePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodSetControlState, Fixture, methodSetControlStatePrametersTypes);

            // Assert
            methodSetControlStatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetControlState) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SetControlState_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetControlState, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDefaultValueControlState) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_SetDefaultValueControlState_Method_Call_Internally(Type[] types)
        {
            var methodSetDefaultValueControlStatePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodSetDefaultValueControlState, Fixture, methodSetDefaultValueControlStatePrametersTypes);
        }

        #endregion

        #region Method Call : (SetDefaultValueControlState) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SetDefaultValueControlState_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetDefaultValueControlStatePrametersTypes = null;
            object[] parametersOfSetDefaultValueControlState = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetDefaultValueControlState, methodSetDefaultValueControlStatePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfSetDefaultValueControlState);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetDefaultValueControlState.ShouldBeNull();
            methodSetDefaultValueControlStatePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetDefaultValueControlState) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SetDefaultValueControlState_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetDefaultValueControlStatePrametersTypes = null;
            object[] parametersOfSetDefaultValueControlState = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodSetDefaultValueControlState, parametersOfSetDefaultValueControlState, methodSetDefaultValueControlStatePrametersTypes);

            // Assert
            parametersOfSetDefaultValueControlState.ShouldBeNull();
            methodSetDefaultValueControlStatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDefaultValueControlState) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SetDefaultValueControlState_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetDefaultValueControlStatePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodSetDefaultValueControlState, Fixture, methodSetDefaultValueControlStatePrametersTypes);

            // Assert
            methodSetDefaultValueControlStatePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDefaultValueControlState) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_SetDefaultValueControlState_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDefaultValueControlState, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideOrShowControlsBasedOnType) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_HideOrShowControlsBasedOnType_Method_Call_Internally(Type[] types)
        {
            var methodHideOrShowControlsBasedOnTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodHideOrShowControlsBasedOnType, Fixture, methodHideOrShowControlsBasedOnTypePrametersTypes);
        }

        #endregion

        #region Method Call : (HideOrShowControlsBasedOnType) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_HideOrShowControlsBasedOnType_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodHideOrShowControlsBasedOnTypePrametersTypes = null;
            object[] parametersOfHideOrShowControlsBasedOnType = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHideOrShowControlsBasedOnType, methodHideOrShowControlsBasedOnTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfHideOrShowControlsBasedOnType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHideOrShowControlsBasedOnType.ShouldBeNull();
            methodHideOrShowControlsBasedOnTypePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (HideOrShowControlsBasedOnType) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_HideOrShowControlsBasedOnType_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodHideOrShowControlsBasedOnTypePrametersTypes = null;
            object[] parametersOfHideOrShowControlsBasedOnType = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodHideOrShowControlsBasedOnType, parametersOfHideOrShowControlsBasedOnType, methodHideOrShowControlsBasedOnTypePrametersTypes);

            // Assert
            parametersOfHideOrShowControlsBasedOnType.ShouldBeNull();
            methodHideOrShowControlsBasedOnTypePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideOrShowControlsBasedOnType) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_HideOrShowControlsBasedOnType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodHideOrShowControlsBasedOnTypePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodHideOrShowControlsBasedOnType, Fixture, methodHideOrShowControlsBasedOnTypePrametersTypes);

            // Assert
            methodHideOrShowControlsBasedOnTypePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HideOrShowControlsBasedOnType) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_HideOrShowControlsBasedOnType_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHideOrShowControlsBasedOnType, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldObjectFromSelectedField) (Return Type : SPField) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_GetFieldObjectFromSelectedField_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldObjectFromSelectedFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodGetFieldObjectFromSelectedField, Fixture, methodGetFieldObjectFromSelectedFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldObjectFromSelectedField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_GetFieldObjectFromSelectedField_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFieldObjectFromSelectedFieldPrametersTypes = null;
            object[] parametersOfGetFieldObjectFromSelectedField = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldObjectFromSelectedField, methodGetFieldObjectFromSelectedFieldPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingFilterToolpart, SPField>(_reportingFilterToolpartInstanceFixture, out exception1, parametersOfGetFieldObjectFromSelectedField);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingFilterToolpart, SPField>(_reportingFilterToolpartInstance, MethodGetFieldObjectFromSelectedField, parametersOfGetFieldObjectFromSelectedField, methodGetFieldObjectFromSelectedFieldPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldObjectFromSelectedField.ShouldBeNull();
            methodGetFieldObjectFromSelectedFieldPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldObjectFromSelectedField) (Return Type : SPField) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_GetFieldObjectFromSelectedField_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetFieldObjectFromSelectedFieldPrametersTypes = null;
            object[] parametersOfGetFieldObjectFromSelectedField = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilterToolpart, SPField>(_reportingFilterToolpartInstance, MethodGetFieldObjectFromSelectedField, parametersOfGetFieldObjectFromSelectedField, methodGetFieldObjectFromSelectedFieldPrametersTypes);

            // Assert
            parametersOfGetFieldObjectFromSelectedField.ShouldBeNull();
            methodGetFieldObjectFromSelectedFieldPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldObjectFromSelectedField) (Return Type : SPField) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_GetFieldObjectFromSelectedField_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetFieldObjectFromSelectedFieldPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodGetFieldObjectFromSelectedField, Fixture, methodGetFieldObjectFromSelectedFieldPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldObjectFromSelectedFieldPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldObjectFromSelectedField) (Return Type : SPField) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_GetFieldObjectFromSelectedField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetFieldObjectFromSelectedFieldPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodGetFieldObjectFromSelectedField, Fixture, methodGetFieldObjectFromSelectedFieldPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldObjectFromSelectedFieldPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldObjectFromSelectedField) (Return Type : SPField) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_GetFieldObjectFromSelectedField_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldObjectFromSelectedField, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FieldIsSupportedByThisWebPart) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_FieldIsSupportedByThisWebPart_Static_Method_Call_Internally(Type[] types)
        {
            var methodFieldIsSupportedByThisWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterToolpartInstanceFixture, _reportingFilterToolpartInstanceType, MethodFieldIsSupportedByThisWebPart, Fixture, methodFieldIsSupportedByThisWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (FieldIsSupportedByThisWebPart) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_FieldIsSupportedByThisWebPart_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodFieldIsSupportedByThisWebPartPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfFieldIsSupportedByThisWebPart = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_reportingFilterToolpartInstanceFixture, _reportingFilterToolpartInstanceType, MethodFieldIsSupportedByThisWebPart, parametersOfFieldIsSupportedByThisWebPart, methodFieldIsSupportedByThisWebPartPrametersTypes);

            // Assert
            parametersOfFieldIsSupportedByThisWebPart.ShouldNotBeNull();
            parametersOfFieldIsSupportedByThisWebPart.Length.ShouldBe(1);
            methodFieldIsSupportedByThisWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FieldIsSupportedByThisWebPart) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_FieldIsSupportedByThisWebPart_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFieldIsSupportedByThisWebPartPrametersTypes = new Type[] { typeof(SPField) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterToolpartInstanceFixture, _reportingFilterToolpartInstanceType, MethodFieldIsSupportedByThisWebPart, Fixture, methodFieldIsSupportedByThisWebPartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodFieldIsSupportedByThisWebPartPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FieldIsSupportedByThisWebPart) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_FieldIsSupportedByThisWebPart_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFieldIsSupportedByThisWebPart, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (FieldIsSupportedByThisWebPart) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_FieldIsSupportedByThisWebPart_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFieldIsSupportedByThisWebPart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddJavascriptForDateTimeControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilterToolpart_AddJavascriptForDateTimeControls_Method_Call_Internally(Type[] types)
        {
            var methodAddJavascriptForDateTimeControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodAddJavascriptForDateTimeControls, Fixture, methodAddJavascriptForDateTimeControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddJavascriptForDateTimeControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_AddJavascriptForDateTimeControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddJavascriptForDateTimeControlsPrametersTypes = null;
            object[] parametersOfAddJavascriptForDateTimeControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddJavascriptForDateTimeControls, methodAddJavascriptForDateTimeControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterToolpartInstanceFixture, parametersOfAddJavascriptForDateTimeControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddJavascriptForDateTimeControls.ShouldBeNull();
            methodAddJavascriptForDateTimeControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddJavascriptForDateTimeControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_AddJavascriptForDateTimeControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddJavascriptForDateTimeControlsPrametersTypes = null;
            object[] parametersOfAddJavascriptForDateTimeControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterToolpartInstance, MethodAddJavascriptForDateTimeControls, parametersOfAddJavascriptForDateTimeControls, methodAddJavascriptForDateTimeControlsPrametersTypes);

            // Assert
            parametersOfAddJavascriptForDateTimeControls.ShouldBeNull();
            methodAddJavascriptForDateTimeControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddJavascriptForDateTimeControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_AddJavascriptForDateTimeControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddJavascriptForDateTimeControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterToolpartInstance, MethodAddJavascriptForDateTimeControls, Fixture, methodAddJavascriptForDateTimeControlsPrametersTypes);

            // Assert
            methodAddJavascriptForDateTimeControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddJavascriptForDateTimeControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingFilterToolpart_AddJavascriptForDateTimeControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddJavascriptForDateTimeControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterToolpartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}