using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Web.UI;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using Telerik.Web.UI;

namespace EPMLiveWebParts.ReportingChart
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportingChart.ReportingChart" />)
    ///     and namespace <see cref="EPMLiveWebParts.ReportingChart"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ReportingChartTest : AbstractBaseSetupTypedTest<ReportingChart>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingChart) Initializer

        private const string PropertyDictFieldIntAndDispName = "DictFieldIntAndDispName";
        private const string Property_filterWebPartId = "_filterWebPartId";
        private const string PropertyPropChartTitle = "PropChartTitle";
        private const string PropertyPropChartType = "PropChartType";
        private const string PropertyPropChartSelectedPaletteName = "PropChartSelectedPaletteName";
        private const string PropertyPropChartSelectedListTitle = "PropChartSelectedListTitle";
        private const string PropertyPropChartSelectedViewTitle = "PropChartSelectedViewTitle";
        private const string PropertyPropChartXaxisField = "PropChartXaxisField";
        private const string PropertyPropChartXaxisFieldLabel = "PropChartXaxisFieldLabel";
        private const string PropertyPropChartYaxisField = "PropChartYaxisField";
        private const string PropertyPropChartYaxisFieldLabel = "PropChartYaxisFieldLabel";
        private const string PropertyPropChartZaxisField = "PropChartZaxisField";
        private const string PropertyPropChartZaxisFieldLabel = "PropChartZaxisFieldLabel";
        private const string PropertyPropBubbleChartGroupBy = "PropBubbleChartGroupBy";
        private const string PropertyPropYaxisFormat = "PropYaxisFormat";
        private const string PropertyPropChartShowSeriesLabels = "PropChartShowSeriesLabels";
        private const string PropertyPropChartShowLegend = "PropChartShowLegend";
        private const string PropertyPropChartLegendPosition = "PropChartLegendPosition";
        private const string PropertyPropChartShowGridlines = "PropChartShowGridlines";
        private const string PropertyPropChartAggregationType = "PropChartAggregationType";
        private const string PropertyUpdatePanelClientId = "UpdatePanelClientId";
        private const string PropertyRadChartClientId = "RadChartClientId";
        private const string MethodReportIDConsumer = "ReportIDConsumer";
        private const string MethodOnInit = "OnInit";
        private const string MethodOnLoad = "OnLoad";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodRenderControl = "RenderControl";
        private const string MethodAddControls = "AddControls";
        private const string MethodupdatePanel_Load = "updatePanel_Load";
        private const string MethodSetChartProps = "SetChartProps";
        private const string MethodConfigureDisplayFormat = "ConfigureDisplayFormat";
        private const string MethodBuildXAxisItemLabels = "BuildXAxisItemLabels";
        private const string MethodBuildYAxisItemLabels = "BuildYAxisItemLabels";
        private const string MethodBuildSeries = "BuildSeries";
        private const string MethodGetColors = "GetColors";
        private const string MethodBuildAreaSeries = "BuildAreaSeries";
        private const string MethodBuildBarSeries = "BuildBarSeries";
        private const string MethodBuildColumnSeries = "BuildColumnSeries";
        private const string MethodBuildLineSeries = "BuildLineSeries";
        private const string MethodBuildPieSeries = "BuildPieSeries";
        private const string MethodBuildScatterSeries = "BuildScatterSeries";
        private const string MethodBuildScatterLineSeries = "BuildScatterLineSeries";
        private const string MethodBuildBubbleSeries = "BuildBubbleSeries";
        private const string MethodBuildDonutSeries = "BuildDonutSeries";
        private const string MethodGetSeriesItems = "GetSeriesItems";
        private const string MethodGetFilterQuery = "GetFilterQuery";
        private const string MethodThisChartIsTiedToAReportFilter = "ThisChartIsTiedToAReportFilter";
        private const string MethodUpdateTheOriginalQueryToAlsoFilterTitles = "UpdateTheOriginalQueryToAlsoFilterTitles";
        private const string MethodGetDataForBubbleSeries = "GetDataForBubbleSeries";
        private const string MethodGetCountDataForPieSeries = "GetCountDataForPieSeries";
        private const string MethodGetSumDataForPieSeries = "GetSumDataForPieSeries";
        private const string MethodGetAvgDataForPieSeries = "GetAvgDataForPieSeries";
        private const string MethodGetCountDataForSingleSeries = "GetCountDataForSingleSeries";
        private const string MethodGetCountDataForClusteredGraph = "GetCountDataForClusteredGraph";
        private const string MethodGetCountDataForClusteredGraphInPercentage = "GetCountDataForClusteredGraphInPercentage";
        private const string MethodGetSumDataForMultiSeries = "GetSumDataForMultiSeries";
        private const string MethodGetSumDataForMultiSeriesInPercentage = "GetSumDataForMultiSeriesInPercentage";
        private const string MethodGetAvgDataForMultiSeries = "GetAvgDataForMultiSeries";
        private const string MethodGetAvgDataForMultiSeriesInPercentage = "GetAvgDataForMultiSeriesInPercentage";
        private const string MethodApplyColorToBaseSeriesForMulticolor = "ApplyColorToBaseSeriesForMulticolor";
        private const string MethodApplyColorToBaseSeriesForSingleColor = "ApplyColorToBaseSeriesForSingleColor";
        private const string MethodGetSelectedListData = "GetSelectedListData";
        private const string MethodGetToolParts = "GetToolParts";
        private const string MethodRebuildControlTree = "RebuildControlTree";
        private const string MethodSetXFieldValue = "SetXFieldValue";
        private const string MethodSetXFieldLabel = "SetXFieldLabel";
        private const string MethodSetYFieldsValues = "SetYFieldsValues";
        private const string MethodSetYFieldsLabels = "SetYFieldsLabels";
        private const string MethodGetYFieldsValues = "GetYFieldsValues";
        private const string MethodGetYFieldsLabel = "GetYFieldsLabel";
        private const string MethodIsBubbleChart = "IsBubbleChart";
        private const string MethodGetFldDispNameFromIntName = "GetFldDispNameFromIntName";
        private const string MethodGetFldsIntAndDispNameDictionary = "GetFldsIntAndDispNameDictionary";
        private const string MethodGetListColumns = "GetListColumns";
        private const string MethodColExistsInListReportingDB = "ColExistsInListReportingDB";
        private const string MethodIsLookupCol = "IsLookupCol";
        private const string MethodGetSQLColNameIfLookup = "GetSQLColNameIfLookup";
        private const string FieldCURRENCY_SYMBOL = "CURRENCY_SYMBOL";
        private const string FieldNULL_CATEGORY_TEXT = "NULL_CATEGORY_TEXT";
        private const string FieldSeparator = "Separator";
        private const string FieldScriptTagHolder = "ScriptTagHolder";
        private const string FieldChartData = "ChartData";
        private const string FieldSiteDataQueryData = "SiteDataQueryData";
        private const string FieldConfigureChartVerbiageLiteral = "ConfigureChartVerbiageLiteral";
        private const string FieldTopList = "TopList";
        private const string FieldWebPartToolPart = "WebPartToolPart";
        private const string Field_radChart = "_radChart";
        private const string FieldBubbleChartXaxisDropDownList = "BubbleChartXaxisDropDownList";
        private const string FieldBubbleChartYaxisAsDropDownList = "BubbleChartYaxisAsDropDownList";
        private const string FieldBubbleChartYaxisCheckBoxList = "BubbleChartYaxisCheckBoxList";
        private const string FieldBubbleChartZaxisDropDownList = "BubbleChartZaxisDropDownList";
        private const string FieldBubbleChartZcolorFieldDropDownList = "BubbleChartZcolorFieldDropDownList";
        private const string FieldBubbleChartApplyButton = "BubbleChartApplyButton";
        private const string FieldUserSettingsTable = "UserSettingsTable";
        private const string FieldMainTable = "MainTable";
        private const string FieldMainChartType = "MainChartType";
        private const string FieldbPropChartShowSeriesLabels = "bPropChartShowSeriesLabels";
        private const string FieldbPropChartShowLegend = "bPropChartShowLegend";
        private const string FieldsPropChartLegendPosition = "sPropChartLegendPosition";
        private const string FieldbPropChartShowGridlines = "bPropChartShowGridlines";
        private const string FieldXAxisLabels = "XAxisLabels";
        private const string FieldYAxisLabel = "YAxisLabel";
        private const string Field_myProvider = "_myProvider";
        private Type _reportingChartInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingChart _reportingChartInstance;
        private ReportingChart _reportingChartInstanceFixture;

        #region General Initializer : Class (ReportingChart) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingChart" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingChartInstanceType = typeof(ReportingChart);
            _reportingChartInstanceFixture = Create(true);
            _reportingChartInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingChart)

        #region General Initializer : Class (ReportingChart) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingChart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodReportIDConsumer, 0)]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodOnLoad, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodRenderControl, 0)]
        [TestCase(MethodAddControls, 0)]
        [TestCase(MethodupdatePanel_Load, 0)]
        [TestCase(MethodSetChartProps, 0)]
        [TestCase(MethodConfigureDisplayFormat, 0)]
        [TestCase(MethodBuildXAxisItemLabels, 0)]
        [TestCase(MethodBuildYAxisItemLabels, 0)]
        [TestCase(MethodBuildSeries, 0)]
        [TestCase(MethodGetColors, 0)]
        [TestCase(MethodBuildAreaSeries, 0)]
        [TestCase(MethodBuildBarSeries, 0)]
        [TestCase(MethodBuildColumnSeries, 0)]
        [TestCase(MethodBuildLineSeries, 0)]
        [TestCase(MethodBuildPieSeries, 0)]
        [TestCase(MethodBuildScatterSeries, 0)]
        [TestCase(MethodBuildScatterLineSeries, 0)]
        [TestCase(MethodBuildBubbleSeries, 0)]
        [TestCase(MethodBuildDonutSeries, 0)]
        [TestCase(MethodGetSeriesItems, 0)]
        [TestCase(MethodGetFilterQuery, 0)]
        [TestCase(MethodThisChartIsTiedToAReportFilter, 0)]
        [TestCase(MethodUpdateTheOriginalQueryToAlsoFilterTitles, 0)]
        [TestCase(MethodGetDataForBubbleSeries, 0)]
        [TestCase(MethodGetCountDataForPieSeries, 0)]
        [TestCase(MethodGetSumDataForPieSeries, 0)]
        [TestCase(MethodGetAvgDataForPieSeries, 0)]
        [TestCase(MethodGetCountDataForSingleSeries, 0)]
        [TestCase(MethodGetCountDataForClusteredGraph, 0)]
        [TestCase(MethodGetCountDataForClusteredGraphInPercentage, 0)]
        [TestCase(MethodGetSumDataForMultiSeries, 0)]
        [TestCase(MethodGetSumDataForMultiSeriesInPercentage, 0)]
        [TestCase(MethodGetAvgDataForMultiSeries, 0)]
        [TestCase(MethodGetAvgDataForMultiSeriesInPercentage, 0)]
        [TestCase(MethodApplyColorToBaseSeriesForMulticolor, 0)]
        [TestCase(MethodApplyColorToBaseSeriesForSingleColor, 0)]
        [TestCase(MethodGetSelectedListData, 0)]
        [TestCase(MethodGetToolParts, 0)]
        [TestCase(MethodRebuildControlTree, 0)]
        [TestCase(MethodSetXFieldValue, 0)]
        [TestCase(MethodSetXFieldLabel, 0)]
        [TestCase(MethodSetYFieldsValues, 0)]
        [TestCase(MethodSetYFieldsLabels, 0)]
        [TestCase(MethodGetYFieldsValues, 0)]
        [TestCase(MethodGetYFieldsLabel, 0)]
        [TestCase(MethodIsBubbleChart, 0)]
        [TestCase(MethodGetFldDispNameFromIntName, 0)]
        [TestCase(MethodGetFldsIntAndDispNameDictionary, 0)]
        [TestCase(MethodGetListColumns, 0)]
        [TestCase(MethodColExistsInListReportingDB, 0)]
        [TestCase(MethodIsLookupCol, 0)]
        [TestCase(MethodGetSQLColNameIfLookup, 0)]
        public void AUT_ReportingChart_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingChartInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportingChart) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportingChart" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyDictFieldIntAndDispName)]
        [TestCase(Property_filterWebPartId)]
        [TestCase(PropertyPropChartTitle)]
        [TestCase(PropertyPropChartType)]
        [TestCase(PropertyPropChartSelectedPaletteName)]
        [TestCase(PropertyPropChartSelectedListTitle)]
        [TestCase(PropertyPropChartSelectedViewTitle)]
        [TestCase(PropertyPropChartXaxisField)]
        [TestCase(PropertyPropChartXaxisFieldLabel)]
        [TestCase(PropertyPropChartYaxisField)]
        [TestCase(PropertyPropChartYaxisFieldLabel)]
        [TestCase(PropertyPropChartZaxisField)]
        [TestCase(PropertyPropChartZaxisFieldLabel)]
        [TestCase(PropertyPropBubbleChartGroupBy)]
        [TestCase(PropertyPropYaxisFormat)]
        [TestCase(PropertyPropChartShowSeriesLabels)]
        [TestCase(PropertyPropChartShowLegend)]
        [TestCase(PropertyPropChartLegendPosition)]
        [TestCase(PropertyPropChartShowGridlines)]
        [TestCase(PropertyPropChartAggregationType)]
        [TestCase(PropertyUpdatePanelClientId)]
        [TestCase(PropertyRadChartClientId)]
        public void AUT_ReportingChart_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportingChartInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportingChart) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportingChart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldCURRENCY_SYMBOL)]
        [TestCase(FieldNULL_CATEGORY_TEXT)]
        [TestCase(FieldSeparator)]
        [TestCase(FieldScriptTagHolder)]
        [TestCase(FieldChartData)]
        [TestCase(FieldSiteDataQueryData)]
        [TestCase(FieldConfigureChartVerbiageLiteral)]
        [TestCase(FieldTopList)]
        [TestCase(FieldWebPartToolPart)]
        [TestCase(Field_radChart)]
        [TestCase(FieldBubbleChartXaxisDropDownList)]
        [TestCase(FieldBubbleChartYaxisAsDropDownList)]
        [TestCase(FieldBubbleChartYaxisCheckBoxList)]
        [TestCase(FieldBubbleChartZaxisDropDownList)]
        [TestCase(FieldBubbleChartZcolorFieldDropDownList)]
        [TestCase(FieldBubbleChartApplyButton)]
        [TestCase(FieldUserSettingsTable)]
        [TestCase(FieldMainTable)]
        [TestCase(FieldMainChartType)]
        [TestCase(FieldbPropChartShowSeriesLabels)]
        [TestCase(FieldbPropChartShowLegend)]
        [TestCase(FieldsPropChartLegendPosition)]
        [TestCase(FieldbPropChartShowGridlines)]
        [TestCase(FieldXAxisLabels)]
        [TestCase(FieldYAxisLabel)]
        [TestCase(Field_myProvider)]
        public void AUT_ReportingChart_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportingChartInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportingChart) => Property (_filterWebPartId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart__filterWebPartId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Property_filterWebPartId);
            Action currentAction = () => propertyInfo.SetValue(_reportingChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportingChart) => Property (_filterWebPartId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class__filterWebPartId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Property_filterWebPartId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingChart) => Property (DictFieldIntAndDispName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_DictFieldIntAndDispName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDictFieldIntAndDispName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingChart) => Property (PropBubbleChartGroupBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropBubbleChartGroupBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropBubbleChartGroupBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartAggregationType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartAggregationType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartLegendPosition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartLegendPosition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartLegendPosition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartSelectedListTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartSelectedListTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartSelectedListTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartSelectedPaletteName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartSelectedPaletteName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartSelectedViewTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartSelectedViewTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartSelectedViewTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartShowGridlines) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartShowGridlines_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartShowLegend) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartShowLegend_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartShowSeriesLabels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartShowSeriesLabels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartXaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartXaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartXaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartXaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartYaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartYaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartYaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartYaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartZaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartZaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropChartZaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropChartZaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportingChart) => Property (PropYaxisFormat) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_PropYaxisFormat_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropYaxisFormat);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingChart) => Property (RadChartClientId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_RadChartClientId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRadChartClientId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingChart) => Property (UpdatePanelClientId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingChart_Public_Class_UpdatePanelClientId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUpdatePanelClientId);

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

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportingChart" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodReportIDConsumer)]
        [TestCase(MethodOnInit)]
        [TestCase(MethodOnLoad)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodRenderControl)]
        [TestCase(MethodAddControls)]
        [TestCase(MethodupdatePanel_Load)]
        [TestCase(MethodSetChartProps)]
        [TestCase(MethodConfigureDisplayFormat)]
        [TestCase(MethodBuildXAxisItemLabels)]
        [TestCase(MethodBuildYAxisItemLabels)]
        [TestCase(MethodBuildSeries)]
        [TestCase(MethodGetColors)]
        [TestCase(MethodBuildAreaSeries)]
        [TestCase(MethodBuildBarSeries)]
        [TestCase(MethodBuildColumnSeries)]
        [TestCase(MethodBuildLineSeries)]
        [TestCase(MethodBuildPieSeries)]
        [TestCase(MethodBuildScatterSeries)]
        [TestCase(MethodBuildScatterLineSeries)]
        [TestCase(MethodBuildBubbleSeries)]
        [TestCase(MethodBuildDonutSeries)]
        [TestCase(MethodGetSeriesItems)]
        [TestCase(MethodGetFilterQuery)]
        [TestCase(MethodThisChartIsTiedToAReportFilter)]
        [TestCase(MethodUpdateTheOriginalQueryToAlsoFilterTitles)]
        [TestCase(MethodGetDataForBubbleSeries)]
        [TestCase(MethodGetCountDataForPieSeries)]
        [TestCase(MethodGetSumDataForPieSeries)]
        [TestCase(MethodGetAvgDataForPieSeries)]
        [TestCase(MethodGetCountDataForSingleSeries)]
        [TestCase(MethodGetCountDataForClusteredGraph)]
        [TestCase(MethodGetCountDataForClusteredGraphInPercentage)]
        [TestCase(MethodGetSumDataForMultiSeries)]
        [TestCase(MethodGetSumDataForMultiSeriesInPercentage)]
        [TestCase(MethodGetAvgDataForMultiSeries)]
        [TestCase(MethodGetAvgDataForMultiSeriesInPercentage)]
        [TestCase(MethodApplyColorToBaseSeriesForMulticolor)]
        [TestCase(MethodApplyColorToBaseSeriesForSingleColor)]
        [TestCase(MethodGetSelectedListData)]
        [TestCase(MethodGetToolParts)]
        [TestCase(MethodRebuildControlTree)]
        [TestCase(MethodSetXFieldValue)]
        [TestCase(MethodSetXFieldLabel)]
        [TestCase(MethodSetYFieldsValues)]
        [TestCase(MethodSetYFieldsLabels)]
        [TestCase(MethodGetYFieldsValues)]
        [TestCase(MethodGetYFieldsLabel)]
        [TestCase(MethodIsBubbleChart)]
        [TestCase(MethodGetFldDispNameFromIntName)]
        [TestCase(MethodGetFldsIntAndDispNameDictionary)]
        [TestCase(MethodGetListColumns)]
        [TestCase(MethodColExistsInListReportingDB)]
        [TestCase(MethodIsLookupCol)]
        [TestCase(MethodGetSQLColNameIfLookup)]
        public void AUT_ReportingChart_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportingChart>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_ReportIDConsumer_Method_Call_Internally(Type[] types)
        {
            var methodReportIDConsumerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodReportIDConsumer, Fixture, methodReportIDConsumerPrametersTypes);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ReportIDConsumer_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var Provider = CreateType<IReportID>();
            var methodReportIDConsumerPrametersTypes = new Type[] { typeof(IReportID) };
            object[] parametersOfReportIDConsumer = { Provider };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodReportIDConsumer, parametersOfReportIDConsumer, methodReportIDConsumerPrametersTypes);

            // Assert
            parametersOfReportIDConsumer.ShouldNotBeNull();
            parametersOfReportIDConsumer.Length.ShouldBe(1);
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(1);
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(parametersOfReportIDConsumer.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ReportIDConsumer_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodReportIDConsumer, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ReportIDConsumer_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodReportIDConsumerPrametersTypes = new Type[] { typeof(IReportID) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodReportIDConsumer, Fixture, methodReportIDConsumerPrametersTypes);

            // Assert
            methodReportIDConsumerPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIDConsumer) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ReportIDConsumer_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReportIDConsumer, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

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
        public void AUT_ReportingChart_OnInit_Method_Call_Parameters_Count_Verification_Test()
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
        public void AUT_ReportingChart_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_OnLoad_Method_Call_Internally(Type[] types)
        {
            var methodOnLoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_OnLoad_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnLoad, methodOnLoadPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartInstanceFixture, parametersOfOnLoad);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_OnLoad_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnLoad = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodOnLoad, parametersOfOnLoad, methodOnLoadPrametersTypes);

            // Assert
            parametersOfOnLoad.ShouldNotBeNull();
            parametersOfOnLoad.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            methodOnLoadPrametersTypes.Length.ShouldBe(parametersOfOnLoad.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_OnLoad_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_OnLoad_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnLoadPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodOnLoad, Fixture, methodOnLoadPrametersTypes);

            // Assert
            methodOnLoadPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnLoad) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_OnLoad_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnLoad, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

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
        public void AUT_ReportingChart_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_RenderControl_Method_Call_Internally(Type[] types)
        {
            var methodRenderControlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodRenderControl, Fixture, methodRenderControlPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_RenderControl_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingChartInstance.RenderControl(writer);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_RenderControl_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderControlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderControl = { writer };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderControl, methodRenderControlPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartInstanceFixture, parametersOfRenderControl);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderControl.ShouldNotBeNull();
            parametersOfRenderControl.Length.ShouldBe(1);
            methodRenderControlPrametersTypes.Length.ShouldBe(1);
            methodRenderControlPrametersTypes.Length.ShouldBe(parametersOfRenderControl.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_RenderControl_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var writer = CreateType<HtmlTextWriter>();
            var methodRenderControlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };
            object[] parametersOfRenderControl = { writer };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodRenderControl, parametersOfRenderControl, methodRenderControlPrametersTypes);

            // Assert
            parametersOfRenderControl.ShouldNotBeNull();
            parametersOfRenderControl.Length.ShouldBe(1);
            methodRenderControlPrametersTypes.Length.ShouldBe(1);
            methodRenderControlPrametersTypes.Length.ShouldBe(parametersOfRenderControl.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_RenderControl_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRenderControl, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_RenderControl_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRenderControlPrametersTypes = new Type[] { typeof(HtmlTextWriter) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodRenderControl, Fixture, methodRenderControlPrametersTypes);

            // Assert
            methodRenderControlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderControl) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_RenderControl_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderControl, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_AddControls_Method_Call_Internally(Type[] types)
        {
            var methodAddControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodAddControls, Fixture, methodAddControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_AddControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddControlsPrametersTypes = null;
            object[] parametersOfAddControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodAddControls, parametersOfAddControls, methodAddControlsPrametersTypes);

            // Assert
            parametersOfAddControls.ShouldBeNull();
            methodAddControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_AddControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodAddControls, Fixture, methodAddControlsPrametersTypes);

            // Assert
            methodAddControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_AddControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (updatePanel_Load) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_updatePanel_Load_Method_Call_Internally(Type[] types)
        {
            var methodupdatePanel_LoadPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodupdatePanel_Load, Fixture, methodupdatePanel_LoadPrametersTypes);
        }

        #endregion

        #region Method Call : (updatePanel_Load) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_updatePanel_Load_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodupdatePanel_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfupdatePanel_Load = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodupdatePanel_Load, parametersOfupdatePanel_Load, methodupdatePanel_LoadPrametersTypes);

            // Assert
            parametersOfupdatePanel_Load.ShouldNotBeNull();
            parametersOfupdatePanel_Load.Length.ShouldBe(2);
            methodupdatePanel_LoadPrametersTypes.Length.ShouldBe(2);
            methodupdatePanel_LoadPrametersTypes.Length.ShouldBe(parametersOfupdatePanel_Load.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (updatePanel_Load) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_updatePanel_Load_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodupdatePanel_Load, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (updatePanel_Load) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_updatePanel_Load_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodupdatePanel_LoadPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodupdatePanel_Load, Fixture, methodupdatePanel_LoadPrametersTypes);

            // Assert
            methodupdatePanel_LoadPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (updatePanel_Load) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_updatePanel_Load_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodupdatePanel_Load, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetChartProps) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_SetChartProps_Method_Call_Internally(Type[] types)
        {
            var methodSetChartPropsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodSetChartProps, Fixture, methodSetChartPropsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (SetChartProps) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetChartProps_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var c = CreateType<RadHtmlChart>();
            var methodSetChartPropsPrametersTypes = new Type[] { typeof(RadHtmlChart) };
            object[] parametersOfSetChartProps = { c };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodSetChartProps, parametersOfSetChartProps, methodSetChartPropsPrametersTypes);

            // Assert
            parametersOfSetChartProps.ShouldNotBeNull();
            parametersOfSetChartProps.Length.ShouldBe(1);
            methodSetChartPropsPrametersTypes.Length.ShouldBe(1);
            methodSetChartPropsPrametersTypes.Length.ShouldBe(parametersOfSetChartProps.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetChartProps) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetChartProps_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetChartProps, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetChartProps) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetChartProps_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetChartPropsPrametersTypes = new Type[] { typeof(RadHtmlChart) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodSetChartProps, Fixture, methodSetChartPropsPrametersTypes);

            // Assert
            methodSetChartPropsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetChartProps) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetChartProps_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetChartProps, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConfigureDisplayFormat) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_ConfigureDisplayFormat_Method_Call_Internally(Type[] types)
        {
            var methodConfigureDisplayFormatPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodConfigureDisplayFormat, Fixture, methodConfigureDisplayFormatPrametersTypes);
        }

        #endregion

        #region Method Call : (ConfigureDisplayFormat) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ConfigureDisplayFormat_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodConfigureDisplayFormatPrametersTypes = null;
            object[] parametersOfConfigureDisplayFormat = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodConfigureDisplayFormat, parametersOfConfigureDisplayFormat, methodConfigureDisplayFormatPrametersTypes);

            // Assert
            parametersOfConfigureDisplayFormat.ShouldBeNull();
            methodConfigureDisplayFormatPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConfigureDisplayFormat) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ConfigureDisplayFormat_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodConfigureDisplayFormatPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodConfigureDisplayFormat, Fixture, methodConfigureDisplayFormatPrametersTypes);

            // Assert
            methodConfigureDisplayFormatPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConfigureDisplayFormat) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ConfigureDisplayFormat_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConfigureDisplayFormat, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildXAxisItemLabels) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildXAxisItemLabels_Method_Call_Internally(Type[] types)
        {
            var methodBuildXAxisItemLabelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildXAxisItemLabels, Fixture, methodBuildXAxisItemLabelsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (BuildXAxisItemLabels) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildXAxisItemLabels_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildXAxisItemLabelsPrametersTypes = null;
            object[] parametersOfBuildXAxisItemLabels = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildXAxisItemLabels, parametersOfBuildXAxisItemLabels, methodBuildXAxisItemLabelsPrametersTypes);

            // Assert
            parametersOfBuildXAxisItemLabels.ShouldBeNull();
            methodBuildXAxisItemLabelsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildXAxisItemLabels) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildXAxisItemLabels_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildXAxisItemLabelsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildXAxisItemLabels, Fixture, methodBuildXAxisItemLabelsPrametersTypes);

            // Assert
            methodBuildXAxisItemLabelsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildXAxisItemLabels) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildXAxisItemLabels_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildXAxisItemLabels, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildYAxisItemLabels) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildYAxisItemLabels_Method_Call_Internally(Type[] types)
        {
            var methodBuildYAxisItemLabelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildYAxisItemLabels, Fixture, methodBuildYAxisItemLabelsPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildYAxisItemLabels) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildYAxisItemLabels_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildYAxisItemLabelsPrametersTypes = null;
            object[] parametersOfBuildYAxisItemLabels = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildYAxisItemLabels, parametersOfBuildYAxisItemLabels, methodBuildYAxisItemLabelsPrametersTypes);

            // Assert
            parametersOfBuildYAxisItemLabels.ShouldBeNull();
            methodBuildYAxisItemLabelsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildYAxisItemLabels) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildYAxisItemLabels_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildYAxisItemLabelsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildYAxisItemLabels, Fixture, methodBuildYAxisItemLabelsPrametersTypes);

            // Assert
            methodBuildYAxisItemLabelsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildYAxisItemLabels) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildYAxisItemLabels_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildYAxisItemLabels, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildSeries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildSeries_Method_Call_Internally(Type[] types)
        {
            var methodBuildSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildSeries, Fixture, methodBuildSeriesPrametersTypes);
        }

        #endregion
        
        #region Method Call : (BuildSeries) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildSeries_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildSeriesPrametersTypes = null;
            object[] parametersOfBuildSeries = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildSeries, parametersOfBuildSeries, methodBuildSeriesPrametersTypes);

            // Assert
            parametersOfBuildSeries.ShouldBeNull();
            methodBuildSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildSeries) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildSeriesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildSeries, Fixture, methodBuildSeriesPrametersTypes);

            // Assert
            methodBuildSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildSeries) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildSeries_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildSeries, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColors) (Return Type : Color[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetColors_Method_Call_Internally(Type[] types)
        {
            var methodGetColorsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetColors, Fixture, methodGetColorsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetColors) (Return Type : Color[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetColors_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var paletteName = CreateType<string>();
            var methodGetColorsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetColors = { paletteName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Color[]>(_reportingChartInstance, MethodGetColors, parametersOfGetColors, methodGetColorsPrametersTypes);

            // Assert
            parametersOfGetColors.ShouldNotBeNull();
            parametersOfGetColors.Length.ShouldBe(1);
            methodGetColorsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetColors) (Return Type : Color[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetColors_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetColorsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetColors, Fixture, methodGetColorsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetColorsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetColors) (Return Type : Color[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetColors_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetColorsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetColors, Fixture, methodGetColorsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetColorsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetColors) (Return Type : Color[]) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetColors_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetColors, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildAreaSeries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildAreaSeries_Method_Call_Internally(Type[] types)
        {
            var methodBuildAreaSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildAreaSeries, Fixture, methodBuildAreaSeriesPrametersTypes);
        }

        #endregion
        
        #region Method Call : (BuildAreaSeries) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildAreaSeries_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildAreaSeriesPrametersTypes = null;
            object[] parametersOfBuildAreaSeries = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildAreaSeries, parametersOfBuildAreaSeries, methodBuildAreaSeriesPrametersTypes);

            // Assert
            parametersOfBuildAreaSeries.ShouldBeNull();
            methodBuildAreaSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildAreaSeries) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildAreaSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildAreaSeriesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildAreaSeries, Fixture, methodBuildAreaSeriesPrametersTypes);

            // Assert
            methodBuildAreaSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildAreaSeries) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildAreaSeries_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildAreaSeries, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildBarSeries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildBarSeries_Method_Call_Internally(Type[] types)
        {
            var methodBuildBarSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildBarSeries, Fixture, methodBuildBarSeriesPrametersTypes);
        }

        #endregion
        
        #region Method Call : (BuildBarSeries) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildBarSeries_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildBarSeriesPrametersTypes = null;
            object[] parametersOfBuildBarSeries = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildBarSeries, parametersOfBuildBarSeries, methodBuildBarSeriesPrametersTypes);

            // Assert
            parametersOfBuildBarSeries.ShouldBeNull();
            methodBuildBarSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildBarSeries) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildBarSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildBarSeriesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildBarSeries, Fixture, methodBuildBarSeriesPrametersTypes);

            // Assert
            methodBuildBarSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildBarSeries) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildBarSeries_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildBarSeries, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildColumnSeries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildColumnSeries_Method_Call_Internally(Type[] types)
        {
            var methodBuildColumnSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildColumnSeries, Fixture, methodBuildColumnSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildColumnSeries) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildColumnSeries_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildColumnSeriesPrametersTypes = null;
            object[] parametersOfBuildColumnSeries = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildColumnSeries, parametersOfBuildColumnSeries, methodBuildColumnSeriesPrametersTypes);

            // Assert
            parametersOfBuildColumnSeries.ShouldBeNull();
            methodBuildColumnSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildColumnSeries) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildColumnSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildColumnSeriesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildColumnSeries, Fixture, methodBuildColumnSeriesPrametersTypes);

            // Assert
            methodBuildColumnSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildColumnSeries) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildColumnSeries_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildColumnSeries, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildLineSeries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildLineSeries_Method_Call_Internally(Type[] types)
        {
            var methodBuildLineSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildLineSeries, Fixture, methodBuildLineSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildLineSeries) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildLineSeries_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildLineSeriesPrametersTypes = null;
            object[] parametersOfBuildLineSeries = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildLineSeries, parametersOfBuildLineSeries, methodBuildLineSeriesPrametersTypes);

            // Assert
            parametersOfBuildLineSeries.ShouldBeNull();
            methodBuildLineSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildLineSeries) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildLineSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildLineSeriesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildLineSeries, Fixture, methodBuildLineSeriesPrametersTypes);

            // Assert
            methodBuildLineSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildLineSeries) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildLineSeries_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildLineSeries, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildPieSeries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildPieSeries_Method_Call_Internally(Type[] types)
        {
            var methodBuildPieSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildPieSeries, Fixture, methodBuildPieSeriesPrametersTypes);
        }

        #endregion
        
        #region Method Call : (BuildPieSeries) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildPieSeries_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildPieSeriesPrametersTypes = null;
            object[] parametersOfBuildPieSeries = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildPieSeries, parametersOfBuildPieSeries, methodBuildPieSeriesPrametersTypes);

            // Assert
            parametersOfBuildPieSeries.ShouldBeNull();
            methodBuildPieSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildPieSeries) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildPieSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildPieSeriesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildPieSeries, Fixture, methodBuildPieSeriesPrametersTypes);

            // Assert
            methodBuildPieSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildPieSeries) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildPieSeries_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildPieSeries, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildScatterSeries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildScatterSeries_Method_Call_Internally(Type[] types)
        {
            var methodBuildScatterSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildScatterSeries, Fixture, methodBuildScatterSeriesPrametersTypes);
        }

        #endregion
        
        #region Method Call : (BuildScatterSeries) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildScatterSeries_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildScatterSeriesPrametersTypes = null;
            object[] parametersOfBuildScatterSeries = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildScatterSeries, parametersOfBuildScatterSeries, methodBuildScatterSeriesPrametersTypes);

            // Assert
            parametersOfBuildScatterSeries.ShouldBeNull();
            methodBuildScatterSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildScatterSeries) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildScatterSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildScatterSeriesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildScatterSeries, Fixture, methodBuildScatterSeriesPrametersTypes);

            // Assert
            methodBuildScatterSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildScatterSeries) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildScatterSeries_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildScatterSeries, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildScatterLineSeries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildScatterLineSeries_Method_Call_Internally(Type[] types)
        {
            var methodBuildScatterLineSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildScatterLineSeries, Fixture, methodBuildScatterLineSeriesPrametersTypes);
        }

        #endregion
        
        #region Method Call : (BuildScatterLineSeries) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildScatterLineSeries_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildScatterLineSeriesPrametersTypes = null;
            object[] parametersOfBuildScatterLineSeries = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildScatterLineSeries, parametersOfBuildScatterLineSeries, methodBuildScatterLineSeriesPrametersTypes);

            // Assert
            parametersOfBuildScatterLineSeries.ShouldBeNull();
            methodBuildScatterLineSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildScatterLineSeries) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildScatterLineSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildScatterLineSeriesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildScatterLineSeries, Fixture, methodBuildScatterLineSeriesPrametersTypes);

            // Assert
            methodBuildScatterLineSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildScatterLineSeries) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildScatterLineSeries_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildScatterLineSeries, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildBubbleSeries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildBubbleSeries_Method_Call_Internally(Type[] types)
        {
            var methodBuildBubbleSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildBubbleSeries, Fixture, methodBuildBubbleSeriesPrametersTypes);
        }

        #endregion
        
        #region Method Call : (BuildBubbleSeries) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildBubbleSeries_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildBubbleSeriesPrametersTypes = null;
            object[] parametersOfBuildBubbleSeries = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildBubbleSeries, parametersOfBuildBubbleSeries, methodBuildBubbleSeriesPrametersTypes);

            // Assert
            parametersOfBuildBubbleSeries.ShouldBeNull();
            methodBuildBubbleSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildBubbleSeries) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildBubbleSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildBubbleSeriesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildBubbleSeries, Fixture, methodBuildBubbleSeriesPrametersTypes);

            // Assert
            methodBuildBubbleSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildBubbleSeries) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildBubbleSeries_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildBubbleSeries, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildDonutSeries) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_BuildDonutSeries_Method_Call_Internally(Type[] types)
        {
            var methodBuildDonutSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildDonutSeries, Fixture, methodBuildDonutSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildDonutSeries) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildDonutSeries_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildDonutSeriesPrametersTypes = null;
            object[] parametersOfBuildDonutSeries = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodBuildDonutSeries, parametersOfBuildDonutSeries, methodBuildDonutSeriesPrametersTypes);

            // Assert
            parametersOfBuildDonutSeries.ShouldBeNull();
            methodBuildDonutSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildDonutSeries) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildDonutSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildDonutSeriesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodBuildDonutSeries, Fixture, methodBuildDonutSeriesPrametersTypes);

            // Assert
            methodBuildDonutSeriesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildDonutSeries) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_BuildDonutSeries_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildDonutSeries, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSeriesItems) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetSeriesItems_Method_Call_Internally(Type[] types)
        {
            var methodGetSeriesItemsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSeriesItems, Fixture, methodGetSeriesItemsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSeriesItems) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSeriesItems_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSeriesItemsPrametersTypes = null;
            object[] parametersOfGetSeriesItems = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetSeriesItems, parametersOfGetSeriesItems, methodGetSeriesItemsPrametersTypes);

            // Assert
            parametersOfGetSeriesItems.ShouldBeNull();
            methodGetSeriesItemsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSeriesItems) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSeriesItems_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSeriesItemsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSeriesItems, Fixture, methodGetSeriesItemsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSeriesItemsPrametersTypes.ShouldBeNull();
        }

        #endregion
        
        #region Method Call : (GetFilterQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetFilterQuery_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetFilterQuery, Fixture, methodGetFilterQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFilterQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var originalQuery = CreateType<XmlDocument>();
            var methodGetFilterQueryPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            object[] parametersOfGetFilterQuery = { list, originalQuery };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, string>(_reportingChartInstance, MethodGetFilterQuery, parametersOfGetFilterQuery, methodGetFilterQueryPrametersTypes);

            // Assert
            parametersOfGetFilterQuery.ShouldNotBeNull();
            parametersOfGetFilterQuery.Length.ShouldBe(2);
            methodGetFilterQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFilterQuery_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilterQueryPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetFilterQuery, Fixture, methodGetFilterQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilterQueryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFilterQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilterQueryPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetFilterQuery, Fixture, methodGetFilterQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilterQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFilterQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFilterQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFilterQuery, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_ThisChartIsTiedToAReportFilter_Method_Call_Internally(Type[] types)
        {
            var methodThisChartIsTiedToAReportFilterPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodThisChartIsTiedToAReportFilter, Fixture, methodThisChartIsTiedToAReportFilterPrametersTypes);
        }

        #endregion
        
        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ThisChartIsTiedToAReportFilter_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodThisChartIsTiedToAReportFilterPrametersTypes = null;
            object[] parametersOfThisChartIsTiedToAReportFilter = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodThisChartIsTiedToAReportFilter, methodThisChartIsTiedToAReportFilterPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, bool>(_reportingChartInstanceFixture, out exception1, parametersOfThisChartIsTiedToAReportFilter);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodThisChartIsTiedToAReportFilter, parametersOfThisChartIsTiedToAReportFilter, methodThisChartIsTiedToAReportFilterPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfThisChartIsTiedToAReportFilter.ShouldBeNull();
            methodThisChartIsTiedToAReportFilterPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ThisChartIsTiedToAReportFilter_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodThisChartIsTiedToAReportFilterPrametersTypes = null;
            object[] parametersOfThisChartIsTiedToAReportFilter = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodThisChartIsTiedToAReportFilter, parametersOfThisChartIsTiedToAReportFilter, methodThisChartIsTiedToAReportFilterPrametersTypes);

            // Assert
            parametersOfThisChartIsTiedToAReportFilter.ShouldBeNull();
            methodThisChartIsTiedToAReportFilterPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ThisChartIsTiedToAReportFilter_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodThisChartIsTiedToAReportFilterPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodThisChartIsTiedToAReportFilter, Fixture, methodThisChartIsTiedToAReportFilterPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodThisChartIsTiedToAReportFilterPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_Internally(Type[] types)
        {
            var methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodUpdateTheOriginalQueryToAlsoFilterTitles, Fixture, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var originalQuery = CreateType<XmlDocument>();
            var methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            object[] parametersOfUpdateTheOriginalQueryToAlsoFilterTitles = { list, originalQuery };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateTheOriginalQueryToAlsoFilterTitles, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, string>(_reportingChartInstanceFixture, out exception1, parametersOfUpdateTheOriginalQueryToAlsoFilterTitles);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, string>(_reportingChartInstance, MethodUpdateTheOriginalQueryToAlsoFilterTitles, parametersOfUpdateTheOriginalQueryToAlsoFilterTitles, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfUpdateTheOriginalQueryToAlsoFilterTitles.ShouldNotBeNull();
            parametersOfUpdateTheOriginalQueryToAlsoFilterTitles.Length.ShouldBe(2);
            methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var originalQuery = CreateType<XmlDocument>();
            var methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            object[] parametersOfUpdateTheOriginalQueryToAlsoFilterTitles = { list, originalQuery };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, string>(_reportingChartInstance, MethodUpdateTheOriginalQueryToAlsoFilterTitles, parametersOfUpdateTheOriginalQueryToAlsoFilterTitles, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes);

            // Assert
            parametersOfUpdateTheOriginalQueryToAlsoFilterTitles.ShouldNotBeNull();
            parametersOfUpdateTheOriginalQueryToAlsoFilterTitles.Length.ShouldBe(2);
            methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodUpdateTheOriginalQueryToAlsoFilterTitles, Fixture, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodUpdateTheOriginalQueryToAlsoFilterTitles, Fixture, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateTheOriginalQueryToAlsoFilterTitles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateTheOriginalQueryToAlsoFilterTitles, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataForBubbleSeries) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetDataForBubbleSeries_Method_Call_Internally(Type[] types)
        {
            var methodGetDataForBubbleSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetDataForBubbleSeries, Fixture, methodGetDataForBubbleSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDataForBubbleSeries) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetDataForBubbleSeries_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var series = CreateType<string>();
            var valueFld = CreateType<string>();
            var groupBy = CreateType<string>();
            var methodGetDataForBubbleSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfGetDataForBubbleSeries = { dtRaw, category, series, valueFld, groupBy };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetDataForBubbleSeries, parametersOfGetDataForBubbleSeries, methodGetDataForBubbleSeriesPrametersTypes);

            // Assert
            parametersOfGetDataForBubbleSeries.ShouldNotBeNull();
            parametersOfGetDataForBubbleSeries.Length.ShouldBe(5);
            methodGetDataForBubbleSeriesPrametersTypes.Length.ShouldBe(5);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetDataForBubbleSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetDataForBubbleSeries_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetDataForBubbleSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetDataForBubbleSeries, Fixture, methodGetDataForBubbleSeriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetDataForBubbleSeriesPrametersTypes.Length.ShouldBe(5);
        }

        #endregion

        #region Method Call : (GetDataForBubbleSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetDataForBubbleSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetDataForBubbleSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 5;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetDataForBubbleSeries, Fixture, methodGetDataForBubbleSeriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetDataForBubbleSeriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetDataForBubbleSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetDataForBubbleSeries_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetDataForBubbleSeries, 0);
            const int parametersCount = 5;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCountDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetCountDataForPieSeries_Method_Call_Internally(Type[] types)
        {
            var methodGetCountDataForPieSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForPieSeries, Fixture, methodGetCountDataForPieSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCountDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForPieSeries_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var methodGetCountDataForPieSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            object[] parametersOfGetCountDataForPieSeries = { dtRaw, category };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetCountDataForPieSeries, parametersOfGetCountDataForPieSeries, methodGetCountDataForPieSeriesPrametersTypes);

            // Assert
            parametersOfGetCountDataForPieSeries.ShouldNotBeNull();
            parametersOfGetCountDataForPieSeries.Length.ShouldBe(2);
            methodGetCountDataForPieSeriesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCountDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForPieSeries_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCountDataForPieSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForPieSeries, Fixture, methodGetCountDataForPieSeriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCountDataForPieSeriesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCountDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForPieSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCountDataForPieSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForPieSeries, Fixture, methodGetCountDataForPieSeriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCountDataForPieSeriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCountDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForPieSeries_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCountDataForPieSeries, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSumDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetSumDataForPieSeries_Method_Call_Internally(Type[] types)
        {
            var methodGetSumDataForPieSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSumDataForPieSeries, Fixture, methodGetSumDataForPieSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSumDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForPieSeries_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var series = CreateType<string>();
            var methodGetSumDataForPieSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            object[] parametersOfGetSumDataForPieSeries = { dtRaw, category, series };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetSumDataForPieSeries, parametersOfGetSumDataForPieSeries, methodGetSumDataForPieSeriesPrametersTypes);

            // Assert
            parametersOfGetSumDataForPieSeries.ShouldNotBeNull();
            parametersOfGetSumDataForPieSeries.Length.ShouldBe(3);
            methodGetSumDataForPieSeriesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSumDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForPieSeries_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSumDataForPieSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSumDataForPieSeries, Fixture, methodGetSumDataForPieSeriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSumDataForPieSeriesPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetSumDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForPieSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSumDataForPieSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSumDataForPieSeries, Fixture, methodGetSumDataForPieSeriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSumDataForPieSeriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSumDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForPieSeries_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSumDataForPieSeries, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvgDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetAvgDataForPieSeries_Method_Call_Internally(Type[] types)
        {
            var methodGetAvgDataForPieSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetAvgDataForPieSeries, Fixture, methodGetAvgDataForPieSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAvgDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForPieSeries_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var series = CreateType<string>();
            var methodGetAvgDataForPieSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            object[] parametersOfGetAvgDataForPieSeries = { dtRaw, category, series };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetAvgDataForPieSeries, parametersOfGetAvgDataForPieSeries, methodGetAvgDataForPieSeriesPrametersTypes);

            // Assert
            parametersOfGetAvgDataForPieSeries.ShouldNotBeNull();
            parametersOfGetAvgDataForPieSeries.Length.ShouldBe(3);
            methodGetAvgDataForPieSeriesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAvgDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForPieSeries_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAvgDataForPieSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetAvgDataForPieSeries, Fixture, methodGetAvgDataForPieSeriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAvgDataForPieSeriesPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetAvgDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForPieSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAvgDataForPieSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetAvgDataForPieSeries, Fixture, methodGetAvgDataForPieSeriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAvgDataForPieSeriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvgDataForPieSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForPieSeries_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAvgDataForPieSeries, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCountDataForSingleSeries) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetCountDataForSingleSeries_Method_Call_Internally(Type[] types)
        {
            var methodGetCountDataForSingleSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForSingleSeries, Fixture, methodGetCountDataForSingleSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCountDataForSingleSeries) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForSingleSeries_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var methodGetCountDataForSingleSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            object[] parametersOfGetCountDataForSingleSeries = { dtRaw, category };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetCountDataForSingleSeries, parametersOfGetCountDataForSingleSeries, methodGetCountDataForSingleSeriesPrametersTypes);

            // Assert
            parametersOfGetCountDataForSingleSeries.ShouldNotBeNull();
            parametersOfGetCountDataForSingleSeries.Length.ShouldBe(2);
            methodGetCountDataForSingleSeriesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCountDataForSingleSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForSingleSeries_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCountDataForSingleSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForSingleSeries, Fixture, methodGetCountDataForSingleSeriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCountDataForSingleSeriesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetCountDataForSingleSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForSingleSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCountDataForSingleSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForSingleSeries, Fixture, methodGetCountDataForSingleSeriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCountDataForSingleSeriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCountDataForSingleSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForSingleSeries_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCountDataForSingleSeries, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraph) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetCountDataForClusteredGraph_Method_Call_Internally(Type[] types)
        {
            var methodGetCountDataForClusteredGraphPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForClusteredGraph, Fixture, methodGetCountDataForClusteredGraphPrametersTypes);
        }

        #endregion
        
        #region Method Call : (GetCountDataForClusteredGraph) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraph_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var series = CreateType<string>();
            var methodGetCountDataForClusteredGraphPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            object[] parametersOfGetCountDataForClusteredGraph = { dtRaw, category, series };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetCountDataForClusteredGraph, parametersOfGetCountDataForClusteredGraph, methodGetCountDataForClusteredGraphPrametersTypes);

            // Assert
            parametersOfGetCountDataForClusteredGraph.ShouldNotBeNull();
            parametersOfGetCountDataForClusteredGraph.Length.ShouldBe(3);
            methodGetCountDataForClusteredGraphPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraph) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraph_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCountDataForClusteredGraphPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForClusteredGraph, Fixture, methodGetCountDataForClusteredGraphPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCountDataForClusteredGraphPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraph) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraph_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCountDataForClusteredGraphPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForClusteredGraph, Fixture, methodGetCountDataForClusteredGraphPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCountDataForClusteredGraphPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraph) (Return Type : Dictionary<string, List<SeriesItem>>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraph_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCountDataForClusteredGraph, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraph) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraph_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCountDataForClusteredGraph, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraphInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetCountDataForClusteredGraphInPercentage_Method_Call_Internally(Type[] types)
        {
            var methodGetCountDataForClusteredGraphInPercentagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForClusteredGraphInPercentage, Fixture, methodGetCountDataForClusteredGraphInPercentagePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraphInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraphInPercentage_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var series = CreateType<string>();
            var methodGetCountDataForClusteredGraphInPercentagePrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            object[] parametersOfGetCountDataForClusteredGraphInPercentage = { dtRaw, category, series };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCountDataForClusteredGraphInPercentage, methodGetCountDataForClusteredGraphInPercentagePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstanceFixture, out exception1, parametersOfGetCountDataForClusteredGraphInPercentage);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetCountDataForClusteredGraphInPercentage, parametersOfGetCountDataForClusteredGraphInPercentage, methodGetCountDataForClusteredGraphInPercentagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetCountDataForClusteredGraphInPercentage.ShouldNotBeNull();
            parametersOfGetCountDataForClusteredGraphInPercentage.Length.ShouldBe(3);
            methodGetCountDataForClusteredGraphInPercentagePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraphInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraphInPercentage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var series = CreateType<string>();
            var methodGetCountDataForClusteredGraphInPercentagePrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            object[] parametersOfGetCountDataForClusteredGraphInPercentage = { dtRaw, category, series };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetCountDataForClusteredGraphInPercentage, parametersOfGetCountDataForClusteredGraphInPercentage, methodGetCountDataForClusteredGraphInPercentagePrametersTypes);

            // Assert
            parametersOfGetCountDataForClusteredGraphInPercentage.ShouldNotBeNull();
            parametersOfGetCountDataForClusteredGraphInPercentage.Length.ShouldBe(3);
            methodGetCountDataForClusteredGraphInPercentagePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraphInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraphInPercentage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetCountDataForClusteredGraphInPercentagePrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForClusteredGraphInPercentage, Fixture, methodGetCountDataForClusteredGraphInPercentagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetCountDataForClusteredGraphInPercentagePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraphInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraphInPercentage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCountDataForClusteredGraphInPercentagePrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetCountDataForClusteredGraphInPercentage, Fixture, methodGetCountDataForClusteredGraphInPercentagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCountDataForClusteredGraphInPercentagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraphInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraphInPercentage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCountDataForClusteredGraphInPercentage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCountDataForClusteredGraphInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetCountDataForClusteredGraphInPercentage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCountDataForClusteredGraphInPercentage, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSumDataForMultiSeries) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetSumDataForMultiSeries_Method_Call_Internally(Type[] types)
        {
            var methodGetSumDataForMultiSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSumDataForMultiSeries, Fixture, methodGetSumDataForMultiSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSumDataForMultiSeries) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForMultiSeries_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var rawMultiSeries = CreateType<string>();
            var methodGetSumDataForMultiSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            object[] parametersOfGetSumDataForMultiSeries = { dtRaw, category, rawMultiSeries };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetSumDataForMultiSeries, parametersOfGetSumDataForMultiSeries, methodGetSumDataForMultiSeriesPrametersTypes);

            // Assert
            parametersOfGetSumDataForMultiSeries.ShouldNotBeNull();
            parametersOfGetSumDataForMultiSeries.Length.ShouldBe(3);
            methodGetSumDataForMultiSeriesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSumDataForMultiSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForMultiSeries_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSumDataForMultiSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSumDataForMultiSeries, Fixture, methodGetSumDataForMultiSeriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSumDataForMultiSeriesPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetSumDataForMultiSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForMultiSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSumDataForMultiSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSumDataForMultiSeries, Fixture, methodGetSumDataForMultiSeriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSumDataForMultiSeriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSumDataForMultiSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForMultiSeries_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSumDataForMultiSeries, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSumDataForMultiSeriesInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetSumDataForMultiSeriesInPercentage_Method_Call_Internally(Type[] types)
        {
            var methodGetSumDataForMultiSeriesInPercentagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSumDataForMultiSeriesInPercentage, Fixture, methodGetSumDataForMultiSeriesInPercentagePrametersTypes);
        }

        #endregion

        #region Method Call : (GetSumDataForMultiSeriesInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForMultiSeriesInPercentage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var rawMultiSeries = CreateType<string>();
            var methodGetSumDataForMultiSeriesInPercentagePrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            object[] parametersOfGetSumDataForMultiSeriesInPercentage = { dtRaw, category, rawMultiSeries };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetSumDataForMultiSeriesInPercentage, parametersOfGetSumDataForMultiSeriesInPercentage, methodGetSumDataForMultiSeriesInPercentagePrametersTypes);

            // Assert
            parametersOfGetSumDataForMultiSeriesInPercentage.ShouldNotBeNull();
            parametersOfGetSumDataForMultiSeriesInPercentage.Length.ShouldBe(3);
            methodGetSumDataForMultiSeriesInPercentagePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSumDataForMultiSeriesInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForMultiSeriesInPercentage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSumDataForMultiSeriesInPercentagePrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSumDataForMultiSeriesInPercentage, Fixture, methodGetSumDataForMultiSeriesInPercentagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSumDataForMultiSeriesInPercentagePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetSumDataForMultiSeriesInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForMultiSeriesInPercentage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSumDataForMultiSeriesInPercentagePrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSumDataForMultiSeriesInPercentage, Fixture, methodGetSumDataForMultiSeriesInPercentagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSumDataForMultiSeriesInPercentagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSumDataForMultiSeriesInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSumDataForMultiSeriesInPercentage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSumDataForMultiSeriesInPercentage, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvgDataForMultiSeries) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetAvgDataForMultiSeries_Method_Call_Internally(Type[] types)
        {
            var methodGetAvgDataForMultiSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetAvgDataForMultiSeries, Fixture, methodGetAvgDataForMultiSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetAvgDataForMultiSeries) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForMultiSeries_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var rawMultiSeries = CreateType<string>();
            var methodGetAvgDataForMultiSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            object[] parametersOfGetAvgDataForMultiSeries = { dtRaw, category, rawMultiSeries };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetAvgDataForMultiSeries, parametersOfGetAvgDataForMultiSeries, methodGetAvgDataForMultiSeriesPrametersTypes);

            // Assert
            parametersOfGetAvgDataForMultiSeries.ShouldNotBeNull();
            parametersOfGetAvgDataForMultiSeries.Length.ShouldBe(3);
            methodGetAvgDataForMultiSeriesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAvgDataForMultiSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForMultiSeries_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAvgDataForMultiSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetAvgDataForMultiSeries, Fixture, methodGetAvgDataForMultiSeriesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAvgDataForMultiSeriesPrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetAvgDataForMultiSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForMultiSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAvgDataForMultiSeriesPrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetAvgDataForMultiSeries, Fixture, methodGetAvgDataForMultiSeriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAvgDataForMultiSeriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvgDataForMultiSeries) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForMultiSeries_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAvgDataForMultiSeries, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvgDataForMultiSeriesInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetAvgDataForMultiSeriesInPercentage_Method_Call_Internally(Type[] types)
        {
            var methodGetAvgDataForMultiSeriesInPercentagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetAvgDataForMultiSeriesInPercentage, Fixture, methodGetAvgDataForMultiSeriesInPercentagePrametersTypes);
        }

        #endregion

        #region Method Call : (GetAvgDataForMultiSeriesInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForMultiSeriesInPercentage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dtRaw = CreateType<DataTable>();
            var category = CreateType<string>();
            var rawMultiSeries = CreateType<string>();
            var methodGetAvgDataForMultiSeriesInPercentagePrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            object[] parametersOfGetAvgDataForMultiSeriesInPercentage = { dtRaw, category, rawMultiSeries };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, List<SeriesItem>>>(_reportingChartInstance, MethodGetAvgDataForMultiSeriesInPercentage, parametersOfGetAvgDataForMultiSeriesInPercentage, methodGetAvgDataForMultiSeriesInPercentagePrametersTypes);

            // Assert
            parametersOfGetAvgDataForMultiSeriesInPercentage.ShouldNotBeNull();
            parametersOfGetAvgDataForMultiSeriesInPercentage.Length.ShouldBe(3);
            methodGetAvgDataForMultiSeriesInPercentagePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetAvgDataForMultiSeriesInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForMultiSeriesInPercentage_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetAvgDataForMultiSeriesInPercentagePrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetAvgDataForMultiSeriesInPercentage, Fixture, methodGetAvgDataForMultiSeriesInPercentagePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetAvgDataForMultiSeriesInPercentagePrametersTypes.Length.ShouldBe(3);
        }

        #endregion

        #region Method Call : (GetAvgDataForMultiSeriesInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForMultiSeriesInPercentage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetAvgDataForMultiSeriesInPercentagePrametersTypes = new Type[] { typeof(DataTable), typeof(string), typeof(string) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetAvgDataForMultiSeriesInPercentage, Fixture, methodGetAvgDataForMultiSeriesInPercentagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetAvgDataForMultiSeriesInPercentagePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetAvgDataForMultiSeriesInPercentage) (Return Type : Dictionary<string, List<SeriesItem>>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetAvgDataForMultiSeriesInPercentage_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetAvgDataForMultiSeriesInPercentage, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyColorToBaseSeriesForMulticolor) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_ApplyColorToBaseSeriesForMulticolor_Method_Call_Internally(Type[] types)
        {
            var methodApplyColorToBaseSeriesForMulticolorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodApplyColorToBaseSeriesForMulticolor, Fixture, methodApplyColorToBaseSeriesForMulticolorPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyColorToBaseSeriesForMulticolor) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ApplyColorToBaseSeriesForMulticolor_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sCol = CreateType<SeriesBase>();
            var colorIndex = CreateType<int>();
            var methodApplyColorToBaseSeriesForMulticolorPrametersTypes = new Type[] { typeof(SeriesBase), typeof(int) };
            object[] parametersOfApplyColorToBaseSeriesForMulticolor = { sCol, colorIndex };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodApplyColorToBaseSeriesForMulticolor, parametersOfApplyColorToBaseSeriesForMulticolor, methodApplyColorToBaseSeriesForMulticolorPrametersTypes);

            // Assert
            parametersOfApplyColorToBaseSeriesForMulticolor.ShouldNotBeNull();
            parametersOfApplyColorToBaseSeriesForMulticolor.Length.ShouldBe(2);
            methodApplyColorToBaseSeriesForMulticolorPrametersTypes.Length.ShouldBe(2);
            methodApplyColorToBaseSeriesForMulticolorPrametersTypes.Length.ShouldBe(parametersOfApplyColorToBaseSeriesForMulticolor.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyColorToBaseSeriesForMulticolor) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ApplyColorToBaseSeriesForMulticolor_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodApplyColorToBaseSeriesForMulticolor, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyColorToBaseSeriesForMulticolor) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ApplyColorToBaseSeriesForMulticolor_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodApplyColorToBaseSeriesForMulticolorPrametersTypes = new Type[] { typeof(SeriesBase), typeof(int) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodApplyColorToBaseSeriesForMulticolor, Fixture, methodApplyColorToBaseSeriesForMulticolorPrametersTypes);

            // Assert
            methodApplyColorToBaseSeriesForMulticolorPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyColorToBaseSeriesForMulticolor) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ApplyColorToBaseSeriesForMulticolor_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyColorToBaseSeriesForMulticolor, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyColorToBaseSeriesForSingleColor) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_ApplyColorToBaseSeriesForSingleColor_Method_Call_Internally(Type[] types)
        {
            var methodApplyColorToBaseSeriesForSingleColorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodApplyColorToBaseSeriesForSingleColor, Fixture, methodApplyColorToBaseSeriesForSingleColorPrametersTypes);
        }

        #endregion

        #region Method Call : (ApplyColorToBaseSeriesForSingleColor) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ApplyColorToBaseSeriesForSingleColor_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var series = CreateType<SeriesBase>();
            var methodApplyColorToBaseSeriesForSingleColorPrametersTypes = new Type[] { typeof(SeriesBase) };
            object[] parametersOfApplyColorToBaseSeriesForSingleColor = { series };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodApplyColorToBaseSeriesForSingleColor, parametersOfApplyColorToBaseSeriesForSingleColor, methodApplyColorToBaseSeriesForSingleColorPrametersTypes);

            // Assert
            parametersOfApplyColorToBaseSeriesForSingleColor.ShouldNotBeNull();
            parametersOfApplyColorToBaseSeriesForSingleColor.Length.ShouldBe(1);
            methodApplyColorToBaseSeriesForSingleColorPrametersTypes.Length.ShouldBe(1);
            methodApplyColorToBaseSeriesForSingleColorPrametersTypes.Length.ShouldBe(parametersOfApplyColorToBaseSeriesForSingleColor.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyColorToBaseSeriesForSingleColor) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ApplyColorToBaseSeriesForSingleColor_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodApplyColorToBaseSeriesForSingleColor, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ApplyColorToBaseSeriesForSingleColor) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ApplyColorToBaseSeriesForSingleColor_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodApplyColorToBaseSeriesForSingleColorPrametersTypes = new Type[] { typeof(SeriesBase) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodApplyColorToBaseSeriesForSingleColor, Fixture, methodApplyColorToBaseSeriesForSingleColorPrametersTypes);

            // Assert
            methodApplyColorToBaseSeriesForSingleColorPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ApplyColorToBaseSeriesForSingleColor) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ApplyColorToBaseSeriesForSingleColor_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodApplyColorToBaseSeriesForSingleColor, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSelectedListData) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetSelectedListData_Method_Call_Internally(Type[] types)
        {
            var methodGetSelectedListDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSelectedListData, Fixture, methodGetSelectedListDataPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSelectedListData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSelectedListData_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodGetSelectedListDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSelectedListData = { listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSelectedListData, methodGetSelectedListDataPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, DataTable>(_reportingChartInstanceFixture, out exception1, parametersOfGetSelectedListData);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, DataTable>(_reportingChartInstance, MethodGetSelectedListData, parametersOfGetSelectedListData, methodGetSelectedListDataPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSelectedListData.ShouldNotBeNull();
            parametersOfGetSelectedListData.Length.ShouldBe(1);
            methodGetSelectedListDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSelectedListData) (Return Type : DataTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSelectedListData_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodGetSelectedListDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSelectedListData = { listName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, DataTable>(_reportingChartInstance, MethodGetSelectedListData, parametersOfGetSelectedListData, methodGetSelectedListDataPrametersTypes);

            // Assert
            parametersOfGetSelectedListData.ShouldNotBeNull();
            parametersOfGetSelectedListData.Length.ShouldBe(1);
            methodGetSelectedListDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSelectedListData) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSelectedListData_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSelectedListDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSelectedListData, Fixture, methodGetSelectedListDataPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSelectedListDataPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSelectedListData) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSelectedListData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSelectedListDataPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSelectedListData, Fixture, methodGetSelectedListDataPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSelectedListDataPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSelectedListData) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSelectedListData_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSelectedListData, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSelectedListData) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSelectedListData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSelectedListData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetToolParts_Method_Call_Internally(Type[] types)
        {
            var methodGetToolPartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetToolParts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, ToolPart[]>(_reportingChartInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetToolParts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_RebuildControlTree_Method_Call_Internally(Type[] types)
        {
            var methodRebuildControlTreePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodRebuildControlTree, Fixture, methodRebuildControlTreePrametersTypes);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_RebuildControlTree_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRebuildControlTreePrametersTypes = null;
            object[] parametersOfRebuildControlTree = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodRebuildControlTree, parametersOfRebuildControlTree, methodRebuildControlTreePrametersTypes);

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
        public void AUT_ReportingChart_RebuildControlTree_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRebuildControlTreePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodRebuildControlTree, Fixture, methodRebuildControlTreePrametersTypes);

            // Assert
            methodRebuildControlTreePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_RebuildControlTree_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRebuildControlTree, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXFieldValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_SetXFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodSetXFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodSetXFieldValue, Fixture, methodSetXFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (SetXFieldValue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetXFieldValue_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xFld = CreateType<string>();
            var methodSetXFieldValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetXFieldValue = { xFld };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodSetXFieldValue, parametersOfSetXFieldValue, methodSetXFieldValuePrametersTypes);

            // Assert
            parametersOfSetXFieldValue.ShouldNotBeNull();
            parametersOfSetXFieldValue.Length.ShouldBe(1);
            methodSetXFieldValuePrametersTypes.Length.ShouldBe(1);
            methodSetXFieldValuePrametersTypes.Length.ShouldBe(parametersOfSetXFieldValue.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXFieldValue) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetXFieldValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetXFieldValue, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetXFieldValue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetXFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetXFieldValuePrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodSetXFieldValue, Fixture, methodSetXFieldValuePrametersTypes);

            // Assert
            methodSetXFieldValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXFieldValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetXFieldValue_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetXFieldValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXFieldLabel) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_SetXFieldLabel_Method_Call_Internally(Type[] types)
        {
            var methodSetXFieldLabelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodSetXFieldLabel, Fixture, methodSetXFieldLabelPrametersTypes);
        }

        #endregion

        #region Method Call : (SetXFieldLabel) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetXFieldLabel_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xFld = CreateType<string>();
            var methodSetXFieldLabelPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSetXFieldLabel = { xFld };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodSetXFieldLabel, parametersOfSetXFieldLabel, methodSetXFieldLabelPrametersTypes);

            // Assert
            parametersOfSetXFieldLabel.ShouldNotBeNull();
            parametersOfSetXFieldLabel.Length.ShouldBe(1);
            methodSetXFieldLabelPrametersTypes.Length.ShouldBe(1);
            methodSetXFieldLabelPrametersTypes.Length.ShouldBe(parametersOfSetXFieldLabel.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXFieldLabel) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetXFieldLabel_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetXFieldLabel, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetXFieldLabel) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetXFieldLabel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetXFieldLabelPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodSetXFieldLabel, Fixture, methodSetXFieldLabelPrametersTypes);

            // Assert
            methodSetXFieldLabelPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetXFieldLabel) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetXFieldLabel_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetXFieldLabel, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldsValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_SetYFieldsValues_Method_Call_Internally(Type[] types)
        {
            var methodSetYFieldsValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodSetYFieldsValues, Fixture, methodSetYFieldsValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetYFieldsValues) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetYFieldsValues_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var yFields = CreateType<string[]>();
            Action executeAction = null;

            // Act
            executeAction = () => _reportingChartInstance.SetYFieldsValues(yFields);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetYFieldsValues) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetYFieldsValues_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var yFields = CreateType<string[]>();
            var methodSetYFieldsValuesPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfSetYFieldsValues = { yFields };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetYFieldsValues, methodSetYFieldsValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingChartInstanceFixture, parametersOfSetYFieldsValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetYFieldsValues.ShouldNotBeNull();
            parametersOfSetYFieldsValues.Length.ShouldBe(1);
            methodSetYFieldsValuesPrametersTypes.Length.ShouldBe(1);
            methodSetYFieldsValuesPrametersTypes.Length.ShouldBe(parametersOfSetYFieldsValues.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldsValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetYFieldsValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var yFields = CreateType<string[]>();
            var methodSetYFieldsValuesPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfSetYFieldsValues = { yFields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodSetYFieldsValues, parametersOfSetYFieldsValues, methodSetYFieldsValuesPrametersTypes);

            // Assert
            parametersOfSetYFieldsValues.ShouldNotBeNull();
            parametersOfSetYFieldsValues.Length.ShouldBe(1);
            methodSetYFieldsValuesPrametersTypes.Length.ShouldBe(1);
            methodSetYFieldsValuesPrametersTypes.Length.ShouldBe(parametersOfSetYFieldsValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldsValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetYFieldsValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetYFieldsValues, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetYFieldsValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetYFieldsValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetYFieldsValuesPrametersTypes = new Type[] { typeof(string[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodSetYFieldsValues, Fixture, methodSetYFieldsValuesPrametersTypes);

            // Assert
            methodSetYFieldsValuesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldsValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetYFieldsValues_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetYFieldsValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldsLabels) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_SetYFieldsLabels_Method_Call_Internally(Type[] types)
        {
            var methodSetYFieldsLabelsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodSetYFieldsLabels, Fixture, methodSetYFieldsLabelsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetYFieldsLabels) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetYFieldsLabels_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var yFields = CreateType<string[]>();
            var methodSetYFieldsLabelsPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfSetYFieldsLabels = { yFields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingChartInstance, MethodSetYFieldsLabels, parametersOfSetYFieldsLabels, methodSetYFieldsLabelsPrametersTypes);

            // Assert
            parametersOfSetYFieldsLabels.ShouldNotBeNull();
            parametersOfSetYFieldsLabels.Length.ShouldBe(1);
            methodSetYFieldsLabelsPrametersTypes.Length.ShouldBe(1);
            methodSetYFieldsLabelsPrametersTypes.Length.ShouldBe(parametersOfSetYFieldsLabels.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldsLabels) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetYFieldsLabels_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetYFieldsLabels, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetYFieldsLabels) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetYFieldsLabels_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetYFieldsLabelsPrametersTypes = new Type[] { typeof(string[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodSetYFieldsLabels, Fixture, methodSetYFieldsLabelsPrametersTypes);

            // Assert
            methodSetYFieldsLabelsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFieldsLabels) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_SetYFieldsLabels_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetYFieldsLabels, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYFieldsValues) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetYFieldsValues_Method_Call_Internally(Type[] types)
        {
            var methodGetYFieldsValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetYFieldsValues, Fixture, methodGetYFieldsValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetYFieldsValues) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetYFieldsValues_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetYFieldsValuesPrametersTypes = null;
            object[] parametersOfGetYFieldsValues = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, string[]>(_reportingChartInstance, MethodGetYFieldsValues, parametersOfGetYFieldsValues, methodGetYFieldsValuesPrametersTypes);

            // Assert
            parametersOfGetYFieldsValues.ShouldBeNull();
            methodGetYFieldsValuesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYFieldsValues) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetYFieldsValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetYFieldsValuesPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetYFieldsValues, Fixture, methodGetYFieldsValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetYFieldsValuesPrametersTypes.ShouldBeNull();
        }

        #endregion
        
        #region Method Call : (GetYFieldsLabel) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetYFieldsLabel_Method_Call_Internally(Type[] types)
        {
            var methodGetYFieldsLabelPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetYFieldsLabel, Fixture, methodGetYFieldsLabelPrametersTypes);
        }

        #endregion

        #region Method Call : (GetYFieldsLabel) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetYFieldsLabel_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetYFieldsLabelPrametersTypes = null;
            object[] parametersOfGetYFieldsLabel = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, string>(_reportingChartInstance, MethodGetYFieldsLabel, parametersOfGetYFieldsLabel, methodGetYFieldsLabelPrametersTypes);

            // Assert
            parametersOfGetYFieldsLabel.ShouldBeNull();
            methodGetYFieldsLabelPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYFieldsLabel) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetYFieldsLabel_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetYFieldsLabelPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetYFieldsLabel, Fixture, methodGetYFieldsLabelPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetYFieldsLabelPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYFieldsLabel) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetYFieldsLabel_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetYFieldsLabel, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_IsBubbleChart_Method_Call_Internally(Type[] types)
        {
            var methodIsBubbleChartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_IsBubbleChart_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, bool>(_reportingChartInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        public void AUT_ReportingChart_IsBubbleChart_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, bool>(_reportingChartInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_IsBubbleChart_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

            // Assert
            parametersOfIsBubbleChart.ShouldBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_IsBubbleChart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFldDispNameFromIntName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetFldDispNameFromIntName_Method_Call_Internally(Type[] types)
        {
            var methodGetFldDispNameFromIntNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetFldDispNameFromIntName, Fixture, methodGetFldDispNameFromIntNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFldDispNameFromIntName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFldDispNameFromIntName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalName = CreateType<string>();
            var methodGetFldDispNameFromIntNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFldDispNameFromIntName = { internalName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, string>(_reportingChartInstance, MethodGetFldDispNameFromIntName, parametersOfGetFldDispNameFromIntName, methodGetFldDispNameFromIntNamePrametersTypes);

            // Assert
            parametersOfGetFldDispNameFromIntName.ShouldNotBeNull();
            parametersOfGetFldDispNameFromIntName.Length.ShouldBe(1);
            methodGetFldDispNameFromIntNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFldDispNameFromIntName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFldDispNameFromIntName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFldDispNameFromIntNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetFldDispNameFromIntName, Fixture, methodGetFldDispNameFromIntNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFldDispNameFromIntNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFldDispNameFromIntName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFldDispNameFromIntName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFldDispNameFromIntNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetFldDispNameFromIntName, Fixture, methodGetFldDispNameFromIntNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFldDispNameFromIntNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (GetFldDispNameFromIntName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFldDispNameFromIntName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFldDispNameFromIntName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFldsIntAndDispNameDictionary) (Return Type : Dictionary<string, string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetFldsIntAndDispNameDictionary_Method_Call_Internally(Type[] types)
        {
            var methodGetFldsIntAndDispNameDictionaryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetFldsIntAndDispNameDictionary, Fixture, methodGetFldsIntAndDispNameDictionaryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFldsIntAndDispNameDictionary) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFldsIntAndDispNameDictionary_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var methodGetFldsIntAndDispNameDictionaryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFldsIntAndDispNameDictionary = { sListName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFldsIntAndDispNameDictionary, methodGetFldsIntAndDispNameDictionaryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, Dictionary<string, string>>(_reportingChartInstanceFixture, out exception1, parametersOfGetFldsIntAndDispNameDictionary);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, string>>(_reportingChartInstance, MethodGetFldsIntAndDispNameDictionary, parametersOfGetFldsIntAndDispNameDictionary, methodGetFldsIntAndDispNameDictionaryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFldsIntAndDispNameDictionary.ShouldNotBeNull();
            parametersOfGetFldsIntAndDispNameDictionary.Length.ShouldBe(1);
            methodGetFldsIntAndDispNameDictionaryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFldsIntAndDispNameDictionary) (Return Type : Dictionary<string, string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFldsIntAndDispNameDictionary_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var methodGetFldsIntAndDispNameDictionaryPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetFldsIntAndDispNameDictionary = { sListName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, Dictionary<string, string>>(_reportingChartInstance, MethodGetFldsIntAndDispNameDictionary, parametersOfGetFldsIntAndDispNameDictionary, methodGetFldsIntAndDispNameDictionaryPrametersTypes);

            // Assert
            parametersOfGetFldsIntAndDispNameDictionary.ShouldNotBeNull();
            parametersOfGetFldsIntAndDispNameDictionary.Length.ShouldBe(1);
            methodGetFldsIntAndDispNameDictionaryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFldsIntAndDispNameDictionary) (Return Type : Dictionary<string, string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFldsIntAndDispNameDictionary_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFldsIntAndDispNameDictionaryPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetFldsIntAndDispNameDictionary, Fixture, methodGetFldsIntAndDispNameDictionaryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFldsIntAndDispNameDictionaryPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetFldsIntAndDispNameDictionary) (Return Type : Dictionary<string, string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFldsIntAndDispNameDictionary_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFldsIntAndDispNameDictionaryPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetFldsIntAndDispNameDictionary, Fixture, methodGetFldsIntAndDispNameDictionaryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFldsIntAndDispNameDictionaryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFldsIntAndDispNameDictionary) (Return Type : Dictionary<string, string>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFldsIntAndDispNameDictionary_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFldsIntAndDispNameDictionary, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFldsIntAndDispNameDictionary) (Return Type : Dictionary<string, string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetFldsIntAndDispNameDictionary_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFldsIntAndDispNameDictionary, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetListColumns_Method_Call_Internally(Type[] types)
        {
            var methodGetListColumnsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetListColumns_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListColumns = { listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetListColumns, methodGetListColumnsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, DataTable>(_reportingChartInstanceFixture, out exception1, parametersOfGetListColumns);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, DataTable>(_reportingChartInstance, MethodGetListColumns, parametersOfGetListColumns, methodGetListColumnsPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetListColumns_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var listName = CreateType<string>();
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetListColumns = { listName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, DataTable>(_reportingChartInstance, MethodGetListColumns, parametersOfGetListColumns, methodGetListColumnsPrametersTypes);

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
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetListColumns_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetListColumnsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetListColumns_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetListColumnsPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetListColumns, Fixture, methodGetListColumnsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetListColumnsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetListColumns_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetListColumns, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetListColumns) (Return Type : DataTable) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetListColumns_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (ColExistsInListReportingDB) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_ColExistsInListReportingDB_Method_Call_Internally(Type[] types)
        {
            var methodColExistsInListReportingDBPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodColExistsInListReportingDB, Fixture, methodColExistsInListReportingDBPrametersTypes);
        }

        #endregion

        #region Method Call : (ColExistsInListReportingDB) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ColExistsInListReportingDB_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var colName = CreateType<string>();
            var listName = CreateType<string>();
            var methodColExistsInListReportingDBPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfColExistsInListReportingDB = { colName, listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodColExistsInListReportingDB, methodColExistsInListReportingDBPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, bool>(_reportingChartInstanceFixture, out exception1, parametersOfColExistsInListReportingDB);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodColExistsInListReportingDB, parametersOfColExistsInListReportingDB, methodColExistsInListReportingDBPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfColExistsInListReportingDB.ShouldNotBeNull();
            parametersOfColExistsInListReportingDB.Length.ShouldBe(2);
            methodColExistsInListReportingDBPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ColExistsInListReportingDB) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ColExistsInListReportingDB_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var colName = CreateType<string>();
            var listName = CreateType<string>();
            var methodColExistsInListReportingDBPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfColExistsInListReportingDB = { colName, listName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodColExistsInListReportingDB, methodColExistsInListReportingDBPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, bool>(_reportingChartInstanceFixture, out exception1, parametersOfColExistsInListReportingDB);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodColExistsInListReportingDB, parametersOfColExistsInListReportingDB, methodColExistsInListReportingDBPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfColExistsInListReportingDB.ShouldNotBeNull();
            parametersOfColExistsInListReportingDB.Length.ShouldBe(2);
            methodColExistsInListReportingDBPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (ColExistsInListReportingDB) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ColExistsInListReportingDB_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var colName = CreateType<string>();
            var listName = CreateType<string>();
            var methodColExistsInListReportingDBPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfColExistsInListReportingDB = { colName, listName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodColExistsInListReportingDB, parametersOfColExistsInListReportingDB, methodColExistsInListReportingDBPrametersTypes);

            // Assert
            parametersOfColExistsInListReportingDB.ShouldNotBeNull();
            parametersOfColExistsInListReportingDB.Length.ShouldBe(2);
            methodColExistsInListReportingDBPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ColExistsInListReportingDB) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ColExistsInListReportingDB_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodColExistsInListReportingDBPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodColExistsInListReportingDB, Fixture, methodColExistsInListReportingDBPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodColExistsInListReportingDBPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ColExistsInListReportingDB) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ColExistsInListReportingDB_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodColExistsInListReportingDB, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ColExistsInListReportingDB) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_ColExistsInListReportingDB_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodColExistsInListReportingDB, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsLookupCol) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_IsLookupCol_Method_Call_Internally(Type[] types)
        {
            var methodIsLookupColPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodIsLookupCol, Fixture, methodIsLookupColPrametersTypes);
        }

        #endregion

        #region Method Call : (IsLookupCol) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_IsLookupCol_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var intName = CreateType<string>();
            var methodIsLookupColPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLookupCol = { intName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLookupCol, methodIsLookupColPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, bool>(_reportingChartInstanceFixture, out exception1, parametersOfIsLookupCol);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodIsLookupCol, parametersOfIsLookupCol, methodIsLookupColPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLookupCol.ShouldNotBeNull();
            parametersOfIsLookupCol.Length.ShouldBe(1);
            methodIsLookupColPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsLookupCol) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_IsLookupCol_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var intName = CreateType<string>();
            var methodIsLookupColPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLookupCol = { intName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLookupCol, methodIsLookupColPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, bool>(_reportingChartInstanceFixture, out exception1, parametersOfIsLookupCol);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodIsLookupCol, parametersOfIsLookupCol, methodIsLookupColPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLookupCol.ShouldNotBeNull();
            parametersOfIsLookupCol.Length.ShouldBe(1);
            methodIsLookupColPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (IsLookupCol) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_IsLookupCol_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intName = CreateType<string>();
            var methodIsLookupColPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfIsLookupCol = { intName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, bool>(_reportingChartInstance, MethodIsLookupCol, parametersOfIsLookupCol, methodIsLookupColPrametersTypes);

            // Assert
            parametersOfIsLookupCol.ShouldNotBeNull();
            parametersOfIsLookupCol.Length.ShouldBe(1);
            methodIsLookupColPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLookupCol) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_IsLookupCol_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodIsLookupColPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodIsLookupCol, Fixture, methodIsLookupColPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsLookupColPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsLookupCol) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_IsLookupCol_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsLookupCol, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLookupCol) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_IsLookupCol_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodIsLookupCol, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSQLColNameIfLookup) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingChart_GetSQLColNameIfLookup_Method_Call_Internally(Type[] types)
        {
            var methodGetSQLColNameIfLookupPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSQLColNameIfLookup, Fixture, methodGetSQLColNameIfLookupPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSQLColNameIfLookup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSQLColNameIfLookup_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var intName = CreateType<string>();
            var methodGetSQLColNameIfLookupPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSQLColNameIfLookup = { intName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSQLColNameIfLookup, methodGetSQLColNameIfLookupPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingChart, string>(_reportingChartInstanceFixture, out exception1, parametersOfGetSQLColNameIfLookup);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingChart, string>(_reportingChartInstance, MethodGetSQLColNameIfLookup, parametersOfGetSQLColNameIfLookup, methodGetSQLColNameIfLookupPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSQLColNameIfLookup.ShouldNotBeNull();
            parametersOfGetSQLColNameIfLookup.Length.ShouldBe(1);
            methodGetSQLColNameIfLookupPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSQLColNameIfLookup) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSQLColNameIfLookup_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var intName = CreateType<string>();
            var methodGetSQLColNameIfLookupPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetSQLColNameIfLookup = { intName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingChart, string>(_reportingChartInstance, MethodGetSQLColNameIfLookup, parametersOfGetSQLColNameIfLookup, methodGetSQLColNameIfLookupPrametersTypes);

            // Assert
            parametersOfGetSQLColNameIfLookup.ShouldNotBeNull();
            parametersOfGetSQLColNameIfLookup.Length.ShouldBe(1);
            methodGetSQLColNameIfLookupPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSQLColNameIfLookup) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSQLColNameIfLookup_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetSQLColNameIfLookupPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSQLColNameIfLookup, Fixture, methodGetSQLColNameIfLookupPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSQLColNameIfLookupPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetSQLColNameIfLookup) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSQLColNameIfLookup_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSQLColNameIfLookupPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingChartInstance, MethodGetSQLColNameIfLookup, Fixture, methodGetSQLColNameIfLookupPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSQLColNameIfLookupPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion
        
        #region Method Call : (GetSQLColNameIfLookup) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingChart_GetSQLColNameIfLookup_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSQLColNameIfLookup, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #endregion

        #endregion
    }
}