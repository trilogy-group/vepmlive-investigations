using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.BaseManager" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class BaseManagerTest : AbstractBaseSetupTypedTest<BaseManager>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (BaseManager) Initializer

        private const string PropertyWeb = "Web";
        private Type _baseManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private BaseManager _baseManagerInstance;
        private BaseManager _baseManagerInstanceFixture;
        private Type[] _abstractClassInstanciatedTypesList;
        
        #endregion

        #region Explore Class for Coverage Gain : Class (BaseManager)

        #region General Initializer : Class (BaseManager) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="BaseManager" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyWeb)]
        public void AUT_BaseManager_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_baseManagerInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (BaseManager) => Property (Web) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT GetterSetter")]
        public void AUT_BaseManager_Public_Class_Web_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyWeb);

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