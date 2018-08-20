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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportTypeSectionTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportTypeSectionTranslationTest : AbstractBaseSetupTypedTest<ReportTypeSectionTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportTypeSectionTranslation) Initializer

        private const string Propertycolumns = "columns";
        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string FieldcolumnsField = "columnsField";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private Type _reportTypeSectionTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportTypeSectionTranslation _reportTypeSectionTranslationInstance;
        private ReportTypeSectionTranslation _reportTypeSectionTranslationInstanceFixture;

        #region General Initializer : Class (ReportTypeSectionTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportTypeSectionTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportTypeSectionTranslationInstanceType = typeof(ReportTypeSectionTranslation);
            _reportTypeSectionTranslationInstanceFixture = Create(true);
            _reportTypeSectionTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportTypeSectionTranslation)

        #region General Initializer : Class (ReportTypeSectionTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportTypeSectionTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycolumns)]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        public void AUT_ReportTypeSectionTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportTypeSectionTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportTypeSectionTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportTypeSectionTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcolumnsField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        public void AUT_ReportTypeSectionTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportTypeSectionTranslationInstanceFixture, 
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
        ///     Class (<see cref="ReportTypeSectionTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportTypeSectionTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _reportTypeSectionTranslationInstanceType.ShouldNotBeNull();
            _reportTypeSectionTranslationInstance.ShouldNotBeNull();
            _reportTypeSectionTranslationInstanceFixture.ShouldNotBeNull();
            _reportTypeSectionTranslationInstance.ShouldBeAssignableTo<ReportTypeSectionTranslation>();
            _reportTypeSectionTranslationInstanceFixture.ShouldBeAssignableTo<ReportTypeSectionTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportTypeSectionTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportTypeSectionTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportTypeSectionTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportTypeSectionTranslationInstanceType.ShouldNotBeNull();
            _reportTypeSectionTranslationInstance.ShouldNotBeNull();
            _reportTypeSectionTranslationInstanceFixture.ShouldNotBeNull();
            _reportTypeSectionTranslationInstance.ShouldBeAssignableTo<ReportTypeSectionTranslation>();
            _reportTypeSectionTranslationInstanceFixture.ShouldBeAssignableTo<ReportTypeSectionTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportTypeSectionTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportTypeColumnTranslation[]) , Propertycolumns)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_ReportTypeSectionTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportTypeSectionTranslation, T>(_reportTypeSectionTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportTypeSectionTranslation) => Property (columns) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeSectionTranslation_columns_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycolumns);
            Action currentAction = () => propertyInfo.SetValue(_reportTypeSectionTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportTypeSectionTranslation) => Property (columns) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeSectionTranslation_Public_Class_columns_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportTypeSectionTranslation) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeSectionTranslation_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportTypeSectionTranslation) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeSectionTranslation_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}