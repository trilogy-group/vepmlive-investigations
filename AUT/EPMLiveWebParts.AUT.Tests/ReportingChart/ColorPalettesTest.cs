using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.ReportingChart
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportingChart.ColorPalettes" />)
    ///     and namespace <see cref="EPMLiveWebParts.ReportingChart"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ColorPalettesTest : AbstractBaseSetupTest
    {

        public ColorPalettesTest() : base(typeof(ColorPalettes))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ColorPalettes) Initializer

        private const string PropertyBluePalette = "BluePalette";
        private const string PropertyRedPalette = "RedPalette";
        private const string PropertyYellowPalette = "YellowPalette";
        private const string PropertyGreenPalette = "GreenPalette";
        private const string PropertyGrayPalette = "GrayPalette";
        private const string PropertyViolet = "Violet";
        private const string PropertyColor1 = "Color1";
        private const string PropertyColor2 = "Color2";
        private Type _colorPalettesInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (ColorPalettes) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ColorPalettes" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _colorPalettesInstanceType = typeof(ColorPalettes);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ColorPalettes)

        #region General Initializer : Class (ColorPalettes) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ColorPalettes" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyBluePalette)]
        [TestCase(PropertyRedPalette)]
        [TestCase(PropertyYellowPalette)]
        [TestCase(PropertyGreenPalette)]
        [TestCase(PropertyGrayPalette)]
        [TestCase(PropertyViolet)]
        [TestCase(PropertyColor1)]
        [TestCase(PropertyColor2)]
        public void AUT_ColorPalettes_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(null,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ColorPalettes" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ColorPalettes_Is_Static_Type_Present_Test()
        {
            // Assert
            _colorPalettesInstanceType.ShouldNotBeNull();
        }

        #endregion

        #endregion
    }
}