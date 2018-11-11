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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.CSCategoryEntry" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CSCategoryEntryTest : AbstractBaseSetupTypedTest<CSCategoryEntry>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CSCategoryEntry) Initializer

        private const string FieldUID = "UID";
        private const string FieldName = "Name";
        private const string FieldRates = "Rates";
        private Type _cSCategoryEntryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CSCategoryEntry _cSCategoryEntryInstance;
        private CSCategoryEntry _cSCategoryEntryInstanceFixture;

        #region General Initializer : Class (CSCategoryEntry) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CSCategoryEntry" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cSCategoryEntryInstanceType = typeof(CSCategoryEntry);
            _cSCategoryEntryInstanceFixture = Create(true);
            _cSCategoryEntryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CSCategoryEntry)

        #region General Initializer : Class (CSCategoryEntry) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CSCategoryEntry" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldUID)]
        [TestCase(FieldName)]
        [TestCase(FieldRates)]
        public void AUT_CSCategoryEntry_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cSCategoryEntryInstanceFixture, 
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
        ///     Class (<see cref="CSCategoryEntry" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CSCategoryEntry_Is_Instance_Present_Test()
        {
            // Assert
            _cSCategoryEntryInstanceType.ShouldNotBeNull();
            _cSCategoryEntryInstance.ShouldNotBeNull();
            _cSCategoryEntryInstanceFixture.ShouldNotBeNull();
            _cSCategoryEntryInstance.ShouldBeAssignableTo<CSCategoryEntry>();
            _cSCategoryEntryInstanceFixture.ShouldBeAssignableTo<CSCategoryEntry>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CSCategoryEntry) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CSCategoryEntry_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CSCategoryEntry instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _cSCategoryEntryInstanceType.ShouldNotBeNull();
            _cSCategoryEntryInstance.ShouldNotBeNull();
            _cSCategoryEntryInstanceFixture.ShouldNotBeNull();
            _cSCategoryEntryInstance.ShouldBeAssignableTo<CSCategoryEntry>();
            _cSCategoryEntryInstanceFixture.ShouldBeAssignableTo<CSCategoryEntry>();
        }

        #endregion

        #endregion

        #endregion
    }
}