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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AnalyticSnapshotMapping" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AnalyticSnapshotMappingTest : AbstractBaseSetupTypedTest<AnalyticSnapshotMapping>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AnalyticSnapshotMapping) Initializer

        private const string PropertyaggregateType = "aggregateType";
        private const string PropertyaggregateTypeSpecified = "aggregateTypeSpecified";
        private const string PropertysourceField = "sourceField";
        private const string PropertysourceType = "sourceType";
        private const string PropertytargetField = "targetField";
        private const string FieldaggregateTypeField = "aggregateTypeField";
        private const string FieldaggregateTypeFieldSpecified = "aggregateTypeFieldSpecified";
        private const string FieldsourceFieldField = "sourceFieldField";
        private const string FieldsourceTypeField = "sourceTypeField";
        private const string FieldtargetFieldField = "targetFieldField";
        private Type _analyticSnapshotMappingInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AnalyticSnapshotMapping _analyticSnapshotMappingInstance;
        private AnalyticSnapshotMapping _analyticSnapshotMappingInstanceFixture;

        #region General Initializer : Class (AnalyticSnapshotMapping) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AnalyticSnapshotMapping" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _analyticSnapshotMappingInstanceType = typeof(AnalyticSnapshotMapping);
            _analyticSnapshotMappingInstanceFixture = Create(true);
            _analyticSnapshotMappingInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AnalyticSnapshotMapping)

        #region General Initializer : Class (AnalyticSnapshotMapping) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AnalyticSnapshotMapping" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaggregateType)]
        [TestCase(PropertyaggregateTypeSpecified)]
        [TestCase(PropertysourceField)]
        [TestCase(PropertysourceType)]
        [TestCase(PropertytargetField)]
        public void AUT_AnalyticSnapshotMapping_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_analyticSnapshotMappingInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AnalyticSnapshotMapping) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AnalyticSnapshotMapping" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaggregateTypeField)]
        [TestCase(FieldaggregateTypeFieldSpecified)]
        [TestCase(FieldsourceFieldField)]
        [TestCase(FieldsourceTypeField)]
        [TestCase(FieldtargetFieldField)]
        public void AUT_AnalyticSnapshotMapping_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_analyticSnapshotMappingInstanceFixture, 
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
        ///     Class (<see cref="AnalyticSnapshotMapping" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AnalyticSnapshotMapping_Is_Instance_Present_Test()
        {
            // Assert
            _analyticSnapshotMappingInstanceType.ShouldNotBeNull();
            _analyticSnapshotMappingInstance.ShouldNotBeNull();
            _analyticSnapshotMappingInstanceFixture.ShouldNotBeNull();
            _analyticSnapshotMappingInstance.ShouldBeAssignableTo<AnalyticSnapshotMapping>();
            _analyticSnapshotMappingInstanceFixture.ShouldBeAssignableTo<AnalyticSnapshotMapping>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AnalyticSnapshotMapping) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AnalyticSnapshotMapping_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AnalyticSnapshotMapping instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _analyticSnapshotMappingInstanceType.ShouldNotBeNull();
            _analyticSnapshotMappingInstance.ShouldNotBeNull();
            _analyticSnapshotMappingInstanceFixture.ShouldNotBeNull();
            _analyticSnapshotMappingInstance.ShouldBeAssignableTo<AnalyticSnapshotMapping>();
            _analyticSnapshotMappingInstanceFixture.ShouldBeAssignableTo<AnalyticSnapshotMapping>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AnalyticSnapshotMapping) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportSummaryType) , PropertyaggregateType)]
        [TestCaseGeneric(typeof(bool) , PropertyaggregateTypeSpecified)]
        [TestCaseGeneric(typeof(string) , PropertysourceField)]
        [TestCaseGeneric(typeof(ReportJobSourceTypes) , PropertysourceType)]
        [TestCaseGeneric(typeof(string) , PropertytargetField)]
        public void AUT_AnalyticSnapshotMapping_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AnalyticSnapshotMapping, T>(_analyticSnapshotMappingInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshotMapping) => Property (aggregateType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshotMapping_aggregateType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyaggregateType);
            Action currentAction = () => propertyInfo.SetValue(_analyticSnapshotMappingInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshotMapping) => Property (aggregateType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshotMapping_Public_Class_aggregateType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AnalyticSnapshotMapping) => Property (aggregateTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshotMapping_Public_Class_aggregateTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (AnalyticSnapshotMapping) => Property (sourceField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshotMapping_Public_Class_sourceField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysourceField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshotMapping) => Property (sourceType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshotMapping_sourceType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysourceType);
            Action currentAction = () => propertyInfo.SetValue(_analyticSnapshotMappingInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshotMapping) => Property (sourceType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshotMapping_Public_Class_sourceType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysourceType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AnalyticSnapshotMapping) => Property (targetField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AnalyticSnapshotMapping_Public_Class_targetField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytargetField);

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