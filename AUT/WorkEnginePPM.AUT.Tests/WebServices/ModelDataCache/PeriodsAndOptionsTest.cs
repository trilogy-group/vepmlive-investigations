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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.PeriodsAndOptions" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PeriodsAndOptionsTest : AbstractBaseSetupTypedTest<PeriodsAndOptions>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PeriodsAndOptions) Initializer

        private const string FieldPeriods = "Periods";
        private const string FielddisplayStart = "displayStart";
        private Type _periodsAndOptionsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PeriodsAndOptions _periodsAndOptionsInstance;
        private PeriodsAndOptions _periodsAndOptionsInstanceFixture;

        #region General Initializer : Class (PeriodsAndOptions) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PeriodsAndOptions" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _periodsAndOptionsInstanceType = typeof(PeriodsAndOptions);
            _periodsAndOptionsInstanceFixture = Create(true);
            _periodsAndOptionsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PeriodsAndOptions)

        #region General Initializer : Class (PeriodsAndOptions) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PeriodsAndOptions" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldPeriods)]
        [TestCase(FielddisplayStart)]
        public void AUT_PeriodsAndOptions_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_periodsAndOptionsInstanceFixture, 
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
        ///     Class (<see cref="PeriodsAndOptions" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PeriodsAndOptions_Is_Instance_Present_Test()
        {
            // Assert
            _periodsAndOptionsInstanceType.ShouldNotBeNull();
            _periodsAndOptionsInstance.ShouldNotBeNull();
            _periodsAndOptionsInstanceFixture.ShouldNotBeNull();
            _periodsAndOptionsInstance.ShouldBeAssignableTo<PeriodsAndOptions>();
            _periodsAndOptionsInstanceFixture.ShouldBeAssignableTo<PeriodsAndOptions>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PeriodsAndOptions) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PeriodsAndOptions_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PeriodsAndOptions instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _periodsAndOptionsInstanceType.ShouldNotBeNull();
            _periodsAndOptionsInstance.ShouldNotBeNull();
            _periodsAndOptionsInstanceFixture.ShouldNotBeNull();
            _periodsAndOptionsInstance.ShouldBeAssignableTo<PeriodsAndOptions>();
            _periodsAndOptionsInstanceFixture.ShouldBeAssignableTo<PeriodsAndOptions>();
        }

        #endregion

        #endregion

        #endregion
    }
}