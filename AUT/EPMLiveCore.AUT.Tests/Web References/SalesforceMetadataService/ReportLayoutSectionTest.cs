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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportLayoutSection" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportLayoutSectionTest : AbstractBaseSetupTypedTest<ReportLayoutSection>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportLayoutSection) Initializer

        private const string Propertycolumns = "columns";
        private const string PropertymasterLabel = "masterLabel";
        private const string FieldcolumnsField = "columnsField";
        private const string FieldmasterLabelField = "masterLabelField";
        private Type _reportLayoutSectionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportLayoutSection _reportLayoutSectionInstance;
        private ReportLayoutSection _reportLayoutSectionInstanceFixture;

        #region General Initializer : Class (ReportLayoutSection) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportLayoutSection" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportLayoutSectionInstanceType = typeof(ReportLayoutSection);
            _reportLayoutSectionInstanceFixture = Create(true);
            _reportLayoutSectionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportLayoutSection)

        #region General Initializer : Class (ReportLayoutSection) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportLayoutSection" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycolumns)]
        [TestCase(PropertymasterLabel)]
        public void AUT_ReportLayoutSection_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportLayoutSectionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportLayoutSection) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportLayoutSection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcolumnsField)]
        [TestCase(FieldmasterLabelField)]
        public void AUT_ReportLayoutSection_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportLayoutSectionInstanceFixture, 
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
        ///     Class (<see cref="ReportLayoutSection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportLayoutSection_Is_Instance_Present_Test()
        {
            // Assert
            _reportLayoutSectionInstanceType.ShouldNotBeNull();
            _reportLayoutSectionInstance.ShouldNotBeNull();
            _reportLayoutSectionInstanceFixture.ShouldNotBeNull();
            _reportLayoutSectionInstance.ShouldBeAssignableTo<ReportLayoutSection>();
            _reportLayoutSectionInstanceFixture.ShouldBeAssignableTo<ReportLayoutSection>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportLayoutSection) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportLayoutSection_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportLayoutSection instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportLayoutSectionInstanceType.ShouldNotBeNull();
            _reportLayoutSectionInstance.ShouldNotBeNull();
            _reportLayoutSectionInstanceFixture.ShouldNotBeNull();
            _reportLayoutSectionInstance.ShouldBeAssignableTo<ReportLayoutSection>();
            _reportLayoutSectionInstanceFixture.ShouldBeAssignableTo<ReportLayoutSection>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportLayoutSection) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportTypeColumn[]) , Propertycolumns)]
        [TestCaseGeneric(typeof(string) , PropertymasterLabel)]
        public void AUT_ReportLayoutSection_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportLayoutSection, T>(_reportLayoutSectionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportLayoutSection) => Property (columns) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportLayoutSection_columns_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycolumns);
            Action currentAction = () => propertyInfo.SetValue(_reportLayoutSectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportLayoutSection) => Property (columns) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportLayoutSection_Public_Class_columns_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportLayoutSection) => Property (masterLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportLayoutSection_Public_Class_masterLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymasterLabel);

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