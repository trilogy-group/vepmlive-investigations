using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace CostDataValues
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsPeriodData" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsPeriodDataTest : AbstractBaseSetupTypedTest<clsPeriodData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsPeriodData) Initializer

        private const string PropertyFinishDate = "FinishDate";
        private const string PropertyPeriodID = "PeriodID";
        private const string PropertyPeriodName = "PeriodName";
        private const string PropertyStartDate = "StartDate";
        private Type _clsPeriodDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsPeriodData _clsPeriodDataInstance;
        private clsPeriodData _clsPeriodDataInstanceFixture;

        #region General Initializer : Class (clsPeriodData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsPeriodData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsPeriodDataInstanceType = typeof(clsPeriodData);
            _clsPeriodDataInstanceFixture = Create(true);
            _clsPeriodDataInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="clsPeriodData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsPeriodData_Is_Instance_Present_Test()
        {
            // Assert
            _clsPeriodDataInstanceType.ShouldNotBeNull();
            _clsPeriodDataInstance.ShouldNotBeNull();
            _clsPeriodDataInstanceFixture.ShouldNotBeNull();
            _clsPeriodDataInstance.ShouldBeAssignableTo<clsPeriodData>();
            _clsPeriodDataInstanceFixture.ShouldBeAssignableTo<clsPeriodData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsPeriodData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_clsPeriodData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            clsPeriodData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _clsPeriodDataInstanceType.ShouldNotBeNull();
            _clsPeriodDataInstance.ShouldNotBeNull();
            _clsPeriodDataInstanceFixture.ShouldNotBeNull();
            _clsPeriodDataInstance.ShouldBeAssignableTo<clsPeriodData>();
            _clsPeriodDataInstanceFixture.ShouldBeAssignableTo<clsPeriodData>();
        }

        #endregion

        #endregion

        #endregion
    }
}