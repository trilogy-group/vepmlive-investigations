using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.SessionManager" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SessionManagerTest : AbstractBaseSetupTest
    {
        public SessionManagerTest() : base(typeof(SessionManager))
        {}

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SessionManager) Initializer

        private const string PropertyUsername = "Username";
        private const string PropertyCurrList = "CurrList";
        private const string FieldCURR_LIST = "CURR_LIST";
        private Type _sessionManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;

        #region General Initializer : Class (SessionManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SessionManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sessionManagerInstanceType = typeof(SessionManager);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SessionManager)

        #region General Initializer : Class (SessionManager) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SessionManager" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyUsername)]
        [TestCase(PropertyCurrList)]
        public void AUT_SessionManager_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(null,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SessionManager) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SessionManager" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldCURR_LIST)]
        public void AUT_SessionManager_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(null, 
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
        ///     Class (<see cref="SessionManager" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SessionManager_Is_Static_Type_Present_Test()
        {
            // Assert
            _sessionManagerInstanceType.ShouldNotBeNull();
        }

        #endregion

        #endregion
    }
}