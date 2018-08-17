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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DashboardTableColumn" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DashboardTableColumnTest : AbstractBaseSetupTypedTest<DashboardTableColumn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DashboardTableColumn) Initializer

        private const string PropertyaggregateType = "aggregateType";
        private const string PropertyaggregateTypeSpecified = "aggregateTypeSpecified";
        private const string Propertycolumn = "column";
        private const string PropertyshowTotal = "showTotal";
        private const string PropertyshowTotalSpecified = "showTotalSpecified";
        private const string PropertysortBy = "sortBy";
        private const string PropertysortBySpecified = "sortBySpecified";
        private const string FieldaggregateTypeField = "aggregateTypeField";
        private const string FieldaggregateTypeFieldSpecified = "aggregateTypeFieldSpecified";
        private const string FieldcolumnField = "columnField";
        private const string FieldshowTotalField = "showTotalField";
        private const string FieldshowTotalFieldSpecified = "showTotalFieldSpecified";
        private const string FieldsortByField = "sortByField";
        private const string FieldsortByFieldSpecified = "sortByFieldSpecified";
        private Type _dashboardTableColumnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DashboardTableColumn _dashboardTableColumnInstance;
        private DashboardTableColumn _dashboardTableColumnInstanceFixture;

        #region General Initializer : Class (DashboardTableColumn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DashboardTableColumn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dashboardTableColumnInstanceType = typeof(DashboardTableColumn);
            _dashboardTableColumnInstanceFixture = Create(true);
            _dashboardTableColumnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DashboardTableColumn)

        #region General Initializer : Class (DashboardTableColumn) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DashboardTableColumn" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaggregateType)]
        [TestCase(PropertyaggregateTypeSpecified)]
        [TestCase(Propertycolumn)]
        [TestCase(PropertyshowTotal)]
        [TestCase(PropertyshowTotalSpecified)]
        [TestCase(PropertysortBy)]
        [TestCase(PropertysortBySpecified)]
        public void AUT_DashboardTableColumn_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dashboardTableColumnInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DashboardTableColumn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DashboardTableColumn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaggregateTypeField)]
        [TestCase(FieldaggregateTypeFieldSpecified)]
        [TestCase(FieldcolumnField)]
        [TestCase(FieldshowTotalField)]
        [TestCase(FieldshowTotalFieldSpecified)]
        [TestCase(FieldsortByField)]
        [TestCase(FieldsortByFieldSpecified)]
        public void AUT_DashboardTableColumn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dashboardTableColumnInstanceFixture, 
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
        ///     Class (<see cref="DashboardTableColumn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DashboardTableColumn_Is_Instance_Present_Test()
        {
            // Assert
            _dashboardTableColumnInstanceType.ShouldNotBeNull();
            _dashboardTableColumnInstance.ShouldNotBeNull();
            _dashboardTableColumnInstanceFixture.ShouldNotBeNull();
            _dashboardTableColumnInstance.ShouldBeAssignableTo<DashboardTableColumn>();
            _dashboardTableColumnInstanceFixture.ShouldBeAssignableTo<DashboardTableColumn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DashboardTableColumn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DashboardTableColumn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DashboardTableColumn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dashboardTableColumnInstanceType.ShouldNotBeNull();
            _dashboardTableColumnInstance.ShouldNotBeNull();
            _dashboardTableColumnInstanceFixture.ShouldNotBeNull();
            _dashboardTableColumnInstance.ShouldBeAssignableTo<DashboardTableColumn>();
            _dashboardTableColumnInstanceFixture.ShouldBeAssignableTo<DashboardTableColumn>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DashboardTableColumn) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportSummaryType) , PropertyaggregateType)]
        [TestCaseGeneric(typeof(bool) , PropertyaggregateTypeSpecified)]
        [TestCaseGeneric(typeof(string) , Propertycolumn)]
        [TestCaseGeneric(typeof(bool) , PropertyshowTotal)]
        [TestCaseGeneric(typeof(bool) , PropertyshowTotalSpecified)]
        [TestCaseGeneric(typeof(DashboardComponentFilter) , PropertysortBy)]
        [TestCaseGeneric(typeof(bool) , PropertysortBySpecified)]
        public void AUT_DashboardTableColumn_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DashboardTableColumn, T>(_dashboardTableColumnInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardTableColumn) => Property (aggregateType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardTableColumn_aggregateType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyaggregateType);
            Action currentAction = () => propertyInfo.SetValue(_dashboardTableColumnInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardTableColumn) => Property (aggregateType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardTableColumn_Public_Class_aggregateType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaggregateType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardTableColumn) => Property (aggregateTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardTableColumn_Public_Class_aggregateTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaggregateTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardTableColumn) => Property (column) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardTableColumn_Public_Class_column_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycolumn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardTableColumn) => Property (showTotal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardTableColumn_Public_Class_showTotal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowTotal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardTableColumn) => Property (showTotalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardTableColumn_Public_Class_showTotalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowTotalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardTableColumn) => Property (sortBy) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardTableColumn_sortBy_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysortBy);
            Action currentAction = () => propertyInfo.SetValue(_dashboardTableColumnInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardTableColumn) => Property (sortBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardTableColumn_Public_Class_sortBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardTableColumn) => Property (sortBySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardTableColumn_Public_Class_sortBySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortBySpecified);

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