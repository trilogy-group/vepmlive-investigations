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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.SortFieldDefn" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SortFieldDefnTest : AbstractBaseSetupTypedTest<SortFieldDefn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SortFieldDefn) Initializer

        private const string Fieldfid = "fid";
        private const string Fieldname = "name";
        private const string Fieldselected = "selected";
        private const string Fieldtouched = "touched";
        private Type _sortFieldDefnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SortFieldDefn _sortFieldDefnInstance;
        private SortFieldDefn _sortFieldDefnInstanceFixture;

        #region General Initializer : Class (SortFieldDefn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SortFieldDefn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sortFieldDefnInstanceType = typeof(SortFieldDefn);
            _sortFieldDefnInstanceFixture = Create(true);
            _sortFieldDefnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SortFieldDefn)

        #region General Initializer : Class (SortFieldDefn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SortFieldDefn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldfid)]
        [TestCase(Fieldname)]
        [TestCase(Fieldselected)]
        [TestCase(Fieldtouched)]
        public void AUT_SortFieldDefn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sortFieldDefnInstanceFixture, 
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
        ///     Class (<see cref="SortFieldDefn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SortFieldDefn_Is_Instance_Present_Test()
        {
            // Assert
            _sortFieldDefnInstanceType.ShouldNotBeNull();
            _sortFieldDefnInstance.ShouldNotBeNull();
            _sortFieldDefnInstanceFixture.ShouldNotBeNull();
            _sortFieldDefnInstance.ShouldBeAssignableTo<SortFieldDefn>();
            _sortFieldDefnInstanceFixture.ShouldBeAssignableTo<SortFieldDefn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SortFieldDefn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SortFieldDefn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SortFieldDefn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sortFieldDefnInstanceType.ShouldNotBeNull();
            _sortFieldDefnInstance.ShouldNotBeNull();
            _sortFieldDefnInstanceFixture.ShouldNotBeNull();
            _sortFieldDefnInstance.ShouldBeAssignableTo<SortFieldDefn>();
            _sortFieldDefnInstanceFixture.ShouldBeAssignableTo<SortFieldDefn>();
        }

        #endregion

        #endregion

        #endregion
    }
}