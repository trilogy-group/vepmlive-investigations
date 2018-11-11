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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.SortGroupDefn" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SortGroupDefnTest : AbstractBaseSetupTypedTest<SortGroupDefn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SortGroupDefn) Initializer

        private const string FieldDetRows = "DetRows";
        private const string FieldTotRows = "TotRows";
        private const string FieldDetFields = "DetFields";
        private const string FieldDetFreeze = "DetFreeze";
        private const string FieldNumPIs = "NumPIs";
        private const string FielderrMsg = "errMsg";
        private const string FieldTotalsCmp = "TotalsCmp";
        private const string FieldViewZoomTo = "ViewZoomTo";
        private Type _sortGroupDefnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SortGroupDefn _sortGroupDefnInstance;
        private SortGroupDefn _sortGroupDefnInstanceFixture;

        #region General Initializer : Class (SortGroupDefn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SortGroupDefn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sortGroupDefnInstanceType = typeof(SortGroupDefn);
            _sortGroupDefnInstanceFixture = Create(true);
            _sortGroupDefnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SortGroupDefn)

        #region General Initializer : Class (SortGroupDefn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SortGroupDefn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldDetRows)]
        [TestCase(FieldTotRows)]
        [TestCase(FieldDetFields)]
        [TestCase(FieldDetFreeze)]
        [TestCase(FieldNumPIs)]
        [TestCase(FielderrMsg)]
        [TestCase(FieldTotalsCmp)]
        [TestCase(FieldViewZoomTo)]
        public void AUT_SortGroupDefn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sortGroupDefnInstanceFixture, 
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
        ///     Class (<see cref="SortGroupDefn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SortGroupDefn_Is_Instance_Present_Test()
        {
            // Assert
            _sortGroupDefnInstanceType.ShouldNotBeNull();
            _sortGroupDefnInstance.ShouldNotBeNull();
            _sortGroupDefnInstanceFixture.ShouldNotBeNull();
            _sortGroupDefnInstance.ShouldBeAssignableTo<SortGroupDefn>();
            _sortGroupDefnInstanceFixture.ShouldBeAssignableTo<SortGroupDefn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SortGroupDefn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SortGroupDefn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SortGroupDefn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sortGroupDefnInstanceType.ShouldNotBeNull();
            _sortGroupDefnInstance.ShouldNotBeNull();
            _sortGroupDefnInstanceFixture.ShouldNotBeNull();
            _sortGroupDefnInstance.ShouldBeAssignableTo<SortGroupDefn>();
            _sortGroupDefnInstanceFixture.ShouldBeAssignableTo<SortGroupDefn>();
        }

        #endregion

        #endregion

        #endregion
    }
}