using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace PortfolioEngineCore.Setup
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Setup.DataScript" />)
    ///     and namespace <see cref="PortfolioEngineCore.Setup"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DataScriptTest : AbstractBaseSetupTypedTest<DataScript>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DataScript) Initializer

        private const string FieldScriptName = "ScriptName";
        private const string FieldScript = "Script";
        private Type _dataScriptInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DataScript _dataScriptInstance;
        private DataScript _dataScriptInstanceFixture;

        #region General Initializer : Class (DataScript) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DataScript" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dataScriptInstanceType = typeof(DataScript);
            _dataScriptInstanceFixture = Create(true);
            _dataScriptInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DataScript)

        #region General Initializer : Class (DataScript) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DataScript" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldScriptName)]
        [TestCase(FieldScript)]
        public void AUT_DataScript_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dataScriptInstanceFixture, 
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
        ///     Class (<see cref="DataScript" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_DataScript_Is_Instance_Present_Test()
        {
            // Assert
            _dataScriptInstanceType.ShouldNotBeNull();
            _dataScriptInstance.ShouldNotBeNull();
            _dataScriptInstanceFixture.ShouldNotBeNull();
            _dataScriptInstance.ShouldBeAssignableTo<DataScript>();
            _dataScriptInstanceFixture.ShouldBeAssignableTo<DataScript>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DataScript) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_DataScript_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DataScript instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dataScriptInstanceType.ShouldNotBeNull();
            _dataScriptInstance.ShouldNotBeNull();
            _dataScriptInstanceFixture.ShouldNotBeNull();
            _dataScriptInstance.ShouldBeAssignableTo<DataScript>();
            _dataScriptInstanceFixture.ShouldBeAssignableTo<DataScript>();
        }

        #endregion

        #endregion

        #endregion
    }
}