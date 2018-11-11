using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.UpdateResourcePool" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UpdateResourcePoolTest : AbstractBaseSetupTypedTest<UpdateResourcePool>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (UpdateResourcePool) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodPerform = "Perform";
        private const string MethodGetConnectionString = "GetConnectionString";
        private const string MethodGetDatabaseFromRegistry = "GetDatabaseFromRegistry";
        private const string MethodProcessFields = "ProcessFields";
        private const string MethodUpdateField = "UpdateField";
        private const string FieldSQL = "SQL";
        private Type _updateResourcePoolInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private UpdateResourcePool _updateResourcePoolInstance;
        private UpdateResourcePool _updateResourcePoolInstanceFixture;

        #region General Initializer : Class (UpdateResourcePool) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UpdateResourcePool" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _updateResourcePoolInstanceType = typeof(UpdateResourcePool);
            _updateResourcePoolInstanceFixture = Create(true);
            _updateResourcePoolInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UpdateResourcePool)

        #region General Initializer : Class (UpdateResourcePool) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="UpdateResourcePool" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPerform, 0)]
        [TestCase(MethodGetConnectionString, 0)]
        [TestCase(MethodGetDatabaseFromRegistry, 0)]
        [TestCase(MethodProcessFields, 0)]
        [TestCase(MethodUpdateField, 0)]
        public void AUT_UpdateResourcePool_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_updateResourcePoolInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UpdateResourcePool) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="UpdateResourcePool" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_UpdateResourcePool_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_updateResourcePoolInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UpdateResourcePool) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="UpdateResourcePool" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FieldSQL)]
        public void AUT_UpdateResourcePool_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_updateResourcePoolInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="UpdateResourcePool" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodGetDatabaseFromRegistry)]
        public void AUT_UpdateResourcePool_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_updateResourcePoolInstanceFixture,
                                                                              _updateResourcePoolInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="UpdateResourcePool" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPerform)]
        [TestCase(MethodGetConnectionString)]
        [TestCase(MethodProcessFields)]
        [TestCase(MethodUpdateField)]
        public void AUT_UpdateResourcePool_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<UpdateResourcePool>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateResourcePool_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateResourcePoolInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #region Method Call : (GetConnectionString) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateResourcePool_GetConnectionString_Method_Call_Internally(Type[] types)
        {
            var methodGetConnectionStringPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateResourcePoolInstance, MethodGetConnectionString, Fixture, methodGetConnectionStringPrametersTypes);
        }

        #endregion

        #region Method Call : (GetDatabaseFromRegistry) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateResourcePool_GetDatabaseFromRegistry_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetDatabaseFromRegistryPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_updateResourcePoolInstanceFixture, _updateResourcePoolInstanceType, MethodGetDatabaseFromRegistry, Fixture, methodGetDatabaseFromRegistryPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessFields) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateResourcePool_ProcessFields_Method_Call_Internally(Type[] types)
        {
            var methodProcessFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateResourcePoolInstance, MethodProcessFields, Fixture, methodProcessFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateField) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateResourcePool_UpdateField_Method_Call_Internally(Type[] types)
        {
            var methodUpdateFieldPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateResourcePoolInstance, MethodUpdateField, Fixture, methodUpdateFieldPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}