using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportTypeColumn" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportTypeColumnTest : AbstractBaseSetupTypedTest<ReportTypeColumn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportTypeColumn) Initializer

        private const string PropertycheckedByDefault = "checkedByDefault";
        private const string PropertydisplayNameOverride = "displayNameOverride";
        private const string Propertyfield = "field";
        private const string Propertytable = "table";
        private const string FieldcheckedByDefaultField = "checkedByDefaultField";
        private const string FielddisplayNameOverrideField = "displayNameOverrideField";
        private const string FieldfieldField = "fieldField";
        private const string FieldtableField = "tableField";
        private Type _reportTypeColumnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportTypeColumn _reportTypeColumnInstance;
        private ReportTypeColumn _reportTypeColumnInstanceFixture;

        #region General Initializer : Class (ReportTypeColumn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportTypeColumn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportTypeColumnInstanceType = typeof(ReportTypeColumn);
            _reportTypeColumnInstanceFixture = Create(true);
            _reportTypeColumnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportTypeColumn)

        #region General Initializer : Class (ReportTypeColumn) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportTypeColumn" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycheckedByDefault)]
        [TestCase(PropertydisplayNameOverride)]
        [TestCase(Propertyfield)]
        [TestCase(Propertytable)]
        public void AUT_ReportTypeColumn_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportTypeColumnInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportTypeColumn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportTypeColumn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcheckedByDefaultField)]
        [TestCase(FielddisplayNameOverrideField)]
        [TestCase(FieldfieldField)]
        [TestCase(FieldtableField)]
        public void AUT_ReportTypeColumn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportTypeColumnInstanceFixture, 
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
        ///     Class (<see cref="ReportTypeColumn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportTypeColumn_Is_Instance_Present_Test()
        {
            // Assert
            _reportTypeColumnInstanceType.ShouldNotBeNull();
            _reportTypeColumnInstance.ShouldNotBeNull();
            _reportTypeColumnInstanceFixture.ShouldNotBeNull();
            _reportTypeColumnInstance.ShouldBeAssignableTo<ReportTypeColumn>();
            _reportTypeColumnInstanceFixture.ShouldBeAssignableTo<ReportTypeColumn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportTypeColumn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportTypeColumn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportTypeColumn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportTypeColumnInstanceType.ShouldNotBeNull();
            _reportTypeColumnInstance.ShouldNotBeNull();
            _reportTypeColumnInstanceFixture.ShouldNotBeNull();
            _reportTypeColumnInstance.ShouldBeAssignableTo<ReportTypeColumn>();
            _reportTypeColumnInstanceFixture.ShouldBeAssignableTo<ReportTypeColumn>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportTypeColumn) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertycheckedByDefault)]
        [TestCaseGeneric(typeof(string) , PropertydisplayNameOverride)]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(string) , Propertytable)]
        public void AUT_ReportTypeColumn_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportTypeColumn, T>(_reportTypeColumnInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportTypeColumn) => Property (checkedByDefault) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeColumn_Public_Class_checkedByDefault_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycheckedByDefault);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportTypeColumn) => Property (displayNameOverride) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeColumn_Public_Class_displayNameOverride_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayNameOverride);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportTypeColumn) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeColumn_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportTypeColumn) => Property (table) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeColumn_Public_Class_table_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytable);

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