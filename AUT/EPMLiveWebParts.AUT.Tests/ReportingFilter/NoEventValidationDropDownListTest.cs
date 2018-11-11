using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.NoEventValidationDropDownList" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class NoEventValidationDropDownListTest : AbstractBaseSetupTypedTest<NoEventValidationDropDownList>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (NoEventValidationDropDownList) Initializer

        private Type _noEventValidationDropDownListInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private NoEventValidationDropDownList _noEventValidationDropDownListInstance;
        private NoEventValidationDropDownList _noEventValidationDropDownListInstanceFixture;

        #region General Initializer : Class (NoEventValidationDropDownList) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NoEventValidationDropDownList" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _noEventValidationDropDownListInstanceType = typeof(NoEventValidationDropDownList);
            _noEventValidationDropDownListInstanceFixture = Create(true);
            _noEventValidationDropDownListInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="NoEventValidationDropDownList" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_NoEventValidationDropDownList_Is_Instance_Present_Test()
        {
            // Assert
            _noEventValidationDropDownListInstanceType.ShouldNotBeNull();
            _noEventValidationDropDownListInstance.ShouldNotBeNull();
            _noEventValidationDropDownListInstanceFixture.ShouldNotBeNull();
            _noEventValidationDropDownListInstance.ShouldBeAssignableTo<NoEventValidationDropDownList>();
            _noEventValidationDropDownListInstanceFixture.ShouldBeAssignableTo<NoEventValidationDropDownList>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NoEventValidationDropDownList) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_NoEventValidationDropDownList_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            NoEventValidationDropDownList instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _noEventValidationDropDownListInstanceType.ShouldNotBeNull();
            _noEventValidationDropDownListInstance.ShouldNotBeNull();
            _noEventValidationDropDownListInstanceFixture.ShouldNotBeNull();
            _noEventValidationDropDownListInstance.ShouldBeAssignableTo<NoEventValidationDropDownList>();
            _noEventValidationDropDownListInstanceFixture.ShouldBeAssignableTo<NoEventValidationDropDownList>();
        }

        #endregion

        #endregion

        #endregion
    }
}