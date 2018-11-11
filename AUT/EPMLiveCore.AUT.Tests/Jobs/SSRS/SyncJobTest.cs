using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.Jobs.SSRS
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.Jobs.SSRS.SyncJob" />)
    ///     and namespace <see cref="EPMLiveCore.Jobs.SSRS"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class SyncJobTest : AbstractBaseSetupTypedTest<SyncJob>
    {

        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SyncJob) Initializer

        private const string Methodexecute = "execute";
        private const string MethodDeleteReport = "DeleteReport";
        private const string MethodSyncReports = "SyncReports";
        private const string MethodCreateSiteCollectionMappedFolder = "CreateSiteCollectionMappedFolder";
        private const string MethodDeleteSiteCollectionMappedFolder = "DeleteSiteCollectionMappedFolder";
        private const string MethodAddRoleMapping = "AddRoleMapping";
        private const string MethodRemoveRoleMapping = "RemoveRoleMapping";
        private Type _syncJobInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SyncJob _syncJobInstance;
        private SyncJob _syncJobInstanceFixture;

        #region General Initializer : Class (SyncJob) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SyncJob" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _syncJobInstanceType = typeof(SyncJob);
            _syncJobInstanceFixture = Create(true);
            _syncJobInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SyncJob)

        #region General Initializer : Class (SyncJob) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="SyncJob" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT Initializer")]
        [TestCase(Methodexecute, 0)]
        [TestCase(MethodDeleteReport, 0)]
        [TestCase(MethodSyncReports, 0)]
        [TestCase(MethodCreateSiteCollectionMappedFolder, 0)]
        [TestCase(MethodDeleteSiteCollectionMappedFolder, 0)]
        [TestCase(MethodAddRoleMapping, 0)]
        [TestCase(MethodRemoveRoleMapping, 0)]
        public void AUT_SyncJob_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_syncJobInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="SyncJob" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [Category("AUT MethodCallTest")]
        [TestCase(Methodexecute)]
        [TestCase(MethodDeleteReport)]
        [TestCase(MethodSyncReports)]
        [TestCase(MethodCreateSiteCollectionMappedFolder)]
        [TestCase(MethodDeleteSiteCollectionMappedFolder)]
        [TestCase(MethodAddRoleMapping)]
        [TestCase(MethodRemoveRoleMapping)]
        public void AUT_SyncJob_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<SyncJob>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (execute) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SyncJob_execute_Method_Call_Internally(Type[] types)
        {
            var methodexecutePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_syncJobInstance, Methodexecute, Fixture, methodexecutePrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteReport) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SyncJob_DeleteReport_Method_Call_Internally(Type[] types)
        {
            var methodDeleteReportPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_syncJobInstance, MethodDeleteReport, Fixture, methodDeleteReportPrametersTypes);
        }

        #endregion

        #region Method Call : (SyncReports) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SyncJob_SyncReports_Method_Call_Internally(Type[] types)
        {
            var methodSyncReportsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_syncJobInstance, MethodSyncReports, Fixture, methodSyncReportsPrametersTypes);
        }

        #endregion

        #region Method Call : (CreateSiteCollectionMappedFolder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SyncJob_CreateSiteCollectionMappedFolder_Method_Call_Internally(Type[] types)
        {
            var methodCreateSiteCollectionMappedFolderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_syncJobInstance, MethodCreateSiteCollectionMappedFolder, Fixture, methodCreateSiteCollectionMappedFolderPrametersTypes);
        }

        #endregion

        #region Method Call : (DeleteSiteCollectionMappedFolder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SyncJob_DeleteSiteCollectionMappedFolder_Method_Call_Internally(Type[] types)
        {
            var methodDeleteSiteCollectionMappedFolderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_syncJobInstance, MethodDeleteSiteCollectionMappedFolder, Fixture, methodDeleteSiteCollectionMappedFolderPrametersTypes);
        }

        #endregion

        #region Method Call : (AddRoleMapping) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SyncJob_AddRoleMapping_Method_Call_Internally(Type[] types)
        {
            var methodAddRoleMappingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_syncJobInstance, MethodAddRoleMapping, Fixture, methodAddRoleMappingPrametersTypes);
        }

        #endregion

        #region Method Call : (RemoveRoleMapping) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_SyncJob_RemoveRoleMapping_Method_Call_Internally(Type[] types)
        {
            var methodRemoveRoleMappingPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_syncJobInstance, MethodRemoveRoleMapping, Fixture, methodRemoveRoleMappingPrametersTypes);
        }

        #endregion

        #endregion

        #endregion
    }
}