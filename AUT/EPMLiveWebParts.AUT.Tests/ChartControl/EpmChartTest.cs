using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Web;
using System.Xml;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.EpmCharting.DomainModel;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.EpmChart" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EpmChartTest : AbstractBaseSetupTypedTest<EpmChart>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EpmChart) Initializer

        private const string PropertyRequest = "Request";
        private const string PropertyPropChartTitleFontSize = "PropChartTitleFontSize";
        private const string PropertyPropChartXaxisLabelRotationAngle = "PropChartXaxisLabelRotationAngle";
        private const string PropertyPropChartXaxisLabelFontSize = "PropChartXaxisLabelFontSize";
        private const string PropertyPropChartZaxisLabelRotationAngle = "PropChartZaxisLabelRotationAngle";
        private const string PropertyPropChartSeriesDataPointLabelFontSize = "PropChartSeriesDataPointLabelFontSize";
        private const string PropertyPropChartShowSeriesNameAsLabel = "PropChartShowSeriesNameAsLabel";
        private const string PropertyPropChartShowSeriesValueAsLabel = "PropChartShowSeriesValueAsLabel";
        private const string PropertyPropChartSeriesNameLabelPosition = "PropChartSeriesNameLabelPosition";
        private const string PropertyPropChartSeriesValueLabelPosition = "PropChartSeriesValueLabelPosition";
        private const string PropertyPropChartLegendFontName = "PropChartLegendFontName";
        private const string PropertyPropChartLegendFontSize = "PropChartLegendFontSize";
        private const string PropertyPropChartShowFrame = "PropChartShowFrame";
        private const string PropertyPropChartFrameColor = "PropChartFrameColor";
        private const string PropertyPropChartFrameRoundCorners = "PropChartFrameRoundCorners";
        private const string PropertyBubbleChartUserSettings = "BubbleChartUserSettings";
        private const string MethodLoadChartDataUsingSPSiteDataQuery = "LoadChartDataUsingSPSiteDataQuery";
        private const string MethodGetSiteDataUsingSPSiteDataQuery = "GetSiteDataUsingSPSiteDataQuery";
        private const string MethodAppendLookupQueryIfApplicable = "AppendLookupQueryIfApplicable";
        private const string MethodIsLookupQuery = "IsLookupQuery";
        private const string MethodConvertEmptySiteQueryDataToNoValue = "ConvertEmptySiteQueryDataToNoValue";
        private const string MethodProcessSiteQueryData = "ProcessSiteQueryData";
        private const string MethodAddXAxisColumnToChartDataTableIfDoesntExist = "AddXAxisColumnToChartDataTableIfDoesntExist";
        private const string MethodAddZAxisRowToChartDataTable = "AddZAxisRowToChartDataTable";
        private const string MethodGetZaxisFieldValue = "GetZaxisFieldValue";
        private const string MethodGetXaxisFieldValue = "GetXaxisFieldValue";
        private const string MethodGetFilterQuery = "GetFilterQuery";
        private const string MethodUpdateTheOriginalQueryToAlsoFilterTitles = "UpdateTheOriginalQueryToAlsoFilterTitles";
        private const string MethodThisChartIsTiedToAReportFilter = "ThisChartIsTiedToAReportFilter";
        private const string MethodDataBindChart = "DataBindChart";
        private const string MethodTraceHeader = "TraceHeader";
        private const string MethodAddChartSeries = "AddChartSeries";
        private const string MethodBuildSeriesArrayForBubbleChart = "BuildSeriesArrayForBubbleChart";
        private const string MethodGetBubbleChartColumnMappings = "GetBubbleChartColumnMappings";
        private const string MethodBuildSeriesArray = "BuildSeriesArray";
        private const string MethodIsBubbleChart = "IsBubbleChart";
        private const string MethodGetCleanNumberValue = "GetCleanNumberValue";
        private const string MethodSeriesExistsInChartDataTable = "SeriesExistsInChartDataTable";
        private const string MethodAddNewRowToChartDataTable = "AddNewRowToChartDataTable";
        private const string MethodUpdateCellValue = "UpdateCellValue";
        private const string MethodGetFieldSchemaAttribValue = "GetFieldSchemaAttribValue";
        private const string FieldScriptTagHolder = "ScriptTagHolder";
        private const string FieldChartDataTable = "ChartDataTable";
        private const string FielddtSPSiteDataQueryData = "dtSPSiteDataQueryData";
        private const string FieldiChartLegendFontSize = "iChartLegendFontSize";
        private const string FieldiChartTitleFontSize = "iChartTitleFontSize";
        private const string Field_numberOfColumnsInChartDataTable = "_numberOfColumnsInChartDataTable";
        private const string Field_numberOfRowsInChartDataTable = "_numberOfRowsInChartDataTable";
        private const string FieldiXaxisLabelFontSize = "iXaxisLabelFontSize";
        private const string FieldiZaxisLabelFontSize = "iZaxisLabelFontSize";
        private const string FieldiZaxisLabelRotationAngle = "iZaxisLabelRotationAngle";
        private const string FieldlitNewWebPartScreen = "litNewWebPartScreen";
        private const string FieldoTopList = "oTopList";
        private const string FieldoTopQuery = "oTopQuery";
        private const string Fieldtoolparts = "toolparts";
        private const string FieldMAX_LOOKUPFILTER = "MAX_LOOKUPFILTER";
        private const string FieldreportFilterField = "reportFilterField";
        private const string FieldtitlesToFilterOn = "titlesToFilterOn";
        private const string Field_reportFilterGuid = "_reportFilterGuid";
        private const string FieldproviderEn = "providerEn";
        private Type _epmChartInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EpmChart _epmChartInstance;
        private EpmChart _epmChartInstanceFixture;

        #region General Initializer : Class (EpmChart) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EpmChart" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _epmChartInstanceType = typeof(EpmChart);
            _epmChartInstanceFixture = Create(true);
            _epmChartInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EpmChart)

        #region General Initializer : Class (EpmChart) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="EpmChart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodLoadChartDataUsingSPSiteDataQuery, 0)]
        [TestCase(MethodGetSiteDataUsingSPSiteDataQuery, 0)]
        [TestCase(MethodAppendLookupQueryIfApplicable, 0)]
        [TestCase(MethodIsLookupQuery, 0)]
        [TestCase(MethodConvertEmptySiteQueryDataToNoValue, 0)]
        [TestCase(MethodProcessSiteQueryData, 0)]
        [TestCase(MethodAddXAxisColumnToChartDataTableIfDoesntExist, 0)]
        [TestCase(MethodAddZAxisRowToChartDataTable, 0)]
        [TestCase(MethodGetZaxisFieldValue, 0)]
        [TestCase(MethodGetXaxisFieldValue, 0)]
        [TestCase(MethodGetFilterQuery, 0)]
        [TestCase(MethodUpdateTheOriginalQueryToAlsoFilterTitles, 0)]
        [TestCase(MethodThisChartIsTiedToAReportFilter, 0)]
        [TestCase(MethodDataBindChart, 0)]
        [TestCase(MethodTraceHeader, 0)]
        [TestCase(MethodAddChartSeries, 0)]
        [TestCase(MethodBuildSeriesArrayForBubbleChart, 0)]
        [TestCase(MethodGetBubbleChartColumnMappings, 0)]
        [TestCase(MethodBuildSeriesArray, 0)]
        [TestCase(MethodIsBubbleChart, 0)]
        [TestCase(MethodGetCleanNumberValue, 0)]
        [TestCase(MethodSeriesExistsInChartDataTable, 0)]
        [TestCase(MethodAddNewRowToChartDataTable, 0)]
        [TestCase(MethodUpdateCellValue, 0)]
        [TestCase(MethodGetFieldSchemaAttribValue, 0)]
        public void AUT_EpmChart_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_epmChartInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EpmChart) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EpmChart" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyRequest)]
        [TestCase(PropertyPropChartTitleFontSize)]
        [TestCase(PropertyPropChartXaxisLabelRotationAngle)]
        [TestCase(PropertyPropChartXaxisLabelFontSize)]
        [TestCase(PropertyPropChartZaxisLabelRotationAngle)]
        [TestCase(PropertyPropChartSeriesDataPointLabelFontSize)]
        [TestCase(PropertyPropChartShowSeriesNameAsLabel)]
        [TestCase(PropertyPropChartShowSeriesValueAsLabel)]
        [TestCase(PropertyPropChartSeriesNameLabelPosition)]
        [TestCase(PropertyPropChartSeriesValueLabelPosition)]
        [TestCase(PropertyPropChartLegendFontName)]
        [TestCase(PropertyPropChartLegendFontSize)]
        [TestCase(PropertyPropChartShowFrame)]
        [TestCase(PropertyPropChartFrameColor)]
        [TestCase(PropertyPropChartFrameRoundCorners)]
        [TestCase(PropertyBubbleChartUserSettings)]
        public void AUT_EpmChart_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_epmChartInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EpmChart) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EpmChart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldScriptTagHolder)]
        [TestCase(FieldChartDataTable)]
        [TestCase(FielddtSPSiteDataQueryData)]
        [TestCase(FieldiChartLegendFontSize)]
        [TestCase(FieldiChartTitleFontSize)]
        [TestCase(Field_numberOfColumnsInChartDataTable)]
        [TestCase(Field_numberOfRowsInChartDataTable)]
        [TestCase(FieldiXaxisLabelFontSize)]
        [TestCase(FieldiZaxisLabelFontSize)]
        [TestCase(FieldiZaxisLabelRotationAngle)]
        [TestCase(FieldlitNewWebPartScreen)]
        [TestCase(FieldoTopList)]
        [TestCase(FieldoTopQuery)]
        [TestCase(Fieldtoolparts)]
        [TestCase(FieldMAX_LOOKUPFILTER)]
        [TestCase(FieldreportFilterField)]
        [TestCase(FieldtitlesToFilterOn)]
        [TestCase(Field_reportFilterGuid)]
        [TestCase(FieldproviderEn)]
        public void AUT_EpmChart_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_epmChartInstanceFixture, 
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
        ///     Class (<see cref="EpmChart" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EpmChart_Is_Instance_Present_Test()
        {
            // Assert
            _epmChartInstanceType.ShouldNotBeNull();
            _epmChartInstance.ShouldNotBeNull();
            _epmChartInstanceFixture.ShouldNotBeNull();
            _epmChartInstance.ShouldBeAssignableTo<EpmChart>();
            _epmChartInstanceFixture.ShouldBeAssignableTo<EpmChart>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EpmChart) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EpmChart_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EpmChart instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _epmChartInstanceType.ShouldNotBeNull();
            _epmChartInstance.ShouldNotBeNull();
            _epmChartInstanceFixture.ShouldNotBeNull();
            _epmChartInstance.ShouldBeAssignableTo<EpmChart>();
            _epmChartInstanceFixture.ShouldBeAssignableTo<EpmChart>();
        }

        #endregion

        #region General Constructor : Class (EpmChart) instance created

        /// <summary>
        ///     Class (<see cref="EpmChart" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChart_Is_Created_Test()
        {
            // Assert
            _epmChartInstance.ShouldNotBeNull();
            _epmChartInstanceFixture.ShouldNotBeNull();
        }

        #endregion

        #region General Constructor : Class (EpmChart) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="EpmChart" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_EpmChart_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<EpmChart>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (EpmChart) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="EpmChart" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChart_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<EpmChart>(Fixture);
        }

        #endregion

        #region General Constructor : Class (EpmChart) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EpmChart" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChart_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfEpmChart = {  };
            Type [] methodEpmChartPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_epmChartInstanceType, methodEpmChartPrametersTypes, parametersOfEpmChart);
        }

        #endregion

        #region General Constructor : Class (EpmChart) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EpmChart" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChart_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodEpmChartPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_epmChartInstanceType, Fixture, methodEpmChartPrametersTypes);
        }

        #endregion

        #region General Constructor : Class (EpmChart) constructors with parameter (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EpmChart" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChart_Constructors_Overloading_Of_1_Explore_Verify_Test()
        {
            // Arrange
            var request = CreateType<HttpRequest>();
            object[] parametersOfEpmChart = { request };
            var methodEpmChartPrametersTypes = new Type[] { typeof(HttpRequest) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_epmChartInstanceType, methodEpmChartPrametersTypes, parametersOfEpmChart);
        }

        #endregion

        #region General Constructor : Class (EpmChart) constructors with dynamic parameters (Overloading_Of_1_) coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="EpmChart" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_EpmChart_Constructors_Overloading_Of_1_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodEpmChartPrametersTypes = new Type[] { typeof(HttpRequest) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_epmChartInstanceType, Fixture, methodEpmChartPrametersTypes);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EpmChart) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(HttpRequest) , PropertyRequest)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartTitleFontSize)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartXaxisLabelRotationAngle)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartXaxisLabelFontSize)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartZaxisLabelRotationAngle)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartSeriesDataPointLabelFontSize)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowSeriesNameAsLabel)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowSeriesValueAsLabel)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartSeriesNameLabelPosition)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartSeriesValueLabelPosition)]
        [TestCaseGeneric(typeof(string) , PropertyPropChartLegendFontName)]
        [TestCaseGeneric(typeof(int) , PropertyPropChartLegendFontSize)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartShowFrame)]
        [TestCaseGeneric(typeof(Color) , PropertyPropChartFrameColor)]
        [TestCaseGeneric(typeof(bool) , PropertyPropChartFrameRoundCorners)]
        [TestCaseGeneric(typeof(EpmChartUserSettings) , PropertyBubbleChartUserSettings)]
        public void AUT_EpmChart_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EpmChart, T>(_epmChartInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChart) => Property (BubbleChartUserSettings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_BubbleChartUserSettings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyBubbleChartUserSettings);
            Action currentAction = () => propertyInfo.SetValue(_epmChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChart) => Property (BubbleChartUserSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_BubbleChartUserSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyBubbleChartUserSettings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartFrameColor) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_PropChartFrameColor_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyPropChartFrameColor);
            Action currentAction = () => propertyInfo.SetValue(_epmChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartFrameColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartFrameColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartFrameRoundCorners) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartFrameRoundCorners_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartLegendFontName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartLegendFontName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartLegendFontSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartLegendFontSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartSeriesDataPointLabelFontSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartSeriesDataPointLabelFontSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartSeriesNameLabelPosition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartSeriesNameLabelPosition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartSeriesValueLabelPosition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartSeriesValueLabelPosition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartShowFrame) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartShowFrame_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartShowSeriesNameAsLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartShowSeriesNameAsLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartShowSeriesValueAsLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartShowSeriesValueAsLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartTitleFontSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartTitleFontSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartXaxisLabelFontSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartXaxisLabelFontSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartXaxisLabelRotationAngle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartXaxisLabelRotationAngle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (PropChartZaxisLabelRotationAngle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_PropChartZaxisLabelRotationAngle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EpmChart) => Property (Request) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Request_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyRequest);
            Action currentAction = () => propertyInfo.SetValue(_epmChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EpmChart) => Property (Request) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_EpmChart_Public_Class_Request_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyRequest);

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

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="EpmChart" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetFieldSchemaAttribValue)]
        public void AUT_EpmChart_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_epmChartInstanceFixture,
                                                                              _epmChartInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="EpmChart" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodLoadChartDataUsingSPSiteDataQuery)]
        [TestCase(MethodGetSiteDataUsingSPSiteDataQuery)]
        [TestCase(MethodAppendLookupQueryIfApplicable)]
        [TestCase(MethodIsLookupQuery)]
        [TestCase(MethodConvertEmptySiteQueryDataToNoValue)]
        [TestCase(MethodProcessSiteQueryData)]
        [TestCase(MethodAddXAxisColumnToChartDataTableIfDoesntExist)]
        [TestCase(MethodAddZAxisRowToChartDataTable)]
        [TestCase(MethodGetZaxisFieldValue)]
        [TestCase(MethodGetXaxisFieldValue)]
        [TestCase(MethodGetFilterQuery)]
        [TestCase(MethodUpdateTheOriginalQueryToAlsoFilterTitles)]
        [TestCase(MethodThisChartIsTiedToAReportFilter)]
        [TestCase(MethodDataBindChart)]
        [TestCase(MethodTraceHeader)]
        [TestCase(MethodAddChartSeries)]
        [TestCase(MethodBuildSeriesArrayForBubbleChart)]
        [TestCase(MethodGetBubbleChartColumnMappings)]
        [TestCase(MethodBuildSeriesArray)]
        [TestCase(MethodIsBubbleChart)]
        [TestCase(MethodGetCleanNumberValue)]
        [TestCase(MethodSeriesExistsInChartDataTable)]
        [TestCase(MethodAddNewRowToChartDataTable)]
        [TestCase(MethodUpdateCellValue)]
        public void AUT_EpmChart_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<EpmChart>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (LoadChartDataUsingSPSiteDataQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_LoadChartDataUsingSPSiteDataQuery_Method_Call_Internally(Type[] types)
        {
            var methodLoadChartDataUsingSPSiteDataQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodLoadChartDataUsingSPSiteDataQuery, Fixture, methodLoadChartDataUsingSPSiteDataQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadChartDataUsingSPSiteDataQuery) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_LoadChartDataUsingSPSiteDataQuery_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _epmChartInstance.LoadChartDataUsingSPSiteDataQuery();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (LoadChartDataUsingSPSiteDataQuery) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_LoadChartDataUsingSPSiteDataQuery_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadChartDataUsingSPSiteDataQueryPrametersTypes = null;
            object[] parametersOfLoadChartDataUsingSPSiteDataQuery = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadChartDataUsingSPSiteDataQuery, methodLoadChartDataUsingSPSiteDataQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfLoadChartDataUsingSPSiteDataQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadChartDataUsingSPSiteDataQuery.ShouldBeNull();
            methodLoadChartDataUsingSPSiteDataQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadChartDataUsingSPSiteDataQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_LoadChartDataUsingSPSiteDataQuery_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadChartDataUsingSPSiteDataQueryPrametersTypes = null;
            object[] parametersOfLoadChartDataUsingSPSiteDataQuery = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartInstance, MethodLoadChartDataUsingSPSiteDataQuery, parametersOfLoadChartDataUsingSPSiteDataQuery, methodLoadChartDataUsingSPSiteDataQueryPrametersTypes);

            // Assert
            parametersOfLoadChartDataUsingSPSiteDataQuery.ShouldBeNull();
            methodLoadChartDataUsingSPSiteDataQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadChartDataUsingSPSiteDataQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_LoadChartDataUsingSPSiteDataQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadChartDataUsingSPSiteDataQueryPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodLoadChartDataUsingSPSiteDataQuery, Fixture, methodLoadChartDataUsingSPSiteDataQueryPrametersTypes);

            // Assert
            methodLoadChartDataUsingSPSiteDataQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadChartDataUsingSPSiteDataQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_LoadChartDataUsingSPSiteDataQuery_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadChartDataUsingSPSiteDataQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteDataUsingSPSiteDataQuery) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_GetSiteDataUsingSPSiteDataQuery_Method_Call_Internally(Type[] types)
        {
            var methodGetSiteDataUsingSPSiteDataQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetSiteDataUsingSPSiteDataQuery, Fixture, methodGetSiteDataUsingSPSiteDataQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSiteDataUsingSPSiteDataQuery) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetSiteDataUsingSPSiteDataQuery_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetSiteDataUsingSPSiteDataQueryPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetSiteDataUsingSPSiteDataQuery = { web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetSiteDataUsingSPSiteDataQuery, methodGetSiteDataUsingSPSiteDataQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfGetSiteDataUsingSPSiteDataQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetSiteDataUsingSPSiteDataQuery.ShouldNotBeNull();
            parametersOfGetSiteDataUsingSPSiteDataQuery.Length.ShouldBe(1);
            methodGetSiteDataUsingSPSiteDataQueryPrametersTypes.Length.ShouldBe(1);
            methodGetSiteDataUsingSPSiteDataQueryPrametersTypes.Length.ShouldBe(parametersOfGetSiteDataUsingSPSiteDataQuery.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteDataUsingSPSiteDataQuery) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetSiteDataUsingSPSiteDataQuery_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetSiteDataUsingSPSiteDataQueryPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetSiteDataUsingSPSiteDataQuery = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartInstance, MethodGetSiteDataUsingSPSiteDataQuery, parametersOfGetSiteDataUsingSPSiteDataQuery, methodGetSiteDataUsingSPSiteDataQueryPrametersTypes);

            // Assert
            parametersOfGetSiteDataUsingSPSiteDataQuery.ShouldNotBeNull();
            parametersOfGetSiteDataUsingSPSiteDataQuery.Length.ShouldBe(1);
            methodGetSiteDataUsingSPSiteDataQueryPrametersTypes.Length.ShouldBe(1);
            methodGetSiteDataUsingSPSiteDataQueryPrametersTypes.Length.ShouldBe(parametersOfGetSiteDataUsingSPSiteDataQuery.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteDataUsingSPSiteDataQuery) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetSiteDataUsingSPSiteDataQuery_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetSiteDataUsingSPSiteDataQuery, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSiteDataUsingSPSiteDataQuery) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetSiteDataUsingSPSiteDataQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetSiteDataUsingSPSiteDataQueryPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetSiteDataUsingSPSiteDataQuery, Fixture, methodGetSiteDataUsingSPSiteDataQueryPrametersTypes);

            // Assert
            methodGetSiteDataUsingSPSiteDataQueryPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSiteDataUsingSPSiteDataQuery) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetSiteDataUsingSPSiteDataQuery_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSiteDataUsingSPSiteDataQuery, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendLookupQueryIfApplicable) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_AppendLookupQueryIfApplicable_Method_Call_Internally(Type[] types)
        {
            var methodAppendLookupQueryIfApplicablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodAppendLookupQueryIfApplicable, Fixture, methodAppendLookupQueryIfApplicablePrametersTypes);
        }

        #endregion

        #region Method Call : (AppendLookupQueryIfApplicable) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AppendLookupQueryIfApplicable_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var dq = CreateType<SPSiteDataQuery>();
            var methodAppendLookupQueryIfApplicablePrametersTypes = new Type[] { typeof(SPSiteDataQuery) };
            object[] parametersOfAppendLookupQueryIfApplicable = { dq };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAppendLookupQueryIfApplicable, methodAppendLookupQueryIfApplicablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfAppendLookupQueryIfApplicable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAppendLookupQueryIfApplicable.ShouldNotBeNull();
            parametersOfAppendLookupQueryIfApplicable.Length.ShouldBe(1);
            methodAppendLookupQueryIfApplicablePrametersTypes.Length.ShouldBe(1);
            methodAppendLookupQueryIfApplicablePrametersTypes.Length.ShouldBe(parametersOfAppendLookupQueryIfApplicable.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendLookupQueryIfApplicable) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AppendLookupQueryIfApplicable_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dq = CreateType<SPSiteDataQuery>();
            var methodAppendLookupQueryIfApplicablePrametersTypes = new Type[] { typeof(SPSiteDataQuery) };
            object[] parametersOfAppendLookupQueryIfApplicable = { dq };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartInstance, MethodAppendLookupQueryIfApplicable, parametersOfAppendLookupQueryIfApplicable, methodAppendLookupQueryIfApplicablePrametersTypes);

            // Assert
            parametersOfAppendLookupQueryIfApplicable.ShouldNotBeNull();
            parametersOfAppendLookupQueryIfApplicable.Length.ShouldBe(1);
            methodAppendLookupQueryIfApplicablePrametersTypes.Length.ShouldBe(1);
            methodAppendLookupQueryIfApplicablePrametersTypes.Length.ShouldBe(parametersOfAppendLookupQueryIfApplicable.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendLookupQueryIfApplicable) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AppendLookupQueryIfApplicable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAppendLookupQueryIfApplicable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AppendLookupQueryIfApplicable) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AppendLookupQueryIfApplicable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAppendLookupQueryIfApplicablePrametersTypes = new Type[] { typeof(SPSiteDataQuery) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodAppendLookupQueryIfApplicable, Fixture, methodAppendLookupQueryIfApplicablePrametersTypes);

            // Assert
            methodAppendLookupQueryIfApplicablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AppendLookupQueryIfApplicable) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AppendLookupQueryIfApplicable_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAppendLookupQueryIfApplicable, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLookupQuery) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_IsLookupQuery_Method_Call_Internally(Type[] types)
        {
            var methodIsLookupQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodIsLookupQuery, Fixture, methodIsLookupQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (IsLookupQuery) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsLookupQuery_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsLookupQueryPrametersTypes = null;
            object[] parametersOfIsLookupQuery = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLookupQuery, methodIsLookupQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, bool>(_epmChartInstanceFixture, out exception1, parametersOfIsLookupQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodIsLookupQuery, parametersOfIsLookupQuery, methodIsLookupQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLookupQuery.ShouldBeNull();
            methodIsLookupQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLookupQuery) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsLookupQuery_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsLookupQueryPrametersTypes = null;
            object[] parametersOfIsLookupQuery = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsLookupQuery, methodIsLookupQueryPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, bool>(_epmChartInstanceFixture, out exception1, parametersOfIsLookupQuery);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodIsLookupQuery, parametersOfIsLookupQuery, methodIsLookupQueryPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfIsLookupQuery.ShouldBeNull();
            methodIsLookupQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLookupQuery) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsLookupQuery_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodIsLookupQueryPrametersTypes = null;
            object[] parametersOfIsLookupQuery = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsLookupQuery, methodIsLookupQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfIsLookupQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfIsLookupQuery.ShouldBeNull();
            methodIsLookupQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLookupQuery) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsLookupQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsLookupQueryPrametersTypes = null;
            object[] parametersOfIsLookupQuery = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodIsLookupQuery, parametersOfIsLookupQuery, methodIsLookupQueryPrametersTypes);

            // Assert
            parametersOfIsLookupQuery.ShouldBeNull();
            methodIsLookupQueryPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsLookupQuery) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsLookupQuery_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodIsLookupQueryPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodIsLookupQuery, Fixture, methodIsLookupQueryPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsLookupQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLookupQuery) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsLookupQuery_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodIsLookupQueryPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodIsLookupQuery, Fixture, methodIsLookupQueryPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsLookupQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLookupQuery) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsLookupQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsLookupQueryPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodIsLookupQuery, Fixture, methodIsLookupQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsLookupQueryPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsLookupQuery) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsLookupQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsLookupQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (ConvertEmptySiteQueryDataToNoValue) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_ConvertEmptySiteQueryDataToNoValue_Method_Call_Internally(Type[] types)
        {
            var methodConvertEmptySiteQueryDataToNoValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodConvertEmptySiteQueryDataToNoValue, Fixture, methodConvertEmptySiteQueryDataToNoValuePrametersTypes);
        }

        #endregion

        #region Method Call : (ConvertEmptySiteQueryDataToNoValue) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ConvertEmptySiteQueryDataToNoValue_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodConvertEmptySiteQueryDataToNoValuePrametersTypes = null;
            object[] parametersOfConvertEmptySiteQueryDataToNoValue = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodConvertEmptySiteQueryDataToNoValue, methodConvertEmptySiteQueryDataToNoValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfConvertEmptySiteQueryDataToNoValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfConvertEmptySiteQueryDataToNoValue.ShouldBeNull();
            methodConvertEmptySiteQueryDataToNoValuePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertEmptySiteQueryDataToNoValue) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ConvertEmptySiteQueryDataToNoValue_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodConvertEmptySiteQueryDataToNoValuePrametersTypes = null;
            object[] parametersOfConvertEmptySiteQueryDataToNoValue = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartInstance, MethodConvertEmptySiteQueryDataToNoValue, parametersOfConvertEmptySiteQueryDataToNoValue, methodConvertEmptySiteQueryDataToNoValuePrametersTypes);

            // Assert
            parametersOfConvertEmptySiteQueryDataToNoValue.ShouldBeNull();
            methodConvertEmptySiteQueryDataToNoValuePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertEmptySiteQueryDataToNoValue) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ConvertEmptySiteQueryDataToNoValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodConvertEmptySiteQueryDataToNoValuePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodConvertEmptySiteQueryDataToNoValue, Fixture, methodConvertEmptySiteQueryDataToNoValuePrametersTypes);

            // Assert
            methodConvertEmptySiteQueryDataToNoValuePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ConvertEmptySiteQueryDataToNoValue) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ConvertEmptySiteQueryDataToNoValue_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodConvertEmptySiteQueryDataToNoValue, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessSiteQueryData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_ProcessSiteQueryData_Method_Call_Internally(Type[] types)
        {
            var methodProcessSiteQueryDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodProcessSiteQueryData, Fixture, methodProcessSiteQueryDataPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessSiteQueryData) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ProcessSiteQueryData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var methodProcessSiteQueryDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfProcessSiteQueryData = { sListName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodProcessSiteQueryData, methodProcessSiteQueryDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfProcessSiteQueryData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfProcessSiteQueryData.ShouldNotBeNull();
            parametersOfProcessSiteQueryData.Length.ShouldBe(1);
            methodProcessSiteQueryDataPrametersTypes.Length.ShouldBe(1);
            methodProcessSiteQueryDataPrametersTypes.Length.ShouldBe(parametersOfProcessSiteQueryData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessSiteQueryData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ProcessSiteQueryData_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var methodProcessSiteQueryDataPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfProcessSiteQueryData = { sListName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartInstance, MethodProcessSiteQueryData, parametersOfProcessSiteQueryData, methodProcessSiteQueryDataPrametersTypes);

            // Assert
            parametersOfProcessSiteQueryData.ShouldNotBeNull();
            parametersOfProcessSiteQueryData.Length.ShouldBe(1);
            methodProcessSiteQueryDataPrametersTypes.Length.ShouldBe(1);
            methodProcessSiteQueryDataPrametersTypes.Length.ShouldBe(parametersOfProcessSiteQueryData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessSiteQueryData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ProcessSiteQueryData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodProcessSiteQueryData, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (ProcessSiteQueryData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ProcessSiteQueryData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodProcessSiteQueryDataPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodProcessSiteQueryData, Fixture, methodProcessSiteQueryDataPrametersTypes);

            // Assert
            methodProcessSiteQueryDataPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ProcessSiteQueryData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ProcessSiteQueryData_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodProcessSiteQueryData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddXAxisColumnToChartDataTableIfDoesntExist) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_AddXAxisColumnToChartDataTableIfDoesntExist_Method_Call_Internally(Type[] types)
        {
            var methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodAddXAxisColumnToChartDataTableIfDoesntExist, Fixture, methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes);
        }

        #endregion

        #region Method Call : (AddXAxisColumnToChartDataTableIfDoesntExist) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddXAxisColumnToChartDataTableIfDoesntExist_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var xAxisFieldValue = CreateType<string>();
            var methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddXAxisColumnToChartDataTableIfDoesntExist = { xAxisFieldValue };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddXAxisColumnToChartDataTableIfDoesntExist, methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfAddXAxisColumnToChartDataTableIfDoesntExist);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddXAxisColumnToChartDataTableIfDoesntExist.ShouldNotBeNull();
            parametersOfAddXAxisColumnToChartDataTableIfDoesntExist.Length.ShouldBe(1);
            methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes.Length.ShouldBe(1);
            methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes.Length.ShouldBe(parametersOfAddXAxisColumnToChartDataTableIfDoesntExist.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddXAxisColumnToChartDataTableIfDoesntExist) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddXAxisColumnToChartDataTableIfDoesntExist_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xAxisFieldValue = CreateType<string>();
            var methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddXAxisColumnToChartDataTableIfDoesntExist = { xAxisFieldValue };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartInstance, MethodAddXAxisColumnToChartDataTableIfDoesntExist, parametersOfAddXAxisColumnToChartDataTableIfDoesntExist, methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes);

            // Assert
            parametersOfAddXAxisColumnToChartDataTableIfDoesntExist.ShouldNotBeNull();
            parametersOfAddXAxisColumnToChartDataTableIfDoesntExist.Length.ShouldBe(1);
            methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes.Length.ShouldBe(1);
            methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes.Length.ShouldBe(parametersOfAddXAxisColumnToChartDataTableIfDoesntExist.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddXAxisColumnToChartDataTableIfDoesntExist) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddXAxisColumnToChartDataTableIfDoesntExist_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddXAxisColumnToChartDataTableIfDoesntExist, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddXAxisColumnToChartDataTableIfDoesntExist) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddXAxisColumnToChartDataTableIfDoesntExist_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes = new Type[] { typeof(string) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodAddXAxisColumnToChartDataTableIfDoesntExist, Fixture, methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes);

            // Assert
            methodAddXAxisColumnToChartDataTableIfDoesntExistPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddXAxisColumnToChartDataTableIfDoesntExist) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddXAxisColumnToChartDataTableIfDoesntExist_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddXAxisColumnToChartDataTableIfDoesntExist, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddZAxisRowToChartDataTable) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_AddZAxisRowToChartDataTable_Method_Call_Internally(Type[] types)
        {
            var methodAddZAxisRowToChartDataTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodAddZAxisRowToChartDataTable, Fixture, methodAddZAxisRowToChartDataTablePrametersTypes);
        }

        #endregion

        #region Method Call : (AddZAxisRowToChartDataTable) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddZAxisRowToChartDataTable_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var xAxisColumnIndex = CreateType<int>();
            var xAxisField = CreateType<SPField>();
            var methodAddZAxisRowToChartDataTablePrametersTypes = new Type[] { typeof(int), typeof(SPField) };
            object[] parametersOfAddZAxisRowToChartDataTable = { xAxisColumnIndex, xAxisField };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddZAxisRowToChartDataTable, methodAddZAxisRowToChartDataTablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfAddZAxisRowToChartDataTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddZAxisRowToChartDataTable.ShouldNotBeNull();
            parametersOfAddZAxisRowToChartDataTable.Length.ShouldBe(2);
            methodAddZAxisRowToChartDataTablePrametersTypes.Length.ShouldBe(2);
            methodAddZAxisRowToChartDataTablePrametersTypes.Length.ShouldBe(parametersOfAddZAxisRowToChartDataTable.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddZAxisRowToChartDataTable) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddZAxisRowToChartDataTable_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var xAxisColumnIndex = CreateType<int>();
            var xAxisField = CreateType<SPField>();
            var methodAddZAxisRowToChartDataTablePrametersTypes = new Type[] { typeof(int), typeof(SPField) };
            object[] parametersOfAddZAxisRowToChartDataTable = { xAxisColumnIndex, xAxisField };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartInstance, MethodAddZAxisRowToChartDataTable, parametersOfAddZAxisRowToChartDataTable, methodAddZAxisRowToChartDataTablePrametersTypes);

            // Assert
            parametersOfAddZAxisRowToChartDataTable.ShouldNotBeNull();
            parametersOfAddZAxisRowToChartDataTable.Length.ShouldBe(2);
            methodAddZAxisRowToChartDataTablePrametersTypes.Length.ShouldBe(2);
            methodAddZAxisRowToChartDataTablePrametersTypes.Length.ShouldBe(parametersOfAddZAxisRowToChartDataTable.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddZAxisRowToChartDataTable) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddZAxisRowToChartDataTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddZAxisRowToChartDataTable, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddZAxisRowToChartDataTable) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddZAxisRowToChartDataTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddZAxisRowToChartDataTablePrametersTypes = new Type[] { typeof(int), typeof(SPField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodAddZAxisRowToChartDataTable, Fixture, methodAddZAxisRowToChartDataTablePrametersTypes);

            // Assert
            methodAddZAxisRowToChartDataTablePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddZAxisRowToChartDataTable) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddZAxisRowToChartDataTable_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddZAxisRowToChartDataTable, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZaxisFieldValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_GetZaxisFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodGetZaxisFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetZaxisFieldValue, Fixture, methodGetZaxisFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetZaxisFieldValue) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetZaxisFieldValue_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var zAxisField = CreateType<SPField>();
            var zAxisFieldIndex = CreateType<int>();
            var dr = CreateType<DataRow>();
            var methodGetZaxisFieldValuePrametersTypes = new Type[] { typeof(string), typeof(SPField), typeof(int), typeof(DataRow) };
            object[] parametersOfGetZaxisFieldValue = { sListName, zAxisField, zAxisFieldIndex, dr };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetZaxisFieldValue, methodGetZaxisFieldValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfGetZaxisFieldValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetZaxisFieldValue.ShouldNotBeNull();
            parametersOfGetZaxisFieldValue.Length.ShouldBe(4);
            methodGetZaxisFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZaxisFieldValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetZaxisFieldValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var zAxisField = CreateType<SPField>();
            var zAxisFieldIndex = CreateType<int>();
            var dr = CreateType<DataRow>();
            var methodGetZaxisFieldValuePrametersTypes = new Type[] { typeof(string), typeof(SPField), typeof(int), typeof(DataRow) };
            object[] parametersOfGetZaxisFieldValue = { sListName, zAxisField, zAxisFieldIndex, dr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, string>(_epmChartInstance, MethodGetZaxisFieldValue, parametersOfGetZaxisFieldValue, methodGetZaxisFieldValuePrametersTypes);

            // Assert
            parametersOfGetZaxisFieldValue.ShouldNotBeNull();
            parametersOfGetZaxisFieldValue.Length.ShouldBe(4);
            methodGetZaxisFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetZaxisFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetZaxisFieldValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetZaxisFieldValuePrametersTypes = new Type[] { typeof(string), typeof(SPField), typeof(int), typeof(DataRow) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetZaxisFieldValue, Fixture, methodGetZaxisFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetZaxisFieldValuePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetZaxisFieldValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetZaxisFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetZaxisFieldValuePrametersTypes = new Type[] { typeof(string), typeof(SPField), typeof(int), typeof(DataRow) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetZaxisFieldValue, Fixture, methodGetZaxisFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetZaxisFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetZaxisFieldValue) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetZaxisFieldValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetZaxisFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetZaxisFieldValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetZaxisFieldValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetZaxisFieldValue, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetXaxisFieldValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_GetXaxisFieldValue_Method_Call_Internally(Type[] types)
        {
            var methodGetXaxisFieldValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetXaxisFieldValue, Fixture, methodGetXaxisFieldValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetXaxisFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetXaxisFieldValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var xAxisField = CreateType<SPField>();
            var xAxisColumnIndex = CreateType<int>();
            var dr = CreateType<DataRow>();
            var methodGetXaxisFieldValuePrametersTypes = new Type[] { typeof(string), typeof(SPField), typeof(int), typeof(DataRow) };
            object[] parametersOfGetXaxisFieldValue = { sListName, xAxisField, xAxisColumnIndex, dr };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetXaxisFieldValue, methodGetXaxisFieldValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, string>(_epmChartInstanceFixture, out exception1, parametersOfGetXaxisFieldValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, string>(_epmChartInstance, MethodGetXaxisFieldValue, parametersOfGetXaxisFieldValue, methodGetXaxisFieldValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetXaxisFieldValue.ShouldNotBeNull();
            parametersOfGetXaxisFieldValue.Length.ShouldBe(4);
            methodGetXaxisFieldValuePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetXaxisFieldValue) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetXaxisFieldValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sListName = CreateType<string>();
            var xAxisField = CreateType<SPField>();
            var xAxisColumnIndex = CreateType<int>();
            var dr = CreateType<DataRow>();
            var methodGetXaxisFieldValuePrametersTypes = new Type[] { typeof(string), typeof(SPField), typeof(int), typeof(DataRow) };
            object[] parametersOfGetXaxisFieldValue = { sListName, xAxisField, xAxisColumnIndex, dr };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, string>(_epmChartInstance, MethodGetXaxisFieldValue, parametersOfGetXaxisFieldValue, methodGetXaxisFieldValuePrametersTypes);

            // Assert
            parametersOfGetXaxisFieldValue.ShouldNotBeNull();
            parametersOfGetXaxisFieldValue.Length.ShouldBe(4);
            methodGetXaxisFieldValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXaxisFieldValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetXaxisFieldValue_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetXaxisFieldValuePrametersTypes = new Type[] { typeof(string), typeof(SPField), typeof(int), typeof(DataRow) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetXaxisFieldValue, Fixture, methodGetXaxisFieldValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetXaxisFieldValuePrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetXaxisFieldValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetXaxisFieldValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetXaxisFieldValuePrametersTypes = new Type[] { typeof(string), typeof(SPField), typeof(int), typeof(DataRow) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetXaxisFieldValue, Fixture, methodGetXaxisFieldValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetXaxisFieldValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetXaxisFieldValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetXaxisFieldValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetXaxisFieldValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXaxisFieldValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetXaxisFieldValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetXaxisFieldValue, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_GetFilterQuery_Method_Call_Internally(Type[] types)
        {
            var methodGetFilterQueryPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetFilterQuery, Fixture, methodGetFilterQueryPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetFilterQuery_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var originalQuery = CreateType<XmlDocument>();
            var methodGetFilterQueryPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            object[] parametersOfGetFilterQuery = { list, originalQuery };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetFilterQuery, methodGetFilterQueryPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfGetFilterQuery);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetFilterQuery.ShouldNotBeNull();
            parametersOfGetFilterQuery.Length.ShouldBe(2);
            methodGetFilterQueryPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetFilterQuery_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var originalQuery = CreateType<XmlDocument>();
            var methodGetFilterQueryPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            object[] parametersOfGetFilterQuery = { list, originalQuery };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, string>(_epmChartInstance, MethodGetFilterQuery, parametersOfGetFilterQuery, methodGetFilterQueryPrametersTypes);

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
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetFilterQuery_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFilterQueryPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetFilterQuery, Fixture, methodGetFilterQueryPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFilterQueryPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetFilterQuery_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFilterQueryPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetFilterQuery, Fixture, methodGetFilterQueryPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFilterQueryPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetFilterQuery_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFilterQuery, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFilterQuery) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetFilterQuery_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_Internally(Type[] types)
        {
            var methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodUpdateTheOriginalQueryToAlsoFilterTitles, Fixture, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var originalQuery = CreateType<XmlDocument>();
            var methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            object[] parametersOfUpdateTheOriginalQueryToAlsoFilterTitles = { list, originalQuery };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodUpdateTheOriginalQueryToAlsoFilterTitles, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, string>(_epmChartInstanceFixture, out exception1, parametersOfUpdateTheOriginalQueryToAlsoFilterTitles);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, string>(_epmChartInstance, MethodUpdateTheOriginalQueryToAlsoFilterTitles, parametersOfUpdateTheOriginalQueryToAlsoFilterTitles, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes);

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
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var list = CreateType<SPList>();
            var originalQuery = CreateType<XmlDocument>();
            var methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            object[] parametersOfUpdateTheOriginalQueryToAlsoFilterTitles = { list, originalQuery };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, string>(_epmChartInstance, MethodUpdateTheOriginalQueryToAlsoFilterTitles, parametersOfUpdateTheOriginalQueryToAlsoFilterTitles, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes);

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
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodUpdateTheOriginalQueryToAlsoFilterTitles, Fixture, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes = new Type[] { typeof(SPList), typeof(XmlDocument) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodUpdateTheOriginalQueryToAlsoFilterTitles, Fixture, methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateTheOriginalQueryToAlsoFilterTitlesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateTheOriginalQueryToAlsoFilterTitles, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (UpdateTheOriginalQueryToAlsoFilterTitles) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateTheOriginalQueryToAlsoFilterTitles_Method_Call_Parameters_Count_Verification_Test()
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

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_ThisChartIsTiedToAReportFilter_Method_Call_Internally(Type[] types)
        {
            var methodThisChartIsTiedToAReportFilterPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodThisChartIsTiedToAReportFilter, Fixture, methodThisChartIsTiedToAReportFilterPrametersTypes);
        }

        #endregion

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ThisChartIsTiedToAReportFilter_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodThisChartIsTiedToAReportFilterPrametersTypes = null;
            object[] parametersOfThisChartIsTiedToAReportFilter = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodThisChartIsTiedToAReportFilter, methodThisChartIsTiedToAReportFilterPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, bool>(_epmChartInstanceFixture, out exception1, parametersOfThisChartIsTiedToAReportFilter);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodThisChartIsTiedToAReportFilter, parametersOfThisChartIsTiedToAReportFilter, methodThisChartIsTiedToAReportFilterPrametersTypes);

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

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ThisChartIsTiedToAReportFilter_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodThisChartIsTiedToAReportFilterPrametersTypes = null;
            object[] parametersOfThisChartIsTiedToAReportFilter = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodThisChartIsTiedToAReportFilter, methodThisChartIsTiedToAReportFilterPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, bool>(_epmChartInstanceFixture, out exception1, parametersOfThisChartIsTiedToAReportFilter);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodThisChartIsTiedToAReportFilter, parametersOfThisChartIsTiedToAReportFilter, methodThisChartIsTiedToAReportFilterPrametersTypes);

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

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ThisChartIsTiedToAReportFilter_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodThisChartIsTiedToAReportFilterPrametersTypes = null;
            object[] parametersOfThisChartIsTiedToAReportFilter = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodThisChartIsTiedToAReportFilter, methodThisChartIsTiedToAReportFilterPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfThisChartIsTiedToAReportFilter);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfThisChartIsTiedToAReportFilter.ShouldBeNull();
            methodThisChartIsTiedToAReportFilterPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ThisChartIsTiedToAReportFilter_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodThisChartIsTiedToAReportFilterPrametersTypes = null;
            object[] parametersOfThisChartIsTiedToAReportFilter = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodThisChartIsTiedToAReportFilter, parametersOfThisChartIsTiedToAReportFilter, methodThisChartIsTiedToAReportFilterPrametersTypes);

            // Assert
            parametersOfThisChartIsTiedToAReportFilter.ShouldBeNull();
            methodThisChartIsTiedToAReportFilterPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ThisChartIsTiedToAReportFilter_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodThisChartIsTiedToAReportFilterPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodThisChartIsTiedToAReportFilter, Fixture, methodThisChartIsTiedToAReportFilterPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodThisChartIsTiedToAReportFilterPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ThisChartIsTiedToAReportFilter_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodThisChartIsTiedToAReportFilterPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodThisChartIsTiedToAReportFilter, Fixture, methodThisChartIsTiedToAReportFilterPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodThisChartIsTiedToAReportFilterPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ThisChartIsTiedToAReportFilter_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodThisChartIsTiedToAReportFilterPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodThisChartIsTiedToAReportFilter, Fixture, methodThisChartIsTiedToAReportFilterPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodThisChartIsTiedToAReportFilterPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ThisChartIsTiedToAReportFilter) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_ThisChartIsTiedToAReportFilter_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodThisChartIsTiedToAReportFilter, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DataBindChart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_DataBindChart_Method_Call_Internally(Type[] types)
        {
            var methodDataBindChartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodDataBindChart, Fixture, methodDataBindChartPrametersTypes);
        }

        #endregion

        #region Method Call : (DataBindChart) (Return Type : void) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_DataBindChart_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _epmChartInstance.DataBindChart();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (DataBindChart) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_DataBindChart_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodDataBindChartPrametersTypes = null;
            object[] parametersOfDataBindChart = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodDataBindChart, methodDataBindChartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfDataBindChart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfDataBindChart.ShouldBeNull();
            methodDataBindChartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DataBindChart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_DataBindChart_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodDataBindChartPrametersTypes = null;
            object[] parametersOfDataBindChart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartInstance, MethodDataBindChart, parametersOfDataBindChart, methodDataBindChartPrametersTypes);

            // Assert
            parametersOfDataBindChart.ShouldBeNull();
            methodDataBindChartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DataBindChart) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_DataBindChart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodDataBindChartPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodDataBindChart, Fixture, methodDataBindChartPrametersTypes);

            // Assert
            methodDataBindChartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DataBindChart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_DataBindChart_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDataBindChart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TraceHeader) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_TraceHeader_Method_Call_Internally(Type[] types)
        {
            var methodTraceHeaderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodTraceHeader, Fixture, methodTraceHeaderPrametersTypes);
        }

        #endregion

        #region Method Call : (TraceHeader) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_TraceHeader_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodTraceHeaderPrametersTypes = null;
            object[] parametersOfTraceHeader = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodTraceHeader, methodTraceHeaderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfTraceHeader);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfTraceHeader.ShouldBeNull();
            methodTraceHeaderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TraceHeader) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_TraceHeader_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodTraceHeaderPrametersTypes = null;
            object[] parametersOfTraceHeader = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_epmChartInstance, MethodTraceHeader, parametersOfTraceHeader, methodTraceHeaderPrametersTypes);

            // Assert
            parametersOfTraceHeader.ShouldBeNull();
            methodTraceHeaderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TraceHeader) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_TraceHeader_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodTraceHeaderPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodTraceHeader, Fixture, methodTraceHeaderPrametersTypes);

            // Assert
            methodTraceHeaderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (TraceHeader) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_TraceHeader_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodTraceHeader, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddChartSeries) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_AddChartSeries_Method_Call_Internally(Type[] types)
        {
            var methodAddChartSeriesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodAddChartSeries, Fixture, methodAddChartSeriesPrametersTypes);
        }

        #endregion

        #region Method Call : (AddChartSeries) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddChartSeries_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sSeriesName = CreateType<string>();
            var sAggregType = CreateType<string>();
            var iNumPoints = CreateType<int>();
            var iMarkerSizePoints = CreateType<int>();
            var bHasIndependentYAxis = CreateType<bool>();
            var formatLabels = CreateType<bool>();
            var methodAddChartSeriesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int), typeof(bool), typeof(bool) };
            object[] parametersOfAddChartSeries = { sSeriesName, sAggregType, iNumPoints, iMarkerSizePoints, bHasIndependentYAxis, formatLabels };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddChartSeries, methodAddChartSeriesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, bool>(_epmChartInstanceFixture, out exception1, parametersOfAddChartSeries);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodAddChartSeries, parametersOfAddChartSeries, methodAddChartSeriesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddChartSeries.ShouldNotBeNull();
            parametersOfAddChartSeries.Length.ShouldBe(6);
            methodAddChartSeriesPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (AddChartSeries) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddChartSeries_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sSeriesName = CreateType<string>();
            var sAggregType = CreateType<string>();
            var iNumPoints = CreateType<int>();
            var iMarkerSizePoints = CreateType<int>();
            var bHasIndependentYAxis = CreateType<bool>();
            var formatLabels = CreateType<bool>();
            var methodAddChartSeriesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int), typeof(bool), typeof(bool) };
            object[] parametersOfAddChartSeries = { sSeriesName, sAggregType, iNumPoints, iMarkerSizePoints, bHasIndependentYAxis, formatLabels };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddChartSeries, methodAddChartSeriesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, bool>(_epmChartInstanceFixture, out exception1, parametersOfAddChartSeries);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodAddChartSeries, parametersOfAddChartSeries, methodAddChartSeriesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddChartSeries.ShouldNotBeNull();
            parametersOfAddChartSeries.Length.ShouldBe(6);
            methodAddChartSeriesPrametersTypes.Length.ShouldBe(6);
        }

        #endregion

        #region Method Call : (AddChartSeries) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddChartSeries_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sSeriesName = CreateType<string>();
            var sAggregType = CreateType<string>();
            var iNumPoints = CreateType<int>();
            var iMarkerSizePoints = CreateType<int>();
            var bHasIndependentYAxis = CreateType<bool>();
            var formatLabels = CreateType<bool>();
            var methodAddChartSeriesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int), typeof(bool), typeof(bool) };
            object[] parametersOfAddChartSeries = { sSeriesName, sAggregType, iNumPoints, iMarkerSizePoints, bHasIndependentYAxis, formatLabels };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddChartSeries, methodAddChartSeriesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfAddChartSeries);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddChartSeries.ShouldNotBeNull();
            parametersOfAddChartSeries.Length.ShouldBe(6);
            methodAddChartSeriesPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddChartSeries) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddChartSeries_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sSeriesName = CreateType<string>();
            var sAggregType = CreateType<string>();
            var iNumPoints = CreateType<int>();
            var iMarkerSizePoints = CreateType<int>();
            var bHasIndependentYAxis = CreateType<bool>();
            var formatLabels = CreateType<bool>();
            var methodAddChartSeriesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int), typeof(bool), typeof(bool) };
            object[] parametersOfAddChartSeries = { sSeriesName, sAggregType, iNumPoints, iMarkerSizePoints, bHasIndependentYAxis, formatLabels };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodAddChartSeries, parametersOfAddChartSeries, methodAddChartSeriesPrametersTypes);

            // Assert
            parametersOfAddChartSeries.ShouldNotBeNull();
            parametersOfAddChartSeries.Length.ShouldBe(6);
            methodAddChartSeriesPrametersTypes.Length.ShouldBe(6);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddChartSeries) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddChartSeries_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddChartSeriesPrametersTypes = new Type[] { typeof(string), typeof(string), typeof(int), typeof(int), typeof(bool), typeof(bool) };
            const int parametersCount = 6;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodAddChartSeries, Fixture, methodAddChartSeriesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddChartSeriesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddChartSeries) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddChartSeries_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddChartSeries, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AddChartSeries) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddChartSeries_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddChartSeries, 0);
            const int parametersCount = 6;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildSeriesArrayForBubbleChart) (Return Type : IEnumerable<VfChartSeries>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_BuildSeriesArrayForBubbleChart_Method_Call_Internally(Type[] types)
        {
            var methodBuildSeriesArrayForBubbleChartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodBuildSeriesArrayForBubbleChart, Fixture, methodBuildSeriesArrayForBubbleChartPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildSeriesArrayForBubbleChart) (Return Type : IEnumerable<VfChartSeries>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_BuildSeriesArrayForBubbleChart_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildSeriesArrayForBubbleChartPrametersTypes = null;
            object[] parametersOfBuildSeriesArrayForBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodBuildSeriesArrayForBubbleChart, methodBuildSeriesArrayForBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, IEnumerable<VfChartSeries>>(_epmChartInstanceFixture, out exception1, parametersOfBuildSeriesArrayForBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, IEnumerable<VfChartSeries>>(_epmChartInstance, MethodBuildSeriesArrayForBubbleChart, parametersOfBuildSeriesArrayForBubbleChart, methodBuildSeriesArrayForBubbleChartPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfBuildSeriesArrayForBubbleChart.ShouldBeNull();
            methodBuildSeriesArrayForBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildSeriesArrayForBubbleChart) (Return Type : IEnumerable<VfChartSeries>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_BuildSeriesArrayForBubbleChart_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodBuildSeriesArrayForBubbleChartPrametersTypes = null;
            object[] parametersOfBuildSeriesArrayForBubbleChart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, IEnumerable<VfChartSeries>>(_epmChartInstance, MethodBuildSeriesArrayForBubbleChart, parametersOfBuildSeriesArrayForBubbleChart, methodBuildSeriesArrayForBubbleChartPrametersTypes);

            // Assert
            parametersOfBuildSeriesArrayForBubbleChart.ShouldBeNull();
            methodBuildSeriesArrayForBubbleChartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildSeriesArrayForBubbleChart) (Return Type : IEnumerable<VfChartSeries>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_BuildSeriesArrayForBubbleChart_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodBuildSeriesArrayForBubbleChartPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodBuildSeriesArrayForBubbleChart, Fixture, methodBuildSeriesArrayForBubbleChartPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildSeriesArrayForBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildSeriesArrayForBubbleChart) (Return Type : IEnumerable<VfChartSeries>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_BuildSeriesArrayForBubbleChart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodBuildSeriesArrayForBubbleChartPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodBuildSeriesArrayForBubbleChart, Fixture, methodBuildSeriesArrayForBubbleChartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildSeriesArrayForBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (BuildSeriesArrayForBubbleChart) (Return Type : IEnumerable<VfChartSeries>) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_BuildSeriesArrayForBubbleChart_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodBuildSeriesArrayForBubbleChart, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBubbleChartColumnMappings) (Return Type : BubbleChartAxisToColumnMapping) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_GetBubbleChartColumnMappings_Method_Call_Internally(Type[] types)
        {
            var methodGetBubbleChartColumnMappingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetBubbleChartColumnMappings, Fixture, methodGetBubbleChartColumnMappingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBubbleChartColumnMappings) (Return Type : BubbleChartAxisToColumnMapping) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetBubbleChartColumnMappings_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetBubbleChartColumnMappingsPrametersTypes = null;
            object[] parametersOfGetBubbleChartColumnMappings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetBubbleChartColumnMappings, methodGetBubbleChartColumnMappingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfGetBubbleChartColumnMappings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetBubbleChartColumnMappings.ShouldBeNull();
            methodGetBubbleChartColumnMappingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBubbleChartColumnMappings) (Return Type : BubbleChartAxisToColumnMapping) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetBubbleChartColumnMappings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetBubbleChartColumnMappingsPrametersTypes = null;
            object[] parametersOfGetBubbleChartColumnMappings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, BubbleChartAxisToColumnMapping>(_epmChartInstance, MethodGetBubbleChartColumnMappings, parametersOfGetBubbleChartColumnMappings, methodGetBubbleChartColumnMappingsPrametersTypes);

            // Assert
            parametersOfGetBubbleChartColumnMappings.ShouldBeNull();
            methodGetBubbleChartColumnMappingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBubbleChartColumnMappings) (Return Type : BubbleChartAxisToColumnMapping) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetBubbleChartColumnMappings_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetBubbleChartColumnMappingsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetBubbleChartColumnMappings, Fixture, methodGetBubbleChartColumnMappingsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetBubbleChartColumnMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBubbleChartColumnMappings) (Return Type : BubbleChartAxisToColumnMapping) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetBubbleChartColumnMappings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetBubbleChartColumnMappingsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetBubbleChartColumnMappings, Fixture, methodGetBubbleChartColumnMappingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBubbleChartColumnMappingsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBubbleChartColumnMappings) (Return Type : BubbleChartAxisToColumnMapping) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetBubbleChartColumnMappings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBubbleChartColumnMappings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (BuildSeriesArray) (Return Type : VfChartSeries) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_BuildSeriesArray_Method_Call_Internally(Type[] types)
        {
            var methodBuildSeriesArrayPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodBuildSeriesArray, Fixture, methodBuildSeriesArrayPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildSeriesArray) (Return Type : VfChartSeries) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_BuildSeriesArray_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sSeriesName = CreateType<string>();
            var sAggregType = CreateType<string>();
            var methodBuildSeriesArrayPrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfBuildSeriesArray = { sSeriesName, sAggregType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, VfChartSeries>(_epmChartInstance, MethodBuildSeriesArray, parametersOfBuildSeriesArray, methodBuildSeriesArrayPrametersTypes);

            // Assert
            parametersOfBuildSeriesArray.ShouldNotBeNull();
            parametersOfBuildSeriesArray.Length.ShouldBe(2);
            methodBuildSeriesArrayPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (BuildSeriesArray) (Return Type : VfChartSeries) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_BuildSeriesArray_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodBuildSeriesArrayPrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodBuildSeriesArray, Fixture, methodBuildSeriesArrayPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodBuildSeriesArrayPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (BuildSeriesArray) (Return Type : VfChartSeries) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_BuildSeriesArray_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodBuildSeriesArrayPrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodBuildSeriesArray, Fixture, methodBuildSeriesArrayPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodBuildSeriesArrayPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (BuildSeriesArray) (Return Type : VfChartSeries) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_BuildSeriesArray_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodBuildSeriesArray, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_IsBubbleChart_Method_Call_Internally(Type[] types)
        {
            var methodIsBubbleChartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsBubbleChart_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, bool>(_epmChartInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        public void AUT_EpmChart_IsBubbleChart_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, bool>(_epmChartInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsBubbleChart_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfIsBubbleChart);

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
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsBubbleChart_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

            // Assert
            parametersOfIsBubbleChart.ShouldBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsBubbleChart_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsBubbleChart_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsBubbleChart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_IsBubbleChart_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCleanNumberValue) (Return Type : double) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_GetCleanNumberValue_Method_Call_Internally(Type[] types)
        {
            var methodGetCleanNumberValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetCleanNumberValue, Fixture, methodGetCleanNumberValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetCleanNumberValue) (Return Type : double) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetCleanNumberValue_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var toString = CreateType<string>();
            var methodGetCleanNumberValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanNumberValue = { toString };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCleanNumberValue, methodGetCleanNumberValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, double>(_epmChartInstanceFixture, out exception1, parametersOfGetCleanNumberValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, double>(_epmChartInstance, MethodGetCleanNumberValue, parametersOfGetCleanNumberValue, methodGetCleanNumberValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCleanNumberValue.ShouldNotBeNull();
            parametersOfGetCleanNumberValue.Length.ShouldBe(1);
            methodGetCleanNumberValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCleanNumberValue) (Return Type : double) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetCleanNumberValue_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var toString = CreateType<string>();
            var methodGetCleanNumberValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanNumberValue = { toString };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCleanNumberValue, methodGetCleanNumberValuePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, double>(_epmChartInstanceFixture, out exception1, parametersOfGetCleanNumberValue);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, double>(_epmChartInstance, MethodGetCleanNumberValue, parametersOfGetCleanNumberValue, methodGetCleanNumberValuePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCleanNumberValue.ShouldNotBeNull();
            parametersOfGetCleanNumberValue.Length.ShouldBe(1);
            methodGetCleanNumberValuePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetCleanNumberValue) (Return Type : double) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetCleanNumberValue_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var toString = CreateType<string>();
            var methodGetCleanNumberValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanNumberValue = { toString };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCleanNumberValue, methodGetCleanNumberValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfGetCleanNumberValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCleanNumberValue.ShouldNotBeNull();
            parametersOfGetCleanNumberValue.Length.ShouldBe(1);
            methodGetCleanNumberValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanNumberValue) (Return Type : double) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetCleanNumberValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var toString = CreateType<string>();
            var methodGetCleanNumberValuePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetCleanNumberValue = { toString };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, double>(_epmChartInstance, MethodGetCleanNumberValue, parametersOfGetCleanNumberValue, methodGetCleanNumberValuePrametersTypes);

            // Assert
            parametersOfGetCleanNumberValue.ShouldNotBeNull();
            parametersOfGetCleanNumberValue.Length.ShouldBe(1);
            methodGetCleanNumberValuePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCleanNumberValue) (Return Type : double) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetCleanNumberValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetCleanNumberValuePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodGetCleanNumberValue, Fixture, methodGetCleanNumberValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCleanNumberValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetCleanNumberValue) (Return Type : double) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetCleanNumberValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCleanNumberValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetCleanNumberValue) (Return Type : double) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetCleanNumberValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetCleanNumberValue, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SeriesExistsInChartDataTable) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_SeriesExistsInChartDataTable_Method_Call_Internally(Type[] types)
        {
            var methodSeriesExistsInChartDataTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodSeriesExistsInChartDataTable, Fixture, methodSeriesExistsInChartDataTablePrametersTypes);
        }

        #endregion

        #region Method Call : (SeriesExistsInChartDataTable) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_SeriesExistsInChartDataTable_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sName = CreateType<string>();
            var methodSeriesExistsInChartDataTablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSeriesExistsInChartDataTable = { sName };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSeriesExistsInChartDataTable, methodSeriesExistsInChartDataTablePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfSeriesExistsInChartDataTable);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSeriesExistsInChartDataTable.ShouldNotBeNull();
            parametersOfSeriesExistsInChartDataTable.Length.ShouldBe(1);
            methodSeriesExistsInChartDataTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SeriesExistsInChartDataTable) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_SeriesExistsInChartDataTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sName = CreateType<string>();
            var methodSeriesExistsInChartDataTablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfSeriesExistsInChartDataTable = { sName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodSeriesExistsInChartDataTable, parametersOfSeriesExistsInChartDataTable, methodSeriesExistsInChartDataTablePrametersTypes);

            // Assert
            parametersOfSeriesExistsInChartDataTable.ShouldNotBeNull();
            parametersOfSeriesExistsInChartDataTable.Length.ShouldBe(1);
            methodSeriesExistsInChartDataTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SeriesExistsInChartDataTable) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_SeriesExistsInChartDataTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSeriesExistsInChartDataTablePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodSeriesExistsInChartDataTable, Fixture, methodSeriesExistsInChartDataTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodSeriesExistsInChartDataTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SeriesExistsInChartDataTable) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_SeriesExistsInChartDataTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSeriesExistsInChartDataTable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddNewRowToChartDataTable) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_AddNewRowToChartDataTable_Method_Call_Internally(Type[] types)
        {
            var methodAddNewRowToChartDataTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodAddNewRowToChartDataTable, Fixture, methodAddNewRowToChartDataTablePrametersTypes);
        }

        #endregion

        #region Method Call : (AddNewRowToChartDataTable) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddNewRowToChartDataTable_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sColVal = CreateType<string>();
            var methodAddNewRowToChartDataTablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddNewRowToChartDataTable = { sColVal };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddNewRowToChartDataTable, methodAddNewRowToChartDataTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, bool>(_epmChartInstanceFixture, out exception1, parametersOfAddNewRowToChartDataTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodAddNewRowToChartDataTable, parametersOfAddNewRowToChartDataTable, methodAddNewRowToChartDataTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddNewRowToChartDataTable.ShouldNotBeNull();
            parametersOfAddNewRowToChartDataTable.Length.ShouldBe(1);
            methodAddNewRowToChartDataTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddNewRowToChartDataTable) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddNewRowToChartDataTable_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var sColVal = CreateType<string>();
            var methodAddNewRowToChartDataTablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddNewRowToChartDataTable = { sColVal };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodAddNewRowToChartDataTable, methodAddNewRowToChartDataTablePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<EpmChart, bool>(_epmChartInstanceFixture, out exception1, parametersOfAddNewRowToChartDataTable);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodAddNewRowToChartDataTable, parametersOfAddNewRowToChartDataTable, methodAddNewRowToChartDataTablePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfAddNewRowToChartDataTable.ShouldNotBeNull();
            parametersOfAddNewRowToChartDataTable.Length.ShouldBe(1);
            methodAddNewRowToChartDataTablePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (AddNewRowToChartDataTable) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddNewRowToChartDataTable_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sColVal = CreateType<string>();
            var methodAddNewRowToChartDataTablePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfAddNewRowToChartDataTable = { sColVal };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodAddNewRowToChartDataTable, parametersOfAddNewRowToChartDataTable, methodAddNewRowToChartDataTablePrametersTypes);

            // Assert
            parametersOfAddNewRowToChartDataTable.ShouldNotBeNull();
            parametersOfAddNewRowToChartDataTable.Length.ShouldBe(1);
            methodAddNewRowToChartDataTablePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddNewRowToChartDataTable) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddNewRowToChartDataTable_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddNewRowToChartDataTablePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodAddNewRowToChartDataTable, Fixture, methodAddNewRowToChartDataTablePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodAddNewRowToChartDataTablePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddNewRowToChartDataTable) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddNewRowToChartDataTable_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddNewRowToChartDataTable, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (AddNewRowToChartDataTable) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_AddNewRowToChartDataTable_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddNewRowToChartDataTable, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateCellValue) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_UpdateCellValue_Method_Call_Internally(Type[] types)
        {
            var methodUpdateCellValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodUpdateCellValue, Fixture, methodUpdateCellValuePrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateCellValue) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateCellValue_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var sRowName = CreateType<string>();
            var sColName = CreateType<string>();
            var sColVal = CreateType<string>();
            var sAggregType = CreateType<string>();
            var methodUpdateCellValuePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfUpdateCellValue = { sRowName, sColName, sColVal, sAggregType };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateCellValue, methodUpdateCellValuePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfUpdateCellValue);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateCellValue.ShouldNotBeNull();
            parametersOfUpdateCellValue.Length.ShouldBe(4);
            methodUpdateCellValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCellValue) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateCellValue_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sRowName = CreateType<string>();
            var sColName = CreateType<string>();
            var sColVal = CreateType<string>();
            var sAggregType = CreateType<string>();
            var methodUpdateCellValuePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            object[] parametersOfUpdateCellValue = { sRowName, sColName, sColVal, sAggregType };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<EpmChart, bool>(_epmChartInstance, MethodUpdateCellValue, parametersOfUpdateCellValue, methodUpdateCellValuePrametersTypes);

            // Assert
            parametersOfUpdateCellValue.ShouldNotBeNull();
            parametersOfUpdateCellValue.Length.ShouldBe(4);
            methodUpdateCellValuePrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateCellValue) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateCellValue_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateCellValuePrametersTypes = new Type[] { typeof(string), typeof(string), typeof(string), typeof(string) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_epmChartInstance, MethodUpdateCellValue, Fixture, methodUpdateCellValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUpdateCellValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateCellValue) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateCellValue_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateCellValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (UpdateCellValue) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_UpdateCellValue_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateCellValue, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_EpmChart_GetFieldSchemaAttribValue_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldSchemaAttribValuePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartInstanceFixture, _epmChartInstanceType, MethodGetFieldSchemaAttribValue, Fixture, methodGetFieldSchemaAttribValuePrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetFieldSchemaAttribValue_Static_Method_Call_With_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var sStringToSearch = CreateType<string>();
            var sAttribName = CreateType<string>();
            var methodGetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetFieldSchemaAttribValue = { sStringToSearch, sAttribName };
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldSchemaAttribValue, methodGetFieldSchemaAttribValuePrametersTypes, out exception);

            // Act
            var result1 = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartInstanceFixture, _epmChartInstanceType, MethodGetFieldSchemaAttribValue, Fixture, methodGetFieldSchemaAttribValuePrametersTypes);
            var result2 = ReflectionAnalyzer.GetResultOfStaticMethod<string>(_epmChartInstanceFixture, _epmChartInstanceType, MethodGetFieldSchemaAttribValue, parametersOfGetFieldSchemaAttribValue, methodGetFieldSchemaAttribValuePrametersTypes);
            Action currentAction = () => methodInfo.Invoke(_epmChartInstanceFixture, parametersOfGetFieldSchemaAttribValue);

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
        public void AUT_EpmChart_GetFieldSchemaAttribValue_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sStringToSearch = CreateType<string>();
            var sAttribName = CreateType<string>();
            var methodGetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            object[] parametersOfGetFieldSchemaAttribValue = { sStringToSearch, sAttribName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<string>(_epmChartInstanceFixture, _epmChartInstanceType, MethodGetFieldSchemaAttribValue, parametersOfGetFieldSchemaAttribValue, methodGetFieldSchemaAttribValuePrametersTypes);

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
        public void AUT_EpmChart_GetFieldSchemaAttribValue_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartInstanceFixture, _epmChartInstanceType, MethodGetFieldSchemaAttribValue, Fixture, methodGetFieldSchemaAttribValuePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetFieldSchemaAttribValue_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldSchemaAttribValuePrametersTypes = new Type[] { typeof(string), typeof(string) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_epmChartInstanceFixture, _epmChartInstanceType, MethodGetFieldSchemaAttribValue, Fixture, methodGetFieldSchemaAttribValuePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldSchemaAttribValuePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetFieldSchemaAttribValue_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldSchemaAttribValue, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_epmChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldSchemaAttribValue) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_EpmChart_GetFieldSchemaAttribValue_Static_Method_Call_Parameters_Count_Verification_Test()
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

        #endregion

        #endregion
    }
}