using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace CostDataValues
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="CostDataValues.clsRateFTECache" />)
    ///     and namespace <see cref="CostDataValues"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ClsRateFTECacheTest : AbstractBaseSetupTypedTest<clsRateFTECache>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (clsRateFTECache) Initializer

        private const string FieldzRate = "zRate";
        private const string Fieldmxdim = "mxdim";
        private Type _clsRateFTECacheInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private clsRateFTECache _clsRateFTECacheInstance;
        private clsRateFTECache _clsRateFTECacheInstanceFixture;

        #region General Initializer : Class (clsRateFTECache) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="clsRateFTECache" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _clsRateFTECacheInstanceType = typeof(clsRateFTECache);
            _clsRateFTECacheInstanceFixture = Create(true);
            _clsRateFTECacheInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (clsRateFTECache)

        #region General Initializer : Class (clsRateFTECache) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="clsRateFTECache" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldzRate)]
        [TestCase(Fieldmxdim)]
        public void AUT_ClsRateFTECache_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_clsRateFTECacheInstanceFixture, 
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
        ///     Class (<see cref="clsRateFTECache" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_ClsRateFTECache_Is_Instance_Present_Test()
        {
            // Assert
            _clsRateFTECacheInstanceType.ShouldNotBeNull();
            _clsRateFTECacheInstance.ShouldNotBeNull();
            _clsRateFTECacheInstanceFixture.ShouldNotBeNull();
            _clsRateFTECacheInstance.ShouldBeAssignableTo<clsRateFTECache>();
            _clsRateFTECacheInstanceFixture.ShouldBeAssignableTo<clsRateFTECache>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (clsRateFTECache) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClsRateFTECache_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var arraysize = CreateType<int>();
            clsRateFTECache instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new clsRateFTECache(arraysize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _clsRateFTECacheInstance.ShouldNotBeNull();
            _clsRateFTECacheInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<clsRateFTECache>();
        }

        #endregion

        #region General Constructor : Class (clsRateFTECache) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_ClsRateFTECache_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var arraysize = CreateType<int>();
            clsRateFTECache instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new clsRateFTECache(arraysize);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _clsRateFTECacheInstance.ShouldNotBeNull();
            _clsRateFTECacheInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #endregion
    }
}