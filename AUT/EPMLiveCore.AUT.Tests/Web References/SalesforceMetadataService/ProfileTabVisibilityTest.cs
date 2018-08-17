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

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ProfileTabVisibility" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProfileTabVisibilityTest : AbstractBaseSetupTypedTest<ProfileTabVisibility>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProfileTabVisibility) Initializer

        private const string Propertytab = "tab";
        private const string Propertyvisibility = "visibility";
        private const string FieldtabField = "tabField";
        private const string FieldvisibilityField = "visibilityField";
        private Type _profileTabVisibilityInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProfileTabVisibility _profileTabVisibilityInstance;
        private ProfileTabVisibility _profileTabVisibilityInstanceFixture;

        #region General Initializer : Class (ProfileTabVisibility) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProfileTabVisibility" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _profileTabVisibilityInstanceType = typeof(ProfileTabVisibility);
            _profileTabVisibilityInstanceFixture = Create(true);
            _profileTabVisibilityInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProfileTabVisibility)

        #region General Initializer : Class (ProfileTabVisibility) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileTabVisibility" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertytab)]
        [TestCase(Propertyvisibility)]
        public void AUT_ProfileTabVisibility_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_profileTabVisibilityInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProfileTabVisibility) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileTabVisibility" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldtabField)]
        [TestCase(FieldvisibilityField)]
        public void AUT_ProfileTabVisibility_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_profileTabVisibilityInstanceFixture, 
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
        ///     Class (<see cref="ProfileTabVisibility" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProfileTabVisibility_Is_Instance_Present_Test()
        {
            // Assert
            _profileTabVisibilityInstanceType.ShouldNotBeNull();
            _profileTabVisibilityInstance.ShouldNotBeNull();
            _profileTabVisibilityInstanceFixture.ShouldNotBeNull();
            _profileTabVisibilityInstance.ShouldBeAssignableTo<ProfileTabVisibility>();
            _profileTabVisibilityInstanceFixture.ShouldBeAssignableTo<ProfileTabVisibility>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProfileTabVisibility) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProfileTabVisibility_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProfileTabVisibility instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _profileTabVisibilityInstanceType.ShouldNotBeNull();
            _profileTabVisibilityInstance.ShouldNotBeNull();
            _profileTabVisibilityInstanceFixture.ShouldNotBeNull();
            _profileTabVisibilityInstance.ShouldBeAssignableTo<ProfileTabVisibility>();
            _profileTabVisibilityInstanceFixture.ShouldBeAssignableTo<ProfileTabVisibility>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProfileTabVisibility) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertytab)]
        [TestCaseGeneric(typeof(TabVisibility) , Propertyvisibility)]
        public void AUT_ProfileTabVisibility_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProfileTabVisibility, T>(_profileTabVisibilityInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProfileTabVisibility) => Property (tab) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileTabVisibility_Public_Class_tab_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytab);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileTabVisibility) => Property (visibility) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileTabVisibility_visibility_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvisibility);
            Action currentAction = () => propertyInfo.SetValue(_profileTabVisibilityInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ProfileTabVisibility) => Property (visibility) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileTabVisibility_Public_Class_visibility_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvisibility);

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