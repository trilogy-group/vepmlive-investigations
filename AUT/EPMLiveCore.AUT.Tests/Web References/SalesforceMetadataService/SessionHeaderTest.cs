using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SessionHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SessionHeaderTest : AbstractBaseSetupTypedTest<SessionHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SessionHeader) Initializer

        private const string PropertysessionId = "sessionId";
        private const string FieldsessionIdField = "sessionIdField";
        private Type _sessionHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SessionHeader _sessionHeaderInstance;
        private SessionHeader _sessionHeaderInstanceFixture;

        #region General Initializer : Class (SessionHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SessionHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sessionHeaderInstanceType = typeof(SessionHeader);
            _sessionHeaderInstanceFixture = Create(true);
            _sessionHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SessionHeader)

        #region General Initializer : Class (SessionHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SessionHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertysessionId)]
        public void AUT_SessionHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sessionHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SessionHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SessionHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldsessionIdField)]
        public void AUT_SessionHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sessionHeaderInstanceFixture, 
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
        ///     Class (<see cref="SessionHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SessionHeader_Is_Instance_Present_Test()
        {
            // Assert
            _sessionHeaderInstanceType.ShouldNotBeNull();
            _sessionHeaderInstance.ShouldNotBeNull();
            _sessionHeaderInstanceFixture.ShouldNotBeNull();
            _sessionHeaderInstance.ShouldBeAssignableTo<SessionHeader>();
            _sessionHeaderInstanceFixture.ShouldBeAssignableTo<SessionHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SessionHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SessionHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SessionHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sessionHeaderInstanceType.ShouldNotBeNull();
            _sessionHeaderInstance.ShouldNotBeNull();
            _sessionHeaderInstanceFixture.ShouldNotBeNull();
            _sessionHeaderInstance.ShouldBeAssignableTo<SessionHeader>();
            _sessionHeaderInstanceFixture.ShouldBeAssignableTo<SessionHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SessionHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertysessionId)]
        public void AUT_SessionHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SessionHeader, T>(_sessionHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SessionHeader) => Property (sessionId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionHeader_Public_Class_sessionId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysessionId);

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