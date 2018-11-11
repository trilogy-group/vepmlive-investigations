using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.WEFeatures" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class WEFeaturesTest : AbstractBaseSetupTest
    {
        public WEFeaturesTest() : base(typeof(WEFeatures))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WEFeatures) Initializer

        private const string FieldBuildTeam = "BuildTeam";
        private const string FieldWEWebParts = "WEWebParts";
        private const string FieldSocialStream = "SocialStream";
        private Type _wEFeaturesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (WEFeatures) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WEFeatures" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _wEFeaturesInstanceType = typeof(WEFeatures);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WEFeatures)

        #region General Initializer : Class (WEFeatures) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WEFeatures" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldBuildTeam)]
        [TestCase(FieldWEWebParts)]
        [TestCase(FieldSocialStream)]
        public void AUT_WEFeatures_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="WEFeatures" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_WEFeatures_Is_Static_Type_Present_Test()
        {
            // Assert
            _wEFeaturesInstanceType.ShouldNotBeNull();
        }

        #endregion

        #endregion
    }
}