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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportColumn" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportColumnTest : AbstractBaseSetupTypedTest<ReportColumn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportColumn) Initializer

        private const string PropertyaggregateTypes = "aggregateTypes";
        private const string Propertyfield = "field";
        private const string FieldaggregateTypesField = "aggregateTypesField";
        private const string FieldfieldField = "fieldField";
        private Type _reportColumnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportColumn _reportColumnInstance;
        private ReportColumn _reportColumnInstanceFixture;

        #region General Initializer : Class (ReportColumn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportColumn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportColumnInstanceType = typeof(ReportColumn);
            _reportColumnInstanceFixture = Create(true);
            _reportColumnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportColumn)

        #region General Initializer : Class (ReportColumn) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportColumn" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaggregateTypes)]
        [TestCase(Propertyfield)]
        public void AUT_ReportColumn_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportColumnInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportColumn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportColumn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaggregateTypesField)]
        [TestCase(FieldfieldField)]
        public void AUT_ReportColumn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportColumnInstanceFixture, 
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
        ///     Class (<see cref="ReportColumn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportColumn_Is_Instance_Present_Test()
        {
            // Assert
            _reportColumnInstanceType.ShouldNotBeNull();
            _reportColumnInstance.ShouldNotBeNull();
            _reportColumnInstanceFixture.ShouldNotBeNull();
            _reportColumnInstance.ShouldBeAssignableTo<ReportColumn>();
            _reportColumnInstanceFixture.ShouldBeAssignableTo<ReportColumn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportColumn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportColumn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportColumn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportColumnInstanceType.ShouldNotBeNull();
            _reportColumnInstance.ShouldNotBeNull();
            _reportColumnInstanceFixture.ShouldNotBeNull();
            _reportColumnInstance.ShouldBeAssignableTo<ReportColumn>();
            _reportColumnInstanceFixture.ShouldBeAssignableTo<ReportColumn>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportColumn) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportSummaryType[]) , PropertyaggregateTypes)]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        public void AUT_ReportColumn_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportColumn, T>(_reportColumnInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportColumn) => Property (aggregateTypes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColumn_aggregateTypes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyaggregateTypes);
            Action currentAction = () => propertyInfo.SetValue(_reportColumnInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportColumn) => Property (aggregateTypes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColumn_Public_Class_aggregateTypes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaggregateTypes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportColumn) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColumn_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

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