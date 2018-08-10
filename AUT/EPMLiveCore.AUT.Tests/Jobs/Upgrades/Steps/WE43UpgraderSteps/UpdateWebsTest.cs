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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps.UpdateWebs" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.Upgrades.Steps.WE43UpgraderSteps"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class UpdateWebsTest : AbstractBaseSetupTypedTest<UpdateWebs>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (UpdateWebs) Initializer

        private const string PropertyDescription = "Description";
        private const string MethodPerform = "Perform";
        private const string MethodgetCategoryName = "getCategoryName";
        private const string MethodgetCategoryNumber = "getCategoryNumber";
        private const string MethodUpdateSettings = "UpdateSettings";
        private const string MethodAddCommunity = "AddCommunity";
        private const string MethodActivateAppsList = "ActivateAppsList";
        private const string MethodUpdateMaster = "UpdateMaster";
        private const string MethodChangeMasterPage = "ChangeMasterPage";
        private const string MethodActivateFeature = "ActivateFeature";
        private Type _updateWebsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private UpdateWebs _updateWebsInstance;
        private UpdateWebs _updateWebsInstanceFixture;

        #region General Initializer : Class (UpdateWebs) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="UpdateWebs" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _updateWebsInstanceType = typeof(UpdateWebs);
            _updateWebsInstanceFixture = Create(true);
            _updateWebsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (UpdateWebs)

        #region General Initializer : Class (UpdateWebs) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="UpdateWebs" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(MethodPerform, 0)]
        [TestCase(MethodgetCategoryName, 0)]
        [TestCase(MethodgetCategoryNumber, 0)]
        [TestCase(MethodUpdateSettings, 0)]
        [TestCase(MethodAddCommunity, 0)]
        [TestCase(MethodActivateAppsList, 0)]
        [TestCase(MethodUpdateMaster, 0)]
        [TestCase(MethodChangeMasterPage, 0)]
        [TestCase(MethodActivateFeature, 0)]
        public void AUT_UpdateWebs_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_updateWebsInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (UpdateWebs) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="UpdateWebs" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(PropertyDescription)]
        public void AUT_UpdateWebs_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_updateWebsInstanceFixture,
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
        ///      Class (<see cref="UpdateWebs" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(MethodPerform)]
        [TestCase(MethodgetCategoryName)]
        [TestCase(MethodgetCategoryNumber)]
        [TestCase(MethodUpdateSettings)]
        [TestCase(MethodAddCommunity)]
        [TestCase(MethodActivateAppsList)]
        [TestCase(MethodUpdateMaster)]
        [TestCase(MethodChangeMasterPage)]
        [TestCase(MethodActivateFeature)]
        public void AUT_UpdateWebs_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<UpdateWebs>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (Perform) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebs_Perform_Method_Call_Internally(Type[] types)
        {
            var methodPerformPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebsInstance, MethodPerform, Fixture, methodPerformPrametersTypes);
        }

        #endregion

        #region Method Call : (getCategoryName) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebs_getCategoryName_Method_Call_Internally(Type[] types)
        {
            var methodgetCategoryNamePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebsInstance, MethodgetCategoryName, Fixture, methodgetCategoryNamePrametersTypes);
        }

        #endregion

        #region Method Call : (getCategoryNumber) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebs_getCategoryNumber_Method_Call_Internally(Type[] types)
        {
            var methodgetCategoryNumberPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebsInstance, MethodgetCategoryNumber, Fixture, methodgetCategoryNumberPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebs_UpdateSettings_Method_Call_Internally(Type[] types)
        {
            var methodUpdateSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebsInstance, MethodUpdateSettings, Fixture, methodUpdateSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (AddCommunity) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebs_AddCommunity_Method_Call_Internally(Type[] types)
        {
            var methodAddCommunityPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebsInstance, MethodAddCommunity, Fixture, methodAddCommunityPrametersTypes);
        }

        #endregion

        #region Method Call : (ActivateAppsList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebs_ActivateAppsList_Method_Call_Internally(Type[] types)
        {
            var methodActivateAppsListPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebsInstance, MethodActivateAppsList, Fixture, methodActivateAppsListPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateMaster) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebs_UpdateMaster_Method_Call_Internally(Type[] types)
        {
            var methodUpdateMasterPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebsInstance, MethodUpdateMaster, Fixture, methodUpdateMasterPrametersTypes);
        }

        #endregion

        #region Method Call : (ChangeMasterPage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebs_ChangeMasterPage_Method_Call_Internally(Type[] types)
        {
            var methodChangeMasterPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebsInstance, MethodChangeMasterPage, Fixture, methodChangeMasterPagePrametersTypes);
        }

        #endregion

        #region Method Call : (ActivateFeature) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_UpdateWebs_ActivateFeature_Method_Call_Internally(Type[] types)
        {
            var methodActivateFeaturePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_updateWebsInstance, MethodActivateFeature, Fixture, methodActivateFeaturePrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}