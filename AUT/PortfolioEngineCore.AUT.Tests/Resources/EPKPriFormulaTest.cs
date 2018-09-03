using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.EPKPriFormula" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class EPKPriFormulaTest : AbstractBaseSetupTypedTest<EPKPriFormula>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EPKPriFormula) Initializer

        private const string Fielduid = "uid";
        private const string Fieldname = "name";
        private const string Fieldcomponents = "components";
        private Type _ePKPriFormulaInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EPKPriFormula _ePKPriFormulaInstance;
        private EPKPriFormula _ePKPriFormulaInstanceFixture;

        #region General Initializer : Class (EPKPriFormula) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EPKPriFormula" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ePKPriFormulaInstanceType = typeof(EPKPriFormula);
            _ePKPriFormulaInstanceFixture = Create(true);
            _ePKPriFormulaInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EPKPriFormula)

        #region General Initializer : Class (EPKPriFormula) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EPKPriFormula" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fielduid)]
        [TestCase(Fieldname)]
        [TestCase(Fieldcomponents)]
        public void AUT_EPKPriFormula_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ePKPriFormulaInstanceFixture, 
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
        ///     Class (<see cref="EPKPriFormula" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_EPKPriFormula_Is_Instance_Present_Test()
        {
            // Assert
            _ePKPriFormulaInstanceType.ShouldNotBeNull();
            _ePKPriFormulaInstance.ShouldNotBeNull();
            _ePKPriFormulaInstanceFixture.ShouldNotBeNull();
            _ePKPriFormulaInstance.ShouldBeAssignableTo<EPKPriFormula>();
            _ePKPriFormulaInstanceFixture.ShouldBeAssignableTo<EPKPriFormula>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EPKPriFormula) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_EPKPriFormula_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EPKPriFormula instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ePKPriFormulaInstanceType.ShouldNotBeNull();
            _ePKPriFormulaInstance.ShouldNotBeNull();
            _ePKPriFormulaInstanceFixture.ShouldNotBeNull();
            _ePKPriFormulaInstance.ShouldBeAssignableTo<EPKPriFormula>();
            _ePKPriFormulaInstanceFixture.ShouldBeAssignableTo<EPKPriFormula>();
        }

        #endregion

        #endregion

        #endregion
    }
}