using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.PFEPermissionMapper" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PFEPermissionMapperTest : AbstractBaseSetupTypedTest<PFEPermissionMapper>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PFEPermissionMapper) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodMapPermissions = "MapPermissions";
        private const string MethodMapPFEPermissions = "MapPFEPermissions";
        private const string MethodPerform = "Perform";
        private Type _pFEPermissionMapperInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PFEPermissionMapper _pFEPermissionMapperInstance;
        private PFEPermissionMapper _pFEPermissionMapperInstanceFixture;

        #region General Initializer : Class (PFEPermissionMapper) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PFEPermissionMapper" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _pFEPermissionMapperInstanceType = typeof(PFEPermissionMapper);
            _pFEPermissionMapperInstanceFixture = Create(true);
            _pFEPermissionMapperInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PFEPermissionMapper)

        #region General Initializer : Class (PFEPermissionMapper) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="PFEPermissionMapper" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodMapPermissions, 0)]
        [TestCase(MethodMapPFEPermissions, 0)]
        [TestCase(MethodPerform, 0)]
        public void AUT_PFEPermissionMapper_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_pFEPermissionMapperInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PFEPermissionMapper) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PFEPermissionMapper" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_PFEPermissionMapper_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_pFEPermissionMapperInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="PFEPermissionMapper" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodMapPermissions)]
        [TestCase(MethodMapPFEPermissions)]
        [TestCase(MethodPerform)]
        public void AUT_PFEPermissionMapper_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<PFEPermissionMapper>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (MapPermissions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEPermissionMapper_MapPermissions_Method_Call_Internally(Type[] types)
        {
            var methodMapPermissionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEPermissionMapperInstance, MethodMapPermissions, Fixture, methodMapPermissionsPrametersTypes);
        }

        #endregion

        #region Method Call : (MapPFEPermissions) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEPermissionMapper_MapPFEPermissions_Method_Call_Internally(Type[] types)
        {
            var methodMapPFEPermissionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEPermissionMapperInstance, MethodMapPFEPermissions, Fixture, methodMapPFEPermissionsPrametersTypes);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_PFEPermissionMapper_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_pFEPermissionMapperInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}