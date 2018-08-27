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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ProfileApexPageAccess" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ProfileApexPageAccessTest : AbstractBaseSetupTypedTest<ProfileApexPageAccess>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ProfileApexPageAccess) Initializer

        private const string PropertyapexPage = "apexPage";
        private const string Propertyenabled = "enabled";
        private const string FieldapexPageField = "apexPageField";
        private const string FieldenabledField = "enabledField";
        private Type _profileApexPageAccessInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ProfileApexPageAccess _profileApexPageAccessInstance;
        private ProfileApexPageAccess _profileApexPageAccessInstanceFixture;

        #region General Initializer : Class (ProfileApexPageAccess) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ProfileApexPageAccess" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _profileApexPageAccessInstanceType = typeof(ProfileApexPageAccess);
            _profileApexPageAccessInstanceFixture = Create(true);
            _profileApexPageAccessInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ProfileApexPageAccess)

        #region General Initializer : Class (ProfileApexPageAccess) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileApexPageAccess" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapexPage)]
        [TestCase(Propertyenabled)]
        public void AUT_ProfileApexPageAccess_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_profileApexPageAccessInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ProfileApexPageAccess) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ProfileApexPageAccess" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapexPageField)]
        [TestCase(FieldenabledField)]
        public void AUT_ProfileApexPageAccess_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_profileApexPageAccessInstanceFixture, 
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
        ///     Class (<see cref="ProfileApexPageAccess" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ProfileApexPageAccess_Is_Instance_Present_Test()
        {
            // Assert
            _profileApexPageAccessInstanceType.ShouldNotBeNull();
            _profileApexPageAccessInstance.ShouldNotBeNull();
            _profileApexPageAccessInstanceFixture.ShouldNotBeNull();
            _profileApexPageAccessInstance.ShouldBeAssignableTo<ProfileApexPageAccess>();
            _profileApexPageAccessInstanceFixture.ShouldBeAssignableTo<ProfileApexPageAccess>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ProfileApexPageAccess) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ProfileApexPageAccess_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ProfileApexPageAccess instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _profileApexPageAccessInstanceType.ShouldNotBeNull();
            _profileApexPageAccessInstance.ShouldNotBeNull();
            _profileApexPageAccessInstanceFixture.ShouldNotBeNull();
            _profileApexPageAccessInstance.ShouldBeAssignableTo<ProfileApexPageAccess>();
            _profileApexPageAccessInstanceFixture.ShouldBeAssignableTo<ProfileApexPageAccess>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ProfileApexPageAccess) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyapexPage)]
        [TestCaseGeneric(typeof(bool) , Propertyenabled)]
        public void AUT_ProfileApexPageAccess_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ProfileApexPageAccess, T>(_profileApexPageAccessInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ProfileApexPageAccess) => Property (apexPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileApexPageAccess_Public_Class_apexPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapexPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ProfileApexPageAccess) => Property (enabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ProfileApexPageAccess_Public_Class_enabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyenabled);

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