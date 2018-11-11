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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="ModelDataCache.CSTargetData" />)
    ///     and namespace <see cref="ModelDataCache"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CSTargetDataTest : AbstractBaseSetupTypedTest<CSTargetData>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CSTargetData) Initializer

        private const string FieldtargetRows = "targetRows";
        private Type _cSTargetDataInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CSTargetData _cSTargetDataInstance;
        private CSTargetData _cSTargetDataInstanceFixture;

        #region General Initializer : Class (CSTargetData) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CSTargetData" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cSTargetDataInstanceType = typeof(CSTargetData);
            _cSTargetDataInstanceFixture = Create(true);
            _cSTargetDataInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CSTargetData)

        #region General Initializer : Class (CSTargetData) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CSTargetData" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldtargetRows)]
        public void AUT_CSTargetData_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cSTargetDataInstanceFixture, 
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
        ///     Class (<see cref="CSTargetData" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_CSTargetData_Is_Instance_Present_Test()
        {
            // Assert
            _cSTargetDataInstanceType.ShouldNotBeNull();
            _cSTargetDataInstance.ShouldNotBeNull();
            _cSTargetDataInstanceFixture.ShouldNotBeNull();
            _cSTargetDataInstance.ShouldBeAssignableTo<CSTargetData>();
            _cSTargetDataInstanceFixture.ShouldBeAssignableTo<CSTargetData>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CSTargetData) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_CSTargetData_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CSTargetData instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _cSTargetDataInstanceType.ShouldNotBeNull();
            _cSTargetDataInstance.ShouldNotBeNull();
            _cSTargetDataInstanceFixture.ShouldNotBeNull();
            _cSTargetDataInstance.ShouldBeAssignableTo<CSTargetData>();
            _cSTargetDataInstanceFixture.ShouldBeAssignableTo<CSTargetData>();
        }

        #endregion

        #endregion

        #endregion
    }
}