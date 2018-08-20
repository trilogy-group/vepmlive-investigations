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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.RoleOrTerritory" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class RoleOrTerritoryTest : AbstractBaseSetupTypedTest<RoleOrTerritory>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (RoleOrTerritory) Initializer

        private const string PropertycaseAccessLevel = "caseAccessLevel";
        private const string PropertycontactAccessLevel = "contactAccessLevel";
        private const string Propertydescription = "description";
        private const string PropertymayForecastManagerShare = "mayForecastManagerShare";
        private const string PropertymayForecastManagerShareSpecified = "mayForecastManagerShareSpecified";
        private const string Propertyname = "name";
        private const string PropertyopportunityAccessLevel = "opportunityAccessLevel";
        private const string FieldcaseAccessLevelField = "caseAccessLevelField";
        private const string FieldcontactAccessLevelField = "contactAccessLevelField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldmayForecastManagerShareField = "mayForecastManagerShareField";
        private const string FieldmayForecastManagerShareFieldSpecified = "mayForecastManagerShareFieldSpecified";
        private const string FieldnameField = "nameField";
        private const string FieldopportunityAccessLevelField = "opportunityAccessLevelField";
        private Type _roleOrTerritoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private RoleOrTerritory _roleOrTerritoryInstance;
        private RoleOrTerritory _roleOrTerritoryInstanceFixture;

        #region General Initializer : Class (RoleOrTerritory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="RoleOrTerritory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _roleOrTerritoryInstanceType = typeof(RoleOrTerritory);
            _roleOrTerritoryInstanceFixture = Create(true);
            _roleOrTerritoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (RoleOrTerritory)

        #region General Initializer : Class (RoleOrTerritory) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="RoleOrTerritory" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycaseAccessLevel)]
        [TestCase(PropertycontactAccessLevel)]
        [TestCase(Propertydescription)]
        [TestCase(PropertymayForecastManagerShare)]
        [TestCase(PropertymayForecastManagerShareSpecified)]
        [TestCase(Propertyname)]
        [TestCase(PropertyopportunityAccessLevel)]
        public void AUT_RoleOrTerritory_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_roleOrTerritoryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (RoleOrTerritory) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="RoleOrTerritory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcaseAccessLevelField)]
        [TestCase(FieldcontactAccessLevelField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldmayForecastManagerShareField)]
        [TestCase(FieldmayForecastManagerShareFieldSpecified)]
        [TestCase(FieldnameField)]
        [TestCase(FieldopportunityAccessLevelField)]
        public void AUT_RoleOrTerritory_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_roleOrTerritoryInstanceFixture, 
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
        ///     Class (<see cref="RoleOrTerritory" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_RoleOrTerritory_Is_Instance_Present_Test()
        {
            // Assert
            _roleOrTerritoryInstanceType.ShouldNotBeNull();
            _roleOrTerritoryInstance.ShouldNotBeNull();
            _roleOrTerritoryInstanceFixture.ShouldNotBeNull();
            _roleOrTerritoryInstance.ShouldBeAssignableTo<RoleOrTerritory>();
            _roleOrTerritoryInstanceFixture.ShouldBeAssignableTo<RoleOrTerritory>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (RoleOrTerritory) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_RoleOrTerritory_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            RoleOrTerritory instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _roleOrTerritoryInstanceType.ShouldNotBeNull();
            _roleOrTerritoryInstance.ShouldNotBeNull();
            _roleOrTerritoryInstanceFixture.ShouldNotBeNull();
            _roleOrTerritoryInstance.ShouldBeAssignableTo<RoleOrTerritory>();
            _roleOrTerritoryInstanceFixture.ShouldBeAssignableTo<RoleOrTerritory>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (RoleOrTerritory) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertycaseAccessLevel)]
        [TestCaseGeneric(typeof(string) , PropertycontactAccessLevel)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(bool) , PropertymayForecastManagerShare)]
        [TestCaseGeneric(typeof(bool) , PropertymayForecastManagerShareSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(string) , PropertyopportunityAccessLevel)]
        public void AUT_RoleOrTerritory_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<RoleOrTerritory, T>(_roleOrTerritoryInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (RoleOrTerritory) => Property (caseAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RoleOrTerritory_Public_Class_caseAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseAccessLevel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RoleOrTerritory) => Property (contactAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RoleOrTerritory_Public_Class_contactAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycontactAccessLevel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RoleOrTerritory) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RoleOrTerritory_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RoleOrTerritory) => Property (mayForecastManagerShare) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RoleOrTerritory_Public_Class_mayForecastManagerShare_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymayForecastManagerShare);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RoleOrTerritory) => Property (mayForecastManagerShareSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RoleOrTerritory_Public_Class_mayForecastManagerShareSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymayForecastManagerShareSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RoleOrTerritory) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RoleOrTerritory_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (RoleOrTerritory) => Property (opportunityAccessLevel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_RoleOrTerritory_Public_Class_opportunityAccessLevel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyopportunityAccessLevel);

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