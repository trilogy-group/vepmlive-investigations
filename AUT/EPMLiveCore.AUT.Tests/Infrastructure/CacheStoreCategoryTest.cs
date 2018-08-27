using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.CacheStoreCategory" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class CacheStoreCategoryTest : AbstractBaseSetupTypedTest<CacheStoreCategory>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CacheStoreCategory) Initializer

        private const string PropertyNavigation = "Navigation";
        private const string PropertyResourceGrid = "ResourceGrid";
        private const string PropertySocialStream = "SocialStream";
        private const string FieldInfrastructure = "Infrastructure";
        private const string Field_siteId = "_siteId";
        private const string Field_webId = "_webId";
        private Type _cacheStoreCategoryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CacheStoreCategory _cacheStoreCategoryInstance;
        private CacheStoreCategory _cacheStoreCategoryInstanceFixture;

        #region General Initializer : Class (CacheStoreCategory) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CacheStoreCategory" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _cacheStoreCategoryInstanceType = typeof(CacheStoreCategory);
            _cacheStoreCategoryInstanceFixture = Create(true);
            _cacheStoreCategoryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CacheStoreCategory)

        #region General Initializer : Class (CacheStoreCategory) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CacheStoreCategory" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyNavigation)]
        [TestCase(PropertyResourceGrid)]
        [TestCase(PropertySocialStream)]
        public void AUT_CacheStoreCategory_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_cacheStoreCategoryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CacheStoreCategory) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CacheStoreCategory" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldInfrastructure)]
        [TestCase(Field_siteId)]
        [TestCase(Field_webId)]
        public void AUT_CacheStoreCategory_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_cacheStoreCategoryInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CacheStoreCategory) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyNavigation)]
        [TestCaseGeneric(typeof(string) , PropertyResourceGrid)]
        [TestCaseGeneric(typeof(string) , PropertySocialStream)]
        public void AUT_CacheStoreCategory_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CacheStoreCategory, T>(_cacheStoreCategoryInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CacheStoreCategory) => Property (Navigation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CacheStoreCategory_Public_Class_Navigation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyNavigation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CacheStoreCategory) => Property (ResourceGrid) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CacheStoreCategory_Public_Class_ResourceGrid_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyResourceGrid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CacheStoreCategory) => Property (SocialStream) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_CacheStoreCategory_Public_Class_SocialStream_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertySocialStream);

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