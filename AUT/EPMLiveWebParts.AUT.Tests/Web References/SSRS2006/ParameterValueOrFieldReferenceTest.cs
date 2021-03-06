using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts.SSRS2006
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.SSRS2006.ParameterValueOrFieldReference" />)
    ///     and namespace <see cref="EPMLiveWebParts.SSRS2006"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ParameterValueOrFieldReferenceTest : AbstractBaseSetupTypedTest<ParameterValueOrFieldReference>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ParameterValueOrFieldReference) Initializer

        private Type _parameterValueOrFieldReferenceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ParameterValueOrFieldReference _parameterValueOrFieldReferenceInstance;
        private ParameterValueOrFieldReference _parameterValueOrFieldReferenceInstanceFixture;

        #region General Initializer : Class (ParameterValueOrFieldReference) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ParameterValueOrFieldReference" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _parameterValueOrFieldReferenceInstanceType = typeof(ParameterValueOrFieldReference);
            _parameterValueOrFieldReferenceInstanceFixture = Create(true);
            _parameterValueOrFieldReferenceInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ParameterValueOrFieldReference" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ParameterValueOrFieldReference_Is_Instance_Present_Test()
        {
            // Assert
            _parameterValueOrFieldReferenceInstanceType.ShouldNotBeNull();
            _parameterValueOrFieldReferenceInstance.ShouldNotBeNull();
            _parameterValueOrFieldReferenceInstanceFixture.ShouldNotBeNull();
            _parameterValueOrFieldReferenceInstance.ShouldBeAssignableTo<ParameterValueOrFieldReference>();
            _parameterValueOrFieldReferenceInstanceFixture.ShouldBeAssignableTo<ParameterValueOrFieldReference>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ParameterValueOrFieldReference) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ParameterValueOrFieldReference_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ParameterValueOrFieldReference instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _parameterValueOrFieldReferenceInstanceType.ShouldNotBeNull();
            _parameterValueOrFieldReferenceInstance.ShouldNotBeNull();
            _parameterValueOrFieldReferenceInstanceFixture.ShouldNotBeNull();
            _parameterValueOrFieldReferenceInstance.ShouldBeAssignableTo<ParameterValueOrFieldReference>();
            _parameterValueOrFieldReferenceInstanceFixture.ShouldBeAssignableTo<ParameterValueOrFieldReference>();
        }

        #endregion

        #endregion

        #endregion
    }
}