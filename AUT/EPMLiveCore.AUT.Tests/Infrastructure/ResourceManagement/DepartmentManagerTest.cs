using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;

namespace EPMLiveCore.Infrastructure
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Infrastructure.DepartmentManager" />)
    ///     and namespace <see cref="EPMLiveCore.Infrastructure"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class DepartmentManagerTest : AbstractBaseSetupTypedTest<DepartmentManager>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DepartmentManager) Initializer

        private Type _departmentManagerInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DepartmentManager _departmentManagerInstance;
        private DepartmentManager _departmentManagerInstanceFixture;

        #region General Initializer : Class (DepartmentManager) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DepartmentManager" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _departmentManagerInstanceType = typeof(DepartmentManager);
            _departmentManagerInstanceFixture = Create(true);
            _departmentManagerInstance = Create(false);
        }

        #endregion

        #endregion

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DepartmentManager) constructors coverage gain tests by index

        /// <summary>
        ///     Class (<see cref="DepartmentManager" />) explore and verify it's constructors by index.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        [TestCase(0)]
        [TestCase(1)]
        public void AUT_DepartmentManager_Constructor_Explore_Verify_By_Index_Test(int constructorIndex)
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructor<DepartmentManager>(Fixture, constructorIndex);
        }

        #endregion

        #region General Constructor : Class (DepartmentManager) constructors coverage gain tests

        /// <summary>
        ///     Explore and verify all constructors of Class (<see cref="DepartmentManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DepartmentManager_All_Constructors_Explore_Verify_Test()
        {
            // Assert
            ShouldlyExtension.ExploreVerifyConstructors<DepartmentManager>(Fixture);
        }

        #endregion

        #region General Constructor : Class (DepartmentManager) constructors with parameter () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DepartmentManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DepartmentManager_Constructors_Explore_Verify_Test()
        {
            // Arrange
            object[] parametersOfDepartmentManager = {  };
            Type [] methodDepartmentManagerPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByGivenParameters(_departmentManagerInstanceType, methodDepartmentManagerPrametersTypes, parametersOfDepartmentManager);
        }

        #endregion

        #region General Constructor : Class (DepartmentManager) constructors with dynamic parameters () coverage gain tests

        /// <summary>
        ///     Explore and verify constructors (with / without parameter) of Class (<see cref="DepartmentManager" />).
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Constructor")]
        public void AUT_DepartmentManager_Constructors_With_Dynamic_Explore_Verify_Test()
        {
            // Arrange
            Type [] methodDepartmentManagerPrametersTypes = null;

            // Assert
            ShouldlyExtension.ExploreVerifyConstructorByDynamicParameters(_departmentManagerInstanceType, Fixture, methodDepartmentManagerPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}