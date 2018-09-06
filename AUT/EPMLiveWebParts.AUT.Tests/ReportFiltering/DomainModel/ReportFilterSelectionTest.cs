using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using Microsoft.SharePoint;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts.ReportFiltering.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportFiltering.DomainModel.ReportFilterSelection" />)
    ///     and namespace <see cref="EPMLiveWebParts.ReportFiltering.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ReportFilterSelectionTest : AbstractBaseSetupTypedTest<ReportFilterSelection>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportFilterSelection) Initializer

        private const string PropertyInternalFieldName = "InternalFieldName";
        private const string PropertyFieldNameForDisplay = "FieldNameForDisplay";
        private const string PropertySelectedFields = "SelectedFields";
        private const string PropertyCamlComparisonOperator = "CamlComparisonOperator";
        private const string PropertyFieldType = "FieldType";
        private const string PropertyIsLookUp = "IsLookUp";
        private const string PropertyIsPercentage = "IsPercentage";
        private const string PropertyLookupFieldType = "LookupFieldType";
        private const string PropertyListToFilterOn = "ListToFilterOn";
        private const string PropertyHasErrors = "HasErrors";
        private const string PropertyErrors = "Errors";
        private const string PropertyHasFieldSelections = "HasFieldSelections";
        private Type _reportFilterSelectionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportFilterSelection _reportFilterSelectionInstance;
        private ReportFilterSelection _reportFilterSelectionInstanceFixture;

        #region General Initializer : Class (ReportFilterSelection) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportFilterSelection" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportFilterSelectionInstanceType = typeof(ReportFilterSelection);
            _reportFilterSelectionInstanceFixture = Create(true);
            _reportFilterSelectionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportFilterSelection)

        #region General Initializer : Class (ReportFilterSelection) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportFilterSelection" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyInternalFieldName)]
        [TestCase(PropertyFieldNameForDisplay)]
        [TestCase(PropertySelectedFields)]
        [TestCase(PropertyCamlComparisonOperator)]
        [TestCase(PropertyFieldType)]
        [TestCase(PropertyIsLookUp)]
        [TestCase(PropertyIsPercentage)]
        [TestCase(PropertyLookupFieldType)]
        [TestCase(PropertyListToFilterOn)]
        [TestCase(PropertyHasErrors)]
        [TestCase(PropertyErrors)]
        [TestCase(PropertyHasFieldSelections)]
        public void AUT_ReportFilterSelection_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportFilterSelectionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ReportFilterSelection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ReportFilterSelection_Is_Instance_Present_Test()
        {
            // Assert
            _reportFilterSelectionInstanceType.ShouldNotBeNull();
            _reportFilterSelectionInstance.ShouldNotBeNull();
            _reportFilterSelectionInstanceFixture.ShouldNotBeNull();
            _reportFilterSelectionInstance.ShouldBeAssignableTo<ReportFilterSelection>();
            _reportFilterSelectionInstanceFixture.ShouldBeAssignableTo<ReportFilterSelection>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportFilterSelection) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_ReportFilterSelection_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportFilterSelection instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportFilterSelectionInstanceType.ShouldNotBeNull();
            _reportFilterSelectionInstance.ShouldNotBeNull();
            _reportFilterSelectionInstanceFixture.ShouldNotBeNull();
            _reportFilterSelectionInstance.ShouldBeAssignableTo<ReportFilterSelection>();
            _reportFilterSelectionInstanceFixture.ShouldBeAssignableTo<ReportFilterSelection>();
        }

        #endregion

        #region General Constructor : Class (ReportFilterSelection) Default Assignment Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ReportFilterSelection_Constructor_Instantiated_With_Default_Assignments_Test()
        {

            // Act
            var reportFilterSelectionInstance  = new ReportFilterSelection();

            // Asserts
            reportFilterSelectionInstance.ShouldNotBeNull();
            reportFilterSelectionInstance.ShouldBeAssignableTo<ReportFilterSelection>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportFilterSelection) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyInternalFieldName)]
        [TestCaseGeneric(typeof(string) , PropertyFieldNameForDisplay)]
        [TestCaseGeneric(typeof(List<string>) , PropertySelectedFields)]
        [TestCaseGeneric(typeof(CamlComparisonOperator) , PropertyCamlComparisonOperator)]
        [TestCaseGeneric(typeof(SPFieldType) , PropertyFieldType)]
        [TestCaseGeneric(typeof(bool) , PropertyIsLookUp)]
        [TestCaseGeneric(typeof(bool) , PropertyIsPercentage)]
        [TestCaseGeneric(typeof(SPFieldType) , PropertyLookupFieldType)]
        [TestCaseGeneric(typeof(Guid) , PropertyListToFilterOn)]
        [TestCaseGeneric(typeof(bool) , PropertyHasErrors)]
        [TestCaseGeneric(typeof(List<string>) , PropertyErrors)]
        [TestCaseGeneric(typeof(bool) , PropertyHasFieldSelections)]
        public void AUT_ReportFilterSelection_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportFilterSelection, T>(_reportFilterSelectionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (CamlComparisonOperator) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_CamlComparisonOperator_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyCamlComparisonOperator);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterSelectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (CamlComparisonOperator) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_CamlComparisonOperator_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCamlComparisonOperator);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (Errors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_Errors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyErrors);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (FieldNameForDisplay) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_FieldNameForDisplay_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFieldNameForDisplay);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (FieldType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_FieldType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyFieldType);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterSelectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (FieldType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_FieldType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFieldType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (HasErrors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_HasErrors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHasErrors);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (HasFieldSelections) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_HasFieldSelections_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyHasFieldSelections);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (InternalFieldName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_InternalFieldName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyInternalFieldName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (IsLookUp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_IsLookUp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsLookUp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (IsPercentage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_IsPercentage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsPercentage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (ListToFilterOn) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_ListToFilterOn_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyListToFilterOn);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterSelectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (ListToFilterOn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_ListToFilterOn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListToFilterOn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (LookupFieldType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_LookupFieldType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyLookupFieldType);
            Action currentAction = () => propertyInfo.SetValue(_reportFilterSelectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (LookupFieldType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_LookupFieldType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLookupFieldType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportFilterSelection) => Property (SelectedFields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_ReportFilterSelection_Public_Class_SelectedFields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySelectedFields);

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