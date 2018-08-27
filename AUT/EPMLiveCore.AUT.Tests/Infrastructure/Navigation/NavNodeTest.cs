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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.Navigation.NavNode" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure.Navigation"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class NavNodeTest : AbstractBaseSetupTypedTest<NavNode>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (NavNode) Initializer

        private const string PropertyLinkProvider = "LinkProvider";
        private const string PropertySeparator = "Separator";
        private Type _navNodeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private NavNode _navNodeInstance;
        private NavNode _navNodeInstanceFixture;

        #region General Initializer : Class (NavNode) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NavNode" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _navNodeInstanceType = typeof(NavNode);
            _navNodeInstanceFixture = Create(true);
            _navNodeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (NavNode)

        #region General Initializer : Class (NavNode) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="NavNode" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyLinkProvider)]
        [TestCase(PropertySeparator)]
        public void AUT_NavNode_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_navNodeInstanceFixture,
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
        ///     Class (<see cref="NavNode" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_NavNode_Is_Instance_Present_Test()
        {
            // Assert
            _navNodeInstanceType.ShouldNotBeNull();
            _navNodeInstance.ShouldNotBeNull();
            _navNodeInstanceFixture.ShouldNotBeNull();
            _navNodeInstance.ShouldBeAssignableTo<NavNode>();
            _navNodeInstanceFixture.ShouldBeAssignableTo<NavNode>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NavNode) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_NavNode_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            NavNode instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _navNodeInstanceType.ShouldNotBeNull();
            _navNodeInstance.ShouldNotBeNull();
            _navNodeInstanceFixture.ShouldNotBeNull();
            _navNodeInstance.ShouldBeAssignableTo<NavNode>();
            _navNodeInstanceFixture.ShouldBeAssignableTo<NavNode>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (NavNode) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyLinkProvider)]
        [TestCaseGeneric(typeof(bool) , PropertySeparator)]
        public void AUT_NavNode_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<NavNode, T>(_navNodeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (NavNode) => Property (LinkProvider) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavNode_Public_Class_LinkProvider_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyLinkProvider);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NavNode) => Property (Separator) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavNode_Public_Class_Separator_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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