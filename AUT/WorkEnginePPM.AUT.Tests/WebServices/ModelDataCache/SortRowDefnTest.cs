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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.SortRowDefn" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SortRowDefnTest : AbstractBaseSetupTypedTest<SortRowDefn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SortRowDefn) Initializer

        private const string Fieldfid = "fid";
        private const string Fielddecf = "decf";
        private const string Fieldgrpf = "grpf";
        private Type _sortRowDefnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SortRowDefn _sortRowDefnInstance;
        private SortRowDefn _sortRowDefnInstanceFixture;

        #region General Initializer : Class (SortRowDefn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SortRowDefn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sortRowDefnInstanceType = typeof(SortRowDefn);
            _sortRowDefnInstanceFixture = Create(true);
            _sortRowDefnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SortRowDefn)

        #region General Initializer : Class (SortRowDefn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SortRowDefn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldfid)]
        [TestCase(Fielddecf)]
        [TestCase(Fieldgrpf)]
        public void AUT_SortRowDefn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sortRowDefnInstanceFixture, 
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
        ///     Class (<see cref="SortRowDefn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SortRowDefn_Is_Instance_Present_Test()
        {
            // Assert
            _sortRowDefnInstanceType.ShouldNotBeNull();
            _sortRowDefnInstance.ShouldNotBeNull();
            _sortRowDefnInstanceFixture.ShouldNotBeNull();
            _sortRowDefnInstance.ShouldBeAssignableTo<SortRowDefn>();
            _sortRowDefnInstanceFixture.ShouldBeAssignableTo<SortRowDefn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SortRowDefn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SortRowDefn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SortRowDefn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sortRowDefnInstanceType.ShouldNotBeNull();
            _sortRowDefnInstance.ShouldNotBeNull();
            _sortRowDefnInstanceFixture.ShouldNotBeNull();
            _sortRowDefnInstance.ShouldBeAssignableTo<SortRowDefn>();
            _sortRowDefnInstanceFixture.ShouldBeAssignableTo<SortRowDefn>();
        }

        #endregion

        #endregion

        #endregion
    }
}