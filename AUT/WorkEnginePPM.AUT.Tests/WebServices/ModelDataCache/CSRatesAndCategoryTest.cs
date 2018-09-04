using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace ModelDataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.CSRatesAndCategory" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CSRatesAndCategoryTest : AbstractBaseSetupTypedTest<CSRatesAndCategory>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CSRatesAndCategory) Initializer

        private const string FieldnumberPeriods = "numberPeriods";
        private const string FieldNamedRates = "NamedRates";
        private const string FieldCategories = "Categories";
        private const string FieldCatjsonMenu = "CatjsonMenu";
        private const string FieldVersions = "Versions";
        private const string FieldCostTypes = "CostTypes";
        private const string FieldCustomFields = "CustomFields";
        private Type _cSRatesAndCategoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CSRatesAndCategory _cSRatesAndCategoryInstance;
        private CSRatesAndCategory _cSRatesAndCategoryInstanceFixture;

        #region General Initializer : Class (CSRatesAndCategory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CSRatesAndCategory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cSRatesAndCategoryInstanceType = typeof(CSRatesAndCategory);
            _cSRatesAndCategoryInstanceFixture = Create(true);
            _cSRatesAndCategoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CSRatesAndCategory)

        #region General Initializer : Class (CSRatesAndCategory) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CSRatesAndCategory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldnumberPeriods)]
        [TestCase(FieldNamedRates)]
        [TestCase(FieldCategories)]
        [TestCase(FieldCatjsonMenu)]
        [TestCase(FieldVersions)]
        [TestCase(FieldCostTypes)]
        [TestCase(FieldCustomFields)]
        public void AUT_CSRatesAndCategory_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cSRatesAndCategoryInstanceFixture, 
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
        ///     Class (<see cref="CSRatesAndCategory" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CSRatesAndCategory_Is_Instance_Present_Test()
        {
            // Assert
            _cSRatesAndCategoryInstanceType.ShouldNotBeNull();
            _cSRatesAndCategoryInstance.ShouldNotBeNull();
            _cSRatesAndCategoryInstanceFixture.ShouldNotBeNull();
            _cSRatesAndCategoryInstance.ShouldBeAssignableTo<CSRatesAndCategory>();
            _cSRatesAndCategoryInstanceFixture.ShouldBeAssignableTo<CSRatesAndCategory>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CSRatesAndCategory) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CSRatesAndCategory_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CSRatesAndCategory instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _cSRatesAndCategoryInstanceType.ShouldNotBeNull();
            _cSRatesAndCategoryInstance.ShouldNotBeNull();
            _cSRatesAndCategoryInstanceFixture.ShouldNotBeNull();
            _cSRatesAndCategoryInstance.ShouldBeAssignableTo<CSRatesAndCategory>();
            _cSRatesAndCategoryInstanceFixture.ShouldBeAssignableTo<CSRatesAndCategory>();
        }

        #endregion

        #endregion

        #endregion
    }
}