using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace ClientPrioritizationDataCache
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ClientPrioritizationDataCache.PriItemDefn" />)
    ///     and namespace <see cref="ClientPrioritizationDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PriItemDefnTest : AbstractBaseSetupTypedTest<PriItemDefn>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PriItemDefn) Initializer

        private const string Fieldfid = "fid";
        private const string FieldName = "Name";
        private Type _priItemDefnInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PriItemDefn _priItemDefnInstance;
        private PriItemDefn _priItemDefnInstanceFixture;

        #region General Initializer : Class (PriItemDefn) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PriItemDefn" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _priItemDefnInstanceType = typeof(PriItemDefn);
            _priItemDefnInstanceFixture = Create(true);
            _priItemDefnInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PriItemDefn)

        #region General Initializer : Class (PriItemDefn) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PriItemDefn" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldfid)]
        [TestCase(FieldName)]
        public void AUT_PriItemDefn_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_priItemDefnInstanceFixture, 
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
        ///     Class (<see cref="PriItemDefn" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PriItemDefn_Is_Instance_Present_Test()
        {
            // Assert
            _priItemDefnInstanceType.ShouldNotBeNull();
            _priItemDefnInstance.ShouldNotBeNull();
            _priItemDefnInstanceFixture.ShouldNotBeNull();
            _priItemDefnInstance.ShouldBeAssignableTo<PriItemDefn>();
            _priItemDefnInstanceFixture.ShouldBeAssignableTo<PriItemDefn>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PriItemDefn) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PriItemDefn_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PriItemDefn instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _priItemDefnInstanceType.ShouldNotBeNull();
            _priItemDefnInstance.ShouldNotBeNull();
            _priItemDefnInstanceFixture.ShouldNotBeNull();
            _priItemDefnInstance.ShouldBeAssignableTo<PriItemDefn>();
            _priItemDefnInstanceFixture.ShouldBeAssignableTo<PriItemDefn>();
        }

        #endregion

        #endregion

        #endregion
    }
}