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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Territory" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TerritoryTest : AbstractBaseSetupTypedTest<Territory>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Territory) Initializer

        private const string PropertyparentTerritory = "parentTerritory";
        private const string FieldparentTerritoryField = "parentTerritoryField";
        private Type _territoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Territory _territoryInstance;
        private Territory _territoryInstanceFixture;

        #region General Initializer : Class (Territory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Territory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _territoryInstanceType = typeof(Territory);
            _territoryInstanceFixture = Create(true);
            _territoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Territory)

        #region General Initializer : Class (Territory) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Territory" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyparentTerritory)]
        public void AUT_Territory_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_territoryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Territory) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Territory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldparentTerritoryField)]
        public void AUT_Territory_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_territoryInstanceFixture, 
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
        ///     Class (<see cref="Territory" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Territory_Is_Instance_Present_Test()
        {
            // Assert
            _territoryInstanceType.ShouldNotBeNull();
            _territoryInstance.ShouldNotBeNull();
            _territoryInstanceFixture.ShouldNotBeNull();
            _territoryInstance.ShouldBeAssignableTo<Territory>();
            _territoryInstanceFixture.ShouldBeAssignableTo<Territory>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Territory) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Territory_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Territory instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _territoryInstanceType.ShouldNotBeNull();
            _territoryInstance.ShouldNotBeNull();
            _territoryInstanceFixture.ShouldNotBeNull();
            _territoryInstance.ShouldBeAssignableTo<Territory>();
            _territoryInstanceFixture.ShouldBeAssignableTo<Territory>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Territory) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyparentTerritory)]
        public void AUT_Territory_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Territory, T>(_territoryInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Territory) => Property (parentTerritory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Territory_Public_Class_parentTerritory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyparentTerritory);

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