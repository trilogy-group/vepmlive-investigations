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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.CSNamedRate" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CSNamedRateTest : AbstractBaseSetupTypedTest<CSNamedRate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CSNamedRate) Initializer

        private const string FieldUID = "UID";
        private const string FieldName = "Name";
        private const string FieldRates = "Rates";
        private Type _cSNamedRateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CSNamedRate _cSNamedRateInstance;
        private CSNamedRate _cSNamedRateInstanceFixture;

        #region General Initializer : Class (CSNamedRate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CSNamedRate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cSNamedRateInstanceType = typeof(CSNamedRate);
            _cSNamedRateInstanceFixture = Create(true);
            _cSNamedRateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CSNamedRate)

        #region General Initializer : Class (CSNamedRate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CSNamedRate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldUID)]
        [TestCase(FieldName)]
        [TestCase(FieldRates)]
        public void AUT_CSNamedRate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cSNamedRateInstanceFixture, 
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
        ///     Class (<see cref="CSNamedRate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CSNamedRate_Is_Instance_Present_Test()
        {
            // Assert
            _cSNamedRateInstanceType.ShouldNotBeNull();
            _cSNamedRateInstance.ShouldNotBeNull();
            _cSNamedRateInstanceFixture.ShouldNotBeNull();
            _cSNamedRateInstance.ShouldBeAssignableTo<CSNamedRate>();
            _cSNamedRateInstanceFixture.ShouldBeAssignableTo<CSNamedRate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CSNamedRate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CSNamedRate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CSNamedRate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _cSNamedRateInstanceType.ShouldNotBeNull();
            _cSNamedRateInstance.ShouldNotBeNull();
            _cSNamedRateInstanceFixture.ShouldNotBeNull();
            _cSNamedRateInstance.ShouldBeAssignableTo<CSNamedRate>();
            _cSNamedRateInstanceFixture.ShouldBeAssignableTo<CSNamedRate>();
        }

        #endregion

        #endregion

        #endregion
    }
}