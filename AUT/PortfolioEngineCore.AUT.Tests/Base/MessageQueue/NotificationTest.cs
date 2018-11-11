using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace PortfolioEngineCore
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="PortfolioEngineCore.Notification" />)
    ///     and namespace <see cref="PortfolioEngineCore"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class NotificationTest : AbstractBaseSetupTypedTest<Notification>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Notification) Initializer

        private const string PropertyBasePath = "BasePath";
        private Type _notificationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Notification _notificationInstance;
        private Notification _notificationInstanceFixture;

        #region General Initializer : Class (Notification) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Notification" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _notificationInstanceType = typeof(Notification);
            _notificationInstanceFixture = Create(true);
            _notificationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Notification)

        #region General Initializer : Class (Notification) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Notification" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyBasePath)]
        public void AUT_Notification_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_notificationInstanceFixture,
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
        ///     Class (<see cref="Notification" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_Notification_Is_Instance_Present_Test()
        {
            // Assert
            _notificationInstanceType.ShouldNotBeNull();
            _notificationInstance.ShouldNotBeNull();
            _notificationInstanceFixture.ShouldNotBeNull();
            _notificationInstance.ShouldBeAssignableTo<Notification>();
            _notificationInstanceFixture.ShouldBeAssignableTo<Notification>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Notification) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_Notification_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Notification instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _notificationInstanceType.ShouldNotBeNull();
            _notificationInstance.ShouldNotBeNull();
            _notificationInstanceFixture.ShouldNotBeNull();
            _notificationInstance.ShouldBeAssignableTo<Notification>();
            _notificationInstanceFixture.ShouldBeAssignableTo<Notification>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Notification) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyBasePath)]
        public void AUT_Notification_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Notification, T>(_notificationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Notification) => Property (BasePath) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_Notification_Public_Class_BasePath_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyBasePath);

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