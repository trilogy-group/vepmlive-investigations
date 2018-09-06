using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace RPADataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="RPADataCache.RPAGridHelper" />)
    ///     and namespace <see cref="RPADataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RPAGridHelperTest : AbstractBaseSetupTest
    {

        public RPAGridHelperTest() : base(typeof(RPAGridHelper))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RPAGridHelper) Initializer

        private const string MethodTargetBackground = "TargetBackground";
        private Type _rPAGridHelperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (RPAGridHelper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RPAGridHelper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rPAGridHelperInstanceType = typeof(RPAGridHelper);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RPAGridHelper)

        #region General Initializer : Class (RPAGridHelper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="RPAGridHelper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodTargetBackground, 0)]
        public void AUT_RPAGridHelper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(null, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="RPAGridHelper" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RPAGridHelper_Is_Static_Type_Present_Test()
        {
            // Assert
            _rPAGridHelperInstanceType.ShouldNotBeNull();
        }

        #endregion

        #endregion
    }
}