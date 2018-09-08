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

namespace EPMLiveWebParts.Personalization.DomainModel
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.Personalization.DomainModel.PersonalizationSearchCriteria" />)
    ///     and namespace <see cref="EPMLiveWebParts.Personalization.DomainModel"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonalizationSearchCriteriaTest : AbstractBaseSetupTypedTest<PersonalizationSearchCriteria>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PersonalizationSearchCriteria) Initializer

        private const string PropertyWebPartId = "WebPartId";
        private const string PropertyUserId = "UserId";
        private const string PropertySiteId = "SiteId";
        private const string PropertyWebId = "WebId";
        private const string PropertyKey = "Key";
        private Type _personalizationSearchCriteriaInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PersonalizationSearchCriteria _personalizationSearchCriteriaInstance;
        private PersonalizationSearchCriteria _personalizationSearchCriteriaInstanceFixture;

        #region General Initializer : Class (PersonalizationSearchCriteria) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PersonalizationSearchCriteria" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _personalizationSearchCriteriaInstanceType = typeof(PersonalizationSearchCriteria);
            _personalizationSearchCriteriaInstanceFixture = Create(true);
            _personalizationSearchCriteriaInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PersonalizationSearchCriteria)

        #region General Initializer : Class (PersonalizationSearchCriteria) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PersonalizationSearchCriteria" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyWebPartId)]
        [TestCase(PropertyUserId)]
        [TestCase(PropertySiteId)]
        [TestCase(PropertyWebId)]
        [TestCase(PropertyKey)]
        public void AUT_PersonalizationSearchCriteria_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_personalizationSearchCriteriaInstanceFixture,
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
        ///     Class (<see cref="PersonalizationSearchCriteria" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Instance")]
        public void AUT_PersonalizationSearchCriteria_Is_Instance_Present_Test()
        {
            // Assert
            _personalizationSearchCriteriaInstanceType.ShouldNotBeNull();
            _personalizationSearchCriteriaInstance.ShouldNotBeNull();
            _personalizationSearchCriteriaInstanceFixture.ShouldNotBeNull();
            _personalizationSearchCriteriaInstance.ShouldBeAssignableTo<PersonalizationSearchCriteria>();
            _personalizationSearchCriteriaInstanceFixture.ShouldBeAssignableTo<PersonalizationSearchCriteria>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PersonalizationSearchCriteria) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_Constructor_PersonalizationSearchCriteria_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PersonalizationSearchCriteria instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _personalizationSearchCriteriaInstanceType.ShouldNotBeNull();
            _personalizationSearchCriteriaInstance.ShouldNotBeNull();
            _personalizationSearchCriteriaInstanceFixture.ShouldNotBeNull();
            _personalizationSearchCriteriaInstance.ShouldBeAssignableTo<PersonalizationSearchCriteria>();
            _personalizationSearchCriteriaInstanceFixture.ShouldBeAssignableTo<PersonalizationSearchCriteria>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PersonalizationSearchCriteria) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Guid?) , PropertyWebPartId)]
        [TestCaseGeneric(typeof(string) , PropertyUserId)]
        [TestCaseGeneric(typeof(Guid?) , PropertySiteId)]
        [TestCaseGeneric(typeof(Guid?) , PropertyWebId)]
        [TestCaseGeneric(typeof(string) , PropertyKey)]
        public void AUT_PersonalizationSearchCriteria_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PersonalizationSearchCriteria, T>(_personalizationSearchCriteriaInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationSearchCriteria) => Property (Key) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationSearchCriteria_Public_Class_Key_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationSearchCriteria) => Property (SiteId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationSearchCriteria_SiteId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertySiteId);
            Action currentAction = () => propertyInfo.SetValue(_personalizationSearchCriteriaInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationSearchCriteria) => Property (SiteId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationSearchCriteria_Public_Class_SiteId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PersonalizationSearchCriteria) => Property (UserId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationSearchCriteria_Public_Class_UserId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyUserId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationSearchCriteria) => Property (WebId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationSearchCriteria_WebId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebId);
            Action currentAction = () => propertyInfo.SetValue(_personalizationSearchCriteriaInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationSearchCriteria) => Property (WebId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationSearchCriteria_Public_Class_WebId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PersonalizationSearchCriteria) => Property (WebPartId) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationSearchCriteria_WebPartId_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyWebPartId);
            Action currentAction = () => propertyInfo.SetValue(_personalizationSearchCriteriaInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PersonalizationSearchCriteria) => Property (WebPartId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_PersonalizationSearchCriteria_Public_Class_WebPartId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWebPartId);

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