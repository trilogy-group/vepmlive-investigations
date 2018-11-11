using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.PFEException" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PFEExceptionTest : AbstractBaseSetupTypedTest<PFEException>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PFEException) Initializer

        private const string PropertyExceptionNumber = "ExceptionNumber";
        private Type _pFEExceptionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PFEException _pFEExceptionInstance;
        private PFEException _pFEExceptionInstanceFixture;

        #region General Initializer : Class (PFEException) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PFEException" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _pFEExceptionInstanceType = typeof(PFEException);
            _pFEExceptionInstanceFixture = Create(true);
            _pFEExceptionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PFEException)

        #region General Initializer : Class (PFEException) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PFEException" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyExceptionNumber)]
        public void AUT_PFEException_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_pFEExceptionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="PFEException" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PFEException_Is_Instance_Present_Test()
        {
            // Assert
            _pFEExceptionInstanceType.ShouldNotBeNull();
            _pFEExceptionInstance.ShouldNotBeNull();
            _pFEExceptionInstanceFixture.ShouldNotBeNull();
            _pFEExceptionInstance.ShouldBeAssignableTo<PFEException>();
            _pFEExceptionInstanceFixture.ShouldBeAssignableTo<PFEException>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PFEException) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEException_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var exceptionNumber = CreateType<int>();
            var message = CreateType<string>();
            PFEException instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new PFEException(exceptionNumber, message);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _pFEExceptionInstance.ShouldNotBeNull();
            _pFEExceptionInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<PFEException>();
        }

        #endregion

        #region General Constructor : Class (PFEException) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PFEException_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var exceptionNumber = CreateType<int>();
            var message = CreateType<string>();
            PFEException instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new PFEException(exceptionNumber, message);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _pFEExceptionInstance.ShouldNotBeNull();
            _pFEExceptionInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PFEException) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(int) , PropertyExceptionNumber)]
        public void AUT_PFEException_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PFEException, T>(_pFEExceptionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PFEException) => Property (ExceptionNumber) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PFEException_Public_Class_ExceptionNumber_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExceptionNumber);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}