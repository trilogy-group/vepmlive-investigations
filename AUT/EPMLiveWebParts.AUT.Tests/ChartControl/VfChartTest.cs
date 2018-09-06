using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Web;
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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.VfChart" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class VfChartTest : AbstractBaseSetupTypedTest<VfChart>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (VfChart) Initializer

        private const string PropertyChartLookupFieldList = "ChartLookupFieldList";
        private const string PropertyChartLookupField = "ChartLookupField";
        private const string PropertySeries = "Series";
        private const string PropertyReportFilterWebPartId = "ReportFilterWebPartId";
        private const string PropertyPropTrace = "PropTrace";
        private const string PropertyPropChartTitle = "PropChartTitle";
        private const string PropertyPropChartMainStyle = "PropChartMainStyle";
        private const string PropertyPropChartMainStyleSafe = "PropChartMainStyleSafe";
        private const string PropertyPropChartHeight = "PropChartHeight";
        private const string PropertyPropChartWidth = "PropChartWidth";
        private const string PropertyPropChartWebPartId = "PropChartWebPartId";
        private const string PropertyChartUserSettings = "ChartUserSettings";
        private const string PropertyPropChartXaxisField = "PropChartXaxisField";
        private const string PropertyPropChartXaxisFieldRaw = "PropChartXaxisFieldRaw";
        private const string PropertyPropChartXaxisFieldLabel = "PropChartXaxisFieldLabel";
        private const string PropertyPropChartXaxisFieldLabelRaw = "PropChartXaxisFieldLabelRaw";
        private const string PropertyPropChartYaxisField = "PropChartYaxisField";
        private const string PropertyPropChartYaxisFieldRaw = "PropChartYaxisFieldRaw";
        private const string PropertyPropChartYaxisFieldLabel = "PropChartYaxisFieldLabel";
        private const string PropertyPropChartYaxisFieldLabelRaw = "PropChartYaxisFieldLabelRaw";
        private const string PropertyPropChartZaxisField = "PropChartZaxisField";
        private const string PropertyPropChartZaxisFieldRaw = "PropChartZaxisFieldRaw";
        private const string PropertyPropChartZaxisFieldLabel = "PropChartZaxisFieldLabel";
        private const string PropertyPropChartZaxisFieldLabelRaw = "PropChartZaxisFieldLabelRaw";
        private const string PropertyPropBubbleChartColorField = "PropBubbleChartColorField";
        private const string PropertyPropBubbleChartColorFieldRaw = "PropBubbleChartColorFieldRaw";
        private const string PropertyPropChartShowYaxisValuesAsPercentage = "PropChartShowYaxisValuesAsPercentage";
        private const string PropertyPropChartShowYaxisValuesAsCurrency = "PropChartShowYaxisValuesAsCurrency";
        private const string PropertyPropChartAggregationType = "PropChartAggregationType";
        private const string PropertyPropChartShowSeriesInZaxis = "PropChartShowSeriesInZaxis";
        private const string PropertyPropChartShowSeriesLabels = "PropChartShowSeriesLabels";
        private const string PropertyPropChartShowZeroValueData = "PropChartShowZeroValueData";
        private const string PropertyPropChartYaxisNumValues = "PropChartYaxisNumValues";
        private const string PropertyPropChartShowLegend = "PropChartShowLegend";
        private const string PropertyPropChartShowGridlines = "PropChartShowGridlines";
        private const string PropertyPropChartShowBubbleChartInputsInWebPart = "PropChartShowBubbleChartInputsInWebPart";
        private const string PropertyPropChartSelectedList = "PropChartSelectedList";
        private const string PropertyPropChartSelectedView = "PropChartSelectedView";
        private const string PropertyPropChartRollupLists = "PropChartRollupLists";
        private const string PropertyPropChartRollupSites = "PropChartRollupSites";
        private const string PropertyPropChartRollupData = "PropChartRollupData";
        private const string PropertyPropChartSelectedPaletteName = "PropChartSelectedPaletteName";
        private const string PropertyPropChartSelectedPaletteNameSafe = "PropChartSelectedPaletteNameSafe";
        private const string PropertyPropChartView3D = "PropChartView3D";
        private const string PropertyChartTypes = "ChartTypes";
        private const string PropertyPalettes = "Palettes";
        private const string MethodLoadChartUserSettings = "LoadChartUserSettings";
        private const string MethodChartUserSettingsAreValid = "ChartUserSettingsAreValid";
        private const string MethodSetYFields = "SetYFields";
        private const string MethodGetYFields = "GetYFields";
        private const string MethodGetXaml = "GetXaml";
        private const string MethodPointShouldBeDisplayed = "PointShouldBeDisplayed";
        private const string MethodGetYAxisTitle = "GetYAxisTitle";
        private const string MethodGetYFieldDisplayName = "GetYFieldDisplayName";
        private const string MethodSortChart = "SortChart";
        private const string MethodShouldShowLegend = "ShouldShowLegend";
        private const string MethodGetBubbleToolTipText = "GetBubbleToolTipText";
        private const string MethodIsBubbleChart = "IsBubbleChart";
        private const string MethodGetHtml = "GetHtml";
        private const string MethodGetWidth = "GetWidth";
        private const string MethodGetHeight = "GetHeight";
        private const string MethodGetQueryString = "GetQueryString";
        private const string MethodHandleException = "HandleException";
        private const string FieldSeparator = "Separator";
        private const string FieldChartsXapPath = "ChartsXapPath";
        private const string FieldVfDataPath = "VfDataPath";
        private const string FieldQTitle = "QTitle";
        private const string FieldQXfield = "QXfield";
        private const string FieldQXfieldLabel = "QXfieldLabel";
        private const string FieldQYfieldLabel = "QYfieldLabel";
        private const string FieldQZfieldLabel = "QZfieldLabel";
        private const string FieldQYfields = "QYfields";
        private const string FieldQZfield = "QZfield";
        private const string FieldQBubbleChartColorField = "QBubbleChartColorField";
        private const string FieldQAggrtype = "QAggrtype";
        private const string FieldQRolluplists = "QRolluplists";
        private const string FieldQRollupsites = "QRollupsites";
        private const string FieldQView = "QView";
        private const string FieldQList = "QList";
        private const string FieldQChartType = "QChartType";
        private const string FieldQView3D = "QView3D";
        private const string FieldQColorSet = "QColorSet";
        private const string FieldQHeight = "QHeight";
        private const string FieldQWidth = "QWidth";
        private const string FieldQLegend = "QLegend";
        private const string FieldQPercentage = "QPercentage";
        private const string FieldQCurrency = "QCurrency";
        private const string FieldQGridlines = "QGridlines";
        private const string FieldQLabels = "QLabels";
        private const string FieldQShowZeroValueData = "QShowZeroValueData";
        private const string FieldQShowBubbleChartInputs = "QShowBubbleChartInputs";
        private const string FieldQChartWebPartId = "QChartWebPartId";
        private const string FieldQLookupField = "QLookupField";
        private const string FieldQLookupFieldList = "QLookupFieldList";
        private const string FieldTraceOutput = "TraceOutput";
        private const string Field_series = "_series";
        private const string Field_chartUserSettings = "_chartUserSettings";
        private const string Field_propChartXaxisField = "_propChartXaxisField";
        private const string Field_propChartXaxisFieldLabel = "_propChartXaxisFieldLabel";
        private const string Field_propChartYaxisFieldLabel = "_propChartYaxisFieldLabel";
        private const string Field_propChartZaxisField = "_propChartZaxisField";
        private const string Field_propChartZaxisFieldLabel = "_propChartZaxisFieldLabel";
        private const string Field_propBubbleChartColorField = "_propBubbleChartColorField";
        private Type _vfChartInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private VfChart _vfChartInstance;
        private VfChart _vfChartInstanceFixture;

        #region General Initializer : Class (VfChart) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="VfChart" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _vfChartInstanceType = typeof(VfChart);
            _vfChartInstanceFixture = Create(true);
            _vfChartInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (VfChart)

        #region General Initializer : Class (VfChart) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="VfChart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodLoadChartUserSettings, 0)]
        [TestCase(MethodChartUserSettingsAreValid, 0)]
        [TestCase(MethodSetYFields, 0)]
        [TestCase(MethodGetYFields, 0)]
        [TestCase(MethodGetXaml, 0)]
        [TestCase(MethodPointShouldBeDisplayed, 0)]
        [TestCase(MethodGetYAxisTitle, 0)]
        [TestCase(MethodGetYFieldDisplayName, 0)]
        [TestCase(MethodSortChart, 0)]
        [TestCase(MethodShouldShowLegend, 0)]
        [TestCase(MethodGetBubbleToolTipText, 0)]
        [TestCase(MethodIsBubbleChart, 0)]
        [TestCase(MethodGetHtml, 0)]
        [TestCase(MethodGetWidth, 0)]
        [TestCase(MethodGetHeight, 0)]
        [TestCase(MethodGetQueryString, 0)]
        [TestCase(MethodHandleException, 0)]
        public void AUT_VfChart_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_vfChartInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (VfChart) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="VfChart" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyChartLookupFieldList)]
        [TestCase(PropertyChartLookupField)]
        [TestCase(PropertySeries)]
        [TestCase(PropertyReportFilterWebPartId)]
        [TestCase(PropertyPropTrace)]
        [TestCase(PropertyPropChartTitle)]
        [TestCase(PropertyPropChartMainStyle)]
        [TestCase(PropertyPropChartMainStyleSafe)]
        [TestCase(PropertyPropChartHeight)]
        [TestCase(PropertyPropChartWidth)]
        [TestCase(PropertyPropChartWebPartId)]
        [TestCase(PropertyChartUserSettings)]
        [TestCase(PropertyPropChartXaxisField)]
        [TestCase(PropertyPropChartXaxisFieldRaw)]
        [TestCase(PropertyPropChartXaxisFieldLabel)]
        [TestCase(PropertyPropChartXaxisFieldLabelRaw)]
        [TestCase(PropertyPropChartYaxisField)]
        [TestCase(PropertyPropChartYaxisFieldRaw)]
        [TestCase(PropertyPropChartYaxisFieldLabel)]
        [TestCase(PropertyPropChartYaxisFieldLabelRaw)]
        [TestCase(PropertyPropChartZaxisField)]
        [TestCase(PropertyPropChartZaxisFieldRaw)]
        [TestCase(PropertyPropChartZaxisFieldLabel)]
        [TestCase(PropertyPropChartZaxisFieldLabelRaw)]
        [TestCase(PropertyPropBubbleChartColorField)]
        [TestCase(PropertyPropBubbleChartColorFieldRaw)]
        [TestCase(PropertyPropChartShowYaxisValuesAsPercentage)]
        [TestCase(PropertyPropChartShowYaxisValuesAsCurrency)]
        [TestCase(PropertyPropChartAggregationType)]
        [TestCase(PropertyPropChartShowSeriesInZaxis)]
        [TestCase(PropertyPropChartShowSeriesLabels)]
        [TestCase(PropertyPropChartShowZeroValueData)]
        [TestCase(PropertyPropChartYaxisNumValues)]
        [TestCase(PropertyPropChartShowLegend)]
        [TestCase(PropertyPropChartShowGridlines)]
        [TestCase(PropertyPropChartShowBubbleChartInputsInWebPart)]
        [TestCase(PropertyPropChartSelectedList)]
        [TestCase(PropertyPropChartSelectedView)]
        [TestCase(PropertyPropChartRollupLists)]
        [TestCase(PropertyPropChartRollupSites)]
        [TestCase(PropertyPropChartRollupData)]
        [TestCase(PropertyPropChartSelectedPaletteName)]
        [TestCase(PropertyPropChartSelectedPaletteNameSafe)]
        [TestCase(PropertyPropChartView3D)]
        [TestCase(PropertyChartTypes)]
        [TestCase(PropertyPalettes)]
        public void AUT_VfChart_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_vfChartInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (VfChart) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="VfChart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldSeparator)]
        [TestCase(FieldChartsXapPath)]
        [TestCase(FieldVfDataPath)]
        [TestCase(FieldQTitle)]
        [TestCase(FieldQXfield)]
        [TestCase(FieldQXfieldLabel)]
        [TestCase(FieldQYfieldLabel)]
        [TestCase(FieldQZfieldLabel)]
        [TestCase(FieldQYfields)]
        [TestCase(FieldQZfield)]
        [TestCase(FieldQBubbleChartColorField)]
        [TestCase(FieldQAggrtype)]
        [TestCase(FieldQRolluplists)]
        [TestCase(FieldQRollupsites)]
        [TestCase(FieldQView)]
        [TestCase(FieldQList)]
        [TestCase(FieldQChartType)]
        [TestCase(FieldQView3D)]
        [TestCase(FieldQColorSet)]
        [TestCase(FieldQHeight)]
        [TestCase(FieldQWidth)]
        [TestCase(FieldQLegend)]
        [TestCase(FieldQPercentage)]
        [TestCase(FieldQCurrency)]
        [TestCase(FieldQGridlines)]
        [TestCase(FieldQLabels)]
        [TestCase(FieldQShowZeroValueData)]
        [TestCase(FieldQShowBubbleChartInputs)]
        [TestCase(FieldQChartWebPartId)]
        [TestCase(FieldQLookupField)]
        [TestCase(FieldQLookupFieldList)]
        [TestCase(FieldTraceOutput)]
        [TestCase(Field_series)]
        [TestCase(Field_chartUserSettings)]
        [TestCase(Field_propChartXaxisField)]
        [TestCase(Field_propChartXaxisFieldLabel)]
        [TestCase(Field_propChartYaxisFieldLabel)]
        [TestCase(Field_propChartZaxisField)]
        [TestCase(Field_propChartZaxisFieldLabel)]
        [TestCase(Field_propBubbleChartColorField)]
        public void AUT_VfChart_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_vfChartInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (VfChart) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="VfChart" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        public void AUT_VfChart_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<VfChart>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (VfChart) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="VfChart" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_VfChart_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<VfChart>(Fixture);
        }

        #endregion

        #region General Constructor : Class (VfChart) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="VfChart" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_VfChart_Constructors_Explore_Verify_Test()
        {
            // Arrange
            var request = CreateType<HttpRequest>();
            object[] parametersOfVfChart = { request };
            var methodVfChartPrametersTypes = new Type[] { typeof(HttpRequest) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_vfChartInstanceType, methodVfChartPrametersTypes, parametersOfVfChart);
        }

        #endregion

        #region General Constructor : Class (VfChart) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="VfChart" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_VfChart_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            var methodVfChartPrametersTypes = new Type[] { typeof(HttpRequest) };

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_vfChartInstanceType, Fixture, methodVfChartPrametersTypes);
        }

        #endregion
        
        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (VfChart) => Property (ChartLookupField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_ChartLookupField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyChartLookupField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (ChartLookupFieldList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_ChartLookupFieldList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyChartLookupFieldList);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (ChartTypes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_ChartTypes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyChartTypes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (ChartUserSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_ChartUserSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyChartUserSettings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (Palettes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_Palettes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPalettes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropBubbleChartColorField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropBubbleChartColorField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropBubbleChartColorFieldRaw) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropBubbleChartColorFieldRaw_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropBubbleChartColorFieldRaw);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartAggregationType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartAggregationType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartHeight) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartHeight_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartHeight);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartMainStyle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartMainStyle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartMainStyleSafe) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartMainStyleSafe_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartMainStyleSafe);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartRollupData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartRollupData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartRollupLists) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartRollupLists_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartRollupSites) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartRollupSites_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartSelectedList) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartSelectedList_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartSelectedPaletteName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartSelectedPaletteName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartSelectedPaletteNameSafe) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartSelectedPaletteNameSafe_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartSelectedPaletteNameSafe);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartSelectedView) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartSelectedView_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartShowBubbleChartInputsInWebPart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartShowBubbleChartInputsInWebPart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartShowGridlines) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartShowGridlines_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartShowLegend) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartShowLegend_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartShowSeriesInZaxis) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartShowSeriesInZaxis_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartShowSeriesLabels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartShowSeriesLabels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartShowYaxisValuesAsCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartShowYaxisValuesAsCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartShowYaxisValuesAsPercentage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartShowYaxisValuesAsPercentage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartShowZeroValueData) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartShowZeroValueData_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartTitle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartTitle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartView3D) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartView3D_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartWebPartId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartWebPartId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartWebPartId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartWidth) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartWidth_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartWidth);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartXaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartXaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartXaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartXaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartXaxisFieldLabelRaw) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartXaxisFieldLabelRaw_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartXaxisFieldLabelRaw);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartXaxisFieldRaw) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartXaxisFieldRaw_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartXaxisFieldRaw);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartYaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartYaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartYaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartYaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartYaxisFieldLabelRaw) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartYaxisFieldLabelRaw_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartYaxisFieldLabelRaw);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartYaxisFieldRaw) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartYaxisFieldRaw_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartYaxisFieldRaw);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartYaxisNumValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartYaxisNumValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartZaxisField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartZaxisField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartZaxisFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartZaxisFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (VfChart) => Property (PropChartZaxisFieldLabelRaw) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartZaxisFieldLabelRaw_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartZaxisFieldLabelRaw);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropChartZaxisFieldRaw) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropChartZaxisFieldRaw_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropChartZaxisFieldRaw);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (PropTrace) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_PropTrace_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyPropTrace);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (ReportFilterWebPartId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_ReportFilterWebPartId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportFilterWebPartId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (VfChart) => Property (Series) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_VfChart_Public_Class_Series_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySeries);

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
        ///     Class (<see cref="VfChart" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodSortChart)]
        public void AUT_VfChart_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_vfChartInstanceFixture,
                                                                              _vfChartInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="VfChart" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodLoadChartUserSettings)]
        [TestCase(MethodChartUserSettingsAreValid)]
        [TestCase(MethodSetYFields)]
        [TestCase(MethodGetYFields)]
        [TestCase(MethodGetXaml)]
        [TestCase(MethodPointShouldBeDisplayed)]
        [TestCase(MethodGetYAxisTitle)]
        [TestCase(MethodGetYFieldDisplayName)]
        [TestCase(MethodShouldShowLegend)]
        [TestCase(MethodGetBubbleToolTipText)]
        [TestCase(MethodIsBubbleChart)]
        [TestCase(MethodGetHtml)]
        [TestCase(MethodGetWidth)]
        [TestCase(MethodGetHeight)]
        [TestCase(MethodGetQueryString)]
        [TestCase(MethodHandleException)]
        public void AUT_VfChart_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<VfChart>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (LoadChartUserSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_LoadChartUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodLoadChartUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodLoadChartUserSettings, Fixture, methodLoadChartUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (LoadChartUserSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_LoadChartUserSettings_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodLoadChartUserSettingsPrametersTypes = null;
            object[] parametersOfLoadChartUserSettings = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodLoadChartUserSettings, methodLoadChartUserSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_vfChartInstanceFixture, parametersOfLoadChartUserSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfLoadChartUserSettings.ShouldBeNull();
            methodLoadChartUserSettingsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (LoadChartUserSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_LoadChartUserSettings_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodLoadChartUserSettingsPrametersTypes = null;
            object[] parametersOfLoadChartUserSettings = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_vfChartInstance, MethodLoadChartUserSettings, parametersOfLoadChartUserSettings, methodLoadChartUserSettingsPrametersTypes);

            // Assert
            parametersOfLoadChartUserSettings.ShouldBeNull();
            methodLoadChartUserSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadChartUserSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_LoadChartUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodLoadChartUserSettingsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodLoadChartUserSettings, Fixture, methodLoadChartUserSettingsPrametersTypes);

            // Assert
            methodLoadChartUserSettingsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (LoadChartUserSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_LoadChartUserSettings_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodLoadChartUserSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ChartUserSettingsAreValid) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_ChartUserSettingsAreValid_Method_Call_Internally(Type[] types)
        {
            var methodChartUserSettingsAreValidPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodChartUserSettingsAreValid, Fixture, methodChartUserSettingsAreValidPrametersTypes);
        }

        #endregion

        #region Method Call : (ChartUserSettingsAreValid) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_ChartUserSettingsAreValid_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodChartUserSettingsAreValidPrametersTypes = null;
            object[] parametersOfChartUserSettingsAreValid = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodChartUserSettingsAreValid, methodChartUserSettingsAreValidPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, bool>(_vfChartInstanceFixture, out exception1, parametersOfChartUserSettingsAreValid);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodChartUserSettingsAreValid, parametersOfChartUserSettingsAreValid, methodChartUserSettingsAreValidPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfChartUserSettingsAreValid.ShouldBeNull();
            methodChartUserSettingsAreValidPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ChartUserSettingsAreValid) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_ChartUserSettingsAreValid_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodChartUserSettingsAreValidPrametersTypes = null;
            object[] parametersOfChartUserSettingsAreValid = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodChartUserSettingsAreValid, methodChartUserSettingsAreValidPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, bool>(_vfChartInstanceFixture, out exception1, parametersOfChartUserSettingsAreValid);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodChartUserSettingsAreValid, parametersOfChartUserSettingsAreValid, methodChartUserSettingsAreValidPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfChartUserSettingsAreValid.ShouldBeNull();
            methodChartUserSettingsAreValidPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ChartUserSettingsAreValid) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_ChartUserSettingsAreValid_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodChartUserSettingsAreValidPrametersTypes = null;
            object[] parametersOfChartUserSettingsAreValid = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodChartUserSettingsAreValid, parametersOfChartUserSettingsAreValid, methodChartUserSettingsAreValidPrametersTypes);

            // Assert
            parametersOfChartUserSettingsAreValid.ShouldBeNull();
            methodChartUserSettingsAreValidPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ChartUserSettingsAreValid) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_ChartUserSettingsAreValid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodChartUserSettingsAreValidPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodChartUserSettingsAreValid, Fixture, methodChartUserSettingsAreValidPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodChartUserSettingsAreValidPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ChartUserSettingsAreValid) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_ChartUserSettingsAreValid_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodChartUserSettingsAreValid, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (SetYFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_SetYFields_Method_Call_Internally(Type[] types)
        {
            var methodSetYFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodSetYFields, Fixture, methodSetYFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (SetYFields) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SetYFields_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var yFields = CreateType<string[]>();
            Action executeAction = null;

            // Act
            executeAction = () => _vfChartInstance.SetYFields(yFields);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (SetYFields) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SetYFields_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var yFields = CreateType<string[]>();
            var methodSetYFieldsPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfSetYFields = { yFields };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetYFields, methodSetYFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_vfChartInstanceFixture, parametersOfSetYFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetYFields.ShouldNotBeNull();
            parametersOfSetYFields.Length.ShouldBe(1);
            methodSetYFieldsPrametersTypes.Length.ShouldBe(1);
            methodSetYFieldsPrametersTypes.Length.ShouldBe(parametersOfSetYFields.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetYFields) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SetYFields_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var yFields = CreateType<string[]>();
            var methodSetYFieldsPrametersTypes = new Type[] { typeof(string[]) };
            object[] parametersOfSetYFields = { yFields };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_vfChartInstance, MethodSetYFields, parametersOfSetYFields, methodSetYFieldsPrametersTypes);

            // Assert
            parametersOfSetYFields.ShouldNotBeNull();
            parametersOfSetYFields.Length.ShouldBe(1);
            methodSetYFieldsPrametersTypes.Length.ShouldBe(1);
            methodSetYFieldsPrametersTypes.Length.ShouldBe(parametersOfSetYFields.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFields) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SetYFields_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetYFields, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetYFields) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SetYFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetYFieldsPrametersTypes = new Type[] { typeof(string[]) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodSetYFields, Fixture, methodSetYFieldsPrametersTypes);

            // Assert
            methodSetYFieldsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetYFields) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SetYFields_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetYFields, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYFields) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_GetYFields_Method_Call_Internally(Type[] types)
        {
            var methodGetYFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetYFields, Fixture, methodGetYFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetYFields) (Return Type : string[]) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFields_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _vfChartInstance.GetYFields();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetYFields) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFields_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetYFieldsPrametersTypes = null;
            object[] parametersOfGetYFields = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetYFields, methodGetYFieldsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, string[]>(_vfChartInstanceFixture, out exception1, parametersOfGetYFields);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, string[]>(_vfChartInstance, MethodGetYFields, parametersOfGetYFields, methodGetYFieldsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetYFields.ShouldBeNull();
            methodGetYFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYFields) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetYFieldsPrametersTypes = null;
            object[] parametersOfGetYFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, string[]>(_vfChartInstance, MethodGetYFields, parametersOfGetYFields, methodGetYFieldsPrametersTypes);

            // Assert
            parametersOfGetYFields.ShouldBeNull();
            methodGetYFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYFields) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFields_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetYFieldsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetYFields, Fixture, methodGetYFieldsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetYFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYFields) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetYFieldsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetYFields, Fixture, methodGetYFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetYFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYFields) (Return Type : string[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetYFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXaml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_GetXaml_Method_Call_Internally(Type[] types)
        {
            var methodGetXamlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetXaml, Fixture, methodGetXamlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetXaml) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetXaml_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _vfChartInstance.GetXaml();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetXaml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetXaml_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXamlPrametersTypes = null;
            object[] parametersOfGetXaml = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetXaml, methodGetXamlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, string>(_vfChartInstanceFixture, out exception1, parametersOfGetXaml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetXaml, parametersOfGetXaml, methodGetXamlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetXaml.ShouldBeNull();
            methodGetXamlPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXaml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetXaml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetXamlPrametersTypes = null;
            object[] parametersOfGetXaml = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetXaml, parametersOfGetXaml, methodGetXamlPrametersTypes);

            // Assert
            parametersOfGetXaml.ShouldBeNull();
            methodGetXamlPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetXaml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetXaml_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetXamlPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetXaml, Fixture, methodGetXamlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetXamlPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXaml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetXaml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetXamlPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetXaml, Fixture, methodGetXamlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetXamlPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetXaml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetXaml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetXaml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PointShouldBeDisplayed) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_PointShouldBeDisplayed_Method_Call_Internally(Type[] types)
        {
            var methodPointShouldBeDisplayedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodPointShouldBeDisplayed, Fixture, methodPointShouldBeDisplayedPrametersTypes);
        }

        #endregion

        #region Method Call : (PointShouldBeDisplayed) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_PointShouldBeDisplayed_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var point = CreateType<VfPoint>();
            var methodPointShouldBeDisplayedPrametersTypes = new Type[] { typeof(VfPoint) };
            object[] parametersOfPointShouldBeDisplayed = { point };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPointShouldBeDisplayed, methodPointShouldBeDisplayedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, bool>(_vfChartInstanceFixture, out exception1, parametersOfPointShouldBeDisplayed);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodPointShouldBeDisplayed, parametersOfPointShouldBeDisplayed, methodPointShouldBeDisplayedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPointShouldBeDisplayed.ShouldNotBeNull();
            parametersOfPointShouldBeDisplayed.Length.ShouldBe(1);
            methodPointShouldBeDisplayedPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PointShouldBeDisplayed) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_PointShouldBeDisplayed_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            var point = CreateType<VfPoint>();
            var methodPointShouldBeDisplayedPrametersTypes = new Type[] { typeof(VfPoint) };
            object[] parametersOfPointShouldBeDisplayed = { point };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodPointShouldBeDisplayed, methodPointShouldBeDisplayedPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, bool>(_vfChartInstanceFixture, out exception1, parametersOfPointShouldBeDisplayed);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodPointShouldBeDisplayed, parametersOfPointShouldBeDisplayed, methodPointShouldBeDisplayedPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfPointShouldBeDisplayed.ShouldNotBeNull();
            parametersOfPointShouldBeDisplayed.Length.ShouldBe(1);
            methodPointShouldBeDisplayedPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (PointShouldBeDisplayed) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_PointShouldBeDisplayed_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var point = CreateType<VfPoint>();
            var methodPointShouldBeDisplayedPrametersTypes = new Type[] { typeof(VfPoint) };
            object[] parametersOfPointShouldBeDisplayed = { point };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodPointShouldBeDisplayed, parametersOfPointShouldBeDisplayed, methodPointShouldBeDisplayedPrametersTypes);

            // Assert
            parametersOfPointShouldBeDisplayed.ShouldNotBeNull();
            parametersOfPointShouldBeDisplayed.Length.ShouldBe(1);
            methodPointShouldBeDisplayedPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PointShouldBeDisplayed) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_PointShouldBeDisplayed_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPointShouldBeDisplayedPrametersTypes = new Type[] { typeof(VfPoint) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodPointShouldBeDisplayed, Fixture, methodPointShouldBeDisplayedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPointShouldBeDisplayedPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PointShouldBeDisplayed) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_PointShouldBeDisplayed_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPointShouldBeDisplayed, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PointShouldBeDisplayed) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_PointShouldBeDisplayed_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPointShouldBeDisplayed, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetYAxisTitle) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_GetYAxisTitle_Method_Call_Internally(Type[] types)
        {
            var methodGetYAxisTitlePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetYAxisTitle, Fixture, methodGetYAxisTitlePrametersTypes);
        }

        #endregion

        #region Method Call : (GetYAxisTitle) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYAxisTitle_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetYAxisTitlePrametersTypes = null;
            object[] parametersOfGetYAxisTitle = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetYAxisTitle, methodGetYAxisTitlePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, string>(_vfChartInstanceFixture, out exception1, parametersOfGetYAxisTitle);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetYAxisTitle, parametersOfGetYAxisTitle, methodGetYAxisTitlePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetYAxisTitle.ShouldBeNull();
            methodGetYAxisTitlePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYAxisTitle) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYAxisTitle_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetYAxisTitlePrametersTypes = null;
            object[] parametersOfGetYAxisTitle = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetYAxisTitle, parametersOfGetYAxisTitle, methodGetYAxisTitlePrametersTypes);

            // Assert
            parametersOfGetYAxisTitle.ShouldBeNull();
            methodGetYAxisTitlePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYAxisTitle) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYAxisTitle_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetYAxisTitlePrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetYAxisTitle, Fixture, methodGetYAxisTitlePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetYAxisTitlePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYAxisTitle) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYAxisTitle_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetYAxisTitlePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetYAxisTitle, Fixture, methodGetYAxisTitlePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetYAxisTitlePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYAxisTitle) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYAxisTitle_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetYAxisTitle, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYFieldDisplayName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_GetYFieldDisplayName_Method_Call_Internally(Type[] types)
        {
            var methodGetYFieldDisplayNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetYFieldDisplayName, Fixture, methodGetYFieldDisplayNamePrametersTypes);
        }

        #endregion

        #region Method Call : (GetYFieldDisplayName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFieldDisplayName_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var internalYfieldName = CreateType<string>();
            var methodGetYFieldDisplayNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetYFieldDisplayName = { internalYfieldName };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetYFieldDisplayName, methodGetYFieldDisplayNamePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, string>(_vfChartInstanceFixture, out exception1, parametersOfGetYFieldDisplayName);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetYFieldDisplayName, parametersOfGetYFieldDisplayName, methodGetYFieldDisplayNamePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetYFieldDisplayName.ShouldNotBeNull();
            parametersOfGetYFieldDisplayName.Length.ShouldBe(1);
            methodGetYFieldDisplayNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetYFieldDisplayName) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFieldDisplayName_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var internalYfieldName = CreateType<string>();
            var methodGetYFieldDisplayNamePrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetYFieldDisplayName = { internalYfieldName };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetYFieldDisplayName, parametersOfGetYFieldDisplayName, methodGetYFieldDisplayNamePrametersTypes);

            // Assert
            parametersOfGetYFieldDisplayName.ShouldNotBeNull();
            parametersOfGetYFieldDisplayName.Length.ShouldBe(1);
            methodGetYFieldDisplayNamePrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetYFieldDisplayName) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFieldDisplayName_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetYFieldDisplayNamePrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetYFieldDisplayName, Fixture, methodGetYFieldDisplayNamePrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetYFieldDisplayNamePrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetYFieldDisplayName) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFieldDisplayName_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetYFieldDisplayNamePrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetYFieldDisplayName, Fixture, methodGetYFieldDisplayNamePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetYFieldDisplayNamePrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetYFieldDisplayName) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFieldDisplayName_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetYFieldDisplayName, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetYFieldDisplayName) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetYFieldDisplayName_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetYFieldDisplayName, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SortChart) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_SortChart_Static_Method_Call_Internally(Type[] types)
        {
            var methodSortChartPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vfChartInstanceFixture, _vfChartInstanceType, MethodSortChart, Fixture, methodSortChartPrametersTypes);
        }

        #endregion

        #region Method Call : (SortChart) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SortChart_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var vfChartSeries = CreateType<VfChartSeries>();
            var methodSortChartPrametersTypes = new Type[] { typeof(VfChartSeries) };
            object[] parametersOfSortChart = { vfChartSeries };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSortChart, methodSortChartPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_vfChartInstanceFixture, parametersOfSortChart);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSortChart.ShouldNotBeNull();
            parametersOfSortChart.Length.ShouldBe(1);
            methodSortChartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortChart) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SortChart_Static_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var vfChartSeries = CreateType<VfChartSeries>();
            var methodSortChartPrametersTypes = new Type[] { typeof(VfChartSeries) };
            object[] parametersOfSortChart = { vfChartSeries };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidStaticMethod(_vfChartInstanceFixture, _vfChartInstanceType, MethodSortChart, parametersOfSortChart, methodSortChartPrametersTypes);

            // Assert
            parametersOfSortChart.ShouldNotBeNull();
            parametersOfSortChart.Length.ShouldBe(1);
            methodSortChartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortChart) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SortChart_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSortChart, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SortChart) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SortChart_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSortChartPrametersTypes = new Type[] { typeof(VfChartSeries) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_vfChartInstanceFixture, _vfChartInstanceType, MethodSortChart, Fixture, methodSortChartPrametersTypes);

            // Assert
            methodSortChartPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SortChart) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_SortChart_Static_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSortChart, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShouldShowLegend) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_ShouldShowLegend_Method_Call_Internally(Type[] types)
        {
            var methodShouldShowLegendPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodShouldShowLegend, Fixture, methodShouldShowLegendPrametersTypes);
        }

        #endregion

        #region Method Call : (ShouldShowLegend) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_ShouldShowLegend_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodShouldShowLegendPrametersTypes = null;
            object[] parametersOfShouldShowLegend = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodShouldShowLegend, methodShouldShowLegendPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, bool>(_vfChartInstanceFixture, out exception1, parametersOfShouldShowLegend);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodShouldShowLegend, parametersOfShouldShowLegend, methodShouldShowLegendPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfShouldShowLegend.ShouldBeNull();
            methodShouldShowLegendPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ShouldShowLegend) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_ShouldShowLegend_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodShouldShowLegendPrametersTypes = null;
            object[] parametersOfShouldShowLegend = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodShouldShowLegend, methodShouldShowLegendPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, bool>(_vfChartInstanceFixture, out exception1, parametersOfShouldShowLegend);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodShouldShowLegend, parametersOfShouldShowLegend, methodShouldShowLegendPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfShouldShowLegend.ShouldBeNull();
            methodShouldShowLegendPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ShouldShowLegend) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_ShouldShowLegend_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodShouldShowLegendPrametersTypes = null;
            object[] parametersOfShouldShowLegend = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodShouldShowLegend, parametersOfShouldShowLegend, methodShouldShowLegendPrametersTypes);

            // Assert
            parametersOfShouldShowLegend.ShouldBeNull();
            methodShouldShowLegendPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ShouldShowLegend) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_ShouldShowLegend_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodShouldShowLegendPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodShouldShowLegend, Fixture, methodShouldShowLegendPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodShouldShowLegendPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ShouldShowLegend) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_ShouldShowLegend_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodShouldShowLegend, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBubbleToolTipText) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_GetBubbleToolTipText_Method_Call_Internally(Type[] types)
        {
            var methodGetBubbleToolTipTextPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetBubbleToolTipText, Fixture, methodGetBubbleToolTipTextPrametersTypes);
        }

        #endregion

        #region Method Call : (GetBubbleToolTipText) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetBubbleToolTipText_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var dataPoint = CreateType<VfPoint>();
            var methodGetBubbleToolTipTextPrametersTypes = new Type[] { typeof(VfPoint) };
            object[] parametersOfGetBubbleToolTipText = { dataPoint };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetBubbleToolTipText, methodGetBubbleToolTipTextPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, string>(_vfChartInstanceFixture, out exception1, parametersOfGetBubbleToolTipText);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetBubbleToolTipText, parametersOfGetBubbleToolTipText, methodGetBubbleToolTipTextPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetBubbleToolTipText.ShouldNotBeNull();
            parametersOfGetBubbleToolTipText.Length.ShouldBe(1);
            methodGetBubbleToolTipTextPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBubbleToolTipText) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetBubbleToolTipText_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var dataPoint = CreateType<VfPoint>();
            var methodGetBubbleToolTipTextPrametersTypes = new Type[] { typeof(VfPoint) };
            object[] parametersOfGetBubbleToolTipText = { dataPoint };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetBubbleToolTipText, parametersOfGetBubbleToolTipText, methodGetBubbleToolTipTextPrametersTypes);

            // Assert
            parametersOfGetBubbleToolTipText.ShouldNotBeNull();
            parametersOfGetBubbleToolTipText.Length.ShouldBe(1);
            methodGetBubbleToolTipTextPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetBubbleToolTipText) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetBubbleToolTipText_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetBubbleToolTipTextPrametersTypes = new Type[] { typeof(VfPoint) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetBubbleToolTipText, Fixture, methodGetBubbleToolTipTextPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetBubbleToolTipTextPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetBubbleToolTipText) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetBubbleToolTipText_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetBubbleToolTipTextPrametersTypes = new Type[] { typeof(VfPoint) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetBubbleToolTipText, Fixture, methodGetBubbleToolTipTextPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetBubbleToolTipTextPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetBubbleToolTipText) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetBubbleToolTipText_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetBubbleToolTipText, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetBubbleToolTipText) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetBubbleToolTipText_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetBubbleToolTipText, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_IsBubbleChart_Method_Call_Internally(Type[] types)
        {
            var methodIsBubbleChartPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_IsBubbleChart_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, bool>(_vfChartInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        public void AUT_VfChart_IsBubbleChart_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, methodIsBubbleChartPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, bool>(_vfChartInstanceFixture, out exception1, parametersOfIsBubbleChart);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        public void AUT_VfChart_IsBubbleChart_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            object[] parametersOfIsBubbleChart = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, bool>(_vfChartInstance, MethodIsBubbleChart, parametersOfIsBubbleChart, methodIsBubbleChartPrametersTypes);

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
        public void AUT_VfChart_IsBubbleChart_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodIsBubbleChartPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodIsBubbleChart, Fixture, methodIsBubbleChartPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodIsBubbleChartPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (IsBubbleChart) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_IsBubbleChart_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodIsBubbleChart, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_GetHtml_Method_Call_Internally(Type[] types)
        {
            var methodGetHtmlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetHtml, Fixture, methodGetHtmlPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHtml_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            var uniqueId = CreateType<string>();
            Action executeAction = null;

            // Act
            executeAction = () => _vfChartInstance.GetHtml(uniqueId);

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHtml_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var uniqueId = CreateType<string>();
            var methodGetHtmlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetHtml = { uniqueId };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetHtml, methodGetHtmlPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, string>(_vfChartInstanceFixture, out exception1, parametersOfGetHtml);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetHtml, parametersOfGetHtml, methodGetHtmlPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetHtml.ShouldNotBeNull();
            parametersOfGetHtml.Length.ShouldBe(1);
            methodGetHtmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHtml_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var uniqueId = CreateType<string>();
            var methodGetHtmlPrametersTypes = new Type[] { typeof(string) };
            object[] parametersOfGetHtml = { uniqueId };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetHtml, parametersOfGetHtml, methodGetHtmlPrametersTypes);

            // Assert
            parametersOfGetHtml.ShouldNotBeNull();
            parametersOfGetHtml.Length.ShouldBe(1);
            methodGetHtmlPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHtml_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetHtmlPrametersTypes = new Type[] { typeof(string) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetHtml, Fixture, methodGetHtmlPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetHtmlPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHtml_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetHtmlPrametersTypes = new Type[] { typeof(string) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetHtml, Fixture, methodGetHtmlPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHtmlPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHtml_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHtml, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHtml) (Return Type : string) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHtml_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetHtml, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetWidth) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_GetWidth_Method_Call_Internally(Type[] types)
        {
            var methodGetWidthPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetWidth, Fixture, methodGetWidthPrametersTypes);
        }

        #endregion

        #region Method Call : (GetWidth) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetWidth_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetWidthPrametersTypes = null;
            object[] parametersOfGetWidth = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetWidth, methodGetWidthPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, string>(_vfChartInstanceFixture, out exception1, parametersOfGetWidth);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetWidth, parametersOfGetWidth, methodGetWidthPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetWidth.ShouldBeNull();
            methodGetWidthPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWidth) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetWidth_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetWidthPrametersTypes = null;
            object[] parametersOfGetWidth = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetWidth, parametersOfGetWidth, methodGetWidthPrametersTypes);

            // Assert
            parametersOfGetWidth.ShouldBeNull();
            methodGetWidthPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetWidth) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetWidth_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetWidthPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetWidth, Fixture, methodGetWidthPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetWidthPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWidth) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetWidth_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetWidthPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetWidth, Fixture, methodGetWidthPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetWidthPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetWidth) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetWidth_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetWidth, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeight) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_GetHeight_Method_Call_Internally(Type[] types)
        {
            var methodGetHeightPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetHeight, Fixture, methodGetHeightPrametersTypes);
        }

        #endregion

        #region Method Call : (GetHeight) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHeight_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetHeightPrametersTypes = null;
            object[] parametersOfGetHeight = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetHeight, methodGetHeightPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, string>(_vfChartInstanceFixture, out exception1, parametersOfGetHeight);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetHeight, parametersOfGetHeight, methodGetHeightPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetHeight.ShouldBeNull();
            methodGetHeightPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeight) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHeight_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetHeightPrametersTypes = null;
            object[] parametersOfGetHeight = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetHeight, parametersOfGetHeight, methodGetHeightPrametersTypes);

            // Assert
            parametersOfGetHeight.ShouldBeNull();
            methodGetHeightPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetHeight) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHeight_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetHeightPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetHeight, Fixture, methodGetHeightPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetHeightPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeight) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHeight_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetHeightPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetHeight, Fixture, methodGetHeightPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetHeightPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetHeight) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetHeight_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetHeight, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetQueryString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_GetQueryString_Method_Call_Internally(Type[] types)
        {
            var methodGetQueryStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetQueryString, Fixture, methodGetQueryStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetQueryString) (Return Type : string) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetQueryString_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _vfChartInstance.GetQueryString();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (GetQueryString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetQueryString_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetQueryStringPrametersTypes = null;
            object[] parametersOfGetQueryString = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetQueryString, methodGetQueryStringPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<VfChart, string>(_vfChartInstanceFixture, out exception1, parametersOfGetQueryString);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetQueryString, parametersOfGetQueryString, methodGetQueryStringPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetQueryString.ShouldBeNull();
            methodGetQueryStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetQueryString) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetQueryString_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetQueryStringPrametersTypes = null;
            object[] parametersOfGetQueryString = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<VfChart, string>(_vfChartInstance, MethodGetQueryString, parametersOfGetQueryString, methodGetQueryStringPrametersTypes);

            // Assert
            parametersOfGetQueryString.ShouldBeNull();
            methodGetQueryStringPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetQueryString) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetQueryString_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetQueryStringPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetQueryString, Fixture, methodGetQueryStringPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetQueryStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetQueryString) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetQueryString_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetQueryStringPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodGetQueryString, Fixture, methodGetQueryStringPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetQueryStringPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetQueryString) (Return Type : string) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_GetQueryString_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetQueryString, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_VfChart_HandleException_Method_Call_Internally(Type[] types)
        {
            var methodHandleExceptionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_HandleException_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var ex = CreateType<Exception>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfHandleException = { ex };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodHandleException, methodHandleExceptionPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_vfChartInstanceFixture, parametersOfHandleException);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(1);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(1);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(parametersOfHandleException.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_HandleException_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var ex = CreateType<Exception>();
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception) };
            object[] parametersOfHandleException = { ex };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_vfChartInstance, MethodHandleException, parametersOfHandleException, methodHandleExceptionPrametersTypes);

            // Assert
            parametersOfHandleException.ShouldNotBeNull();
            parametersOfHandleException.Length.ShouldBe(1);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(1);
            methodHandleExceptionPrametersTypes.Length.ShouldBe(parametersOfHandleException.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_HandleException_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodHandleException, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_HandleException_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodHandleExceptionPrametersTypes = new Type[] { typeof(Exception) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_vfChartInstance, MethodHandleException, Fixture, methodHandleExceptionPrametersTypes);

            // Assert
            methodHandleExceptionPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HandleException) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        public void AUT_VfChart_HandleException_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHandleException, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_vfChartInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #endregion

        #endregion
    }
}