using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Infrastructure.Navigation
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.Navigation.NavLinkProviderInfoAttribute" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure.Navigation"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class NavLinkProviderInfoAttributeTest : AbstractBaseSetupTypedTest<NavLinkProviderInfoAttribute>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (NavLinkProviderInfoAttribute) Initializer

        private const string PropertyName = "Name";
        private Type _navLinkProviderInfoAttributeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private NavLinkProviderInfoAttribute _navLinkProviderInfoAttributeInstance;
        private NavLinkProviderInfoAttribute _navLinkProviderInfoAttributeInstanceFixture;

        #region General Initializer : Class (NavLinkProviderInfoAttribute) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NavLinkProviderInfoAttribute" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _navLinkProviderInfoAttributeInstanceType = typeof(NavLinkProviderInfoAttribute);
            _navLinkProviderInfoAttributeInstanceFixture = Create(true);
            _navLinkProviderInfoAttributeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (NavLinkProviderInfoAttribute)

        #region General Initializer : Class (NavLinkProviderInfoAttribute) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="NavLinkProviderInfoAttribute" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyName)]
        public void AUT_NavLinkProviderInfoAttribute_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_navLinkProviderInfoAttributeInstanceFixture,
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
        ///     Class (<see cref="NavLinkProviderInfoAttribute" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_NavLinkProviderInfoAttribute_Is_Instance_Present_Test()
        {
            // Assert
            _navLinkProviderInfoAttributeInstanceType.ShouldNotBeNull();
            _navLinkProviderInfoAttributeInstance.ShouldNotBeNull();
            _navLinkProviderInfoAttributeInstanceFixture.ShouldNotBeNull();
            _navLinkProviderInfoAttributeInstance.ShouldBeAssignableTo<NavLinkProviderInfoAttribute>();
            _navLinkProviderInfoAttributeInstanceFixture.ShouldBeAssignableTo<NavLinkProviderInfoAttribute>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NavLinkProviderInfoAttribute) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_NavLinkProviderInfoAttribute_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            NavLinkProviderInfoAttribute instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _navLinkProviderInfoAttributeInstanceType.ShouldNotBeNull();
            _navLinkProviderInfoAttributeInstance.ShouldNotBeNull();
            _navLinkProviderInfoAttributeInstanceFixture.ShouldNotBeNull();
            _navLinkProviderInfoAttributeInstance.ShouldBeAssignableTo<NavLinkProviderInfoAttribute>();
            _navLinkProviderInfoAttributeInstanceFixture.ShouldBeAssignableTo<NavLinkProviderInfoAttribute>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (NavLinkProviderInfoAttribute) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyName)]
        public void AUT_NavLinkProviderInfoAttribute_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<NavLinkProviderInfoAttribute, T>(_navLinkProviderInfoAttributeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (NavLinkProviderInfoAttribute) => Property (Name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavLinkProviderInfoAttribute_Public_Class_Name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyName);

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