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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.Navigation.NavLink" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure.Navigation"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class NavLinkTest : AbstractBaseSetupTypedTest<NavLink>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (NavLink) Initializer

        private const string PropertyCategory = "Category";
        private const string PropertyObjectId = "ObjectId";
        private const string PropertyOrder = "Order";
        private const string PropertySeparator = "Separator";
        private Type _navLinkInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private NavLink _navLinkInstance;
        private NavLink _navLinkInstanceFixture;

        #region General Initializer : Class (NavLink) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NavLink" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _navLinkInstanceType = typeof(NavLink);
            _navLinkInstanceFixture = Create(true);
            _navLinkInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (NavLink)

        #region General Initializer : Class (NavLink) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="NavLink" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyCategory)]
        [TestCase(PropertyObjectId)]
        [TestCase(PropertyOrder)]
        [TestCase(PropertySeparator)]
        public void AUT_NavLink_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_navLinkInstanceFixture,
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
        ///     Class (<see cref="NavLink" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_NavLink_Is_Instance_Present_Test()
        {
            // Assert
            _navLinkInstanceType.ShouldNotBeNull();
            _navLinkInstance.ShouldNotBeNull();
            _navLinkInstanceFixture.ShouldNotBeNull();
            _navLinkInstance.ShouldBeAssignableTo<NavLink>();
            _navLinkInstanceFixture.ShouldBeAssignableTo<NavLink>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NavLink) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_NavLink_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            NavLink instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _navLinkInstanceType.ShouldNotBeNull();
            _navLinkInstance.ShouldNotBeNull();
            _navLinkInstanceFixture.ShouldNotBeNull();
            _navLinkInstance.ShouldBeAssignableTo<NavLink>();
            _navLinkInstanceFixture.ShouldBeAssignableTo<NavLink>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (NavLink) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyCategory)]
        [TestCaseGeneric(typeof(string) , PropertyObjectId)]
        [TestCaseGeneric(typeof(int) , PropertyOrder)]
        [TestCaseGeneric(typeof(bool) , PropertySeparator)]
        public void AUT_NavLink_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<NavLink, T>(_navLinkInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (NavLink) => Property (Category) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavLink_Public_Class_Category_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCategory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NavLink) => Property (ObjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavLink_Public_Class_ObjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyObjectId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NavLink) => Property (Order) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavLink_Public_Class_Order_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyOrder);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NavLink) => Property (Separator) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavLink_Public_Class_Separator_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySeparator);

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