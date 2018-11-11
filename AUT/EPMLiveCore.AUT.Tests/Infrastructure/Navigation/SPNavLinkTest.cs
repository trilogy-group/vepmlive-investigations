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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.Navigation.SPNavLink" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure.Navigation"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SPNavLinkTest : AbstractBaseSetupTypedTest<SPNavLink>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SPNavLink) Initializer

        private const string PropertyItemId = "ItemId";
        private const string PropertyListId = "ListId";
        private const string PropertySiteId = "SiteId";
        private const string PropertyWebId = "WebId";
        private const string PropertyArchived = "Archived";
        private Type _sPNavLinkInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SPNavLink _sPNavLinkInstance;
        private SPNavLink _sPNavLinkInstanceFixture;

        #region General Initializer : Class (SPNavLink) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SPNavLink" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sPNavLinkInstanceType = typeof(SPNavLink);
            _sPNavLinkInstanceFixture = Create(true);
            _sPNavLinkInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SPNavLink)

        #region General Initializer : Class (SPNavLink) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SPNavLink" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyItemId)]
        [TestCase(PropertyListId)]
        [TestCase(PropertySiteId)]
        [TestCase(PropertyWebId)]
        public void AUT_SPNavLink_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sPNavLinkInstanceFixture,
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
        ///     Class (<see cref="SPNavLink" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_SPNavLink_Is_Instance_Present_Test()
        {
            // Assert
            _sPNavLinkInstanceType.ShouldNotBeNull();
            _sPNavLinkInstance.ShouldNotBeNull();
            _sPNavLinkInstanceFixture.ShouldNotBeNull();
            _sPNavLinkInstance.ShouldBeAssignableTo<SPNavLink>();
            _sPNavLinkInstanceFixture.ShouldBeAssignableTo<SPNavLink>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SPNavLink) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_SPNavLink_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SPNavLink instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sPNavLinkInstanceType.ShouldNotBeNull();
            _sPNavLinkInstance.ShouldNotBeNull();
            _sPNavLinkInstanceFixture.ShouldNotBeNull();
            _sPNavLinkInstance.ShouldBeAssignableTo<SPNavLink>();
            _sPNavLinkInstanceFixture.ShouldBeAssignableTo<SPNavLink>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SPNavLink) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyItemId)]
        [TestCaseGeneric(typeof(string) , PropertyListId)]
        [TestCaseGeneric(typeof(string) , PropertySiteId)]
        [TestCaseGeneric(typeof(string) , PropertyWebId)]
        public void AUT_SPNavLink_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SPNavLink, T>(_sPNavLinkInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SPNavLink) => Property (ItemId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SPNavLink_Public_Class_ItemId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyItemId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SPNavLink) => Property (ListId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SPNavLink_Public_Class_ListId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SPNavLink) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SPNavLink_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySiteId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SPNavLink) => Property (WebId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_SPNavLink_Public_Class_WebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebId);

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