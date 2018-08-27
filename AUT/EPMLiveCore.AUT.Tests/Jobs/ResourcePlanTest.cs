using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.ResourcePlan" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ResourcePlanTest : AbstractBaseSetupTypedTest<ResourcePlan>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResourcePlan) Initializer

        private const string Methodexecute = "execute";
        private const string MethodprocessResPlan = "processResPlan";
        private const string MethodstoreResPlanInfo = "storeResPlanInfo";
        private const string MethodgetResUrl = "getResUrl";
        private const string MethodBuildResourceInfoDataTable = "BuildResourceInfoDataTable";
        private const string MethodBuildResourceLinkDataTable = "BuildResourceLinkDataTable";
        private const string MethodProcessResourcePlan = "ProcessResourcePlan";
        private const string MethodProcessResourcePlanList = "ProcessResourcePlanList";
        private const string MethodProcessResourcePlanListItem = "ProcessResourcePlanListItem";
        private const string FielddtResLink = "dtResLink";
        private const string FielddtResInfo = "dtResInfo";
        private const string FieldsbErrors = "sbErrors";
        private Type _resourcePlanInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResourcePlan _resourcePlanInstance;
        private ResourcePlan _resourcePlanInstanceFixture;

        #region General Initializer : Class (ResourcePlan) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResourcePlan" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resourcePlanInstanceType = typeof(ResourcePlan);
            _resourcePlanInstanceFixture = Create(true);
            _resourcePlanInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResourcePlan)

        #region General Initializer : Class (ResourcePlan) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResourcePlan" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(FielddtResLink)]
        [TestCase(FielddtResInfo)]
        [TestCase(FieldsbErrors)]
        public void AUT_ResourcePlan_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resourcePlanInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ResourcePlan" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        [TestCase(MethodprocessResPlan)]
        [TestCase(MethodstoreResPlanInfo)]
        [TestCase(MethodgetResUrl)]
        public void AUT_ResourcePlan_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ResourcePlan>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlan_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (processResPlan) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlan_processResPlan_Method_Call_Internally(Type[] types)
        {
            var methodprocessResPlanPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanInstance, MethodprocessResPlan, Fixture, methodprocessResPlanPrametersTypes);
        }

        #endregion

        #region Method Call : (storeResPlanInfo) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlan_storeResPlanInfo_Method_Call_Internally(Type[] types)
        {
            var methodstoreResPlanInfoPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanInstance, MethodstoreResPlanInfo, Fixture, methodstoreResPlanInfoPrametersTypes);
        }

        #endregion

        #region Method Call : (getResUrl) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlan_getResUrl_Method_Call_Internally(Type[] types)
        {
            var methodgetResUrlPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_resourcePlanInstance, MethodgetResUrl, Fixture, methodgetResUrlPrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResourceInfoDataTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlan_BuildResourceInfoDataTable_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildResourceInfoDataTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourcePlanInstanceFixture, _resourcePlanInstanceType, MethodBuildResourceInfoDataTable, Fixture, methodBuildResourceInfoDataTablePrametersTypes);
        }

        #endregion

        #region Method Call : (BuildResourceLinkDataTable) (Return Type : DataTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlan_BuildResourceLinkDataTable_Static_Method_Call_Internally(Type[] types)
        {
            var methodBuildResourceLinkDataTablePrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourcePlanInstanceFixture, _resourcePlanInstanceType, MethodBuildResourceLinkDataTable, Fixture, methodBuildResourceLinkDataTablePrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessResourcePlan) (Return Type : ResourcePlanProcessingResult) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlan_ProcessResourcePlan_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessResourcePlanPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourcePlanInstanceFixture, _resourcePlanInstanceType, MethodProcessResourcePlan, Fixture, methodProcessResourcePlanPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessResourcePlanList) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlan_ProcessResourcePlanList_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessResourcePlanListPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourcePlanInstanceFixture, _resourcePlanInstanceType, MethodProcessResourcePlanList, Fixture, methodProcessResourcePlanListPrametersTypes);
        }

        #endregion

        #region Method Call : (ProcessResourcePlanListItem) (Return Type : IEnumerable<ResourcePlanProcessingResult.ResourceInfo>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ResourcePlan_ProcessResourcePlanListItem_Static_Method_Call_Internally(Type[] types)
        {
            var methodProcessResourcePlanListItemPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_resourcePlanInstanceFixture, _resourcePlanInstanceType, MethodProcessResourcePlanListItem, Fixture, methodProcessResourcePlanListItemPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}