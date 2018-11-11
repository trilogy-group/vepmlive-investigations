using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace RPADataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="RPADataCache.RPAColumnFieldDefn" />)
    ///     and namespace <see cref="RPADataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class RPAColumnFieldDefnTest : AbstractBaseSetupTypedTest<RPAColumnFieldDefn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RPAColumnFieldDefn) Initializer

        private const string Fieldfid = "fid";
        private const string Fieldname = "name";
        private const string Fieldselected = "selected";
        private Type _rPAColumnFieldDefnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RPAColumnFieldDefn _rPAColumnFieldDefnInstance;
        private RPAColumnFieldDefn _rPAColumnFieldDefnInstanceFixture;

        #region General Initializer : Class (RPAColumnFieldDefn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RPAColumnFieldDefn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _rPAColumnFieldDefnInstanceType = typeof(RPAColumnFieldDefn);
            _rPAColumnFieldDefnInstanceFixture = Create(true);
            _rPAColumnFieldDefnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RPAColumnFieldDefn)

        #region General Initializer : Class (RPAColumnFieldDefn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RPAColumnFieldDefn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldfid)]
        [TestCase(Fieldname)]
        [TestCase(Fieldselected)]
        public void AUT_RPAColumnFieldDefn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_rPAColumnFieldDefnInstanceFixture, 
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
        ///     Class (<see cref="RPAColumnFieldDefn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_RPAColumnFieldDefn_Is_Instance_Present_Test()
        {
            // Assert
            _rPAColumnFieldDefnInstanceType.ShouldNotBeNull();
            _rPAColumnFieldDefnInstance.ShouldNotBeNull();
            _rPAColumnFieldDefnInstanceFixture.ShouldNotBeNull();
            _rPAColumnFieldDefnInstance.ShouldBeAssignableTo<RPAColumnFieldDefn>();
            _rPAColumnFieldDefnInstanceFixture.ShouldBeAssignableTo<RPAColumnFieldDefn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RPAColumnFieldDefn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_RPAColumnFieldDefn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RPAColumnFieldDefn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _rPAColumnFieldDefnInstanceType.ShouldNotBeNull();
            _rPAColumnFieldDefnInstance.ShouldNotBeNull();
            _rPAColumnFieldDefnInstanceFixture.ShouldNotBeNull();
            _rPAColumnFieldDefnInstance.ShouldBeAssignableTo<RPAColumnFieldDefn>();
            _rPAColumnFieldDefnInstanceFixture.ShouldBeAssignableTo<RPAColumnFieldDefn>();
        }

        #endregion

        #endregion

        #endregion
    }
}