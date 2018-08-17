using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Report" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportTest : AbstractBaseSetupTypedTest<Report>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Report) Initializer

        private const string Propertyaggregates = "aggregates";
        private const string Propertyblock = "block";
        private const string PropertyblockInfo = "blockInfo";
        private const string Propertybuckets = "buckets";
        private const string Propertychart = "chart";
        private const string PropertycolorRanges = "colorRanges";
        private const string Propertycolumns = "columns";
        private const string PropertycrossFilters = "crossFilters";
        private const string Propertycurrency = "currency";
        private const string PropertycurrencySpecified = "currencySpecified";
        private const string Propertydescription = "description";
        private const string Propertydivision = "division";
        private const string Propertyfilter = "filter";
        private const string Propertyformat = "format";
        private const string PropertygroupingsAcross = "groupingsAcross";
        private const string PropertygroupingsDown = "groupingsDown";
        private const string Propertyname = "name";
        private const string PropertyreportType = "reportType";
        private const string PropertyroleHierarchyFilter = "roleHierarchyFilter";
        private const string PropertyrowLimit = "rowLimit";
        private const string PropertyrowLimitSpecified = "rowLimitSpecified";
        private const string Propertyscope = "scope";
        private const string PropertyshowDetails = "showDetails";
        private const string PropertyshowDetailsSpecified = "showDetailsSpecified";
        private const string PropertysortColumn = "sortColumn";
        private const string PropertysortOrder = "sortOrder";
        private const string PropertysortOrderSpecified = "sortOrderSpecified";
        private const string PropertyterritoryHierarchyFilter = "territoryHierarchyFilter";
        private const string PropertytimeFrameFilter = "timeFrameFilter";
        private const string PropertyuserFilter = "userFilter";
        private const string FieldaggregatesField = "aggregatesField";
        private const string FieldblockField = "blockField";
        private const string FieldblockInfoField = "blockInfoField";
        private const string FieldbucketsField = "bucketsField";
        private const string FieldchartField = "chartField";
        private const string FieldcolorRangesField = "colorRangesField";
        private const string FieldcolumnsField = "columnsField";
        private const string FieldcrossFiltersField = "crossFiltersField";
        private const string FieldcurrencyField = "currencyField";
        private const string FieldcurrencyFieldSpecified = "currencyFieldSpecified";
        private const string FielddescriptionField = "descriptionField";
        private const string FielddivisionField = "divisionField";
        private const string FieldfilterField = "filterField";
        private const string FieldformatField = "formatField";
        private const string FieldgroupingsAcrossField = "groupingsAcrossField";
        private const string FieldgroupingsDownField = "groupingsDownField";
        private const string FieldnameField = "nameField";
        private const string FieldparamsField = "paramsField";
        private const string FieldreportTypeField = "reportTypeField";
        private const string FieldroleHierarchyFilterField = "roleHierarchyFilterField";
        private const string FieldrowLimitField = "rowLimitField";
        private const string FieldrowLimitFieldSpecified = "rowLimitFieldSpecified";
        private const string FieldscopeField = "scopeField";
        private const string FieldshowDetailsField = "showDetailsField";
        private const string FieldshowDetailsFieldSpecified = "showDetailsFieldSpecified";
        private const string FieldsortColumnField = "sortColumnField";
        private const string FieldsortOrderField = "sortOrderField";
        private const string FieldsortOrderFieldSpecified = "sortOrderFieldSpecified";
        private const string FieldterritoryHierarchyFilterField = "territoryHierarchyFilterField";
        private const string FieldtimeFrameFilterField = "timeFrameFilterField";
        private const string FielduserFilterField = "userFilterField";
        private Type _reportInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Report _reportInstance;
        private Report _reportInstanceFixture;

        #region General Initializer : Class (Report) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Report" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportInstanceType = typeof(Report);
            _reportInstanceFixture = Create(true);
            _reportInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Report)

        #region General Initializer : Class (Report) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Report" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyaggregates)]
        [TestCase(Propertyblock)]
        [TestCase(PropertyblockInfo)]
        [TestCase(Propertybuckets)]
        [TestCase(Propertychart)]
        [TestCase(PropertycolorRanges)]
        [TestCase(Propertycolumns)]
        [TestCase(PropertycrossFilters)]
        [TestCase(Propertycurrency)]
        [TestCase(PropertycurrencySpecified)]
        [TestCase(Propertydescription)]
        [TestCase(Propertydivision)]
        [TestCase(Propertyfilter)]
        [TestCase(Propertyformat)]
        [TestCase(PropertygroupingsAcross)]
        [TestCase(PropertygroupingsDown)]
        [TestCase(Propertyname)]
        [TestCase(PropertyreportType)]
        [TestCase(PropertyroleHierarchyFilter)]
        [TestCase(PropertyrowLimit)]
        [TestCase(PropertyrowLimitSpecified)]
        [TestCase(Propertyscope)]
        [TestCase(PropertyshowDetails)]
        [TestCase(PropertyshowDetailsSpecified)]
        [TestCase(PropertysortColumn)]
        [TestCase(PropertysortOrder)]
        [TestCase(PropertysortOrderSpecified)]
        [TestCase(PropertyterritoryHierarchyFilter)]
        [TestCase(PropertytimeFrameFilter)]
        [TestCase(PropertyuserFilter)]
        public void AUT_Report_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Report) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Report" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaggregatesField)]
        [TestCase(FieldblockField)]
        [TestCase(FieldblockInfoField)]
        [TestCase(FieldbucketsField)]
        [TestCase(FieldchartField)]
        [TestCase(FieldcolorRangesField)]
        [TestCase(FieldcolumnsField)]
        [TestCase(FieldcrossFiltersField)]
        [TestCase(FieldcurrencyField)]
        [TestCase(FieldcurrencyFieldSpecified)]
        [TestCase(FielddescriptionField)]
        [TestCase(FielddivisionField)]
        [TestCase(FieldfilterField)]
        [TestCase(FieldformatField)]
        [TestCase(FieldgroupingsAcrossField)]
        [TestCase(FieldgroupingsDownField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldparamsField)]
        [TestCase(FieldreportTypeField)]
        [TestCase(FieldroleHierarchyFilterField)]
        [TestCase(FieldrowLimitField)]
        [TestCase(FieldrowLimitFieldSpecified)]
        [TestCase(FieldscopeField)]
        [TestCase(FieldshowDetailsField)]
        [TestCase(FieldshowDetailsFieldSpecified)]
        [TestCase(FieldsortColumnField)]
        [TestCase(FieldsortOrderField)]
        [TestCase(FieldsortOrderFieldSpecified)]
        [TestCase(FieldterritoryHierarchyFilterField)]
        [TestCase(FieldtimeFrameFilterField)]
        [TestCase(FielduserFilterField)]
        public void AUT_Report_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportInstanceFixture, 
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
        ///     Class (<see cref="Report" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Report_Is_Instance_Present_Test()
        {
            // Assert
            _reportInstanceType.ShouldNotBeNull();
            _reportInstance.ShouldNotBeNull();
            _reportInstanceFixture.ShouldNotBeNull();
            _reportInstance.ShouldBeAssignableTo<Report>();
            _reportInstanceFixture.ShouldBeAssignableTo<Report>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Report) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Report_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Report instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportInstanceType.ShouldNotBeNull();
            _reportInstance.ShouldNotBeNull();
            _reportInstanceFixture.ShouldNotBeNull();
            _reportInstance.ShouldBeAssignableTo<Report>();
            _reportInstanceFixture.ShouldBeAssignableTo<Report>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Report) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportAggregate[]) , Propertyaggregates)]
        [TestCaseGeneric(typeof(Report[]) , Propertyblock)]
        [TestCaseGeneric(typeof(ReportBlockInfo) , PropertyblockInfo)]
        [TestCaseGeneric(typeof(ReportBucketField[]) , Propertybuckets)]
        [TestCaseGeneric(typeof(ReportChart) , Propertychart)]
        [TestCaseGeneric(typeof(ReportColorRange[]) , PropertycolorRanges)]
        [TestCaseGeneric(typeof(ReportColumn[]) , Propertycolumns)]
        [TestCaseGeneric(typeof(ReportCrossFilter[]) , PropertycrossFilters)]
        [TestCaseGeneric(typeof(CurrencyIsoCode) , Propertycurrency)]
        [TestCaseGeneric(typeof(bool) , PropertycurrencySpecified)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertydivision)]
        [TestCaseGeneric(typeof(ReportFilter) , Propertyfilter)]
        [TestCaseGeneric(typeof(ReportFormat) , Propertyformat)]
        [TestCaseGeneric(typeof(ReportGrouping[]) , PropertygroupingsAcross)]
        [TestCaseGeneric(typeof(ReportGrouping[]) , PropertygroupingsDown)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(string) , PropertyreportType)]
        [TestCaseGeneric(typeof(string) , PropertyroleHierarchyFilter)]
        [TestCaseGeneric(typeof(int) , PropertyrowLimit)]
        [TestCaseGeneric(typeof(bool) , PropertyrowLimitSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyscope)]
        [TestCaseGeneric(typeof(bool) , PropertyshowDetails)]
        [TestCaseGeneric(typeof(bool) , PropertyshowDetailsSpecified)]
        [TestCaseGeneric(typeof(string) , PropertysortColumn)]
        [TestCaseGeneric(typeof(SortOrder) , PropertysortOrder)]
        [TestCaseGeneric(typeof(bool) , PropertysortOrderSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyterritoryHierarchyFilter)]
        [TestCaseGeneric(typeof(ReportTimeFrameFilter) , PropertytimeFrameFilter)]
        [TestCaseGeneric(typeof(string) , PropertyuserFilter)]
        public void AUT_Report_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Report, T>(_reportInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (Report) => Property (aggregates) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_aggregates_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyaggregates);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (aggregates) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_aggregates_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyaggregates);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (block) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_block_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyblock);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (block) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_block_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyblock);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (blockInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_blockInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyblockInfo);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (blockInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_blockInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyblockInfo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (buckets) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_buckets_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertybuckets);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (buckets) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_buckets_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertybuckets);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (chart) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_chart_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertychart);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (chart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_chart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertychart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (colorRanges) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_colorRanges_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycolorRanges);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (colorRanges) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_colorRanges_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycolorRanges);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (columns) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_columns_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycolumns);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (columns) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_columns_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycolumns);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (crossFilters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_crossFilters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycrossFilters);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (crossFilters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_crossFilters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycrossFilters);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (currency) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_currency_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycurrency);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (currency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_currency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (currencySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_currencySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycurrencySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (division) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_division_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydivision);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (filter) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_filter_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfilter);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (filter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_filter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (format) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_format_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyformat);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (format) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_format_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyformat);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (groupingsAcross) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_groupingsAcross_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertygroupingsAcross);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (groupingsAcross) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_groupingsAcross_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertygroupingsAcross);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (groupingsDown) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_groupingsDown_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertygroupingsDown);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (groupingsDown) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_groupingsDown_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertygroupingsDown);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (reportType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_reportType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreportType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (roleHierarchyFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_roleHierarchyFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyroleHierarchyFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (rowLimit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_rowLimit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrowLimit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (rowLimitSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_rowLimitSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrowLimitSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (scope) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_scope_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyscope);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (showDetails) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_showDetails_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowDetails);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (showDetailsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_showDetailsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowDetailsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (sortColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_sortColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortColumn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (sortOrder) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_sortOrder_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysortOrder);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (sortOrder) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_sortOrder_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortOrder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (sortOrderSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_sortOrderSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortOrderSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (territoryHierarchyFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_territoryHierarchyFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyterritoryHierarchyFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (timeFrameFilter) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_timeFrameFilter_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertytimeFrameFilter);
            Action currentAction = () => propertyInfo.SetValue(_reportInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (timeFrameFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_timeFrameFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytimeFrameFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Report) => Property (userFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Report_Public_Class_userFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}