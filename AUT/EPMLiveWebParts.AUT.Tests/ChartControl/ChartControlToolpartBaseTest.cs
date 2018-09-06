using System;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ChartControlToolpartBase" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ChartControlToolpartBaseTest : AbstractBaseSetupTypedTest<ChartControlToolpartBase>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ChartControlToolpartBase) Initializer

        private const string MethodOnInit = "OnInit";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodRenderToolPart = "RenderToolPart";
        private const string MethodChartTypeDropDownListSelectedIndexChanged = "ChartTypeDropDownListSelectedIndexChanged";
        private const string MethodListsDropDownListSelectedIndexChanged = "ListsDropDownListSelectedIndexChanged";
        private const string MethodApplyChanges = "ApplyChanges";
        private const string MethodCreateDisplayOptionControls = "CreateDisplayOptionControls";
        private const string MethodCreateZaxisControls = "CreateZaxisControls";
        private const string MethodCreateYaxisControls = "CreateYaxisControls";
        private const string MethodCreateXaxisControls = "CreateXaxisControls";
        private const string MethodSetDropDownListSelectedValues = "SetDropDownListSelectedValues";
        private const string MethodSetupDropDownLists = "SetupDropDownLists";
        private const string MethodSetupCheckBoxes = "SetupCheckBoxes";
        private const string MethodSetupAggregateTypeHtmlSelect = "SetupAggregateTypeHtmlSelect";
        private const string MethodSetTextBoxValues = "SetTextBoxValues";
        private const string MethodClearDropDownLists = "ClearDropDownLists";
        private const string MethodFillDropdowns = "FillDropdowns";
        private const string MethodSortDropDownList = "SortDropDownList";
        private const string MethodWriteXaxisSectionHtml = "WriteXaxisSectionHtml";
        private const string MethodWriteDisplayOptionsSectionHtml = "WriteDisplayOptionsSectionHtml";
        private const string MethodWriteYaxisSectionHtml = "WriteYaxisSectionHtml";
        private const string MethodWriteZaxisSectionHtml = "WriteZaxisSectionHtml";
        private const string MethodWriteOptionsSectionHtml = "WriteOptionsSectionHtml";
        private const string MethodWriteJavascript = "WriteJavascript";
        private const string MethodForcePageToNotCache = "ForcePageToNotCache";
        private const string MethodIsBubbleChart = "IsBubbleChart";
        private const string FieldChartTypeDropDownList = "ChartTypeDropDownList";
        private const string FieldChartPaletteStyleDropDownList = "ChartPaletteStyleDropDownList";
        private const string FieldListsDropDownList = "ListsDropDownList";
        private const string FieldViewsDropDownList = "ViewsDropDownList";
        private const string FieldXaxisFieldDropDownList = "XaxisFieldDropDownList";
        private const string FieldBubbleChartColorFieldDropDownList = "BubbleChartColorFieldDropDownList";
        private const string FieldSeriesNameLabelPositionDropDownList = "SeriesNameLabelPositionDropDownList";
        private const string FieldSeriesValueLabelPositionDropDownList = "SeriesValueLabelPositionDropDownList";
        private const string FieldFrameColorDropDownList = "FrameColorDropDownList";
        private const string FieldZaxisFieldDropDownList = "ZaxisFieldDropDownList";
        private const string FieldYaxisFieldAsDropDownList = "YaxisFieldAsDropDownList";
        private const string FieldYaxisFieldCheckBoxList = "YaxisFieldCheckBoxList";
        private const string FieldShowProjectsCheckBox = "ShowProjectsCheckBox";
        private const string FieldShowBubbleChartInputsInWebPart = "ShowBubbleChartInputsInWebPart";
        private const string FieldShowIn3DCheckBox = "ShowIn3DCheckBox";
        private const string FieldShowLegendCheckBox = "ShowLegendCheckBox";
        private const string FieldShowGridlinesCheckBox = "ShowGridlinesCheckBox";
        private const string FieldShowLabelsCheckBox = "ShowLabelsCheckBox";
        private const string FieldShowSeriesNameAsLabelCheckBox = "ShowSeriesNameAsLabelCheckBox";
        private const string FieldShowSeriesValueAsLabelCheckBox = "ShowSeriesValueAsLabelCheckBox";
        private const string FieldShowYaxisValuesAsPercentageCheckBox = "ShowYaxisValuesAsPercentageCheckBox";
        private const string FieldShowYaxisValuesAsCurrencyCheckBox = "ShowYaxisValuesAsCurrencyCheckBox";
        private const string FieldShowFrameCheckBox = "ShowFrameCheckBox";
        private const string FieldFrameRoundCornersCheckBox = "FrameRoundCornersCheckBox";
        private const string FieldRollupCheckBox = "RollupCheckBox";
        private const string FieldShowZeroValueDataCheckBox = "ShowZeroValueDataCheckBox";
        private const string FieldNumberOfYaxisValuesTextBox = "NumberOfYaxisValuesTextBox";
        private const string FieldXaxisLabelRotationAngleTextBox = "XaxisLabelRotationAngleTextBox";
        private const string FieldXaxisLabelFontSizeTextBox = "XaxisLabelFontSizeTextBox";
        private const string FieldZaxisLabelRotationAngleTextBox = "ZaxisLabelRotationAngleTextBox";
        private const string FieldSeriesDataPointLabelFontSizeTextBox = "SeriesDataPointLabelFontSizeTextBox";
        private const string FieldChartLegendFontSizeCheckBox = "ChartLegendFontSizeCheckBox";
        private const string FieldRollupListsTextBox = "RollupListsTextBox";
        private const string FieldRollupSitesTextBox = "RollupSitesTextBox";
        private const string FieldChartTitleTextBox = "ChartTitleTextBox";
        private const string FieldChartTitleFontSizeTextBox = "ChartTitleFontSizeTextBox";
        private const string FieldAggregateTypeHtmlSelect = "AggregateTypeHtmlSelect";
        private Type _chartControlToolpartBaseInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ChartControlToolpartBase _chartControlToolpartBaseInstance;
        private ChartControlToolpartBase _chartControlToolpartBaseInstanceFixture;

        #region General Initializer : Class (ChartControlToolpartBase) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChartControlToolpartBase" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _chartControlToolpartBaseInstanceType = typeof(ChartControlToolpartBase);
            _chartControlToolpartBaseInstanceFixture = Create(true);
            _chartControlToolpartBaseInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChartControlToolpartBase)

        #region General Initializer : Class (ChartControlToolpartBase) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ChartControlToolpartBase" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodRenderToolPart, 0)]
        [TestCase(MethodChartTypeDropDownListSelectedIndexChanged, 0)]
        [TestCase(MethodListsDropDownListSelectedIndexChanged, 0)]
        [TestCase(MethodApplyChanges, 0)]
        [TestCase(MethodCreateDisplayOptionControls, 0)]
        [TestCase(MethodCreateZaxisControls, 0)]
        [TestCase(MethodCreateYaxisControls, 0)]
        [TestCase(MethodCreateXaxisControls, 0)]
        [TestCase(MethodSetDropDownListSelectedValues, 0)]
        [TestCase(MethodSetupDropDownLists, 0)]
        [TestCase(MethodSetupCheckBoxes, 0)]
        [TestCase(MethodSetupAggregateTypeHtmlSelect, 0)]
        [TestCase(MethodSetTextBoxValues, 0)]
        [TestCase(MethodClearDropDownLists, 0)]
        [TestCase(MethodFillDropdowns, 0)]
        [TestCase(MethodSortDropDownList, 0)]
        [TestCase(MethodWriteXaxisSectionHtml, 0)]
        [TestCase(MethodWriteDisplayOptionsSectionHtml, 0)]
        [TestCase(MethodWriteYaxisSectionHtml, 0)]
        [TestCase(MethodWriteZaxisSectionHtml, 0)]
        [TestCase(MethodWriteOptionsSectionHtml, 0)]
        [TestCase(MethodWriteJavascript, 0)]
        [TestCase(MethodForcePageToNotCache, 0)]
        [TestCase(MethodIsBubbleChart, 0)]
        public void AUT_ChartControlToolpartBase_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_chartControlToolpartBaseInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChartControlToolpartBase) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ChartControlToolpartBase" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldChartTypeDropDownList)]
        [TestCase(FieldChartPaletteStyleDropDownList)]
        [TestCase(FieldListsDropDownList)]
        [TestCase(FieldViewsDropDownList)]
        [TestCase(FieldXaxisFieldDropDownList)]
        [TestCase(FieldBubbleChartColorFieldDropDownList)]
        [TestCase(FieldSeriesNameLabelPositionDropDownList)]
        [TestCase(FieldSeriesValueLabelPositionDropDownList)]
        [TestCase(FieldFrameColorDropDownList)]
        [TestCase(FieldZaxisFieldDropDownList)]
        [TestCase(FieldYaxisFieldAsDropDownList)]
        [TestCase(FieldYaxisFieldCheckBoxList)]
        [TestCase(FieldShowProjectsCheckBox)]
        [TestCase(FieldShowBubbleChartInputsInWebPart)]
        [TestCase(FieldShowIn3DCheckBox)]
        [TestCase(FieldShowLegendCheckBox)]
        [TestCase(FieldShowGridlinesCheckBox)]
        [TestCase(FieldShowLabelsCheckBox)]
        [TestCase(FieldShowSeriesNameAsLabelCheckBox)]
        [TestCase(FieldShowSeriesValueAsLabelCheckBox)]
        [TestCase(FieldShowYaxisValuesAsPercentageCheckBox)]
        [TestCase(FieldShowYaxisValuesAsCurrencyCheckBox)]
        [TestCase(FieldShowFrameCheckBox)]
        [TestCase(FieldFrameRoundCornersCheckBox)]
        [TestCase(FieldRollupCheckBox)]
        [TestCase(FieldShowZeroValueDataCheckBox)]
        [TestCase(FieldNumberOfYaxisValuesTextBox)]
        [TestCase(FieldXaxisLabelRotationAngleTextBox)]
        [TestCase(FieldXaxisLabelFontSizeTextBox)]
        [TestCase(FieldZaxisLabelRotationAngleTextBox)]
        [TestCase(FieldSeriesDataPointLabelFontSizeTextBox)]
        [TestCase(FieldChartLegendFontSizeCheckBox)]
        [TestCase(FieldRollupListsTextBox)]
        [TestCase(FieldRollupSitesTextBox)]
        [TestCase(FieldChartTitleTextBox)]
        [TestCase(FieldChartTitleFontSizeTextBox)]
        [TestCase(FieldAggregateTypeHtmlSelect)]
        public void AUT_ChartControlToolpartBase_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_chartControlToolpartBaseInstanceFixture, 
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
        ///     Class (<see cref="ChartControlToolpartBase" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ChartControlToolpartBase_Is_Instance_Present_Test()
        {
            // Assert
            _chartControlToolpartBaseInstanceType.ShouldNotBeNull();
            _chartControlToolpartBaseInstance.ShouldNotBeNull();
            _chartControlToolpartBaseInstanceFixture.ShouldNotBeNull();
            _chartControlToolpartBaseInstance.ShouldBeAssignableTo<ChartControlToolpartBase>();
            _chartControlToolpartBaseInstanceFixture.ShouldBeAssignableTo<ChartControlToolpartBase>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ChartControlToolpartBase) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ChartControlToolpartBase_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ChartControlToolpartBase instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _chartControlToolpartBaseInstanceType.ShouldNotBeNull();
            _chartControlToolpartBaseInstance.ShouldNotBeNull();
            _chartControlToolpartBaseInstanceFixture.ShouldNotBeNull();
            _chartControlToolpartBaseInstance.ShouldBeAssignableTo<ChartControlToolpartBase>();
            _chartControlToolpartBaseInstanceFixture.ShouldBeAssignableTo<ChartControlToolpartBase>();
        }

        #endregion

        #region General Constructor : Class (ChartControlToolpartBase) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ChartControlToolpartBase_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var chartControlToolpartBaseInstance  = new ChartControlToolpartBase();

            // Asserts
            chartControlToolpartBaseInstance.ShouldNotBeNull();
            chartControlToolpartBaseInstance.ShouldBeAssignableTo<ChartControlToolpartBase>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ChartControlToolpartBase" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodSortDropDownList)]
        [TestCase(MethodWriteOptionsSectionHtml)]
        [TestCase(MethodWriteJavascript)]
        public void AUT_ChartControlToolpartBase_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_chartControlToolpartBaseInstanceFixture,
                                                                              _chartControlToolpartBaseInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ChartControlToolpartBase" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnInit)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodRenderToolPart)]
        [TestCase(MethodChartTypeDropDownListSelectedIndexChanged)]
        [TestCase(MethodListsDropDownListSelectedIndexChanged)]
        [TestCase(MethodApplyChanges)]
        [TestCase(MethodCreateDisplayOptionControls)]
        [TestCase(MethodCreateZaxisControls)]
        [TestCase(MethodCreateYaxisControls)]
        [TestCase(MethodCreateXaxisControls)]
        [TestCase(MethodSetDropDownListSelectedValues)]
        [TestCase(MethodSetupDropDownLists)]
        [TestCase(MethodSetupCheckBoxes)]
        [TestCase(MethodSetupAggregateTypeHtmlSelect)]
        [TestCase(MethodSetTextBoxValues)]
        [TestCase(MethodClearDropDownLists)]
        [TestCase(MethodFillDropdowns)]
        [TestCase(MethodWriteXaxisSectionHtml)]
        [TestCase(MethodWriteDisplayOptionsSectionHtml)]
        [TestCase(MethodWriteYaxisSectionHtml)]
        [TestCase(MethodWriteZaxisSectionHtml)]
        [TestCase(MethodForcePageToNotCache)]
        [TestCase(MethodIsBubbleChart)]
        public void AUT_ChartControlToolpartBase_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ChartControlToolpartBase>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnInit, methodOnInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfOnInit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

            // Assert
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_OnInit_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnInit, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_ChartControlToolpartBase_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfOnPreRender);

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
        public void AUT_ChartControlToolpartBase_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

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
        public void AUT_ChartControlToolpartBase_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ChartControlToolpartBase_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_RenderToolPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderToolPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodRenderToolPart, Fixture, methodRenderToolPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_RenderToolPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderToolPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderToolPart, methodRenderToolPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfRenderToolPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderToolPart.ShouldNotBeNull();
            parametersOfRenderToolPart.Length.ShouldBe(1);
            methodRenderToolPartPrametersTypes.Length.ShouldBe(1);
            methodRenderToolPartPrametersTypes.Length.ShouldBe(parametersOfRenderToolPart.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_RenderToolPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderToolPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodRenderToolPart, parametersOfRenderToolPart, methodRenderToolPartPrametersTypes);

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
        public void AUT_ChartControlToolpartBase_RenderToolPart_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ChartControlToolpartBase_RenderToolPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodRenderToolPart, Fixture, methodRenderToolPartPrametersTypes);

            // Assert
            methodRenderToolPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_RenderToolPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderToolPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ChartTypeDropDownListSelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_ChartTypeDropDownListSelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodChartTypeDropDownListSelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodChartTypeDropDownListSelectedIndexChanged, Fixture, methodChartTypeDropDownListSelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ChartTypeDropDownListSelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ChartTypeDropDownListSelectedIndexChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodChartTypeDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfChartTypeDropDownListSelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodChartTypeDropDownListSelectedIndexChanged, methodChartTypeDropDownListSelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfChartTypeDropDownListSelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfChartTypeDropDownListSelectedIndexChanged.ShouldNotBeNull();
            parametersOfChartTypeDropDownListSelectedIndexChanged.Length.ShouldBe(2);
            methodChartTypeDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodChartTypeDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfChartTypeDropDownListSelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ChartTypeDropDownListSelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ChartTypeDropDownListSelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodChartTypeDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfChartTypeDropDownListSelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodChartTypeDropDownListSelectedIndexChanged, parametersOfChartTypeDropDownListSelectedIndexChanged, methodChartTypeDropDownListSelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfChartTypeDropDownListSelectedIndexChanged.ShouldNotBeNull();
            parametersOfChartTypeDropDownListSelectedIndexChanged.Length.ShouldBe(2);
            methodChartTypeDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodChartTypeDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfChartTypeDropDownListSelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ChartTypeDropDownListSelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ChartTypeDropDownListSelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodChartTypeDropDownListSelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ChartTypeDropDownListSelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ChartTypeDropDownListSelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodChartTypeDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodChartTypeDropDownListSelectedIndexChanged, Fixture, methodChartTypeDropDownListSelectedIndexChangedPrametersTypes);

            // Assert
            methodChartTypeDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ChartTypeDropDownListSelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ChartTypeDropDownListSelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodChartTypeDropDownListSelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListsDropDownListSelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_ListsDropDownListSelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodListsDropDownListSelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodListsDropDownListSelectedIndexChanged, Fixture, methodListsDropDownListSelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ListsDropDownListSelectedIndexChanged) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ListsDropDownListSelectedIndexChanged_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodListsDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfListsDropDownListSelectedIndexChanged = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodListsDropDownListSelectedIndexChanged, methodListsDropDownListSelectedIndexChangedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfListsDropDownListSelectedIndexChanged);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfListsDropDownListSelectedIndexChanged.ShouldNotBeNull();
            parametersOfListsDropDownListSelectedIndexChanged.Length.ShouldBe(2);
            methodListsDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodListsDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfListsDropDownListSelectedIndexChanged.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ListsDropDownListSelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ListsDropDownListSelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodListsDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfListsDropDownListSelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodListsDropDownListSelectedIndexChanged, parametersOfListsDropDownListSelectedIndexChanged, methodListsDropDownListSelectedIndexChangedPrametersTypes);

            // Assert
            parametersOfListsDropDownListSelectedIndexChanged.ShouldNotBeNull();
            parametersOfListsDropDownListSelectedIndexChanged.Length.ShouldBe(2);
            methodListsDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            methodListsDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(parametersOfListsDropDownListSelectedIndexChanged.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListsDropDownListSelectedIndexChanged) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ListsDropDownListSelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodListsDropDownListSelectedIndexChanged, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ListsDropDownListSelectedIndexChanged) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ListsDropDownListSelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListsDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodListsDropDownListSelectedIndexChanged, Fixture, methodListsDropDownListSelectedIndexChangedPrametersTypes);

            // Assert
            methodListsDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListsDropDownListSelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ListsDropDownListSelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListsDropDownListSelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_ApplyChanges_Method_Call_Internally(Type[] types)
        {
            var methodApplyChangesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodApplyChanges, Fixture, methodApplyChangesPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ApplyChanges_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _chartControlToolpartBaseInstance.ApplyChanges();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ApplyChanges_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;
            object[] parametersOfApplyChanges = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodApplyChanges, methodApplyChangesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfApplyChanges);

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
        public void AUT_ChartControlToolpartBase_ApplyChanges_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;
            object[] parametersOfApplyChanges = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodApplyChanges, parametersOfApplyChanges, methodApplyChangesPrametersTypes);

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
        public void AUT_ChartControlToolpartBase_ApplyChanges_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodApplyChanges, Fixture, methodApplyChangesPrametersTypes);

            // Assert
            methodApplyChangesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ApplyChanges_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyChanges, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDisplayOptionControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_CreateDisplayOptionControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateDisplayOptionControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodCreateDisplayOptionControls, Fixture, methodCreateDisplayOptionControlsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CreateDisplayOptionControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateDisplayOptionControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateDisplayOptionControlsPrametersTypes = null;
            object[] parametersOfCreateDisplayOptionControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodCreateDisplayOptionControls, parametersOfCreateDisplayOptionControls, methodCreateDisplayOptionControlsPrametersTypes);

            // Assert
            parametersOfCreateDisplayOptionControls.ShouldBeNull();
            methodCreateDisplayOptionControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDisplayOptionControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateDisplayOptionControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateDisplayOptionControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodCreateDisplayOptionControls, Fixture, methodCreateDisplayOptionControlsPrametersTypes);

            // Assert
            methodCreateDisplayOptionControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDisplayOptionControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateDisplayOptionControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateDisplayOptionControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateZaxisControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_CreateZaxisControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateZaxisControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodCreateZaxisControls, Fixture, methodCreateZaxisControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateZaxisControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateZaxisControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateZaxisControlsPrametersTypes = null;
            object[] parametersOfCreateZaxisControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodCreateZaxisControls, parametersOfCreateZaxisControls, methodCreateZaxisControlsPrametersTypes);

            // Assert
            parametersOfCreateZaxisControls.ShouldBeNull();
            methodCreateZaxisControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateZaxisControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateZaxisControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateZaxisControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodCreateZaxisControls, Fixture, methodCreateZaxisControlsPrametersTypes);

            // Assert
            methodCreateZaxisControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateZaxisControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateZaxisControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateZaxisControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateYaxisControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_CreateYaxisControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateYaxisControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodCreateYaxisControls, Fixture, methodCreateYaxisControlsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CreateYaxisControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateYaxisControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateYaxisControlsPrametersTypes = null;
            object[] parametersOfCreateYaxisControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodCreateYaxisControls, parametersOfCreateYaxisControls, methodCreateYaxisControlsPrametersTypes);

            // Assert
            parametersOfCreateYaxisControls.ShouldBeNull();
            methodCreateYaxisControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateYaxisControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateYaxisControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateYaxisControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodCreateYaxisControls, Fixture, methodCreateYaxisControlsPrametersTypes);

            // Assert
            methodCreateYaxisControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateYaxisControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateYaxisControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateYaxisControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateXaxisControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_CreateXaxisControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateXaxisControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodCreateXaxisControls, Fixture, methodCreateXaxisControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateXaxisControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateXaxisControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateXaxisControlsPrametersTypes = null;
            object[] parametersOfCreateXaxisControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodCreateXaxisControls, parametersOfCreateXaxisControls, methodCreateXaxisControlsPrametersTypes);

            // Assert
            parametersOfCreateXaxisControls.ShouldBeNull();
            methodCreateXaxisControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateXaxisControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateXaxisControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateXaxisControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodCreateXaxisControls, Fixture, methodCreateXaxisControlsPrametersTypes);

            // Assert
            methodCreateXaxisControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateXaxisControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_CreateXaxisControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateXaxisControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDropDownListSelectedValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_SetDropDownListSelectedValues_Method_Call_Internally(Type[] types)
        {
            var methodSetDropDownListSelectedValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodSetDropDownListSelectedValues, Fixture, methodSetDropDownListSelectedValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetDropDownListSelectedValues) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetDropDownListSelectedValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chart = CreateType<ChartControl>();
            var methodSetDropDownListSelectedValuesPrametersTypes = new Type[] { typeof(ChartControl) };
            object[] parametersOfSetDropDownListSelectedValues = { chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetDropDownListSelectedValues, methodSetDropDownListSelectedValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfSetDropDownListSelectedValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetDropDownListSelectedValues.ShouldNotBeNull();
            parametersOfSetDropDownListSelectedValues.Length.ShouldBe(1);
            methodSetDropDownListSelectedValuesPrametersTypes.Length.ShouldBe(1);
            methodSetDropDownListSelectedValuesPrametersTypes.Length.ShouldBe(parametersOfSetDropDownListSelectedValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDropDownListSelectedValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetDropDownListSelectedValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ChartControl>();
            var methodSetDropDownListSelectedValuesPrametersTypes = new Type[] { typeof(ChartControl) };
            object[] parametersOfSetDropDownListSelectedValues = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodSetDropDownListSelectedValues, parametersOfSetDropDownListSelectedValues, methodSetDropDownListSelectedValuesPrametersTypes);

            // Assert
            parametersOfSetDropDownListSelectedValues.ShouldNotBeNull();
            parametersOfSetDropDownListSelectedValues.Length.ShouldBe(1);
            methodSetDropDownListSelectedValuesPrametersTypes.Length.ShouldBe(1);
            methodSetDropDownListSelectedValuesPrametersTypes.Length.ShouldBe(parametersOfSetDropDownListSelectedValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDropDownListSelectedValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetDropDownListSelectedValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetDropDownListSelectedValues, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetDropDownListSelectedValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetDropDownListSelectedValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDropDownListSelectedValuesPrametersTypes = new Type[] { typeof(ChartControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodSetDropDownListSelectedValues, Fixture, methodSetDropDownListSelectedValuesPrametersTypes);

            // Assert
            methodSetDropDownListSelectedValuesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDropDownListSelectedValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetDropDownListSelectedValues_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDropDownListSelectedValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupDropDownLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_SetupDropDownLists_Method_Call_Internally(Type[] types)
        {
            var methodSetupDropDownListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodSetupDropDownLists, Fixture, methodSetupDropDownListsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetupDropDownLists) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupDropDownLists_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var chart = CreateType<ChartControl>();
            var methodSetupDropDownListsPrametersTypes = new Type[] { typeof(SPWeb), typeof(ChartControl) };
            object[] parametersOfSetupDropDownLists = { web, chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetupDropDownLists, methodSetupDropDownListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfSetupDropDownLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetupDropDownLists.ShouldNotBeNull();
            parametersOfSetupDropDownLists.Length.ShouldBe(2);
            methodSetupDropDownListsPrametersTypes.Length.ShouldBe(2);
            methodSetupDropDownListsPrametersTypes.Length.ShouldBe(parametersOfSetupDropDownLists.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetupDropDownLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupDropDownLists_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var chart = CreateType<ChartControl>();
            var methodSetupDropDownListsPrametersTypes = new Type[] { typeof(SPWeb), typeof(ChartControl) };
            object[] parametersOfSetupDropDownLists = { web, chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodSetupDropDownLists, parametersOfSetupDropDownLists, methodSetupDropDownListsPrametersTypes);

            // Assert
            parametersOfSetupDropDownLists.ShouldNotBeNull();
            parametersOfSetupDropDownLists.Length.ShouldBe(2);
            methodSetupDropDownListsPrametersTypes.Length.ShouldBe(2);
            methodSetupDropDownListsPrametersTypes.Length.ShouldBe(parametersOfSetupDropDownLists.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupDropDownLists) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupDropDownLists_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetupDropDownLists, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetupDropDownLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupDropDownLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetupDropDownListsPrametersTypes = new Type[] { typeof(SPWeb), typeof(ChartControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodSetupDropDownLists, Fixture, methodSetupDropDownListsPrametersTypes);

            // Assert
            methodSetupDropDownListsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupDropDownLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupDropDownLists_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetupDropDownLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupCheckBoxes) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_SetupCheckBoxes_Method_Call_Internally(Type[] types)
        {
            var methodSetupCheckBoxesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodSetupCheckBoxes, Fixture, methodSetupCheckBoxesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetupCheckBoxes) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupCheckBoxes_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chart = CreateType<ChartControl>();
            var methodSetupCheckBoxesPrametersTypes = new Type[] { typeof(ChartControl) };
            object[] parametersOfSetupCheckBoxes = { chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetupCheckBoxes, methodSetupCheckBoxesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfSetupCheckBoxes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetupCheckBoxes.ShouldNotBeNull();
            parametersOfSetupCheckBoxes.Length.ShouldBe(1);
            methodSetupCheckBoxesPrametersTypes.Length.ShouldBe(1);
            methodSetupCheckBoxesPrametersTypes.Length.ShouldBe(parametersOfSetupCheckBoxes.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupCheckBoxes) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupCheckBoxes_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ChartControl>();
            var methodSetupCheckBoxesPrametersTypes = new Type[] { typeof(ChartControl) };
            object[] parametersOfSetupCheckBoxes = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodSetupCheckBoxes, parametersOfSetupCheckBoxes, methodSetupCheckBoxesPrametersTypes);

            // Assert
            parametersOfSetupCheckBoxes.ShouldNotBeNull();
            parametersOfSetupCheckBoxes.Length.ShouldBe(1);
            methodSetupCheckBoxesPrametersTypes.Length.ShouldBe(1);
            methodSetupCheckBoxesPrametersTypes.Length.ShouldBe(parametersOfSetupCheckBoxes.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupCheckBoxes) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupCheckBoxes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetupCheckBoxes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetupCheckBoxes) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupCheckBoxes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetupCheckBoxesPrametersTypes = new Type[] { typeof(ChartControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodSetupCheckBoxes, Fixture, methodSetupCheckBoxesPrametersTypes);

            // Assert
            methodSetupCheckBoxesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupCheckBoxes) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupCheckBoxes_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetupCheckBoxes, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupAggregateTypeHtmlSelect) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_SetupAggregateTypeHtmlSelect_Method_Call_Internally(Type[] types)
        {
            var methodSetupAggregateTypeHtmlSelectPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodSetupAggregateTypeHtmlSelect, Fixture, methodSetupAggregateTypeHtmlSelectPrametersTypes);
        }

        #endregion

        #region Method Call : (SetupAggregateTypeHtmlSelect) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupAggregateTypeHtmlSelect_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chart = CreateType<ChartControl>();
            var methodSetupAggregateTypeHtmlSelectPrametersTypes = new Type[] { typeof(ChartControl) };
            object[] parametersOfSetupAggregateTypeHtmlSelect = { chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetupAggregateTypeHtmlSelect, methodSetupAggregateTypeHtmlSelectPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfSetupAggregateTypeHtmlSelect);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetupAggregateTypeHtmlSelect.ShouldNotBeNull();
            parametersOfSetupAggregateTypeHtmlSelect.Length.ShouldBe(1);
            methodSetupAggregateTypeHtmlSelectPrametersTypes.Length.ShouldBe(1);
            methodSetupAggregateTypeHtmlSelectPrametersTypes.Length.ShouldBe(parametersOfSetupAggregateTypeHtmlSelect.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupAggregateTypeHtmlSelect) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupAggregateTypeHtmlSelect_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ChartControl>();
            var methodSetupAggregateTypeHtmlSelectPrametersTypes = new Type[] { typeof(ChartControl) };
            object[] parametersOfSetupAggregateTypeHtmlSelect = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodSetupAggregateTypeHtmlSelect, parametersOfSetupAggregateTypeHtmlSelect, methodSetupAggregateTypeHtmlSelectPrametersTypes);

            // Assert
            parametersOfSetupAggregateTypeHtmlSelect.ShouldNotBeNull();
            parametersOfSetupAggregateTypeHtmlSelect.Length.ShouldBe(1);
            methodSetupAggregateTypeHtmlSelectPrametersTypes.Length.ShouldBe(1);
            methodSetupAggregateTypeHtmlSelectPrametersTypes.Length.ShouldBe(parametersOfSetupAggregateTypeHtmlSelect.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupAggregateTypeHtmlSelect) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupAggregateTypeHtmlSelect_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetupAggregateTypeHtmlSelect, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetupAggregateTypeHtmlSelect) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupAggregateTypeHtmlSelect_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetupAggregateTypeHtmlSelectPrametersTypes = new Type[] { typeof(ChartControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodSetupAggregateTypeHtmlSelect, Fixture, methodSetupAggregateTypeHtmlSelectPrametersTypes);

            // Assert
            methodSetupAggregateTypeHtmlSelectPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupAggregateTypeHtmlSelect) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetupAggregateTypeHtmlSelect_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetupAggregateTypeHtmlSelect, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTextBoxValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_SetTextBoxValues_Method_Call_Internally(Type[] types)
        {
            var methodSetTextBoxValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodSetTextBoxValues, Fixture, methodSetTextBoxValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTextBoxValues) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetTextBoxValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chart = CreateType<ChartControl>();
            var methodSetTextBoxValuesPrametersTypes = new Type[] { typeof(ChartControl) };
            object[] parametersOfSetTextBoxValues = { chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTextBoxValues, methodSetTextBoxValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfSetTextBoxValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetTextBoxValues.ShouldNotBeNull();
            parametersOfSetTextBoxValues.Length.ShouldBe(1);
            methodSetTextBoxValuesPrametersTypes.Length.ShouldBe(1);
            methodSetTextBoxValuesPrametersTypes.Length.ShouldBe(parametersOfSetTextBoxValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTextBoxValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetTextBoxValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ChartControl>();
            var methodSetTextBoxValuesPrametersTypes = new Type[] { typeof(ChartControl) };
            object[] parametersOfSetTextBoxValues = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodSetTextBoxValues, parametersOfSetTextBoxValues, methodSetTextBoxValuesPrametersTypes);

            // Assert
            parametersOfSetTextBoxValues.ShouldNotBeNull();
            parametersOfSetTextBoxValues.Length.ShouldBe(1);
            methodSetTextBoxValuesPrametersTypes.Length.ShouldBe(1);
            methodSetTextBoxValuesPrametersTypes.Length.ShouldBe(parametersOfSetTextBoxValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTextBoxValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetTextBoxValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetTextBoxValues, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetTextBoxValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetTextBoxValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTextBoxValuesPrametersTypes = new Type[] { typeof(ChartControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodSetTextBoxValues, Fixture, methodSetTextBoxValuesPrametersTypes);

            // Assert
            methodSetTextBoxValuesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTextBoxValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SetTextBoxValues_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTextBoxValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearDropDownLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_ClearDropDownLists_Method_Call_Internally(Type[] types)
        {
            var methodClearDropDownListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodClearDropDownLists, Fixture, methodClearDropDownListsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (ClearDropDownLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ClearDropDownLists_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodClearDropDownListsPrametersTypes = null;
            object[] parametersOfClearDropDownLists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodClearDropDownLists, parametersOfClearDropDownLists, methodClearDropDownListsPrametersTypes);

            // Assert
            parametersOfClearDropDownLists.ShouldBeNull();
            methodClearDropDownListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearDropDownLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ClearDropDownLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodClearDropDownListsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodClearDropDownLists, Fixture, methodClearDropDownListsPrametersTypes);

            // Assert
            methodClearDropDownListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ClearDropDownLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ClearDropDownLists_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodClearDropDownLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillDropdowns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_FillDropdowns_Method_Call_Internally(Type[] types)
        {
            var methodFillDropdownsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodFillDropdowns, Fixture, methodFillDropdownsPrametersTypes);
        }

        #endregion

        #region Method Call : (FillDropdowns) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_FillDropdowns_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var oList = CreateType<SPList>();
            var methodFillDropdownsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfFillDropdowns = { oList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFillDropdowns, methodFillDropdownsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfFillDropdowns);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFillDropdowns.ShouldNotBeNull();
            parametersOfFillDropdowns.Length.ShouldBe(1);
            methodFillDropdownsPrametersTypes.Length.ShouldBe(1);
            methodFillDropdownsPrametersTypes.Length.ShouldBe(parametersOfFillDropdowns.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FillDropdowns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_FillDropdowns_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var oList = CreateType<SPList>();
            var methodFillDropdownsPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfFillDropdowns = { oList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodFillDropdowns, parametersOfFillDropdowns, methodFillDropdownsPrametersTypes);

            // Assert
            parametersOfFillDropdowns.ShouldNotBeNull();
            parametersOfFillDropdowns.Length.ShouldBe(1);
            methodFillDropdownsPrametersTypes.Length.ShouldBe(1);
            methodFillDropdownsPrametersTypes.Length.ShouldBe(parametersOfFillDropdowns.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillDropdowns) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_FillDropdowns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFillDropdowns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FillDropdowns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_FillDropdowns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFillDropdownsPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodFillDropdowns, Fixture, methodFillDropdownsPrametersTypes);

            // Assert
            methodFillDropdownsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillDropdowns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_FillDropdowns_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFillDropdowns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortDropDownList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_SortDropDownList_Static_Method_Call_Internally(Type[] types)
        {
            var methodSortDropDownListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstanceFixture, _chartControlToolpartBaseInstanceType, MethodSortDropDownList, Fixture, methodSortDropDownListPrametersTypes);
        }

        #endregion

        #region Method Call : (SortDropDownList) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SortDropDownList_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dropDownList = CreateType<DropDownList>();
            var methodSortDropDownListPrametersTypes = new Type[] { typeof(DropDownList) };
            object[] parametersOfSortDropDownList = { dropDownList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSortDropDownList, methodSortDropDownListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfSortDropDownList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSortDropDownList.ShouldNotBeNull();
            parametersOfSortDropDownList.Length.ShouldBe(1);
            methodSortDropDownListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortDropDownList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SortDropDownList_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dropDownList = CreateType<DropDownList>();
            var methodSortDropDownListPrametersTypes = new Type[] { typeof(DropDownList) };
            object[] parametersOfSortDropDownList = { dropDownList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_chartControlToolpartBaseInstanceFixture, _chartControlToolpartBaseInstanceType, MethodSortDropDownList, parametersOfSortDropDownList, methodSortDropDownListPrametersTypes);

            // Assert
            parametersOfSortDropDownList.ShouldNotBeNull();
            parametersOfSortDropDownList.Length.ShouldBe(1);
            methodSortDropDownListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortDropDownList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SortDropDownList_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSortDropDownList, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SortDropDownList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SortDropDownList_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSortDropDownListPrametersTypes = new Type[] { typeof(DropDownList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstanceFixture, _chartControlToolpartBaseInstanceType, MethodSortDropDownList, Fixture, methodSortDropDownListPrametersTypes);

            // Assert
            methodSortDropDownListPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortDropDownList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_SortDropDownList_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSortDropDownList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteXaxisSectionHtml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_WriteXaxisSectionHtml_Method_Call_Internally(Type[] types)
        {
            var methodWriteXaxisSectionHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodWriteXaxisSectionHtml, Fixture, methodWriteXaxisSectionHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteXaxisSectionHtml) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteXaxisSectionHtml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteXaxisSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteXaxisSectionHtml = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteXaxisSectionHtml, methodWriteXaxisSectionHtmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfWriteXaxisSectionHtml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteXaxisSectionHtml.ShouldNotBeNull();
            parametersOfWriteXaxisSectionHtml.Length.ShouldBe(1);
            methodWriteXaxisSectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteXaxisSectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteXaxisSectionHtml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteXaxisSectionHtml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteXaxisSectionHtml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteXaxisSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteXaxisSectionHtml = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodWriteXaxisSectionHtml, parametersOfWriteXaxisSectionHtml, methodWriteXaxisSectionHtmlPrametersTypes);

            // Assert
            parametersOfWriteXaxisSectionHtml.ShouldNotBeNull();
            parametersOfWriteXaxisSectionHtml.Length.ShouldBe(1);
            methodWriteXaxisSectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteXaxisSectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteXaxisSectionHtml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteXaxisSectionHtml) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteXaxisSectionHtml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteXaxisSectionHtml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteXaxisSectionHtml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteXaxisSectionHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteXaxisSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodWriteXaxisSectionHtml, Fixture, methodWriteXaxisSectionHtmlPrametersTypes);

            // Assert
            methodWriteXaxisSectionHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteXaxisSectionHtml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteXaxisSectionHtml_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteXaxisSectionHtml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteDisplayOptionsSectionHtml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_WriteDisplayOptionsSectionHtml_Method_Call_Internally(Type[] types)
        {
            var methodWriteDisplayOptionsSectionHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodWriteDisplayOptionsSectionHtml, Fixture, methodWriteDisplayOptionsSectionHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteDisplayOptionsSectionHtml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteDisplayOptionsSectionHtml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteDisplayOptionsSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteDisplayOptionsSectionHtml = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodWriteDisplayOptionsSectionHtml, parametersOfWriteDisplayOptionsSectionHtml, methodWriteDisplayOptionsSectionHtmlPrametersTypes);

            // Assert
            parametersOfWriteDisplayOptionsSectionHtml.ShouldNotBeNull();
            parametersOfWriteDisplayOptionsSectionHtml.Length.ShouldBe(1);
            methodWriteDisplayOptionsSectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteDisplayOptionsSectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteDisplayOptionsSectionHtml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteDisplayOptionsSectionHtml) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteDisplayOptionsSectionHtml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteDisplayOptionsSectionHtml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteDisplayOptionsSectionHtml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteDisplayOptionsSectionHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteDisplayOptionsSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodWriteDisplayOptionsSectionHtml, Fixture, methodWriteDisplayOptionsSectionHtmlPrametersTypes);

            // Assert
            methodWriteDisplayOptionsSectionHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteYaxisSectionHtml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_WriteYaxisSectionHtml_Method_Call_Internally(Type[] types)
        {
            var methodWriteYaxisSectionHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodWriteYaxisSectionHtml, Fixture, methodWriteYaxisSectionHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteYaxisSectionHtml) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteYaxisSectionHtml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteYaxisSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteYaxisSectionHtml = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteYaxisSectionHtml, methodWriteYaxisSectionHtmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfWriteYaxisSectionHtml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteYaxisSectionHtml.ShouldNotBeNull();
            parametersOfWriteYaxisSectionHtml.Length.ShouldBe(1);
            methodWriteYaxisSectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteYaxisSectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteYaxisSectionHtml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteYaxisSectionHtml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteYaxisSectionHtml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteYaxisSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteYaxisSectionHtml = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodWriteYaxisSectionHtml, parametersOfWriteYaxisSectionHtml, methodWriteYaxisSectionHtmlPrametersTypes);

            // Assert
            parametersOfWriteYaxisSectionHtml.ShouldNotBeNull();
            parametersOfWriteYaxisSectionHtml.Length.ShouldBe(1);
            methodWriteYaxisSectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteYaxisSectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteYaxisSectionHtml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteYaxisSectionHtml) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteYaxisSectionHtml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteYaxisSectionHtml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteYaxisSectionHtml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteYaxisSectionHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteYaxisSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodWriteYaxisSectionHtml, Fixture, methodWriteYaxisSectionHtmlPrametersTypes);

            // Assert
            methodWriteYaxisSectionHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteYaxisSectionHtml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteYaxisSectionHtml_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteYaxisSectionHtml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteZaxisSectionHtml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_WriteZaxisSectionHtml_Method_Call_Internally(Type[] types)
        {
            var methodWriteZaxisSectionHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodWriteZaxisSectionHtml, Fixture, methodWriteZaxisSectionHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteZaxisSectionHtml) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteZaxisSectionHtml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteZaxisSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteZaxisSectionHtml = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteZaxisSectionHtml, methodWriteZaxisSectionHtmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfWriteZaxisSectionHtml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteZaxisSectionHtml.ShouldNotBeNull();
            parametersOfWriteZaxisSectionHtml.Length.ShouldBe(1);
            methodWriteZaxisSectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteZaxisSectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteZaxisSectionHtml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteZaxisSectionHtml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteZaxisSectionHtml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteZaxisSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteZaxisSectionHtml = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodWriteZaxisSectionHtml, parametersOfWriteZaxisSectionHtml, methodWriteZaxisSectionHtmlPrametersTypes);

            // Assert
            parametersOfWriteZaxisSectionHtml.ShouldNotBeNull();
            parametersOfWriteZaxisSectionHtml.Length.ShouldBe(1);
            methodWriteZaxisSectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteZaxisSectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteZaxisSectionHtml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteZaxisSectionHtml) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteZaxisSectionHtml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteZaxisSectionHtml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteZaxisSectionHtml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteZaxisSectionHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteZaxisSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodWriteZaxisSectionHtml, Fixture, methodWriteZaxisSectionHtmlPrametersTypes);

            // Assert
            methodWriteZaxisSectionHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteZaxisSectionHtml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteZaxisSectionHtml_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteZaxisSectionHtml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteOptionsSectionHtml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_WriteOptionsSectionHtml_Static_Method_Call_Internally(Type[] types)
        {
            var methodWriteOptionsSectionHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstanceFixture, _chartControlToolpartBaseInstanceType, MethodWriteOptionsSectionHtml, Fixture, methodWriteOptionsSectionHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteOptionsSectionHtml) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteOptionsSectionHtml_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteOptionsSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteOptionsSectionHtml = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteOptionsSectionHtml, methodWriteOptionsSectionHtmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfWriteOptionsSectionHtml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteOptionsSectionHtml.ShouldNotBeNull();
            parametersOfWriteOptionsSectionHtml.Length.ShouldBe(1);
            methodWriteOptionsSectionHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteOptionsSectionHtml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteOptionsSectionHtml_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteOptionsSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteOptionsSectionHtml = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_chartControlToolpartBaseInstanceFixture, _chartControlToolpartBaseInstanceType, MethodWriteOptionsSectionHtml, parametersOfWriteOptionsSectionHtml, methodWriteOptionsSectionHtmlPrametersTypes);

            // Assert
            parametersOfWriteOptionsSectionHtml.ShouldNotBeNull();
            parametersOfWriteOptionsSectionHtml.Length.ShouldBe(1);
            methodWriteOptionsSectionHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteOptionsSectionHtml) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteOptionsSectionHtml_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteOptionsSectionHtml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteOptionsSectionHtml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteOptionsSectionHtml_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteOptionsSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstanceFixture, _chartControlToolpartBaseInstanceType, MethodWriteOptionsSectionHtml, Fixture, methodWriteOptionsSectionHtmlPrametersTypes);

            // Assert
            methodWriteOptionsSectionHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteOptionsSectionHtml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteOptionsSectionHtml_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteOptionsSectionHtml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_WriteJavascript_Static_Method_Call_Internally(Type[] types)
        {
            var methodWriteJavascriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstanceFixture, _chartControlToolpartBaseInstanceType, MethodWriteJavascript, Fixture, methodWriteJavascriptPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteJavascript_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteJavascriptPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteJavascript = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteJavascript, methodWriteJavascriptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfWriteJavascript);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteJavascript.ShouldNotBeNull();
            parametersOfWriteJavascript.Length.ShouldBe(1);
            methodWriteJavascriptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteJavascript_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteJavascriptPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteJavascript = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_chartControlToolpartBaseInstanceFixture, _chartControlToolpartBaseInstanceType, MethodWriteJavascript, parametersOfWriteJavascript, methodWriteJavascriptPrametersTypes);

            // Assert
            parametersOfWriteJavascript.ShouldNotBeNull();
            parametersOfWriteJavascript.Length.ShouldBe(1);
            methodWriteJavascriptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteJavascript_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteJavascript, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteJavascript_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteJavascriptPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstanceFixture, _chartControlToolpartBaseInstanceType, MethodWriteJavascript, Fixture, methodWriteJavascriptPrametersTypes);

            // Assert
            methodWriteJavascriptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_WriteJavascript_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteJavascript, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ForcePageToNotCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_ForcePageToNotCache_Method_Call_Internally(Type[] types)
        {
            var methodForcePageToNotCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodForcePageToNotCache, Fixture, methodForcePageToNotCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ForcePageToNotCache) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ForcePageToNotCache_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodForcePageToNotCachePrametersTypes = null;
            object[] parametersOfForcePageToNotCache = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodForcePageToNotCache, methodForcePageToNotCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlToolpartBaseInstanceFixture, parametersOfForcePageToNotCache);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfForcePageToNotCache.ShouldBeNull();
            methodForcePageToNotCachePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ForcePageToNotCache) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ForcePageToNotCache_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodForcePageToNotCachePrametersTypes = null;
            object[] parametersOfForcePageToNotCache = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlToolpartBaseInstance, MethodForcePageToNotCache, parametersOfForcePageToNotCache, methodForcePageToNotCachePrametersTypes);

            // Assert
            parametersOfForcePageToNotCache.ShouldBeNull();
            methodForcePageToNotCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ForcePageToNotCache) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ForcePageToNotCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodForcePageToNotCachePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodForcePageToNotCache, Fixture, methodForcePageToNotCachePrametersTypes);

            // Assert
            methodForcePageToNotCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ForcePageToNotCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_ForcePageToNotCache_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodForcePageToNotCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlToolpartBaseInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControlToolpartBase_IsBubbleChart_Method_Call_Internally(Type[] types)
        {
            var methodIsBubbleChartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_IsBubbleChart_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChartControlToolpartBase, bool>(_chartControlToolpartBaseInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChartControlToolpartBase, bool>(_chartControlToolpartBaseInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsBubbleChart.ShouldBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_IsBubbleChart_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChartControlToolpartBase, bool>(_chartControlToolpartBaseInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChartControlToolpartBase, bool>(_chartControlToolpartBaseInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsBubbleChart.ShouldBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion
        
        #region Method Call : (IsBubbleChart) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_IsBubbleChart_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControlToolpartBase, bool>(_chartControlToolpartBaseInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

            // Assert
            parametersOfIsBubbleChart.ShouldBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ChartControlToolpartBase_IsBubbleChart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlToolpartBaseInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion
        
        #endregion

        #endregion
    }
}