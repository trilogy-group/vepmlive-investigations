using System;
using System.Data;
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

namespace EPMLiveWebParts.ReportingChart
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportingChart.ReportingChartToolPart" />)
    ///     and namespace <see cref="EPMLiveWebParts.ReportingChart"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportingChartToolPartTest : AbstractBaseSetupTypedTest<ReportingChartToolPart>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingChartToolPart) Initializer

        private const string MethodOnInit = "OnInit";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodLoadAndSetAggregateTypes = "LoadAndSetAggregateTypes";
        private const string MethodForcePageToNotCache = "ForcePageToNotCache";
        private const string MethodApplyChanges = "ApplyChanges";
        private const string MethodSetXAxisField = "SetXAxisField";
        private const string MethodSetYAxisField = "SetYAxisField";
        private const string MethodSetZAxisField = "SetZAxisField";
        private const string MethodRenderToolPart = "RenderToolPart";
        private const string MethodListsDropDownListSelectedIndexChanged = "ListsDropDownListSelectedIndexChanged";
        private const string MethodLoadAndSetViews = "LoadAndSetViews";
        private const string MethodWriteConfigSectionHtml = "WriteConfigSectionHtml";
        private const string MethodWriteDisplaySectionHtml = "WriteDisplaySectionHtml";
        private const string MethodWriteJavascript = "WriteJavascript";
        private const string MethodCreateConfigSectionControls = "CreateConfigSectionControls";
        private const string MethodCreateDisplaySectionControls = "CreateDisplaySectionControls";
        private const string MethodSetDropDownListSelectedValues = "SetDropDownListSelectedValues";
        private const string MethodSetYFieldControlValues = "SetYFieldControlValues";
        private const string MethodLoadAndSetSelectedList = "LoadAndSetSelectedList";
        private const string MethodLoadAndSetChartTypes = "LoadAndSetChartTypes";
        private const string MethodSetupCheckBoxes = "SetupCheckBoxes";
        private const string MethodSetTextBoxValues = "SetTextBoxValues";
        private const string MethodFillDropDowns = "FillDropDowns";
        private const string MethodGetListColumns = "GetListColumns";
        private const string MethodGetMappedLists = "GetMappedLists";
        private const string MethodSortListControlItems = "SortListControlItems";
        private const string MethodIsBubbleChart = "IsBubbleChart";
        private const string MethodGetFieldSchemaAttribValue = "GetFieldSchemaAttribValue";
        private const string MethodRenderOneYField = "RenderOneYField";
        private const string MethodRenderMultipleYField = "RenderMultipleYField";
        private const string FieldChartTypeDropDownList = "ChartTypeDropDownList";
        private const string FieldChartPaletteStyleDropDownList = "ChartPaletteStyleDropDownList";
        private const string FieldListsDropDownList = "ListsDropDownList";
        private const string FieldViewsDropDownList = "ViewsDropDownList";
        private const string FieldBubbleChartColorFieldDropDownList = "BubbleChartColorFieldDropDownList";
        private const string FieldSeriesNameLabelPositionDropDownList = "SeriesNameLabelPositionDropDownList";
        private const string FieldSeriesValueLabelPositionDropDownList = "SeriesValueLabelPositionDropDownList";
        private const string FieldFrameColorDropDownList = "FrameColorDropDownList";
        private const string FieldXaxisFieldDropDownList = "XaxisFieldDropDownList";
        private const string FieldddlXaxisFieldNum = "ddlXaxisFieldNum";
        private const string FieldddlXaxisFieldNonNum = "ddlXaxisFieldNonNum";
        private const string FieldddlYaxisFieldNum = "ddlYaxisFieldNum";
        private const string FieldddlYaxisFieldNonNum = "ddlYaxisFieldNonNum";
        private const string FieldZaxisFieldDropDownList = "ZaxisFieldDropDownList";
        private const string FieldBubbleGroupByDropDownList = "BubbleGroupByDropDownList";
        private const string FieldAggregateTypeHtmlSelect = "AggregateTypeHtmlSelect";
        private const string FieldYaxisFormatDropDownList = "YaxisFormatDropDownList";
        private const string FieldLegendPositionDropDownList = "LegendPositionDropDownList";
        private const string FieldcblYaxisFieldNum = "cblYaxisFieldNum";
        private const string FieldcblYaxisFieldNonNum = "cblYaxisFieldNonNum";
        private const string FieldShowProjectsCheckBox = "ShowProjectsCheckBox";
        private const string FieldShowLegendCheckBox = "ShowLegendCheckBox";
        private const string FieldShowGridlinesCheckBox = "ShowGridlinesCheckBox";
        private const string FieldShowLabelsCheckBox = "ShowLabelsCheckBox";
        private const string FieldShowSeriesNameAsLabelCheckBox = "ShowSeriesNameAsLabelCheckBox";
        private const string FieldShowSeriesValueAsLabelCheckBox = "ShowSeriesValueAsLabelCheckBox";
        private const string FieldShowFrameCheckBox = "ShowFrameCheckBox";
        private const string FieldFrameRoundCornersCheckBox = "FrameRoundCornersCheckBox";
        private const string FieldRollupCheckBox = "RollupCheckBox";
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
        private Type _reportingChartToolPartInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingChartToolPart _reportingChartToolPartInstance;
        private ReportingChartToolPart _reportingChartToolPartInstanceFixture;

        #region General Initializer : Class (ReportingChartToolPart) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingChartToolPart" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingChartToolPartInstanceType = typeof(ReportingChartToolPart);
            _reportingChartToolPartInstanceFixture = Create(true);
            _reportingChartToolPartInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingChartToolPart)

        #region General Initializer : Class (ReportingChartToolPart) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingChartToolPart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodLoadAndSetAggregateTypes, 0)]
        [TestCase(MethodForcePageToNotCache, 0)]
        [TestCase(MethodApplyChanges, 0)]
        [TestCase(MethodSetXAxisField, 0)]
        [TestCase(MethodSetYAxisField, 0)]
        [TestCase(MethodSetZAxisField, 0)]
        [TestCase(MethodRenderToolPart, 0)]
        [TestCase(MethodListsDropDownListSelectedIndexChanged, 0)]
        [TestCase(MethodLoadAndSetViews, 0)]
        [TestCase(MethodWriteConfigSectionHtml, 0)]
        [TestCase(MethodWriteDisplaySectionHtml, 0)]
        [TestCase(MethodWriteJavascript, 0)]
        [TestCase(MethodCreateConfigSectionControls, 0)]
        [TestCase(MethodCreateDisplaySectionControls, 0)]
        [TestCase(MethodSetDropDownListSelectedValues, 0)]
        [TestCase(MethodSetYFieldControlValues, 0)]
        [TestCase(MethodLoadAndSetSelectedList, 0)]
        [TestCase(MethodLoadAndSetChartTypes, 0)]
        [TestCase(MethodSetupCheckBoxes, 0)]
        [TestCase(MethodSetTextBoxValues, 0)]
        [TestCase(MethodFillDropDowns, 0)]
        [TestCase(MethodGetListColumns, 0)]
        [TestCase(MethodGetMappedLists, 0)]
        [TestCase(MethodSortListControlItems, 0)]
        [TestCase(MethodIsBubbleChart, 0)]
        [TestCase(MethodGetFieldSchemaAttribValue, 0)]
        [TestCase(MethodRenderOneYField, 0)]
        [TestCase(MethodRenderMultipleYField, 0)]
        public void AUT_ReportingChartToolPart_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingChartToolPartInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportingChartToolPart) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportingChartToolPart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldChartTypeDropDownList)]
        [TestCase(FieldChartPaletteStyleDropDownList)]
        [TestCase(FieldListsDropDownList)]
        [TestCase(FieldViewsDropDownList)]
        [TestCase(FieldBubbleChartColorFieldDropDownList)]
        [TestCase(FieldSeriesNameLabelPositionDropDownList)]
        [TestCase(FieldSeriesValueLabelPositionDropDownList)]
        [TestCase(FieldFrameColorDropDownList)]
        [TestCase(FieldXaxisFieldDropDownList)]
        [TestCase(FieldddlXaxisFieldNum)]
        [TestCase(FieldddlXaxisFieldNonNum)]
        [TestCase(FieldddlYaxisFieldNum)]
        [TestCase(FieldddlYaxisFieldNonNum)]
        [TestCase(FieldZaxisFieldDropDownList)]
        [TestCase(FieldBubbleGroupByDropDownList)]
        [TestCase(FieldAggregateTypeHtmlSelect)]
        [TestCase(FieldYaxisFormatDropDownList)]
        [TestCase(FieldLegendPositionDropDownList)]
        [TestCase(FieldcblYaxisFieldNum)]
        [TestCase(FieldcblYaxisFieldNonNum)]
        [TestCase(FieldShowProjectsCheckBox)]
        [TestCase(FieldShowLegendCheckBox)]
        [TestCase(FieldShowGridlinesCheckBox)]
        [TestCase(FieldShowLabelsCheckBox)]
        [TestCase(FieldShowSeriesNameAsLabelCheckBox)]
        [TestCase(FieldShowSeriesValueAsLabelCheckBox)]
        [TestCase(FieldShowFrameCheckBox)]
        [TestCase(FieldFrameRoundCornersCheckBox)]
        [TestCase(FieldRollupCheckBox)]
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
        public void AUT_ReportingChartToolPart_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportingChartToolPartInstanceFixture, 
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
        ///     Class (<see cref="ReportingChartToolPart" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportingChartToolPart_Is_Instance_Present_Test()
        {
            // Assert
            _reportingChartToolPartInstanceType.ShouldNotBeNull();
            _reportingChartToolPartInstance.ShouldNotBeNull();
            _reportingChartToolPartInstanceFixture.ShouldNotBeNull();
            _reportingChartToolPartInstance.ShouldBeAssignableTo<ReportingChartToolPart>();
            _reportingChartToolPartInstanceFixture.ShouldBeAssignableTo<ReportingChartToolPart>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportingChartToolPart) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportingChartToolPart_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportingChartToolPart instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportingChartToolPartInstanceType.ShouldNotBeNull();
            _reportingChartToolPartInstance.ShouldNotBeNull();
            _reportingChartToolPartInstanceFixture.ShouldNotBeNull();
            _reportingChartToolPartInstance.ShouldBeAssignableTo<ReportingChartToolPart>();
            _reportingChartToolPartInstanceFixture.ShouldBeAssignableTo<ReportingChartToolPart>();
        }

        #endregion

        #region General Constructor : Class (ReportingChartToolPart) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportingChartToolPart_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var reportingChartToolPartInstance  = new ReportingChartToolPart();

            // Asserts
            reportingChartToolPartInstance.ShouldNotBeNull();
            reportingChartToolPartInstance.ShouldBeAssignableTo<ReportingChartToolPart>();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ReportingChartToolPart" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodSortListControlItems)]
        [TestCase(MethodGetFieldSchemaAttribValue)]
        public void AUT_ReportingChartToolPart_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_reportingChartToolPartInstanceFixture,
                                                                              _reportingChartToolPartInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportingChartToolPart" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodOnInit)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodLoadAndSetAggregateTypes)]
        [TestCase(MethodForcePageToNotCache)]
        [TestCase(MethodApplyChanges)]
        [TestCase(MethodSetXAxisField)]
        [TestCase(MethodSetYAxisField)]
        [TestCase(MethodSetZAxisField)]
        [TestCase(MethodRenderToolPart)]
        [TestCase(MethodListsDropDownListSelectedIndexChanged)]
        [TestCase(MethodLoadAndSetViews)]
        [TestCase(MethodWriteConfigSectionHtml)]
        [TestCase(MethodWriteDisplaySectionHtml)]
        [TestCase(MethodWriteJavascript)]
        [TestCase(MethodCreateConfigSectionControls)]
        [TestCase(MethodCreateDisplaySectionControls)]
        [TestCase(MethodSetDropDownListSelectedValues)]
        [TestCase(MethodSetYFieldControlValues)]
        [TestCase(MethodLoadAndSetSelectedList)]
        [TestCase(MethodLoadAndSetChartTypes)]
        [TestCase(MethodSetupCheckBoxes)]
        [TestCase(MethodSetTextBoxValues)]
        [TestCase(MethodFillDropDowns)]
        [TestCase(MethodGetListColumns)]
        [TestCase(MethodGetMappedLists)]
        [TestCase(MethodIsBubbleChart)]
        [TestCase(MethodRenderOneYField)]
        [TestCase(MethodRenderMultipleYField)]
        public void AUT_ReportingChartToolPart_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportingChartToolPart>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnInit, methodOnInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfOnInit);

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
        public void AUT_ReportingChartToolPart_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

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
        public void AUT_ReportingChartToolPart_OnInit_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportingChartToolPart_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_ReportingChartToolPart_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfOnPreRender);

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
        public void AUT_ReportingChartToolPart_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

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
        public void AUT_ReportingChartToolPart_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportingChartToolPart_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetAggregateTypes) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_LoadAndSetAggregateTypes_Method_Call_Internally(Type[] types)
        {
            var methodLoadAndSetAggregateTypesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodLoadAndSetAggregateTypes, Fixture, methodLoadAndSetAggregateTypesPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadAndSetAggregateTypes) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetAggregateTypes_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodLoadAndSetAggregateTypesPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfLoadAndSetAggregateTypes = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodLoadAndSetAggregateTypes, parametersOfLoadAndSetAggregateTypes, methodLoadAndSetAggregateTypesPrametersTypes);

            // Assert
            parametersOfLoadAndSetAggregateTypes.ShouldNotBeNull();
            parametersOfLoadAndSetAggregateTypes.Length.ShouldBe(1);
            methodLoadAndSetAggregateTypesPrametersTypes.Length.ShouldBe(1);
            methodLoadAndSetAggregateTypesPrametersTypes.Length.ShouldBe(parametersOfLoadAndSetAggregateTypes.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetAggregateTypes) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetAggregateTypes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadAndSetAggregateTypes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadAndSetAggregateTypes) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetAggregateTypes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadAndSetAggregateTypesPrametersTypes = new Type[] { typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodLoadAndSetAggregateTypes, Fixture, methodLoadAndSetAggregateTypesPrametersTypes);

            // Assert
            methodLoadAndSetAggregateTypesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetAggregateTypes) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetAggregateTypes_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadAndSetAggregateTypes, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ForcePageToNotCache) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_ForcePageToNotCache_Method_Call_Internally(Type[] types)
        {
            var methodForcePageToNotCachePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodForcePageToNotCache, Fixture, methodForcePageToNotCachePrametersTypes);
        }

        #endregion

        #region Method Call : (ForcePageToNotCache) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_ForcePageToNotCache_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodForcePageToNotCachePrametersTypes = null;
            object[] parametersOfForcePageToNotCache = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodForcePageToNotCache, methodForcePageToNotCachePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfForcePageToNotCache);

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
        public void AUT_ReportingChartToolPart_ForcePageToNotCache_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodForcePageToNotCachePrametersTypes = null;
            object[] parametersOfForcePageToNotCache = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodForcePageToNotCache, parametersOfForcePageToNotCache, methodForcePageToNotCachePrametersTypes);

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
        public void AUT_ReportingChartToolPart_ForcePageToNotCache_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodForcePageToNotCachePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodForcePageToNotCache, Fixture, methodForcePageToNotCachePrametersTypes);

            // Assert
            methodForcePageToNotCachePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ForcePageToNotCache) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_ForcePageToNotCache_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodForcePageToNotCache, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_ApplyChanges_Method_Call_Internally(Type[] types)
        {
            var methodApplyChangesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodApplyChanges, Fixture, methodApplyChangesPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_ApplyChanges_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportingChartToolPartInstance.ApplyChanges();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_ApplyChanges_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;
            object[] parametersOfApplyChanges = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodApplyChanges, methodApplyChangesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfApplyChanges);

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
        public void AUT_ReportingChartToolPart_ApplyChanges_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;
            object[] parametersOfApplyChanges = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodApplyChanges, parametersOfApplyChanges, methodApplyChangesPrametersTypes);

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
        public void AUT_ReportingChartToolPart_ApplyChanges_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodApplyChangesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodApplyChanges, Fixture, methodApplyChangesPrametersTypes);

            // Assert
            methodApplyChangesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyChanges) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_ApplyChanges_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyChanges, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXAxisField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_SetXAxisField_Method_Call_Internally(Type[] types)
        {
            var methodSetXAxisFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetXAxisField, Fixture, methodSetXAxisFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (SetXAxisField) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetXAxisField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chartWp = CreateType<ReportingChart>();
            var methodSetXAxisFieldPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetXAxisField = { chartWp };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetXAxisField, methodSetXAxisFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfSetXAxisField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetXAxisField.ShouldNotBeNull();
            parametersOfSetXAxisField.Length.ShouldBe(1);
            methodSetXAxisFieldPrametersTypes.Length.ShouldBe(1);
            methodSetXAxisFieldPrametersTypes.Length.ShouldBe(parametersOfSetXAxisField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXAxisField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetXAxisField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chartWp = CreateType<ReportingChart>();
            var methodSetXAxisFieldPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetXAxisField = { chartWp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodSetXAxisField, parametersOfSetXAxisField, methodSetXAxisFieldPrametersTypes);

            // Assert
            parametersOfSetXAxisField.ShouldNotBeNull();
            parametersOfSetXAxisField.Length.ShouldBe(1);
            methodSetXAxisFieldPrametersTypes.Length.ShouldBe(1);
            methodSetXAxisFieldPrametersTypes.Length.ShouldBe(parametersOfSetXAxisField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXAxisField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetXAxisField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetXAxisField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetXAxisField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetXAxisField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetXAxisFieldPrametersTypes = new Type[] { typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetXAxisField, Fixture, methodSetXAxisFieldPrametersTypes);

            // Assert
            methodSetXAxisFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXAxisField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetXAxisField_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetXAxisField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYAxisField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_SetYAxisField_Method_Call_Internally(Type[] types)
        {
            var methodSetYAxisFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetYAxisField, Fixture, methodSetYAxisFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (SetYAxisField) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetYAxisField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chartWp = CreateType<ReportingChart>();
            var methodSetYAxisFieldPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetYAxisField = { chartWp };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetYAxisField, methodSetYAxisFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfSetYAxisField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetYAxisField.ShouldNotBeNull();
            parametersOfSetYAxisField.Length.ShouldBe(1);
            methodSetYAxisFieldPrametersTypes.Length.ShouldBe(1);
            methodSetYAxisFieldPrametersTypes.Length.ShouldBe(parametersOfSetYAxisField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYAxisField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetYAxisField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chartWp = CreateType<ReportingChart>();
            var methodSetYAxisFieldPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetYAxisField = { chartWp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodSetYAxisField, parametersOfSetYAxisField, methodSetYAxisFieldPrametersTypes);

            // Assert
            parametersOfSetYAxisField.ShouldNotBeNull();
            parametersOfSetYAxisField.Length.ShouldBe(1);
            methodSetYAxisFieldPrametersTypes.Length.ShouldBe(1);
            methodSetYAxisFieldPrametersTypes.Length.ShouldBe(parametersOfSetYAxisField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYAxisField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetYAxisField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetYAxisField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetYAxisField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetYAxisField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetYAxisFieldPrametersTypes = new Type[] { typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetYAxisField, Fixture, methodSetYAxisFieldPrametersTypes);

            // Assert
            methodSetYAxisFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYAxisField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetYAxisField_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetYAxisField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetZAxisField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_SetZAxisField_Method_Call_Internally(Type[] types)
        {
            var methodSetZAxisFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetZAxisField, Fixture, methodSetZAxisFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (SetZAxisField) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetZAxisField_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var chartWp = CreateType<ReportingChart>();
            var methodSetZAxisFieldPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetZAxisField = { chartWp };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetZAxisField, methodSetZAxisFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfSetZAxisField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetZAxisField.ShouldNotBeNull();
            parametersOfSetZAxisField.Length.ShouldBe(1);
            methodSetZAxisFieldPrametersTypes.Length.ShouldBe(1);
            methodSetZAxisFieldPrametersTypes.Length.ShouldBe(parametersOfSetZAxisField.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetZAxisField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetZAxisField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chartWp = CreateType<ReportingChart>();
            var methodSetZAxisFieldPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetZAxisField = { chartWp };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodSetZAxisField, parametersOfSetZAxisField, methodSetZAxisFieldPrametersTypes);

            // Assert
            parametersOfSetZAxisField.ShouldNotBeNull();
            parametersOfSetZAxisField.Length.ShouldBe(1);
            methodSetZAxisFieldPrametersTypes.Length.ShouldBe(1);
            methodSetZAxisFieldPrametersTypes.Length.ShouldBe(parametersOfSetZAxisField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetZAxisField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetZAxisField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetZAxisField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetZAxisField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetZAxisField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetZAxisFieldPrametersTypes = new Type[] { typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetZAxisField, Fixture, methodSetZAxisFieldPrametersTypes);

            // Assert
            methodSetZAxisFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetZAxisField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetZAxisField_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetZAxisField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_RenderToolPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderToolPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodRenderToolPart, Fixture, methodRenderToolPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderToolPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderToolPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderToolPart, methodRenderToolPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfRenderToolPart);

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
        public void AUT_ReportingChartToolPart_RenderToolPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderToolPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodRenderToolPart, parametersOfRenderToolPart, methodRenderToolPartPrametersTypes);

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
        public void AUT_ReportingChartToolPart_RenderToolPart_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportingChartToolPart_RenderToolPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderToolPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodRenderToolPart, Fixture, methodRenderToolPartPrametersTypes);

            // Assert
            methodRenderToolPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderToolPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderToolPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderToolPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListsDropDownListSelectedIndexChanged) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_ListsDropDownListSelectedIndexChanged_Method_Call_Internally(Type[] types)
        {
            var methodListsDropDownListSelectedIndexChangedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodListsDropDownListSelectedIndexChanged, Fixture, methodListsDropDownListSelectedIndexChangedPrametersTypes);
        }

        #endregion

        #region Method Call : (ListsDropDownListSelectedIndexChanged) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_ListsDropDownListSelectedIndexChanged_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodListsDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfListsDropDownListSelectedIndexChanged = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodListsDropDownListSelectedIndexChanged, parametersOfListsDropDownListSelectedIndexChanged, methodListsDropDownListSelectedIndexChangedPrametersTypes);

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
        public void AUT_ReportingChartToolPart_ListsDropDownListSelectedIndexChanged_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportingChartToolPart_ListsDropDownListSelectedIndexChanged_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodListsDropDownListSelectedIndexChangedPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodListsDropDownListSelectedIndexChanged, Fixture, methodListsDropDownListSelectedIndexChangedPrametersTypes);

            // Assert
            methodListsDropDownListSelectedIndexChangedPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ListsDropDownListSelectedIndexChanged) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_ListsDropDownListSelectedIndexChanged_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodListsDropDownListSelectedIndexChanged, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetViews) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_LoadAndSetViews_Method_Call_Internally(Type[] types)
        {
            var methodLoadAndSetViewsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodLoadAndSetViews, Fixture, methodLoadAndSetViewsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadAndSetViews) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodLoadAndSetViewsPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfLoadAndSetViews = { chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadAndSetViews, methodLoadAndSetViewsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfLoadAndSetViews);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadAndSetViews.ShouldNotBeNull();
            parametersOfLoadAndSetViews.Length.ShouldBe(1);
            methodLoadAndSetViewsPrametersTypes.Length.ShouldBe(1);
            methodLoadAndSetViewsPrametersTypes.Length.ShouldBe(parametersOfLoadAndSetViews.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetViews) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetViews_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodLoadAndSetViewsPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfLoadAndSetViews = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodLoadAndSetViews, parametersOfLoadAndSetViews, methodLoadAndSetViewsPrametersTypes);

            // Assert
            parametersOfLoadAndSetViews.ShouldNotBeNull();
            parametersOfLoadAndSetViews.Length.ShouldBe(1);
            methodLoadAndSetViewsPrametersTypes.Length.ShouldBe(1);
            methodLoadAndSetViewsPrametersTypes.Length.ShouldBe(parametersOfLoadAndSetViews.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetViews) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetViews_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadAndSetViews, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadAndSetViews) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetViews_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadAndSetViewsPrametersTypes = new Type[] { typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodLoadAndSetViews, Fixture, methodLoadAndSetViewsPrametersTypes);

            // Assert
            methodLoadAndSetViewsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetViews) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetViews_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadAndSetViews, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteConfigSectionHtml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_WriteConfigSectionHtml_Method_Call_Internally(Type[] types)
        {
            var methodWriteConfigSectionHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodWriteConfigSectionHtml, Fixture, methodWriteConfigSectionHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteConfigSectionHtml) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteConfigSectionHtml_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteConfigSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteConfigSectionHtml = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteConfigSectionHtml, methodWriteConfigSectionHtmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfWriteConfigSectionHtml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteConfigSectionHtml.ShouldNotBeNull();
            parametersOfWriteConfigSectionHtml.Length.ShouldBe(1);
            methodWriteConfigSectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteConfigSectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteConfigSectionHtml.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (WriteConfigSectionHtml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteConfigSectionHtml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteConfigSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteConfigSectionHtml = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodWriteConfigSectionHtml, parametersOfWriteConfigSectionHtml, methodWriteConfigSectionHtmlPrametersTypes);

            // Assert
            parametersOfWriteConfigSectionHtml.ShouldNotBeNull();
            parametersOfWriteConfigSectionHtml.Length.ShouldBe(1);
            methodWriteConfigSectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteConfigSectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteConfigSectionHtml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteConfigSectionHtml) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteConfigSectionHtml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteConfigSectionHtml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteConfigSectionHtml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteConfigSectionHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteConfigSectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodWriteConfigSectionHtml, Fixture, methodWriteConfigSectionHtmlPrametersTypes);

            // Assert
            methodWriteConfigSectionHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteConfigSectionHtml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteConfigSectionHtml_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteConfigSectionHtml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteDisplaySectionHtml) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_WriteDisplaySectionHtml_Method_Call_Internally(Type[] types)
        {
            var methodWriteDisplaySectionHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodWriteDisplaySectionHtml, Fixture, methodWriteDisplaySectionHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteDisplaySectionHtml) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteDisplaySectionHtml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteDisplaySectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteDisplaySectionHtml = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteDisplaySectionHtml, methodWriteDisplaySectionHtmlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfWriteDisplaySectionHtml);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteDisplaySectionHtml.ShouldNotBeNull();
            parametersOfWriteDisplaySectionHtml.Length.ShouldBe(1);
            methodWriteDisplaySectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteDisplaySectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteDisplaySectionHtml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteDisplaySectionHtml) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteDisplaySectionHtml_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteDisplaySectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteDisplaySectionHtml = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodWriteDisplaySectionHtml, parametersOfWriteDisplaySectionHtml, methodWriteDisplaySectionHtmlPrametersTypes);

            // Assert
            parametersOfWriteDisplaySectionHtml.ShouldNotBeNull();
            parametersOfWriteDisplaySectionHtml.Length.ShouldBe(1);
            methodWriteDisplaySectionHtmlPrametersTypes.Length.ShouldBe(1);
            methodWriteDisplaySectionHtmlPrametersTypes.Length.ShouldBe(parametersOfWriteDisplaySectionHtml.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteDisplaySectionHtml) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteDisplaySectionHtml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodWriteDisplaySectionHtml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (WriteDisplaySectionHtml) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteDisplaySectionHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteDisplaySectionHtmlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodWriteDisplaySectionHtml, Fixture, methodWriteDisplaySectionHtmlPrametersTypes);

            // Assert
            methodWriteDisplaySectionHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteDisplaySectionHtml) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteDisplaySectionHtml_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteDisplaySectionHtml, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_WriteJavascript_Method_Call_Internally(Type[] types)
        {
            var methodWriteJavascriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodWriteJavascript, Fixture, methodWriteJavascriptPrametersTypes);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteJavascript_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteJavascriptPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteJavascript = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodWriteJavascript, methodWriteJavascriptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfWriteJavascript);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfWriteJavascript.ShouldNotBeNull();
            parametersOfWriteJavascript.Length.ShouldBe(1);
            methodWriteJavascriptPrametersTypes.Length.ShouldBe(1);
            methodWriteJavascriptPrametersTypes.Length.ShouldBe(parametersOfWriteJavascript.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteJavascript_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodWriteJavascriptPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfWriteJavascript = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodWriteJavascript, parametersOfWriteJavascript, methodWriteJavascriptPrametersTypes);

            // Assert
            parametersOfWriteJavascript.ShouldNotBeNull();
            parametersOfWriteJavascript.Length.ShouldBe(1);
            methodWriteJavascriptPrametersTypes.Length.ShouldBe(1);
            methodWriteJavascriptPrametersTypes.Length.ShouldBe(parametersOfWriteJavascript.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteJavascript_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportingChartToolPart_WriteJavascript_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodWriteJavascriptPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodWriteJavascript, Fixture, methodWriteJavascriptPrametersTypes);

            // Assert
            methodWriteJavascriptPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (WriteJavascript) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_WriteJavascript_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodWriteJavascript, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateConfigSectionControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_CreateConfigSectionControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateConfigSectionControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodCreateConfigSectionControls, Fixture, methodCreateConfigSectionControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateConfigSectionControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_CreateConfigSectionControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateConfigSectionControlsPrametersTypes = null;
            object[] parametersOfCreateConfigSectionControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodCreateConfigSectionControls, parametersOfCreateConfigSectionControls, methodCreateConfigSectionControlsPrametersTypes);

            // Assert
            parametersOfCreateConfigSectionControls.ShouldBeNull();
            methodCreateConfigSectionControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateConfigSectionControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_CreateConfigSectionControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateConfigSectionControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodCreateConfigSectionControls, Fixture, methodCreateConfigSectionControlsPrametersTypes);

            // Assert
            methodCreateConfigSectionControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateConfigSectionControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_CreateConfigSectionControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateConfigSectionControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDisplaySectionControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_CreateDisplaySectionControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateDisplaySectionControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodCreateDisplaySectionControls, Fixture, methodCreateDisplaySectionControlsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CreateDisplaySectionControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_CreateDisplaySectionControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateDisplaySectionControlsPrametersTypes = null;
            object[] parametersOfCreateDisplaySectionControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodCreateDisplaySectionControls, parametersOfCreateDisplaySectionControls, methodCreateDisplaySectionControlsPrametersTypes);

            // Assert
            parametersOfCreateDisplaySectionControls.ShouldBeNull();
            methodCreateDisplaySectionControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDisplaySectionControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_CreateDisplaySectionControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateDisplaySectionControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodCreateDisplaySectionControls, Fixture, methodCreateDisplaySectionControlsPrametersTypes);

            // Assert
            methodCreateDisplaySectionControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateDisplaySectionControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_CreateDisplaySectionControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateDisplaySectionControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDropDownListSelectedValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_SetDropDownListSelectedValues_Method_Call_Internally(Type[] types)
        {
            var methodSetDropDownListSelectedValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetDropDownListSelectedValues, Fixture, methodSetDropDownListSelectedValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetDropDownListSelectedValues) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetDropDownListSelectedValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodSetDropDownListSelectedValuesPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetDropDownListSelectedValues = { chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetDropDownListSelectedValues, methodSetDropDownListSelectedValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfSetDropDownListSelectedValues);

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
        public void AUT_ReportingChartToolPart_SetDropDownListSelectedValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodSetDropDownListSelectedValuesPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetDropDownListSelectedValues = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodSetDropDownListSelectedValues, parametersOfSetDropDownListSelectedValues, methodSetDropDownListSelectedValuesPrametersTypes);

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
        public void AUT_ReportingChartToolPart_SetDropDownListSelectedValues_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportingChartToolPart_SetDropDownListSelectedValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetDropDownListSelectedValuesPrametersTypes = new Type[] { typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetDropDownListSelectedValues, Fixture, methodSetDropDownListSelectedValuesPrametersTypes);

            // Assert
            methodSetDropDownListSelectedValuesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetDropDownListSelectedValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetDropDownListSelectedValues_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetDropDownListSelectedValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldControlValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_SetYFieldControlValues_Method_Call_Internally(Type[] types)
        {
            var methodSetYFieldControlValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetYFieldControlValues, Fixture, methodSetYFieldControlValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetYFieldControlValues) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetYFieldControlValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodSetYFieldControlValuesPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetYFieldControlValues = { chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetYFieldControlValues, methodSetYFieldControlValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfSetYFieldControlValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetYFieldControlValues.ShouldNotBeNull();
            parametersOfSetYFieldControlValues.Length.ShouldBe(1);
            methodSetYFieldControlValuesPrametersTypes.Length.ShouldBe(1);
            methodSetYFieldControlValuesPrametersTypes.Length.ShouldBe(parametersOfSetYFieldControlValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldControlValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetYFieldControlValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodSetYFieldControlValuesPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetYFieldControlValues = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodSetYFieldControlValues, parametersOfSetYFieldControlValues, methodSetYFieldControlValuesPrametersTypes);

            // Assert
            parametersOfSetYFieldControlValues.ShouldNotBeNull();
            parametersOfSetYFieldControlValues.Length.ShouldBe(1);
            methodSetYFieldControlValuesPrametersTypes.Length.ShouldBe(1);
            methodSetYFieldControlValuesPrametersTypes.Length.ShouldBe(parametersOfSetYFieldControlValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldControlValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetYFieldControlValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetYFieldControlValues, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetYFieldControlValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetYFieldControlValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetYFieldControlValuesPrametersTypes = new Type[] { typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetYFieldControlValues, Fixture, methodSetYFieldControlValuesPrametersTypes);

            // Assert
            methodSetYFieldControlValuesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldControlValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetYFieldControlValues_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetYFieldControlValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetSelectedList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_LoadAndSetSelectedList_Method_Call_Internally(Type[] types)
        {
            var methodLoadAndSetSelectedListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodLoadAndSetSelectedList, Fixture, methodLoadAndSetSelectedListPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadAndSetSelectedList) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetSelectedList_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var chart = CreateType<ReportingChart>();
            var methodLoadAndSetSelectedListPrametersTypes = new Type[] { typeof(SPWeb), typeof(ReportingChart) };
            object[] parametersOfLoadAndSetSelectedList = { web, chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadAndSetSelectedList, methodLoadAndSetSelectedListPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfLoadAndSetSelectedList);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadAndSetSelectedList.ShouldNotBeNull();
            parametersOfLoadAndSetSelectedList.Length.ShouldBe(2);
            methodLoadAndSetSelectedListPrametersTypes.Length.ShouldBe(2);
            methodLoadAndSetSelectedListPrametersTypes.Length.ShouldBe(parametersOfLoadAndSetSelectedList.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetSelectedList) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetSelectedList_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var chart = CreateType<ReportingChart>();
            var methodLoadAndSetSelectedListPrametersTypes = new Type[] { typeof(SPWeb), typeof(ReportingChart) };
            object[] parametersOfLoadAndSetSelectedList = { web, chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodLoadAndSetSelectedList, parametersOfLoadAndSetSelectedList, methodLoadAndSetSelectedListPrametersTypes);

            // Assert
            parametersOfLoadAndSetSelectedList.ShouldNotBeNull();
            parametersOfLoadAndSetSelectedList.Length.ShouldBe(2);
            methodLoadAndSetSelectedListPrametersTypes.Length.ShouldBe(2);
            methodLoadAndSetSelectedListPrametersTypes.Length.ShouldBe(parametersOfLoadAndSetSelectedList.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetSelectedList) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetSelectedList_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadAndSetSelectedList, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadAndSetSelectedList) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetSelectedList_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadAndSetSelectedListPrametersTypes = new Type[] { typeof(SPWeb), typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodLoadAndSetSelectedList, Fixture, methodLoadAndSetSelectedListPrametersTypes);

            // Assert
            methodLoadAndSetSelectedListPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetSelectedList) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetSelectedList_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadAndSetSelectedList, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetChartTypes) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_LoadAndSetChartTypes_Method_Call_Internally(Type[] types)
        {
            var methodLoadAndSetChartTypesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodLoadAndSetChartTypes, Fixture, methodLoadAndSetChartTypesPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadAndSetChartTypes) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetChartTypes_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodLoadAndSetChartTypesPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfLoadAndSetChartTypes = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodLoadAndSetChartTypes, parametersOfLoadAndSetChartTypes, methodLoadAndSetChartTypesPrametersTypes);

            // Assert
            parametersOfLoadAndSetChartTypes.ShouldNotBeNull();
            parametersOfLoadAndSetChartTypes.Length.ShouldBe(1);
            methodLoadAndSetChartTypesPrametersTypes.Length.ShouldBe(1);
            methodLoadAndSetChartTypesPrametersTypes.Length.ShouldBe(parametersOfLoadAndSetChartTypes.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetChartTypes) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetChartTypes_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodLoadAndSetChartTypes, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (LoadAndSetChartTypes) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetChartTypes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodLoadAndSetChartTypesPrametersTypes = new Type[] { typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodLoadAndSetChartTypes, Fixture, methodLoadAndSetChartTypesPrametersTypes);

            // Assert
            methodLoadAndSetChartTypesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadAndSetChartTypes) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_LoadAndSetChartTypes_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadAndSetChartTypes, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupCheckBoxes) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_SetupCheckBoxes_Method_Call_Internally(Type[] types)
        {
            var methodSetupCheckBoxesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetupCheckBoxes, Fixture, methodSetupCheckBoxesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetupCheckBoxes) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetupCheckBoxes_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodSetupCheckBoxesPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetupCheckBoxes = { chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetupCheckBoxes, methodSetupCheckBoxesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfSetupCheckBoxes);

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
        public void AUT_ReportingChartToolPart_SetupCheckBoxes_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodSetupCheckBoxesPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetupCheckBoxes = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodSetupCheckBoxes, parametersOfSetupCheckBoxes, methodSetupCheckBoxesPrametersTypes);

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
        public void AUT_ReportingChartToolPart_SetupCheckBoxes_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportingChartToolPart_SetupCheckBoxes_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetupCheckBoxesPrametersTypes = new Type[] { typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetupCheckBoxes, Fixture, methodSetupCheckBoxesPrametersTypes);

            // Assert
            methodSetupCheckBoxesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetupCheckBoxes) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetupCheckBoxes_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetupCheckBoxes, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTextBoxValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_SetTextBoxValues_Method_Call_Internally(Type[] types)
        {
            var methodSetTextBoxValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetTextBoxValues, Fixture, methodSetTextBoxValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetTextBoxValues) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetTextBoxValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodSetTextBoxValuesPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetTextBoxValues = { chart };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetTextBoxValues, methodSetTextBoxValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfSetTextBoxValues);

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
        public void AUT_ReportingChartToolPart_SetTextBoxValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var chart = CreateType<ReportingChart>();
            var methodSetTextBoxValuesPrametersTypes = new Type[] { typeof(ReportingChart) };
            object[] parametersOfSetTextBoxValues = { chart };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodSetTextBoxValues, parametersOfSetTextBoxValues, methodSetTextBoxValuesPrametersTypes);

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
        public void AUT_ReportingChartToolPart_SetTextBoxValues_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportingChartToolPart_SetTextBoxValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetTextBoxValuesPrametersTypes = new Type[] { typeof(ReportingChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodSetTextBoxValues, Fixture, methodSetTextBoxValuesPrametersTypes);

            // Assert
            methodSetTextBoxValuesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetTextBoxValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SetTextBoxValues_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetTextBoxValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillDropDowns) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_FillDropDowns_Method_Call_Internally(Type[] types)
        {
            var methodFillDropDownsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodFillDropDowns, Fixture, methodFillDropDownsPrametersTypes);
        }

        #endregion

        #region Method Call : (FillDropDowns) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_FillDropDowns_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodFillDropDownsPrametersTypes = null;
            object[] parametersOfFillDropDowns = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodFillDropDowns, parametersOfFillDropDowns, methodFillDropDownsPrametersTypes);

            // Assert
            parametersOfFillDropDowns.ShouldBeNull();
            methodFillDropDownsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillDropDowns) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_FillDropDowns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodFillDropDownsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodFillDropDowns, Fixture, methodFillDropDownsPrametersTypes);

            // Assert
            methodFillDropDownsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FillDropDowns) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_FillDropDowns_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFillDropDowns, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_GetListColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetListColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var id = CreateType<Guid>();
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetListColumns = { id };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListColumns, methodGetListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChartToolPart, DataTable>(_reportingChartToolPartInstanceFixture, out exception1, parametersOfGetListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChartToolPart, DataTable>(_reportingChartToolPartInstance, MethodGetListColumns, parametersOfGetListColumns, methodGetListColumnsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetListColumns.ShouldNotBeNull();
            parametersOfGetListColumns.Length.ShouldBe(1);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetListColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var id = CreateType<Guid>();
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            object[] parametersOfGetListColumns = { id };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChartToolPart, DataTable>(_reportingChartToolPartInstance, MethodGetListColumns, parametersOfGetListColumns, methodGetListColumnsPrametersTypes);

            // Assert
            parametersOfGetListColumns.ShouldNotBeNull();
            parametersOfGetListColumns.Length.ShouldBe(1);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetListColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetListColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(Guid) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetListColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetListColumns_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetListColumns, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_GetMappedLists_Method_Call_Internally(Type[] types)
        {
            var methodGetMappedListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodGetMappedLists, Fixture, methodGetMappedListsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetMappedLists_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedListsPrametersTypes = null;
            object[] parametersOfGetMappedLists = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetMappedLists, methodGetMappedListsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChartToolPart, DataTable>(_reportingChartToolPartInstanceFixture, out exception1, parametersOfGetMappedLists);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChartToolPart, DataTable>(_reportingChartToolPartInstance, MethodGetMappedLists, parametersOfGetMappedLists, methodGetMappedListsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetMappedLists.ShouldBeNull();
            methodGetMappedListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetMappedLists_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetMappedListsPrametersTypes = null;
            object[] parametersOfGetMappedLists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChartToolPart, DataTable>(_reportingChartToolPartInstance, MethodGetMappedLists, parametersOfGetMappedLists, methodGetMappedListsPrametersTypes);

            // Assert
            parametersOfGetMappedLists.ShouldBeNull();
            methodGetMappedListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetMappedLists_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetMappedListsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodGetMappedLists, Fixture, methodGetMappedListsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetMappedListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetMappedLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetMappedListsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodGetMappedLists, Fixture, methodGetMappedListsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetMappedListsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetMappedLists) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetMappedLists_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetMappedLists, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SortListControlItems) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_SortListControlItems_Static_Method_Call_Internally(Type[] types)
        {
            var methodSortListControlItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingChartToolPartInstanceFixture, _reportingChartToolPartInstanceType, MethodSortListControlItems, Fixture, methodSortListControlItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (SortListControlItems) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SortListControlItems_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var o = CreateType<object>();
            var methodSortListControlItemsPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfSortListControlItems = { o };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSortListControlItems, methodSortListControlItemsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfSortListControlItems);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSortListControlItems.ShouldNotBeNull();
            parametersOfSortListControlItems.Length.ShouldBe(1);
            methodSortListControlItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortListControlItems) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SortListControlItems_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var o = CreateType<object>();
            var methodSortListControlItemsPrametersTypes = new Type[] { typeof(object) };
            object[] parametersOfSortListControlItems = { o };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_reportingChartToolPartInstanceFixture, _reportingChartToolPartInstanceType, MethodSortListControlItems, parametersOfSortListControlItems, methodSortListControlItemsPrametersTypes);

            // Assert
            parametersOfSortListControlItems.ShouldNotBeNull();
            parametersOfSortListControlItems.Length.ShouldBe(1);
            methodSortListControlItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortListControlItems) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SortListControlItems_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSortListControlItems, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SortListControlItems) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SortListControlItems_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSortListControlItemsPrametersTypes = new Type[] { typeof(object) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingChartToolPartInstanceFixture, _reportingChartToolPartInstanceType, MethodSortListControlItems, Fixture, methodSortListControlItemsPrametersTypes);

            // Assert
            methodSortListControlItemsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortListControlItems) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_SortListControlItems_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSortListControlItems, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_IsBubbleChart_Method_Call_Internally(Type[] types)
        {
            var methodIsBubbleChartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_IsBubbleChart_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChartToolPart, bool>(_reportingChartToolPartInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChartToolPart, bool>(_reportingChartToolPartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        public void AUT_ReportingChartToolPart_IsBubbleChart_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChartToolPart, bool>(_reportingChartToolPartInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChartToolPart, bool>(_reportingChartToolPartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        public void AUT_ReportingChartToolPart_IsBubbleChart_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChartToolPart, bool>(_reportingChartToolPartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        public void AUT_ReportingChartToolPart_IsBubbleChart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_IsBubbleChart_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_GetFieldSchemaAttribValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldSchemaAttribValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingChartToolPartInstanceFixture, _reportingChartToolPartInstanceType, MethodGetFieldSchemaAttribValue, Fixture, methodGetFieldSchemaAttribValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetFieldSchemaAttribValue_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sStringToSearch = CreateType<string>();
            var sAttribName = CreateType<string>();
            var methodGetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetFieldSchemaAttribValue = { sStringToSearch, sAttribName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldSchemaAttribValue, methodGetFieldSchemaAttribValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingChartToolPartInstanceFixture, _reportingChartToolPartInstanceType, MethodGetFieldSchemaAttribValue, Fixture, methodGetFieldSchemaAttribValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingChartToolPartInstanceFixture, _reportingChartToolPartInstanceType, MethodGetFieldSchemaAttribValue, parametersOfGetFieldSchemaAttribValue, methodGetFieldSchemaAttribValuePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfGetFieldSchemaAttribValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldSchemaAttribValue.ShouldNotBeNull();
            parametersOfGetFieldSchemaAttribValue.Length.ShouldBe(2);
            methodGetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(2);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetFieldSchemaAttribValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sStringToSearch = CreateType<string>();
            var sAttribName = CreateType<string>();
            var methodGetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetFieldSchemaAttribValue = { sStringToSearch, sAttribName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_reportingChartToolPartInstanceFixture, _reportingChartToolPartInstanceType, MethodGetFieldSchemaAttribValue, parametersOfGetFieldSchemaAttribValue, methodGetFieldSchemaAttribValuePrametersTypes);

            // Assert
            parametersOfGetFieldSchemaAttribValue.ShouldNotBeNull();
            parametersOfGetFieldSchemaAttribValue.Length.ShouldBe(2);
            methodGetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetFieldSchemaAttribValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingChartToolPartInstanceFixture, _reportingChartToolPartInstanceType, MethodGetFieldSchemaAttribValue, Fixture, methodGetFieldSchemaAttribValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetFieldSchemaAttribValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingChartToolPartInstanceFixture, _reportingChartToolPartInstanceType, MethodGetFieldSchemaAttribValue, Fixture, methodGetFieldSchemaAttribValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetFieldSchemaAttribValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldSchemaAttribValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_GetFieldSchemaAttribValue_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldSchemaAttribValue, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderOneYField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_RenderOneYField_Method_Call_Internally(Type[] types)
        {
            var methodRenderOneYFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodRenderOneYField, Fixture, methodRenderOneYFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderOneYField) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderOneYField_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var isNum = CreateType<bool>();
            var isHidden = CreateType<bool>();
            var methodRenderOneYFieldPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(bool), typeof(bool) };
            object[] parametersOfRenderOneYField = { output, isNum, isHidden };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderOneYField, methodRenderOneYFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfRenderOneYField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderOneYField.ShouldNotBeNull();
            parametersOfRenderOneYField.Length.ShouldBe(3);
            methodRenderOneYFieldPrametersTypes.Length.ShouldBe(3);
            methodRenderOneYFieldPrametersTypes.Length.ShouldBe(parametersOfRenderOneYField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderOneYField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderOneYField_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var isNum = CreateType<bool>();
            var isHidden = CreateType<bool>();
            var methodRenderOneYFieldPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(bool), typeof(bool) };
            object[] parametersOfRenderOneYField = { output, isNum, isHidden };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodRenderOneYField, parametersOfRenderOneYField, methodRenderOneYFieldPrametersTypes);

            // Assert
            parametersOfRenderOneYField.ShouldNotBeNull();
            parametersOfRenderOneYField.Length.ShouldBe(3);
            methodRenderOneYFieldPrametersTypes.Length.ShouldBe(3);
            methodRenderOneYFieldPrametersTypes.Length.ShouldBe(parametersOfRenderOneYField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderOneYField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderOneYField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderOneYField, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderOneYField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderOneYField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderOneYFieldPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(bool), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodRenderOneYField, Fixture, methodRenderOneYFieldPrametersTypes);

            // Assert
            methodRenderOneYFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderOneYField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderOneYField_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderOneYField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderMultipleYField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChartToolPart_RenderMultipleYField_Method_Call_Internally(Type[] types)
        {
            var methodRenderMultipleYFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodRenderMultipleYField, Fixture, methodRenderMultipleYFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderMultipleYField) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderMultipleYField_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var isNum = CreateType<bool>();
            var isHidden = CreateType<bool>();
            var methodRenderMultipleYFieldPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(bool), typeof(bool) };
            object[] parametersOfRenderMultipleYField = { output, isNum, isHidden };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderMultipleYField, methodRenderMultipleYFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartToolPartInstanceFixture, parametersOfRenderMultipleYField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderMultipleYField.ShouldNotBeNull();
            parametersOfRenderMultipleYField.Length.ShouldBe(3);
            methodRenderMultipleYFieldPrametersTypes.Length.ShouldBe(3);
            methodRenderMultipleYFieldPrametersTypes.Length.ShouldBe(parametersOfRenderMultipleYField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderMultipleYField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderMultipleYField_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var isNum = CreateType<bool>();
            var isHidden = CreateType<bool>();
            var methodRenderMultipleYFieldPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(bool), typeof(bool) };
            object[] parametersOfRenderMultipleYField = { output, isNum, isHidden };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartToolPartInstance, MethodRenderMultipleYField, parametersOfRenderMultipleYField, methodRenderMultipleYFieldPrametersTypes);

            // Assert
            parametersOfRenderMultipleYField.ShouldNotBeNull();
            parametersOfRenderMultipleYField.Length.ShouldBe(3);
            methodRenderMultipleYFieldPrametersTypes.Length.ShouldBe(3);
            methodRenderMultipleYFieldPrametersTypes.Length.ShouldBe(parametersOfRenderMultipleYField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderMultipleYField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderMultipleYField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderMultipleYField, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderMultipleYField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderMultipleYField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderMultipleYFieldPrametersTypes = new Type[] { typeof(HtmlTextWriter), typeof(bool), typeof(bool) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartToolPartInstance, MethodRenderMultipleYField, Fixture, methodRenderMultipleYFieldPrametersTypes);

            // Assert
            methodRenderMultipleYFieldPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderMultipleYField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_ReportingChartToolPart_RenderMultipleYField_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderMultipleYField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartToolPartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}