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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportTypeColumnTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportTypeColumnTranslationTest : AbstractBaseSetupTypedTest<ReportTypeColumnTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportTypeColumnTranslation) Initializer

        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private Type _reportTypeColumnTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportTypeColumnTranslation _reportTypeColumnTranslationInstance;
        private ReportTypeColumnTranslation _reportTypeColumnTranslationInstanceFixture;

        #region General Initializer : Class (ReportTypeColumnTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportTypeColumnTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportTypeColumnTranslationInstanceType = typeof(ReportTypeColumnTranslation);
            _reportTypeColumnTranslationInstanceFixture = Create(true);
            _reportTypeColumnTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportTypeColumnTranslation)

        #region General Initializer : Class (ReportTypeColumnTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportTypeColumnTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        public void AUT_ReportTypeColumnTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportTypeColumnTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportTypeColumnTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportTypeColumnTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        public void AUT_ReportTypeColumnTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportTypeColumnTranslationInstanceFixture, 
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
        ///     Class (<see cref="ReportTypeColumnTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportTypeColumnTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _reportTypeColumnTranslationInstanceType.ShouldNotBeNull();
            _reportTypeColumnTranslationInstance.ShouldNotBeNull();
            _reportTypeColumnTranslationInstanceFixture.ShouldNotBeNull();
            _reportTypeColumnTranslationInstance.ShouldBeAssignableTo<ReportTypeColumnTranslation>();
            _reportTypeColumnTranslationInstanceFixture.ShouldBeAssignableTo<ReportTypeColumnTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportTypeColumnTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportTypeColumnTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportTypeColumnTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportTypeColumnTranslationInstanceType.ShouldNotBeNull();
            _reportTypeColumnTranslationInstance.ShouldNotBeNull();
            _reportTypeColumnTranslationInstanceFixture.ShouldNotBeNull();
            _reportTypeColumnTranslationInstance.ShouldBeAssignableTo<ReportTypeColumnTranslation>();
            _reportTypeColumnTranslationInstanceFixture.ShouldBeAssignableTo<ReportTypeColumnTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportTypeColumnTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_ReportTypeColumnTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportTypeColumnTranslation, T>(_reportTypeColumnTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportTypeColumnTranslation) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeColumnTranslation_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportTypeColumnTranslation) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeColumnTranslation_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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