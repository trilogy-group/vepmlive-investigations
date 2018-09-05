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

namespace PPM
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PPM.PublicAPI" />)
    ///     and namespace <see cref="PPM"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PublicAPITest : AbstractBaseSetupTypedTest<PublicAPI>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PublicAPI) Initializer

        private const string PropertyIsPublic = "IsPublic";
        private Type _publicAPIInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PublicAPI _publicAPIInstance;
        private PublicAPI _publicAPIInstanceFixture;

        #region General Initializer : Class (PublicAPI) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PublicAPI" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _publicAPIInstanceType = typeof(PublicAPI);
            _publicAPIInstanceFixture = Create(true);
            _publicAPIInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PublicAPI)

        #region General Initializer : Class (PublicAPI) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PublicAPI" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyIsPublic)]
        public void AUT_PublicAPI_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_publicAPIInstanceFixture,
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
        ///     Class (<see cref="PublicAPI" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PublicAPI_Is_Instance_Present_Test()
        {
            // Assert
            _publicAPIInstanceType.ShouldNotBeNull();
            _publicAPIInstance.ShouldNotBeNull();
            _publicAPIInstanceFixture.ShouldNotBeNull();
            _publicAPIInstance.ShouldBeAssignableTo<PublicAPI>();
            _publicAPIInstanceFixture.ShouldBeAssignableTo<PublicAPI>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PublicAPI) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PublicAPI_Constructor_With_Parameter_Created_Instance_Type_Test()
        {
            // Arrange
            var isPublic = CreateType<bool>();
            PublicAPI instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new PublicAPI(isPublic);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _publicAPIInstance.ShouldNotBeNull();
            _publicAPIInstanceFixture.ShouldNotBeNull();
            instance.ShouldBeOfType<PublicAPI>();
        }

        #endregion

        #region General Constructor : Class (PublicAPI) with Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_PublicAPI_Constructor_Instantiation_With_Parameter_Test()
        {
            // Arrange
            var isPublic = CreateType<bool>();
            PublicAPI instance = null;
            Exception creationException = null;

            // Act
            Action createAction = () => instance = new PublicAPI(isPublic);
            creationException = ActionAnalyzer.GetActionException(createAction);

            // Assert
            instance.ShouldNotBeNull();
            _publicAPIInstance.ShouldNotBeNull();
            _publicAPIInstanceFixture.ShouldNotBeNull();
            Should.NotThrow(createAction);
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PublicAPI) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyIsPublic)]
        public void AUT_PublicAPI_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PublicAPI, T>(_publicAPIInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PublicAPI) => Property (IsPublic) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PublicAPI_Public_Class_IsPublic_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsPublic);

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