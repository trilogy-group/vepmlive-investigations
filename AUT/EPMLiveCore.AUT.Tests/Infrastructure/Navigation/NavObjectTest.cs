using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Infrastructure.Navigation
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.Navigation.NavObject" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure.Navigation"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class NavObjectTest : AbstractBaseSetupTypedTest<NavObject>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (NavObject) Initializer

        private const string PropertyId = "Id";
        private const string PropertyCssClass = "CssClass";
        private const string PropertyActive = "Active";
        private const string PropertyVisible = "Visible";
        private const string PropertyExternal = "External";
        private const string PropertyUrl = "Url";
        private const string PropertyTitle = "Title";
        private Type _navObjectInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private NavObject _navObjectInstance;
        private NavObject _navObjectInstanceFixture;
        private Type[] _abstractClassInstanciatedTypesList;

        #region General Initializer : Class (NavObject) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NavObject" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _navObjectInstanceType = typeof(NavObject);
            _abstractClassInstanciatedTypesList = new Type[] { typeof(NavLink), typeof(NavNode) };
            _navObjectInstanceFixture = Create(true);
            _navObjectInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (NavObject)

        #region General Initializer : Class (NavObject) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="NavObject" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyId)]
        [TestCase(PropertyCssClass)]
        [TestCase(PropertyActive)]
        [TestCase(PropertyVisible)]
        [TestCase(PropertyExternal)]
        [TestCase(PropertyUrl)]
        [TestCase(PropertyTitle)]
        public void AUT_NavObject_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_navObjectInstanceFixture,
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
        ///     Class (<see cref="NavObject" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_NavObject_Is_Instance_Present_Test()
        {
            // Assert
            _navObjectInstanceType.ShouldNotBeNull();
            _navObjectInstance.ShouldNotBeNull();
            _navObjectInstanceFixture.ShouldNotBeNull();
            _navObjectInstance.ShouldBeAssignableTo<NavObject>();
            _navObjectInstanceFixture.ShouldBeAssignableTo<NavObject>();
        }

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (NavObject) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyId)]
        [TestCaseGeneric(typeof(string) , PropertyCssClass)]
        [TestCaseGeneric(typeof(bool) , PropertyActive)]
        [TestCaseGeneric(typeof(bool) , PropertyVisible)]
        [TestCaseGeneric(typeof(bool) , PropertyExternal)]
        [TestCaseGeneric(typeof(string) , PropertyUrl)]
        [TestCaseGeneric(typeof(string) , PropertyTitle)]
        public void AUT_NavObject_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<NavObject, T>(_navObjectInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (NavObject) => Property (Active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavObject_Public_Class_Active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyActive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NavObject) => Property (CssClass) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavObject_Public_Class_CssClass_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCssClass);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NavObject) => Property (External) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavObject_Public_Class_External_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyExternal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NavObject) => Property (Id) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavObject_Public_Class_Id_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NavObject) => Property (Title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavObject_Public_Class_Title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NavObject) => Property (Url) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavObject_Public_Class_Url_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NavObject) => Property (Visible) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_NavObject_Public_Class_Visible_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyVisible);

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