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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.InstallAndConfigureLists" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class InstallAndConfigureListsTest : AbstractBaseSetupTypedTest<InstallAndConfigureLists>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (InstallAndConfigureLists) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodPerform = "Perform";
        private const string MethodDownloadAndInstallList = "DownloadAndInstallList";
        private const string Fieldstoreurl = "storeurl";
        private const string Fieldsolutions = "solutions";
        private Type _installAndConfigureListsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private InstallAndConfigureLists _installAndConfigureListsInstance;
        private InstallAndConfigureLists _installAndConfigureListsInstanceFixture;

        #region General Initializer : Class (InstallAndConfigureLists) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="InstallAndConfigureLists" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _installAndConfigureListsInstanceType = typeof(InstallAndConfigureLists);
            _installAndConfigureListsInstanceFixture = Create(true);
            _installAndConfigureListsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (InstallAndConfigureLists)

        #region General Initializer : Class (InstallAndConfigureLists) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="InstallAndConfigureLists" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPerform, 0)]
        [TestCase(MethodDownloadAndInstallList, 0)]
        public void AUT_InstallAndConfigureLists_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_installAndConfigureListsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (InstallAndConfigureLists) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="InstallAndConfigureLists" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_InstallAndConfigureLists_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_installAndConfigureListsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (InstallAndConfigureLists) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="InstallAndConfigureLists" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Fieldstoreurl)]
        [TestCase(Fieldsolutions)]
        public void AUT_InstallAndConfigureLists_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_installAndConfigureListsInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : GetterSetter

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="InstallAndConfigureLists" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPerform)]
        [TestCase(MethodDownloadAndInstallList)]
        public void AUT_InstallAndConfigureLists_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<InstallAndConfigureLists>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallAndConfigureLists_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installAndConfigureListsInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #region Method Call : (DownloadAndInstallList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_InstallAndConfigureLists_DownloadAndInstallList_Method_Call_Internally(Type[] types)
        {
            var methodDownloadAndInstallListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_installAndConfigureListsInstance, MethodDownloadAndInstallList, Fixture, methodDownloadAndInstallListPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}