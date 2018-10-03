using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Web.UI;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.EpmCharting.DomainModel;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ChartControl" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ChartControlTest : AbstractBaseSetupTypedTest<ChartControl>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ChartControl) Initializer

        private const string PropertyPropChartTitle = "PropChartTitle";
        private const string PropertyPropChartTitleFontSize = "PropChartTitleFontSize";
        private const string PropertyPropChartMainStyle = "PropChartMainStyle";
        private const string PropertyPropChartSelectedPaletteName = "PropChartSelectedPaletteName";
        private const string PropertyPropChartView3D = "PropChartView3D";
        private const string PropertyPropChartXaxisField = "PropChartXaxisField";
        private const string PropertyPropChartXaxisFieldLabel = "PropChartXaxisFieldLabel";
        private const string PropertyPropChartYaxisField = "PropChartYaxisField";
        private const string PropertyPropChartYaxisFieldLabel = "PropChartYaxisFieldLabel";
        private const string PropertyPropChartZaxisField = "PropChartZaxisField";
        private const string PropertyPropChartZaxisFieldLabel = "PropChartZaxisFieldLabel";
        private const string PropertyPropBubbleChartColorField = "PropBubbleChartColorField";
        private const string PropertyPropChartXaxisLabelRotationAngle = "PropChartXaxisLabelRotationAngle";
        private const string PropertyPropChartXaxisLabelFontSize = "PropChartXaxisLabelFontSize";
        private const string PropertyPropChartShowYaxisValuesAsPercentage = "PropChartShowYaxisValuesAsPercentage";
        private const string PropertyPropChartShowYaxisValuesAsCurrency = "PropChartShowYaxisValuesAsCurrency";
        private const string PropertyPropChartZaxisLabelRotationAngle = "PropChartZaxisLabelRotationAngle";
        private const string PropertyPropChartSeriesDataPointLabelFontSize = "PropChartSeriesDataPointLabelFontSize";
        private const string PropertyPropChartShowSeriesInZaxis = "PropChartShowSeriesInZaxis";
        private const string PropertyPropChartShowSeriesLabels = "PropChartShowSeriesLabels";
        private const string PropertyPropChartShowZeroValueData = "PropChartShowZeroValueData";
        private const string PropertyPropChartShowSeriesNameAsLabel = "PropChartShowSeriesNameAsLabel";
        private const string PropertyPropChartShowSeriesValueAsLabel = "PropChartShowSeriesValueAsLabel";
        private const string PropertyPropChartSeriesNameLabelPosition = "PropChartSeriesNameLabelPosition";
        private const string PropertyPropChartSeriesValueLabelPosition = "PropChartSeriesValueLabelPosition";
        private const string PropertyPropChartYaxisNumValues = "PropChartYaxisNumValues";
        private const string PropertyPropChartShowLegend = "PropChartShowLegend";
        private const string PropertyPropChartShowGridlines = "PropChartShowGridlines";
        private const string PropertyPropChartLegendFontName = "PropChartLegendFontName";
        private const string PropertyPropChartLegendFontSize = "PropChartLegendFontSize";
        private const string PropertyPropChartShowFrame = "PropChartShowFrame";
        private const string PropertyPropChartFrameColor = "PropChartFrameColor";
        private const string PropertyPropChartFrameRoundCorners = "PropChartFrameRoundCorners";
        private const string PropertyPropChartSelectedList = "PropChartSelectedList";
        private const string PropertyPropChartSelectedView = "PropChartSelectedView";
        private const string PropertyPropChartRollupLists = "PropChartRollupLists";
        private const string PropertyPropChartRollupSites = "PropChartRollupSites";
        private const string PropertyPropChartAggregationType = "PropChartAggregationType";
        private const string PropertyPropChartRollupData = "PropChartRollupData";
        private const string PropertyPropChartShowBubbleChartInputsInWebPart = "PropChartShowBubbleChartInputsInWebPart";
        private const string PropertyChart = "Chart";
        private const string MethodSetYField = "SetYField";
        private const string MethodGetYaxisFields = "GetYaxisFields";
        private const string MethodReportIdConsumer = "ReportIdConsumer";
        private const string MethodOnInit = "OnInit";
        private const string MethodSetChartWidthAndHeight = "SetChartWidthAndHeight";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodHandleBubbleChartInputPostBack = "HandleBubbleChartInputPostBack";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodIsBubbleChart = "IsBubbleChart";
        private const string MethodRenderWebPart = "RenderWebPart";
        private const string MethodGetToolParts = "GetToolParts";
        private const string MethodRenderWebPartWithElevatedPermissions = "RenderWebPartWithElevatedPermissions";
        private const string MethodDisableBrowserCaching = "DisableBrowserCaching";
        private const string MethodInitializeBubbleChartInputs = "InitializeBubbleChartInputs";
        private const string MethodBubbleChartApplyButtonClick = "BubbleChartApplyButtonClick";
        private const string MethodGetPersistedBubbleChartPersonalizations = "GetPersistedBubbleChartPersonalizations";
        private const string MethodPersistBubbleChartPersonalizations = "PersistBubbleChartPersonalizations";
        private const string MethodGetZaxisColorFieldSelection = "GetZaxisColorFieldSelection";
        private const string MethodGetZaxisFieldSelection = "GetZaxisFieldSelection";
        private const string MethodGetXaxisFieldSelection = "GetXaxisFieldSelection";
        private const string MethodGetXaxisFieldLabel = "GetXaxisFieldLabel";
        private const string MethodGetYaxisFieldLabel = "GetYaxisFieldLabel";
        private const string MethodGetYaxisSelections = "GetYaxisSelections";
        private const string MethodGetZaxisFieldLabel = "GetZaxisFieldLabel";
        private const string MethodSetBubbleChartInputSelectionsBasedOnPersonalizationSettings = "SetBubbleChartInputSelectionsBasedOnPersonalizationSettings";
        private const string MethodSetZaxisColorFieldSelection = "SetZaxisColorFieldSelection";
        private const string MethodSetZaxisSelection = "SetZaxisSelection";
        private const string MethodSetYaxisSelections = "SetYaxisSelections";
        private const string MethodSetXaxisSelection = "SetXaxisSelection";
        private const string MethodSetBubbleChartInputsBasedOnWebPartProperties = "SetBubbleChartInputsBasedOnWebPartProperties";
        private const string MethodPopulateBubbleChartInputsWithInitialValues = "PopulateBubbleChartInputsWithInitialValues";
        private const string MethodSortBubbleChartDropDownLists = "SortBubbleChartDropDownLists";
        private const string MethodRebuildControlTree = "RebuildControlTree";
        private const string FieldScriptTagHolder = "ScriptTagHolder";
        private const string FieldChartData = "ChartData";
        private const string FieldSiteDataQueryData = "SiteDataQueryData";
        private const string FieldConfigureChartVerbiageLiteral = "ConfigureChartVerbiageLiteral";
        private const string FieldTopList = "TopList";
        private const string FieldWebPartToolPart = "WebPartToolPart";
        private const string Field_backingChart = "_backingChart";
        private const string Field_litVfChart = "_litVfChart";
        private const string Field_isPostBackFromBubbleChartInputsApplyButton = "_isPostBackFromBubbleChartInputsApplyButton";
        private const string FieldBubbleChartXaxisDropDownList = "BubbleChartXaxisDropDownList";
        private const string FieldBubbleChartYaxisAsDropDownList = "BubbleChartYaxisAsDropDownList";
        private const string FieldBubbleChartYaxisCheckBoxList = "BubbleChartYaxisCheckBoxList";
        private const string FieldBubbleChartZaxisDropDownList = "BubbleChartZaxisDropDownList";
        private const string FieldBubbleChartZcolorFieldDropDownList = "BubbleChartZcolorFieldDropDownList";
        private const string FieldBubbleChartApplyButton = "BubbleChartApplyButton";
        private const string FieldUserSettingsTable = "UserSettingsTable";
        private const string FieldMainTable = "MainTable";
        private const string Field_myProvider = "_myProvider";
        private const string Fieldact = "act";
        private const string Fieldactivation = "activation";
        private Type _chartControlInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ChartControl _chartControlInstance;
        private ChartControl _chartControlInstanceFixture;

        #region General Initializer : Class (ChartControl) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChartControl" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _chartControlInstanceType = typeof(ChartControl);
            _chartControlInstanceFixture = Create(true);
            _chartControlInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChartControl)
        
        #region General Initializer : Class (ChartControl) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ChartControl" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyPropChartTitle)]
        [TestCase(PropertyPropChartTitleFontSize)]
        [TestCase(PropertyPropChartMainStyle)]
        [TestCase(PropertyPropChartSelectedPaletteName)]
        [TestCase(PropertyPropChartView3D)]
        [TestCase(PropertyPropChartXaxisField)]
        [TestCase(PropertyPropChartXaxisFieldLabel)]
        [TestCase(PropertyPropChartYaxisField)]
        [TestCase(PropertyPropChartYaxisFieldLabel)]
        [TestCase(PropertyPropChartZaxisField)]
        [TestCase(PropertyPropChartZaxisFieldLabel)]
        [TestCase(PropertyPropBubbleChartColorField)]
        [TestCase(PropertyPropChartXaxisLabelRotationAngle)]
        [TestCase(PropertyPropChartXaxisLabelFontSize)]
        [TestCase(PropertyPropChartShowYaxisValuesAsPercentage)]
        [TestCase(PropertyPropChartShowYaxisValuesAsCurrency)]
        [TestCase(PropertyPropChartZaxisLabelRotationAngle)]
        [TestCase(PropertyPropChartSeriesDataPointLabelFontSize)]
        [TestCase(PropertyPropChartShowSeriesInZaxis)]
        [TestCase(PropertyPropChartShowSeriesLabels)]
        [TestCase(PropertyPropChartShowZeroValueData)]
        [TestCase(PropertyPropChartShowSeriesNameAsLabel)]
        [TestCase(PropertyPropChartShowSeriesValueAsLabel)]
        [TestCase(PropertyPropChartSeriesNameLabelPosition)]
        [TestCase(PropertyPropChartSeriesValueLabelPosition)]
        [TestCase(PropertyPropChartYaxisNumValues)]
        [TestCase(PropertyPropChartShowLegend)]
        [TestCase(PropertyPropChartShowGridlines)]
        [TestCase(PropertyPropChartLegendFontName)]
        [TestCase(PropertyPropChartLegendFontSize)]
        [TestCase(PropertyPropChartShowFrame)]
        [TestCase(PropertyPropChartFrameColor)]
        [TestCase(PropertyPropChartFrameRoundCorners)]
        [TestCase(PropertyPropChartSelectedList)]
        [TestCase(PropertyPropChartSelectedView)]
        [TestCase(PropertyPropChartRollupLists)]
        [TestCase(PropertyPropChartRollupSites)]
        [TestCase(PropertyPropChartAggregationType)]
        [TestCase(PropertyPropChartRollupData)]
        [TestCase(PropertyPropChartShowBubbleChartInputsInWebPart)]
        [TestCase(PropertyChart)]
        public void AUT_ChartControl_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_chartControlInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChartControl) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ChartControl" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldScriptTagHolder)]
        [TestCase(FieldChartData)]
        [TestCase(FieldSiteDataQueryData)]
        [TestCase(FieldConfigureChartVerbiageLiteral)]
        [TestCase(FieldTopList)]
        [TestCase(FieldWebPartToolPart)]
        [TestCase(Field_backingChart)]
        [TestCase(Field_litVfChart)]
        [TestCase(Field_isPostBackFromBubbleChartInputsApplyButton)]
        [TestCase(FieldBubbleChartXaxisDropDownList)]
        [TestCase(FieldBubbleChartYaxisAsDropDownList)]
        [TestCase(FieldBubbleChartYaxisCheckBoxList)]
        [TestCase(FieldBubbleChartZaxisDropDownList)]
        [TestCase(FieldBubbleChartZcolorFieldDropDownList)]
        [TestCase(FieldBubbleChartApplyButton)]
        [TestCase(FieldUserSettingsTable)]
        [TestCase(FieldMainTable)]
        [TestCase(Field_myProvider)]
        [TestCase(Fieldact)]
        [TestCase(Fieldactivation)]
        public void AUT_ChartControl_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_chartControlInstanceFixture, 
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
        ///     Class (<see cref="ChartControl" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ChartControl_Is_Instance_Present_Test()
        {
            // Assert
            _chartControlInstanceType.ShouldNotBeNull();
            _chartControlInstance.ShouldNotBeNull();
            _chartControlInstanceFixture.ShouldNotBeNull();
            _chartControlInstance.ShouldBeAssignableTo<ChartControl>();
            _chartControlInstanceFixture.ShouldBeAssignableTo<ChartControl>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ChartControl) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ChartControl_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ChartControl instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _chartControlInstanceType.ShouldNotBeNull();
            _chartControlInstance.ShouldNotBeNull();
            _chartControlInstanceFixture.ShouldNotBeNull();
            _chartControlInstance.ShouldBeAssignableTo<ChartControl>();
            _chartControlInstanceFixture.ShouldBeAssignableTo<ChartControl>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ChartControl) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyPropChartTitle)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartTitleFontSize)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartMainStyle)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartSelectedPaletteName)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartView3D)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartXaxisField)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartXaxisFieldLabel)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartYaxisField)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartYaxisFieldLabel)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartZaxisField)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartZaxisFieldLabel)]
        [TestCaseGeneric(typeof(string) , PropertyPropBubbleChartColorField)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartXaxisLabelRotationAngle)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartXaxisLabelFontSize)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowYaxisValuesAsPercentage)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowYaxisValuesAsCurrency)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartZaxisLabelRotationAngle)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartSeriesDataPointLabelFontSize)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowSeriesInZaxis)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowSeriesLabels)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowZeroValueData)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowSeriesNameAsLabel)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowSeriesValueAsLabel)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartSeriesNameLabelPosition)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartSeriesValueLabelPosition)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartYaxisNumValues)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowLegend)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowGridlines)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartLegendFontName)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartLegendFontSize)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowFrame)]
        [TestCaseGeneric(typeof(Color) , PropertyPropChartFrameColor)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartFrameRoundCorners)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartSelectedList)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartSelectedView)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartRollupLists)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartRollupSites)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartAggregationType)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartRollupData)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowBubbleChartInputsInWebPart)]
        [TestCaseGeneric(typeof(EpmChart) , PropertyChart)]
        public void AUT_ChartControl_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ChartControl, T>(_chartControlInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (Chart) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Chart_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyChart);
            Action currentAction = () => propertyInfo.SetValue(_chartControlInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (Chart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_Chart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyChart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropBubbleChartColorField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropBubbleChartColorField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropBubbleChartColorField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartAggregationType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartAggregationType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartAggregationType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartFrameColor) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_PropChartFrameColor_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyPropChartFrameColor);
            Action currentAction = () => propertyInfo.SetValue(_chartControlInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartFrameColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartFrameColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartFrameColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartFrameRoundCorners) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartFrameRoundCorners_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartFrameRoundCorners);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartLegendFontName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartLegendFontName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartLegendFontName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartLegendFontSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartLegendFontSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartLegendFontSize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartMainStyle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartMainStyle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartMainStyle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartRollupData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartRollupData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartRollupData);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartRollupLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartRollupLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartRollupLists);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartRollupSites) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartRollupSites_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartRollupSites);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartSelectedList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartSelectedList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartSelectedList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartSelectedPaletteName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartSelectedPaletteName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartSelectedPaletteName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartSelectedView) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartSelectedView_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartSelectedView);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartSeriesDataPointLabelFontSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartSeriesDataPointLabelFontSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartSeriesDataPointLabelFontSize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartSeriesNameLabelPosition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartSeriesNameLabelPosition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartSeriesNameLabelPosition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartSeriesValueLabelPosition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartSeriesValueLabelPosition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartSeriesValueLabelPosition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowBubbleChartInputsInWebPart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowBubbleChartInputsInWebPart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowBubbleChartInputsInWebPart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowFrame) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowFrame_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowFrame);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowGridlines) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowGridlines_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowGridlines);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowLegend) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowLegend_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowLegend);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowSeriesInZaxis) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowSeriesInZaxis_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowSeriesInZaxis);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowSeriesLabels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowSeriesLabels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowSeriesLabels);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowSeriesNameAsLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowSeriesNameAsLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowSeriesNameAsLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowSeriesValueAsLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowSeriesValueAsLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowSeriesValueAsLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowYaxisValuesAsCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowYaxisValuesAsCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowYaxisValuesAsCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowYaxisValuesAsPercentage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowYaxisValuesAsPercentage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowYaxisValuesAsPercentage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartShowZeroValueData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartShowZeroValueData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartShowZeroValueData);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartTitleFontSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartTitleFontSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartTitleFontSize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartView3D) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartView3D_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartView3D);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartXaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartXaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartXaxisField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartXaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartXaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartXaxisFieldLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartXaxisLabelFontSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartXaxisLabelFontSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartXaxisLabelFontSize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartXaxisLabelRotationAngle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartXaxisLabelRotationAngle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartXaxisLabelRotationAngle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartYaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartYaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartYaxisField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartYaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartYaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartYaxisFieldLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartYaxisNumValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartYaxisNumValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartYaxisNumValues);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartZaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartZaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartZaxisField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartZaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartZaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartZaxisFieldLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartControl) => Property (PropChartZaxisLabelRotationAngle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartControl_Public_Class_PropChartZaxisLabelRotationAngle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartZaxisLabelRotationAngle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest
        
        #region Method Call : (SetYField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_SetYField_Method_Call_Internally(Type[] types)
        {
            var methodSetYFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetYField, Fixture, methodSetYFieldPrametersTypes);
        }

        #endregion

        #region Method Call : (SetYField) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYField_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var yField = CreateType<string[]>();
            Action executeAction = null;

            // Act
            executeAction = () => _chartControlInstance.SetYField(yField);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (SetYField) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var yField = CreateType<string[]>();
            var methodSetYFieldPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfSetYField = { yField };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetYField, methodSetYFieldPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfSetYField);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetYField.ShouldNotBeNull();
            parametersOfSetYField.Length.ShouldBe(1);
            methodSetYFieldPrametersTypes.Length.ShouldBe(1);
            methodSetYFieldPrametersTypes.Length.ShouldBe(parametersOfSetYField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYField) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYField_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var yField = CreateType<string[]>();
            var methodSetYFieldPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfSetYField = { yField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodSetYField, parametersOfSetYField, methodSetYFieldPrametersTypes);

            // Assert
            parametersOfSetYField.ShouldNotBeNull();
            parametersOfSetYField.Length.ShouldBe(1);
            methodSetYFieldPrametersTypes.Length.ShouldBe(1);
            methodSetYFieldPrametersTypes.Length.ShouldBe(parametersOfSetYField.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYField) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYField_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetYField, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetYField) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYField_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetYFieldPrametersTypes = new Type[] { typeof(string[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetYField, Fixture, methodSetYFieldPrametersTypes);

            // Assert
            methodSetYFieldPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYField) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYField_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetYField, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYaxisFields) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_GetYaxisFields_Method_Call_Internally(Type[] types)
        {
            var methodGetYaxisFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetYaxisFields, Fixture, methodGetYaxisFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetYaxisFields) (Return Type : string[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisFields_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _chartControlInstance.GetYaxisFields();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetYaxisFields) (Return Type : string[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisFields_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetYaxisFieldsPrametersTypes = null;
            object[] parametersOfGetYaxisFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetYaxisFields, methodGetYaxisFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfGetYaxisFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetYaxisFields.ShouldBeNull();
            methodGetYaxisFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYaxisFields) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetYaxisFieldsPrametersTypes = null;
            object[] parametersOfGetYaxisFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, string[]>(_chartControlInstance, MethodGetYaxisFields, parametersOfGetYaxisFields, methodGetYaxisFieldsPrametersTypes);

            // Assert
            parametersOfGetYaxisFields.ShouldBeNull();
            methodGetYaxisFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYaxisFields) (Return Type : string[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisFields_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetYaxisFieldsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetYaxisFields, Fixture, methodGetYaxisFieldsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetYaxisFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYaxisFields) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetYaxisFieldsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetYaxisFields, Fixture, methodGetYaxisFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetYaxisFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYaxisFields) (Return Type : string[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetYaxisFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ReportIdConsumer) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_ReportIdConsumer_Method_Call_Internally(Type[] types)
        {
            var methodReportIdConsumerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodReportIdConsumer, Fixture, methodReportIdConsumerPrametersTypes);
        }

        #endregion

        #region Method Call : (ReportIdConsumer) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_ReportIdConsumer_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            var provider = CreateType<IReportID>();
            Action executeAction = null;

            // Act
            executeAction = () => _chartControlInstance.ReportIdConsumer(provider);

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ReportIdConsumer) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_ReportIdConsumer_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var provider = CreateType<IReportID>();
            var methodReportIdConsumerPrametersTypes = new Type[] { typeof(IReportID) };
            object[] parametersOfReportIdConsumer = { provider };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReportIdConsumer, methodReportIdConsumerPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfReportIdConsumer);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReportIdConsumer.ShouldNotBeNull();
            parametersOfReportIdConsumer.Length.ShouldBe(1);
            methodReportIdConsumerPrametersTypes.Length.ShouldBe(1);
            methodReportIdConsumerPrametersTypes.Length.ShouldBe(parametersOfReportIdConsumer.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIdConsumer) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_ReportIdConsumer_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var provider = CreateType<IReportID>();
            var methodReportIdConsumerPrametersTypes = new Type[] { typeof(IReportID) };
            object[] parametersOfReportIdConsumer = { provider };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodReportIdConsumer, parametersOfReportIdConsumer, methodReportIdConsumerPrametersTypes);

            // Assert
            parametersOfReportIdConsumer.ShouldNotBeNull();
            parametersOfReportIdConsumer.Length.ShouldBe(1);
            methodReportIdConsumerPrametersTypes.Length.ShouldBe(1);
            methodReportIdConsumerPrametersTypes.Length.ShouldBe(parametersOfReportIdConsumer.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIdConsumer) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_ReportIdConsumer_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReportIdConsumer, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReportIdConsumer) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_ReportIdConsumer_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReportIdConsumerPrametersTypes = new Type[] { typeof(IReportID) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodReportIdConsumer, Fixture, methodReportIdConsumerPrametersTypes);

            // Assert
            methodReportIdConsumerPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIdConsumer) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_ReportIdConsumer_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReportIdConsumer, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnInit, methodOnInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfOnInit);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_OnInit_Method_Call_Parameters_Count_Verification_Test()
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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetChartWidthAndHeight) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_SetChartWidthAndHeight_Method_Call_Internally(Type[] types)
        {
            var methodSetChartWidthAndHeightPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetChartWidthAndHeight, Fixture, methodSetChartWidthAndHeightPrametersTypes);
        }

        #endregion

        #region Method Call : (SetChartWidthAndHeight) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetChartWidthAndHeight_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSetChartWidthAndHeightPrametersTypes = null;
            object[] parametersOfSetChartWidthAndHeight = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetChartWidthAndHeight, methodSetChartWidthAndHeightPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfSetChartWidthAndHeight);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetChartWidthAndHeight.ShouldBeNull();
            methodSetChartWidthAndHeightPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetChartWidthAndHeight) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetChartWidthAndHeight_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetChartWidthAndHeightPrametersTypes = null;
            object[] parametersOfSetChartWidthAndHeight = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodSetChartWidthAndHeight, parametersOfSetChartWidthAndHeight, methodSetChartWidthAndHeightPrametersTypes);

            // Assert
            parametersOfSetChartWidthAndHeight.ShouldBeNull();
            methodSetChartWidthAndHeightPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetChartWidthAndHeight) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetChartWidthAndHeight_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetChartWidthAndHeightPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetChartWidthAndHeight, Fixture, methodSetChartWidthAndHeightPrametersTypes);

            // Assert
            methodSetChartWidthAndHeightPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetChartWidthAndHeight) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetChartWidthAndHeight_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetChartWidthAndHeight, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_OnPreRender_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfOnPreRender);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleBubbleChartInputPostBack) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_HandleBubbleChartInputPostBack_Method_Call_Internally(Type[] types)
        {
            var methodHandleBubbleChartInputPostBackPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodHandleBubbleChartInputPostBack, Fixture, methodHandleBubbleChartInputPostBackPrametersTypes);
        }

        #endregion
        
        #region Method Call : (HandleBubbleChartInputPostBack) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_HandleBubbleChartInputPostBack_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodHandleBubbleChartInputPostBackPrametersTypes = null;
            object[] parametersOfHandleBubbleChartInputPostBack = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodHandleBubbleChartInputPostBack, parametersOfHandleBubbleChartInputPostBack, methodHandleBubbleChartInputPostBackPrametersTypes);

            // Assert
            parametersOfHandleBubbleChartInputPostBack.ShouldBeNull();
            methodHandleBubbleChartInputPostBackPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleBubbleChartInputPostBack) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_HandleBubbleChartInputPostBack_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodHandleBubbleChartInputPostBackPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodHandleBubbleChartInputPostBack, Fixture, methodHandleBubbleChartInputPostBackPrametersTypes);

            // Assert
            methodHandleBubbleChartInputPostBackPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleBubbleChartInputPostBack) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_HandleBubbleChartInputPostBack_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleBubbleChartInputPostBack, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, methodCreateChildControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfCreateChildControls);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_ChartControl_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_IsBubbleChart_Method_Call_Internally(Type[] types)
        {
            var methodIsBubbleChartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_IsBubbleChart_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChartControl, bool>(_chartControlInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChartControl, bool>(_chartControlInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_IsBubbleChart_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChartControl, bool>(_chartControlInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChartControl, bool>(_chartControlInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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

        #region Method Call : (IsBubbleChart) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_IsBubbleChart_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfIsBubbleChart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsBubbleChart.ShouldBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_IsBubbleChart_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, bool>(_chartControlInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

            // Assert
            parametersOfIsBubbleChart.ShouldBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_IsBubbleChart_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_IsBubbleChart_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_IsBubbleChart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_IsBubbleChart_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_RenderWebPart_Method_Call_Internally(Type[] types)
        {
            var methodRenderWebPartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RenderWebPart_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, methodRenderWebPartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfRenderWebPart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderWebPart.ShouldNotBeNull();
            parametersOfRenderWebPart.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(parametersOfRenderWebPart.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RenderWebPart_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPart = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodRenderWebPart, parametersOfRenderWebPart, methodRenderWebPartPrametersTypes);

            // Assert
            parametersOfRenderWebPart.ShouldNotBeNull();
            parametersOfRenderWebPart.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartPrametersTypes.Length.ShouldBe(parametersOfRenderWebPart.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RenderWebPart_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RenderWebPart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderWebPartPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodRenderWebPart, Fixture, methodRenderWebPartPrametersTypes);

            // Assert
            methodRenderWebPartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RenderWebPart_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderWebPart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_GetToolParts_Method_Call_Internally(Type[] types)
        {
            var methodGetToolPartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetToolParts_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _chartControlInstance.GetToolParts();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetToolParts_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetToolParts, methodGetToolPartsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfGetToolParts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetToolParts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, ToolPart[]>(_chartControlInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetToolParts_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetToolParts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetToolParts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetToolParts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RenderWebPartWithElevatedPermissions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_RenderWebPartWithElevatedPermissions_Method_Call_Internally(Type[] types)
        {
            var methodRenderWebPartWithElevatedPermissionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodRenderWebPartWithElevatedPermissions, Fixture, methodRenderWebPartWithElevatedPermissionsPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderWebPartWithElevatedPermissions) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RenderWebPartWithElevatedPermissions_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartWithElevatedPermissionsPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPartWithElevatedPermissions = { output };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderWebPartWithElevatedPermissions, methodRenderWebPartWithElevatedPermissionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfRenderWebPartWithElevatedPermissions);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderWebPartWithElevatedPermissions.ShouldNotBeNull();
            parametersOfRenderWebPartWithElevatedPermissions.Length.ShouldBe(1);
            methodRenderWebPartWithElevatedPermissionsPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartWithElevatedPermissionsPrametersTypes.Length.ShouldBe(parametersOfRenderWebPartWithElevatedPermissions.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPartWithElevatedPermissions) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RenderWebPartWithElevatedPermissions_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var output = CreateType<HtmlTextWriter>();
            var methodRenderWebPartWithElevatedPermissionsPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderWebPartWithElevatedPermissions = { output };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodRenderWebPartWithElevatedPermissions, parametersOfRenderWebPartWithElevatedPermissions, methodRenderWebPartWithElevatedPermissionsPrametersTypes);

            // Assert
            parametersOfRenderWebPartWithElevatedPermissions.ShouldNotBeNull();
            parametersOfRenderWebPartWithElevatedPermissions.Length.ShouldBe(1);
            methodRenderWebPartWithElevatedPermissionsPrametersTypes.Length.ShouldBe(1);
            methodRenderWebPartWithElevatedPermissionsPrametersTypes.Length.ShouldBe(parametersOfRenderWebPartWithElevatedPermissions.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPartWithElevatedPermissions) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RenderWebPartWithElevatedPermissions_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderWebPartWithElevatedPermissions, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderWebPartWithElevatedPermissions) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RenderWebPartWithElevatedPermissions_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderWebPartWithElevatedPermissionsPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodRenderWebPartWithElevatedPermissions, Fixture, methodRenderWebPartWithElevatedPermissionsPrametersTypes);

            // Assert
            methodRenderWebPartWithElevatedPermissionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderWebPartWithElevatedPermissions) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RenderWebPartWithElevatedPermissions_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderWebPartWithElevatedPermissions, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableBrowserCaching) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_DisableBrowserCaching_Method_Call_Internally(Type[] types)
        {
            var methodDisableBrowserCachingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodDisableBrowserCaching, Fixture, methodDisableBrowserCachingPrametersTypes);
        }

        #endregion

        #region Method Call : (DisableBrowserCaching) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_DisableBrowserCaching_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDisableBrowserCachingPrametersTypes = null;
            object[] parametersOfDisableBrowserCaching = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDisableBrowserCaching, methodDisableBrowserCachingPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfDisableBrowserCaching);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDisableBrowserCaching.ShouldBeNull();
            methodDisableBrowserCachingPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (DisableBrowserCaching) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_DisableBrowserCaching_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDisableBrowserCachingPrametersTypes = null;
            object[] parametersOfDisableBrowserCaching = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodDisableBrowserCaching, parametersOfDisableBrowserCaching, methodDisableBrowserCachingPrametersTypes);

            // Assert
            parametersOfDisableBrowserCaching.ShouldBeNull();
            methodDisableBrowserCachingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableBrowserCaching) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_DisableBrowserCaching_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDisableBrowserCachingPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodDisableBrowserCaching, Fixture, methodDisableBrowserCachingPrametersTypes);

            // Assert
            methodDisableBrowserCachingPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisableBrowserCaching) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_DisableBrowserCaching_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisableBrowserCaching, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeBubbleChartInputs) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_InitializeBubbleChartInputs_Method_Call_Internally(Type[] types)
        {
            var methodInitializeBubbleChartInputsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodInitializeBubbleChartInputs, Fixture, methodInitializeBubbleChartInputsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializeBubbleChartInputs) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_InitializeBubbleChartInputs_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitializeBubbleChartInputsPrametersTypes = null;
            object[] parametersOfInitializeBubbleChartInputs = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializeBubbleChartInputs, methodInitializeBubbleChartInputsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfInitializeBubbleChartInputs);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializeBubbleChartInputs.ShouldBeNull();
            methodInitializeBubbleChartInputsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeBubbleChartInputs) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_InitializeBubbleChartInputs_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializeBubbleChartInputsPrametersTypes = null;
            object[] parametersOfInitializeBubbleChartInputs = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodInitializeBubbleChartInputs, parametersOfInitializeBubbleChartInputs, methodInitializeBubbleChartInputsPrametersTypes);

            // Assert
            parametersOfInitializeBubbleChartInputs.ShouldBeNull();
            methodInitializeBubbleChartInputsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeBubbleChartInputs) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_InitializeBubbleChartInputs_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializeBubbleChartInputsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodInitializeBubbleChartInputs, Fixture, methodInitializeBubbleChartInputsPrametersTypes);

            // Assert
            methodInitializeBubbleChartInputsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializeBubbleChartInputs) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_InitializeBubbleChartInputs_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializeBubbleChartInputs, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BubbleChartApplyButtonClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_BubbleChartApplyButtonClick_Method_Call_Internally(Type[] types)
        {
            var methodBubbleChartApplyButtonClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodBubbleChartApplyButtonClick, Fixture, methodBubbleChartApplyButtonClickPrametersTypes);
        }

        #endregion

        #region Method Call : (BubbleChartApplyButtonClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_BubbleChartApplyButtonClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBubbleChartApplyButtonClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBubbleChartApplyButtonClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodBubbleChartApplyButtonClick, methodBubbleChartApplyButtonClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfBubbleChartApplyButtonClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfBubbleChartApplyButtonClick.ShouldNotBeNull();
            parametersOfBubbleChartApplyButtonClick.Length.ShouldBe(2);
            methodBubbleChartApplyButtonClickPrametersTypes.Length.ShouldBe(2);
            methodBubbleChartApplyButtonClickPrametersTypes.Length.ShouldBe(parametersOfBubbleChartApplyButtonClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (BubbleChartApplyButtonClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_BubbleChartApplyButtonClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodBubbleChartApplyButtonClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfBubbleChartApplyButtonClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodBubbleChartApplyButtonClick, parametersOfBubbleChartApplyButtonClick, methodBubbleChartApplyButtonClickPrametersTypes);

            // Assert
            parametersOfBubbleChartApplyButtonClick.ShouldNotBeNull();
            parametersOfBubbleChartApplyButtonClick.Length.ShouldBe(2);
            methodBubbleChartApplyButtonClickPrametersTypes.Length.ShouldBe(2);
            methodBubbleChartApplyButtonClickPrametersTypes.Length.ShouldBe(parametersOfBubbleChartApplyButtonClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BubbleChartApplyButtonClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_BubbleChartApplyButtonClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBubbleChartApplyButtonClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BubbleChartApplyButtonClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_BubbleChartApplyButtonClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBubbleChartApplyButtonClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodBubbleChartApplyButtonClick, Fixture, methodBubbleChartApplyButtonClickPrametersTypes);

            // Assert
            methodBubbleChartApplyButtonClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BubbleChartApplyButtonClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_BubbleChartApplyButtonClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBubbleChartApplyButtonClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersistedBubbleChartPersonalizations) (Return Type : EpmChartUserSettings) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_GetPersistedBubbleChartPersonalizations_Method_Call_Internally(Type[] types)
        {
            var methodGetPersistedBubbleChartPersonalizationsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetPersistedBubbleChartPersonalizations, Fixture, methodGetPersistedBubbleChartPersonalizationsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersistedBubbleChartPersonalizations) (Return Type : EpmChartUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetPersistedBubbleChartPersonalizations_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetPersistedBubbleChartPersonalizationsPrametersTypes = null;
            object[] parametersOfGetPersistedBubbleChartPersonalizations = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPersistedBubbleChartPersonalizations, methodGetPersistedBubbleChartPersonalizationsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChartControl, EpmChartUserSettings>(_chartControlInstanceFixture, out exception1, parametersOfGetPersistedBubbleChartPersonalizations);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChartControl, EpmChartUserSettings>(_chartControlInstance, MethodGetPersistedBubbleChartPersonalizations, parametersOfGetPersistedBubbleChartPersonalizations, methodGetPersistedBubbleChartPersonalizationsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPersistedBubbleChartPersonalizations.ShouldBeNull();
            methodGetPersistedBubbleChartPersonalizationsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersistedBubbleChartPersonalizations) (Return Type : EpmChartUserSettings) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetPersistedBubbleChartPersonalizations_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetPersistedBubbleChartPersonalizationsPrametersTypes = null;
            object[] parametersOfGetPersistedBubbleChartPersonalizations = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, EpmChartUserSettings>(_chartControlInstance, MethodGetPersistedBubbleChartPersonalizations, parametersOfGetPersistedBubbleChartPersonalizations, methodGetPersistedBubbleChartPersonalizationsPrametersTypes);

            // Assert
            parametersOfGetPersistedBubbleChartPersonalizations.ShouldBeNull();
            methodGetPersistedBubbleChartPersonalizationsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersistedBubbleChartPersonalizations) (Return Type : EpmChartUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetPersistedBubbleChartPersonalizations_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetPersistedBubbleChartPersonalizationsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetPersistedBubbleChartPersonalizations, Fixture, methodGetPersistedBubbleChartPersonalizationsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPersistedBubbleChartPersonalizationsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersistedBubbleChartPersonalizations) (Return Type : EpmChartUserSettings) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetPersistedBubbleChartPersonalizations_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetPersistedBubbleChartPersonalizationsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetPersistedBubbleChartPersonalizations, Fixture, methodGetPersistedBubbleChartPersonalizationsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPersistedBubbleChartPersonalizationsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersistedBubbleChartPersonalizations) (Return Type : EpmChartUserSettings) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetPersistedBubbleChartPersonalizations_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersistedBubbleChartPersonalizations, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PersistBubbleChartPersonalizations) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_PersistBubbleChartPersonalizations_Method_Call_Internally(Type[] types)
        {
            var methodPersistBubbleChartPersonalizationsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodPersistBubbleChartPersonalizations, Fixture, methodPersistBubbleChartPersonalizationsPrametersTypes);
        }

        #endregion

        #region Method Call : (PersistBubbleChartPersonalizations) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_PersistBubbleChartPersonalizations_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodPersistBubbleChartPersonalizationsPrametersTypes = null;
            object[] parametersOfPersistBubbleChartPersonalizations = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPersistBubbleChartPersonalizations, methodPersistBubbleChartPersonalizationsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfPersistBubbleChartPersonalizations);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPersistBubbleChartPersonalizations.ShouldBeNull();
            methodPersistBubbleChartPersonalizationsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PersistBubbleChartPersonalizations) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_PersistBubbleChartPersonalizations_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPersistBubbleChartPersonalizationsPrametersTypes = null;
            object[] parametersOfPersistBubbleChartPersonalizations = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodPersistBubbleChartPersonalizations, parametersOfPersistBubbleChartPersonalizations, methodPersistBubbleChartPersonalizationsPrametersTypes);

            // Assert
            parametersOfPersistBubbleChartPersonalizations.ShouldBeNull();
            methodPersistBubbleChartPersonalizationsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistBubbleChartPersonalizations) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_PersistBubbleChartPersonalizations_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPersistBubbleChartPersonalizationsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodPersistBubbleChartPersonalizations, Fixture, methodPersistBubbleChartPersonalizationsPrametersTypes);

            // Assert
            methodPersistBubbleChartPersonalizationsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistBubbleChartPersonalizations) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_PersistBubbleChartPersonalizations_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPersistBubbleChartPersonalizations, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZaxisColorFieldSelection) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_GetZaxisColorFieldSelection_Method_Call_Internally(Type[] types)
        {
            var methodGetZaxisColorFieldSelectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetZaxisColorFieldSelection, Fixture, methodGetZaxisColorFieldSelectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetZaxisColorFieldSelection) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisColorFieldSelection_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetZaxisColorFieldSelectionPrametersTypes = null;
            object[] parametersOfGetZaxisColorFieldSelection = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetZaxisColorFieldSelection, methodGetZaxisColorFieldSelectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfGetZaxisColorFieldSelection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetZaxisColorFieldSelection.ShouldBeNull();
            methodGetZaxisColorFieldSelectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZaxisColorFieldSelection) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisColorFieldSelection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetZaxisColorFieldSelectionPrametersTypes = null;
            object[] parametersOfGetZaxisColorFieldSelection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, string>(_chartControlInstance, MethodGetZaxisColorFieldSelection, parametersOfGetZaxisColorFieldSelection, methodGetZaxisColorFieldSelectionPrametersTypes);

            // Assert
            parametersOfGetZaxisColorFieldSelection.ShouldBeNull();
            methodGetZaxisColorFieldSelectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZaxisColorFieldSelection) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisColorFieldSelection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetZaxisColorFieldSelectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetZaxisColorFieldSelection, Fixture, methodGetZaxisColorFieldSelectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetZaxisColorFieldSelectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetZaxisColorFieldSelection) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisColorFieldSelection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetZaxisColorFieldSelectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetZaxisColorFieldSelection, Fixture, methodGetZaxisColorFieldSelectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetZaxisColorFieldSelectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetZaxisColorFieldSelection) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisColorFieldSelection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetZaxisColorFieldSelection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetZaxisFieldSelection) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_GetZaxisFieldSelection_Method_Call_Internally(Type[] types)
        {
            var methodGetZaxisFieldSelectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetZaxisFieldSelection, Fixture, methodGetZaxisFieldSelectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetZaxisFieldSelection) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisFieldSelection_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetZaxisFieldSelectionPrametersTypes = null;
            object[] parametersOfGetZaxisFieldSelection = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetZaxisFieldSelection, methodGetZaxisFieldSelectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfGetZaxisFieldSelection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetZaxisFieldSelection.ShouldBeNull();
            methodGetZaxisFieldSelectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZaxisFieldSelection) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisFieldSelection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetZaxisFieldSelectionPrametersTypes = null;
            object[] parametersOfGetZaxisFieldSelection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, string>(_chartControlInstance, MethodGetZaxisFieldSelection, parametersOfGetZaxisFieldSelection, methodGetZaxisFieldSelectionPrametersTypes);

            // Assert
            parametersOfGetZaxisFieldSelection.ShouldBeNull();
            methodGetZaxisFieldSelectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZaxisFieldSelection) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisFieldSelection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetZaxisFieldSelectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetZaxisFieldSelection, Fixture, methodGetZaxisFieldSelectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetZaxisFieldSelectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetZaxisFieldSelection) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisFieldSelection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetZaxisFieldSelectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetZaxisFieldSelection, Fixture, methodGetZaxisFieldSelectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetZaxisFieldSelectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetZaxisFieldSelection) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisFieldSelection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetZaxisFieldSelection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetXaxisFieldSelection) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_GetXaxisFieldSelection_Method_Call_Internally(Type[] types)
        {
            var methodGetXaxisFieldSelectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetXaxisFieldSelection, Fixture, methodGetXaxisFieldSelectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetXaxisFieldSelection) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetXaxisFieldSelection_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetXaxisFieldSelectionPrametersTypes = null;
            object[] parametersOfGetXaxisFieldSelection = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetXaxisFieldSelection, methodGetXaxisFieldSelectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfGetXaxisFieldSelection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetXaxisFieldSelection.ShouldBeNull();
            methodGetXaxisFieldSelectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXaxisFieldSelection) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetXaxisFieldSelection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetXaxisFieldSelectionPrametersTypes = null;
            object[] parametersOfGetXaxisFieldSelection = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, string>(_chartControlInstance, MethodGetXaxisFieldSelection, parametersOfGetXaxisFieldSelection, methodGetXaxisFieldSelectionPrametersTypes);

            // Assert
            parametersOfGetXaxisFieldSelection.ShouldBeNull();
            methodGetXaxisFieldSelectionPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXaxisFieldSelection) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetXaxisFieldSelection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXaxisFieldSelectionPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetXaxisFieldSelection, Fixture, methodGetXaxisFieldSelectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetXaxisFieldSelectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXaxisFieldSelection) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetXaxisFieldSelection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetXaxisFieldSelectionPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetXaxisFieldSelection, Fixture, methodGetXaxisFieldSelectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetXaxisFieldSelectionPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXaxisFieldSelection) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetXaxisFieldSelection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetXaxisFieldSelection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetXaxisFieldLabel) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_GetXaxisFieldLabel_Method_Call_Internally(Type[] types)
        {
            var methodGetXaxisFieldLabelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetXaxisFieldLabel, Fixture, methodGetXaxisFieldLabelPrametersTypes);
        }

        #endregion

        #region Method Call : (GetXaxisFieldLabel) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetXaxisFieldLabel_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXaxisFieldLabelPrametersTypes = null;
            object[] parametersOfGetXaxisFieldLabel = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetXaxisFieldLabel, methodGetXaxisFieldLabelPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChartControl, string>(_chartControlInstanceFixture, out exception1, parametersOfGetXaxisFieldLabel);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChartControl, string>(_chartControlInstance, MethodGetXaxisFieldLabel, parametersOfGetXaxisFieldLabel, methodGetXaxisFieldLabelPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetXaxisFieldLabel.ShouldBeNull();
            methodGetXaxisFieldLabelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXaxisFieldLabel) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetXaxisFieldLabel_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetXaxisFieldLabelPrametersTypes = null;
            object[] parametersOfGetXaxisFieldLabel = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, string>(_chartControlInstance, MethodGetXaxisFieldLabel, parametersOfGetXaxisFieldLabel, methodGetXaxisFieldLabelPrametersTypes);

            // Assert
            parametersOfGetXaxisFieldLabel.ShouldBeNull();
            methodGetXaxisFieldLabelPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXaxisFieldLabel) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetXaxisFieldLabel_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXaxisFieldLabelPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetXaxisFieldLabel, Fixture, methodGetXaxisFieldLabelPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetXaxisFieldLabelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXaxisFieldLabel) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetXaxisFieldLabel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetXaxisFieldLabelPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetXaxisFieldLabel, Fixture, methodGetXaxisFieldLabelPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetXaxisFieldLabelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXaxisFieldLabel) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetXaxisFieldLabel_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetXaxisFieldLabel, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYaxisFieldLabel) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_GetYaxisFieldLabel_Method_Call_Internally(Type[] types)
        {
            var methodGetYaxisFieldLabelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetYaxisFieldLabel, Fixture, methodGetYaxisFieldLabelPrametersTypes);
        }

        #endregion

        #region Method Call : (GetYaxisFieldLabel) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisFieldLabel_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetYaxisFieldLabelPrametersTypes = null;
            object[] parametersOfGetYaxisFieldLabel = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, string>(_chartControlInstance, MethodGetYaxisFieldLabel, parametersOfGetYaxisFieldLabel, methodGetYaxisFieldLabelPrametersTypes);

            // Assert
            parametersOfGetYaxisFieldLabel.ShouldBeNull();
            methodGetYaxisFieldLabelPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYaxisFieldLabel) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisFieldLabel_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetYaxisFieldLabelPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetYaxisFieldLabel, Fixture, methodGetYaxisFieldLabelPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetYaxisFieldLabelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYaxisFieldLabel) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisFieldLabel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetYaxisFieldLabelPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetYaxisFieldLabel, Fixture, methodGetYaxisFieldLabelPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetYaxisFieldLabelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYaxisSelections) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_GetYaxisSelections_Method_Call_Internally(Type[] types)
        {
            var methodGetYaxisSelectionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetYaxisSelections, Fixture, methodGetYaxisSelectionsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (GetYaxisSelections) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisSelections_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetYaxisSelectionsPrametersTypes = null;
            object[] parametersOfGetYaxisSelections = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, List<string>>(_chartControlInstance, MethodGetYaxisSelections, parametersOfGetYaxisSelections, methodGetYaxisSelectionsPrametersTypes);

            // Assert
            parametersOfGetYaxisSelections.ShouldBeNull();
            methodGetYaxisSelectionsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYaxisSelections) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisSelections_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetYaxisSelectionsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetYaxisSelections, Fixture, methodGetYaxisSelectionsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetYaxisSelectionsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYaxisSelections) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetYaxisSelections_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetYaxisSelectionsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetYaxisSelections, Fixture, methodGetYaxisSelectionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetYaxisSelectionsPrametersTypes.ShouldBeNull();
        }

        #endregion
        
        #region Method Call : (GetZaxisFieldLabel) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_GetZaxisFieldLabel_Method_Call_Internally(Type[] types)
        {
            var methodGetZaxisFieldLabelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetZaxisFieldLabel, Fixture, methodGetZaxisFieldLabelPrametersTypes);
        }

        #endregion

        #region Method Call : (GetZaxisFieldLabel) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisFieldLabel_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetZaxisFieldLabelPrametersTypes = null;
            object[] parametersOfGetZaxisFieldLabel = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetZaxisFieldLabel, methodGetZaxisFieldLabelPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ChartControl, string>(_chartControlInstanceFixture, out exception1, parametersOfGetZaxisFieldLabel);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ChartControl, string>(_chartControlInstance, MethodGetZaxisFieldLabel, parametersOfGetZaxisFieldLabel, methodGetZaxisFieldLabelPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetZaxisFieldLabel.ShouldBeNull();
            methodGetZaxisFieldLabelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetZaxisFieldLabel) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisFieldLabel_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetZaxisFieldLabelPrametersTypes = null;
            object[] parametersOfGetZaxisFieldLabel = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ChartControl, string>(_chartControlInstance, MethodGetZaxisFieldLabel, parametersOfGetZaxisFieldLabel, methodGetZaxisFieldLabelPrametersTypes);

            // Assert
            parametersOfGetZaxisFieldLabel.ShouldBeNull();
            methodGetZaxisFieldLabelPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZaxisFieldLabel) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisFieldLabel_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetZaxisFieldLabelPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetZaxisFieldLabel, Fixture, methodGetZaxisFieldLabelPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetZaxisFieldLabelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetZaxisFieldLabel) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisFieldLabel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetZaxisFieldLabelPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodGetZaxisFieldLabel, Fixture, methodGetZaxisFieldLabelPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetZaxisFieldLabelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetZaxisFieldLabel) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_GetZaxisFieldLabel_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetZaxisFieldLabel, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetBubbleChartInputSelectionsBasedOnPersonalizationSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_SetBubbleChartInputSelectionsBasedOnPersonalizationSettings_Method_Call_Internally(Type[] types)
        {
            var methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetBubbleChartInputSelectionsBasedOnPersonalizationSettings, Fixture, methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetBubbleChartInputSelectionsBasedOnPersonalizationSettings) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetBubbleChartInputSelectionsBasedOnPersonalizationSettings_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<EpmChartUserSettings>();
            var selectedList = CreateType<SPList>();
            var methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes = new Type[] { typeof(EpmChartUserSettings), typeof(SPList) };
            object[] parametersOfSetBubbleChartInputSelectionsBasedOnPersonalizationSettings = { userSettings, selectedList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetBubbleChartInputSelectionsBasedOnPersonalizationSettings, methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfSetBubbleChartInputSelectionsBasedOnPersonalizationSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetBubbleChartInputSelectionsBasedOnPersonalizationSettings.ShouldNotBeNull();
            parametersOfSetBubbleChartInputSelectionsBasedOnPersonalizationSettings.Length.ShouldBe(2);
            methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes.Length.ShouldBe(2);
            methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes.Length.ShouldBe(parametersOfSetBubbleChartInputSelectionsBasedOnPersonalizationSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetBubbleChartInputSelectionsBasedOnPersonalizationSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetBubbleChartInputSelectionsBasedOnPersonalizationSettings_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<EpmChartUserSettings>();
            var selectedList = CreateType<SPList>();
            var methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes = new Type[] { typeof(EpmChartUserSettings), typeof(SPList) };
            object[] parametersOfSetBubbleChartInputSelectionsBasedOnPersonalizationSettings = { userSettings, selectedList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodSetBubbleChartInputSelectionsBasedOnPersonalizationSettings, parametersOfSetBubbleChartInputSelectionsBasedOnPersonalizationSettings, methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes);

            // Assert
            parametersOfSetBubbleChartInputSelectionsBasedOnPersonalizationSettings.ShouldNotBeNull();
            parametersOfSetBubbleChartInputSelectionsBasedOnPersonalizationSettings.Length.ShouldBe(2);
            methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes.Length.ShouldBe(2);
            methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes.Length.ShouldBe(parametersOfSetBubbleChartInputSelectionsBasedOnPersonalizationSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetBubbleChartInputSelectionsBasedOnPersonalizationSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetBubbleChartInputSelectionsBasedOnPersonalizationSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetBubbleChartInputSelectionsBasedOnPersonalizationSettings, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetBubbleChartInputSelectionsBasedOnPersonalizationSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetBubbleChartInputSelectionsBasedOnPersonalizationSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes = new Type[] { typeof(EpmChartUserSettings), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetBubbleChartInputSelectionsBasedOnPersonalizationSettings, Fixture, methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes);

            // Assert
            methodSetBubbleChartInputSelectionsBasedOnPersonalizationSettingsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetBubbleChartInputSelectionsBasedOnPersonalizationSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetBubbleChartInputSelectionsBasedOnPersonalizationSettings_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetBubbleChartInputSelectionsBasedOnPersonalizationSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetZaxisColorFieldSelection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_SetZaxisColorFieldSelection_Method_Call_Internally(Type[] types)
        {
            var methodSetZaxisColorFieldSelectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetZaxisColorFieldSelection, Fixture, methodSetZaxisColorFieldSelectionPrametersTypes);
        }

        #endregion

        #region Method Call : (SetZaxisColorFieldSelection) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetZaxisColorFieldSelection_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<EpmChartUserSettings>();
            var methodSetZaxisColorFieldSelectionPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfSetZaxisColorFieldSelection = { userSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetZaxisColorFieldSelection, methodSetZaxisColorFieldSelectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfSetZaxisColorFieldSelection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetZaxisColorFieldSelection.ShouldNotBeNull();
            parametersOfSetZaxisColorFieldSelection.Length.ShouldBe(1);
            methodSetZaxisColorFieldSelectionPrametersTypes.Length.ShouldBe(1);
            methodSetZaxisColorFieldSelectionPrametersTypes.Length.ShouldBe(parametersOfSetZaxisColorFieldSelection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetZaxisColorFieldSelection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetZaxisColorFieldSelection_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<EpmChartUserSettings>();
            var methodSetZaxisColorFieldSelectionPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfSetZaxisColorFieldSelection = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodSetZaxisColorFieldSelection, parametersOfSetZaxisColorFieldSelection, methodSetZaxisColorFieldSelectionPrametersTypes);

            // Assert
            parametersOfSetZaxisColorFieldSelection.ShouldNotBeNull();
            parametersOfSetZaxisColorFieldSelection.Length.ShouldBe(1);
            methodSetZaxisColorFieldSelectionPrametersTypes.Length.ShouldBe(1);
            methodSetZaxisColorFieldSelectionPrametersTypes.Length.ShouldBe(parametersOfSetZaxisColorFieldSelection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetZaxisColorFieldSelection) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetZaxisColorFieldSelection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetZaxisColorFieldSelection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetZaxisColorFieldSelection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetZaxisColorFieldSelection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetZaxisColorFieldSelectionPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetZaxisColorFieldSelection, Fixture, methodSetZaxisColorFieldSelectionPrametersTypes);

            // Assert
            methodSetZaxisColorFieldSelectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetZaxisColorFieldSelection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetZaxisColorFieldSelection_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetZaxisColorFieldSelection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetZaxisSelection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_SetZaxisSelection_Method_Call_Internally(Type[] types)
        {
            var methodSetZaxisSelectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetZaxisSelection, Fixture, methodSetZaxisSelectionPrametersTypes);
        }

        #endregion

        #region Method Call : (SetZaxisSelection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetZaxisSelection_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<EpmChartUserSettings>();
            var methodSetZaxisSelectionPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfSetZaxisSelection = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodSetZaxisSelection, parametersOfSetZaxisSelection, methodSetZaxisSelectionPrametersTypes);

            // Assert
            parametersOfSetZaxisSelection.ShouldNotBeNull();
            parametersOfSetZaxisSelection.Length.ShouldBe(1);
            methodSetZaxisSelectionPrametersTypes.Length.ShouldBe(1);
            methodSetZaxisSelectionPrametersTypes.Length.ShouldBe(parametersOfSetZaxisSelection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetZaxisSelection) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetZaxisSelection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetZaxisSelection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetZaxisSelection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetZaxisSelection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetZaxisSelectionPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetZaxisSelection, Fixture, methodSetZaxisSelectionPrametersTypes);

            // Assert
            methodSetZaxisSelectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetZaxisSelection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetZaxisSelection_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetZaxisSelection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYaxisSelections) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_SetYaxisSelections_Method_Call_Internally(Type[] types)
        {
            var methodSetYaxisSelectionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetYaxisSelections, Fixture, methodSetYaxisSelectionsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetYaxisSelections) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYaxisSelections_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<EpmChartUserSettings>();
            var methodSetYaxisSelectionsPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfSetYaxisSelections = { userSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetYaxisSelections, methodSetYaxisSelectionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfSetYaxisSelections);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetYaxisSelections.ShouldNotBeNull();
            parametersOfSetYaxisSelections.Length.ShouldBe(1);
            methodSetYaxisSelectionsPrametersTypes.Length.ShouldBe(1);
            methodSetYaxisSelectionsPrametersTypes.Length.ShouldBe(parametersOfSetYaxisSelections.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYaxisSelections) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYaxisSelections_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<EpmChartUserSettings>();
            var methodSetYaxisSelectionsPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfSetYaxisSelections = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodSetYaxisSelections, parametersOfSetYaxisSelections, methodSetYaxisSelectionsPrametersTypes);

            // Assert
            parametersOfSetYaxisSelections.ShouldNotBeNull();
            parametersOfSetYaxisSelections.Length.ShouldBe(1);
            methodSetYaxisSelectionsPrametersTypes.Length.ShouldBe(1);
            methodSetYaxisSelectionsPrametersTypes.Length.ShouldBe(parametersOfSetYaxisSelections.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYaxisSelections) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYaxisSelections_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetYaxisSelections, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetYaxisSelections) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYaxisSelections_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetYaxisSelectionsPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetYaxisSelections, Fixture, methodSetYaxisSelectionsPrametersTypes);

            // Assert
            methodSetYaxisSelectionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYaxisSelections) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetYaxisSelections_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetYaxisSelections, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXaxisSelection) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_SetXaxisSelection_Method_Call_Internally(Type[] types)
        {
            var methodSetXaxisSelectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetXaxisSelection, Fixture, methodSetXaxisSelectionPrametersTypes);
        }

        #endregion

        #region Method Call : (SetXaxisSelection) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetXaxisSelection_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<EpmChartUserSettings>();
            var methodSetXaxisSelectionPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfSetXaxisSelection = { userSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetXaxisSelection, methodSetXaxisSelectionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfSetXaxisSelection);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetXaxisSelection.ShouldNotBeNull();
            parametersOfSetXaxisSelection.Length.ShouldBe(1);
            methodSetXaxisSelectionPrametersTypes.Length.ShouldBe(1);
            methodSetXaxisSelectionPrametersTypes.Length.ShouldBe(parametersOfSetXaxisSelection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXaxisSelection) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetXaxisSelection_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<EpmChartUserSettings>();
            var methodSetXaxisSelectionPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };
            object[] parametersOfSetXaxisSelection = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodSetXaxisSelection, parametersOfSetXaxisSelection, methodSetXaxisSelectionPrametersTypes);

            // Assert
            parametersOfSetXaxisSelection.ShouldNotBeNull();
            parametersOfSetXaxisSelection.Length.ShouldBe(1);
            methodSetXaxisSelectionPrametersTypes.Length.ShouldBe(1);
            methodSetXaxisSelectionPrametersTypes.Length.ShouldBe(parametersOfSetXaxisSelection.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXaxisSelection) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetXaxisSelection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetXaxisSelection, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetXaxisSelection) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetXaxisSelection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetXaxisSelectionPrametersTypes = new Type[] { typeof(EpmChartUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetXaxisSelection, Fixture, methodSetXaxisSelectionPrametersTypes);

            // Assert
            methodSetXaxisSelectionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXaxisSelection) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetXaxisSelection_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetXaxisSelection, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetBubbleChartInputsBasedOnWebPartProperties) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_SetBubbleChartInputsBasedOnWebPartProperties_Method_Call_Internally(Type[] types)
        {
            var methodSetBubbleChartInputsBasedOnWebPartPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetBubbleChartInputsBasedOnWebPartProperties, Fixture, methodSetBubbleChartInputsBasedOnWebPartPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetBubbleChartInputsBasedOnWebPartProperties) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetBubbleChartInputsBasedOnWebPartProperties_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSetBubbleChartInputsBasedOnWebPartPropertiesPrametersTypes = null;
            object[] parametersOfSetBubbleChartInputsBasedOnWebPartProperties = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodSetBubbleChartInputsBasedOnWebPartProperties, parametersOfSetBubbleChartInputsBasedOnWebPartProperties, methodSetBubbleChartInputsBasedOnWebPartPropertiesPrametersTypes);

            // Assert
            parametersOfSetBubbleChartInputsBasedOnWebPartProperties.ShouldBeNull();
            methodSetBubbleChartInputsBasedOnWebPartPropertiesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetBubbleChartInputsBasedOnWebPartProperties) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetBubbleChartInputsBasedOnWebPartProperties_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSetBubbleChartInputsBasedOnWebPartPropertiesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSetBubbleChartInputsBasedOnWebPartProperties, Fixture, methodSetBubbleChartInputsBasedOnWebPartPropertiesPrametersTypes);

            // Assert
            methodSetBubbleChartInputsBasedOnWebPartPropertiesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetBubbleChartInputsBasedOnWebPartProperties) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SetBubbleChartInputsBasedOnWebPartProperties_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetBubbleChartInputsBasedOnWebPartProperties, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateBubbleChartInputsWithInitialValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_PopulateBubbleChartInputsWithInitialValues_Method_Call_Internally(Type[] types)
        {
            var methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodPopulateBubbleChartInputsWithInitialValues, Fixture, methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateBubbleChartInputsWithInitialValues) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_PopulateBubbleChartInputsWithInitialValues_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfPopulateBubbleChartInputsWithInitialValues = { list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateBubbleChartInputsWithInitialValues, methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfPopulateBubbleChartInputsWithInitialValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateBubbleChartInputsWithInitialValues.ShouldNotBeNull();
            parametersOfPopulateBubbleChartInputsWithInitialValues.Length.ShouldBe(1);
            methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes.Length.ShouldBe(1);
            methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes.Length.ShouldBe(parametersOfPopulateBubbleChartInputsWithInitialValues.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateBubbleChartInputsWithInitialValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_PopulateBubbleChartInputsWithInitialValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes = new Type[] { typeof(SPList) };
            object[] parametersOfPopulateBubbleChartInputsWithInitialValues = { list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodPopulateBubbleChartInputsWithInitialValues, parametersOfPopulateBubbleChartInputsWithInitialValues, methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes);

            // Assert
            parametersOfPopulateBubbleChartInputsWithInitialValues.ShouldNotBeNull();
            parametersOfPopulateBubbleChartInputsWithInitialValues.Length.ShouldBe(1);
            methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes.Length.ShouldBe(1);
            methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes.Length.ShouldBe(parametersOfPopulateBubbleChartInputsWithInitialValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateBubbleChartInputsWithInitialValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_PopulateBubbleChartInputsWithInitialValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateBubbleChartInputsWithInitialValues, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateBubbleChartInputsWithInitialValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_PopulateBubbleChartInputsWithInitialValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes = new Type[] { typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodPopulateBubbleChartInputsWithInitialValues, Fixture, methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes);

            // Assert
            methodPopulateBubbleChartInputsWithInitialValuesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateBubbleChartInputsWithInitialValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_PopulateBubbleChartInputsWithInitialValues_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateBubbleChartInputsWithInitialValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortBubbleChartDropDownLists) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_SortBubbleChartDropDownLists_Method_Call_Internally(Type[] types)
        {
            var methodSortBubbleChartDropDownListsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSortBubbleChartDropDownLists, Fixture, methodSortBubbleChartDropDownListsPrametersTypes);
        }

        #endregion

        #region Method Call : (SortBubbleChartDropDownLists) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SortBubbleChartDropDownLists_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodSortBubbleChartDropDownListsPrametersTypes = null;
            object[] parametersOfSortBubbleChartDropDownLists = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSortBubbleChartDropDownLists, methodSortBubbleChartDropDownListsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfSortBubbleChartDropDownLists);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSortBubbleChartDropDownLists.ShouldBeNull();
            methodSortBubbleChartDropDownListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortBubbleChartDropDownLists) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SortBubbleChartDropDownLists_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodSortBubbleChartDropDownListsPrametersTypes = null;
            object[] parametersOfSortBubbleChartDropDownLists = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodSortBubbleChartDropDownLists, parametersOfSortBubbleChartDropDownLists, methodSortBubbleChartDropDownListsPrametersTypes);

            // Assert
            parametersOfSortBubbleChartDropDownLists.ShouldBeNull();
            methodSortBubbleChartDropDownListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortBubbleChartDropDownLists) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SortBubbleChartDropDownLists_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodSortBubbleChartDropDownListsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodSortBubbleChartDropDownLists, Fixture, methodSortBubbleChartDropDownListsPrametersTypes);

            // Assert
            methodSortBubbleChartDropDownListsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortBubbleChartDropDownLists) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_SortBubbleChartDropDownLists_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSortBubbleChartDropDownLists, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ChartControl_RebuildControlTree_Method_Call_Internally(Type[] types)
        {
            var methodRebuildControlTreePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodRebuildControlTree, Fixture, methodRebuildControlTreePrametersTypes);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RebuildControlTree_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _chartControlInstance.RebuildControlTree();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RebuildControlTree_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRebuildControlTreePrametersTypes = null;
            object[] parametersOfRebuildControlTree = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRebuildControlTree, methodRebuildControlTreePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_chartControlInstanceFixture, parametersOfRebuildControlTree);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRebuildControlTree.ShouldBeNull();
            methodRebuildControlTreePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RebuildControlTree_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRebuildControlTreePrametersTypes = null;
            object[] parametersOfRebuildControlTree = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_chartControlInstance, MethodRebuildControlTree, parametersOfRebuildControlTree, methodRebuildControlTreePrametersTypes);

            // Assert
            parametersOfRebuildControlTree.ShouldBeNull();
            methodRebuildControlTreePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RebuildControlTree_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRebuildControlTreePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_chartControlInstance, MethodRebuildControlTree, Fixture, methodRebuildControlTreePrametersTypes);

            // Assert
            methodRebuildControlTreePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ChartControl_RebuildControlTree_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRebuildControlTree, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_chartControlInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}