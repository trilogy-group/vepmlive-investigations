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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportCrossFilter" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportCrossFilterTest : AbstractBaseSetupTypedTest<ReportCrossFilter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportCrossFilter) Initializer

        private const string PropertycriteriaItems = "criteriaItems";
        private const string Propertyoperation = "operation";
        private const string PropertyprimaryTableColumn = "primaryTableColumn";
        private const string PropertyrelatedTable = "relatedTable";
        private const string PropertyrelatedTableJoinColumn = "relatedTableJoinColumn";
        private const string FieldcriteriaItemsField = "criteriaItemsField";
        private const string FieldoperationField = "operationField";
        private const string FieldprimaryTableColumnField = "primaryTableColumnField";
        private const string FieldrelatedTableField = "relatedTableField";
        private const string FieldrelatedTableJoinColumnField = "relatedTableJoinColumnField";
        private Type _reportCrossFilterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportCrossFilter _reportCrossFilterInstance;
        private ReportCrossFilter _reportCrossFilterInstanceFixture;

        #region General Initializer : Class (ReportCrossFilter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportCrossFilter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportCrossFilterInstanceType = typeof(ReportCrossFilter);
            _reportCrossFilterInstanceFixture = Create(true);
            _reportCrossFilterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportCrossFilter)

        #region General Initializer : Class (ReportCrossFilter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportCrossFilter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycriteriaItems)]
        [TestCase(Propertyoperation)]
        [TestCase(PropertyprimaryTableColumn)]
        [TestCase(PropertyrelatedTable)]
        [TestCase(PropertyrelatedTableJoinColumn)]
        public void AUT_ReportCrossFilter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportCrossFilterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportCrossFilter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportCrossFilter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcriteriaItemsField)]
        [TestCase(FieldoperationField)]
        [TestCase(FieldprimaryTableColumnField)]
        [TestCase(FieldrelatedTableField)]
        [TestCase(FieldrelatedTableJoinColumnField)]
        public void AUT_ReportCrossFilter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportCrossFilterInstanceFixture, 
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
        ///     Class (<see cref="ReportCrossFilter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportCrossFilter_Is_Instance_Present_Test()
        {
            // Assert
            _reportCrossFilterInstanceType.ShouldNotBeNull();
            _reportCrossFilterInstance.ShouldNotBeNull();
            _reportCrossFilterInstanceFixture.ShouldNotBeNull();
            _reportCrossFilterInstance.ShouldBeAssignableTo<ReportCrossFilter>();
            _reportCrossFilterInstanceFixture.ShouldBeAssignableTo<ReportCrossFilter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportCrossFilter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportCrossFilter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportCrossFilter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportCrossFilterInstanceType.ShouldNotBeNull();
            _reportCrossFilterInstance.ShouldNotBeNull();
            _reportCrossFilterInstanceFixture.ShouldNotBeNull();
            _reportCrossFilterInstance.ShouldBeAssignableTo<ReportCrossFilter>();
            _reportCrossFilterInstanceFixture.ShouldBeAssignableTo<ReportCrossFilter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportCrossFilter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportFilterItem[]) , PropertycriteriaItems)]
        [TestCaseGeneric(typeof(ObjectFilterOperator) , Propertyoperation)]
        [TestCaseGeneric(typeof(string) , PropertyprimaryTableColumn)]
        [TestCaseGeneric(typeof(string) , PropertyrelatedTable)]
        [TestCaseGeneric(typeof(string) , PropertyrelatedTableJoinColumn)]
        public void AUT_ReportCrossFilter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportCrossFilter, T>(_reportCrossFilterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportCrossFilter) => Property (criteriaItems) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportCrossFilter_criteriaItems_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycriteriaItems);
            Action currentAction = () => propertyInfo.SetValue(_reportCrossFilterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportCrossFilter) => Property (criteriaItems) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportCrossFilter_Public_Class_criteriaItems_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycriteriaItems);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportCrossFilter) => Property (operation) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportCrossFilter_operation_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyoperation);
            Action currentAction = () => propertyInfo.SetValue(_reportCrossFilterInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportCrossFilter) => Property (operation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportCrossFilter_Public_Class_operation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyoperation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportCrossFilter) => Property (primaryTableColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportCrossFilter_Public_Class_primaryTableColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyprimaryTableColumn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportCrossFilter) => Property (relatedTable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportCrossFilter_Public_Class_relatedTable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelatedTable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportCrossFilter) => Property (relatedTableJoinColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportCrossFilter_Public_Class_relatedTableJoinColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelatedTableJoinColumn);

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