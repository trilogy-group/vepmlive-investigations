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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ProfileApplicationVisibility" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProfileApplicationVisibilityTest : AbstractBaseSetupTypedTest<ProfileApplicationVisibility>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProfileApplicationVisibility) Initializer

        private const string Propertyapplication = "application";
        private const string Propertyvisible = "visible";
        private const string FieldapplicationField = "applicationField";
        private const string FielddefaultField = "defaultField";
        private const string FieldvisibleField = "visibleField";
        private Type _profileApplicationVisibilityInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProfileApplicationVisibility _profileApplicationVisibilityInstance;
        private ProfileApplicationVisibility _profileApplicationVisibilityInstanceFixture;

        #region General Initializer : Class (ProfileApplicationVisibility) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProfileApplicationVisibility" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _profileApplicationVisibilityInstanceType = typeof(ProfileApplicationVisibility);
            _profileApplicationVisibilityInstanceFixture = Create(true);
            _profileApplicationVisibilityInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProfileApplicationVisibility)

        #region General Initializer : Class (ProfileApplicationVisibility) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileApplicationVisibility" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyapplication)]
        [TestCase(Propertyvisible)]
        public void AUT_ProfileApplicationVisibility_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_profileApplicationVisibilityInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProfileApplicationVisibility) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileApplicationVisibility" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapplicationField)]
        [TestCase(FielddefaultField)]
        [TestCase(FieldvisibleField)]
        public void AUT_ProfileApplicationVisibility_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_profileApplicationVisibilityInstanceFixture, 
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
        ///     Class (<see cref="ProfileApplicationVisibility" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProfileApplicationVisibility_Is_Instance_Present_Test()
        {
            // Assert
            _profileApplicationVisibilityInstanceType.ShouldNotBeNull();
            _profileApplicationVisibilityInstance.ShouldNotBeNull();
            _profileApplicationVisibilityInstanceFixture.ShouldNotBeNull();
            _profileApplicationVisibilityInstance.ShouldBeAssignableTo<ProfileApplicationVisibility>();
            _profileApplicationVisibilityInstanceFixture.ShouldBeAssignableTo<ProfileApplicationVisibility>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProfileApplicationVisibility) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProfileApplicationVisibility_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProfileApplicationVisibility instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _profileApplicationVisibilityInstanceType.ShouldNotBeNull();
            _profileApplicationVisibilityInstance.ShouldNotBeNull();
            _profileApplicationVisibilityInstanceFixture.ShouldNotBeNull();
            _profileApplicationVisibilityInstance.ShouldBeAssignableTo<ProfileApplicationVisibility>();
            _profileApplicationVisibilityInstanceFixture.ShouldBeAssignableTo<ProfileApplicationVisibility>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProfileApplicationVisibility) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyapplication)]
        [TestCaseGeneric(typeof(bool) , Propertyvisible)]
        public void AUT_ProfileApplicationVisibility_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProfileApplicationVisibility, T>(_profileApplicationVisibilityInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (ProfileApplicationVisibility) => Property (application) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileApplicationVisibility_Public_Class_application_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyapplication);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileApplicationVisibility) => Property (visible) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileApplicationVisibility_Public_Class_visible_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvisible);

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