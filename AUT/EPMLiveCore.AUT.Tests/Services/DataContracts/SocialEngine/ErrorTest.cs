using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Services.DataContracts.SocialEngine
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Services.DataContracts.SocialEngine.Error" />)
    ///     and namespace <see cref="EPMLiveCore.Services.DataContracts.SocialEngine"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ErrorTest : AbstractBaseSetupTypedTest<Error>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Error) Initializer

        private const string Propertykind = "kind";
        private const string Propertymessage = "message";
        private const string PropertystackTrace = "stackTrace";
        private Type _errorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Error _errorInstance;
        private Error _errorInstanceFixture;

        #region General Initializer : Class (Error) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Error" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _errorInstanceType = typeof(Error);
            _errorInstanceFixture = Create(true);
            _errorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Error)

        #region General Initializer : Class (Error) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Error" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Propertykind)]
        [TestCase(Propertymessage)]
        [TestCase(PropertystackTrace)]
        public void AUT_Error_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_errorInstanceFixture,
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
        ///     Class (<see cref="Error" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Error_Is_Instance_Present_Test()
        {
            // Assert
            _errorInstanceType.ShouldNotBeNull();
            _errorInstance.ShouldNotBeNull();
            _errorInstanceFixture.ShouldNotBeNull();
            _errorInstance.ShouldBeAssignableTo<Error>();
            _errorInstanceFixture.ShouldBeAssignableTo<Error>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Error) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Error_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Error instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _errorInstanceType.ShouldNotBeNull();
            _errorInstance.ShouldNotBeNull();
            _errorInstanceFixture.ShouldNotBeNull();
            _errorInstance.ShouldBeAssignableTo<Error>();
            _errorInstanceFixture.ShouldBeAssignableTo<Error>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Error) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertykind)]
        [TestCaseGeneric(typeof(string) , Propertymessage)]
        [TestCaseGeneric(typeof(string) , PropertystackTrace)]
        public void AUT_Error_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Error, T>(_errorInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Error) => Property (kind) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Error_Public_Class_kind_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertykind);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Error) => Property (message) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Error_Public_Class_message_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymessage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Error) => Property (stackTrace) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Error_Public_Class_stackTrace_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystackTrace);

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